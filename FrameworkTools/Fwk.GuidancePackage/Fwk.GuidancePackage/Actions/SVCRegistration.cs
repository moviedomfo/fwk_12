#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using Fwk.Transaction;
using System.IO;
using System.Windows.Forms;
using System.Text;
using Fwk.Guidance.Core;

#endregion

namespace Fwk.GuidPk.Actions
{
    public class SVCRegistrationAction : Microsoft.Practices.RecipeFramework.Action
    {
        #region Input Properties
        string serviceName;
        

        EnvDTE.Project prj;

        [Input]
        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }
        
        [Input(Required = true)]
        public EnvDTE.Project Project
        {
            get { return prj; }
            set { prj = value; }
        }
        
        #endregion

        #region Output Properties

     
        #endregion

        #region IAction Members

        public override void Execute()
        {
            Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting = FwkGenerator.TemplateSettingFactoty();
            Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting.Project.ProjectName = Project.Name;

            Fwk.Bases.ServiceConfiguration cngf = new Bases.ServiceConfiguration();


            
            cngf.Name = serviceName;
            cngf.Available = true;
            cngf.CreatedDateTime = Now;
            cngf.CreatedUserName = Environment.UserName;
            cngf.Request = string.Concat(string.Concat(Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting.Project.InterfaceServices, ".", serviceName, "Req ,"), Project.Name);
            cngf.Response = string.Concat(string.Concat(Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting.Project.InterfaceServices, ".", serviceName, "Res ,"), Project.Name);
            cngf.Handler = string.Concat(string.Concat(Fwk.CodeGenerator.FwkGeneratorHelper.TemplateSetting.Project.BusinessService, ".", serviceName, "Service ,"), Project.Name);


            cngf.IsolationLevel = Transaction.IsolationLevel.ReadCommitted;
            if (Fwk.Guidance.Core.HelperFunctions.RequiresNew(serviceName))
            {
                cngf.TransactionalBehaviour = TransactionalBehaviour.RequiresNew;
            }
            else
            {
                cngf.TransactionalBehaviour = TransactionalBehaviour.Suppres;
            }

            string foldert = System.IO.Path.GetDirectoryName(Project.FullName);
            string fileFullName = string.Empty;
            DirectoryInfo dInfo = new DirectoryInfo(foldert);

            if (!System.IO.Directory.Exists("Metadata"))
                dInfo = dInfo.CreateSubdirectory("Metadata");
            StringBuilder err = new StringBuilder();
            try
            {
                fileFullName = Path.Combine(dInfo.FullName, string.Concat(serviceName, ".xml"));

                Fwk.HelperFunctions.FileFunctions.SaveTextFile(fileFullName, cngf.GetXml());
                Project.ProjectItems.AddFromFile(fileFullName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("The SVC's classes was successfully generated with errors /r",
                    Fwk.Exceptions.ExceptionHelper.GetAllMessageException( ex)), Fwk.GuidPk.Properties.Resources.ProductTitle,
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

              

        }

        public override void Undo()
        {
            

        }

        #endregion

        public DateTime Now { get; set; }
    }
}

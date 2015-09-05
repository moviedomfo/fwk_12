#region Using Directives

using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using Microsoft.Practices.RecipeFramework.Library;
using Microsoft.Practices.RecipeFramework.Services;
using Microsoft.Practices.RecipeFramework.VisualStudio;
using Microsoft.Practices.RecipeFramework.VisualStudio.Templates;
using EnvDTE;
using Fwk.CodeGenerator;
using System.Text;

#endregion

namespace Fwk.GuidPk.Actions
{
    [ServiceDependency(typeof(DTE))]
    public class AddBE : Microsoft.Practices.RecipeFramework.Action
    {
        #region Input Properties

         GeneratedCode[] _GeneratedCodeList;
        
        EnvDTE.Project prj;
        /// <summary>
        /// Specifies the filename name of the template 
        /// we are going to reference
        /// </summary>
        [Input(Required = true)]
        public GeneratedCode[] GeneratedCodeList
        {
            get { return _GeneratedCodeList; }
            set { _GeneratedCodeList = value; }
        }
        
        [Input(Required = true)]
        public EnvDTE.Project Project
        {
            get { return prj; }
            set { prj = value; }
        }
        
     


        #endregion

        

        #region IAction Members

        public override void Execute()
        {
            DTE vs = GetService<DTE>(true);
            IAssetReferenceService referenceService = GetService<IAssetReferenceService>(true);
            object item = DteHelper.GetTarget(vs);

            CreateFolderAndFiles(Project);

        }

        void CreateFolderAndFiles(EnvDTE.Project currentProject)
        {
            string foldert = System.IO.Path.GetDirectoryName(currentProject.FullName);
            string fileFullName = string.Empty;
            DirectoryInfo dInfo = new DirectoryInfo(foldert);
            DialogResult res = DialogResult.OK;
            if (!System.IO.Directory.Exists("Entities"))
                dInfo = dInfo.CreateSubdirectory("Entities");
            StringBuilder err = new StringBuilder();
            foreach (GeneratedCode genCode in _GeneratedCodeList)
            {
                fileFullName = Path.Combine(dInfo.FullName, string.Concat(genCode.Id, ".cs"));
                try
                {
                    // Check it the targetFileName already exists and delete it so it can be added.
                    //ProjectItem targetItem = VSIPHelper.FindItemByName(Project.ProjectItems, fileFullName, true);
                    if (File.Exists(fileFullName))
                    {
                        res = MessageBox.Show(string.Concat("Entity file: ", Path.GetFileName(fileFullName), " already exist. /n do you want to replaced it?"), Fwk.GuidPk.Properties.Resources.ProductTitle,
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    if (res == DialogResult.OK)
                    {
                        Fwk.HelperFunctions.FileFunctions.SaveTextFile(fileFullName, genCode.Code.ToString());
                        currentProject.ProjectItems.AddFromFile(fileFullName);
                    }
                }
                catch (Exception ex)
                {
                    err.AppendLine(ex.Message);
                }
            }
            if (err.Length != 0)

                MessageBox.Show(string.Concat("The Entities classes was successfully generated with errors /r", err.ToString()), Fwk.GuidPk.Properties.Resources.ProductTitle,
               MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else

                MessageBox.Show("The new Entities class was successfully generated.", Fwk.GuidPk.Properties.Resources.ProductTitle,
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public override void Undo()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}

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
    public class AddDAC : Microsoft.Practices.RecipeFramework.Action
    {
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
        
     

        /// <summary>
        /// Adds the template reference to the IAssetReferenceService
        /// </summary>
        public override void Execute()
        {
            DTE vs = GetService<DTE>(true);
            IAssetReferenceService referenceService = GetService<IAssetReferenceService>(true);
            object item = DteHelper.GetTarget(vs);

            CreateFolderAndFiles(Project);

            

            if (item == null)
                throw new InvalidOperationException("There is no valid target to create any DAC .");

            if (item is EnvDTE.Project)
            {

                EnvDTE.Project p = (EnvDTE.Project)item;
                
               // p.ProjectItems.AddFromFile();
            }
            else if (item is Solution)
            {
               // addedReference = new SolutionReference(recipeName, (Solution)item);
            }
            else if (item is ProjectItem)
            {
              //  addedReference = new ProjectItemReference(recipeName, (ProjectItem)item);
            }
            else
            {
                throw new NotSupportedException("Current selection is unsupported.");
            }

            //referenceService.Add(addedReference);

            //MessageBox.Show("The new reference was successfully added.", "New Reference",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void CreateFolderAndFiles(EnvDTE.Project currentProject)
        {
            string foldert = System.IO.Path.GetDirectoryName(currentProject.FullName);
            string fileFullName = string.Empty;
            DirectoryInfo dInfo = new DirectoryInfo(foldert);
            DialogResult res = DialogResult.OK;
            if (!System.IO.Directory.Exists("DAC"))
                dInfo = dInfo.CreateSubdirectory("DAC");
            StringBuilder err = new StringBuilder();
            foreach (GeneratedCode genCode in _GeneratedCodeList)
            {
                fileFullName = Path.Combine(dInfo.FullName, string.Concat(genCode.Id, "DAC.cs"));
                try
                {
                    // Check it the targetFileName already exists and delete it so it can be added.
                    //ProjectItem targetItem = VSIPHelper.FindItemByName(Project.ProjectItems, fileFullName, true);
                    if (File.Exists(fileFullName))
                    {
                        res = MessageBox.Show(string.Concat("DAC file: ", Path.GetFileName(fileFullName), " already exist. /n do you want to replaced it?"), Fwk.GuidPk.Properties.Resources.ProductTitle,
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

                MessageBox.Show(string.Concat("The DAC's classes was successfully generated with errors /r", err.ToString()), Fwk.GuidPk.Properties.Resources.ProductTitle,
               MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else

                MessageBox.Show("The new DAC's class was successfully generated.", Fwk.GuidPk.Properties.Resources.ProductTitle,
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        /// <summary>
        /// Removes the previously added reference, if it was created
        /// </summary>
        public override void Undo()
        {
            //if (addedReference != null)
            //{
            //    IAssetReferenceService referenceService = GetService<IAssetReferenceService>(true);
            //   referenceService.Remove(addedReference);
            //}
        }
    }
}
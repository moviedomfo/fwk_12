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
using System.Text;

#endregion
namespace Fwk.GuidPk.Actions
{


    [ServiceDependency(typeof(DTE))]
    public class AddItemFromStringAction : Microsoft.Practices.RecipeFramework.Action
    {
        #region Properties

        private string content;
        /// <summary>
        /// The string with the content of the item. In most cases it is a class
        /// generated using the T3 engine.
        /// </summary>
        [Input(Required = true)]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string targetFileName;
        /// <summary>
        /// Name of the file where the item is to be stored.
        /// </summary>
        [Input(Required = true)]
        public string TargetFileName
        {
            get { return targetFileName; }
            set { targetFileName = value; }
        }

        private Project project;
        /// <summary>
        /// Project where the item it to be inserted.
        /// </summary>
        [Input(Required = true)]
        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        private bool open = true;
        /// <summary>
        /// A flag to indicate if the newly created item should be shown
        /// in a window.
        /// </summary>
        [Input]
        public bool Open
        {
            get { return open; }
            set { open = value; }
        }

        private string itemName;
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        [Input(Required = false)]
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private EnvDTE.ProjectItem projectItem;
        /// <summary>
        /// A property that can be used to pass the creted item to
        /// a following action.
        /// </summary>
        [Output]
        public EnvDTE.ProjectItem ProjectItem
        {
            get { return projectItem; }
            set { projectItem = value; }
        }
        private string subfolder;
        [Input(Required = true)]
        public string Subfolder
        {
            get { return subfolder; }
            set { subfolder = value; }
        }
        #endregion

        #region Protected Implementation
        /// <summary>
        /// Called when [execute].
        /// </summary>
        public override void Execute()
        {
            string tempfile = Path.GetTempFileName();

            try
            {

                //string foldert = System.IO.Path.GetDirectoryName(Project.FullName);
                string fileFullName = string.Empty;
                //DirectoryInfo dInfo = new DirectoryInfo(foldert);
                ProjectItem folderItem = VSIPHelper.FindItemByName(Project.ProjectItems, Subfolder, true);
                if (folderItem==null)
                    try
                    {
                        project.ProjectItems.AddFolder(Subfolder);
                        folderItem = VSIPHelper.FindItemByName(Project.ProjectItems, Subfolder, true);
                    }
                    catch
                    { }
           
                using (StreamWriter sw = new StreamWriter(tempfile, false, new UTF8Encoding(true, true)))
                {
                    sw.WriteLine(content);
                }

                // Check it the targetFileName already exists and delete it so it can be added.
                ProjectItem targetItem = VSIPHelper.FindItemByName(Project.ProjectItems, targetFileName, true);
                if (targetItem != null)
                {
                    targetItem.Delete();
                }

                if (!String.IsNullOrEmpty(itemName))
                {
                    ProjectItem item = VSIPHelper.FindItemByName(Project.ProjectItems, itemName, true);

                    if (item != null)
                    {
                        projectItem = item.ProjectItems.AddFromTemplate(tempfile, targetFileName);
                    }
                }
                else
                {
                    //projectItem = project.ProjectItems.AddFromTemplate(tempfile, targetFileName);
                    projectItem = folderItem.ProjectItems.AddFromTemplate(tempfile, targetFileName);
                }

                if (open && projectItem != null)
                {
                    Window wnd = projectItem.Open(EnvDTE.Constants.vsViewKindPrimary);
                    wnd.Visible = true;
                    wnd.Activate();
                }
            }
            finally
            {
                File.Delete(tempfile);
            }
        }

        /// <summary>
        /// Called when [undo].
        /// </summary>
        public override void Undo()
        {
            if (projectItem != null)
            {
                projectItem.Delete();
            }
        }
        #endregion
    }



    /// <summary>
    /// Adds a new template reference to the IAssetReferenceService
    /// It needs the templatefilename
    /// </summary>
    [ServiceDependency(typeof(DTE))]
    public class AddTemplateReference : Microsoft.Practices.RecipeFramework.Action
    {
        #region Input Properties

        /// <summary>
        /// Specifies the filename name of the template 
        /// we are going to reference
        /// </summary>
        [Input(Required = true)]
        public string TemplateFilename
        {
            get { return templateFilename; }
            set { templateFilename = value; }
        } string templateFilename;

        #endregion

        #region Output Properties


        /// <summary>
        /// Instance to the new added reference
        /// </summary>
        [Output]
        public IBoundAssetReference NewReference
        {
            get { return newReference; }
            set { newReference = value; }
        } IBoundAssetReference newReference;

        #endregion

        /// <summary>
        /// Adds the template reference to the IAssetReferenceService
        /// </summary>
        public override void Execute()
        {
            EnvDTE.DTE dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
            IAssetReferenceService referenceService = (IAssetReferenceService)GetService(typeof(IAssetReferenceService));
            object item = DteHelper.GetTarget(dte);



            if (item == null)
            {
                MessageBox.Show("There is no valid target to reference the template");
                return;
            }
            templateFilename = new Uri(templateFilename).LocalPath;

            VsBoundReference vsTarget = null;
            if (item is Project)
            {
                vsTarget = new ProjectReference(templateFilename, (Project)item);
            }
            else if (item is Solution)
            {
                vsTarget = new SolutionReference(templateFilename, (Solution)item);
            }
            else if (item is ProjectItem)
            {
                vsTarget = new ProjectItemReference(templateFilename, (ProjectItem)item);
            }
            else if (item is EnvDTE80.SolutionFolder)
            {
                vsTarget = new ProjectReference(templateFilename, ((EnvDTE80.SolutionFolder)item).Parent);
            }
            if (item == null || vsTarget == null)
            {
                MessageBox.Show(string.Format(
                    CultureInfo.CurrentCulture,
                    "Target {0} specified for reference to asset {1} doesn't exist.",
                    "target", templateFilename));
                return;
            }
            if (!File.Exists(templateFilename) || !templateFilename.EndsWith(".vstemplate", StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show(string.Format(
                    CultureInfo.CurrentCulture,
                    "The filename specified for the template \"{0}\" does not exist.",
                    templateFilename));
                return;
            }
            newReference = new BoundTemplateReference(templateFilename, vsTarget);
            referenceService.Add(newReference);
            MessageBox.Show("The new reference was successfully added", "New Reference",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Removes the previously added reference, if it was created
        /// </summary>
        public override void Undo()
        {
            if (newReference != null)
            {
                IAssetReferenceService referenceService = (IAssetReferenceService)GetService(typeof(IAssetReferenceService));
                referenceService.Remove(newReference);
            }
        }
    }
}

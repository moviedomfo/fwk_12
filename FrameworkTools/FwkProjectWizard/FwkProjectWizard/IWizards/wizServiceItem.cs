using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.VisualStudio.TemplateWizard;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{

    public class wizServiceItem : IWizard
    {
        #region IWizard Members
        frmWizService inputForm;
        EnvDTE.Solution solution;
        EnvDTE.Project selectedProject;
        EnvDTE.Project projectIsvc;
        EnvDTE.Project projectSvc;

        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {

           
        }

        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
           
        }

        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
          
        }

        public void RunFinished()
        {
            string prjPath;

           
            try
            {

              
                prjPath = System.IO.Path.GetDirectoryName(projectIsvc.FullName);
                HelperFunctions.SaveTextFile(System.IO.Path.Combine(prjPath, inputForm.ServiceName + ".cs"), inputForm.IsvcCode, false);
                projectIsvc.ProjectItems.AddFromFile(System.IO.Path.Combine(prjPath, inputForm.ServiceName + ".cs"));


              
                prjPath = System.IO.Path.GetDirectoryName(projectSvc.FullName);
                HelperFunctions.SaveTextFile(System.IO.Path.Combine(prjPath, inputForm.Svc), inputForm.SvcCode, false);
                projectSvc.ProjectItems.AddFromFile(System.IO.Path.Combine(prjPath, inputForm.Svc));
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(HelperFunctions.GetAllMessageException(e));
            }
        }

       
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            InitializeWizard(automationObject, replacementsDictionary);

            inputForm.ShowDialog();

            if (inputForm.WizardButton == WizardButton.Ok)
            {
                replacementsDictionary["$servicename$"] = inputForm.ServiceName;
            }

        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion


        void inputForm_FinalizeWizEvent(frmWizBase frm, WizardButton pWizardButton)
        {
            frm.Close();
        }

        private void InitializeWizard(object automationObject, Dictionary<string, string> replacementsDictionary)
        {
            inputForm = new frmWizService();
            inputForm.FinalizeWizEvent += new FinalizeWizHandler(inputForm_FinalizeWizEvent);
            inputForm.ServiceName = replacementsDictionary["$rootname$"];
            solution = (((EnvDTE.SolutionClass)(((EnvDTE.DTE)automationObject).Solution)));


            selectedProject = HelperFunctions.GetDTE_SelectedProject(solution);

            projectIsvc = HelperFunctions.GetDTEProject(solution, "ISVC");
            if (projectIsvc == null)
                projectIsvc = selectedProject;
           projectSvc = HelperFunctions.GetDTEProject(solution, "SVC");
            if (projectSvc == null)
                projectSvc = selectedProject;

            //replacementsDictionary["$DefaultNamespace$"] = HelperFunctions.GetDTEProperty(solution, "Name").Value.ToString(); // HelperFunctions.GetDTEProperty(solution, "Name").Value.ToString();
            inputForm.ProjectName = HelperFunctions.GetDTEProperty(solution, "Name").Value.ToString();
            inputForm.ProjectSvcName = HelperFunctions.GetDTEProperty(projectSvc, "DefaultNamespace").Value.ToString();
            inputForm.ProjectISvcName = HelperFunctions.GetDTEProperty(projectIsvc, "DefaultNamespace").Value.ToString();
             



        }

      
    }

}

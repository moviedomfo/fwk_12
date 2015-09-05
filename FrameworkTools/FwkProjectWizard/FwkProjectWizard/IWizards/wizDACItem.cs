using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{
    public class wizDACItem : IWizard
    {
        #region IWizard Members
        frmWizDAC_1 inputForm;
        EnvDTE.Solution solution;
        EnvDTE.Project selectedProject;
        Storage _Storage;
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
            if (inputForm.WizardButton == WizardButton.Ok)
            {
                string prjPath = System.IO.Path.GetDirectoryName(selectedProject.FullName);
                foreach (KeyValuePair<string, string> code in inputForm.GenCode)
                {
                    HelperFunctions.SaveTextFile(System.IO.Path.Combine(prjPath, code.Key), code.Value,false);
                    selectedProject.ProjectItems.AddFromFile(System.IO.Path.Combine(prjPath, code.Key));
                }
                //replacementsDictionary["$fwkgencode$"] = inputForm.GenCode[""];
            }
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            InitializeWizard(automationObject, replacementsDictionary);

            inputForm.ShowDialog();
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion


        private void InitializeWizard(object automationObject, Dictionary<string, string> replacementsDictionary)
        {
            _Storage = new Storage();
            _Storage.LoadStorage();


            inputForm = new frmWizDAC_1(_Storage.CnnString);


            inputForm.FinalizeWizEvent += new FinalizeWizHandler(inputForm_FinalizeWizEvent);
            solution = (((EnvDTE.SolutionClass)(((EnvDTE.DTE)automationObject).Solution)));


            selectedProject = HelperFunctions.GetDTE_SelectedProject(solution);

            replacementsDictionary[CommonConstants.CONST_FwkProject_NAME] = HelperFunctions.GetDTEProperty(solution ,"Name").Value.ToString();
            inputForm.ProjectName = replacementsDictionary[CommonConstants.CONST_FwkProject_NAME];
        }

        void inputForm_FinalizeWizEvent(frmWizBase frm, WizardButton pWizardButton)
        {
            _Storage.CnnString = inputForm.Cnn;
            _Storage.SaveStorage();
            frm.Close();
        }


    }
}

//Utilizar los asistentes con las plantillas de proyectos
//http://msdn2.microsoft.com/es-es/library/ms185301(VS.80).aspx#Mtps_DropDownFilterText
//

//---------------------------
// Keys
//StringBuilder sp = new StringBuilder();
//                foreach(string s in replacementsDictionary.Keys)
//                {
//                    sp.Append(s);
//                }
//---------------------------
//$guid1$
//$guid2$
//$guid3$
//$guid4$
//$guid5$
//$guid6$
//$guid7$
//$guid8$
//$guid9$
//$guid10$
//$time$
//$year$
//$username$
//$userdomain$
//$machinename$
//$clrversion$
//$registeredorganization$
//$runsilent$
//$BCSuffix$
//$DACSuffix$
//$BESuffix$
//$projectname$
//$safeprojectname$
//$installpath$
//$exclusiveproject$
//$destinationdirectory$ = path  donde se crea el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{
    public class wizEntityItem : IWizard
    {
        frmWizEntity_1 inputForm;
        EnvDTE.Solution solution;
        EnvDTE.Project selectedProject;
        Storage _Storage;
        #region IWizard Members

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
           
            }
         
        }

        public void RunStarted(object automationObject, 
            Dictionary<string, string> replacementsDictionary, 
            WizardRunKind runKind, object[] customParams)
        {

            
            InitializeWizard(automationObject,replacementsDictionary);
          
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

            
            inputForm = new frmWizEntity_1(_Storage.CnnString);


            inputForm.FinalizeWizEvent += new FinalizeWizHandler(inputForm_FinalizeWizEvent);
            solution = (((EnvDTE.SolutionClass)(((EnvDTE.DTE)automationObject).Solution)));


            selectedProject = HelperFunctions.GetDTE_SelectedProject(solution);

            replacementsDictionary[CommonConstants.CONST_FwkProject_NAME] = HelperFunctions.GetDTEProperty(solution, "Name").Value.ToString();
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

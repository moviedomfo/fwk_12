using System;

using System.Collections.Generic;

using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;

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



namespace Fwk.Wizard.SilpleArq
{
    public class SipleArchitectWizard:IWizard  
    {
        private frmBackeçEndProjects inputForm;

        private string _BusinessComponents = ".BC";
        private string _BusinessEntities = ".BE";
        private string _DataAccessComponents = ".DAC";
        private string _InterfaceServices = ".ISVC";
        private string _BusinessServices = ".SVC";
        

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
            
        }

        public void RunStarted(object automationObject, 
            Dictionary<string, string> replacementsDictionary, 
            WizardRunKind runKind, object[] customParams)
        {

            try
            {


                InitializeWizard( replacementsDictionary);




                if (inputForm.ShowDialog() == DialogResult.Cancel)
                { return; }
                
                
                // Add custom parameters.
                //replacementsDictionary.Add("$Company$", inputForm.Company);
                //replacementsDictionary.Add("$App$", inputForm.App);
                replacementsDictionary.Add("$projectname$", inputForm.ProjectName);

                //Reemplazo valores de parametros
                //if (replacementsDictionary.ContainsKey("$BackendNamespace$"))
                //    replacementsDictionary["$BackendNamespace$"] = inputForm.BackendNamespaceTemplate;

                ////Ej ElMercurio.SCA.Common.Entorno.Cobertura.InterfaceServices
                //if (replacementsDictionary.ContainsKey("$CommonNamespace$"))
                //    replacementsDictionary["$CommonNamespace$"] = inputForm.CommonNamespaceTemplate;


               MessageBox.Show(replacementsDictionary["$projectname$"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void InitializeWizard(Dictionary<string, string> pReplacementsDictionary)
        {
            inputForm = new frmBackeçEndProjects();
            //inputForm.LongModuleName = GetLongModuleName(pReplacementsDictionary);
           

            //if (pReplacementsDictionary["$ComponentType$"].Trim().ToUpper() == "ISVC")
            //{
            //    inputForm.CommonNamespaceTemplate = pReplacementsDictionary["$CommonNamespace$"].ToString();
            //    inputForm.Text = "Interfase Services Project Template";
            //}

            //if (pReplacementsDictionary["$ComponentType$"].Trim().ToUpper() == "SVC")
            //{
            //    inputForm.CommonNamespaceTemplate = pReplacementsDictionary["$CommonNamespace$"].ToString();
            //    inputForm.BackendNamespaceTemplate = pReplacementsDictionary["$BackendNamespace$"].ToString();
            //    inputForm.Text = "Business Services Project Template";
            //}

            //if (pReplacementsDictionary["$ComponentType$"].Trim().ToUpper() == "BC" ||
            //    pReplacementsDictionary["$ComponentType$"].Trim().ToUpper() == "BE" ||
            //    pReplacementsDictionary["$ComponentType$"].Trim().ToUpper() == "DAC")
            //{
            //    inputForm.BackendNamespaceTemplate = pReplacementsDictionary["$BackendNamespace$"].ToString();
            //}

            //switch(pReplacementsDictionary["$ComponentType$"].Trim().ToUpper())
            //{
            //    case  "ISVC":
            //        {
            //            inputForm.CommonNamespaceTemplate = pReplacementsDictionary["$CommonNamespace$"].ToString();
            //            inputForm.Text = "Interfase Services Project";
            //            break;
            //        }
            //    case "SVC":
            //        {
            //            inputForm.CommonNamespaceTemplate = pReplacementsDictionary["$CommonNamespace$"].ToString();
            //            inputForm.BackendNamespaceTemplate = pReplacementsDictionary["$BackendNamespace$"].ToString();
            //            inputForm.Text = "Business Services Project";

            //            break;
            //        }
            //    case "BC":
            //        {
            //            inputForm.Text = "Business Component Project ";
            //            inputForm.BackendNamespaceTemplate = pReplacementsDictionary["$BackendNamespace$"].ToString();
            //            break;
            //        }
            //    case "BE":
            //        {
            //            inputForm.Text = "Business Entities Project";
            //            inputForm.BackendNamespaceTemplate = pReplacementsDictionary["$BackendNamespace$"].ToString();
            //            break;
            //        }

            //    case "DAC":
            //        {
            //            inputForm.Text = "Data Access Components Project";
            //            inputForm.BackendNamespaceTemplate = pReplacementsDictionary["$BackendNamespace$"].ToString();
            //            break;
            //        }
            //}

            inputForm.ProjectName = pReplacementsDictionary["$projectname$"].ToString();
        }

        private string GetLongModuleName(Dictionary<string, string> replacementsDictionary)
        {
            
            switch (replacementsDictionary["$ComponentType$"].Trim().ToUpper())
            {
                case "BC":
                    {
                        return _BusinessComponents;
                      
                    }
                case "BE":
                    {
                        return _BusinessEntities;
                      
                    }
                case "DAC":
                    {
                        return _DataAccessComponents;
                        
                    }
                case "ISVC":
                    {
                        return _InterfaceServices;
                      
                    }
                case "SVC":
                    {
                        return _BusinessServices;
                      
                    }
            }
            return String.Empty;
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;

        }

        #endregion
    }
}

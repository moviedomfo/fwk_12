using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using System.IO;
using Fwk.CodeGenerator;
using EnvDTE;

namespace Fwk.Wizard
{
    public class wizProjects : IWizard
    {
        frmBackeçEndProjects inputForm;
        static string fwkprojectname = string.Empty;
        static string destinationdirectory = string.Empty;
        static bool  useStatics = true;
        DTE dte;
        #region IWizard Members

        void IWizard.BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
            
        }

        void IWizard.ProjectFinishedGenerating(EnvDTE.Project project)
        {

            //Ubicar la carpeta creada que contiene los proyectos y arreglarla debido a que Visual studio ordena de una forma no deceada
            //System.IO.DirectoryInfo solutionDir = new System.IO.DirectoryInfo(destinationdirectory);
            

            ////Creo el destino con el npmbre del proyecto
            //// Ej: Motorola.pelsoft.Clientes
            //System.IO.DirectoryInfo destinationDir = System.IO.Directory.CreateDirectory(System.IO.Path.Combine(solutionDir.Parent.FullName, fwkprojectname));


            //MoveRec(solutionDir, destinationDir);
            ////destinationdirectory = destinationDir.FullName;

            //EnvDTE.DTE dte = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE"); 
            //string dir = System.IO.Path.GetDirectoryName(dte.Solution.FullName);
      
        }


        void MoveRec(DirectoryInfo sourceparentDir,DirectoryInfo detDir )
        {
            DirectoryInfo d;


            foreach (FileInfo f in sourceparentDir.GetFiles("*.*", SearchOption.TopDirectoryOnly))
            {
               File.Move(f.FullName, Path.Combine(detDir.FullName, f.Name));
            }

            foreach (DirectoryInfo sourceDir in sourceparentDir.GetDirectories("*.*", SearchOption.TopDirectoryOnly))
            {
                if (!Directory.Exists(Path.Combine(detDir.FullName, sourceDir.Name)))
                {
                    d = Directory.CreateDirectory(Path.Combine(detDir.FullName, sourceDir.Name));
                }
                else
                {
                    d = new DirectoryInfo(Path.Combine(detDir.FullName, sourceDir.Name));
                }

                MoveRec(sourceDir, d);
            }
            
        }

        void IWizard.ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
            
        }

        void IWizard.RunFinished()
        {

            if (useStatics)
            {
                string libs = string.Concat(destinationdirectory, @"..\..\..\", @"StaticLibs");
                string statics = string.Concat(destinationdirectory, @"..\..\..\", @"builds");

                if (!System.IO.Directory.Exists(statics))
                    System.IO.Directory.CreateDirectory(statics);
                if (!System.IO.Directory.Exists(libs))
                    System.IO.Directory.CreateDirectory(libs);
            }

          

        }
        bool _Cancel = true;
        void IWizard.RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {

            try
            {


                InitializeWizard(replacementsDictionary);

                if (runKind == WizardRunKind.AsMultiProject)
                {
                    if (inputForm.ShowDialog() == DialogResult.Cancel)
                    { return; }
                    _Cancel = false;
                    fwkprojectname = inputForm.ProjectName;
                    useStatics = inputForm.UseStatics;

                    
                    destinationdirectory = replacementsDictionary["$destinationdirectory$"];
                }



                //Reemplazo valores de parametros

                if (!replacementsDictionary.ContainsKey(CommonConstants.CONST_FwkProject_NAME))
                    replacementsDictionary.Add(CommonConstants.CONST_FwkProject_NAME, fwkprojectname);
                else

                    replacementsDictionary[CommonConstants.CONST_FwkProject_NAME] = fwkprojectname;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool IWizard.ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion

        private void InitializeWizard(Dictionary<string, string> pReplacementsDictionary)
        {
            inputForm = new frmBackeçEndProjects();

            inputForm.ProjectName = pReplacementsDictionary["$projectname$"].ToString();
         
        }
    }
}

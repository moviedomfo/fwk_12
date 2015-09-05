using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Microsoft.VisualStudio.TemplateWizard;

namespace Fwk.Wizard
{
    public class wizStoreProcedures : IWizard
    {
        frmWizService inputForm;
        EnvDTE.Solution solution;
        EnvDTE.Project selectedProject;

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

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion
    }
}

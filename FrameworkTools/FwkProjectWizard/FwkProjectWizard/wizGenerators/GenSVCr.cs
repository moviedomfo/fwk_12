using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{
    public static class GenSVC
    {
         static string _ISVC_tt;

         static string _SVC_tt;

        static GenSVC()
        {
            _ISVC_tt = FwkGeneratorHelper.GetFileTemplate("Isvc.txt");
            _SVC_tt = FwkGeneratorHelper.GetFileTemplate("Svc.txt");

        }

        internal static string Generate_SVC(string pServiceName, string prjName)
        {
            StringBuilder wClassContainer = new StringBuilder(_SVC_tt);
            wClassContainer.Replace(CommonConstants.CONST_SERVICE_NAME, pServiceName);
            wClassContainer.Replace(CommonConstants.CONST_FwkProject_NAME, prjName);
            return wClassContainer.ToString();
        }

        internal static string Generate_ISVC(string pServiceName,string prjName)
        {

            StringBuilder wClassContainer = new StringBuilder(_ISVC_tt);
            wClassContainer.Replace(CommonConstants.CONST_SERVICE_NAME, pServiceName);
            wClassContainer.Replace(CommonConstants.CONST_FwkProject_NAME, prjName);
            return wClassContainer.ToString();
        }
    }
}

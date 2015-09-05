using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.CodeGenerator
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

        public static string Generate_SVC(string pServiceName, string prjName)
        {
            StringBuilder wClassContainer = new StringBuilder(_SVC_tt);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_SERVICE_NAME, pServiceName);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_FwkProject_NAME, prjName);
            return wClassContainer.ToString();
        }

        public static string Generate_ISVC(string pServiceName,string prjName)
        {

            StringBuilder wClassContainer = new StringBuilder(_ISVC_tt);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_SERVICE_NAME, pServiceName);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_FwkProject_NAME, prjName);
            return wClassContainer.ToString();
        }
    }
}

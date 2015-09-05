//using System;
//using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Text;
//
//using Microsoft.SqlServer.Management.Smo;


//namespace Fwk.CodeGenerator
//{
//    public class ServiceControlle : ControllerBase
//    {
//        private String _ServiceName = String.Empty;
//        private List<GlobalElementComplexType> _GlobalElementComplexTypeRES;
//        private List<GlobalElementComplexType> _GlobalElementComplexTypeREQ;
        

//        public String ServiceName
//        {
//            set { _ServiceName = value; }
//        }
//        public List<GlobalElementComplexType> GlobalElementComplexTypeRES
//        {
            
//            set { _GlobalElementComplexTypeRES = value; }
//        }
//        public List<GlobalElementComplexType> GlobalElementComplexTypeREQ
//        {

//            set { _GlobalElementComplexTypeREQ = value; }
//        }




//        /// <summary>
//        /// Lee el esquema XSD y genera de una entidad tipo BE.-
//        /// </summary>
//        /// <param name="pEntityGenerationInfo"></param>
//        /// <returns>String con el codigo generado a partir del esquema</returns>
//        //public  TreeNode GenerateCode()
//        //{
//        //    try
//        //    {
//        //        EntityGenerationInfo wEntityGenerationInfo = new EntityGenerationInfo();
//        //        wEntityGenerationInfo.TemplateSettingObject = base.TemplateSettingObject;

//        //        wEntityGenerationInfo.Tables =  GenerateEntityInfo();

//        //        //ServiceGenerator.EntityGenerationInfo = wEntityGenerationInfo;
//        //        return ServiceGenerator.GenerateCode(_ServiceName);


//        //    }
//        //    catch (Exception ex)
//        //    { throw ex; }

//        //}


//        /// <summary>
//        /// Controller para un XSD.-
//        /// </summary>
//        /// <param name="pGlobalElementComplexType"></param>
//        /// <returns></returns>
//        private List<Table> GenerateEntityInfo()
//        {
//            List<Table> wEntityInfoList = new List<Table>();
//            Table wEntityInfo = new Table();
            
//            ////Responce
//            //wEntityInfo.GlobalElementComplexTypeList = _GlobalElementComplexTypeRES;
//            //wEntityInfo.Name = _ServiceName;

//            //wEntityInfoList.Add(wEntityInfo);


//            ////Request
//            //wEntityInfo = new EntityInfo();
//            //wEntityInfo.GlobalElementComplexTypeList = _GlobalElementComplexTypeREQ;
//            //wEntityInfo.Name = _ServiceName;
//            //wEntityInfoList.Add(wEntityInfo);


//            return wEntityInfoList;
//        }

//    }
//}

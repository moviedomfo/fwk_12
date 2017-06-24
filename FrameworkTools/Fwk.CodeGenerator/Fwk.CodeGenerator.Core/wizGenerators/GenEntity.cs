using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.CodeGenerator
{
    public static class GenEntity
    {
        
        static GenEntity()
        {           

        }

        internal static Dictionary<string, string> GenerateEntities(List<Microsoft.SqlServer.Management.Smo.View> pViews, string project)
        {
            Dictionary<string, string> gen = new Dictionary<string, string>();

            foreach (Microsoft.SqlServer.Management.Smo.View t in pViews)
            {
                gen.Add(string.Concat(t.Name, ".cs"), Generate(t, project));
            }
            return gen;
        }

        internal static Dictionary<string, string> GenerateEntities(List<Table> pTables, string project)
        {
            Dictionary<string, string> gen = new Dictionary<string,string> ();

            foreach(Table t in pTables)
            {
                gen.Add(string.Concat(t.Name, ".cs"), Generate(t, project));
            }
            return gen;
        }


        internal static string Generate(Microsoft.SqlServer.Management.Smo.View pView, string project)
        {
            StringBuilder wClassContainer = new StringBuilder();
            string wPrivateMembers_BODY = String.Empty;
            string wPublicProperty_BODY = String.Empty;

            wClassContainer.Append(FwkGeneratorHelper._Entity_Envelope_tt);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_NAME, pView.Name);

            GenerateDataBaseProperttyBody(pView, out  wPublicProperty_BODY, out wPrivateMembers_BODY);
            //Inserta miembros privados
            //wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, wPrivateMembers_BODY);
            //Inserta los atributos publicos
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY, wPublicProperty_BODY);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_FwkProject_NAME, project);
            return wClassContainer.ToString();
        }

        internal static string Generate(Table pTable, string project)
        {
            StringBuilder wClassContainer = new StringBuilder();
            string wPrivateMembers_BODY = String.Empty;
            string wPublicProperty_BODY = String.Empty;

            wClassContainer.Append(FwkGeneratorHelper._Entity_Envelope_tt);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            GenerateDataBaseProperttyBody(pTable, out  wPublicProperty_BODY, out wPrivateMembers_BODY);
            //Inserta miembros privados
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, wPrivateMembers_BODY);
            //Inserta los atributos publicos
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY, wPublicProperty_BODY);
            wClassContainer.Replace(CodeGeneratorCommon.CommonConstants.CONST_FwkProject_NAME, project);
            return wClassContainer.ToString();
        }
   

         

       
               /// <summary>
        /// Retorna codigo de miembros privados + los atributos publicos.-
        /// </summary>
        /// <param name="pView">  Microsoft.SqlServer.Management.Smo.View</param>
        /// <param name="pPublicProperty_Body">atributos publicos</param>
        /// <param name="pPrivateMembers_Body">miembros privados</param>
        static void GenerateDataBaseProperttyBody(Microsoft.SqlServer.Management.Smo.View pView, out String pPublicProperty_Body, out String pPrivateMembers_Body)
        {

            StringBuilder wPrivateMembers_BODY = new StringBuilder();
            StringBuilder wPublicProperty_BODY = new StringBuilder();

            foreach (Column wColumn in pView.Columns)
            {
                //Si es una columna no permitida
                if (!FwkGeneratorHelper.NotSupportTypes_ToIncludeInBackEnd.Contains(wColumn.DataType.Name.ToLower()))
                {
                    //if (wColumn.Selected)
                    //{
                    //Privados
                    wPrivateMembers_BODY.Append(FwkGeneratorHelper.GetCsharpMember(wColumn));
                    //Publicos (con Get y Set)
                    wPublicProperty_BODY.Append(FwkGeneratorHelper.GetCsharpProperty(wColumn));
                    //}
                }
            }
            pPrivateMembers_Body = wPrivateMembers_BODY.ToString();
            pPublicProperty_Body = wPublicProperty_BODY.ToString();


        }
  
        /// <summary>
        /// Retorna codigo de miembros privados + los atributos publicos.-
        /// </summary>
        /// <param name="pTable">tabla</param>
        /// <param name="pPublicProperty_Body">atributos publicos</param>
        /// <param name="pPrivateMembers_Body">miembros privados</param>
        static void GenerateDataBaseProperttyBody(Table pTable, out String pPublicProperty_Body, out String pPrivateMembers_Body)
        {

            StringBuilder wPrivateMembers_BODY = new StringBuilder();
            StringBuilder wPublicProperty_BODY = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                //Si es una columna no permitida
                if (!FwkGeneratorHelper.NotSupportTypes_ToIncludeInBackEnd.Contains(wColumn.DataType.Name.ToLower()))
                {
                    //if (wColumn.Selected)
                    //{
                    //Privados
                    wPrivateMembers_BODY.Append(FwkGeneratorHelper.GetCsharpMember(wColumn));
                    //Publicos (con Get y Set)
                    wPublicProperty_BODY.Append(FwkGeneratorHelper.GetCsharpProperty(wColumn));
                    //}
                }
            }
            pPrivateMembers_Body = wPrivateMembers_BODY.ToString();
            pPublicProperty_Body = wPublicProperty_BODY.ToString();


        }
  
    }
}

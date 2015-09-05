using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using fwkDataEntities = Fwk.DataBase.DataEntities;

using Microsoft.SqlServer.Management.Smo;

namespace Fwk.CodeGenerator
{
    public class BakcEndGenController 
    {
        #region Private Members

        private CodeGeneratorCommon.SelectedObject _SelectedObject = CodeGeneratorCommon.SelectedObject.Tables; 
        private List<Table> _Tables = null;
        private List<Microsoft.SqlServer.Management.Smo.View> _Views = null;
       
        private List<StoredProcedure> _StoreProcedures = null;
        private ListViewCodeGenerated _listViewCodeGenerated = null;



        #endregion

        #region Public Properties
        public ListViewCodeGenerated ListViewCodeGenerated
        {
            get { return _listViewCodeGenerated; }
            set { _listViewCodeGenerated = value; }
        }
        public CodeGeneratorCommon.SelectedObject SelectedObject
        {
            get { return _SelectedObject; }
            set { _SelectedObject = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Table> Tables
        {
            get { return _Tables; }
            set { _Tables = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public List<Microsoft.SqlServer.Management.Smo.View> Views
        {
            get { return _Views; }
            set { _Views = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<StoredProcedure> StoreProcedures
        {
            get { return _StoreProcedures; }
            set { _StoreProcedures = value; }

        }
       



        #endregion

        /// <summary>
        /// Agrega codigo a :
        /// listViewCodeGenerated.GeneratedStoredProcedureCodeList
        /// listViewCodeGenerated.GeneratedDACCodeList
        /// listViewCodeGenerated.GeneratedBECodeList
        /// </summary>
        public void Generate()
        {


            switch (_SelectedObject)
            {
                case  CodeGeneratorCommon.SelectedObject.Tables:
                    {

                        _listViewCodeGenerated.NodeSP = SPGenerator.GenCode(_Tables);
                        _listViewCodeGenerated.NodeDAC = DACGenerator.GenCode(_Tables);
                        _listViewCodeGenerated.NodeBE = BEGenerator.GenCode(_Tables);
                        break;
                    }
                case CodeGeneratorCommon.SelectedObject.Views:
                    {

                        _listViewCodeGenerated.NodeSP = SPGenerator.GenCode(_Views);
                        _listViewCodeGenerated.NodeDAC = DACGenerator.GenCode(_Views);
                        _listViewCodeGenerated.NodeBE = BEGenerator.GenCode(_Views);
                        break;
                    }

            }

            
            
            _listViewCodeGenerated.LoadTtreeView();
        }


        /// <summary>
        /// Agrega codigo solo a :
        /// listViewCodeGenerated.GeneratedBECodeList
        /// </summary>
        public void GenerateBEOnly()
        {
         
           
            _listViewCodeGenerated.NodeBE = BEGenerator.GenCode(_Tables);
            _listViewCodeGenerated.LoadTtreeView();
            _listViewCodeGenerated.ExpandBE();
        }

        //public String GenerateBEFromSchema()
        //{
        //    SetEntityGenerationInfo();

        //    //SchemEntityGenEngine.EntityGenerationInfo = _EntityGenerationInfo;
        //    //return SchemEntityGenEngine.GenCode(true);
        //}


        /// <summary>
        ///// Genera los script de los SPs.-
        ///// </summary>
        ///// <param name="pEntityGenerationInfo"></param>
        ///// <returns></returns>
        //private TreeNode SPFromTableCodeGenerator_GenerateCode()
        //{
        //    SPCodeGenerator wSPFromTableCodeGenerator = null;
        //    try
        //    {
        //        wSPFromTableCodeGenerator = new SPCodeGenerator();
        //        return wSPFromTableCodeGenerator.GenCode(_EntityGenerationInfo);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }

       

 
       

      


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Fwk.DataBase.DataEntities;


namespace Fwk.CodeGenerator

    {

        /// <summary>
        /// Clase para generar código fuente de table data gateways.
        /// </summary>
        /// <remarks>
        /// Hace uso de templates para efectuar reemplazos en tags. Crea una clase y sus métodos.
        /// </remarks>
        /// <author>Marcelo Oviedo</author>
        public class DACGenerator
        {



            /// <summary>
            /// Inicia la generación de código fuente de un componente de acceso a datos
            /// </summary>
            /// <param name="pEntityGenerationInfo">información de generación de entidad para creación del componente de acceso a datos.</param>
            /// <returns>Código fuente.</returns>
            /// <date>2006-03-29T00:00:00</date>
            /// <author>Marcelo Oviedo</author>
            public static TreeNode GenCode(List<Microsoft.SqlServer.Management.Smo.View> pViews)
            {
                List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();
                GeneratedCode wGeneratedCode;
                foreach (Microsoft.SqlServer.Management.Smo.View t in pViews)
                {
                    //GenClass(wEntityInfo,wGeneratedCodeResult);
                    wGeneratedCode = new GeneratedCode();
                    wGeneratedCode.Id = t.Name;
                    ///TODO: Ver parametros Gen_DAC
                    wGeneratedCode.Code.Append(GenDAC.Gen_DAC(t,
                        FwkGeneratorHelper.TemplateSetting.Methods.GenerateBatch,
                        FwkGeneratorHelper.TemplateSetting.Project.ProjectName));
                    wGeneratedCodeResult.Add(wGeneratedCode);
                }


                return BuildTreeNode(wGeneratedCodeResult);
            }


            /// <summary>
            /// Inicia la generación de código fuente de un componente de acceso a datos
            /// </summary>
            /// <param name="pEntityGenerationInfo">información de generación de entidad para creación del componente de acceso a datos.</param>
            /// <returns>Código fuente.</returns>
            /// <date>2006-03-29T00:00:00</date>
            /// <author>Marcelo Oviedo</author>
            public static TreeNode GenCode(List<Microsoft.SqlServer.Management.Smo.Table> pTables)
            {
                List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();
                GeneratedCode wGeneratedCode;
                foreach (Microsoft.SqlServer.Management.Smo.Table t in pTables)
                {
                    //GenClass(wEntityInfo,wGeneratedCodeResult);
                    wGeneratedCode = new GeneratedCode();
                    wGeneratedCode.Id = t.Name;
                    ///TODO: Ver parametros Gen_DAC
                    wGeneratedCode.Code.Append(GenDAC.Gen_DAC(t,
                        FwkGeneratorHelper.TemplateSetting.Methods.GenerateBatch,
                        FwkGeneratorHelper.TemplateSetting.Project.ProjectName));
                    wGeneratedCodeResult.Add(wGeneratedCode);
                }


                return BuildTreeNode(wGeneratedCodeResult);
            }

        

           


            private static TreeNode BuildTreeNode(List<GeneratedCode> pGeneratedCodeResult)
            {
                TreeNode wTreeNodeDAC = new TreeNode("DAC");
                foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
                {
                    TreeNode wTreeNode = new TreeNode(wGeneratedCode.Id);
                    wTreeNode.Text = wGeneratedCode.Id;
                    wTreeNode.Tag = wGeneratedCode;

                    wTreeNodeDAC.Nodes.Add(wTreeNode);

                }
                return wTreeNodeDAC;
            }


           


            

      





        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.CodeGenerator;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.CodeGenerator
{
    public class SPGenerator
    {
        
        /// <summary>
        /// Genera el código fuente de un conjunto de procedimientos almacenados.
        /// </summary>
        /// <seealso cref="GenStoredProcedures"/>
        /// <param name="pEntityGenerationInfo">información de generación de entidad para creación de procedimientos almacenados.</param>
        /// <returns>Código fuente.</returns>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static TreeNode GenCode(List<Table> pTables)
        {

            List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();

            foreach (Table t in pTables)
            {
                GenSP.GenCode(t, wGeneratedCodeResult);
            }
            return BuildTreeNode(wGeneratedCodeResult);

        }
        /// <summary>
        /// Genera el código fuente de un conjunto de procedimientos almacenados.
        /// </summary>
        /// <seealso cref="GenStoredProcedures"/>
        /// <param name="pEntityGenerationInfo">información de generación de entidad para creación de procedimientos almacenados.</param>
        /// <returns>Código fuente.</returns>
        /// <date>2007-5-25T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static TreeNode GenCode(List<Microsoft.SqlServer.Management.Smo.View> pViews)
        {

            List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();

            foreach (Microsoft.SqlServer.Management.Smo.View t in pViews)
            {
                GenSP.GenCode(t, wGeneratedCodeResult);
            }
            return BuildTreeNode(wGeneratedCodeResult);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGeneratedCodeResult"></param>
        /// <returns></returns>
         static TreeNode BuildTreeNode(List<GeneratedCode> pGeneratedCodeResult)
        {
            int wiIndex = 0;
            string wzsAux = String.Empty;
            TreeNode wNodeSP = new TreeNode("SP");
            TreeNode wTreeNodeEntitySp = null;
            TreeNode wTreeNodeSpActions = null;



            //Carga los nodos  con los nombres de las entidades
            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
            {
                if (wzsAux != wGeneratedCode.Id)
                {
                    wzsAux = wGeneratedCode.Id;

                    wTreeNodeEntitySp = new TreeNode(wGeneratedCode.Id);
                    wTreeNodeEntitySp.Text = wGeneratedCode.Id;
                    wTreeNodeEntitySp.Name = wGeneratedCode.Id;
                    wTreeNodeEntitySp.Tag = "EntitySP";


                    wNodeSP.Nodes.Add(wTreeNodeEntitySp);
                }

            }
            //Carga los nodos  con los nombres de los metodos por cada entidad
            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
            {
                if (wzsAux != wGeneratedCode.Id)
                {
                    wzsAux = wGeneratedCode.Id;
                    wiIndex = wNodeSP.Nodes.IndexOfKey(wGeneratedCode.Id);
                    wTreeNodeEntitySp = wNodeSP.Nodes[wiIndex];
                }
                wTreeNodeSpActions = new TreeNode();
                wTreeNodeSpActions.Name = wGeneratedCode.MethodActionType.ToString();
                wTreeNodeSpActions.Text = wGeneratedCode.MethodActionType.ToString();
                wTreeNodeSpActions.Tag = wGeneratedCode;


                wTreeNodeEntitySp.Nodes.Add(wTreeNodeSpActions);
            }

            return wNodeSP;
        }
    }
}

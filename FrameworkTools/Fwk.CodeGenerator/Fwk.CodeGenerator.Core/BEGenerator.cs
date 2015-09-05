using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;


namespace Fwk.CodeGenerator
{
    public class BEGenerator
    {

        public static TreeNode GenCode(List<Microsoft.SqlServer.Management.Smo.View> pViews)
        {

            List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();
            GeneratedCode wGeneratedCode;
            foreach (Microsoft.SqlServer.Management.Smo.View t in pViews)
            {

                wGeneratedCode = new GeneratedCode();
                wGeneratedCode.Id = t.Name;
                wGeneratedCode.Code.Append(GenEntity.Generate(t, FwkGeneratorHelper.TemplateSetting.Project.ProjectName));
                wGeneratedCodeResult.Add(wGeneratedCode);
            }


            return BuildTreeNode(wGeneratedCodeResult);

        }


        public static TreeNode GenCode(List<Table> pTables )
        {
             
            List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();
            GeneratedCode wGeneratedCode;
            foreach (Table t in pTables)
            {
      
                wGeneratedCode = new GeneratedCode();
                wGeneratedCode.Id = t.Name;
                wGeneratedCode.Code.Append(GenEntity.Generate(t, FwkGeneratorHelper.TemplateSetting.Project.ProjectName));
                wGeneratedCodeResult.Add(wGeneratedCode);
            }


            return BuildTreeNode(wGeneratedCodeResult);

        }


        private static TreeNode BuildTreeNode(List<GeneratedCode> pGeneratedCodeResult)
        {
            TreeNode wTreeNodeBE = new TreeNode("BE");
            TreeNode wTreeNode;
            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
            {
                wTreeNode = new TreeNode(wGeneratedCode.Id);
                wTreeNode.Text = wGeneratedCode.Id;
                wTreeNode.Tag = wGeneratedCode;

                wTreeNodeBE.Nodes.Add(wTreeNode);

            }
            return wTreeNodeBE;
        }       
    }
}

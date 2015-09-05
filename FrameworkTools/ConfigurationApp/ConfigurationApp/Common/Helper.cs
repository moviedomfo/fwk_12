using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ConfigurationApp.Common
{
    
    internal static class Helper
    {

        /// <summary>
        /// Determina si un nodo existe dentro de otro.-
        /// Retorna true si encuentra el nodo de lo contrario false.-
        /// </summary>
        /// <param name="pParentNode"></param>
        /// <param name="pChildName"></param>
        /// <returns>Boolean</returns>
        internal static Boolean TreeNodeExist(TreeNode pParentNode, String pChildName)
        {
            foreach (TreeNode o in pParentNode.Nodes)
            {
                if(o.Text == pChildName)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si un nodo existe dentro de otro;
        /// Retorna true si encuentra el nodo, de lo contrario false.-
        /// Retorna el indice del nodo encontrado. 
        /// Si no encuentra el subnodo retorna -1 como valor de pIndex.
        /// </summary>
        /// <param name="pParentNode"></param>
        /// <param name="pChildName"></param>
        /// <param name="pIndex">Parametro de salida que contendra el indice del nodo encontrado</param>
        /// <returns>Boolean</returns>
        internal static Boolean TreeNodeExist(TreeNode pParentNode, String pChildName,out Int32 pIndex)
        {
            pIndex = -1;
            foreach (TreeNode o in pParentNode.Nodes)
            {
                if (o.Text.Trim().ToLower() == pChildName.ToLower())
                {
                    pIndex = o.Index;
                    return true;
                    
                }
            }
            return false;
        }

        internal static string GetEnumDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

    }

   
    internal class CommonConstant
    {
        public const string DATABES_NODE_NAME = "Data base configuration";
    }
}

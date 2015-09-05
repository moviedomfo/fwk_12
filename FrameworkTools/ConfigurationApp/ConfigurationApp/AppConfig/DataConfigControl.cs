//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Text;
//using System.Windows.Forms;
//using System.Xml;
//using ConfigurationApp.Common;

//namespace ConfigurationApp
//{
//    internal class DataConfigControl
//    {
//        /// <summary>
//        /// Agrega una seccion para conexiónes a baes de datos atravez de 
//        /// Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings
//        /// </summary>
//        /// <param name="pTreeNodeFile"></param>
//        /// <param name="pDatabaseNodeMenu"></param>
//        internal static void AddConfigSection(TreeNode pTreeNodeFile, ContextMenuStrip pDatabaseNodeMenu)
//        {
            
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];

//            if (!SectionsAndGroupsConfig.SectionExist(pConfiguration, "dataConfiguration", string.Empty))
//            {
//                SectionsAndGroupsConfig.AddSection(pConfiguration, "dataConfiguration", string.Empty, string.Empty);
//            }
            

//            if (Helper.TreeNodeExist(pTreeNodeFile, CommonConstant.DATABES_NODE_NAME) == false)
//                TreeNodeConfig.GenerateDataBaseNode(pTreeNodeFile, pDatabaseNodeMenu);

//        }


//        /// <summary>
//        /// Crea una cnn string en la seccion connectionStrings
//        /// </summary>
//        /// <param name="pTreeNodeFile">Tree view</param>
//        /// <param name="menu">Menu contextual especifico para nodos de conexión</param>
//        internal static void AddCnnStringDefault(TreeNode pTreeNodeFile, ContextMenuStrip menu)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];

//            CnnString wCnnString = new CnnString();
//            wCnnString.Name = "ConnectionString";
//            wCnnString.DataSource = "(local)";
//            wCnnString.InitialCatalog = "DataBase";
//            wCnnString.WindowsAutentification = true;

//            AddConnectionStrings(pConfiguration, wCnnString);
//            int wIndex = 0;
//            Helper.TreeNodeExist(pTreeNodeFile, CommonConstant .DATABES_NODE_NAME, out wIndex);
//            TreeNodeConfig.GenerateCnnStringNode(pTreeNodeFile.Nodes[wIndex], wCnnString, menu);
//        }

      
//        /// <summary>
//        /// Crea una CnnString en la seccion connectionStrings
//        /// </summary>
//        /// <param name="pTreeNodeFile">Tree view que reprecenta al App.config</param>
//        /// <param name="pCnnString"></param>
//        /// <param name="menu">Menu contextual especifico para nodos de conexión</param>
//        internal static void CreateCnnString(TreeNode pTreeNodeFile, CnnString pCnnString, ContextMenuStrip menu)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];

//            AddConnectionStrings(pConfiguration, pCnnString);
//            int wIndex = 0;
//            Helper.TreeNodeExist(pTreeNodeFile, CommonConstant .DATABES_NODE_NAME, out wIndex);
            
//            TreeNodeConfig.GenerateCnnStringNode(pTreeNodeFile.Nodes[wIndex], pCnnString, menu);
//        }
//        /// <summary>
//        /// Agrega un nuevo nodo de connection string en el XmlDocument del archivo   
//        /// </summary>
//        /// <param name="pConfiguration">Configuration del AppConfig cargado</param>
//        /// <param name="pCnnString"></param>
//        internal static void AddConnectionStrings(Configuration pConfiguration, CnnString pCnnString)
//        {
//            ////<add name="CnnA" connectionString="DBTest=Database;Server=(local)\SQLEXPRESS;Integrated Security=SSPI;" providerName="System.Data.SqlClient"/>
//            ConnectionStringSettings wConnectionStringSettings = new ConnectionStringSettings(pCnnString.Name, pCnnString.ToString());
//            wConnectionStringSettings.ProviderName = "System.Data.SqlClient";

//            int index = pConfiguration.ConnectionStrings.ConnectionStrings.IndexOf(wConnectionStringSettings);
//            if (index == -1)
//                pConfiguration.ConnectionStrings.ConnectionStrings.Add(wConnectionStringSettings);
//            else 
//                throw new Exception("Connection strings " + pCnnString.Name + "already exist." + Environment.NewLine + "Rename existen connection in the tree ");
//        }

//        internal static void ChangeCnnString(TreeNode pTreeNodeFile, TreeNode pTreeNodeCnnString, String pOldName)
//        {
//            CnnString wCnnString = (CnnString)pTreeNodeCnnString.Tag;
//            ChangeCnnString(pTreeNodeFile, wCnnString, pOldName);
//        }

//        /// <summary>
//        /// Cambia el valor de una cadena de conexión:
//        /// </summary>
//        /// <param name="pTreeNodeFile">Nodo con el contenido del archivo App.config</param>
//        /// <param name="pCnnString">Clase <see cref="CnnString"/> del tag del node cadena de conexión </param>
//        /// <param name="pOldName">Nombre anterior de la cadena de conexión. 
//        /// Este valor es util solo en el caso de que el nobre alla cambiado por el usuario </param>
//        /// <Author>Marcelo Oviedo</Author> 
//        private static void ChangeCnnString(TreeNode pTreeNodeFile, Fwk.dat CnnString pCnnString, String pOldName)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;
//            // /configuration/connectionStrings/add/@name

//            //Fwk.Xml.NodeAttribute.AttributeSet(wXmlNodeConnectionString, "name", pCnnString.Name);
           
//            pConfiguration.ConnectionStrings.ConnectionStrings[pOldName].ConnectionString = pCnnString.ToString();
//            pConfiguration.ConnectionStrings.ConnectionStrings[pOldName].Name = pCnnString.Name;
            
//        }




//        /// <summary>
//        /// Carga los nodos connectionStrings que estan en el xml del archivo y  lo mapea al tree view
//        /// </summary>
//        /// <param name="tvNodeRoot"></param>
//        /// <param name="wtvNodeFile"></param>
//        /// <param name="pConfiguration">Configuration file</param>
//        /// <param name="menuDataBaseNode"></param>
//        /// <param name="menuCnnString"></param>
//        internal static void LoadConnections(TreeNode tvNodeRoot, TreeNode wtvNodeFile, Configuration pConfiguration, ContextMenuStrip menuDataBaseNode, ContextMenuStrip menuCnnString)
//        {
//            ConnectionStringSettingsCollection wConnectionStrings = pConfiguration.ConnectionStrings.ConnectionStrings;
//            if (wConnectionStrings.Count != 0)
//                AddConfigSection(wtvNodeFile, menuDataBaseNode);
            
//            int index;
//            Helper.TreeNodeExist(wtvNodeFile, CommonConstant .DATABES_NODE_NAME, out index);
//            if (index == -1) return;
//            TreeNode wDataBaseNode = wtvNodeFile.Nodes[index];
//            foreach (ConnectionStringSettings cnn in wConnectionStrings)
//            {
//                CnnString wCnnString = GetCnnStringFromConnectionString(cnn);
//                TreeNodeConfig.GenerateCnnStringNode(wDataBaseNode, wCnnString, menuCnnString);
//            }
//        }

//        /// <summary>
//        /// Descompone una cadena de conexión y genera una clase <see cref="CnnString"/>
//        /// </summary>
//        /// <param name="pConnectionStringSettings"></param>
//        /// <returns></returns>
//        private static CnnString GetCnnStringFromConnectionString(ConnectionStringSettings pConnectionStringSettings)
//        {
//            CnnString wCnnString  = new CnnString(pConnectionStringSettings.Name,pConnectionStringSettings.ConnectionString.ToString());
//            return wCnnString;
//        }



//        /// <summary>
//        /// Cambia el valor de una cadena de conexión:
//        /// </summary>
//        /// <param name="pCnnTreeNode">Nodo con el contenido del archivo App.config</param>
//        /// Este valor es util solo en el caso de que el nobre alla cambiado por el usuario </param>
//        /// <Author>Marcelo Oviedo</Author> 
//        internal static void RemoveCnnString(TreeNode pCnnTreeNode)
//        {
//            TreeNode wTreeNodeFile = pCnnTreeNode.Parent.Parent;

//            ListDictionary wDictionary = (ListDictionary)wTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;


//            CnnString wCnnString = (CnnString)pCnnTreeNode.Tag;

//            //Remueve del archivo
//            ConnectionStringSettingsCollection wConnectionStrings = pConfiguration.ConnectionStrings.ConnectionStrings;
//            wConnectionStrings.Remove(wCnnString.Name);

//            //Elimino el nodo conexion del tree view
//            pCnnTreeNode.Remove();
//        }

//        /// <summary>
//        /// Elimina el nodo data access que contiene las cadenas de conexión
//        /// </summary>
//        /// <param name="pDataAccessNode">Nodo data access</param>
//        /// <Author>Marcelo Oviedo</Author> 
//        internal static void ClearDataAccess(TreeNode pDataAccessNode)
//        {
//            TreeNode wTreeNodeFile = pDataAccessNode.Parent;

//            ListDictionary wDictionary = (ListDictionary)wTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            pConfiguration.ConnectionStrings.ConnectionStrings.Clear();
            
//            //Elimino el nodo conexion del tree view
//            pDataAccessNode.Nodes.Clear();
//        }

//    }
//}

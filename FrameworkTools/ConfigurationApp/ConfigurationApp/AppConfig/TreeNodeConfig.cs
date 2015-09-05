//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Xml;
//using System.Windows.Forms;
//using ConfigurationApp.Common;

//namespace ConfigurationApp
//{

//    internal class TreeNodeConfig
//    {

       
       
//        /// <summary>
//        /// Mapea todo el contenido de un archivo App.config (transformado a XmlDocument) a un treeNode 
//        /// </summary>
//        /// <param name="pConfiguration">XmlDocument del App.Config</param>
//        /// <param name="tvNodeRoot">Nodo 0 del tree view</param>
//        /// <param name="pFileName">Nombre del archivo</param>
//        /// <param name="pFullFileName">Nombre completo del archivo</param>
//        /// <param name="mnAppConfigAplications">Menu contextual</param>
//        /// <param name="pDataAccessMenuStrip"></param>
//        /// <param name="pConnectionMenuStrip"></param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        internal static void MapXmlToTreeview(Configuration pConfiguration, TreeNode tvNodeRoot, String pFileName, String pFullFileName,
//              ContextMenuStrip mnAppConfigAplications,
//            ContextMenuStrip pDataAccessMenuStrip,
//            ContextMenuStrip pConnectionMenuStrip,
//            ContextMenuStrip pContextMenuStripSection)
//        {
//            #region Node File

//            TreeNode wtvNodeFile = new TreeNode(pFileName);
//            tvNodeRoot.Nodes.Add(wtvNodeFile);

//            ListDictionary wDictionary = new ListDictionary();
//            wDictionary["FullFileName"] = pFullFileName;
//            wDictionary["Configuration"] = pConfiguration;
//            wDictionary["Saved"] = true;

//            wtvNodeFile.ToolTipText = pFullFileName;
//            wtvNodeFile.Tag = wDictionary;
//            wtvNodeFile.SelectedImageIndex = tvNodeRoot.TreeView.ImageList.Images.IndexOfKey("inifile.ico");
//            wtvNodeFile.ImageIndex = tvNodeRoot.TreeView.ImageList.Images.IndexOfKey("inifile.ico");
//            wtvNodeFile.ContextMenuStrip = mnAppConfigAplications;

//            #endregion

//            #region Node sectionGroup

//            TreeNode wtvNodeSectionGroup = GenerateSectionGroup(tvNodeRoot, wtvNodeFile, mnAppConfigAplications);
//            GenerateSectionInSectionGroup(tvNodeRoot, wtvNodeSectionGroup, pConfiguration, pContextMenuStripSection);

//            #endregion

//            #region Node applicationSettings

//            TreeNode wtvNodeApplicationSettings =
//                GenrateApplicationSettings(tvNodeRoot, wtvNodeFile, mnAppConfigAplications);

//            GenerateSectionInApplicationSettings(tvNodeRoot, wtvNodeApplicationSettings, pConfiguration);

//            #endregion

//            #region Data Access Configuration

//            if (pDataAccessMenuStrip != null)
//                DataConfigControl.LoadConnections(tvNodeRoot, wtvNodeFile, pConfiguration, pDataAccessMenuStrip,
//                                                    pConnectionMenuStrip);

//            #endregion
//        }


//        /// <summary>
//        /// Genera una seccion en TreeNode nodo sectionGroup del tree view
//        /// </summary>
//        /// <param name="ptvNodeRoot">Nodo root de los App.Config Files</param>
//        /// <param name="ptvNodeSectionGroup">Tree node SectionGroup</param>
//        /// <param name="pConfiguration">Configuration del archivo</param>
//        /// <param name="pContextMenuStripSection">menu contextual para las secciones</param>
//        internal static void GenerateSectionInSectionGroup(
//            TreeNode ptvNodeRoot,
//            TreeNode ptvNodeSectionGroup,
//            Configuration pConfiguration,
//            ContextMenuStrip pContextMenuStripSection)
//       {

//           ConfigurationSectionGroup wConfigurationSectionGroup = pConfiguration.GetSectionGroup("applicationSettings");
//           if (wConfigurationSectionGroup == null) return;
//           foreach (ConfigurationSection wSection in wConfigurationSectionGroup.Sections)
//           {
//               if (SectionsAndGroupsConfig.ChekIsValidSection(wSection.SectionInformation.Name))
//               {
//                   TreeNode wtvSection = new TreeNode(wSection.SectionInformation.Name);
//                   //wtvSection.Tag = xmlSection.Attributes["name"].Value;
//                   wtvSection.Tag = "Application";
//                   wtvSection.ContextMenuStrip = pContextMenuStripSection;
//                   wtvSection.SelectedImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("DocumentHS.png");
//                   wtvSection.ImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("DocumentHS.png");
//                   ptvNodeSectionGroup.Nodes.Add(wtvSection);
//               }
//           }
//       }

//        /// <summary>
//        /// Genera una seccion en TreeNode applicationSettings del tree view
//        /// </summary>
//        /// <param name="ptvNodeRoot">Nodo root de los App.Config Files</param>
//        /// <param name="ptvNodeApplicationSettings"></param>
//        /// <param name="pConfiguration">Configuration del archivo</param>
//        internal static void GenerateSectionInApplicationSettings(
//            TreeNode ptvNodeRoot, 
//            TreeNode ptvNodeApplicationSettings,
//            Configuration pConfiguration)
//        {

//            ConfigurationSectionGroup wConfigurationSectionGroup = pConfiguration.GetSectionGroup("applicationSettings");
//            if (wConfigurationSectionGroup == null) return;
//            foreach (ConfigurationSection wSection in wConfigurationSectionGroup.Sections)
//            {
//                if (SectionsAndGroupsConfig.ChekIsValidSection(wSection.SectionInformation.Name))
//                {
//                    Settings wSettingsClass = null;
//                    TreeNode wtvApplication = new TreeNode(wSection.SectionInformation.Name);
//                    wtvApplication.SelectedImageIndex =
//                        ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("DocumentHS.png");
//                    wtvApplication.ImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("DocumentHS.png");
//                    wtvApplication.Tag = "Application";
//                    //Recorro los Settings y me trae los values

//                    ClientSettingsSection wClientSettingsSection = (System.Configuration.ClientSettingsSection)wSection;
//                    foreach (SettingElement wSetting in wClientSettingsSection.Settings)
//                    {
//                        if (SectionsAndGroupsConfig.CheIsValidSettings(wSetting))
//                        {
//                            TreeNode wtvSettingName = new TreeNode(wSetting.Name);

//                            wSettingsClass = new Settings(wSetting.Name, wtvApplication.Text);

//                            wSettingsClass.Value = wSetting.Value.ValueXml.InnerXml;

//                            wtvSettingName.Tag = wSettingsClass;

//                            wtvSettingName.SelectedImageIndex =
//                                ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("PushpinHS.png");
//                            wtvSettingName.ImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("RecordHS.png");

//                            wtvApplication.Nodes.Add(wtvSettingName);
//                        }
//                    }


//                    ptvNodeApplicationSettings.Nodes.Add(wtvApplication);
//                }
//            }
//        }


//        internal static void GenerateSection(             
//            TreeNode ptvNodeFile, 
//            ContextMenuStrip pmnAppConfigAplications)        {

//            ListDictionary wDictionary = (ListDictionary)ptvNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            ptvNodeFile.Nodes[0].Nodes.Clear();

//            TreeNodeConfig.GenerateSectionInSectionGroup(ptvNodeFile.Parent, ptvNodeFile.Nodes[0], wConfiguration, pmnAppConfigAplications);

//            ptvNodeFile.Nodes[1].Nodes.Clear();
//            TreeNodeConfig.GenerateSectionInApplicationSettings(ptvNodeFile.Parent, ptvNodeFile.Nodes[1], wConfiguration);
        
//        }
//        /// <summary>
//        /// Genera un TreeNode sectionGroup
//        /// </summary>
//        /// <param name="ptvNodeRoot">Nodo root de los App.Config Files</param>
//        /// <param name="ptvNodeFile"></param>
//        /// <param name="mnAppConfigAplications"></param>
//        internal static TreeNode GenerateSectionGroup(TreeNode ptvNodeRoot, TreeNode ptvNodeFile, ContextMenuStrip mnAppConfigAplications)
//        {
//            TreeNode wtvNodeSectionGroup = new TreeNode("sectionGroup");
//            ptvNodeFile.Nodes.Add(wtvNodeSectionGroup);

//            wtvNodeSectionGroup.ContextMenuStrip = mnAppConfigAplications;

//            wtvNodeSectionGroup.SelectedImageIndex =
//                ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("CascadeWindowsHS.png");
//            wtvNodeSectionGroup.ImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("CascadeWindowsHS.png");

//            return wtvNodeSectionGroup;
//        }

//        /// <summary>
//        /// Genera un TreeNode applicationSettings
//        /// </summary>
//        /// <param name="ptvNodeRoot">Nodo root de los App.Config Files</param>
//        /// <param name="ptvNodeFile"></param>
//        /// <param name="mnAppConfigAplications"></param>
//        /// <returns></returns>
//        internal static TreeNode GenrateApplicationSettings(TreeNode ptvNodeRoot, TreeNode ptvNodeFile, ContextMenuStrip mnAppConfigAplications)
//        {
//            TreeNode wtvNodeApplicationSettings = new TreeNode("applicationSettings");
//            ptvNodeFile.Nodes.Add(wtvNodeApplicationSettings);
//            wtvNodeApplicationSettings.ContextMenuStrip = mnAppConfigAplications;

//            wtvNodeApplicationSettings.SelectedImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
//            wtvNodeApplicationSettings.ImageIndex = ptvNodeRoot.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");

//            return wtvNodeApplicationSettings;
//        }

//        /// <summary>
//        /// Elimina SectionGroup / ApplicationSettings
//        /// </summary>
//        /// <param name="ptvNodeFile"></param>
//        /// <param name="pSeccionName"></param>
//        /// <returns></returns>
//        internal static void RemoveSection(TreeNode ptvNodeFile, string pSeccionName)
//        {

//            int index = 0;//ptnNodeFile.Nodes.IndexOfKey("SectionGroup");

//            Helper.TreeNodeExist(ptvNodeFile, "sectionGroup", out index);
//            TreeNode node = ptvNodeFile.Nodes[index];

//            Helper.TreeNodeExist(node, pSeccionName, out index);
//            node.Nodes[index].Remove();
          

//            Helper.TreeNodeExist(ptvNodeFile, "applicationSettings", out index);
//            node = ptvNodeFile.Nodes[index];
//            Helper.TreeNodeExist(node, pSeccionName, out index);
//            node.Nodes[index].Remove();
//        }

//        #region DataBase

//        /// <summary>
//        /// Crea un nodo root para todas los nodos conexión en el tree view.-
//        /// </summary>
//        /// <param name="ptvNodeFile"></param>
//        /// <param name="pMenu"></param>
//        /// <author>Marcelo Oviedo</author>
//        internal static TreeNode GenerateDataBaseNode(TreeNode ptvNodeFile, ContextMenuStrip pMenu)
//        {
//            TreeNode wtvSection = new TreeNode("Data base configuration");
//            wtvSection.SelectedImageIndex = ptvNodeFile.TreeView.ImageList.Images.IndexOfKey("DocumentHS.png");
//            wtvSection.ImageIndex = ptvNodeFile.TreeView.ImageList.Images.IndexOfKey("DocumentHS.png");
//            wtvSection.ContextMenuStrip = pMenu;
//            wtvSection.Tag = "DataConfig";
//            ptvNodeFile.Nodes.Add(wtvSection);
//            return wtvSection;
//        }

//        /// <summary>
//        /// Crea un nuevo nodo de conexión en el tree view
//        /// </summary>
//        /// <param name="ptvRootDataBaseNode"></param>
//        /// <param name="pCnnString">Objeto que  reprecenta una cadena de conexión seleccionada</param>
//        /// <param name="menu">Menu contextual especifico para nodos de conexión</param>
//        /// <author>Marcelo Oviedo</author>
//        internal static void GenerateCnnStringNode(TreeNode ptvRootDataBaseNode, CnnString pCnnString, ContextMenuStrip menu)
//        {
//            TreeNode wtvCnnString = new TreeNode(pCnnString.Name);
//            wtvCnnString.Tag = pCnnString;
//            wtvCnnString.ContextMenuStrip = menu;

//            wtvCnnString.SelectedImageIndex = ptvRootDataBaseNode.TreeView.ImageList.Images.IndexOfKey("POWER04B.ICO");
//            wtvCnnString.ImageIndex = ptvRootDataBaseNode.TreeView.ImageList.Images.IndexOfKey("POWER04B.ICO");
//            //wtvSection.ContextMenuStrip = pMenu;
//            ptvRootDataBaseNode.Nodes.Add(wtvCnnString);
//        }
//        #endregion



//    }


//}

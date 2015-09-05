//using System;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Windows.Forms;
//using System.Xml;
//using ConfigurationApp.Common;

//namespace ConfigurationApp
//{
//    class WrapperConfig
//    {
//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper
//        /// Los valores que el Wrapper asume
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        internal static void AddWebServiceWrapperSection(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;
//            System.Collections.Generic.List<string> wrapperSettingList = SomeWrapperExist(wConfiguration, WrapperType.WebService);
//            if (wrapperSettingList.Count == 0)
//            {
//                MessageBox.Show("The wrapper configuration section already exist", "Information", MessageBoxButtons.OK,
//                                MessageBoxIcon.Information);
//                return;
//            }
           
//            String configSections = TemplateProvider.GetAppConfigValue("BasesConfigSectionsName");
//            if (wrapperSettingList[0] == "BasesConfigSectionsName") //-----> agregar directamente toda la seccion
//            {
//                SectionsAndGroupsConfig.AddSection(wConfiguration, configSections, "applicationSettings", "Fwk.Bases.ApplicationSettings");
//                TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);
//            }
//            else
//            {
//                foreach (string setting in wrapperSettingList)
//                {
//                    SectionsAndGroupsConfig.Add_SettingInSection(wConfiguration, configSections, "applicationSettings", setting,String.Empty);
//                }
//            }


//            AddFrmBaseSection(pTreeNodeFile, WrapperType.WebService, pContextMenuStripSection);

//        }


//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper
//        /// Los valores que el Wrapper asume
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        internal static void AddRemotingWrapperSection(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            System.Collections.Generic.List<string> wrapperSettingList = SomeWrapperExist(wConfiguration, WrapperType.Remoting);
//            if (wrapperSettingList.Count == 0)
//            {
//                MessageBox.Show("The wrapper configuration section already exist", "Information", MessageBoxButtons.OK,
//                                MessageBoxIcon.Information);
//                return;
//            }


//            String configSections = TemplateProvider.GetAppConfigValue("BasesConfigSectionsName");


//            if (wrapperSettingList[0] == "BasesConfigSectionsName") //-----> agregar directamente toda la seccion con sus settings
//            {
//                SectionsAndGroupsConfig.AddSection(wConfiguration, configSections, "applicationSettings", "Fwk.Bases.ApplicationSettings");
//                TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);
//            }
//            else//agregar los setings que sean necesarios
//            {
//                foreach (string setting in wrapperSettingList)
//                {
//                    SectionsAndGroupsConfig.Add_SettingInSection(wConfiguration, configSections, "applicationSettings", setting, String.Empty);
//                }
//            }


//            AddFrmBaseSection(pTreeNodeFile, WrapperType.WebService, pContextMenuStripSection);

//        }

//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper
//        /// Los valores que el Wrapper asume
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        internal static void AddLocalWrapperSection(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            if (SomeWrapperExist(wConfiguration, WrapperType.Local).Count ==0)
//            {
//                MessageBox.Show("The wrapper configuration section already exist", "Information", MessageBoxButtons.OK,
//                                MessageBoxIcon.Information);
//                return;
//            }
//            ///Elimino Cualquier configuracion del wrapper exitente
//            Remove(pTreeNodeFile);
//            String configSections = TemplateProvider.GetAppConfigValue("WrapperConfigSectionsName");


//            SectionsAndGroupsConfig.AddSection(wConfiguration, configSections, "applicationSettings", "LocalWrapperApplicationSettings");
//            TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);
//            if (!SectionsAndGroupsConfig.SectionExist(wConfiguration, TemplateProvider.GetAppConfigValue("WrapperType.ConfigSectionsName"), "applicationSettings"))
//            {
//                AddFrmBaseSection(pTreeNodeFile, WrapperType.Local, pContextMenuStripSection);
//            }
//            //System.Collections.Generic.Dictionary<string, string> dic = TemplateProvider.GetSettingDic("BusinessFacadeSettings");
//            //String SettingProcessConfigurationManagerType = dic["ProcessConfigurationManagerType"].Replace("[ProcessConfigurationManagerType]", TemplateProvider.GetAppConfigValue("XmlProcessConfigurationManager"));

//            //SectionsAndGroupsConfig.AddSection(wConfiguration, configSections, "applicationSettings", "BusinessFacadeSettings");
//            //SectionsAndGroupsConfig.ChangeSettingValue(pTreeNodeFile, configSections, "ProcessConfigurationManagerType", SettingProcessConfigurationManagerType);
//            //TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);

//        }


//        /// <summary>
//        /// Agrega configuracion de Front Base "Bases.FrontEnd.ConfigSections"
//        /// Esta configuracion permite determinar el tipo de Wrapper se utiliza
//        /// </summary>
//        /// <param name="pTreeNodeFile"></param>
//        /// <param name="pWrapperType"></param>
//        /// <param name="pContextMenuStripSection"></param>
//        private static void AddFrmBaseSection(TreeNode pTreeNodeFile, WrapperType pWrapperType, ContextMenuStrip pContextMenuStripSection)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;


//            String configSections = TemplateProvider.GetAppConfigValue("BasesConfigSectionsName");

//            String wWrapperName = Enum.GetName(typeof(WrapperType), pWrapperType) + "Wrapper";

//            System.Collections.Generic.Dictionary<string, string> dic = TemplateProvider.GetSettingDic("WrapperType.ApplicationSettings");
//            String SettingWrapperValue = dic["Wrapper"].Replace("[WrapperName]", wWrapperName);
            
//            SectionsAndGroupsConfig.ChangeSettingValue(pTreeNodeFile, configSections, "Wrapper", SettingWrapperValue);

//            TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);


//        }


//        /// <summary>
//        /// Elimina la configuracion del Wrapper existente
//        /// </summary>
//        /// <param name="pTreeNodeFile">TreeNode que reprecenta un archivo de configuracion</param>
//        internal static void Remove(TreeNode pTreeNodeFile)
//        {
//            String wSectionName = String.Empty;
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            #region [WrapperConfigSectionsName]
//            wSectionName = TemplateProvider.GetAppConfigValue("WrapperConfigSectionsName");
//            if (SectionsAndGroupsConfig.SectionExist(pConfiguration, wSectionName, "applicationSettings"))
//            {
//                TreeNodeConfig.RemoveSection(pTreeNodeFile, wSectionName);
//                SectionsAndGroupsConfig.RemoveSection(pConfiguration, wSectionName);
//            }


//            #endregion

//            #region [BusinessFacadeConfigSectionName]
//            wSectionName = TemplateProvider.GetAppConfigValue("BusinessFacadeConfigSectionName");
//            ///Para el caso de que tengo un wrapper local pre configurado
//            if (SectionsAndGroupsConfig.SectionExist(pConfiguration, wSectionName, "applicationSettings"))
//            {
//                TreeNodeConfig.RemoveSection(pTreeNodeFile, wSectionName);
//                //Elimina sectionGroup/section/@name
//                SectionsAndGroupsConfig.RemoveSection(pConfiguration, wSectionName);
//            }

//            #endregion

//            #region [WrapperType.ConfigSectionsName]
//            wSectionName = TemplateProvider.GetAppConfigValue("WrapperType.ConfigSectionsName");
//            if (SectionsAndGroupsConfig.SectionExist(pConfiguration, wSectionName, "applicationSettings"))
//            {
//                TreeNodeConfig.RemoveSection(pTreeNodeFile, wSectionName);
//                //Elimina sectionGroup/section/@name
//                SectionsAndGroupsConfig.RemoveSection(pConfiguration, wSectionName);

//            }

//            #endregion
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pConfiguration"></param>
//        /// <returns></returns>
//        static System.Collections.Generic.List<String>  SomeWrapperExist(Configuration pConfiguration, WrapperType pWrapperType)
//        {
//            System.Collections.Generic.List<String> wSettingElementList = new System.Collections.Generic.List<string>();
//            string name = TemplateProvider.GetAppConfigValue("BasesConfigSectionsName");

//            if (SectionsAndGroupsConfig.SectionExist(pConfiguration,
//                                                               name, "applicationSettings"))
//            {
//                ConfigurationSection wConfigurationSection = SectionsAndGroupsConfig.Get_Section(pConfiguration, name, "applicationSettings");
//                SettingElement wSettingElement = null;

//                wSettingElement = SectionsAndGroupsConfig.Get_SettingByName(wConfigurationSection, "Wrapper");
//                if (wSettingElement == null)
//                    wSettingElementList.Add("Wrapper");

//                if (pWrapperType == WrapperType.WebService)
//                {
//                      wSettingElement = SectionsAndGroupsConfig.Get_SettingByName(wConfigurationSection, "WebServiceDispatcherUrl");
//                    if (wSettingElement == null)
//                        wSettingElementList.Add("WebServiceDispatcherUrl");

//                }


//                if (pWrapperType == WrapperType.Remoting)
//                {
//                    wSettingElement = SectionsAndGroupsConfig.Get_SettingByName(wConfigurationSection, "DispatcherRemotingConfigFilePath");

//                    if (wSettingElement == null)
//                        wSettingElementList.Add("DispatcherRemotingConfigFilePath");
//                }
//            }
//            else
//            {
//                wSettingElementList.Add("BasesConfigSectionsName");  
//            }

//            return wSettingElementList;
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Text;
//using System.Windows.Forms;
//using ConfigurationApp.Common;

//namespace ConfigurationApp.AppConfig
//{
//    internal class ServiceMannagerConfig
//    {
//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper
//        /// Los valores que el Wrapper asume
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        internal static void AddBusinessFacadeSection(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            String configSections = TemplateProvider.GetAppConfigValue("BusinessFacadeConfigSectionName");

//            System.Collections.Generic.Dictionary<string, string> dic = TemplateProvider.GetSettingDic("BusinessFacadeSettings");
            
//            String SettingProcessConfigurationManagerType =
//                dic["ServiceConfigurationManagerType"].Replace
//                ("[ServiceConfigurationManagerType]", TemplateProvider.GetAppConfigValue("XmlServiceConfigurationManager"));

//            ///Agrega la seccion completa si no existe
//            SectionsAndGroupsConfig.AddSection(wConfiguration, configSections, "applicationSettings", "BusinessFacadeSettings");

//            System.Collections.Generic.List<string> wBusinessFacadeSettingList = Exist(wConfiguration);
//            foreach (string setting in wBusinessFacadeSettingList)
//            {
//                SectionsAndGroupsConfig.Add_SettingInSection(wConfiguration, configSections, "applicationSettings", setting, String.Empty);
//            }

//            SectionsAndGroupsConfig.ChangeSettingValue(pTreeNodeFile, configSections, "ServiceConfigurationManagerType", SettingProcessConfigurationManagerType);
//            TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);

//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pConfiguration"></param>
//        /// <returns></returns>
//        static System.Collections.Generic.List<String> Exist(Configuration pConfiguration)
//        {
//            System.Collections.Generic.List<String> wSettingElementList = new System.Collections.Generic.List<string>();
//            string name = TemplateProvider.GetAppConfigValue("BusinessFacadeConfigSectionName");

//            if (SectionsAndGroupsConfig.SectionExist(pConfiguration,
//                                                               name, "applicationSettings"))
//            {
//                ConfigurationSection wConfigurationSection = SectionsAndGroupsConfig.Get_Section(pConfiguration, name, "applicationSettings");
//                SettingElement wSettingElement = null;

//                wSettingElement = SectionsAndGroupsConfig.Get_SettingByName(wConfigurationSection, "ConnectionName");
//                if (wSettingElement == null)
//                    wSettingElementList.Add("ConnectionName");

//                wSettingElement = SectionsAndGroupsConfig.Get_SettingByName(wConfigurationSection, "ConfigurationFilePath");
//                if (wSettingElement == null)
//                    wSettingElementList.Add("ConfigurationFilePath");

//                wSettingElement = SectionsAndGroupsConfig.Get_SettingByName(wConfigurationSection, "ServiceConfigurationManagerType");
//                if (wSettingElement == null)
//                    wSettingElementList.Add("ServiceConfigurationManagerType");

//            }
//            else
//            {
//                wSettingElementList.Add("BusinessFacadeConfigSectionName");
//            }

//            return wSettingElementList;
//        }
    
//    }
//}

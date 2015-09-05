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
//    internal class ConfigurationManagerConfig
//    {
//        /// <summary>
//        /// Agrega una seccion para Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings dentro 
//        /// de <configSections>
//        /// </summary>
//        /// <param name="pTreeNodeFile"></param>
//        internal static void AddSection(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
//            Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
//            wDictionary["Saved"] = false;

//            String wConfigurationConfigSectionsName = TemplateProvider.GetAppConfigValue("ConfigurationConfigSectionsName");
//            if (SectionsAndGroupsConfig.SectionExist(wConfiguration, wConfigurationConfigSectionsName, "applicationSettings"))
//            {
//                MessageBox.Show("This seccion already exist", "Information", MessageBoxButtons.OK,
//                                MessageBoxIcon.Information);
//                return;
//            }


//            SectionsAndGroupsConfig.AddSection(wConfiguration, wConfigurationConfigSectionsName, "applicationSettings", "ConfigurationApplicationSettings");

//            TreeNodeConfig.GenerateSection(pTreeNodeFile, pContextMenuStripSection);
       
//        }



      
//    }
//}

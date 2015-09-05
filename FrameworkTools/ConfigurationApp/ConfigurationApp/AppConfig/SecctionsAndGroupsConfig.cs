using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ConfigurationApp.Common;

namespace ConfigurationApp
{
   internal  class SectionsAndGroupsConfig
   {


       /// <summary>
       /// Inserta elementos (Section y setting) en los :
       /// sectionGroup --> pTreeNodeFile.Nodes[0] y 
       /// applicationSettings --> pTreeNodeFile.Nodes[1]
       /// </summary>
       /// <param name="pTreeNodeFile"></param>
        /// <param name="pConfiguration"></param>
       /// <param name="pConfigSections"></param>
       /// <param name="pApplicationSettings"></param>
       /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
       /// <Author>Marcelo Oviedo</Author>   
       //internal static void AddSectionAndSettingsToSectionGroupAndAppSeting(TreeNode pTreeNodeFile,
       //    Configuration pConfiguration, String pConfigSections, String pApplicationSettings, ContextMenuStrip pContextMenuStripSection)
       //{
       //    //sectionGroup --> pTreeNodeFile.Nodes[0]
       //    pTreeNodeFile.Nodes[0].Nodes.Clear();
       //    //AddSectionGroupToTreeView(pTreeNodeFile, pConfiguration, pConfigSections, pContextMenuStripSection);
       //    TreeNodeConfig.GenerateSectionInSectionGroup(pTreeNodeFile.Parent, pTreeNodeFile.Nodes[0],pConfiguration, pContextMenuStripSection);

       //    //applicationSettings --> pTreeNodeFile.Nodes[1]
       //    pTreeNodeFile.Nodes[1].Nodes.Clear();
       //    TreeNodeConfig.GenerateSectionInApplicationSettings(pTreeNodeFile.Parent, pTreeNodeFile.Nodes[1], pConfiguration);
       //}

        /// <summary>
        /// Cambia el valor de un Setting:
        /// /configuration/applicationSettings/setting [name] . Value
        /// </summary>
        /// <param name="pTreeNodeFile">Nodo con el contenido del archivo App.config</param>
        /// <param name="pSectionName">Reprecenta un nodo de un applicationSettings </param>
        /// <param name="pSettingName">Nombre del setting a cambiar</param>
        /// <param name="pValue">Nuevo valor</param>
        /// <Author>Marcelo Oviedo</Author> 
       internal static void ChangeSettingValue(TreeNode pTreeNodeFile, String pSectionName, String pSettingName, String pNewValue)
        {
            ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
            Configuration pConfiguration = (Configuration)wDictionary["Configuration"];
            wDictionary["Saved"] = false;

            ConfigurationSection wSection = Get_Section(pConfiguration, pSectionName, "applicationSettings");

            ClientSettingsSection wClientSettingsSection = (System.Configuration.ClientSettingsSection)wSection;
            SettingElement setting = wClientSettingsSection.Settings.Get(pSettingName);
            setting.Value.ValueXml.InnerXml = pNewValue;
            wSection.SectionInformation.ForceSave = true;

        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="pConfiguration">Configuration del app.config</param>
       /// <param name="pSectionName">Seccion</param>
        /// <param name="pSectionGroupName">Grupo</param>
       internal static void AddSection(Configuration pConfiguration, String pSectionName,String pSectionGroupName,String pSettingTemplateName)
       {
           ConfigurationSectionGroup wConfigurationSectionGroup =null;
           SettingElement wSettingElement = null;
           XmlDocument doc = new XmlDocument();
           XmlNode xmlValue = doc.CreateNode(XmlNodeType.Element, "value", String.Empty);
           ConfigurationSectionCollection wSections = null;
           if (pSectionGroupName.Length == 0)
           {
               AddSectionFromAssembly(pConfiguration, pSectionName);
               return;
           }
           else
           {
               wConfigurationSectionGroup = pConfiguration.GetSectionGroup(pSectionGroupName);
               if (wConfigurationSectionGroup == null)
                   wConfigurationSectionGroup = AddSectionGroup(pConfiguration, pSectionGroupName);
               wSections = wConfigurationSectionGroup.Sections;
               
           }

           if (wSections.Get(pSectionName) != null) return;

           ClientSettingsSection wClientSettingsSection = new ClientSettingsSection();
           wClientSettingsSection.SectionInformation.RequirePermission = false;
           wClientSettingsSection.SectionInformation.ForceSave = true;
           
           #region Settings


           Dictionary<String, String> wSettings = TemplateProvider.GetSettingDic(pSettingTemplateName);

           if (wSettings != null)
           {
               foreach (KeyValuePair<string, string> seting in wSettings)
               {
                   wSettingElement = new SettingElement();
                   wSettingElement.Name = seting.Key;
                   xmlValue.InnerXml = seting.Value;
                   wSettingElement.Value.ValueXml = xmlValue.Clone();
                   wClientSettingsSection.Settings.Add(wSettingElement);
               }


           }
           #endregion
           wSections.Add(pSectionName, wClientSettingsSection);
           
       }
       internal static void Add_SettingInSection(Configuration pConfiguration,
           String pSectionName,
           String pSectionGroupName,
           String pSettingName,String settingValue)
       {
           ConfigurationSectionGroup wConfigurationSectionGroup = null;
           //SettingElement wSettingElement = null;
           XmlDocument doc = new XmlDocument();
           XmlNode xmlValue = doc.CreateNode(XmlNodeType.Element, "value", String.Empty);
           ConfigurationSectionCollection wSections = null;
           if (pSectionGroupName.Length == 0)
           {
               AddSectionFromAssembly(pConfiguration, pSectionName);
               return;
           }
           else
           {
               wConfigurationSectionGroup = pConfiguration.GetSectionGroup(pSectionGroupName);
               if (wConfigurationSectionGroup == null)
                   wConfigurationSectionGroup = AddSectionGroup(pConfiguration, pSectionGroupName);
               wSections = wConfigurationSectionGroup.Sections;
           }

           ConfigurationSection wConfigurationSection = wSections.Get(pSectionName);
           ClientSettingsSection wClientSettingsSection = (ClientSettingsSection)wConfigurationSection;
           wClientSettingsSection.SectionInformation.RequirePermission = false;
           wClientSettingsSection.SectionInformation.ForceSave = true;

           #region Settings
           //wClientSettingsSection.Settings.Get(pSettingName);

           SettingElement wSettingElement = new SettingElement();
           wSettingElement.Name = pSettingName;
           xmlValue.InnerXml = settingValue;
           wSettingElement.Value.ValueXml = xmlValue.Clone();
           wClientSettingsSection.Settings.Add(wSettingElement);

           #endregion

       }
       /// <summary>
       /// Obtiene una ConfigurationSection por reflection
       /// </summary>
       /// <param name="pConfiguration"></param>
       /// <param name="pSectionName">Ej databaseSettings</param>
       static void AddSectionFromAssembly(Configuration pConfiguration, String pSectionName)
       {
           String s = TemplateProvider.GetAssemblySections(pSectionName);
           ConfigurationSection wSection =
               (ConfigurationSection) Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(s);

           pConfiguration.Sections.Add(pSectionName, wSection);
           wSection.SectionInformation.ForceSave = true;
       }
       static ConfigurationSectionGroup AddSectionGroup(Configuration pConfiguration, String pSectionGroupName)
       {

           ConfigurationSectionGroup wConfigurationSectionGroup = null;
           if (pSectionGroupName == "applicationSettings")
               wConfigurationSectionGroup = new ApplicationSettingsGroup();
           if (pSectionGroupName == "userSettingsGroup")
               wConfigurationSectionGroup = new UserSettingsGroup();

          pConfiguration.SectionGroups.Add(pSectionGroupName, wConfigurationSectionGroup);
          return wConfigurationSectionGroup;
       }
       #region Gets

       /// <summary>
       /// Obtiene un SettingElement de applicationSettings/
       /// </summary>
       /// <param name="pConfiguration"></param>
       /// <param name="pSectionName">Nombre de la seccion  la que pertenece</param>
       /// <param name="pSettingName">Nombre del Setting</param>
       /// <param name="pNewValue"></param>
       /// <returns></returns>
       internal static SettingElement Get_Setting_FromApplicationSetting(Configuration pConfiguration, String pSectionName, String pSettingName, String pNewValue)
       {
           ConfigurationSection wSection = Get_Section(pConfiguration, pSectionName, "applicationSettings");

           return Get_SettingByName(wSection, pSettingName);
         

       }
     

       /// <summary>
       /// Obtiene una seccion (dentro de /configuration/configSections/[@name=) por nombre
       /// </summary>
       /// <param name="pConfiguration"></param>
       /// <param name="pSectionName"></param>
       /// <param name="pSectionGroupName">Ej: applicationSettings</param> 
       /// <returns></returns>
       internal static ConfigurationSection Get_Section(Configuration pConfiguration, String pSectionName, String pSectionGroupName)
       {
           try
           {
               
               if (pSectionGroupName.Length == 0)
               {
                   return pConfiguration.GetSection(pSectionName);
               }
               else
               {
                   return pConfiguration.GetSection(pSectionGroupName + @"/" + pSectionName);
               }
           }
           catch(System.Configuration.ConfigurationException ex)
           {
               StringBuilder serrMesage = new StringBuilder(ex.Message);
               serrMesage.AppendLine("Do you want to correct this secction");

               DialogResult res = MessageBox.Show(serrMesage.ToString(), "App configuration", MessageBoxButtons.YesNo);

               if(res ==DialogResult.Yes)
               {
                   //Elimino
                   RemoveSection2(pConfiguration, pSectionName);
                   //Agrego
                   AddSection(pConfiguration, pSectionName, String.Empty, String.Empty);
                   //Retorno
                   return Get_Section(pConfiguration, pSectionName, String.Empty);
               }

               
               return null;
           }
       }

   


       /// <summary>
       /// Obtiene la seccion connectionStrings
       /// </summary>
       /// <param name="pConfiguration">Configuration</param>
       /// <param name="pCnnName">Configuration name</param> 
       /// <returns></returns>
       internal static ConnectionStringSettings Get_ConnectionStrings(Configuration pConfiguration, String pCnnName)
       {
           ConnectionStringSettingsCollection wConnectionStrings = pConfiguration.ConnectionStrings.ConnectionStrings;
           foreach (ConnectionStringSettings wConnectionStringSettings in wConnectionStrings)
           {
               if (wConnectionStringSettings.Name.CompareTo(pCnnName) != -1)
               {
                   return wConnectionStringSettings;
               }
           }
           return null;
       }

       /// <summary>
       /// Obtiene el value de un Setting
       /// </summary>
       /// <param name="doc">XmlDocument</param>
       /// <param name="pSettings">XmlNode</param>
       /// <returns></returns>
       internal static string Get_SettingValue(ConfigurationSection wSection, String pSettingName)
       {
           ClientSettingsSection wClientSettingsSection = (System.Configuration.ClientSettingsSection)wSection;
           SettingElement setting = wClientSettingsSection.Settings.Get(pSettingName);
           return setting.Value.ValueXml.InnerXml;

       }

       /// <summary>
       /// Obtiene el value de un Setting
       /// </summary>
       /// <param name="doc">XmlDocument</param>
       /// <param name="pSettings">XmlNode</param>
       /// <returns></returns>
       internal static SettingElement Get_SettingByName(ConfigurationSection wSection, String pSettingName)
       {
           ClientSettingsSection wClientSettingsSection = (System.Configuration.ClientSettingsSection)wSection;
           SettingElement setting = wClientSettingsSection.Settings.Get(pSettingName);
           return setting;

       }
       #endregion

       #region Checks

       internal static bool CheIsValidSettings(SettingElement wSetting)
       {
           //if (wSetting.Attributes == null) return false;
           //if(wSettings.Attributes["name"] == null)return false;


           return true;
       }

       /// <summary>
       /// Valida si la seccion de configuracion es una seccion valida para configurar por la herramienta
       /// </summary>
       /// <param name="wSettings"></param>
       /// <returns></returns>
       internal static bool ChekIsValidSection(String wSectionName)
       {

           return TemplateProvider.AppConfigContainsKey(wSectionName.Trim());
       }

       
       #endregion

       #region Validar existencia de nodos
    
       /// <summary>
       /// 
       /// </summary>
       /// <param name="pConfiguration"></param>
       /// <param name="pFileName"></param>
       internal static void ValidateAppConfigConsistence(Configuration pConfiguration, string pFileName)
       {

           

           if (pConfiguration.RootSectionGroup.SectionGroupName == "applicationSettings")
           {
               throw new Exception("El archivo " + pFileName + "Section group applicationSettings not exist");
           }
          
       }

       #endregion


         

       /// <summary>
       /// Determina si existe o no una determinada section en  configSections  
       /// Por ejemplo dataConfiguration, cachingConfiguration, etc.
       /// </summary>
       /// <param name="pConfiguration">Configuration del App.Config</param>
       /// <param name="pSectionName">Nombre de la seccion</param>
       /// <param name="pSectionGroupName">Ej: applicationSettings</param> 
       /// <returns></returns>
       internal static bool SectionExist(Configuration pConfiguration, String pSectionName,String pSectionGroupName)
       {
           ConfigurationSection wSection = Get_Section(pConfiguration, pSectionName, pSectionGroupName);
           if (wSection == null)
               return false;
           else return true;

       }
       
       /// <summary>
       /// Elimina una seccion de la Configuration /  applicationSettings
       /// </summary>
       /// <param name="pConfiguration">Configuration App.Config</param>
       /// <param name="pSectionName">Nombre de la seccion</param>
      internal  static void RemoveSection(Configuration pConfiguration, String pSectionName)
       {
           ConfigurationSectionGroup wSectionGroup = pConfiguration.GetSectionGroup("applicationSettings");

           ConfigurationSection wSection = wSectionGroup.Sections.Get(pSectionName);//ConfigurationSection wSection = pConfiguration.GetSection("applicationSettings/" + pSectionName);
           wSection.SectionInformation.ForceSave = true;
           pConfiguration.GetSectionGroup("applicationSettings").Sections.Remove(pSectionName);

           pConfiguration.Sections.Remove(pSectionName);
       }

       /// <summary>
       /// Elimina una seccion de la Configuration
       /// </summary>
       /// <param name="pConfiguration">Configuration App.Config</param>
       /// <param name="pSectionName">Nombre de la seccion</param>
       internal static void RemoveSection2(Configuration pConfiguration, String pSectionName)
       {
           //ConfigurationSection wSection = pConfiguration.Sections.Get(pSectionName);//ConfigurationSection wSection = pConfiguration.GetSection("applicationSettings/" + pSectionName);
           //wSection.SectionInformation.ForceSave = true;
           pConfiguration.Sections.Remove(pSectionName);
       }

       /// <summary>
       /// Elimina una seccion de la Configuration
       /// </summary>
       /// <param name="pTreeNodeFile">Tree view con el App.Config</param>
       /// <param name="pSectionName">Nombre de la seccion</param>
       internal static void RemoveSection(TreeNode pTreeNodeFile, String pSectionName)
       {
           ListDictionary wDictionary = (ListDictionary)pTreeNodeFile.Tag;
           Configuration wConfiguration = (Configuration)wDictionary["Configuration"];
           wDictionary["Saved"] = false;
           RemoveSection(wConfiguration, pSectionName);
       }
   }
}

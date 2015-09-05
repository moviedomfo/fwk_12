using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.HelperFunctions;

namespace ConfigurationApp.Common
{
    public enum CnfgManagerSelectedNodeType { Root = 0, File = 1, Group = 2, Key = 3 } ;
    public enum AppConfigSelectedNodeType
    {
        /// <summary>
        /// Value = ; 0 Nivel 0
        /// </summary>
        Root = 0,
        /// <summary>
        /// Value = 1; 0 Nivel 1
        /// </summary>
        File = 1,
        /// <summary>
        /// Value = 2 ; 0 Nivel 2
        /// </summary>
        ApplicationSettings = 2,
        /// <summary>
        /// Value = 3; 0 Nivel 2
        /// </summary>
        SectionGroup = 3,
        /// <summary>
        /// Value = 4; 0 Nivel 4
        /// </summary>
        Application = 4,
        /// <summary>
        /// Value = 5
        /// </summary>
        Setting = 5,
        /// <summary>
        /// Value = 6 ; 0 Nivel 2
        /// </summary>
        CnnStrings = 6,
        /// <summary>
        /// Value = 7
        /// </summary>
        CnnString = 7
    } ;

    /// <summary>
    /// Indica cual es el nodo del tree view seleccionado .-
    /// </summary>
    public enum SelectedRoot { 
        /// <summary>
        /// Nodo perteneciente a la raiz donde se hubican los archivos App.config 
        /// </summary>
        AppConfigRoot = 0, 
        /// <summary>
        /// Nodo perteneciente a la raiz donde se hubican los archivos ConfigurationManagers.xml
        /// </summary>
        ConfigManagerRoot = 1, 
        /// <summary>
        /// 
        /// </summary>
        None = 2 } ;

    /// <summary>
    /// Enumeración de tipos de Wrappers
    /// </summary>
    public enum WrapperType
    {
        /// <summary>
        /// Wrapper que contiene la logica de para conectarce a un despachador de servicios hosteado en un web service.-
        /// </summary>
        WebService = 0,

        /// <summary>
        /// Wrapper que contiene la logica de para conectarce a un despachador de servicios hosteado en un win service
        /// implementado en una clase remota.-
        /// </summary>
        Remoting = 1,
        /// <summary>
        /// Wrapper que contiene la logica de para trabajar totalmente independiente de un despachador de servicio.
        /// Instancia directamente los servicios.
        /// </summary>
        Local = 2,

    }
    public enum ConfigurationType
    {
        ApplicationConfiuration = 0,
        ConfigurationManager = 1
    }
    /// <summary>
    /// Componente proveedor de templates .- Lee el archico Templates.xml
    /// </summary>
    internal class TemplateProvider
    {
        static Dictionary<String, String> _TemplateDictionary_AppConfi = null;
        static Dictionary<String, String> _TemplateDictionary_ConfigManager = null;
        static Dictionary<String, String> _TemplateDictionary_StandarsDataConfiguration = null;
      

        static Dictionary<String, Dictionary<String, String>> _Template_SettingSections = null;

        static Dictionary<String, String> _Template_AssemblySections = null;
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static TemplateProvider()
        {

            _TemplateDictionary_AppConfi = new Dictionary<string, string>();
            _TemplateDictionary_ConfigManager = new Dictionary<string, string>();
            _TemplateDictionary_StandarsDataConfiguration = new Dictionary<string, string>();
          
            _Template_AssemblySections = new Dictionary<string, string>(); 
            _Template_SettingSections = new Dictionary<string, Dictionary<string, string>>();

            LoadTemplates();
        }

        /// <summary>
        /// Retorna un valor del template AppConfig
        /// </summary>
        /// <param name="pPropertyName">Nombre del valor a obtener del template</param>
        /// <returns>Valor o contenido del template</returns>
        internal static string GetAppConfigValue(String pPropertyName)
        {
            return _TemplateDictionary_AppConfi[pPropertyName];
        }
    
        /// <summary>
        /// Retorna un valor del template AppConfig
        /// </summary>
        /// <param name="pPropertyName">Nombre del valor a obtener del template</param>
        /// <returns>Valor o contenido del template</returns>
        internal static Boolean AppConfigContainsKey(String pPropertyName)
        {
            return _TemplateDictionary_AppConfi.ContainsValue(pPropertyName);
        }
        /// <summary>
        /// Retorna un valor del template AppConfig
        /// </summary>
        /// <param name="pPropertyName">Nombre del valor a obtener del template</param>
        /// <returns>Valor o contenido del template</returns>
        internal static string  GetAssemblySections(String pPropertyName)
        {
            return _Template_AssemblySections[pPropertyName];
        }
        /// <summary>
        /// Retorna un valor del template ConfigurationManager
        /// </summary>
        /// <param name="pPropertyName">Nombre del valor a obtener del template</param>
        /// <returns>Valor o contenido del template</returns>
        internal static string GetConfigurationManagerValue(String pPropertyName)
        {



            return _TemplateDictionary_ConfigManager[pPropertyName];

        }
        /// <summary>
        /// Retorna un valor del template StandarsDataConfiguration
        /// </summary>
        /// <param name="pPropertyName">Nombre del valor a obtener del template</param>
        /// <returns>Valor o contenido del template</returns>
        internal static string GetStandarsDataConfigurationValue(String pPropertyName)
        {

            return _TemplateDictionary_StandarsDataConfiguration[pPropertyName];

        }
        
        /// <summary>
        /// Retorna un valor del template StandarsDataConfiguration
        /// </summary>
        /// <param name="pSectionName">Nombre de la seccion</param>
        /// <returns>Valor o contenido del template</returns>
        internal static Dictionary<string, string> GetSettingDic(String pSectionName)
        {
            if (_Template_SettingSections.ContainsKey(pSectionName))
                return _Template_SettingSections[pSectionName];
            else
                return null;
        }

        private static void LoadTemplates()
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Templates.xml");

                XmlNode wTemplateNode = doc.SelectSingleNode("Templates/Template[@name='AppConfi']");

                foreach (XmlNode o in wTemplateNode.ChildNodes)
                {
                    _TemplateDictionary_AppConfi.Add(o.Name, o.InnerText);
                }

                wTemplateNode = doc.SelectSingleNode("Templates/Template[@name='ConfigurationManager']");
                foreach (XmlNode o in wTemplateNode.ChildNodes)
                {
                    _TemplateDictionary_ConfigManager.Add(o.Name, o.InnerText);
                }

                wTemplateNode = doc.SelectSingleNode("Templates/Template[@name='StandarsDataConfiguration']");
                foreach (XmlNode o in wTemplateNode.ChildNodes)
                {
                    _TemplateDictionary_StandarsDataConfiguration.Add(o.Name, o.InnerText);
                }

              


                wTemplateNode = doc.SelectSingleNode("Templates/Template[@name='SettingsSections']");
                foreach (XmlNode o in wTemplateNode.ChildNodes)
                {
                    String wSettingName;
                    String wSettinValue;
                    Dictionary<String, String> wSettings = new Dictionary<String, String>();
                    
                    XmlDocument settingDoc = new XmlDocument();

                    settingDoc.LoadXml(o.InnerText);

                    foreach (XmlNode pXmlSettings in settingDoc.ChildNodes[0].ChildNodes)
                    {
                        wSettingName = Fwk.Xml.NodeAttribute.AttributeGet(pXmlSettings, "name");
                        wSettinValue = pXmlSettings.SelectSingleNode("value").InnerText;
                        wSettings.Add(wSettingName, wSettinValue);
                    }

                    _Template_SettingSections.Add(o.Name, wSettings);
                }

                wTemplateNode = doc.SelectSingleNode("Templates/Template[@name='AssemblySections']");
                foreach (XmlNode o in wTemplateNode.ChildNodes)
                {
                    _Template_AssemblySections.Add(o.Name, o.InnerText);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

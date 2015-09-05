using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;
using Fwk.Logging;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Regla de logueo. Estas reglas establecen una
    /// correspondencia entre el tipo de evento y su destino(File, 
    /// Xml, Database, WindowEvent o Console).
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class LogProviderElement : ConfigurationElement
    {
      
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElement.
        /// </summary>
        public LogProviderElement() { }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la regla. Es el identificador de una regla
        /// por lo tanto este nombre no debe repetirse.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        /// <summary>
        /// Conjunto de tipos de eventos sobre los cuales aplica
        /// la regla. Deben ser escritos separados por coma.
        /// </summary>
        //[ConfigurationProperty("events", IsRequired = true, IsKey = false), 
        // StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        //public  string EventsString
        //{
        //    get
        //    {
        //        return (string)this["events"];
        //    }
        //}

        /// <summary>
        /// Lista de tipos de eventos sobre los cuales aplica
        /// la regla.
        /// </summary>
        //public List<EventType> Events
        //{
        //    get
        //    {
        //        string[] wEventsString = EventsString.Split(',');
        //        List<EventType> wEvents = new List<EventType>();
        //        foreach (string wSingleEvent in wEventsString)
        //        {
        //            switch (wSingleEvent)
        //            {
                    
        //                case "Error":
        //                    {
        //                        wEvents.Add(EventType.Error);
        //                        break;
        //                    }
        //                case "Information":
        //                    {
        //                        wEvents.Add(EventType.Information);
        //                        break;
        //                    }
        //                case "Warning":
        //                    {
        //                        wEvents.Add(EventType.Warning);
        //                        break;
        //                    }
        //                case "Audit":
        //                    {
        //                        wEvents.Add(EventType.Audit);
        //                        break;
        //                    }
        //            }
        //        }
        //        if (wEvents.Count > 0)
        //        {
        //            return wEvents;
        //        }
        //        return null;
        //    }
        //}

        /// <summary>
        /// Cadena de texto con el destino o tipo de salida sobre la cual será escrito el log 
        /// del evento. Puede ser File, Xml, Database, WindowEvent o Console.
        /// </summary>
        [ConfigurationProperty("target", IsRequired = true, IsKey = false),
         StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string TargetString
        {
            get
            {
                return (string)this["target"];
            }
        }

        /// <summary>
        /// Destino o tipo de salida sobre la cual será escrito el log 
        /// del evento. Puede ser File, Xml, Database, WindowEvent o Console.
        /// </summary>
        public TargetType Target
        {
            get
            {
                switch (TargetString)
                {
                    case "File":
                        {
                            return TargetType.File;
                        }
                    case "Xml":
                        {
                            return TargetType.Xml;
                        }
                    case "Database":
                        {
                            return TargetType.Database;
                        }
                    case "WindowsEvent":
                        {
                            return TargetType.WindowsEvent;
                        }
                }
                return TargetType.None;
            }
        }

        /// <summary>
        /// Nombre del archivo sobre el cual será escrito el log del evento.
        /// Este atributo aplica si el target es File o Xml.
        /// </summary>
        [ConfigurationProperty("fileName", IsRequired = false, IsKey = false), 
         StringValidator(InvalidCharacters = @"~!@#$%^&*()[]{}/;'""|")]
        public string FileName
        {
            get
            {
                return (string)this["fileName"];
            }
        }

        /// <summary>
        /// Nombre de la cadena de conexión configurada en la Sección 
        /// 'connectionStrings'del archivo de configuración App.Config.
        /// Este atributo aplica solo para el target Database y debe
        /// existir la conexión configurada en la Sección 'connectionStrings'.
        /// </summary>
        [ConfigurationProperty("cnnStringName", IsRequired = false, IsKey = false),
         StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string CnnStringName
        {
            get
            {
                return (string)this["cnnStringName"];
            }
        }
        #endregion
    }
}

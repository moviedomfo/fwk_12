using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.ObjectModel;
using Fwk.Bases;
using System.Xml;
using System.Reflection;
using System.IO;
using Fwk.HelperFunctions;
using System.ComponentModel;
using Fwk.Exceptions;
namespace Fwk.Configuration.Common
{
    /// <summary>
    /// Clase contenedora de archivos de configuracion y sus estados. Esta clase permite cachear en memoria las configuraciones que
    /// son requeridas por las aplicacioenes. 
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    class ConfigurationRepository
    {

        private System.Collections.Generic.Dictionary<string, ConfigurationFile> _DictionaryFiles;


        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ConfigurationRepository()
        {

            _DictionaryFiles = new System.Collections.Generic.Dictionary<string, ConfigurationFile>();
        }

        /// <summary>
        /// Agrega un configuration file al hashtable.
        /// </summary>
        /// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
        public void AddConfigurationFile(ConfigurationFile pConfigurationFile)
        {
            if (pConfigurationFile == null)
            {
                TechnicalException te = new TechnicalException("Error al intentar agregar un archivo de configuracion: El parámetro ConfigurationFile no puede ser nulo.");
                te.ErrorId = "8012";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            if (_DictionaryFiles.ContainsKey(pConfigurationFile.ProviderName))
            {
                TechnicalException te = new TechnicalException(string.Concat("Error al intentar agregar un archivo de configuracion: El archivo ConfigurationFile ",pConfigurationFile.FileName, " ya se agrego con anterioridad al repositorio del configuration mannager."));
                te.ErrorId = "8012";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            _DictionaryFiles.Add(pConfigurationFile.ProviderName, pConfigurationFile);

        }


        /// <summary>
        /// Obtiene un ConfigurationFile del hashtable.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        public ConfigurationFile GetConfigurationFile(string providerName)
        {
            if (_DictionaryFiles.ContainsKey(providerName))
                return (ConfigurationFile)_DictionaryFiles[providerName];
            else
                return null;
        }

        /// <summary>
        /// Agrega un configuration file al hashtable.
        /// </summary>
        /// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
        public void RemoveConfigurationFile(ConfigurationFile pConfigurationFile)
        {
            if (pConfigurationFile == null)
            {
                
                TechnicalException te = new TechnicalException("Error al intentar eremover un archivo de configuracion: El parámetro ConfigurationFile no puede ser nulo.");
                te.ErrorId = "8012";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            if (!_DictionaryFiles.ContainsKey(pConfigurationFile.ProviderName))
            {
                TechnicalException te = new TechnicalException(string.Concat("Error al intentar eremover un archivo de configuracion: El archivo ", pConfigurationFile.FileName , " no se encuentra"));
                te.ErrorId = "8012";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            _DictionaryFiles.Remove(pConfigurationFile.ProviderName);
       }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public bool ExistConfigurationFile(string providerName)
        {
            return _DictionaryFiles.ContainsKey(providerName);
        }
    }


    /// <summary>
    /// Reprecenta un archivo de confuguracion y sus estados en memoria.-
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    [XmlRoot("ConfigurationFile"), SerializableAttribute]
    public class ConfigurationFile:Entity
    {
        #region ConfigurationFile properties
       
        bool _Encrypted;
        string _FileName;
        int _TTL;
        bool _ForceUpdate;
        string providerName= string.Empty;
       
        string _CurrentVersion;

 
      
        public bool Encrypted
        {
            get { return _Encrypted; }
            set { _Encrypted = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public int TTL
        {
            get { return _TTL; }
            set { _TTL = value; }
        }

        public bool ForceUpdate
        {
            get { return _ForceUpdate; }
            set { _ForceUpdate = value; }
        }

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

       

        public string CurrentVersion
        {
            get { return _CurrentVersion; }
            set { _CurrentVersion = value; }
        }
        #endregion

        Groups _Groups;
        private DateTime _TimeStamp;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ConfigurationFile()
        {
            _TimeStamp = new DateTime(0);
        }
        /// <summary>
        /// Resultado de la invocacíon al webservice.
        /// </summary>
        public Groups Groups
        {
            get
            {
                return _Groups;
            }
            set
            {
                _Groups = value;
                _TimeStamp = DateTime.Now;
            }
        }


        /// <summary>
        /// Fecha y hora de la obtención de la configuración.
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return _TimeStamp;
            }
        }


        

        /// <summary>
        /// Chequea si el archivo expiró.
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckExpiration()
        {
            return (TTL != 0 && this._TimeStamp.AddSeconds(TTL) < DateTime.Now);
          
        }

        /// <summary>
        /// Devuelve el estado del ConfigurationFile
        /// </summary>
        /// <returns>FileStatus</returns>
        public Helper.FileStatus CheckFileStatus()
        {
            Helper.FileStatus wStatus;

            if (_TimeStamp == new DateTime(0))
                wStatus = Helper.FileStatus.Inconsistent;
            else if (CheckExpiration())
                wStatus = Helper.FileStatus.Expired;
            else
                wStatus = Helper.FileStatus.Ok;

            return wStatus;

        }

    }
    

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Groups"), SerializableAttribute]
    public class Groups : BaseEntities<Group>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Group GetFirstByName(string pName)
        {

            IEnumerable<Group> wItem = this.Where(p => p.Name == pName);
            if (wItem.Count<Group>() == 0) return null;

            return wItem.First<Group>();
        }
    }




    [XmlInclude(typeof(Group)), Serializable]
    public class Group : Fwk.Bases.BaseEntity
    {
        string _name;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        Keys _Keys = new Keys();

        public Keys Keys
        {
            get { return _Keys; }
            set { _Keys = value; }
        }


       
 

    }
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Keys"), SerializableAttribute]
    public class Keys : Fwk.Bases.BaseEntities<Key>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Key GetFirstByName(string pName)
        {

            IEnumerable<Key> wItem = this.Where(p => p.Name == pName);
            if (wItem.Count<Key>() == 0) return null;

            return wItem.First<Key>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public int GetCountByName(string pName)
        {
            IEnumerable<Key> wItem = this.Where(p => p.Name == pName);
            return wItem.Count<Key>();
        }
    }

    [XmlInclude(typeof(Key)), Serializable]
    public class Key : Fwk.Bases.BaseEntity
    {
        string _Name;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        bool _Encrypted = false;

        [XmlAttribute("encrypted")]
        public bool Encrypted
        {
            get { return _Encrypted; }
            set { _Encrypted = value; }
        }

      

        Fwk.Xml.CData _Value = new Fwk.Xml.CData();

        [XmlElement("Value", Type = typeof(Fwk.Xml.CData))]
        public Fwk.Xml.CData Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

       
        
    }





   

}

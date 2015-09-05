using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Fwk.Bases;



namespace Fwk.Cache.Test
{
    
    #region Colaborator class
    /// <summary>
    /// Esta clase reprecenta un usuario e implementa INotifyPropertyChanged lo que le da soporte
    /// a bindings one-way and two-way
    /// </summary>
    [DataContract]
    public class Colaborator : INotifyPropertyChanged
    {
        #region Instance Fields
        private string _ImageURL;
        private string _Name;
        private string _HostName;
        string _MachineIp;
      
        private bool _IsAdmin;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Cosntructores
        /// <summary>
        /// Blank constructor
        /// </summary>
        public Colaborator()
        {
        }

        /// <summary>
        /// Assign constructor
        /// </summary>
        /// <param name="imageURL">Image url to allow a picture to be created for this chatter</param>
        /// <param name="name">The name to use for this chatter</param>
        public Colaborator(string imageURL, string name)
        {
            _ImageURL = imageURL;
            _Name = name;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// direccion url de la imagen del colaborador
        /// </summary>
        [DataMember]
        public string ImageURL
        {
            get { return _ImageURL; }
            set
            {
                _ImageURL = value;
                OnPropertyChanged("ImageURL");
            }
        }

        /// <summary>
        /// nombre del colaborador
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                // llama al handler OnPropertyChanged  cuando la propiedad cambia
                OnPropertyChanged("Name");
            }
        }
       
        [DataMember]
        public string MachineIp
        {
            get { return _MachineIp; }
            set
            {
                _MachineIp = value;
            }
        }
        [DataMember]
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }
        /// <summary>
        ///indica si el colaborador es administrador colaborador
        /// </summary>
        [DataMember]
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                _IsAdmin = value;
            }
        }
        #endregion
        #region OnPropertyChanged (for correct well behaved databinding)
        /// <summary>
        /// Informa el combio de valor de una propiedad
        ///  y si el binding nececita ser actualizado
        /// </summary>
        /// <param name="propValue">La propiedad que cambia</param>
        protected void OnPropertyChanged(string propValue)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propValue));
            }
        }
        #endregion
    }
    #endregion
    [XmlInclude(typeof(ColaboratorData)), Serializable]
    public class ColaboratorData:Entity
    {
        public ColaboratorData()
        {
            
        }
        
        //public ColaboratorData(Colaborator pColaborator)
        //{
        //    username = pColaborator.Name;
        //    _MachineIp = pColaborator.MachineIp;
        //}

        DomainList _DomainList;

        public DomainList DomainList
        {
            get { return _DomainList; }
            set { _DomainList = value; }
        }

        bool connected;

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }
        int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string domain;

        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }
        string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        
        int? cuentaId;

        public int? CuentaId
        {
            get { return cuentaId; }
            set { cuentaId = value; }
        }
        int? subAreaId;

        public int? SubAreaId
        {
            get { return subAreaId; }
            set { subAreaId = value; }
        }
        int? sucursalId;

        public int? SucursalId
        {
            get { return sucursalId; }
            set { sucursalId = value; }
        }

        int? cargoId;

        public int? CargoId
        {
            get { return cargoId; }
            set { cargoId = value; }
        }
        string _MachineIp;
      
        public string MachineIp
        {
            get { return _MachineIp; }
            set
            {
                _MachineIp = value;
            }
        }
    }
}

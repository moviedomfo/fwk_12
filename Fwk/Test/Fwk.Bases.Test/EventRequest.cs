using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fwk.Bases.Test
{
    [Serializable]
    public class EventRequest : Request<EventRequestParams>
    {
        public EventRequest()
        {
            this.ServiceName = "EventService";
        }
    }

    [XmlInclude(typeof(EventRequestParams)), Serializable]
    public class EventRequestParams : Entity
    {
        #region << -Attributes- >>
        /// <summary>
        /// Cadena de carácteres que identifica al evento
        /// </summary>
        private string _Par_Event_Tag = string.Empty;
        /// <summary>
        /// GUID de la instancia de la aplicación
        /// </summary>
        private Guid _Par_AppInstanceGUID = Guid.Empty;
        /// <summary>
        /// Host de donde proviene la solicitud
        /// </summary>
        private string _Par_LoginHost = string.Empty;
        /// <summary>
        /// Dirección IP de donde proviene la solicitud
        /// </summary>
        private string _Par_LoginIP = string.Empty;
        /// <summary>
        /// GUID enviado por la aplicación en la solicitud anterior
        /// </summary>
        private Guid _Par_RequestLoginGUID = Guid.Empty;
        /// <summary>
        /// GUID del tipo de autenticación seleccionado por el usuario
        /// </summary>
        private Guid _Par_AuthTypeGUID = Guid.Empty;
        /// <summary>
        /// Nombre de Usuario
        /// </summary>
        private string _Par_UserName = string.Empty;
        /// <summary>
        /// Contraseña del usuario (Obligatorio si el tipo de autenticación en "Propia" o de "Windows")
        /// </summary>
        [NonSerialized]
        private string _Par_UserKey = string.Empty;
        /// <summary>
        /// GUID del dominio seleccionado (Obligatorio si el tipo de autenticación es de "Windows")
        /// </summary>
        private Guid _Par_DomainGUID = Guid.Empty;
        /// <summary>
        /// GUID de sessión generado cuando el usuario se auténtica con éxito.
        /// </summary>
        private Guid _Par_RequestSessionGUID = Guid.Empty;
        /// <summary>
        /// GUID del elemento de menú seleccionado
        /// </summary>
        private Guid _Par_MenuGUID = Guid.Empty;
        #endregion

        #region << -Properties- >>
        public string Par_Event_Tag
        {
            get { return _Par_Event_Tag; }
            set { _Par_Event_Tag = value; }
        }

        public Guid Par_AppInstanceGUID
        {
            get { return _Par_AppInstanceGUID; }
            set { _Par_AppInstanceGUID = value; }
        }

        public string Par_LoginHost
        {
            get { return _Par_LoginHost; }
            set { _Par_LoginHost = value; }
        }

        public string Par_LoginIP
        {
            get { return _Par_LoginIP; }
            set { _Par_LoginIP = value; }
        }

        public Guid Par_RequestLoginGUID
        {
            get { return _Par_RequestLoginGUID; }
            set { _Par_RequestLoginGUID = value; }
        }

        public Guid Par_AuthTypeGUID
        {
            get { return _Par_AuthTypeGUID; }
            set { _Par_AuthTypeGUID = value; }
        }

        public string Par_UserName
        {
            get { return _Par_UserName; }
            set { _Par_UserName = value; }
        }

        [XmlIgnore]
        public string Par_UserKey
        {
            get { return _Par_UserKey; }
            set { _Par_UserKey = value; }
        }

        public Guid Par_DomainGUID
        {
            get { return _Par_DomainGUID; }
            set { _Par_DomainGUID = value; }
        }

        public Guid Par_RequestSessionGUID
        {
            get { return _Par_RequestSessionGUID; }
            set { _Par_RequestSessionGUID = value; }
        }

        public Guid Par_MenuGUID
        {
            get { return _Par_MenuGUID; }
            set { _Par_MenuGUID = value; }
        }
        #endregion

        public class EventList
        {
            #region << -Attributes- >>
            //public static string ValidateApplication = CommonMethods.Enumerations.GetDescription(Event.EventType.ValidateApplication);
            //public static string AuthenticationTypes = CommonMethods.Enumerations.GetDescription(Event.EventType.AuthenticationTypes);
            //public static string UserAuthentication = CommonMethods.Enumerations.GetDescription(Event.EventType.UserAuthentication);
            //public static string PermissionControl = CommonMethods.Enumerations.GetDescription(Event.EventType.PermissionCotrol);
            //public static string UsersEnabled = CommonMethods.Enumerations.GetDescription(Event.EventType.UsersEnabled);
            //public static string MenuPermission = CommonMethods.Enumerations.GetDescription(Event.EventType.MenuPermission);
            #endregion
        }
    }
}

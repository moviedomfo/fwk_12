using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;


namespace Fwk.Bases.Test
{
    //[Serializable]
    //public class EventRequest : Request<EventRequestParams>
    //{
    //    public EventRequest()
    //    {
    //        this.ServiceName = "EventService";
    //    }
    //}

    //[XmlInclude(typeof(EventRequestParams)), Serializable]
    //public class EventRequestParams : Entity
    //{
    //    #region << -Attributes- >>
    //    /// <summary>
    //    /// Cadena de carácteres que identifica al evento
    //    /// </summary>
    //    private string _Par_Event_Tag = string.Empty;
    //    /// <summary>
    //    /// GUID de la instancia de la aplicación
    //    /// </summary>
    //    private Guid _Par_AppInstanceGUID = Guid.Empty;
    //    /// <summary>
    //    /// Host de donde proviene la solicitud
    //    /// </summary>
    //    private string _Par_LoginHost = string.Empty;
    //    /// <summary>
    //    /// Dirección IP de donde proviene la solicitud
    //    /// </summary>
    //    private string _Par_LoginIP = string.Empty;
    //    /// <summary>
    //    /// GUID enviado por la aplicación en la solicitud anterior
    //    /// </summary>
    //    private Guid _Par_RequestLoginGUID = Guid.Empty;
    //    /// <summary>
    //    /// GUID del tipo de autenticación seleccionado por el usuario
    //    /// </summary>
    //    private Guid _Par_AuthTypeGUID = Guid.Empty;
    //    /// <summary>
    //    /// Nombre de Usuario
    //    /// </summary>
    //    private string _Par_UserName = string.Empty;
    //    /// <summary>
    //    /// Contraseña del usuario (Obligatorio si el tipo de autenticación en "Propia" o de "Windows")
    //    /// </summary>
    //    [NonSerialized]
    //    private string _Par_UserKey = string.Empty;
    //    /// <summary>
    //    /// GUID del dominio seleccionado (Obligatorio si el tipo de autenticación es de "Windows")
    //    /// </summary>
    //    private Guid _Par_DomainGUID = Guid.Empty;
    //    /// <summary>
    //    /// GUID de sessión generado cuando el usuario se auténtica con éxito.
    //    /// </summary>
    //    private Guid _Par_RequestSessionGUID = Guid.Empty;
    //    /// <summary>
    //    /// GUID del elemento de menú seleccionado
    //    /// </summary>
    //    private Guid _Par_MenuGUID = Guid.Empty;
    //    #endregion

    //    #region << -Properties- >>
    //    public string Par_Event_Tag
    //    {
    //        get { return _Par_Event_Tag; }
    //        set { _Par_Event_Tag = value; }
    //    }

    //    public Guid Par_AppInstanceGUID
    //    {
    //        get { return _Par_AppInstanceGUID; }
    //        set { _Par_AppInstanceGUID = value; }
    //    }

    //    public string Par_LoginHost
    //    {
    //        get { return _Par_LoginHost; }
    //        set { _Par_LoginHost = value; }
    //    }

    //    public string Par_LoginIP
    //    {
    //        get { return _Par_LoginIP; }
    //        set { _Par_LoginIP = value; }
    //    }

    //    public Guid Par_RequestLoginGUID
    //    {
    //        get { return _Par_RequestLoginGUID; }
    //        set { _Par_RequestLoginGUID = value; }
    //    }

    //    public Guid Par_AuthTypeGUID
    //    {
    //        get { return _Par_AuthTypeGUID; }
    //        set { _Par_AuthTypeGUID = value; }
    //    }

    //    public string Par_UserName
    //    {
    //        get { return _Par_UserName; }
    //        set { _Par_UserName = value; }
    //    }

    //    [XmlIgnore]
    //    public string Par_UserKey
    //    {
    //        get { return _Par_UserKey; }
    //        set { _Par_UserKey = value; }
    //    }

    //    public Guid Par_DomainGUID
    //    {
    //        get { return _Par_DomainGUID; }
    //        set { _Par_DomainGUID = value; }
    //    }

    //    public Guid Par_RequestSessionGUID
    //    {
    //        get { return _Par_RequestSessionGUID; }
    //        set { _Par_RequestSessionGUID = value; }
    //    }

    //    public Guid Par_MenuGUID
    //    {
    //        get { return _Par_MenuGUID; }
    //        set { _Par_MenuGUID = value; }
    //    }
    //    #endregion

    //    public class EventList
    //    {
    //        #region << -Attributes- >>
    //        public static string ValidateApplication = CommonMethods.Enumerations.GetDescription(Event.EventType.ValidateApplication);
    //        public static string AuthenticationTypes = CommonMethods.Enumerations.GetDescription(Event.EventType.AuthenticationTypes);
    //        public static string UserAuthentication = CommonMethods.Enumerations.GetDescription(Event.EventType.UserAuthentication);
    //        public static string PermissionControl = CommonMethods.Enumerations.GetDescription(Event.EventType.PermissionCotrol);
    //        public static string UsersEnabled = CommonMethods.Enumerations.GetDescription(Event.EventType.UsersEnabled);
    //        public static string MenuPermission = CommonMethods.Enumerations.GetDescription(Event.EventType.MenuPermission);
    //        #endregion
    //    }
    //}

    [Serializable]
    public class EventResponse : Response<EventResponseParams>
    {
    }

    //[XmlInclude(typeof(EventResponseParams)), Serializable]
    //public class EventResponseParams : Entity
    //{
    //    //public Event Error { get; set; }
    //    public Guid TrackingGUID { get; set; }

    //    public EventResponseParams()
    //    {
    //        this._AuthenticationModesResponse = new AuthenticationModesResponse();
    //    }

    //    #region << -VALIDAR-APP- >>
    //    //private ApplicationInstance _ValidateApplicationInstanseResponse = null;

    //    //public ApplicationInstance ValidateApplicationInstanseResponse
    //    //{
    //    //    get { return _ValidateApplicationInstanseResponse; }
    //    //    set { _ValidateApplicationInstanseResponse = value; }
    //    //}
    //    #endregion

    //    #region << -TIPOS-AUT- >>
    //    private AuthenticationModesResponse _AuthenticationModesResponse = null;

    //    public AuthenticationModesResponse AuthModesResponse
    //    {
    //        get { return _AuthenticationModesResponse; }
    //        set { _AuthenticationModesResponse = value; }
    //    }

    //    public class AuthenticationModesResponse : Entity
    //    {
    //        private DomainList _Domains = null;
    //        private AuthenticationTypeList _Authentications = null;
    //        public string QueryResponseXml = string.Empty;

    //        public DomainList Domains
    //        {
    //            get { return _Domains; }
    //            set
    //            {
    //                _Domains = value;
    //                if (value != null)
    //                    this.UpdateResponseXml(value.QueryResponseXml);
    //            }
    //        }

    //        public AuthenticationTypeList Authentications
    //        {
    //            get { return _Authentications; }
    //            set
    //            {
    //                _Authentications = value;
    //                if (value != null)
    //                    this.UpdateResponseXml(value.QueryResponseXml);
    //            }
    //        }

    //        public AuthenticationModesResponse()
    //        { }

    //        public AuthenticationModesResponse(DomainList pDomains, AuthenticationTypeList pAuthentications)
    //        {
    //            this._Domains = pDomains;
    //            this._Authentications = pAuthentications;
    //            this.QueryResponseXml = string.Concat(this._Authentications.QueryResponseXml, this._Domains.QueryResponseXml);
    //        }

    //        private void UpdateResponseXml(string pXmlString)
    //        {
    //            string wNewXml = string.Empty;

    //            if (string.IsNullOrEmpty(pXmlString))
    //                return;

    //            if (string.IsNullOrEmpty(this.QueryResponseXml))
    //            {
    //                this.QueryResponseXml = pXmlString;
    //                return;
    //            }

    //            this.QueryResponseXml.Replace("<Root>", "<Node>");

    //            wNewXml = "<Root>";
    //            wNewXml += this.QueryResponseXml;
    //            wNewXml += pXmlString;
    //            wNewXml += "</Root>";

    //            this.QueryResponseXml = wNewXml;
    //        }
    //    }
    //    #endregion

    //    #region << -USER-AUTENTIC- >>
    //    private User _UserAuthenticationResponse = null;
    //    public User UserAuthenticationResponse
    //    {
    //        get { return _UserAuthenticationResponse; }
    //        set { _UserAuthenticationResponse = null; }
    //    }
    //    #endregion

    //    #region << -CONTROL-PERMISOS- >>
    //    //private ControlsUIList _ControlsList = null;

    //    //public ControlsUIList ControlsPermissionsResponse
    //    //{
    //    //    get { return _ControlsList; }
    //    //    set { _ControlsList = value; }
    //    //}
    //    #endregion

    //    #region << -USERS-ENABLED- >>
    //    private UserList _UsersEnabled = null;

    //    public UserList UsersEnabledResponse
    //    {
    //        get { return _UsersEnabled; }
    //        set { _UsersEnabled = value; }
    //    }
    //    #endregion

    //    #region << -MENU-PERMISSION- >>
    //    //private MenuList _MenuPermission = null;

    //    //public MenuList MenuPermissionResponse
    //    //{
    //    //    get { return _MenuPermission; }
    //    //    set { _MenuPermission = value; }
    //    //}
    //    #endregion
    //}

    //public class UserList : Entities<User>
    //{

    //}
    //public class User : Entity
    //{
    //    public String Name { get; set; }
    //}
}

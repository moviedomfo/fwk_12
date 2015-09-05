using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Fwk.Bases;
using Newtonsoft.Json;

namespace Fwk.Bases.Test
{
    [XmlInclude(typeof(EventResponseParams)), Serializable]
    public class EventResponseParams : Entity
    {
        public Event Error { get; set; }
        public Guid TrackingGUID { get; set; }

        public EventResponseParams()
        {
            this._AuthenticationModesResponse = new AuthenticationModesResponse();
        }

        #region << -VALIDAR-APP- >>
        private ApplicationInstance _ValidateApplicationInstanseResponse = null;

        public ApplicationInstance ValidateApplicationInstanseResponse
        {
            get { return _ValidateApplicationInstanseResponse; }
            set { _ValidateApplicationInstanseResponse = value; }
        }
        #endregion

        #region << -TIPOS-AUT- >>
        private AuthenticationModesResponse _AuthenticationModesResponse = null;

        public AuthenticationModesResponse AuthModesResponse
        {
            get { return _AuthenticationModesResponse; }
            set { _AuthenticationModesResponse = value; }
        }

        public class AuthenticationModesResponse : Entity
        {
            [JsonIgnore]
            private DomainList _Domains = null;
            [JsonIgnore]
            private AuthenticationTypeList _Authentications = null;
            public string QueryResponseXml = string.Empty;

            public DomainList Domains
            {
                get { return _Domains; }
                set
                {
                    _Domains = value;
                    //if (value != null)
                    //    this.UpdateResponseXml(value.QueryResponseXml);
                }
            }

            public AuthenticationTypeList Authentications
            {
                get { return _Authentications; }
                set
                {
                    _Authentications = value;
                    //if (value != null)
                    //    this.UpdateResponseXml(value.QueryResponseXml);
                }
            }

            public AuthenticationModesResponse()
            { }

            //public AuthenticationModesResponse(DomainList pDomains, AuthenticationTypeList pAuthentications)
            //{
            //    this._Domains = pDomains;
            //    this._Authentications = pAuthentications;
            //    this.QueryResponseXml = string.Concat(this._Authentications.QueryResponseXml, this._Domains.QueryResponseXml);
            //}

            private void UpdateResponseXml(string pXmlString)
            {
                string wNewXml = string.Empty;

                if (string.IsNullOrEmpty(pXmlString))
                    return;

                if (string.IsNullOrEmpty(this.QueryResponseXml))
                {
                    this.QueryResponseXml = pXmlString;
                    return;
                }

                this.QueryResponseXml.Replace("<Root>", "<Node>");

                wNewXml = "<Root>";
                wNewXml += this.QueryResponseXml;
                wNewXml += pXmlString;
                wNewXml += "</Root>";

                this.QueryResponseXml = wNewXml;
            }
        }
        #endregion

        #region << -USER-AUTENTIC- >>
        private User _UserAuthenticationResponse = null;
        public User UserAuthenticationResponse
        {
            get { return _UserAuthenticationResponse; }
            set { _UserAuthenticationResponse = null; }
        }
        #endregion

        #region << -CONTROL-PERMISOS- >>
        //private ControlsUIList _ControlsList = null;

        //public ControlsUIList ControlsPermissionsResponse
        //{
        //    get { return _ControlsList; }
        //    set { _ControlsList = value; }
        //}
        #endregion

        #region << -USERS-ENABLED- >>
        private UserList _UsersEnabled = null;

        public UserList UsersEnabledResponse
        {
            get { return _UsersEnabled; }
            set { _UsersEnabled = value; }
        }
        #endregion

        #region << -MENU-PERMISSION- >>
        ////private MenuList _MenuPermission = null;

        ////public MenuList MenuPermissionResponse
        ////{
        ////    get { return _MenuPermission; }
        ////    set { _MenuPermission = value; }
        ////}
        #endregion
    }


    public class ApplicationInstance : Entity
    {
        public String Name { get; set; }
    }

    public class UserList : Entities<User>
    {

    }
    public class User : Entity
    {
        public String Name { get; set; }
    }


    [Serializable]
    public class AuthenticationType : Entity
    {
        #region << -Enumerations- >>
        public enum Type
        {
            [Description("WINDOWS")]
            Windows = 1,
            [Description("INTEGRATED")]
            Integrated = 2,
            [Description("OWN")]
            Own
        }
        #endregion

        #region << -Attributes- >>
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime Created { get; set; }
        public Guid GUID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedByUser { get; set; }
        public string Tag { get; set; }
        public string UserName { get; set; }
        #endregion

        #region << -Constructors- >>
        public AuthenticationType()
            : base()
        { }

        //public AuthenticationType(System.Data.DataTable pTable)
        //    : base(pTable)
        //{ }
        #endregion
    }

    [Serializable]
    public class AuthenticationTypeList : Entities<AuthenticationType>
    {
        public AuthenticationTypeList()
            : base()
        { }

        //public AuthenticationTypeList(DataTable pTable)
        //    : base(pTable)
        //{ }
    }




}

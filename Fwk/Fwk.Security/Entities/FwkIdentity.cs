using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Data;

namespace Fwk.Security.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class FwkIdentity :ObjectDomain, IIdentity
    {
        #region {Declaraciones}
        private List<ObjectDomainGroup> _ActiveDirectoryGroups = null;
        /// <summary>
        /// 
        /// </summary>
        public List<ObjectDomainGroup> ActiveDirectoryGroups
        {
            get
            {
                if (_ActiveDirectoryGroups == null)
                    RefreshADGroups();
                return _ActiveDirectoryGroups;
            }
           
        }

        private bool _IsAuthenticated;
        private string  _AuthenticationType;

        private string _FirstName, _LastName, _Mail, _UserPrincipalName,  _DistinguishedName, _Description, _Domain;
        /// <summary>
        /// 
        /// </summary>
        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DistinguishedName
        {
            get { return _DistinguishedName; }
            set { _DistinguishedName = value; }
        }



        /// <summary>
        /// Nombre usuario como moviedo@actionline.com
        /// </summary>
        public string UserPrincipalName
        {
            get { return _UserPrincipalName; }
            set { _UserPrincipalName = value; }
        }

        /// <summary>
        /// Correo electionico
        /// </summary>
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }

        /// <summary>
        /// Determina cuando el usuario esta autenticado o no.-
        /// </summary>
        public bool IsAuthenticated
        {
            get { return this._IsAuthenticated; }

        }

   

        //}
        /// <summary>
        /// Tipo de autentificacion usado para determinar al usuario.-
        /// </summary>
        public string AuthenticationType
        {
            get { return _AuthenticationType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            get { return _FirstName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LastName
        {
            get { return this._LastName; }
            set { _LastName = value; }
        }
        
        public FwkIdentity()
        {
            base.Name = String.Empty;
            this._IsAuthenticated = false;
            this._AuthenticationType = "None";

        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsLogin"></param>
        /// <param name="pAuthenticationType"></param>
        /// <param name="pDirectoryEntry"></param>
        public FwkIdentity(bool pIsLogin, string pAuthenticationType, System.DirectoryServices.DirectoryEntry pDirectoryEntry)
        {
            _IsAuthenticated = pIsLogin;
            _AuthenticationType = pAuthenticationType;

            if (pDirectoryEntry.Properties.Contains("mail"))
                _Mail = pDirectoryEntry.Properties["mail"][0].ToString();

            if (pDirectoryEntry.Properties.Contains("sAMAccountName"))
                base.Name = pDirectoryEntry.Properties["sAMAccountName"][0].ToString(); //Nombre usuario como aaguirre

            if (pDirectoryEntry.Properties.Contains("userPrincipalName"))
                _UserPrincipalName = pDirectoryEntry.Properties["userPrincipalName"][0].ToString();//Nombre usuario como aaguirre@actionline.com
            if (pDirectoryEntry.Properties.Contains("name"))
                base.FullName = pDirectoryEntry.Properties["name"][0].ToString(); //Nombre completo
            if (pDirectoryEntry.Properties.Contains("sn"))
                _LastName = pDirectoryEntry.Properties["sn"][0].ToString();
            if (pDirectoryEntry.Properties.Contains("givenName"))
                _FirstName = pDirectoryEntry.Properties["givenName"][0].ToString();

            if (pDirectoryEntry.Properties.Contains("sAMAccountType"))
                _FirstName = pDirectoryEntry.Properties["sAMAccountType"][0].ToString();
            if (pDirectoryEntry.Properties.Contains("objectCategory"))
                base.Category = pDirectoryEntry.Properties["objectCategory"][0].ToString();
            if (pDirectoryEntry.Properties.Contains("distinguishedName"))
                _DistinguishedName = pDirectoryEntry.Properties["distinguishedName"][0].ToString();
            if (pDirectoryEntry.Properties.Contains("description"))
                _Description = pDirectoryEntry.Properties["description"][0].ToString();
        }


       

        /// <summary>
        /// Vuelve a cargar los grupos del cual es muiembro desde el dominio
        /// </summary>
        public void  RefreshADGroups()
        {
            //FwkActyveDirectory _FwkActyveDirectory = new FwkActyveDirectory(this.Domain);
            //_ActiveDirectoryGroups = _FwkActyveDirectory.GetGroupForUser(this.Name);
        }
    }

  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using  Fwk.Security;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// Clase que representa un usuario de active directory.- 
    /// 1.       This class has read only properties for fetching First Name, Last Name, City, Login Name etc.
    /// 2.       Constructor of the class is taking one parameter of type DirectoryEntry class.
    /// 3.       In Constructor all the information about ADUser is getting fetched using static class ADProperties.
    /// 4.       There are two static functions inside this class. GetUser and GetProperty
    /// 5.       Get Property is returning a string which holds property of AD User.
    /// 6.       GetUser static function is returning an ADUser. 
    /// </summary>
    public class ADUser
    {
        #region Properties
        private LoginResult _LoginResult;
        /// <summary>
        /// 
        /// </summary>
        public LoginResult LoginResult
        {
            get { return _LoginResult; }
            set { _LoginResult = value; }
        }
        private String _firstName;

        private String _middleName;

        private String _lastName;

        private String _loginName;

        private String _loginNameWithDomain;

        private String _streetAddress;

        private String _city;

        private String _state;

        private String _postalCode;

        private String _country;

        private String _homePhone;

        private String _extension;

        private String _mobile;

        private String _fax;

        private String _emailAddress;

        private String _title;

        private String _company;

        private String _manager;

        private String _managerName;

        private String _department;
        private String _UserAccountControl;

        /// <summary>
        /// Reprecenta la propiedad: userAccountControl Se utiliza para dehabilitar una cuenta.-
        /// Valor 514 dehabilita, mientras 512 mantiene la cuenta lista para logon.-
        /// </summary>
        public String UserAccountControl
        {
            get { return _UserAccountControl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Department
        {
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String FirstName
        {
            get { return _firstName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String MiddleName
        {
            get { return _middleName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String LastName
        {
            get { return _lastName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String LoginName
        {
            get { return _loginName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String LoginNameWithDomain
        {
            get { return _loginNameWithDomain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String StreetAddress
        {
            get { return _streetAddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String City
        {
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String State
        {
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String PostalCode
        {
            get { return _postalCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Country
        {
            get { return _country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String HomePhone
        {
            get { return _homePhone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Extension
        {
            get { return _extension; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Mobile
        {

            get { return _mobile; }

        }
        /// <summary>
        /// 
        /// </summary>
        public String Fax
        {
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String EmailAddress
        {
            get { return _emailAddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Title
        {
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Company
        {
            get { return _company; }
        }


        List<string> _Groups;


        /// <summary>
        /// 
        /// </summary>
        public String ManagerName
        {
            get { return _managerName; }

        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directoryUser"></param>
        public ADUser(DirectoryEntry directoryUser)
        {



            String domainAddress;
            String userPrincipalName = ADWrapper.GetProperty(directoryUser, ADProperties.USERPRINCIPALNAME);
            String domainName;
            _UserAccountControl = ADWrapper.GetProperty(directoryUser, ADProperties.USERACCOUNTCONTROL);
            _firstName = ADWrapper.GetProperty(directoryUser, ADProperties.FIRSTNAME);

            _middleName = ADWrapper.GetProperty(directoryUser, ADProperties.MIDDLENAME);

            _lastName = ADWrapper.GetProperty(directoryUser, ADProperties.LASTNAME);

            _loginName = ADWrapper.GetProperty(directoryUser, ADProperties.LOGINNAME);



            if (!string.IsNullOrEmpty(userPrincipalName))
            {
                domainAddress = userPrincipalName.Split('@')[1];
            }
            else
            {
                domainAddress = String.Empty;
            }

            if (!string.IsNullOrEmpty(domainAddress))
            {

                domainName = domainAddress.Split('.').First();

            }

            else
            {

                domainName = String.Empty;

            }

            _loginNameWithDomain = String.Format(@"{0}\{1}", domainName, _loginName);

            _streetAddress = ADWrapper.GetProperty(directoryUser, ADProperties.STREETADDRESS);

            _city = ADWrapper.GetProperty(directoryUser, ADProperties.CITY);

            _state = ADWrapper.GetProperty(directoryUser, ADProperties.STATE);

            _postalCode = ADWrapper.GetProperty(directoryUser, ADProperties.POSTALCODE);

            _country = ADWrapper.GetProperty(directoryUser, ADProperties.COUNTRY);

            _company = ADWrapper.GetProperty(directoryUser, ADProperties.COMPANY);

            _department = ADWrapper.GetProperty(directoryUser, ADProperties.DEPARTMENT);

            _homePhone = ADWrapper.GetProperty(directoryUser, ADProperties.HOMEPHONE);

            _extension = ADWrapper.GetProperty(directoryUser, ADProperties.EXTENSION);

            _mobile = ADWrapper.GetProperty(directoryUser, ADProperties.MOBILE);

            _fax = ADWrapper.GetProperty(directoryUser, ADProperties.FAX);

            _emailAddress = ADWrapper.GetProperty(directoryUser, ADProperties.EMAILADDRESS);

            _title = ADWrapper.GetProperty(directoryUser, ADProperties.TITLE);

            _manager = ADWrapper.GetProperty(directoryUser, ADProperties.MANAGER);

            if (!String.IsNullOrEmpty(_manager))
            {

                String[] managerArray = _manager.Split(',');

                _managerName = managerArray[0].Replace("CN=", "");

            }

            // NOTA: En este código se confunden las propiedades LockedOut con Disabled... supuestamente se obtiene con la pripiedad
            // LockedOutTime pero no funciona
            //_LockedOut = Convert.ToBoolean(directoryUser.InvokeGet("IsAccountLocked")); 

            //_LoginResult = ADWrapper.User_Get_LoginResult(directoryUser);

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultUserUser"></param>
        public ADUser(SearchResult resultUser)
        {



            String domainAddress;
            String userPrincipalName = ADWrapper.GetProperty(resultUser, ADProperties.USERPRINCIPALNAME);
            String domainName;
            _UserAccountControl = ADWrapper.GetProperty(resultUser, ADProperties.USERACCOUNTCONTROL);
            _firstName = ADWrapper.GetProperty(resultUser, ADProperties.FIRSTNAME);

            _middleName = ADWrapper.GetProperty(resultUser, ADProperties.MIDDLENAME);

            _lastName = ADWrapper.GetProperty(resultUser, ADProperties.LASTNAME);

            _loginName = ADWrapper.GetProperty(resultUser, ADProperties.LOGINNAME);



            if (!string.IsNullOrEmpty(userPrincipalName))
            {
                domainAddress = userPrincipalName.Split('@')[1];
            }
            else
            {
                domainAddress = String.Empty;
            }

            if (!string.IsNullOrEmpty(domainAddress))
            {

                domainName = domainAddress.Split('.').First();

            }

            else
            {

                domainName = String.Empty;

            }

            _loginNameWithDomain = String.Format(@"{0}\{1}", domainName, _loginName);

            _streetAddress = ADWrapper.GetProperty(resultUser, ADProperties.STREETADDRESS);

            _city = ADWrapper.GetProperty(resultUser, ADProperties.CITY);

            _state = ADWrapper.GetProperty(resultUser, ADProperties.STATE);

            _postalCode = ADWrapper.GetProperty(resultUser, ADProperties.POSTALCODE);

            _country = ADWrapper.GetProperty(resultUser, ADProperties.COUNTRY);

            _company = ADWrapper.GetProperty(resultUser, ADProperties.COMPANY);

            _department = ADWrapper.GetProperty(resultUser, ADProperties.DEPARTMENT);

            _homePhone = ADWrapper.GetProperty(resultUser, ADProperties.HOMEPHONE);

            _extension = ADWrapper.GetProperty(resultUser, ADProperties.EXTENSION);

            _mobile = ADWrapper.GetProperty(resultUser, ADProperties.MOBILE);

            _fax = ADWrapper.GetProperty(resultUser, ADProperties.FAX);

            _emailAddress = ADWrapper.GetProperty(resultUser, ADProperties.EMAILADDRESS);

            _title = ADWrapper.GetProperty(resultUser, ADProperties.TITLE);

            _manager = ADWrapper.GetProperty(resultUser, ADProperties.MANAGER);

            if (!String.IsNullOrEmpty(_manager))
            {

                String[] managerArray = _manager.Split(',');

                _managerName = managerArray[0].Replace("CN=", "");

            }

            //_LockedOut = Convert.ToBoolean(resultUser.GetDirectoryEntry().InvokeGet("IsAccountLocked")); 

            //_LoginResult = ADWrapper.User_Get_LoginResult(resultUser);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLdapUser"></param>
        //public ADUser(LdapEntry pLdapUser)
        //{
        //    String domainAddress;
        //    String userPrincipalName = pLdapUser[ADProperties.USERPRINCIPALNAME][0];
        //    String domainName;

        //    _UserAccountControl = pLdapUser[ADProperties.USERACCOUNTCONTROL][0];
        //    _firstName = pLdapUser[ADProperties.FIRSTNAME][0];
        //    if (pLdapUser.ContainsKey(ADProperties.MIDDLENAME))
        //        _middleName = pLdapUser[ADProperties.MIDDLENAME][0];
        //    if (pLdapUser.ContainsKey(ADProperties.LASTNAME))
        //        _lastName = pLdapUser[ADProperties.LASTNAME][0];
        //    if (pLdapUser.ContainsKey(ADProperties.LOGINNAME))
        //        _loginName = pLdapUser[ADProperties.LOGINNAME][0];

        //    if (!string.IsNullOrEmpty(userPrincipalName))
        //    {
        //        domainAddress = userPrincipalName.Split('@')[1];
        //    }
        //    else
        //    {
        //        domainAddress = String.Empty;
        //    }

        //    if (!string.IsNullOrEmpty(domainAddress))
        //    {

        //        domainName = domainAddress.Split('.').First();
        //    }
        //    else
        //    {
        //        domainName = String.Empty;

        //    }
        //    _loginNameWithDomain = String.Format(@"{0}\{1}", domainName, _loginName);

        //    if (pLdapUser.ContainsKey(ADProperties.STREETADDRESS))
        //        _streetAddress = pLdapUser[ADProperties.STREETADDRESS][0];
        //    if (pLdapUser.ContainsKey(ADProperties.CITY))
        //        _city = pLdapUser[ADProperties.CITY][0];
        //    if (pLdapUser.ContainsKey(ADProperties.STATE))
        //        _state = pLdapUser[ADProperties.STATE][0];
        //    if (pLdapUser.ContainsKey(ADProperties.POSTALCODE))
        //        _postalCode = pLdapUser[ADProperties.POSTALCODE][0];
        //    if (pLdapUser.ContainsKey(ADProperties.COUNTRY))
        //        _country = pLdapUser[ADProperties.COUNTRY][0];
        //    if (pLdapUser.ContainsKey(ADProperties.COMPANY))
        //        _company = pLdapUser[ADProperties.COMPANY][0];
        //    if (pLdapUser.ContainsKey(ADProperties.DEPARTMENT))
        //        _department = pLdapUser[ADProperties.DEPARTMENT][0];
        //    if (pLdapUser.ContainsKey(ADProperties.HOMEPHONE))
        //        _homePhone = pLdapUser[ADProperties.HOMEPHONE][0];
        //    if (pLdapUser.ContainsKey(ADProperties.EXTENSION))
        //        _extension = pLdapUser[ADProperties.EXTENSION][0];
        //    if (pLdapUser.ContainsKey(ADProperties.MOBILE))
        //        _mobile = pLdapUser[ADProperties.MOBILE][0];
        //    if (pLdapUser.ContainsKey(ADProperties.FAX))
        //        _fax = pLdapUser[ADProperties.FAX][0];
        //    if (pLdapUser.ContainsKey(ADProperties.EMAILADDRESS))
        //        _emailAddress = pLdapUser[ADProperties.EMAILADDRESS][0];
        //    if (pLdapUser.ContainsKey(ADProperties.TITLE))
        //        _title = pLdapUser[ADProperties.TITLE][0];
        //    if (pLdapUser.ContainsKey(ADProperties.MANAGER))
        //        _manager = pLdapUser[ADProperties.MANAGER][0];

        //    if (!String.IsNullOrEmpty(_manager))
        //    {
        //        String[] managerArray = _manager.Split(',');
        //        _managerName = managerArray[0].Replace("CN=", "");

        //    }

        //    //if (pLdapUser.ContainsKey("lockoutTime"))
        //    //    _LockedOut = Convert.ToInt64(pLdapUser["lockoutTime"][0]) > 0;

        //    //_LoginResult = ADWrapper.User_Get_LoginResult(directoryUser);
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pSource"></param>
        /// <returns></returns>
        public static List<ADUser> FilterByName(String pName, List<ADUser> pSource)
        {
            if (pSource == null) return null;

            return (List<ADUser>)
                pSource.Where<ADUser>(p => (
                    p.LoginName.StartsWith(pName, StringComparison.OrdinalIgnoreCase)
                    || String.IsNullOrEmpty(pName)));

        }
    }

}



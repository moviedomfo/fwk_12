using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;

namespace Fwk.CentralizedSecurity.Contracts
{
    [Serializable]
    public class ActiveDirectoryUser
    {
        #region Properties
    

        /// <summary>
        /// Reprecenta la propiedad: userAccountControl Se utiliza para dehabilitar una cuenta.-
        /// Valor 514 dehabilita, mientras 512 mantiene la cuenta lista para logon.-
        /// </summary>
        public String UserAccountControl
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Department
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String FirstName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String MiddleName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String LastName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String LoginName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String LoginNameWithDomain
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String StreetAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String City
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String State
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String PostalCode
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Country
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String HomePhone
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Extension
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Fax
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String EmailAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Title
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Company
        {
            get;
            set;
        }

        

        #endregion

         /// <summary>
        /// 
        /// </summary>
        public ActiveDirectoryUser()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public ActiveDirectoryUser(ADUser adUser)
        {
            this.City = adUser.City;
            this.Company = adUser.Company;
            this.Country = adUser.Country;
            this.Department = adUser.Department;
            this.EmailAddress = adUser.EmailAddress;
            this.Extension = adUser.Extension;
            this.Fax = adUser.Fax;
            this.FirstName = adUser.FirstName;
            this.HomePhone = adUser.HomePhone;
            this.LastName = adUser.LastName;
            this.LoginName = adUser.LoginName;
            this.LoginNameWithDomain = adUser.LoginName;
            this.MiddleName = adUser.MiddleName;
            this.Mobile = adUser.Mobile;
            this.PostalCode = adUser.PostalCode;
            this.State = adUser.State;
            this.StreetAddress = adUser.StreetAddress;
            this.UserAccountControl = adUser.UserAccountControl;
            this.Title = adUser.Title;



        }
    }
}

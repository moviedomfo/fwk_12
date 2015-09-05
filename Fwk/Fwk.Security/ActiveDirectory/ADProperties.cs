using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// This class will have the properties corresponding to the information of the AD User.  
    /// This is a static class. This class is having all the properties as constant string for ADUser.  
    /// This class is giving readable name to all the properties of user details. 
    /// </summary>
    public static class ADProperties
    {
        /// <summary>
        /// 
        /// </summary>
        public const String OBJECTCLASS = "objectClass";
        /// <summary>
        /// 
        /// </summary>
        public const String CONTAINERNAME = "cn";
        /// <summary>
        /// 
        /// </summary>
        public const String LASTNAME = "sn";
        /// <summary>
        /// 
        /// </summary>
        public const String COUNTRYNOTATION = "c";
        /// <summary>
        /// 
        /// </summary>
        public const String CITY = "l";
        /// <summary>
        /// 
        /// </summary>
        public const String STATE = "st";
        /// <summary>
        /// 
        /// </summary>
        public const String TITLE = "title";
        /// <summary>
        /// 
        /// </summary>
        public const String POSTALCODE = "postalCode";
        /// <summary>
        /// 
        /// </summary>
        public const String PHYSICALDELIVERYOFFICENAME = "physicalDeliveryOfficeName";

        /// <summary>
        /// givenName
        /// </summary>
        public const String FIRSTNAME = "givenName";

        /// <summary>
        /// initials
        /// </summary>
        public const String MIDDLENAME = "initials";

        /// <summary>
        /// DN Es uno de los mas importantes atributos LDAP
        /// CN=Jay Jamieson, OU= Newport,DC=cp,DC=com
        /// CN=GS_CalidadTP_R,OU=Avanzados,OU=Analistas,OU=Seguridad,DC=Datacom,DC=org
        /// </summary>
        public const String DISTINGUISHEDNAME = "distinguishedName";
        /// <summary>
        /// 
        /// </summary>
        public const String INSTANCETYPE = "instanceType";
        /// <summary>
        /// 
        /// </summary>
        public const String WHENCREATED = "whenCreated";
        /// <summary>
        /// 
        /// </summary>
        public const String WHENCHANGED = "whenChanged";
        /// <summary>
        /// 
        /// </summary>
        public const String DISPLAYNAME = "displayName";

        /// <summary>
        /// uSNCreated
        /// </summary>
        public const String USNCREATED = "uSNCreated";
        /// <summary>
        /// 
        /// </summary>
        public const String MEMBEROF = "memberOf";
        /// <summary>
        /// 
        /// </summary>
        public const String USNCHANGED = "uSNChanged";
        /// <summary>
        /// 
        /// </summary>
        public const String COUNTRY = "co";
        /// <summary>
        /// 
        /// </summary>
        public const String DEPARTMENT = "department";
        /// <summary>
        /// 
        /// </summary>
        public const String COMPANY = "company";
        /// <summary>
        /// 
        /// </summary>
        public const String PROXYADDRESSES = "proxyAddresses";
        /// <summary>
        /// 
        /// </summary>
        public const String STREETADDRESS = "streetAddress";
        /// <summary>
        /// 
        /// </summary>
        public const String DIRECTREPORTS = "directReports";

        /// <summary>
        /// Reprecenta la propiedad: name 
        /// Nombre completo
        /// </summary>
        public const String NAME = "name";

        /// <summary>
        /// Reprecenta la propiedad: objectGUID
        /// </summary>
        public const String OBJECTGUID = "objectGUID";

        /// <summary>
        /// Reprecenta la propiedad: userAccountControl Se utiliza para dehabilitar una cuenta.-
        /// Valor 514 dehabilita, mientras 512 mantiene la cuenta lista para logon.-
        /// </summary>
        public const String USERACCOUNTCONTROL = "userAccountControl";

        /// <summary>
        /// Reprecenta la propiedad: badPwdCount
        /// </summary>
        public const String BADPWDCOUNT = "badPwdCount";

        /// <summary>
        /// Reprecenta la propiedad: codePage
        /// </summary>
        public const String CODEPAGE = "codePage";
        /// <summary>
        /// Reprecenta la propiedad: countryCode
        /// </summary>
        public const String COUNTRYCODE = "countryCode";
        /// <summary>
        /// Reprecenta la propiedad: badPasswordTime
        /// </summary>
        public const String BADPASSWORDTIME = "badPasswordTime";
        /// <summary>
        /// Reprecenta la propiedad: lastLogoff
        /// </summary>
        public const String LASTLOGOFF = "lastLogoff";

        /// <summary>
        /// Reprecenta la propiedad: lastLogon
        /// </summary>
        public const String LASTLOGON = "lastLogon";

        /// <summary>
        /// Reprecenta la propiedad: pwdLastSet
        /// </summary>
        public const String PWDLASTSET = "pwdLastSet";

        /// <summary>
        /// Reprecenta la propiedad: primaryGroupID
        /// </summary>
        public const String PRIMARYGROUPID = "primaryGroupID";

        /// <summary>
        /// Reprecenta la propiedad: objectSid
        /// </summary>
        public const String OBJECTSID = "objectSid";

        /// <summary>
        /// Reprecenta la propiedad: adminCount
        /// </summary>
        public const String ADMINCOUNT = "adminCount";

        /// <summary>
        /// Reprecenta la propiedad: accountExpires
        /// </summary>
        public const String ACCOUNTEXPIRES = "accountExpires";

        /// <summary>
        /// Reprecenta la propiedad: logonCount
        /// </summary>
        public const String LOGONCOUNT = "logonCount";

        /// <summary>
        /// Reprecenta la propiedad: sAMAccountName
        /// </summary>
        public const String LOGINNAME = "sAMAccountName";

        /// <summary>
        /// Reprecenta la propiedad: sAMAccountType
        /// </summary>
        public const String SAMACCOUNTTYPE = "sAMAccountType";
        /// <summary>
        /// 
        /// </summary>
        public const String SHOWINADDRESSBOOK = "showInAddressBook";
        /// <summary>
        /// 
        /// </summary>
        public const String LEGACYEXCHANGEDN = "legacyExchangeDN";

        /// <summary>
        ///  Reprecenta la propiedad: userPrincipalName
        ///  Nombre usuario como jhendrix@actionline.com
        /// </summary>
        public const String USERPRINCIPALNAME = "userPrincipalName";
        /// <summary>
        /// 
        /// </summary>
        public const String EXTENSION = "ipPhone";
        /// <summary>
        /// 
        /// </summary>
        public const String SERVICEPRINCIPALNAME = "servicePrincipalName";
        
        /// <summary>
        /// Defines the Active Directory Schema category. For example, objectCategory = Person
        /// Ej: CN=Group,CN=Schema,CN=Configuration,DC=Datacom,DC=org
        /// </summary>
        public const String OBJECTCATEGORY = "objectCategory";
        /// <summary>
        /// 
        /// </summary>
        public const String DSCOREPROPAGATIONDATA = "dSCorePropagationData";
        /// <summary>
        /// 
        /// </summary>
        public const String LASTLOGONTIMESTAMP = "lastLogonTimestamp";
        /// <summary>
        /// 
        /// </summary>
        public const String EMAILADDRESS = "mail";
        /// <summary>
        /// 
        /// </summary>
        public const String MANAGER = "manager";
        /// <summary>
        /// 
        /// </summary>
        public const String MOBILE = "mobile";
        /// <summary>
        /// 
        /// </summary>
        public const String PAGER = "pager";
        /// <summary>
        /// 
        /// </summary>
        public const String FAX = "facsimileTelephoneNumber";
        /// <summary>
        /// 
        /// </summary>
        public const String HOMEPHONE = "homePhone";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHUSERACCOUNTCONTROL = "msExchUserAccountControl";
        /// <summary>
        /// 
        /// </summary>
        public const String MDBUSEDEFAULTS = "mDBUseDefaults";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHMAILBOXSECURITYDESCRIPTOR = "msExchMailboxSecurityDescriptor";
        /// <summary>
        /// 
        /// </summary>
        public const String HOMEMDB = "homeMDB";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHPOLICIESINCLUDED = "msExchPoliciesIncluded";
        /// <summary>
        /// 
        /// </summary>
        public const String HOMEMTA = "homeMTA";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHRECIPIENTTYPEDETAILS = "msExchRecipientTypeDetails";
        /// <summary>
        /// 
        /// </summary>
        public const String MAILNICKNAME = "mailNickname";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHHOMESERVERNAME = "msExchHomeServerName";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHVERSION = "msExchVersion";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHRECIPIENTDISPLAYTYPE = "msExchRecipientDisplayType";
        /// <summary>
        /// 
        /// </summary>
        public const String MSEXCHMAILBOXGUID = "msExchMailboxGuid";
        /// <summary>
        /// 
        /// </summary>
        public const String NTSECURITYDESCRIPTOR = "nTSecurityDescriptor";
        /// <summary>
        /// 
        /// </summary>
        public const String DESCRIPTION = "description";
        /// <summary>
        /// 
        /// </summary>
        public const String LOCKOUTTIME = "lockoutTime";
        /// <summary>
        /// 
        /// </summary>
        public const String ISACCOUNTLOCKED = "IsAccountLocked";

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory
{

    /// <summary>
    /// 
    /// </summary>
    public enum ADAccountOptions
    {
        /// <summary>
        /// 
        /// </summary>
        UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,
        /// <summary>
        /// 
        /// </summary>
        UF_NORMAL_ACCOUNT = 0x0200,
        /// <summary>
        /// Dec = 512 
        /// </summary>
        UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,
        /// <summary>
        /// Dec =2048
        /// </summary>
        UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
        /// <summary>
        /// 
        /// </summary>
        UF_SERVER_TRUST_ACCOUNT = 0x2000,
        /// <summary>
        /// Cuenta de usuario no expiro &h10000 (dec = 65536)
        /// </summary>
        UF_DONT_EXPIRE_PASSWD = 0x10000,
        /// <summary>
        /// 
        /// </summary>
        UF_SCRIPT = 0x0001,
        /// <summary>
        /// ACCOUNTDISABLE: la cuenta de usuario está desactivada. (dec = 2)
        /// </summary>
        UF_ACCOUNTDISABLE = 0x0002,
        /// <summary>
        /// HOMEDIR_REQUIRED: se requiere la carpeta principal. 
        /// </summary>
        UF_HOMEDIR_REQUIRED = 0x0008,
        /// <summary>
        /// 16
        /// </summary>
        UF_LOCKOUT = 0x0010,
        /// <summary>
        /// 
        /// </summary>
        UF_PASSWD_NOTREQD = 0x0020,
        /// <summary>
        /// 
        /// </summary>
        UF_PASSWD_CANT_CHANGE = 0x0040,
        /// <summary>
        /// 16
        /// </summary>
        UF_ACCOUNT_LOCKOUT = 0X0010,
        /// <summary>
        /// 
        /// </summary>
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080,



    }


    /// <summary>
    /// The ADS_USER_FLAG_ENUM enumeration defines the flags used for setting user properties in the directory. These flags correspond to values of the userAccountControl attribute in Active Directory when using the LDAP provider, and the userFlags attribute when using the WinNT system provider.
    /// </summary>
    public enum ADS_USER_FLAG_ENUM
    {
        /// <summary>
        /// The logon script is executed. This flag does not work for the ADSI LDAP provider on either read or write operations. For the ADSI WinNT provider, this flag is read-only data, and it cannot be set for user objects.
        /// </summary>
        ADS_UF_SCRIPT = 1,         // 0x1
        /// <summary>
        /// The user account is disabled.
        /// </summary>
        ADS_UF_ACCOUNTDISABLE =  0x2, //2
        /// <summary>
        /// The home directory is required.
        /// </summary>
        ADS_UF_HOMEDIR_REQUIRED = 8,         // 0x8
        /// <summary>
        /// The account is currently locked out.
        /// </summary>
        ADS_UF_LOCKOUT = 16,        // 0x10
        /// <summary>
        /// No password is required.
        /// </summary>
        ADS_UF_PASSWD_NOTREQD = 32,        // 0x20
        /// <summary>
        /// The user cannot change the password. This flag can be read, but not set directly. 
        /// For more information and a code example that shows how to prevent a user from changing the password, see User Cannot Change Password.
        /// </summary>
        ADS_UF_PASSWD_CANT_CHANGE = 64,        // 0x40
        /// <summary>
        /// The user can send an encrypted password.
        /// </summary>
        ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 128,       // 0x80
        /// <summary>
        /// This is an account for users whose primary account is in another domain. This account provides user access to this domain, but not to any domain that trusts this domain. Also known as a local user account.
        /// </summary>
        ADS_UF_TEMP_DUPLICATE_ACCOUNT = 256,       // 0x100
        /// <summary>
        /// This is a default account type that represents a typical user.
        /// </summary>
        ADS_UF_NORMAL_ACCOUNT = 512,       // 0x200
        /// <summary>
        /// This is a permit to trust account for a system domain that trusts other domains.
        /// </summary>
        ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = 2048,      // 0x800
        /// <summary>
        /// This is a computer account for a Windows 2000 Professional or Windows 2000 Server that is a member of this domain.
        /// </summary>
        ADS_UF_WORKSTATION_TRUST_ACCOUNT = 4096,      // 0x1000
        /// <summary>
        /// This is a computer account for a system backup domain controller that is a member of this domain.
        /// </summary>
        ADS_UF_SERVER_TRUST_ACCOUNT = 8192,      // 0x2000
        /// <summary>
        /// When set, the password will not expire on this account.
        /// </summary>
        ADS_UF_DONT_EXPIRE_PASSWD = 65536,     // 0x10000
        /// <summary>
        /// This is an Majority Node Set (MNS) logon account. With MNS, you can configure a multi-node Windows cluster without using a common shared disk.
        /// </summary>
        ADS_UF_MNS_LOGON_ACCOUNT = 131072,    // 0x20000
        /// <summary>
        /// When set, this flag will force the user to log on using a smart card.
        /// </summary>
        ADS_UF_SMARTCARD_REQUIRED = 262144,    // 0x40000
        /// <summary>
        /// When set, the service account (user or computer account), under which a service runs, is trusted for Kerberos delegation. Any such service can impersonate a client requesting the service.
        /// To enable a service for Kerberos delegation, set this flag on the userAccountControl property of the service account.
        /// </summary>
        ADS_UF_TRUSTED_FOR_DELEGATION = 524288,    // 0x80000
        /// <summary>
        /// When set, the security context of the user will not be delegated to a service even if the service account is set as trusted for Kerberos delegation.
        /// </summary>
        ADS_UF_NOT_DELEGATED = 1048576,   // 0x100000
        /// <summary>
        /// Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.
        ///Active Directory Client Extension:  Not supported.
        /// </summary>
        ADS_UF_USE_DES_KEY_ONLY = 2097152,   // 0x200000
        /// <summary>
        /// This account does not require Kerberos preauthentication for logon.
        /// </summary>
        ADS_UF_DONT_REQUIRE_PREAUTH = 4194304,   // 0x400000
        /// <summary>
        /// The user password has expired. This flag is created by the system using data from the password last set attribute and the domain policy. It is read-only and cannot be set. To manually set a user password as expired, use the NetUserSetInfo function with the USER_INFO_3 (usri3_password_expired member) or USER_INFO_4 (usri4_password_expired member) structure.
        ///Active Directory Client Extension:  Not supported.
        /// </summary>
        ADS_UF_PASSWORD_EXPIRED = 8388608,   // 0x800000
        /// <summary>
        /// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be strictly controlled. This setting enables a service running under the account to assume a client identity and authenticate as that user to other remote servers on the network.
        /// </summary>
        ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 16777216   // 0x1000000
    } 


    /// <summary>
    /// Determina el resultado de loging de usuario
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// Logoing exitoso
        /// </summary>
        LOGIN_OK = 0,

        /// <summary>
        /// Uario no existe
        /// </summary>
        LOGIN_USER_DOESNT_EXIST,

        /// <summary>
        /// Cuenta inactiva
        /// </summary>
        LOGIN_USER_ACCOUNT_INACTIVE,

        /// <summary>
        /// Clave incorrecta
        /// </summary>
        LOGIN_USER_OR_PASSWORD_INCORRECT,

        /// <summary>
        /// Cuenta de usuario bloqueada
        /// </summary>
        LOGIN_USER_ACCOUNT_LOCKOUT,
        /// <summary>
        /// 
        /// </summary>
        ERROR_PASSWORD_MUST_CHANGE = 1907,
        /// <summary>
        /// 
        /// </summary>
        ERROR_PASSWORD_EXPIRED = 1330,

        /// <summary>
        /// Este mensaje de error puede deberse a cualquiera de las siguientes situaciones:
        ///     La configuración de red del cliente es incorrecta. Esto incluye la ausencia de direcciones incorrecta para los servidores DNS localizar y resolver los controladores de dominio o.
        ///     La configuración del cliente Winsock Proxy es incorrecta, impedir la resolución correcta de controladores de dominio disponibles y sus direcciones.
        ///     Conectividad de red entre el cliente y los controladores de dominio descubiertos consultando DNS no está disponible.
        ///     Comunicación a través de la red para el controlador de dominio funciona correctamente, pero devolvió una respuesta no válida al cliente.
        ///     El controlador de dominio utilizado como origen de datos mientras está abierto el complemento ha convertido en no disponible.
        /// </summary>
        ERROR_SERVER_IS_NOT_OPERATIONAL
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LOGON32
    {
        /// <summary>
        /// This parameter causes LogonUser to create a primary token.
        /// Use the standard logon provider for the system. 
        /// This is the recommended value for the dwLogonProvider parameter. 
        /// It provides maximum compatibility with current and future releases of Windows NT.
        /// </summary>
        LOGON32_PROVIDER_DEFAULT = 0,
        /// <summary>
        /// 
        /// </summary>
        LOGON32_LOGON_INTERACTIVE = 2
    }
}

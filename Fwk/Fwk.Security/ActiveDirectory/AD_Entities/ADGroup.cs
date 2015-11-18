using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using  Fwk.Security;


namespace Fwk.Security.ActiveDirectory
{

    /// <summary>
    /// Grupo de Active Directory
    /// </summary>
    public class ADGroup
    {
        #region Properties
        List<String> _OU;
        List<String> _Users;
        string _Name, _FirstName, _Category, _Domain, _DistinguishedName, _Description, _CN;

        /// <summary>
        /// Nombre del domijio al que pertenece el grupo
        /// </summary>
        public string Domain
        {
            get { return _Domain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
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
        public string Description
        {
            get { return _Description; }
        }

        /// <summary>
        /// Ejemplos:
        /// CN=GS_Comite_comunicacion_RW,OU=Seguridad,DC=Datacom,DC=org
        /// CN=GS_CalidadTP_R,OU=Avanzados,OU=Analistas,OU=Seguridad,DC=Datacom,DC=org
        /// </summary>
        public string DistinguishedName
        {
            get { return _DistinguishedName; }
        }

        /// <summary>
        /// Defines the Active Directory Schema category. For example, objectCategory = Person
        /// Ej: CN=Group,CN=Schema,CN=Configuration,DC=Datacom,DC=org
        /// </summary>
        public string Category
        {
            get { return _Category; }
        }

        /// <summary>
        ///Common Name
        /// </summary>
        public string CN
        {
            get { return _CN; }
        }


        /// <summary>
        /// Reprecenta la lista de unidades organizacionales del dominio
        /// OU = Organizational Unit 
        /// </summary>
        public List<String> OU
        {
            get { return _OU; }
            set { _OU = value; }
        }

        /// <summary>
        /// Lista de usuarios del grupo
        /// </summary>
        public List<String> Users
        {
            get { return _Users; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ADGroup()
        { }


        //public ADGroup(LdapEntry wLdapEntry)
        //{
        //    if (wLdapEntry.ContainsKey(ADProperties.NAME))
        //        _Name = wLdapEntry[ADProperties.NAME][0];

        //    if (wLdapEntry.ContainsKey(ADProperties.DISTINGUISHEDNAME))
        //        _Name = wLdapEntry[ADProperties.DISTINGUISHEDNAME][0];

        //    if (wLdapEntry.ContainsKey(ADProperties.DESCRIPTION))
        //        _Name = wLdapEntry[ADProperties.DESCRIPTION][0];

        //    if (wLdapEntry.ContainsKey(ADProperties.LOGINNAME))
        //        _Name = wLdapEntry[ADProperties.LOGINNAME][0];

        //    if (wLdapEntry.ContainsKey(ADProperties.OBJECTCATEGORY))
        //        _Name = wLdapEntry[ADProperties.OBJECTCATEGORY][0];

        //    if (wLdapEntry.ContainsKey(ADProperties.USERPRINCIPALNAME))
        //        _Domain = wLdapEntry[ADProperties.USERPRINCIPALNAME][0].Split('.').First();

        //    if (!String.IsNullOrEmpty(_DistinguishedName))
        //    {
        //        SetNameInfo(_DistinguishedName);
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryGroup"></param>
        public ADGroup(DirectoryEntry directoryGroup)
        {

            String domainAddress;
          
            String userPrincipalName = ADWrapper.GetProperty(directoryGroup, ADProperties.USERPRINCIPALNAME);

       
            _Name = ADWrapper.GetProperty(directoryGroup, ADProperties.NAME);

            _DistinguishedName = ADWrapper.GetProperty(directoryGroup, ADProperties.DISTINGUISHEDNAME);

            _Description = ADWrapper.GetProperty(directoryGroup, ADProperties.DESCRIPTION);

            _FirstName = ADWrapper.GetProperty(directoryGroup, ADProperties.LOGINNAME);
            _Category = ADWrapper.GetProperty(directoryGroup, ADProperties.OBJECTCATEGORY);
            _CN = ADWrapper.GetProperty(directoryGroup, ADProperties.CONTAINERNAME);
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

                _Domain = domainAddress.Split('.').First();

            }

            //if (pDirectoryEntry.Properties.Contains("sAMAccountName"))
            //{
            //    base.Name = pDirectoryEntry.Properties["sAMAccountName"][0].ToString(); //Nombre usuario como aaguirre
            //    _CN = base.Name;
            //}
            //if (pDirectoryEntry.Properties.Contains("userPrincipalName"))
            //    _UserPrincipalName = pDirectoryEntry.Properties["userPrincipalName"][0].ToString();//Nombre usuario como aaguirre@actionline.com
            //if (pDirectoryEntry.Properties.Contains("name"))
            //    base.FullName = pDirectoryEntry.Properties["name"][0].ToString(); //Nombre completo

            //if (pDirectoryEntry.Properties.Contains("sAMAccountType"))
            //    _FirstName = pDirectoryEntry.Properties["sAMAccountType"][0].ToString();
            //if (pDirectoryEntry.Properties.Contains("objectCategory"))
            //    base.Category = pDirectoryEntry.Properties["objectCategory"][0].ToString();

            //ej:CN=GS_Comite_comunicacion_RW,OU=Seguridad,DC=Datacom,DC=org
            if (!String.IsNullOrEmpty(_DistinguishedName))
            {
                SetNameInfo(_DistinguishedName);
            }
        
        }

        void SetNameInfo(string pNameInfo)
        {
            int i = 0;
            string[] propAux;
            _OU = new List<String>();
            foreach (string prop in pNameInfo.Split(','))
            {
                propAux = prop.Split('=');
                //if (propAux[0].CompareTo("CN") == 0)
                //{
                //    //base.Name = propAux[1];
                //    _CN = propAux[1];

                //}
                if (propAux[0].CompareTo("OU") == 0)
                {
                    _OU.Add(propAux[1]);
                    i++;
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pSource"></param>
        /// <returns></returns>
        public static List<ADGroup> FilterByName(String pName, List<ADGroup> pSource)
        {
            if (pSource == null) return null;
            
            IEnumerable<ADGroup> list = from s in pSource
                                  where
                                      (s.Name.StartsWith(pName, StringComparison.OrdinalIgnoreCase) || String.IsNullOrEmpty(pName))

                                  select s;

            return list.ToList<ADGroup>();

        }

    }
}

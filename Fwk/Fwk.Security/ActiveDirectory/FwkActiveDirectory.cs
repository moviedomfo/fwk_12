//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using System.Security.Principal;

//using System.Windows.Forms;
//using System.Web.Security;
//using Fwk.Security.Common;
//using System.DirectoryServices;
//using System.Collections;
//using Fwk.Security.ActiveDirectory;



//namespace Fwk.Security.Common
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [Obsolete("Esta clase no se utiliza ")]
//    class FwkActyveDirectory
//    {
//        private string[] _Properties = new string[] { "fullname" };
//        String _Domain;
//        DirectorySearcher _Searcher = null;

//        [Obsolete("Esta clase no se utiliza ")]
//        public FwkActyveDirectory(String pDomain)
//        {
//            _Domain = pDomain;
//            DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + _Domain, null, null, AuthenticationTypes.Secure);

//            //DirectoryEntry adRoot = new DirectoryEntry( "LDAP://CORRSF71NT13.Datacom.org/DC=Datacom,DC=org", Environment.UserName, "Lincelin4", AuthenticationTypes.Secure);

//            _Searcher = new DirectorySearcher(adRoot);
//            //_Searcher.SearchScope = SearchScope.Subtree;

//            //TODO: Completar el tema del PageSize
//            _Searcher.PageSize = 12;
//            _Searcher.ReferralChasing = ReferralChasingOption.All;
//            _Searcher.PropertiesToLoad.AddRange(_Properties);
//        }


//        #region [Group]
//        /// <summary>
//        /// Obtiene un FwkIdentity que reprecenta un grupo 
//        /// </summary>
//        /// <param name="pName"></param>
//        /// <returns></returns>
//        public ADGroup GetGroup(String pName)
//        {
//            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "group", pName);


//            _Searcher.Filter = filter;
//            SearchResult result = _Searcher.FindOne();
//            if (result == null) return null;
//            DirectoryEntry directoryEntry = result.GetDirectoryEntry();

//            ADGroup wADGroup = new ADGroup(directoryEntry);

//            return wADGroup;
           
//        }

//        /// <summary>
//        /// Obtiene todo los grupos pertenecientes al dominio.-
//        /// </summary>
//        public List<ADGroup> GetAllGroups()
//        {
//            List<ADGroup> pList = null;
//            ExecutepQuery("(&(objectClass=group))", "sAMAccountName", out pList);
//            return pList;
//        }

//        /// <summary>
//        /// Obtiene todo los usuarios pertenecientes al dominio.-
//        /// Busca por cn nombre@mail retorna el sAMAccountName ejemplo: moviedo
//        /// </summary>
//        public void GetUsersForGroup(String pGroupName, out List<FwkIdentity> pDomainUserList, out List<ADGroup> pDomainGrouplist)
//        {

//            pDomainUserList = new List<FwkIdentity>();
//            pDomainGrouplist = new List<ADGroup>();
//            string filter = string.Format("(&(ObjectClass=group)(sAMAccountName={0}))", pGroupName);

//            _Searcher.Filter = filter;
//            _Searcher.PropertiesToLoad.Add("member");
//            SearchResult result = _Searcher.FindOne();




//            if (result != null)
//            {
//                FwkIdentity wFwkIdentity;
//                ADGroup wADGroup;
//                DirectoryEntry directoryEntryGroup = result.GetDirectoryEntry();


//                //CN=BD03_AgenteSQLServer,OU=Desarrollo,OU=Sistemas,DC=Datacom,DC=org"
//                foreach (string strMember in directoryEntryGroup.Properties["member"])
//                {

//                    //Get index of equals and comma
//                    int intEqualsIndex = strMember.IndexOf("=", 1);
//                    int intCommaIndex = strMember.IndexOf(",", 1);

//                    string wName = strMember.Substring((intEqualsIndex + 1), (intCommaIndex - intEqualsIndex) - 1);



//                    wFwkIdentity = GetUserByUserName(wName);
//                    if (wFwkIdentity != null)
//                        pDomainUserList.Add(wFwkIdentity);

//                    wADGroup = GetGroup(wName);
//                    if (wADGroup != null)
//                        pDomainGrouplist.Add(wADGroup);

//                    //intentar buscar usuario por nombre completo
//                    if (wFwkIdentity == null)
//                    {
//                        wFwkIdentity = GetUserByFullName(wName);
//                        if (wFwkIdentity != null)
//                            pDomainUserList.Add(wFwkIdentity);
//                    }
//                }

//            }

//        }
//        /// <summary>
//        /// Lista simple de grupos de usuario
//        /// </summary>
//        /// <param name="groupName"></param>
//        /// <returns></returns>
//        List<string> GetADGroupUsers(string groupName)
//        {
//            SearchResult result;
//            DirectorySearcher search = new DirectorySearcher();
//            search.Filter = String.Format("(cn={0})", groupName);
//            search.PropertiesToLoad.Add("member");
//            result = search.FindOne();

//            List<string> userNames = new List<string>();
//            if (result != null)
//            {
//                foreach (string strMember in result.Properties["member"])
//                {
//                    userNames.Add(strMember);
//                }
//                //for (int counter = 0; counter <
//                //         result.Properties["member"].Count; counter++)
//                //{
//                //    string user = (string)result.Properties["member"][counter];
//                //    userNames.Add(user);
//                //}

//            }
//            return userNames;
//        }
//        #endregion

//        #region [User]
//        public bool ValidateUser(string username, string pwd)
//        {
//            string domainAndUsername = _Domain + @"\" + username;
//            DirectoryEntry entry = new DirectoryEntry("LDAP://", domainAndUsername, pwd);

//            try
//            {
//                //Bind to the native AdsObject to force authentication.
//                object obj = entry.NativeObject;

//                DirectorySearcher search = new DirectorySearcher(entry);

//                search.Filter = "(SAMAccountName=" + username + ")";
//                search.PropertiesToLoad.Add("cn");
//                SearchResult result = search.FindOne();

//                if (null == result)
//                {
//                    return false;
//                }

//                //Update the new path to the user in the directory.
//                //_path = result.Path;
//                //_filterAttribute = (string)result.Properties["cn"][0];
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error authenticating user. " + ex.Message);
//            }

//            return true;
//        }
//        /// <summary>
//        /// Obtiene todo los usuarios pertenecientes al dominio.-
//        /// objectClass = person
//        /// </summary>
//        public List<FwkIdentity> Getpelsofters()
//        {
//            List<FwkIdentity> userList = null;
//            ExecutepQuery("(&(objectClass=person))", "sAMAccountName", out userList);
//            return userList;
//        }

//        /// <summary>
//        /// Obtiene todo los usuarios pertenecientes al dominio.-
//        /// Busca por cn nombre@mail retorna el sAMAccountName ejemplo: moviedo
//        /// </summary>
//        public List<ObjectDomain> GetUsersByName(String pName)
//        {

//            // _Searcher.Filter = "(&(objectClass=group)(&(ou:dn:=Chicago)(!(ou:dn:=Wrigleyville))))";

//            //_Searcher.Filter = String.Format("(&(objectClass=user) | (cn={0}*))", pName);//(cn=andy*)(cn=steve*)(cn=margaret*))";
//            //_Searcher.Filter = String.Format("(&(objectClass=user)(userPrincipalName={0}*))", pName);
//            List<ObjectDomain> userList = null;
//            ExecutepQuery(String.Format("(&(objectClass=user)(cn={0}*))", pName), "sAMAccountName", out userList);

//            return userList;

//        }

//        /// <summary>
//        /// Obtiene todo los usuarios pertenecientes al dominio.-
//        /// Busca por cn nombre@mail retorna el sAMAccountName ejemplo: moviedo
//        /// </summary>
//        public List<ADGroup> GetGroupForUser(String userName)
//        {
//            List<ADGroup> list = new List<ADGroup>();

//            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", userName);

//            _Searcher.Filter = filter;
//            SearchResult result = _Searcher.FindOne();
//            DirectoryEntry directoryEntryUser = result.GetDirectoryEntry();

//            //////foreach (string grouInfo in directoryEntryUser.Properties["memberOf"])
//            //////{
//            //////    list.Add(new ADGroup(grouInfo));
//            //////}

//            return list;
//        }

//        /// <summary>
//        ///  Obtiene un FwkIdentity que reprecenta un usuario 
//        /// </summary>
//        /// <param name="userName"></param>
//        /// <returns></returns>
//        public FwkIdentity GetUserByUserName(String userName)
//        {
//            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", userName);


//            _Searcher.Filter = filter;
//            SearchResult result = _Searcher.FindOne();
//            if (result == null) return null;
//            DirectoryEntry directoryEntry = result.GetDirectoryEntry();

//            Fwk.Security.Common.FwkIdentity wFwkIdentity = new FwkIdentity(false, String.Empty, directoryEntry);
//            wFwkIdentity.Domain = _Domain;
//            return wFwkIdentity;

//        }
//        /// <summary>
//        ///  Obtiene un FwkIdentity que reprecenta un usuario 
//        /// </summary>
//        /// <param name="userName"></param>
//        /// <returns></returns>
//        public FwkIdentity GetUserByFullName(String pFullName)
//        {
//            string filter = string.Format("(&(ObjectClass={0})(name={1}))", "person", pFullName);

//            _Searcher.Filter = filter;
//            SearchResult result = _Searcher.FindOne();
//            if (result == null) return null;
//            DirectoryEntry directoryEntry = result.GetDirectoryEntry();

//            Fwk.Security.Common.FwkIdentity wFwkIdentity = new FwkIdentity(false, String.Empty, directoryEntry);
//            wFwkIdentity.Domain = _Domain;
//            return wFwkIdentity;

//        }

//        #endregion


//        /// <summary>
//        /// Ejecuta una consulta LDAP
//        /// </summary>
//        /// <param name="pQuery">Consulta</param>
//        /// <param name="pSortPropertyName">Columna de ordenamiento ascendente</param>
//        /// <returns></returns>
//        void ExecutepQuery(String pQuery, string pSortPropertyName, out List<ObjectDomain> pObjectDomainList)
//        {
//            pObjectDomainList = new List<ObjectDomain>();
//            DirectoryEntry wDirectoryEntry = null;

//            _Searcher.Filter = pQuery;

//            //_Searcher.Sort.Direction = System.DirectoryServices.SortDirection.Ascending;
//            //_Searcher.Sort.PropertyName = pSortPropertyName;

//            foreach (SearchResult result in _Searcher.FindAll())
//            {
//                wDirectoryEntry = result.GetDirectoryEntry();

//                //GetProperties(wDirectoryEntry, "pQuery");
//                if (wDirectoryEntry.Properties.Contains("sAMAccountName"))
//                    pObjectDomainList.Add(new ObjectDomain(wDirectoryEntry.Properties["sAMAccountName"].Value.ToString()));


//            }

//        }
//        /// <summary>
//        /// Ejecuta una consulta LDAP
//        /// </summary>
//        /// <param name="pQuery">Consulta</param>
//        /// <param name="pSortPropertyName">Columna de ordenamiento ascendente</param>
//        /// <returns></returns>
//        void ExecutepQuery(String pQuery, string pSortPropertyName, out List<FwkIdentity> pFwkIdentityList)
//        {
//            pFwkIdentityList = new List<FwkIdentity>();
//            DirectoryEntry wDirectoryEntry = null;

//            _Searcher.Filter = pQuery;

//            //_Searcher.Sort.Direction = System.DirectoryServices.SortDirection.Ascending;
//            //_Searcher.Sort.PropertyName = pSortPropertyName;
//            FwkIdentity wFwkIdentity = null;
//            foreach (SearchResult result in _Searcher.FindAll())
//            {
//                wDirectoryEntry = result.GetDirectoryEntry();
//                wFwkIdentity = new FwkIdentity(false, String.Empty, wDirectoryEntry);
//                pFwkIdentityList.Add(wFwkIdentity);
//                //GetProperties(wDirectoryEntry, "pQuery");
//            }

//        }
//        void ExecutepQuery(String pQuery, string pSortPropertyName, out List<ADGroup> pADGroup)
//        {
//            ADGroup group = null;
//            pADGroup = new List<ADGroup>();
//            DirectoryEntry wDirectoryEntry = null;

//            _Searcher.Filter = pQuery;

//            _Searcher.Sort.Direction = System.DirectoryServices.SortDirection.Ascending;
//            _Searcher.Sort.PropertyName = pSortPropertyName;

//            foreach (SearchResult result in _Searcher.FindAll())
//            {
//                wDirectoryEntry = result.GetDirectoryEntry();

//                //GetProperties(wDirectoryEntry, "pQuery");
//                if (wDirectoryEntry.Properties.Contains("sAMAccountName"))
//                {
//                    group = new ADGroup(wDirectoryEntry);
//                    //group.Domain = _Domain;
//                    pADGroup.Add(group);
//                }


//            }


//        }
  
//        /// <summary>
//        ///  Solo sirve a los fines de ver las propiedades
//        /// </summary>
//        /// <param name="directoryEntry"></param>
//        /// <param name="pQuery"></param>
//        private void GetProperties(DirectoryEntry directoryEntry, String pQuery)
//        {
//            StringBuilder slist = new StringBuilder("Query = " + pQuery);
//            slist.AppendLine();
//            foreach (string s in directoryEntry.Properties.PropertyNames.Cast<string>())
//            {
//                slist.AppendLine(String.Concat(new String[] { s, " = ", directoryEntry.Properties[s].Value.ToString() }));
//            }

//        }

//    }





//}

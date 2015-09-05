using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases.FrontEnd;
using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.Windows.Forms;
using System.Web.Security;
using Fwk.Bases.FrontEnd.Controls;

namespace Fwk.Security.Test
{
    class Helper
    {

        public void m1()
        {
            try
            {

                //ICacheManager cc = CacheFactory.GetCacheManager("XCache2");

                //Authenticate the user and initialize the security cache
                //ISecurityCacheProvider secCache = SecurityCacheFactory.GetSecurityCacheProvider("ProveedorAlmacenCaching");
                // Cache the identity. The SecurityCache will generate and return a token.
                //IToken token = secCache.SaveIdentity(new GenericIdentity(Environment.UserName));
                //IToken token = secCache.SaveIdentity(new GenericIdentity("xxxx"));


                //// Retrieves the identity previoussecCachely saved by using the corresponding token.
                //IIdentity savedIdentity = secCache.GetIdentity(token);




            }
            catch (Exception ex)
            {
                FwkMessageView.Show(ex, "m1()", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
            }

        }

        public static void CreateUser(string userName, string password)
        {
            try
            {
                //String app_name = Membership.Provider.ApplicationName;
                //MembershipUser wMembershipUser = Membership.GetUser(userName);

                Membership.CreateUser(userName, password);


            }
            catch (Exception ex)
            {
                FwkMessageView.Show(ex, "CreateUser", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
            }
        }

        public static List<UserByApp> GetAllUsers()
        {
            UserByApp wUserByApp;
            List<UserByApp> wUsersList = new List<UserByApp>();
            try
            {

                foreach (MembershipUser wMembershipUser in Membership.GetAllUsers())
                {
                    wUserByApp = new UserByApp(wMembershipUser);
                    wUsersList.Add(wUserByApp);
                }
             
            }
            catch (Exception ex)
            {
                FwkMessageView.Show(ex, "MembershipUserCollection", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
            }

            return wUsersList;

        }

    }


    public class UserByApp
    {
        String _UserName;

        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        String _AppName;

        public String AppName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }
        public UserByApp(MembershipUser pMembershipUser)
        {
            _UserName = pMembershipUser.UserName;

        }
    }

    sealed class WaitCursorHelper : IDisposable
    {
        private Control owner;
        private Cursor previousCursor;

        public WaitCursorHelper(Control owner)
        {
            this.owner = owner;
            this.previousCursor = this.owner.Cursor;
            this.owner.Cursor = Cursors.WaitCursor;
        }

        void IDisposable.Dispose()
        {
            this.owner.Cursor = this.previousCursor;
        }
    }

}
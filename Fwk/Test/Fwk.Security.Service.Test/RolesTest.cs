using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security.ISVC;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.SVC;
using Fwk.Bases.Test;
using Fwk.Transaction;
using Fwk.Security.ISVC.AssignRolesToUser;
using Fwk.Security.ISVC.CreateRole;
using Fwk.Security.ISVC.DeleteRole;
using Fwk.Security.Common;
using Fwk.Security.ISVC.SearchAllRoles;
using Fwk.Security.ISVC.SearchRolesForUser;
using Fwk.Exceptions;


namespace Fwk.Security.Service.Test
{
    /// <summary>
    /// Summary description for Roles
    /// </summary>
    [TestClass]
    public class RolesTest : UnitTestBase
    {
        static string rolName = "Role_1";
        public RolesTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [TestMethod]
        public void Roles_CRUD_No_Service()
        {
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 1, 15));
            base.Tx.InitScope();
            CreateRole_No_Service("Role_1");

            List<User> userList = Fwk.Security.FwkMembership.GetAllUsers(null);
            if (userList.Count > 0)
            {
                AssignRolesToUser_No_Service(userList[0].UserName, "Role_1");
            }
            else
            {
                Assert.Inconclusive("No se encontraron usuarios para testear AssignRolesToUser_No_Service");
            }

            DeleteRoles_No_Service("Role_1");
            //bool updateOK = res.BusinessData.Any<FwkAuthorizationRole>(r => r.Name.Equals("Role_1", StringComparison.OrdinalIgnoreCase)
            //    && r.Expression.Equals("(R:Admin OR R:User)", StringComparison.OrdinalIgnoreCase));

            //Assert.AreEqual<bool>(updateOK, true, "No se actualizo correctamente la regla");

            base.Tx.Abort();
        }

        //[TestMethod]
         void CreateRole_No_Service(string name)
        {
            String strErrorResut = String.Empty;

            CreateRoleService svc = new CreateRoleService();
            CreateRoleReq req = new CreateRoleReq();
            
            req.BusinessData.Rol.RolName = rolName;
            req.SecurityProviderName = SecurityProviderName;

            try
            {
                CreateRoleRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

         void DeleteRoles_No_Service(string name)
        {
            String strErrorResut = String.Empty;

            DeleteRoleService svc = new DeleteRoleService();
            DeleteRoleReq req = new DeleteRoleReq();

            req.BusinessData.RolName = name;

            try
            {
                DeleteRoleRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                if (typeof(TechnicalException) == ex.GetType())
                {
                    Assert.AreEqual<String>("4006", ((TechnicalException)ex).ErrorId, "No se esta validando Rol no vasio");
                }
                else
                {
                    strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                }
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

        //[TestMethod]
         void AssignRolesToUser_No_Service(string user,string rol)
        {

            String strErrorResut = String.Empty;
            
            AssignRolesToUserService svc = new AssignRolesToUserService();
            AssignRolesToUserReq req = new AssignRolesToUserReq();

            req.BusinessData.Username = user;
            req.BusinessData.RolList.Add(new Fwk.Security.Common.Rol (rol));

            try
            {
                AssignRolesToUserRes res = svc.Execute(req);
            

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

        [TestMethod]
         public void SearchAllRoles_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchAllRolesService svc = new SearchAllRolesService();
            SearchAllRolesReq req = new SearchAllRolesReq();


            try
            {
                SearchAllRolesRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

        [TestMethod]
        public void SearchRolesForUser_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchRolesForUserService svc = new SearchRolesForUserService();
            SearchRolesForUserReq req = new SearchRolesForUserReq();

            List<User> userList = Fwk.Security.FwkMembership.GetAllUsers(null);
            if (userList.Count > 0)
            {
                req.BusinessData.Username = userList[0].UserName;
                
            }
            else
            {
                Assert.Inconclusive("No se encontraron usuarios para testear SearchRolesForUserService");
            }

            try
            {
                SearchRolesForUserRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }
    }
}

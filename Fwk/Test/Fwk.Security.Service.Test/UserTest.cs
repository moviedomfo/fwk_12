using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security;
using ISVC = Fwk.Security.ISVC;

using Fwk.Caching;
using Fwk.Transaction;
using Fwk.Security.ISVC.AuthenticateUser;
using Fwk.Security.ISVC.CreateUsers;
using Fwk.Bases;
using Fwk.Security.ISVC.SearchAllUsers;
using Fwk.Security.BE;
using Fwk.Security.ISVC.GetUserInfoByParams;
using Fwk.Security.ISVC.UpdateUser;
using Fwk.Security.ISVC.SearchDomainsUrls;
using Fwk.HelperFunctions;
using Fwk.Security.SVC;
using Fwk.Security.Common;
using Fwk.Security.ISVC.RemoveUserFromRole;
using Fwk.ConfigSection;
using System.Configuration;
using Fwk.Security.Service.Test;

namespace ServiceTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UserTest : Fwk.Bases.Test.UnitTestBase
    {
        static User wTestUser = null;
        static User wUnaprovedUser = null;
        
        
        public UserTest()
        {

        
             wTestUser = new User();

            wTestUser.UserName = "riley";
            wTestUser.FirstName = "Riley";
            wTestUser.LastName = "B. King";
            wTestUser.Password = "12345678";
            wTestUser.Email = "Riley.King@rollingstones.com";

            wTestUser.IsApproved = true;

             wUnaprovedUser = new User();

            wUnaprovedUser.UserName = "daved";
            wUnaprovedUser.FirstName = "Daved";
            wUnaprovedUser.LastName = "Matthews";
            wUnaprovedUser.Password = "12345678";
            wUnaprovedUser.Email = "daved.matthews@rollingstones.com";

            wUnaprovedUser.IsApproved = false;
            try
            {
                CreeateUser_No_Service(wTestUser);
                CreeateUser_No_Service(wUnaprovedUser);
            }
            catch { }
            try
            {
                CreeateUser_No_Service(wTestUser);
                
            }
            catch { }
        }
    
   
        [TestMethod]
        public void SearchAllUsers_NoService()
        {
            string strErrorResult = string.Empty;
            SearchAllUsersService svc = new SearchAllUsersService();
            SearchAllUsersReq req = new SearchAllUsersReq();
            
            try
            {
               SearchAllUsersRes res = svc.Execute(req);
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        [TestMethod]
        public void GetUserInfoByParams_NoService()
        {
            string strErrorResult = string.Empty;
            Fwk.Security.SVC.GetUserInfoByParamsService service = new Fwk.Security.SVC.GetUserInfoByParamsService();
            GetUserInfoByParamsReq req = new GetUserInfoByParamsReq();
            req.BusinessData.UserName = wTestUser.UserName;
            try
            {

                GetUserInfoByParamsRes res = service.Execute(req);
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        #region Authentication Test Methods

        [TestMethod()]
        public void AuthenticateUser_NonExistentUser()
        {
            String wErrorResult;
            AuthenticateUserRes res = AuthenticateUser("usuarioquenoexiste", "123345", out wErrorResult);

            Assert.AreEqual<string>(res.Error.ErrorId, "4005", wErrorResult);

        }

        [TestMethod()]
        public void AuthenticateUser_ok()
        {
            String wErrorResult;
            AuthenticateUserRes res = AuthenticateUser(wTestUser.UserName, wTestUser.Password, out wErrorResult);

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, wErrorResult);

        }

        [TestMethod()]
        public void AuthenticateUser_IsApproved_False()
        {
            String wErrorResult;
            AuthenticateUserRes res = AuthenticateUser(wUnaprovedUser.UserName, wUnaprovedUser.Password, out wErrorResult);

            Assert.AreEqual<string>(res.Error.ErrorId, "4009", wErrorResult);

        }



        [TestMethod()]
        public void AuthenticateUser_WrongPassword()
        {
            String wErrorResult;
            AuthenticateUserRes res = AuthenticateUser(wTestUser.UserName, "sarasabtrosca", out wErrorResult);

            Assert.AreEqual<string>(res.Error.ErrorId, "4007", wErrorResult);

        }



        public AuthenticateUserRes AuthenticateUser(string pUserName, string pPassword, out string pErrorResult)
        {
            
            string d = System.Reflection.Assembly.GetExecutingAssembly().Location;
            AuthenticateUserReq req = new AuthenticateUserReq();
            req.BusinessData.AuthenticationMode = AuthenticationModeEnum.ASPNETMemberShips;
            req.BusinessData.UserName = pUserName;
            req.BusinessData.Password = pPassword;
            AuthenticateUserRes res = base.ClientServiceBase.ExecuteService<AuthenticateUserReq, AuthenticateUserRes>(req);

            if (res.Error != null)
                pErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            else
                pErrorResult = String.Empty;

            return res;
           
        }

        #endregion

       

        [TestMethod()]
        public void User_CRUD_No_Service()
        {
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 1, 15));
            base.Tx.InitScope();

            string wszRandom = GenerarCadenaAleatoria(6);// Para generar un nombre de manera aleatoria
            User wUserBe = new User();
            wUserBe.UserName = wszRandom;
            wUserBe.FirstName = "Juan";
            wUserBe.LastName = "Guastini";
            wUserBe.Password = "asd";
            wUserBe.Email = "ads@asd.com";

            wUserBe.IsApproved = true;


            CreeateUser_No_Service(wUserBe);


            if (wUserBe.UserId != null)
            {
                User usr = GetByNAme(wUserBe.UserName);
                if (usr == null)
                {
                    Assert.Fail("No se ccreo el usuario exitosamente");
                }


                UpdateUser_NO_Service(usr);

                try
                {
                    //Comprovar si actualizo
                    usr = GetByNAme(wUserBe.UserName);

                    if (!usr.Email.Equals(string.Concat(wUserBe.Email, ".ar")))
                        Assert.Fail("No se actualizo exitosamente: Email");
                    //if (!usr.FirstName.Equals(string.Concat(wUserBe.FirstName, "_updated")))
                    //    Assert.Fail("No se actualizo exitosamente: FirstName");

                    //if (!usr.LastName.Equals(string.Concat(wUserBe.LastName, "_updated")))
                    //    Assert.Fail("No se actualizo exitosamente: LastName ");

                    //if (!usr.ModifiedByUserId.Equals(12))
                    //    Assert.Fail("No se actualizo exitosamente: ModifiedByUserId ");

                }
                catch (Exception ex)
                {
                    base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                }

                RemoveUserFromRole_NO_Service(wUserBe.UserName );
            }
            else
            {
                Assert.Inconclusive("No se puede testear UpdateUserService");
            }

            base.Tx.Abort();
        }

        User GetByNAme(string pUserName)
        {
            GetUserInfoByParamsService service = new GetUserInfoByParamsService();
            GetUserInfoByParamsReq req = new GetUserInfoByParamsReq();
            req.BusinessData.UserName = pUserName;

            GetUserInfoByParamsRes res = null;

            try
            {
                //Comprovar si se creo el usuario
                res = service.Execute(req);
                
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                return null;
            }
          
           return  res.BusinessData.UserInfo;
        }

        void CreeateUser_No_Service(User pUserBe)
        {
            String strErrorResut = String.Empty;
            CreateUserReq req = new CreateUserReq();
            CreateUserRes res = new CreateUserRes();
            CreateUserService svc = new CreateUserService();

            req.SecurityProviderName = SecurityProviderName;
            
            try
            {

                RolList roles = FwkMembership.GetAllRoles(SecurityProviderName);
                  if (roles.Count >= 2)
                  {
                      pUserBe.Roles = new String[2];
                      pUserBe.Roles[0] = roles[0].RolName;
                      pUserBe.Roles[1] = roles[1].RolName;

                      
                  }
                req.BusinessData.User = pUserBe;
                res = svc.Execute(req);
                
            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
            pUserBe.UserId = res.BusinessData.UserId;
      
        }



        void UpdateUser_cpass_NO_Service(User oldUser)
        {
          
            UpdateUserReq req = new UpdateUserReq();
            UpdateUserService svc = new UpdateUserService();
         

            req.BusinessData.ChangePassword = new ChangePassword();
            req.BusinessData.ChangePassword.New = "11111";
            req.BusinessData.ChangePassword.Old = "66666";
            req.BusinessData.UsersBE = oldUser;


            req.BusinessData.PasswordOnly = true;

            try
            {
 
                UpdateUserRes res = svc.Execute(req);
             
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }




            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }
        void UpdateUser_NO_Service(User oldUser)
        {

            UpdateUserReq req = new UpdateUserReq();
            UpdateUserService svc = new UpdateUserService();
    
            req.BusinessData.UsersBE = oldUser;

            req.BusinessData.UsersBE.FirstName = oldUser.FirstName + "_updated";
            req.BusinessData.UsersBE.LastName = oldUser.LastName + "_updated";
            req.BusinessData.UsersBE.ModifiedByUserId = 12;
            req.BusinessData.UsersBE.ModifiedDate = System.DateTime.Now;
            req.BusinessData.UsersBE.Email = oldUser.Email + ".ar";
   

            req.BusinessData.PasswordOnly = false;

            try
            {

                UpdateUserRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }




            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }

        /// <summary>
        /// Elimina el primer rol
        /// </summary>
        /// <param name="user"></param>
        void RemoveUserFromRole_NO_Service(string user)
        {
            RolList roles = FwkMembership.GetAllRoles(SecurityProviderName);
            
            RemoveUserFromRoleReq req = new RemoveUserFromRoleReq();
            RemoveUserFromRoleService svc = new RemoveUserFromRoleService();
            req.BusinessData.UserName = user;
            req.BusinessData.RolName = roles[0].RolName;
            try
            {
                RemoveUserFromRoleRes res = svc.Execute(req);
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }

        [TestMethod]
        public void SearchDomainsUrls_NO_Service()
        {
          

            SearchDomainsUrlsRequest wRequest = new SearchDomainsUrlsRequest();
            wRequest.BusinessData.ConnectionString = "test";
            SearchDomainsUrlsService svc = new SearchDomainsUrlsService();

            try
            {
                SearchDomainsUrlsResponse wResponse = svc.Execute(wRequest);
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }

        public string GenerarCadenaAleatoria(int longitudCadena)
        {
            Random rnd = new Random();
            string wszRandom = string.Empty;
            string[] wCaracteres = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S",
                        "T", "U", "V", "W", "X", "Y", "Z"};
            for (int i = 0; i < longitudCadena; i++)
            {
                wszRandom += wCaracteres[rnd.Next(0, wCaracteres.Length - 1)];
            }
            return wszRandom;

        }
       

    }
}

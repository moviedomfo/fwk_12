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

namespace Fwk.Security.Service.Test
{
    /// <summary>
    /// Summary description for FacadeTest
    /// </summary>
    [TestClass]
    public class FacadeTest : Fwk.Bases.Test.UnitTestBase
    {

        public FacadeTest()
        {
         
        }

       


        

        [TestMethod]
        public void SearchAllUsersService()
        {
            string strErrorResult = string.Empty;

            SearchAllUsersReq req = new SearchAllUsersReq();


            SearchAllUsersRes res = ClientServiceBase.ExecuteService<SearchAllUsersReq, SearchAllUsersRes>(req);
            if (res.Error != null)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            }
            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, strErrorResult);


          
        }

        [TestMethod]
        public void SearchAllUsersService_WithProvider()
        {
            string strErrorResult = string.Empty;

            SearchAllUsersReq req = new SearchAllUsersReq();


            SearchAllUsersRes res = ClientServiceBase.ExecuteService<SearchAllUsersReq, SearchAllUsersRes>("XML_test",req);
            if (res.Error != null)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            }
            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, strErrorResult);



        }
    }
}

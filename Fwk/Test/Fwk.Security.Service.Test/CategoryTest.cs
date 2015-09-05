using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security.ISVC.CreateRulesCategory;

using  Fwk.Security.ISVC.SearchAllRulesCategory;
using Fwk.Security.ISVC;
using Fwk.Security.BE;

using Fwk.Security.ISVC.SearchRulesCategoryByParam;
using Fwk.Security;
using Fwk.Security.SVC;
using Fwk.Bases.Test;
using Fwk.Transaction;
using Fwk.Security.ISVC.UpdateRulesCategory;
using Fwk.Security.ISVC.DeleteRulesCategory;

namespace Security
{
    /// <summary>
    /// Summary description for GroupsTest
    /// </summary>
    [TestClass]
    public class CategoryTest : UnitTestBase
    {
        public CategoryTest()
        {
           
        }

        [TestMethod]
        public void RulesCategory_Test_CRUD_No_Service()
        {
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.Suppres , IsolationLevel.ReadCommitted, new TimeSpan(0, 1, 15));

            base.Tx.InitScope();
            int? id = CreateRulesCategory_No_Service();
            if (id != null)
                UpdateRulesCategory_No_Service(id.Value);
            if (id != null)
                DeleteRulesCategory_No_Service(id.Value);

            base.Tx.Abort();

        }
        [TestMethod]
        public void CreateRulesCategory()
        {
            CreateRulesCategoryReq req = new CreateRulesCategoryReq();
            CreateRulesCategoryRes res = base.ClientServiceBase.ExecuteService<CreateRulesCategoryReq, CreateRulesCategoryRes>(req);

            if (res.Error != null)
            {

            }
        }
        //[TestMethod]
        public int? CreateRulesCategory_No_Service()
        {
           
            String strErrorResut = String.Empty;
            CreateRulesCategoryService svc = new CreateRulesCategoryService();
            CreateRulesCategoryReq req = new CreateRulesCategoryReq();
            CreateRulesCategoryRes res = new Fwk.Security.ISVC.CreateRulesCategory.CreateRulesCategoryRes();

            req.BusinessData.Name = "Categorytest_1";
            req.BusinessData.ParentId = 0;
            req.BusinessData.FwkRulesInCategoryList = new FwkAuthorizationRuleList();
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule ("Rule_1",""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_2", ""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_3", ""));

            req.SecurityProviderName = SecurityProviderName;

            Int32? id = null;
            try
            {
                res = svc.Execute(req);
                id =  res.BusinessData.Id;
                //base.Tx.Abort();
            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
               
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
            return id;
        }

        //[TestMethod]
        public void UpdateRulesCategory_No_Service(int id)
        {
     
        
            String strErrorResut = String.Empty;
            UpdateRulesCategoryService svc = new UpdateRulesCategoryService();
            UpdateRulesCategoryReq req = new UpdateRulesCategoryReq();
            UpdateRulesCategoryRes res = new UpdateRulesCategoryRes();

            req.BusinessData.CategoryId = id;
            req.BusinessData.Name = "CategoryXtest_1";
            req.BusinessData.ParentId = 0;
            req.BusinessData.FwkRulesInCategoryList = new FwkAuthorizationRuleList();
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_1", ""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_3", ""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_4", ""));
            req.SecurityProviderName = SecurityProviderName;

            try
            {
                res = svc.Execute(req);
            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }


        public void DeleteRulesCategory_No_Service(int id)
        {
     
           
            String strErrorResut = String.Empty;
            DeleteRulesCategoryService svc = new DeleteRulesCategoryService();
            DeleteRulesCategoryReq req = new DeleteRulesCategoryReq();
            DeleteRulesCategoryRes res = new DeleteRulesCategoryRes();
            req.SecurityProviderName = SecurityProviderName;
            req.BusinessData.CategoryId = id;
    

            try
            {
                res = svc.Execute(req);
               
            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }

        [TestMethod]
        public void SearchAllRulesCategory_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchAllRulesCategoryReq req = new SearchAllRulesCategoryReq();
            SearchAllRulesCategoryRes res;
            SearchAllRulesCategoryService svc = new SearchAllRulesCategoryService();
            req.SecurityProviderName = SecurityProviderName;

            try
            {
                res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);



        }

        //[TestMethod]
        public void SearchRulesCategoryByParam_No_Service()
        {
            
            String strErrorResut = String.Empty;
            SearchRulesCategoryByParamService svc = new SearchRulesCategoryByParamService();
            SearchRulesCategoryByParamReq req = new SearchRulesCategoryByParamReq();
            SearchRulesCategoryByParamRes res = null;

            req.BusinessData.CategoryId = 1;

 
            try
            {
                res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
        }


        //public void SearchRulesCategoryByParam_No_Service(SearchRulesCategoryByParamReq req )
        //{

        //    String strErrorResut = String.Empty;
        //    SearchAllRulesCategoryService svc = new SearchAllRulesCategoryService();
       
        //    SearchRulesCategoryByParamRes res;

          


        //    try
        //    {
        //        res = svc.Execute(req);

        //    }
        //    catch (Exception ex)
        //    {
        //        strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
        //    }

        //    Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
        //}
    }
}

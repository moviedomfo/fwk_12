using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Bases;
using Fwk.Security.ISVC.SearchAllRules;
using Fwk.Transaction;
using Fwk.Exceptions;
using Fwk.Security.SVC;
using Fwk.Bases.Test;
using Fwk.Security.ISVC.CreateRules;
using Fwk.Security.ISVC.UpdateRules;
using Fwk.Security;






namespace Security
{
    /// <summary>
    /// Summary description for RulesTest
    /// </summary>
    [TestClass]
    public class RulesTest : UnitTestBase
    {


        [TestMethod]
        public void Rules_CRUD_No_Service()
        {
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 1, 15));

            base.Tx.InitScope();
            CreateRule_No_Service();

            SearchAllRulesRes res = SearchAllRules();
            bool updateOK = res.BusinessData.Any<FwkAuthorizationRule>(r => r.Name.Equals("rule_1", StringComparison.OrdinalIgnoreCase));

            UpdateRules_No_Service();

            res = SearchAllRules();
            updateOK = res.BusinessData.Any<FwkAuthorizationRule>(r => r.Name.Equals("rule_1", StringComparison.OrdinalIgnoreCase)
               && r.Expression.Equals("(R:Admin OR R:User)", StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual<bool>(updateOK, true, "No se actualizo correctamente la regla");

            base.Tx.Abort();
        }
        
      
    
        //[TestMethod]
        public void CreateRule_No_Service()
        {
            String strErrorResut = String.Empty;
          
            CreateRuleService svc = new CreateRuleService();
            CreateRuleReq req = new CreateRuleReq();

            req.BusinessData.Name = "rule_1";
            req.BusinessData.Expression = "(R:Admin)";
            req.SecurityProviderName =     SecurityProviderName;
            try
            {
                CreateRuleRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

        public void UpdateRules_No_Service()
        {
            String strErrorResut = String.Empty;

            UpdateRulesService svc = new UpdateRulesService();
            UpdateRulesReq req = new UpdateRulesReq();

            req.BusinessData.FwkAuthorizationRuleList = new Fwk.Security.FwkAuthorizationRuleList();
            req.BusinessData.FwkAuthorizationRuleList.Add(new Fwk.Security.FwkAuthorizationRule("rule_1", "(R:Admin OR R:User)"));
            req.SecurityProviderName = SecurityProviderName;
            try
            {
                UpdateRulesRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }
        [TestMethod]
        public void SearchAllRulesService_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchAllRulesReq req = new SearchAllRulesReq();
            SearchAllRulesRes res = new SearchAllRulesRes();
            SearchAllRulesService svc = new SearchAllRulesService();
            //res.ContextInformation.CompanyId = "pelsoft";
            //req.SecurityProviderName = "tesa";
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


        public SearchAllRulesRes SearchAllRules()
        {
            String strErrorResut = String.Empty;

            SearchAllRulesReq req = new SearchAllRulesReq();
            SearchAllRulesRes res = new SearchAllRulesRes();
            SearchAllRulesService svc = new SearchAllRulesService();
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

            return res;
        }
    }
}

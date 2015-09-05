using Fwk.Params;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Fwk.Params.BE;

namespace Fwk.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ParamsControllerTest and is intended
    ///to contain all ParamsControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParamsControllerTest
    {

        string wrapperProviderName = "local_wrapper"; 
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        


      
        /// <summary>
        ///A test for CreateParam
        ///</summary>
        [TestMethod()]
        public void CreateParamTest()
        {
            
            ParamBE pParam = new ParamBE (); 
            
            pParam.Description = "DESC1";
            pParam.Enabled= true;
            pParam.ParamId = 9002;
            pParam.ParamTypeId = 9000;
            pParam.Name = "parameter 1";
            try
            {
                //ParamsController.CreateParam(wrapperProviderName, pParam);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex,null,ex.Message);
            }
            
        }

        /// <summary>
        ///A test for DeleteParam
        ///</summary>
        [TestMethod()]
        public void DeleteParamTest()
        {
            try
            {
                ParamsController.DeleteParam(wrapperProviderName, 9000, null, "");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex, null, ex.Message);
            }
            
        }
        
        /// <summary>
        ///A test for SearchParams
        ///</summary>
        [TestMethod()]
        public void SearchParamsTest()
        {
            try
            {
                ParamList expected = ParamsController.SearchParams(wrapperProviderName, 9002, "");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex, null, ex.Message);
            }
            
        }
    }
}

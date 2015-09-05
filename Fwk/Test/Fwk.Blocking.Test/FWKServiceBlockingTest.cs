using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Blocking;
using Fwk.Configuration;
using Fwk.Blocking.ISVC;


namespace Test.Blocking
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class FWKServiceBlockingTest
    {

        public FWKServiceBlockingTest()
        {
          //int TTLInfo=0;
          //  try
          //  {
          //      if (ConfigurationManager.GetProperty("BlockingModel", "TestTTL") != null)
          //           TTLInfo = Convert.ToInt32(ConfigurationManager.GetProperty("BlockingModel", "TTLInfo"));
          //  }
          //  catch
          //  {
               
          //  }
        }

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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ClearBlockingMarksService()
        {
            string err = String.Empty;
            try
            {
                /// Llama al método que limpia las marcas para las
                /// cuales se cumplióel TTL.
                //BlockingEngineBase.ClearBlockingMarks();
                Fwk.Blocking.ISVC.ClearBlockingMarksReq req = new Fwk.Blocking.ISVC.ClearBlockingMarksReq();
                ClearBlockingMarksRes res = req.ExecuteService<ClearBlockingMarksReq, ClearBlockingMarksRes>(req);

                if (res.Error != null)
                {
                    err =  res.Error.Message;
                }
            }
            catch (Exception ex)
            {
                err =  Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            Assert.AreEqual(err, String.Empty, err);
        }
       
    }
}

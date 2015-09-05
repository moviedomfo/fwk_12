using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fwk.UnitTest
{
    /// <summary>
    /// Summary description for Logs
    /// </summary>
    [TestClass]
    public class Logs
    {
        public Logs()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void WriteLog_Database()
        {
            String strErrorResut = String.Empty;
            try
            {
                Fwk.Logging.Event s = new Fwk.Logging.Event(Fwk.Logging.EventType.Information, "test", "testing fwk.logging");
                
                Fwk.Logging.StaticLogger.Log(s);
                
                s = new Fwk.Logging.Event( Fwk.Logging.EventType.Error, "test", "testing fwk.logging");
                s.AppId = "unit test ";
     
                Fwk.Logging.StaticLogger.Log( Fwk.Logging.Targets.TargetType.Database,s,null,"test1");
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }
            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
        }
    }
}

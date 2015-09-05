using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Transaction;
using Fwk.Bases;

namespace Fwk.Bases.Test
{
    /// <summary>
    /// Summary description for UnitTestBase
    /// </summary>
    [TestClass]
    public class UnitTestBase
    {
        public const string SecurityProviderName = "sec_test_provider";
        public UnitTestBase()
        {
            _ClientServiceBase = new ClientServiceBase();

        }

        TransactionScopeHandler _Tx;

        protected TransactionScopeHandler Tx
        {
            get { return _Tx; }
            set { _Tx = value; }
        }
        ClientServiceBase _ClientServiceBase = null;

        protected ClientServiceBase ClientServiceBase
        {
            get { return _ClientServiceBase; }
            set { _ClientServiceBase = value; }
        }

        string _StrExceptionMessage = String.Empty;

        protected string StrExceptionMessage
        {
            get { return _StrExceptionMessage; }
            set { _StrExceptionMessage = value; }
        }
        String xmlPath = @"\\Corrsf71bi01\BigBang\test";

        protected String XmlPath
        {
            get { return xmlPath; }
            set { xmlPath = value; }
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

     
    }
}

﻿using CTADotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntegrationTests
{
    
    
    /// <summary>
    ///This is a test class for RouteStatusApiTest and is intended
    ///to contain all RouteStatusApiTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RouteStatusApiTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void test_api_executexml_returns_a_responsexml()
        {
            var api = new RouteStatusApi();
            string response = api.ExecuteXml();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void test_api_execute_returns_a_response()
        {
            var api = new RouteStatusApi();
            RouteStatusResponse response = api.Execute();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void test_api_execute_for_specific_routeid()
        {
            var api = new RouteStatusApi();
            RouteStatusResponse response = api.Execute(routeIds:"Blue");
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.RouteInfoList.Count);
        }
    }
}

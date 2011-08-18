using CTADotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace IntegrationTests
{
    [TestClass]
    public class DetailedAlertsApiTest
    {
        [TestMethod]
        public void test_api_executexml_returns_xml()
        {
            var api = new DetailedAlertsApi();
            var response = api.ExecuteXml();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void test_api_execute_returns_response()
        {
            var api = new DetailedAlertsApi();
            var response = api.Execute();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void test_api_execute_blueline()
        {
            var api = new DetailedAlertsApi();
            var response = api.Execute(routeIds:"Blue");
            Assert.IsNotNull(response);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CTADotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RouteStatusTests
    {
        [TestMethod]
        public void querystring_formatter__with_empty_params__returns_empty_string()
        {
            var sut = new QueryStringFormatter();

            var response = sut.Format(null);

            Assert.IsTrue(response == string.Empty);
        }

        [TestMethod]
        public void querystring_formatter_with_single_param()
        {
            var sut = new QueryStringFormatter();

            var parameters = new List<Tuple<string, string>> ();
            parameters.Add(new Tuple<string, string>("key1", "val1"));

            var response = sut.Format(parameters);
            Assert.AreEqual("?key1=val1", response);
        }

        [TestMethod]
        public void querystring_formatter_with_multiple_params()
        {
            var sut = new QueryStringFormatter();

            var parameters = new List<Tuple<string, string>>();
            parameters.Add(new Tuple<string, string>("key1", "val1"));
            parameters.Add(new Tuple<string, string>("key2", "val2"));

            var response = sut.Format(parameters);
            Assert.AreEqual("?key1=val1&key2=val2", response);
        }

        [TestMethod]
        public void route_response_parser__parses_well_formed_xml()
        {
            string xml =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <CTARoutes>
                        <TimeStamp>20110818 10:53</TimeStamp>
                        <ErrorCode>0</ErrorCode>
                        <ErrorMessage />
                        <RouteInfo>
                            <Route>Red Line</Route>
                            <RouteColorCode>c60c30</RouteColorCode>
                            <RouteTextColor>ffffff</RouteTextColor>
                            <ServiceId>Red</ServiceId>
                            <RouteURL>
                                <![CDATA[http://www.transitchicago.com/riding_cta/systemguide/redline.aspx]]>
                            </RouteURL>
                            <RouteStatus>Normal Service</RouteStatus>
                            <RouteStatusColor>404040</RouteStatusColor>
                        </RouteInfo>
                        <RouteInfo>
                            <Route>Blue Line</Route>
                            <RouteColorCode>00a1de</RouteColorCode>
                            <RouteTextColor>ffffff</RouteTextColor>
                            <ServiceId>Blue</ServiceId>
                            <RouteURL>
                                <![CDATA[http://www.transitchicago.com/riding_cta/systemguide/blueline.aspx]]>
                            </RouteURL>
                            <RouteStatus>Normal Service</RouteStatus>
                            <RouteStatusColor>404040</RouteStatusColor>
                        </RouteInfo>
                     </CTARoutes>";
            var sut = new RouteStatusResponseParser();
            var response = sut.Parse(xml);
            Assert.IsNotNull(response);
            Assert.IsTrue(2 == response.RouteInfoList.Count);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CTADotNet
{
    public class RouteStatusResponseParser
    {
        public RouteStatusResponse Parse(string xml)
        {
            var response = new RouteStatusResponse();
            XDocument doc = XDocument.Parse(xml);
            var root = doc.Element("CTARoutes");
            response.TimeStamp = root.Element("TimeStamp").Value;
            response.ErrorCode = root.Element("ErrorCode").Value;
            response.ErrorMessage = root.Element("ErrorMessage").Value;

            var routes = root.Descendants("RouteInfo");
            foreach(var route in routes)
            {
                var routeInfo = new RouteInfo()
                                    {
                                        Route = route.Element("Route").Value,
                                        RouteColorCode = route.Element("RouteColorCode").Value,
                                        RouteTextColor = route.Element("RouteTextColor").Value,
                                        ServiceId = route.Element("ServiceId").Value,
                                        RouteURL = route.Element("RouteURL").Value,
                                        RouteStatus = route.Element("RouteStatus").Value,
                                        RouteStatusColor = route.Element("RouteStatusColor").Value
                                    };
                response.RouteInfoList.Add(routeInfo);

            }
            return response;
        }
    }
}

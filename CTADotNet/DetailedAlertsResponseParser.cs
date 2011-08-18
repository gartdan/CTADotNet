using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CTADotNet
{
    public class DetailedAlertsResponseParser
    {
        public DetailedAlertsResponse Parse(string xml)
        {
            var response = new DetailedAlertsResponse();
            XDocument doc = XDocument.Parse(xml);
            var root = doc.Element("CTAAlerts");
            response.TimeStamp = root.Element("TimeStamp").Value;
            response.ErrorCode = root.Element("ErrorCode").Value;
            response.ErrorMessage = root.Element("ErrorMessage").Value;

            var alertNodes = root.Elements("Alert");
            foreach(var node in alertNodes)
            {
                var alert = new Alert();
                alert.AlertId = int.Parse(node.Element("AlertId").Value);
                alert.Headline = node.Element("Headline").Value;
                alert.ShortDescription = node.Element("ShortDescription").Value;
                alert.FullDescription = node.Element("FullDescription").Value;
                alert.SeverityScore = int.Parse(node.Element("SeverityScore").Value);
                alert.SeverityColor = node.Element("SeverityColor").Value;
                alert.SeverityCSS = node.Element("SeverityCSS").Value;
                alert.Impact = node.Element("Impact").Value;
                alert.EventStart = node.Element("EventStart").Value;
                alert.EventEnd = node.Element("EventEnd").Value;
                alert.TBD = int.Parse(node.Element("TBD").Value);
                alert.MajorAlert = int.Parse(node.Element("MajorAlert").Value);
                alert.AlertURL = node.Element("AlertURL").Value.RemoveWhitespace();
                var impactedServiceNode = node.Element("ImpactedService");
                var servicesNodes = impactedServiceNode.Elements("Service");
                foreach(var serviceNode in servicesNodes)
                {
                    var service = new ImpactedService()
                                      {
                                          ServiceType = serviceNode.Element("ServiceType").Value,
                                          ServiceTypeDescription = serviceNode.Element("ServiceTypeDescription").Value,
                                          ServiceName = serviceNode.Element("ServiceName").Value,
                                          ServiceBackColor = serviceNode.Element("ServiceBackColor").Value,
                                          ServiceId = serviceNode.Element("ServiceId").Value,
                                          ServiceTextColor = serviceNode.Element("ServiceTextColor").Value,
                                          ServiceURL = serviceNode.Element("ServiceURL").Value.RemoveWhitespace()

                                      };
                    alert.ImpactedServices.Add(service);
                    response.Alerts.Add(alert);
                }
                
            }
            return response;
            
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTADotNet
{
    public class DetailedAlertsResponse
    {
        public string TimeStamp { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        public IList<Alert> Alerts { get; set; }

        public DetailedAlertsResponse()
        {
            Alerts = new List<Alert>();
        }
    }

    public class Alert
    {
        public int AlertId { get; set; }
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int SeverityScore { get; set; }
        public string SeverityColor { get; set; }
        public string SeverityCSS { get; set; }
        public string Impact { get; set; }
        public string EventStart { get; set; }
        public string EventEnd { get; set; }
        public int TBD { get; set; }
        public int MajorAlert { get; set; }
        public string AlertURL { get; set; }

        public IList<ImpactedService> ImpactedServices { get; set; }

        public Alert()
        {
            ImpactedServices = new List<ImpactedService>();
        }
    }

    public class ImpactedService
    {
        public string ServiceType { get; set; }
        public string ServiceTypeDescription { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public string ServiceBackColor { get; set; }
        public string ServiceTextColor { get; set; }
        public string ServiceURL { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTADotNet
{
    public class RouteStatusResponse
    {
        public RouteStatusResponse()
        {
            this.RouteInfoList = new List<RouteInfo>();
        }
        public string TimeStamp { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public IList<RouteInfo> RouteInfoList { get; set; }
    }

    public class RouteInfo
    {
        public string Route { get; set; }
        public string RouteColorCode { get; set; }
        public string RouteTextColor { get; set; }
        public string ServiceId { get; set; }
        public string RouteURL { get; set; }
        public string RouteStatus { get; set; }
        public string RouteStatusColor { get; set; }
    }
}

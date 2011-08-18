using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTADotNet
{
    public class DetailedAlertsApi
    {
        private const string _version = "1.0";
        private const string _baseUrl = "http://www.transitchicago.com/api/"+ _version + "/alerts.aspx";


        public DetailedAlertsResponse Execute(bool? activeOnly = null, bool? accessibility = null, bool? planned = null,
            string routeIds = null, string stationIds = null, DateTime? byStartDate = null, int? recentDays = null)
        {
            var xml = ExecuteXml(activeOnly, accessibility, planned, routeIds, stationIds, byStartDate, recentDays);
            var parser = new DetailedAlertsResponseParser();
            return parser.Parse(xml);
        }

        /// <summary>
        /// Method to invoke the CTA Alerts Api
        /// </summary>
        /// <param name="activeOnly">Default is FALSE. If TRUE, response yields events only where the start time is in the past and the end time is in the future or unknown.</param>
        /// <param name="accessibility">Default is TRUE. If FALSE, response excludes events that affect accessible paths in stations.</param>
        /// <param name="planned">Default is TRUE. If FALSE, response excludes common planned alerts. Otherwise, result does include planned alerts.</param>
        /// <param name="routeIds">If specified (comma delimit multiple values), determines which routes’ statuses to return list, based on unique route IDs. Matches GTFS route IDs.</param>
        /// <param name="stationIds">If specified (comma delimit multiple values), determines which stations to return, based on unique station IDs. Matches GTFS station IDs.</param>
        /// <param name="byStartDate">If specified, yields events with a start date before the one specified (excludes events that don’t begin until on or after the specified point in the future).</param>
        /// <param name="recentDays">If specified, yields events that have started within x number of days before today (excludes events that began further in the past than the specified number of days).</param>
        /// <returns></returns>
        public string ExecuteXml(bool? activeOnly = null, bool? accessibility = null, bool? planned = null, 
            string routeIds = null, string stationIds = null, DateTime? byStartDate = null, int? recentDays = null)
        {
            var parameters = new List<Tuple<string, string>>();
            parameters.AddIfNotNull(activeOnly,
                new Tuple<string, string>("activeonly", activeOnly.GetValueOrDefault().ToString()));
            parameters.AddIfNotNull(accessibility,
                new Tuple<string, string>("accessibility", accessibility.GetValueOrDefault().ToString()));
            parameters.AddIfNotNull(planned,
                new Tuple<string, string>("planned", planned.GetValueOrDefault().ToString()));
            parameters.AddIfNotNull(routeIds, new Tuple<string, string>("routeid", routeIds));
            parameters.AddIfNotNull(stationIds, new Tuple<string, string>("stationid", stationIds));
            parameters.AddIfNotNull(byStartDate,
                new Tuple<string, string>("bystartdate", byStartDate.ToYYYYMMDD()));
            parameters.AddIfNotNull(recentDays, 
                new Tuple<string,string>("recentdays", recentDays.GetValueOrDefault().ToString()));
            var formatter = new QueryStringFormatter();
            string queryString = formatter.Format(parameters);
            string requestUrl = _baseUrl + queryString;
            var requestExecutor = new HttpRequestor();
            string response = requestExecutor.ExecuteGet(requestUrl);
            return response;
        }

    }
}

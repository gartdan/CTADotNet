using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTADotNet
{
    public class RouteStatusApi
    {
        private const string _version = "1.0";
        private const string _baseUrl = "http://www.transitchicago.com/api/" + _version + "/routes.aspx";

        /// <summary>
        /// Method to query the CTA route status api.  All of the parameters are optional
        /// </summary>
        /// <param name="types">Comma-delimited list of desired service types</param>
        /// <param name="routeIds">Single or multiple route ID(s). Comma-delimited</param>
        /// <param name="stationIds">Single or multiple station IDs.  Comma delimited</param>
        /// <returns></returns>
        public RouteStatusResponse Execute(string types = null, string routeIds = null, string stationIds = null)
        {
            var responseXml = ExecuteXml(types, routeIds, stationIds);
            var parser = new RouteStatusResponseParser();
            return parser.Parse(responseXml);
        }

        public string ExecuteXml(string types = null, string routeIds = null, string stationIds = null)
        {
            var parameters = new List<Tuple<string, string>>();
            parameters.AddIfNotNull(types, new Tuple<string, string>("type", types));
            parameters.AddIfNotNull(routeIds, new Tuple<string, string>("routeid", routeIds));
            parameters.AddIfNotNull(stationIds, new Tuple<string, string>("stationid", stationIds));
            var formatter = new QueryStringFormatter();
            string queryString = formatter.Format(parameters);
            string requestUrl = _baseUrl + queryString;
            var requestExecutor = new HttpRequestor();
            string response = requestExecutor.ExecuteGet(requestUrl);
            return response;
        }


        

    }
}

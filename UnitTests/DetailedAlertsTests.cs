using System;

using CTADotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DetailedAlertsTests
    {
        [TestMethod]
        public void test_convert_to_YYYYMMDD()
        {
            DateTime? dt = DateTime.Parse("09/03/2011");
            var str = dt.ToYYYYMMDD();
            Assert.AreEqual("20110903", str);
        }

        [TestMethod]
        public void test_null_datetime_returns_empty_string()
        {
            DateTime? dt = null;
            var str = dt.ToYYYYMMDD();
            Assert.AreEqual(string.Empty, str);
        }

        [TestMethod]
        public void alertsxmlparser_parses_well_formed_responsexml()
        {
            string xml = @"
            <CTAAlerts>
                <TimeStamp>20110818 14:51</TimeStamp>
                <ErrorCode>0</ErrorCode>
                <ErrorMessage/>
                <Alert>
                    <AlertId>6502</AlertId>
                    <Headline>Temporary Reroute</Headline>
                    <ShortDescription>
                    Northbound buses will operate via Harrison, Canal, and Jackson, then resume their normal route on Franklin.
                    </ShortDescription>
                    <FullDescription>
                    <![CDATA[
                    <div><strong>How does this affect my trip?</strong></div>
                     <div>Northbound buses will operate via Harrison, Canal, and Jackson, then resume their normal route on Franklin.</div>
                     <div><strong>&nbsp;</strong></div>
                     <div><strong>Southbound buses are not affected.</strong>&nbsp;</div>
                     <div>&nbsp;</div>
                     <div>Allow extra travel time. <br />
                     <br />
                     <strong><span>Why is service being changed?</span></strong> <br />
                     Buses are rerouted due to the Wacker Drive Reconstruction Project.</div>
                    ]]>
                    </FullDescription>
                    <SeverityScore>36</SeverityScore>
                    <SeverityColor>06c</SeverityColor>
                    <SeverityCSS>planned</SeverityCSS>
                    <Impact>Planned Work w/Reroute</Impact>
                    <EventStart>20100618 00:01</EventStart>
                    <EventEnd>20120531 05:00</EventEnd>
                    <TBD>0</TBD>
                    <MajorAlert>0</MajorAlert>
                    <AlertURL>
                    <![CDATA[
                    http://www.transitchicago.com/travel_information/alert_detail.aspx?AlertId=6502
                    ]]>
                    </AlertURL>
                    <ImpactedService>
                    <Service>
                    <ServiceType>B</ServiceType>
                    <ServiceTypeDescription>Bus Route</ServiceTypeDescription>
                    <ServiceName>Lincoln/Sedgwick</ServiceName>
                    <ServiceId>11</ServiceId>
                    <ServiceBackColor>059</ServiceBackColor>
                    <ServiceTextColor>ffffff</ServiceTextColor>
                    <ServiceURL>
                    <![CDATA[
                    http://www.transitchicago.com/riding_cta/busroute.aspx?RouteId=172
                    ]]>
                    </ServiceURL>
                    </Service>
                    </ImpactedService>
                    <ttim>0</ttim>
                    <GUID>5ddd0dd4-100e-4d3e-af57-3122f81d3a5c</GUID>
                </Alert>
                <Alert>
                    <AlertId>6503</AlertId>
                    <Headline>Temporary Reroute</Headline>
                    <ShortDescription>
                    NB buses via Jackson, Franklin, Lake, Post Place, then normal route. SB buses via Lower Wacker, to Randolph/Upper Wacker, then normal route.
                    </ShortDescription>
                    <FullDescription>
                    <![CDATA[
                    <div><span style=""font-size: small""><strong>How does this affect my trip?</strong></span></div>
                     <div>
                     <p><font size=""2""><strong>Westbound </strong><span style=""font-size: small""><span lang=""EN"" style=""color: black"">buses will operate via Grand, Wabash, Upper Wacker, Clark, Adams, and Clinton, then
                    ]]>
                    <![CDATA[
                    resume their normal route on Jackson. Buses will not operate on Lower Wacker or Lower Michigan. <strong>Eastbound<font size=""3""> </font></strong>buses will operate via Jackson, Franklin, Lake, and Post Place, then resume their normal route on Lower Wacker.</span></span></font></p>
                     <p><span style=""font-size: small""><span lang=""EN"" style=""color: black""><font size=""2"">The bus stops on Lower Michigan at Illinois (northwest corner) and at Kinzie (northwest corner), and at Lower Wacker/Michigan (northwest corner) will be temporarily eliminated.</font></span></span></p>
                     <p><span style=""font-size: small""><span lang=""EN"" style=""color: black""><font size=""2"">New&nbsp;bus stops will be temporarily added at Grand/Lower Michigan (northeast corner),&nbsp;Franklin/Randolph (northwest corner),&nbsp;Wabash/Hubbard (mid-block) and at Wabash/Upper Wacker (southwest corner).</font></span></span></p>
                     <p><span style=""font-size: small""><span lang=""EN"" style=""color: black""><font size=""2"">The bus&nbsp;stop at Upper Wacker/Adams (AM only) will be temporarily relocated from the northwest&nbsp;corner to the&nbsp;northeast corner.</font></span></span></p>
                     <p><span style=""font-size: small""><span lang=""EN"" style=""color: black""><font size=""2"">Allow extra travel time.</font></span></span></p>
                     <p><strong><span style=""font-size: small""><span lang=""EN"" style=""color: black""><span style=""font-size: small""><span lang=""EN"" style=""color: black""><font size=""2"">Why is service being changed? <br />
                     </font></span></span></span></span></strong><span style=""font-size: small""><span lang=""EN"" style=""color: black""><font size=""2"">Buses will be rerouted and bus stops temporarily changed due to the Wacker Drive Reconstruction Project.</font></span></span></p>
                     </div>
                    ]]>
                    </FullDescription>
                    <SeverityScore>36</SeverityScore>
                    <SeverityColor>06c</SeverityColor>
                    <SeverityCSS>planned</SeverityCSS>
                    <Impact>Planned Work w/Reroute</Impact>
                    <EventStart>20100618 00:01</EventStart>
                    <EventEnd>20120531 05:00</EventEnd>
                    <TBD>0</TBD>
                    <MajorAlert>0</MajorAlert>
                    <AlertURL>
                    <![CDATA[
                    http://www.transitchicago.com/travel_information/alert_detail.aspx?AlertId=6503
                    ]]>
                    </AlertURL>
                    <ImpactedService>
                    <Service>
                    <ServiceType>B</ServiceType>
                    <ServiceTypeDescription>Bus Route</ServiceTypeDescription>
                    <ServiceName>Union/Wacker Express</ServiceName>
                    <ServiceId>121</ServiceId>
                    <ServiceBackColor>059</ServiceBackColor>
                    <ServiceTextColor>ffffff</ServiceTextColor>
                    <ServiceURL>
                    <![CDATA[
                    http://www.transitchicago.com/riding_cta/busroute.aspx?RouteId=272
                    ]]>
                    </ServiceURL>
                    </Service>
                    </ImpactedService>
                    <ttim>0</ttim>
                    <GUID>3165502d-68a0-4244-b4d0-ea5b4c10b1b8</GUID>
                </Alert>
            </CTAAlerts>";

            var sut = new DetailedAlertsResponseParser();
            var response = sut.Parse(xml);
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Alerts.Count);
        }
    }
}

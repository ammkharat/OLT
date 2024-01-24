using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Common.Utility
{
    public class DateRangeUtilities
    {

        private static Range<Date> actionitemnewdateRange = new Range<Date>(null,null);

        public static DateTime GetFromDateTimeForLogs(Site site, SiteConfiguration siteConfiguration,
            ITimeService timeService)
        {
            var daysToDisplayShiftLogs = siteConfiguration.DaysToDisplayShiftLogs;
            return GetStartDateTimeFromDaysToDisplay(site, timeService, daysToDisplayShiftLogs);
        }

        public static Date GetFromDateForLogs(Site site, SiteConfiguration siteConfiguration, ITimeService timeService)
        {
            var daysToDisplayShiftLogs = siteConfiguration.DaysToDisplayShiftLogs;
            return GetStartDateFromDaysToDisplay(site, timeService, daysToDisplayShiftLogs);
        }

        public static bool OccurenceIsInWindow(Range<DateTime> occcur, Range<DateTime> window)
        {
            if (occcur.LowerBound.Year == 9999) return false;
            var occurUpperBound =
                new DateTime(occcur.UpperBound.Year == 9999 ? occcur.LowerBound.Year : occcur.UpperBound.Year,
                    occcur.UpperBound.Month, occcur.UpperBound.Day,
                    occcur.UpperBound.Hour, occcur.UpperBound.Minute, occcur.UpperBound.Second);
            if (occcur.UpperBound < occcur.LowerBound) occurUpperBound = occurUpperBound.AddDays(1);
            return !(window.UpperBound < occcur.LowerBound || occurUpperBound < window.LowerBound);
        }

        public static Date GetFromDateForShiftHandovers(Site site, SiteConfiguration siteConfiguration,
            ITimeService timeService)
        {
            var daysToDisplayShiftHandovers = siteConfiguration.DaysToDisplayShiftHandovers;
            return GetStartDateFromDaysToDisplay(site, timeService, daysToDisplayShiftHandovers);
        }

        public static Range<Date> GetDefaultDateRangeForActionItemDefinitions(Site site,
            SiteConfiguration siteConfiguration, ITimeService timeService)
        {
            var startDateTime = GetStartDateTimeFromDaysToDisplay(site, timeService,
                siteConfiguration.DaysToDisplayActionItems);
            return new Range<Date>(new Date(startDateTime), null);   //ayman rollback action item definition date range
        }

        public static Range<Date> GetDefaultDateRangeForPermitRequests(SiteConfiguration siteConfiguration)
        {
            var now = Clock.Now.ToDate();
            var from = now.AddDays(-1*siteConfiguration.DaysToDisplayPermitRequestsBackwards);
            var to = now.AddDays(siteConfiguration.DaysToDisplayPermitRequestsForwards);
            return new Range<Date>(from, to);
        }

        public static Range<Date> GetDefaultDateRangeForWorkPermits(SiteConfiguration siteConfiguration)
        {
            var now = Clock.Now.ToDate();
            var from = now.AddDays(-1*siteConfiguration.DaysToDisplayWorkPermitsBackwards);
            var to = now.AddDays(siteConfiguration.DaysToDisplayWorkPermitsForwards);
            return new Range<Date>(from, to);
        }

        public static Range<Date> GetDefaultDateRangeForActionItems(Site site, SiteConfiguration siteConfiguration,
            ITimeService timeService)
        {
            var daysToDisplayActionItems = siteConfiguration.DaysToDisplayActionItems;

            var currentDateTime = timeService.GetTime(site.TimeZone);
            var startDate = new Date(currentDateTime.SubtractDays(daysToDisplayActionItems));
            //ayman action item to date
            var today = timeService.GetDate(site.TimeZone);
            return new Range<Date>(startDate, today);
        }

        public static Range<Date> GetDefaultDateRangeForFutureActionItems(SiteConfiguration siteConfiguration, DateTime startOfNextShift)
        {
            var startDate = new Date(startOfNextShift);
            return new Range<Date>(startDate, startDate.AddDays(siteConfiguration.DaysToDisplayActionItems));
        }

        public static Range<Date> GetDefaultDateRangeForLabAlerts(SiteConfiguration siteConfiguration)
        {
            var lowerBound = DateTime.Now.AddDays(siteConfiguration.DaysToDisplayLabAlerts*-1).GetNetworkPortable();
            return new Range<Date>(new Date(lowerBound), new Date(Clock.Now));
        }

        public static Range<Date> GetDefaultDateRangeForDeviationAlerts(SiteConfiguration siteConfiguration)
        {
            var lowerBound =
                DateTime.Now.AddDays(siteConfiguration.DaysToDisplayDeviationAlerts*-1).GetNetworkPortable();
            return new Range<Date>(new Date(lowerBound), new Date(Clock.Now));
        }

        private static DateTime GetStartDateTimeFromDaysToDisplay(Site site, ITimeService timeService, int daysToDisplay)
        {
            var today = timeService.GetDate(site.TimeZone);
            var fromDate = today.CreateDateTime(Time.MIDNIGHT);
            fromDate = fromDate.Subtract(daysToDisplay.Days());
            return fromDate;
        }

        private static Date GetStartDateFromDaysToDisplay(Site site, ITimeService timeService, int daysToDisplay)
        {
            var today = timeService.GetDate(site.TimeZone);
            var fromDate = today.SubtractDays(daysToDisplay);
            return fromDate;
        }

        public static Range<Date> GetDefaultDateRangeForDirectives(SiteConfiguration siteConfiguration)
        {
            var now = Clock.DateNow;
            var from = now.AddDays(-1*siteConfiguration.DaysToDisplayDirectivesBackwards);
            var to = siteConfiguration.DaysToDisplayDirectivesForwards == null
                ? null
                : now.AddDays(siteConfiguration.DaysToDisplayDirectivesForwards.Value);
            return new Range<Date>(from, to);
        }



    }
}
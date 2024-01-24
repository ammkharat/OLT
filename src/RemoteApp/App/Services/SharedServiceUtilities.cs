using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    public static class SharedServiceUtilities
    {
        public static DateTime GetFromDateTimeForLogs(Site site, ISiteConfigurationDao siteConfigurationDao, ITimeService timeService)
        {
            SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
            int daysToDisplayShiftLogs = siteConfiguration.DaysToDisplayShiftLogs;

            return GetStartDateTimeFromDaysToDisplay(site, timeService, daysToDisplayShiftLogs);
        }

        public static Date GetFromDateForLogs(Site site, ISiteConfigurationDao siteConfigurationDao, ITimeService timeService)
        {
            SiteConfiguration siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
            int daysToDisplayShiftLogs = siteConfiguration.DaysToDisplayShiftLogs;
            return GetStartDateFromDaysToDisplay(site, timeService, daysToDisplayShiftLogs);
        }

        private static DateTime GetStartDateTimeFromDaysToDisplay(Site site, ITimeService timeService, int daysToDisplay)
        {
            Date today = timeService.GetDate(site.TimeZone);
            DateTime fromDate = today.CreateDateTime(Time.MIDNIGHT);
            fromDate = fromDate.Subtract(daysToDisplay.Days());
            return fromDate;
        }

        private static Date GetStartDateFromDaysToDisplay(Site site, ITimeService timeService, int daysToDisplay)
        {
            Date today = timeService.GetDate(site.TimeZone);
            Date fromDate = today.SubtractDays(daysToDisplay);
            return fromDate;
        }
    }
}
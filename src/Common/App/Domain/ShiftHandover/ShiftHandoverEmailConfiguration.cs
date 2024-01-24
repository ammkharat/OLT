using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverEmailConfiguration : DomainObject, ICacheBySiteId
    {
        public ShiftHandoverEmailConfiguration(ShiftPattern shiftPattern, Time emailSendTime,
            List<EmailAddress> emailAddresses, List<WorkAssignment> workAssignments, Site site)
            : this(null, shiftPattern, emailAddresses, workAssignments, site, CreateSchedule(emailSendTime, site))
        {
        }

        public ShiftHandoverEmailConfiguration(long? id, ShiftPattern shiftPattern, List<EmailAddress> emailAddresses,
            List<WorkAssignment> workAssignments, Site site, RecurringDailySchedule schedule)
        {
            this.id = id;
            ShiftPattern = shiftPattern;
            EmailAddresses = emailAddresses;
            WorkAssignments = workAssignments;
            Site = site;
            Schedule = schedule;
        }

        public ShiftPattern ShiftPattern { get; set; }
        public List<EmailAddress> EmailAddresses { get; set; }
        public List<WorkAssignment> WorkAssignments { get; set; }
        public Site Site { get; private set; }
        public RecurringDailySchedule Schedule { get; private set; }

        public string EmailAddressesAsDelimitedString
        {
            get { return EmailAddress.ConvertToDelimitedString(EmailAddresses); }
        }

        public string WorkAssignmentsAsDelimitedString
        {
            get { return WorkAssignments.AsString(wa => wa.Name); }
        }

        public Time EmailSendTime
        {
            get { return Schedule.StartTime; }
            set
            {
                Schedule.StartTime = value;
                Schedule.EndTime = value;
            }
        }

        [IgnoreToString]
        public long SiteId
        {
            get { return Site.IdValue; }
        }

        public void SetEmailAddresses(string emailAddressList)
        {
            EmailAddresses = EmailAddress.ConvertDelimitedListToEmailAddresses(emailAddressList);
        }

        private static RecurringDailySchedule CreateSchedule(Time emailSendTime, Site site)
        {
            return new RecurringDailySchedule(Clock.DateNow, null, emailSendTime, emailSendTime, 1, site);
        }
    }
}
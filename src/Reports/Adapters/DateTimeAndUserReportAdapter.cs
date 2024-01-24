using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class DateTimeAndUserReportAdapter
    {
        private readonly DateTime dateTime;
        private readonly string parentId;
        private readonly string userName;

        public DateTimeAndUserReportAdapter(DateTime dateTime, string userName)
            : this("-1", dateTime, userName)
        {
        }

        public DateTimeAndUserReportAdapter(string parentId, DateTime dateTime, string userName)
        {
            this.parentId = parentId;
            this.dateTime = dateTime;
            this.userName = userName;
        }

        public string ParentId
        {
            get { return parentId; }
        }

        public string UserName
        {
            get { return userName; }
        }

        public string DateTime
        {
            get { return dateTime.ToLongDateAndTimeString(); }
        }
    }
}
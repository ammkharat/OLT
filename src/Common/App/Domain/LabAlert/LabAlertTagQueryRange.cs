using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    public enum LabAlertTagQueryRangeType
    {
        Daily,
        Weekly,
        MonthlyDayOfWeek,
        MonthlyDayOfMonth
    }

    [Serializable]
    public abstract class LabAlertTagQueryRange
    {
        protected readonly Time fromTime;
        protected readonly Time toTime;

        protected LabAlertTagQueryRange(Time fromTime, Time toTime)
        {
            this.fromTime = fromTime;
            this.toTime = toTime;
        }

        public abstract LabAlertTagQueryRangeType LabAlertTagQueryRangeType { get; }
        public abstract string FromDescription { get; }
        public abstract string ToDescription { get; }

        public Time FromTime
        {
            get { return fromTime; }
        }

        public Time ToTime
        {
            get { return toTime; }
        }

        public virtual string Description
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            var theString = String.Format("{0} : {1}{2}{3} : {4}",
                StringResources.From,
                FromDescription,
                Environment.NewLine,
                StringResources.To,
                ToDescription);

            return theString;
        }
    }
}
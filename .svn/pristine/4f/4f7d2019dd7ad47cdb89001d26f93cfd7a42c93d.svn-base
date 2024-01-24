using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertTagQueryMonthlyDayOfWeekRange : LabAlertTagQueryRange
    {
        private readonly DayOfWeek fromDayOfWeek;
        private readonly WeekOfMonth fromWeekOfMonth;
        private readonly DayOfWeek toDayOfWeek;
        private readonly WeekOfMonth toWeekOfMonth;

        public LabAlertTagQueryMonthlyDayOfWeekRange(
            Time fromTime,
            Time toTime,
            WeekOfMonth fromWeekOfMonth,
            WeekOfMonth toWeekOfMonth,
            DayOfWeek fromDayOfWeek,
            DayOfWeek toDayOfWeek) : base(fromTime, toTime)
        {
            this.fromWeekOfMonth = fromWeekOfMonth;
            this.toWeekOfMonth = toWeekOfMonth;
            this.fromDayOfWeek = fromDayOfWeek;
            this.toDayOfWeek = toDayOfWeek;
        }

        public override LabAlertTagQueryRangeType LabAlertTagQueryRangeType
        {
            get { return LabAlertTagQueryRangeType.MonthlyDayOfWeek; }
        }

        public override string FromDescription
        {
            get
            {
                return String.Format(StringResources.LabAlertTagQueryMonthlyDayOfWeekRangeDescription, fromWeekOfMonth,
                    fromDayOfWeek, fromTime);
            }
        }

        public override string ToDescription
        {
            get
            {
                return String.Format(StringResources.LabAlertTagQueryMonthlyDayOfWeekRangeDescription, toWeekOfMonth,
                    toDayOfWeek, toTime);
            }
        }

        public WeekOfMonth FromWeekOfMonth
        {
            get { return fromWeekOfMonth; }
        }

        public WeekOfMonth ToWeekOfMonth
        {
            get { return toWeekOfMonth; }
        }

        public DayOfWeek FromDayOfWeek
        {
            get { return fromDayOfWeek; }
        }

        public DayOfWeek ToDayOfWeek
        {
            get { return toDayOfWeek; }
        }
    }
}
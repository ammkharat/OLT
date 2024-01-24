using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertTagQueryMonthlyDayOfMonthRange : LabAlertTagQueryRange
    {
        private readonly DayOfMonth fromDayOfMonth;
        private readonly DayOfMonth toDayOfMonth;

        public LabAlertTagQueryMonthlyDayOfMonthRange(
            Time fromTime,
            Time toTime,
            DayOfMonth fromDayOfMonth,
            DayOfMonth toDayOfMonth)
            : base(fromTime, toTime)
        {
            this.fromDayOfMonth = fromDayOfMonth;
            this.toDayOfMonth = toDayOfMonth;
        }

        public override LabAlertTagQueryRangeType LabAlertTagQueryRangeType
        {
            get { return LabAlertTagQueryRangeType.MonthlyDayOfMonth; }
        }

        public override string FromDescription
        {
            get
            {
                return String.Format(StringResources.LabAlertTagQueryMonthlyDayOfMonthRangeDescription,
                    fromDayOfMonth.NthName, fromTime);
            }
        }

        public override string ToDescription
        {
            get
            {
                return String.Format(StringResources.LabAlertTagQueryMonthlyDayOfMonthRangeDescription,
                    toDayOfMonth.NthName, toTime);
            }
        }

        public DayOfMonth FromDayOfMonth
        {
            get { return fromDayOfMonth; }
        }

        public DayOfMonth ToDayOfMonth
        {
            get { return toDayOfMonth; }
        }
    }
}
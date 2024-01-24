using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertTagQueryWeeklyRange : LabAlertTagQueryRange
    {
        private readonly DayOfWeek fromDayOfWeek;
        private readonly DayOfWeek toDayOfWeek;

        public LabAlertTagQueryWeeklyRange(
            Time fromTime,
            Time toTime,
            DayOfWeek fromDayOfWeek,
            DayOfWeek toDayOfWeek)
            : base(fromTime, toTime)
        {
            this.fromDayOfWeek = fromDayOfWeek;
            this.toDayOfWeek = toDayOfWeek;
        }

        public override LabAlertTagQueryRangeType LabAlertTagQueryRangeType
        {
            get { return LabAlertTagQueryRangeType.Weekly; }
        }

        public override string FromDescription
        {
            get
            {
                return String.Format(StringResources.LabAlertTagQueryWeeklyRangeDescription, fromDayOfWeek, fromTime);
            }
        }

        public override string ToDescription
        {
            get { return String.Format(StringResources.LabAlertTagQueryWeeklyRangeDescription, toDayOfWeek, toTime); }
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
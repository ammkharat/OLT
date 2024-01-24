using System;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertTagQueryDailyRange : LabAlertTagQueryRange
    {
        public LabAlertTagQueryDailyRange(
            Time fromTime,
            Time toTime) : base(fromTime, toTime)
        {
        }

        public override LabAlertTagQueryRangeType LabAlertTagQueryRangeType
        {
            get { return LabAlertTagQueryRangeType.Daily; }
        }

        public override string FromDescription
        {
            get { return fromTime.ToString(); }
        }

        public override string ToDescription
        {
            get { return toTime.ToString(); }
        }
    }
}
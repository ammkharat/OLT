using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class DailyShiftTargetAlertGapReasonReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        public DailyShiftTargetAlertGapReasonReportAdapter(ShiftGapReasonReportDTO dto)
        {
            TargetAlertName = dto.TargetAlertName;
            TargetAlertUnit = dto.TargetAlertUnit;
            TargetAlertUnitDescription = dto.TargetAlertUnitDescription;
            TargetAlertFunctionalLocation = dto.TargetAlertFunctionalLocation;
            TargetAlertFunctionalLocationDescription = dto.TargetAlertFunctionalLocationDescription;
            ShiftName = dto.ShiftName;
            ShiftStartDateTime = dto.ShiftStartDate.ToShortDateAndTimeString();

            ResponseBy = dto.ResponseBy;
            ResponseByDateTime = dto.ResponseByDateTime.ToShortDateAndTimeString();
            TargetGapReason = dto.TargetGapReason;
            TargetGapReasonComment = dto.TargetGapReasonComment;
        }

        public string TargetAlertName { get; private set; }

        public string TargetAlertUnit { get; private set; }
        public string TargetAlertUnitDescription { get; private set; }

        public string TargetAlertFunctionalLocation { get; private set; }
        public string TargetAlertFunctionalLocationDescription { get; private set; }

        public string ShiftName { get; private set; }
        public string ShiftStartDateTime { get; private set; }

        public string ResponseBy { get; private set; }
        public string ResponseByDateTime { get; private set; }

        public string TargetGapReason { get; private set; }
        public string TargetGapReasonComment { get; private set; }
    }
}
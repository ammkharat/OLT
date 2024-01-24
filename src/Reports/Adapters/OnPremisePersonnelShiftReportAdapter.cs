using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class OnPremisePersonnelShiftReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly List<OnPremisePersonnelShiftReportDetailsAdapter> onPremiseShiftReportDetailsDetailAdapters =
            new List<OnPremisePersonnelShiftReportDetailsAdapter>();

        public OnPremisePersonnelShiftReportAdapter(OnPremisePersonnelShiftReportDTO onPremiseShiftReportDTO)
        {
            foreach (
                var onPremisePersonnelShiftReportDetailDTO in
                    onPremiseShiftReportDTO.OnPremisePersonnelShiftReportDetailDTOs)
            {
                var end = onPremisePersonnelShiftReportDetailDTO.EndDateTime.AddDays(1);
                var start = onPremisePersonnelShiftReportDetailDTO.StartDateTime.SubtractDays(1);
                var dayShift = onPremiseShiftReportDTO.SiteShifts.OrderBy(pattern => pattern.StartTime).First();
                var nightShift = onPremiseShiftReportDTO.SiteShifts.OrderBy(pattern => pattern.StartTime).Last();
                var dayShiftEndTime = dayShift.EndTime.Subtract(new TimeSpan(0, 0, 1));
                foreach (
                    var shift in
                        EachShift(new DateTime(start.Year,
                            start.Month,
                            start.Day,
                            dayShift.StartTime.Hour,
                            dayShift.StartTime.Minute,
                            dayShift.StartTime.Second),
                            new DateTime(end.Year, end.Month, end.Day, dayShiftEndTime.Hour, dayShiftEndTime.Minute, 59,
                                999),
                            dayShift.ShiftLength.Hours))
                {
                    if (
                        shift.IsRangeOverLapped(new Range<DateTime>(
                            onPremisePersonnelShiftReportDetailDTO.StartDateTime,
                            onPremisePersonnelShiftReportDetailDTO.EndDateTime)))
                    {
                        if (
                            ShouldAddForDayOrNightShift(shift, onPremisePersonnelShiftReportDetailDTO,
                                dayShift.StartTime.Hour, nightShift.StartTime.Hour) &&
                            ShiftIsInTheReportingPeriod(shift, onPremiseShiftReportDTO.ReportingPeriod))
                        {
                            onPremiseShiftReportDetailsDetailAdapters.Add(
                                new OnPremisePersonnelShiftReportDetailsAdapter(shift.LowerBound,
                                    "Shift: " + shift.LowerBound.ToShortDateString() + " - " +
                                    (shift.LowerBound.TimeOfDay > dayShift.StartTime.TimeOfDay ? "N" : "D"),
                                    onPremisePersonnelShiftReportDetailDTO));
                        }
                    }
                }
            }
        }

        public List<OnPremisePersonnelShiftReportDetailsAdapter> OnPremisePersonnelShiftReportDetailsAdapters
        {
            get { return onPremiseShiftReportDetailsDetailAdapters.OrderBy(adapter => adapter.ShiftStart).ToList(); }
        }

        private bool ShiftIsInTheReportingPeriod(Range<DateTime> shift, Range<DateTime> reportingPeriod)
        {
            return shift.IsRangeOverLapped(reportingPeriod);
        }

        private bool ShouldAddForDayOrNightShift(Range<DateTime> shift,
            OnPremisePersonnelShiftReportDetailDTO onPremisePersonnelShiftReportDetailDTO,
            int dayShiftStartHour, int nightShiftStartHour)
        {
            if (onPremisePersonnelShiftReportDetailDTO.IsDayShift && shift.LowerBound.Hour == dayShiftStartHour)
                return true;
            if (onPremisePersonnelShiftReportDetailDTO.IsNightShift && shift.LowerBound.Hour == nightShiftStartHour)
                return true;
            return false;
        }

        private IEnumerable<Range<DateTime>> EachShift(DateTime from, DateTime to, int hoursInShift)
        {
            for (var shiftRange = new Range<DateTime>(from, from.AddHours(hoursInShift));
                shiftRange.LowerBound < to;
                shiftRange = new Range<DateTime>(shiftRange.UpperBound, shiftRange.UpperBound.AddHours(hoursInShift)))
                yield return shiftRange;
        }
    }
}
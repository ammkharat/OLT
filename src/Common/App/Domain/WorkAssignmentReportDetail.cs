using System;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Flattened detail regarding one user shift assignment (for use with a report).
    /// </summary>
    [Serializable]
    public class WorkAssignmentReportDetail
    {
        private readonly ShiftPattern shiftPattern;
        private readonly Date shiftStartDate;

        public WorkAssignmentReportDetail(ShiftPattern shiftPattern, Date shiftStartDate)
        {
            this.shiftPattern = shiftPattern;
            this.shiftStartDate = shiftStartDate;
        }

        public ShiftPattern ShiftPattern
        {
            get { return shiftPattern; }
        }

        public DateTime ShiftStartDateTime
        {
            get { return shiftStartDate.CreateDateTime(ShiftPattern.StartTime); }
        }
    }
}
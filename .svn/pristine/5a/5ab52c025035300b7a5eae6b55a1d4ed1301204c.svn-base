using System;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class TimeEntry
    {
        private readonly long shiftId;
        private readonly Date shiftStartDate;
        private readonly Time time;

        public TimeEntry(Time time, long shiftId, Date shiftStartDate)
        {
            this.time = time;
            this.shiftId = shiftId;
            this.shiftStartDate = shiftStartDate;
        }

        public Time Time
        {
            get { return time; }
        }

        public long ShiftId
        {
            get { return shiftId; }
        }

        public Date ShiftStartDate
        {
            get { return shiftStartDate; }
        }

        public bool IsSameShift(UserShift userShift)
        {
            return ShiftId == userShift.ShiftPatternId &&
                   ShiftStartDate == userShift.StartDate;
        }
    }
}
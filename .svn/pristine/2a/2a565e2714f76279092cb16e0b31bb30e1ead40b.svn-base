using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class CokerCardCycleStepEntryDTO : DomainObject
    {
        public CokerCardCycleStepEntryDTO(long id, string drum, string cycle, DateTime start, DateTime? end,
            string shiftName, DateTime shiftStartDate, string comment)
        {
            Id = id;
            Drum = drum;
            Cycle = cycle;
            Start = start;
            End = end;
            ShiftName = shiftName;
            ShiftStartDate = shiftStartDate;
            Comment = comment;
        }

        public string Drum { get; private set; }
        public string Cycle { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }
        public string ShiftName { get; private set; }
        public DateTime ShiftStartDate { get; private set; }
        public string Comment { get; private set; }

        public string ShiftDescription
        {
            get { return string.Format("{0} {1}", ShiftStartDate.ToDateString(), ShiftName); }
        }

        public string StartTimeAsString
        {
            get { return Start.ToTimeString(); }
        }

        public string EndTimeAsString
        {
            get { return End != null ? End.Value.ToTimeString() : null; }
        }
    }
}
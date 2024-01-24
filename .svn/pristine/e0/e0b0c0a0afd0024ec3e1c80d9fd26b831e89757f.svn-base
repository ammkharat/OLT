using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftPatternFormatter
    {
        private readonly ShiftPattern shiftPattern;

        public ShiftPatternFormatter(ShiftPattern shiftPattern)
        {
            this.shiftPattern = shiftPattern;
        }

        public string Format()
        {
            return shiftPattern.Name + ": " + shiftPattern.StartTime + " - " + shiftPattern.EndTime;
        }
    }
}

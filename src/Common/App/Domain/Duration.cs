using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    public class Duration
    {
        public static readonly Duration OneWeek = new Duration(StringResources.OneWeekDuration, 0, 7);
        public static readonly Duration OneMonth = new Duration(StringResources.OneMonthDuration, 1, 0);
        public static readonly Duration ThreeMonths = new Duration(StringResources.ThreeMonthsDuration, 3, 0);
        public static readonly Duration SixMonths = new Duration(StringResources.SixMonthsDuration, 6, 0);
        public static readonly Duration OneYear = new Duration(StringResources.OneYearDuration, 12, 0);

        private static readonly Duration[] allDurations = {OneWeek, OneMonth, ThreeMonths, SixMonths, OneYear};

        private readonly int days;
        private readonly int months;
        private readonly string name;

        private Duration(string name, int months, int days)
        {
            this.name = name;
            this.months = months;
            this.days = days;
        }

        public string Name
        {
            get { return name; }
        }

        public static Duration Get(string durationName)
        {
            foreach (var duration in allDurations)
            {
                if (duration.Name.Equals(durationName))
                {
                    return duration;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return name;
        }

        public Date Before(Date today)
        {
            return today.AddMonths(-1*months).AddDays(-1*days);
        }
    }
}
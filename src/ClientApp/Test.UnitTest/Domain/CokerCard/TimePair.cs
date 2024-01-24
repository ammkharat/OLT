
namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class TimePair
    {
        private readonly int? start;
        private readonly int? end;

        public TimePair(int? start, int? end)
        {
            this.start = start;
            this.end = end;
        }

        public int? Start
        {
            get { return start; }
        }

        public int? End
        {
            get { return end; }
        }
    }
}

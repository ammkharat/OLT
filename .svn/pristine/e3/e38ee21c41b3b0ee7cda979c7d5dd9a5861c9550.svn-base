
namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryColumnKey
    {
        private readonly long cycleStepId;
        private readonly bool isLastStepInPreviousCokerCard;
        private readonly string cycleStepName;
        private readonly int displayOrder;

        public CycleStepEntryColumnKey(long cycleStepId, bool isLastStepInPreviousCokerCard, string cycleStepName, int displayOrder)
        {
            this.cycleStepId = cycleStepId;
            this.isLastStepInPreviousCokerCard = isLastStepInPreviousCokerCard;
            this.cycleStepName = cycleStepName;
            this.displayOrder = displayOrder;
        }

        public long CycleStepId
        {
            get { return cycleStepId; }
        }

        public bool IsLastStepInPreviousCokerCard
        {
            get { return isLastStepInPreviousCokerCard; }
        }

        public string CycleStepName
        {
            get { return cycleStepName; }
        }

        public int DisplayOrder
        {
            get { return displayOrder; }
        }

        public string ColumnCaption
        {
            get { return cycleStepName; }
        }

        public string Key
        {
            get { return "ColumnKey_" + cycleStepId + "_" + isLastStepInPreviousCokerCard; }
        }

        public bool Equals(CycleStepEntryColumnKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.cycleStepId == cycleStepId && other.isLastStepInPreviousCokerCard.Equals(isLastStepInPreviousCokerCard);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CycleStepEntryColumnKey)) return false;
            return Equals((CycleStepEntryColumnKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (cycleStepId.GetHashCode()*397) ^ isLastStepInPreviousCokerCard.GetHashCode();
            }
        }
    }
}

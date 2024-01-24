using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardRowGroupFillerForNextCard : CokerCardRowGroupFiller
    {
        private readonly UserShift nextCokerCardShift;
        private readonly int endIndexForEntriesForCurrentCokerCard;

        public CokerCardRowGroupFillerForNextCard(
            UserShift nextCokerCardShift,
            CycleStepEntryColumnKeyCollection columnKeys,
            CycleStepEntryIterator iterator,
            int endIndexForEntriesForCurrentCokerCard) 
            : base(columnKeys, iterator)
        {
            this.nextCokerCardShift = nextCokerCardShift;
            this.endIndexForEntriesForCurrentCokerCard = endIndexForEntriesForCurrentCokerCard;
        }

        public void Fill(CokerCardRowGroup rowGroup)
        {
            if (columnKeys.Count > 1)
            {
                int indexOfLastEntryWithEndEntryForNextCokerCard = GetIndexOfLastEntryWithEndEntryForNextCokerCard(rowGroup);

                if (iterator.HasEntries)
                {
                    int fillFromIndex = columnKeys.FindIndex(false, iterator.PeekFirst);
                    if (indexOfLastEntryWithEndEntryForNextCokerCard != -1 &&
                        indexOfLastEntryWithEndEntryForNextCokerCard < fillFromIndex)
                    {
                        fillFromIndex = indexOfLastEntryWithEndEntryForNextCokerCard + 1;
                    }
                    if (endIndexForEntriesForCurrentCokerCard != -1 &&
                        endIndexForEntriesForCurrentCokerCard >= fillFromIndex)
                    {
                        fillFromIndex = endIndexForEntriesForCurrentCokerCard + 1;
                    }

                    int fillToIndex = columnKeys.Count - 1;

                    FillWithEntries(rowGroup, fillFromIndex, fillToIndex);
                }
                else if (indexOfLastEntryWithEndEntryForNextCokerCard != -1)
                {
                    int fillFromIndex = indexOfLastEntryWithEndEntryForNextCokerCard + 1;
                    int fillToIndex = columnKeys.Count - 1;
                    FillWithEntries(rowGroup, fillFromIndex, fillToIndex);
                }
            }
        }

        private int GetIndexOfLastEntryWithEndEntryForNextCokerCard(CokerCardRowGroup rowGroup)
        {
            int index = -1;
            for (int i = 0; i < columnKeys.Count; i++)
            {
                CycleStepEntryColumnKey columnKey = columnKeys[i];
                if (rowGroup.IsSameShiftForOriginalEndEntry(columnKey, nextCokerCardShift))
                {
                    index = i;
                }
            }
            return index;
        }

        protected override CycleStepEntryDisplayAdapter CreateAdapter(
            CokerCardRowGroup rowGroup, CycleStepEntryColumnKey columnKey, CokerCardCycleStepEntry entry)
        {
            return CreateReadOnlyAdapter(rowGroup, columnKey, entry);
        }
    }
}

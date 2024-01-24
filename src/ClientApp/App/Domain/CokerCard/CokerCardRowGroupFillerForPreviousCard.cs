using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardRowGroupFillerForPreviousCard : CokerCardRowGroupFiller
    {
        private readonly UserShift currentCokerCardShift;
        private readonly int startIndexForEntriesForCurrentCokerCard;

        public CokerCardRowGroupFillerForPreviousCard(
            UserShift currentCokerCardShift,
            CycleStepEntryColumnKeyCollection columnKeys, 
            CycleStepEntryIterator iterator,
            int startIndexForEntriesForCurrentCokerCard)
            : base(columnKeys, iterator)
        {
            this.currentCokerCardShift = currentCokerCardShift;
            this.startIndexForEntriesForCurrentCokerCard = startIndexForEntriesForCurrentCokerCard;
        }

        public void Fill(CokerCardRowGroup rowGroup)
        {
            if (columnKeys.Count > 1 && iterator.HasEntries)
            {
                const int fillFromIndex = 0;

                int fillToIndex = columnKeys.FindIndex(true, iterator.PeekLast);
                if (fillToIndex == 0)
                {
                    iterator.MoveLast();
                }
                else
                {
                    if (startIndexForEntriesForCurrentCokerCard != -1 &&
                        startIndexForEntriesForCurrentCokerCard <= fillToIndex)
                    {
                        fillToIndex = startIndexForEntriesForCurrentCokerCard - 1;
                    }
                }

                FillWithEntries(rowGroup, fillFromIndex, fillToIndex);
            }
        }

        protected override CycleStepEntryDisplayAdapter CreateAdapter(
            CokerCardRowGroup rowGroup, CycleStepEntryColumnKey columnKey, CokerCardCycleStepEntry entry)
        {
            CycleStepEntryDisplayAdapter adapter;
            if (entry == null)
            {
                adapter = new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentCokerCardShift, rowGroup.DrumId, columnKey.CycleStepId);
            }
            else
            {
                adapter = new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentCokerCardShift, entry);
            }
            return adapter;
        }
    }
}

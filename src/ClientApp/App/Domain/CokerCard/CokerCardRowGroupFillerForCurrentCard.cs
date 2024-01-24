using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardRowGroupFillerForCurrentCard : CokerCardRowGroupFiller
    {
        private readonly UserShift currentCokerCardShift;

        public CokerCardRowGroupFillerForCurrentCard(
            UserShift currentCokerCardShift, 
            CycleStepEntryColumnKeyCollection columnKeys, 
            CycleStepEntryIterator iterator) 
            : base(columnKeys, iterator)
        {
            this.currentCokerCardShift = currentCokerCardShift;
        }

        public void Fill(CokerCardRowGroup rowGroup)
        {
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                if (columnKey.IsLastStepInPreviousCokerCard)
                {
                    rowGroup.AddAdapter(columnKey, CreateReadOnlyAdapter(rowGroup, columnKey, null));
                }
                else
                {
                    rowGroup.AddAdapter(columnKey, CreateAdapter(rowGroup, columnKey, null));
                }
            }

            if (iterator.HasEntries)
            {
                int fillFromIndex = columnKeys.FindIndex(false, iterator.PeekFirst);
                int fillToIndex = columnKeys.FindIndex(false, iterator.PeekLast);
                FillWithEntries(rowGroup, fillFromIndex, fillToIndex);
            }
        }

        protected override CycleStepEntryDisplayAdapter CreateAdapter(
            CokerCardRowGroup rowGroup, CycleStepEntryColumnKey columnKey, CokerCardCycleStepEntry entry)
        {
            CycleStepEntryDisplayAdapter adapter;
            if (entry == null)
            {
                adapter = new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentCokerCardShift, rowGroup.DrumId, columnKey.CycleStepId);
            }
            else
            {
                adapter = new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentCokerCardShift, entry);
            }
            return adapter;
        }
    }
}

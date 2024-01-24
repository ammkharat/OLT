using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public abstract class CokerCardRowGroupFiller
    {
        protected readonly CycleStepEntryColumnKeyCollection columnKeys;
        protected readonly CycleStepEntryIterator iterator;

        protected CokerCardRowGroupFiller(CycleStepEntryColumnKeyCollection columnKeys, CycleStepEntryIterator iterator)
        {
            this.columnKeys = columnKeys;
            this.iterator = iterator;
        }

        protected abstract CycleStepEntryDisplayAdapter CreateAdapter(
            CokerCardRowGroup rowGroup, CycleStepEntryColumnKey columnKey, CokerCardCycleStepEntry entry);

        protected void FillWithEntries(
            CokerCardRowGroup rowGroup,
            int fillFromIndex,
            int fillToIndex)
        {
            int columnKeyIndex = fillFromIndex;
            while (columnKeyIndex >= 0 &&
                   columnKeyIndex < columnKeys.Count &&
                   columnKeyIndex <= fillToIndex)
            {
                CycleStepEntryColumnKey columnKey = columnKeys[columnKeyIndex];

                if (iterator.Current != null &&
                    iterator.Current.CycleStepId == columnKey.CycleStepId)
                {
                    rowGroup.AddAdapter(columnKey, CreateAdapter(rowGroup, columnKey, iterator.Current));
                    iterator.MoveNext();
                }
                else
                {
                    rowGroup.AddAdapter(columnKey, CreateAdapter(rowGroup, columnKey, null));
                }

                columnKeyIndex++;
            }
        }

        protected static CycleStepEntryDisplayAdapter CreateReadOnlyAdapter(
            CokerCardRowGroup rowGroup, CycleStepEntryColumnKey columnKey, CokerCardCycleStepEntry entry)
        {
            CycleStepEntryDisplayAdapter adapter;
            if (entry == null)
            {
                adapter = new CycleStepEntryDisplayAdapterForReadOnly(rowGroup.DrumId, columnKey.CycleStepId);
            }
            else
            {
                adapter = new CycleStepEntryDisplayAdapterForReadOnly(entry);
            }
            return adapter;
        }
    }
}

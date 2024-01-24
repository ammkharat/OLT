using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardDisplayAdapter
    {
        private readonly UserShift cokerCardUserShift;
        private readonly UserShift nextCokerCardUserShift;
        private readonly CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
        private readonly Dictionary<long, CokerCardRowGroup> rowGroups = new Dictionary<long, CokerCardRowGroup>();

        public CokerCardDisplayAdapter(
            UserShift nextCokerCardUserShift,
            CokerCardConfiguration configuration,
            Common.Domain.CokerCard.CokerCard cokerCard,
            Common.Domain.CokerCard.CokerCard previousCokerCard,
            Common.Domain.CokerCard.CokerCard nextCard,
            Common.Domain.CokerCard.CokerCard previousPreviousCard)
        {
            cokerCardUserShift = new UserShift(cokerCard.Shift, cokerCard.ShiftStartDate);
            this.nextCokerCardUserShift = nextCokerCardUserShift;

            BuildOutlineForColumnsAndRows(configuration);
            PopulateRows(cokerCard, previousCokerCard, nextCard, previousPreviousCard);
        }

        private void BuildOutlineForColumnsAndRows(CokerCardConfiguration configuration)
        {
            configuration.Steps.Sort((x, y) => x.DisplayOrder.CompareTo(y.DisplayOrder));
            foreach (CokerCardConfigurationCycleStep step in configuration.Steps)
            {
                columnKeys.Add(new CycleStepEntryColumnKey(step.IdValue, false, step.Name, columnKeys.Count + 1));
            }
            if (columnKeys.Count > 1)
            {
                CycleStepEntryColumnKey lastStep = columnKeys[columnKeys.Count - 1];
                columnKeys.Insert(0, new CycleStepEntryColumnKey(lastStep.CycleStepId, true, lastStep.CycleStepName, 0));
            }

            configuration.Drums.Sort((x, y) => x.DisplayOrder.CompareTo(y.DisplayOrder));
            foreach (CokerCardConfigurationDrum drum in configuration.Drums)
            {
                rowGroups.Add(drum.IdValue, new CokerCardRowGroup(drum.IdValue, drum.Name, columnKeys));
            }
        }

        private void PopulateRows(
            Common.Domain.CokerCard.CokerCard cokerCard,
            Common.Domain.CokerCard.CokerCard previousCokerCard,
            Common.Domain.CokerCard.CokerCard nextCard,
            Common.Domain.CokerCard.CokerCard previousPreviousCard)
        {
            PopulateRowsWithDrumEntries(cokerCard);
            PopulateRowsWithCycleStepEntries(cokerCard, previousCokerCard, nextCard, previousPreviousCard);
        }

        private void PopulateRowsWithDrumEntries(Common.Domain.CokerCard.CokerCard cokerCard)
        {
            foreach (CokerCardDrumEntry entry in cokerCard.DrumEntries)
            {
                if (rowGroups.ContainsKey(entry.DrumId))
                {
                    CokerCardRowGroup rowGroup = rowGroups[entry.DrumId];
                    rowGroup.LastCycleStepId = entry.LastCycleStepId;
                    rowGroup.HoursIntoLastCycle = entry.HoursIntoLastCycle;
                    rowGroup.Comments = entry.Comments;
                }
            }
        }

        private void PopulateRowsWithCycleStepEntries(
            Common.Domain.CokerCard.CokerCard cokerCard,
            Common.Domain.CokerCard.CokerCard previousCokerCard,
            Common.Domain.CokerCard.CokerCard nextCard,
            Common.Domain.CokerCard.CokerCard previousPreviousCard)
        {
            if (columnKeys.Count == 0)
            {
                return;
            }

            CycleStepEntryIteratorsByDrum currentCardIterators = new CycleStepEntryIteratorsByDrum(columnKeys, cokerCard);
            CycleStepEntryIteratorsByDrum previousCardIterators = new CycleStepEntryIteratorsByDrum(columnKeys, previousCokerCard);
            CycleStepEntryIteratorsByDrum nextCardIterators = new CycleStepEntryIteratorsByDrum(columnKeys, nextCard);
            CycleStepEntryIteratorsByDrum previousPreviousCardIterators = new CycleStepEntryIteratorsByDrum(columnKeys, previousPreviousCard);

            foreach (CokerCardRowGroup rowGroup in rowGroups.Values)
            {
                CycleStepEntryIterator iteratorForCurrentCard = currentCardIterators.GetIteratorForDrum(rowGroup.DrumId);
                CycleStepEntryIterator iteratorForPreviousCard = GetIteratorForPreviousCard(
                    rowGroup, previousCardIterators, previousPreviousCardIterators);

                new CokerCardRowGroupFillerForCurrentCard(cokerCardUserShift, columnKeys, iteratorForCurrentCard)
                    .Fill(rowGroup);
                new CokerCardRowGroupFillerForPreviousCard(
                    cokerCardUserShift, 
                    columnKeys, 
                    iteratorForPreviousCard,
                    columnKeys.FindIndex(false, iteratorForCurrentCard.PeekFirst))
                    .Fill(rowGroup);
                new CokerCardRowGroupFillerForNextCard(
                    nextCokerCardUserShift,
                    columnKeys, 
                    nextCardIterators.GetIteratorForDrum(rowGroup.DrumId),
                    columnKeys.FindIndex(false, iteratorForCurrentCard.PeekLast))
                    .Fill(rowGroup);
            }
        }

        private CycleStepEntryIterator GetIteratorForPreviousCard(
            CokerCardRowGroup rowGroup, 
            CycleStepEntryIteratorsByDrum previousCardIterators, 
            CycleStepEntryIteratorsByDrum previousPreviousCardIterators)
        {
            CycleStepEntryIterator iterator = previousCardIterators.GetIteratorForDrum(rowGroup.DrumId);

            if (!iterator.HasEntries)
            {
                CycleStepEntryIterator iteratorForPreviousPreviousCard = previousPreviousCardIterators.GetIteratorForDrum(rowGroup.DrumId);
                if (iteratorForPreviousPreviousCard.HasEntries &&
                    iteratorForPreviousPreviousCard.PeekLast != null &&
                    columnKeys.Count > 0)
                {
                    CycleStepEntryColumnKey columnKey = columnKeys[0];
                    CokerCardCycleStepEntry lastFromPreviousPreviousCard = iteratorForPreviousPreviousCard.PeekLast;
                    if (columnKey.IsLastStepInPreviousCokerCard &&
                        columnKey.CycleStepId == lastFromPreviousPreviousCard.CycleStepId)
                    {
                        iterator = iteratorForPreviousPreviousCard;
                    }
                }
            }

            return iterator;
        }

        public List<CokerCardRow> Rows
        {
            get
            {
                List<CokerCardRow> rows = new List<CokerCardRow>();
                foreach (CokerCardRowGroup rowGroup in rowGroups.Values)
                {
                    rows.AddRange(rowGroup.Rows);
                }
                return rows;
            }
        }

        public List<CycleStepEntryColumnKey> ColumnKeys
        {
            get { return columnKeys; }
        }

        public List<CokerCardDrumEntry> DrumEntries
        {
            get
            {
                List<CokerCardDrumEntry> entries = new List<CokerCardDrumEntry>();
                foreach (CokerCardRowGroup rowGroup in rowGroups.Values)
                {
                    CokerCardDrumEntry entry = new CokerCardDrumEntry(
                        null, 
                        rowGroup.DrumId,
                        rowGroup.LastCycleStepId,
                        rowGroup.HoursIntoLastCycle, 
                        rowGroup.Comments);
                    entries.Add(entry);
                }
                return entries;
            }
        }

        public IEnumerable<CokerCardCycleStepEntry> CycleStepEntriesForCurrentCokerCard
        {
            get { return GetCycleStepEntries(true); }
        }

        public List<CokerCardCycleStepEntry> CycleStepEntriesForOtherCokerCard
        {
            get { return GetCycleStepEntries(false); }
        }

        private List<CokerCardCycleStepEntry> GetCycleStepEntries(bool forCurrent)
        {
            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            foreach (CokerCardRowGroup rowGroup in rowGroups.Values)
            {
                foreach (CokerCardCycleStepEntry entry in rowGroup.CycleStepEntries)
                {
                    if (entry.StartEntry.IsSameShift(cokerCardUserShift) == forCurrent)
                    {
                        entries.Add(entry);
                    }
                }
            }
            return entries;
        }

        public bool Validate()
        {
            bool isValid = true;

            foreach (CokerCardRowGroup rowGroup in rowGroups.Values)
            {
                isValid &= rowGroup.Validate();
            }

            return isValid;
        }
    }
}

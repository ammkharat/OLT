using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardRowGroup
    {
        private const int MAX_HOURS_INTO_LAST_CYCLE = 99;

        private readonly long drumId;
        private readonly CycleStepEntryColumnKeyCollection columnKeys;
        private readonly CokerCardRow startRow;
        private readonly CokerCardRow endRow;

        public CokerCardRowGroup(long drumId, string drumName, CycleStepEntryColumnKeyCollection columnKeys)
        {
            this.drumId = drumId;
            this.columnKeys = columnKeys;

            startRow = new CokerCardRowWithCycleStepStart(drumId, drumName);
            endRow = new CokerCardRowWithCycleStepEnd(drumId, drumName);

            endRow.CycleStepEntryDateTimeSet += EndRow_CycleStepEntryDateTimeSet;
        }

        private void EndRow_CycleStepEntryDateTimeSet(CycleStepEntryColumnKey key, DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                CycleStepEntryColumnKey nextKey = columnKeys.GetNext(key);
                if (nextKey != null &&
                    startRow.GetCycleStepEntryDateTime(nextKey) == null)
                {
                    startRow.SetCycleStepEntryDateTime(nextKey, dateTime);
                    startRow.TriggerPropertyChanged(nextKey);
                }
            }
        }

        public long DrumId
        {
            get { return drumId; }
        }

        public List<CokerCardRow> Rows
        {
            get { return new List<CokerCardRow>{ startRow, endRow }; }
        }

        public string Comments
        {
            set { startRow.Comments = value; }
            get { return startRow.Comments; }
        }

        public long? LastCycleStepId
        {
            set { startRow.LastCycleStepId = value; }
            get { return startRow.LastCycleStepId; }
        }

        public decimal? HoursIntoLastCycle
        {
            set { startRow.HoursIntoLastCycle = value; }
            get { return startRow.HoursIntoLastCycle; }
        }

        public IEnumerable<CokerCardCycleStepEntry> CycleStepEntries
        {
            get
            {
                List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();

                foreach (CycleStepEntryColumnKey columnKey in columnKeys)
                {
                    // both rows in the group reference the same set of adapters so
                    // only need to get the entries from one row
                    CokerCardCycleStepEntry entry = startRow.GetCycleStepEntry(columnKey);
                    if (entry != null)
                    {
                        entries.Add(entry);
                    }
                }

                return entries;
            }
        }

        public void AddAdapter(CycleStepEntryColumnKey key, CycleStepEntryDisplayAdapter adapter)
        {
            // each row shares the same reference to the same adapter
            startRow.AddAdapter(key, adapter);
            endRow.AddAdapter(key, adapter);
        }

        public bool Validate()
        {
            startRow.ClearError();
            endRow.ClearError();

            bool isValid = true;

            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                DateTime? startDateTime = startRow.GetCycleStepEntryDateTime(columnKey);
                DateTime? endDateTime = endRow.GetCycleStepEntryDateTime(columnKey);

                if (!startDateTime.HasValue && endDateTime.HasValue)
                {
                    startRow.AddError(String.Format(StringResources.CokerCardMissingStartTime, columnKey.CycleStepName));
                    isValid = false;
                }
            }

            if (startRow.HoursIntoLastCycle.HasValue &&
                startRow.HoursIntoLastCycle > MAX_HOURS_INTO_LAST_CYCLE)
            {
                startRow.AddError(String.Format(StringResources.HoursIntoCycleValidationError, MAX_HOURS_INTO_LAST_CYCLE));
                isValid = false;
            }


            return isValid;
        }

        public bool IsSameShiftForOriginalEndEntry(CycleStepEntryColumnKey columnKey, UserShift shift)
        {
            return endRow.IsSameShiftForOriginalEndEntry(columnKey, shift);
        }
    }
}

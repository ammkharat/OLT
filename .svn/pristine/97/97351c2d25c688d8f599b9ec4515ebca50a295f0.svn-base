using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public abstract class CokerCardRow : IDataErrorInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<CycleStepEntryColumnKey, DateTime?> CycleStepEntryDateTimeSet;

        private readonly long drumId;
        private readonly string drumName;

        private readonly Dictionary<CycleStepEntryColumnKey, CycleStepEntryDisplayAdapter> adapters = new Dictionary<CycleStepEntryColumnKey, CycleStepEntryDisplayAdapter>();
        private long? lastCycleStepId;
        private decimal? hoursIntoLastCycle;
        private string comments;

        private string rowError;

        protected CokerCardRow(long drumId, string drumName)
        {
            this.drumId = drumId;
            this.drumName = drumName;
        }

        public abstract string EntryTypeDescription { get; }
        public abstract bool AllowedToEnterLastCycleStep { get; }
        public abstract bool AllowedToEnterHoursIntoLastCycleStep { get; }
        public abstract bool AllowedToEnterComments { get; }
        protected abstract void SetDateTime(CycleStepEntryDisplayAdapter adapter, DateTime? stepDateTime);
        protected abstract DateTime? GetSetDateTime(CycleStepEntryDisplayAdapter adapter);
        protected abstract bool IsReadOnlyCycleStepEntry(CycleStepEntryDisplayAdapter adapter);

        public long DrumId
        {
            get { return drumId; }
        }

        public string DrumName
        {
            get { return drumName; }
        }

        public long? LastCycleStepId
        {
            get { return lastCycleStepId; }
            set { lastCycleStepId = value; }
        }

        public decimal? HoursIntoLastCycle
        {
            get { return hoursIntoLastCycle; }
            set { hoursIntoLastCycle = value; }
        }

        public string Comments
        {
            get { return comments.TrimWhitespace(); }
            set { comments = value; }
        }

        public void SetCycleStepEntryDateTime(CycleStepEntryColumnKey key, DateTime? stepDateTime)
        {
            CycleStepEntryDisplayAdapter adapter = GetAdapter(key);
            if (adapter != null)
            {
                DateTime? stepDateTimeWithCorrectDate = null;

                if (stepDateTime.HasValue)
                {
                    stepDateTimeWithCorrectDate = new Time(stepDateTime.Value).ToDateTime();
                }

                SetDateTime(adapter, stepDateTimeWithCorrectDate);
                if (CycleStepEntryDateTimeSet != null)
                {
                    CycleStepEntryDateTimeSet(key, stepDateTimeWithCorrectDate);
                }
            }
        }

        public DateTime? GetCycleStepEntryDateTime(CycleStepEntryColumnKey key)
        {
            CycleStepEntryDisplayAdapter adapter = GetAdapter(key);
            if (adapter != null)
            {
                return GetSetDateTime(adapter);
            }
            else
            {
                return null;
            }
        }

        public bool IsReadOnlyCycleStepEntry(CycleStepEntryColumnKey key)
        {
            CycleStepEntryDisplayAdapter adapter = GetAdapter(key);
            if (adapter != null)
            {
                return IsReadOnlyCycleStepEntry(adapter);
            }
            else
            {
                return true;
            }
        }

        public CokerCardCycleStepEntry GetCycleStepEntry(CycleStepEntryColumnKey key)
        {
            CycleStepEntryDisplayAdapter adapter = GetAdapter(key);
            if (adapter != null)
            {
                return adapter.GetCycleStepEntry();
            }
            else
            {
                return null;
            }
        }

        private CycleStepEntryDisplayAdapter GetAdapter(CycleStepEntryColumnKey key)
        {
            if (adapters.ContainsKey(key))
            {
                return adapters[key];                
            }
            else
            {
                return null;
            }
        }

        public void AddAdapter(CycleStepEntryColumnKey key, CycleStepEntryDisplayAdapter adapter)
        {
            if (!adapters.ContainsKey(key))
            {
                adapters.Add(key, adapter);
            }
            else
            {
                adapters[key] = adapter;
            }
        }

        public string this[string columnName]
        {
            get { return null; }
        }

        public string Error
        {
            get { return rowError; }
        }

        public void AddError(string error)
        {
            if (!string.IsNullOrEmpty(rowError))
            {
                rowError += Environment.NewLine;
            }
            rowError += error;
        }

        public void ClearError()
        {
            rowError = null;
        }

        public void TriggerPropertyChanged(CycleStepEntryColumnKey key)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(key.Key));
            }
        }

        public bool IsSameShiftForOriginalEndEntry(CycleStepEntryColumnKey columnKey, UserShift shift)
        {
            CycleStepEntryDisplayAdapter adapter = GetAdapter(columnKey);
            if (adapter == null)
            {
                return false;
            }
            else if (adapter.OriginalEndEntry == null)
            {
                return false;
            }
            else
            {
                return adapter.OriginalEndEntry.IsSameShift(shift);
            }
        }
    }
}

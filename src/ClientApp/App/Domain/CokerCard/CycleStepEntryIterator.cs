using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryIterator
    {
        private const int INVALID_INDEX = -99;

        private readonly List<CokerCardCycleStepEntry> entries;
        private int index;

        public CycleStepEntryIterator(List<CokerCardCycleStepEntry> entries)
        {
            this.entries = entries;
            index = INVALID_INDEX;
            MoveFirst();
        }

        public bool HasEntries
        {
            get { return entries.Count > 0; }
        }
        
        public CokerCardCycleStepEntry Current
        {
            get
            {
                if (IsIndexValid)
                {
                    return entries[index];
                }
                else
                {
                    return null;
                }
            }
        }

        public void MoveNext()
        {
            index++;
            if (!IsIndexValid)
            {
                index = INVALID_INDEX;
            }
        }

        public CokerCardCycleStepEntry PeekFirst
        {
            get
            {
                if (HasEntries)
                {
                    return entries[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public CokerCardCycleStepEntry PeekLast
        {
            get
            {
                if (HasEntries)
                {
                    return entries[entries.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        private void MoveFirst()
        {
            if (HasEntries)
            {
                index = 0;
            }
            else
            {
                index = INVALID_INDEX;
            }
        }

        public void MoveLast()
        {
            if (HasEntries)
            {
                index = entries.Count - 1;
            }
            else
            {
                index = INVALID_INDEX;
            }
        }

        private bool IsIndexValid
        {
            get { return index >= 0 && index < entries.Count; }
        }
    }
}

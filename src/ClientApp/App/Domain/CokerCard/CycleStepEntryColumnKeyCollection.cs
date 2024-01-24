using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryColumnKeyCollection : List<CycleStepEntryColumnKey>
    {
        public int FindIndex(bool includeLastStepInPreviousCokerCard, CokerCardCycleStepEntry entry)
        {
            if (entry == null)
            {
                return -1;
            }
            else
            {
                return FindIndex(obj =>
                    (includeLastStepInPreviousCokerCard || !obj.IsLastStepInPreviousCokerCard) &&
                    obj.CycleStepId == entry.CycleStepId);
            }
        }

        public CycleStepEntryColumnKey GetNext(CycleStepEntryColumnKey entry)
        {
            if (entry == null)
            {
                return null;
            }
            else
            {
                int index = FindIndex(obj =>
                    obj.IsLastStepInPreviousCokerCard == entry.IsLastStepInPreviousCokerCard &&
                    obj.CycleStepId == entry.CycleStepId);
                if (index == -1)
                {
                    return null;
                }
                else
                {
                    index++;
                    if (index >= 0 && index < Count)
                    {
                        return this[index];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}

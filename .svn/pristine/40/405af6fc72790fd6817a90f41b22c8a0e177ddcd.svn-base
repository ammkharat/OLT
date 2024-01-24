using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryIteratorsByDrum
    {
        private readonly Dictionary<long, List<CokerCardCycleStepEntry>> entriesByDrum = 
            new Dictionary<long, List<CokerCardCycleStepEntry>>();

        public CycleStepEntryIteratorsByDrum(
            List<CycleStepEntryColumnKey> columnKeys, Common.Domain.CokerCard.CokerCard card)
        {
            if (card != null)
            {

                Dictionary<long, int> cycleStepIdToDisplayOrderMap = GetCycleStepIdToDisplayOrderMap(columnKeys);

                List<CokerCardCycleStepEntry> entries = GetSortedEntries(card, cycleStepIdToDisplayOrderMap);

                // TODO: This could use CollectionExtensions.GroupUsing(stepEntry => stepEntry.DrumId)
                foreach (CokerCardCycleStepEntry entry in entries)
                {
                    long key = entry.DrumId;
                    if (!entriesByDrum.ContainsKey(key))
                    {
                        entriesByDrum.Add(key, new List<CokerCardCycleStepEntry>());
                    }
                    entriesByDrum[key].Add(entry);
                }
            }
        }

        private static List<CokerCardCycleStepEntry> GetSortedEntries(Common.Domain.CokerCard.CokerCard card, Dictionary<long, int> cycleStepIdToDisplayOrderMap)
        {
            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            foreach (CokerCardCycleStepEntry entry in card.CycleStepEntries)
            {
                if (cycleStepIdToDisplayOrderMap.ContainsKey(entry.CycleStepId))
                {
                    entries.Add(entry);
                }
            }
            entries.Sort((x, y) => cycleStepIdToDisplayOrderMap[x.CycleStepId].CompareTo(cycleStepIdToDisplayOrderMap[y.CycleStepId]));
            return entries;
        }

        private static Dictionary<long, int> GetCycleStepIdToDisplayOrderMap(List<CycleStepEntryColumnKey> columnKeys)
        {
            Dictionary<long, int> cycleStepIdToDisplayOrderMap = new Dictionary<long, int>();
            for (int i = 0; i < columnKeys.Count; i++)
            {
                CycleStepEntryColumnKey key = columnKeys[i];
                if (!key.IsLastStepInPreviousCokerCard &&
                    !cycleStepIdToDisplayOrderMap.ContainsKey(key.CycleStepId))
                {
                    cycleStepIdToDisplayOrderMap.Add(key.CycleStepId, i);
                }
            }
            return cycleStepIdToDisplayOrderMap;
        }

        public CycleStepEntryIterator GetIteratorForDrum(long drumId)
        {
            if (entriesByDrum.ContainsKey(drumId))
            {
                return new CycleStepEntryIterator(entriesByDrum[drumId]);
            }
            else
            {
                return new CycleStepEntryIterator(new List<CokerCardCycleStepEntry>());
            }
        }
    }
}

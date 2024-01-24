using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardHistory : DomainObject, IHistorySnapshot
    {
        private readonly List<CokerCardDrumEntryHistory> drumEntryHistories = new List<CokerCardDrumEntryHistory>();

        public CokerCardHistory(long cokerCardId, User lastModifiedUser, DateTime lastModifiedDate,
            List<CokerCardDrumEntryHistory> drumEntryHistoryEntryHistories)
        {
            CokerCardId = cokerCardId;
            LastModifiedBy = lastModifiedUser;
            LastModifiedDate = lastModifiedDate;
            drumEntryHistories = drumEntryHistoryEntryHistories;
        }

        public CokerCardHistory(CokerCardConfiguration configuration, CokerCard cokerCard,
            List<CokerCardCycleStepEntry> previousEntries)
        {
            CokerCardId = cokerCard.IdValue;

            LastModifiedBy = cokerCard.LastModifiedBy;
            LastModifiedDate = cokerCard.LastModifiedDate;

            AddDrumsAndStepsFromConfiguration(configuration);
            AddCokerCardEntryData(configuration, cokerCard);
            AddPreviousEntries(configuration, previousEntries);
        }

        public long CokerCardId { get; private set; }

        public List<CokerCardDrumEntryHistory> DrumEntryHistories
        {
            get { return drumEntryHistories; }
        }

        public User LastModifiedBy { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        private void AddCokerCardEntryData(CokerCardConfiguration configuration, CokerCard cokerCard)
        {
            foreach (var drumEntry in cokerCard.DrumEntries)
            {
                var cokerCardDrumEntryHistory =
                    DrumEntryHistories.Find(drumEntryHistory => drumEntryHistory.DrumConfigurationId == drumEntry.DrumId);

                if (cokerCardDrumEntryHistory == null)
                    continue;

                if (drumEntry.LastCycleStepId != null)
                {
                    var step = configuration.Steps.Find(obj => obj.IdValue == drumEntry.LastCycleStepId.Value);
                    if (step != null)
                    {
                        cokerCardDrumEntryHistory.LastCycleStep = step.Name;
                    }
                }
                cokerCardDrumEntryHistory.HoursIntoLastCycle = drumEntry.HoursIntoLastCycle;
                cokerCardDrumEntryHistory.Comments = drumEntry.Comments;
            }

            foreach (var cycleStepEntry in cokerCard.CycleStepEntries)
            {
                var cokerCardDrumEntryHistory =
                    DrumEntryHistories.Find(
                        drumEntryHistory => drumEntryHistory.DrumConfigurationId == cycleStepEntry.DrumId);

                if (cokerCardDrumEntryHistory == null)
                    continue;

                var cokerCardCycleStepHistory =
                    cokerCardDrumEntryHistory.CycleStepHistory.Find(
                        csh => csh.CycleStepConfigurationId == cycleStepEntry.CycleStepId);

                if (cokerCardCycleStepHistory == null)
                    continue;

                cokerCardCycleStepHistory.SetTimes(cycleStepEntry.StartEntry, cycleStepEntry.EndEntry);
            }
        }

        private void AddPreviousEntries(CokerCardConfiguration configuration,
            List<CokerCardCycleStepEntry> previousEntries)
        {
            foreach (var entry in previousEntries)
            {
                var drumHistory =
                    DrumEntryHistories.Find(drumEntryHistory => drumEntryHistory.DrumConfigurationId == entry.DrumId);
                if (drumHistory != null)
                {
                    var cycleStep = configuration.Steps.Find(obj => obj.Id == entry.CycleStepId);

                    drumHistory.CycleStepHistory.Add(new CokerCardCycleStepHistory(
                        null,
                        entry.CycleStepId,
                        cycleStep == null ? "" : cycleStep.Name,
                        drumHistory.Name,
                        entry.StartEntry.Time,
                        entry.EndEntry == null ? null : entry.EndEntry.Time));
                }
            }
        }

        private void AddDrumsAndStepsFromConfiguration(CokerCardConfiguration configuration)
        {
            var cokerCardDrumEntryHistories =
                configuration.Drums.ConvertAll(drumConfiguration => new CokerCardDrumEntryHistory(drumConfiguration));

            foreach (var drumEntryHistory in cokerCardDrumEntryHistories)
            {
                var cardCycleStepHistories = configuration.Steps.ConvertAll(
                    cycleStepConfiguration =>
                        new CokerCardCycleStepHistory(cycleStepConfiguration, drumEntryHistory.Name));

                drumEntryHistory.CycleStepHistory.AddRange(cardCycleStepHistories);
            }

            DrumEntryHistories.AddRange(cokerCardDrumEntryHistories);
        }
    }
}
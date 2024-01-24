using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardDrumEntryHistoryDao : AbstractManagedDao, ICokerCardDrumEntryHistoryDao
    {
        public List<CokerCardDrumEntryHistory> GetDrumEntryHistoryByCokerCardHistoryId(long cokerCardHistoryId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardHistoryId", cokerCardHistoryId);
            List<FlattenedDrumEntryHistoryAndCycleStepHistory> flattenedDrumEntryHistoryAndCycleStepHistories =
                command.QueryForListResult<FlattenedDrumEntryHistoryAndCycleStepHistory>(PopulateDrumEntryInstance, "QueryCokerCardEntryHistoryByCokerCardHistoryId");

            List<CokerCardDrumEntryHistory> result = new List<CokerCardDrumEntryHistory>();
            foreach (FlattenedDrumEntryHistoryAndCycleStepHistory cycleStepHistory in flattenedDrumEntryHistoryAndCycleStepHistories)
            {
                if (result.DoesNotHave(drumEntryHistory => drumEntryHistory.DrumConfigurationId == cycleStepHistory.DrumConfigurationId))
                {
                    CokerCardDrumEntryHistory cokerCardDrumEntryHistory =
                        new CokerCardDrumEntryHistory(cycleStepHistory.DrumEntryHistoryId,
                                                      cycleStepHistory.DrumConfigurationId,
                                                      cycleStepHistory.DrumName,
                                                      cycleStepHistory.LastCycleStep,
                                                      cycleStepHistory.HoursIntoLastCycle,
                                                      cycleStepHistory.Comments);
                    result.Add(cokerCardDrumEntryHistory);
                }
                CokerCardDrumEntryHistory cardDrumEntryHistory = result.FindById(cycleStepHistory.DrumEntryHistoryId);

                CokerCardCycleStepHistory cokerCardCycleStepHistory =
                    new CokerCardCycleStepHistory(cycleStepHistory.CycleStepEntryHistoryId,
                        cycleStepHistory.CycleStepConfigurationId,
                        cycleStepHistory.CycleStepName,
                        cardDrumEntryHistory.Name,
                        cycleStepHistory.StartTime,
                        cycleStepHistory.EndTime);

                cardDrumEntryHistory.CycleStepHistory.Add(cokerCardCycleStepHistory);
            }
            return result;
        }

        private static FlattenedDrumEntryHistoryAndCycleStepHistory PopulateDrumEntryInstance(SqlDataReader reader)
        {
            long drumEntryHistoryId = reader.Get<long>("DrumEntryHistoryId");
            long drumConfigurationId = reader.Get<long>("DrumConfigurationId");
            string drumName = reader.Get<string>("DrumName");
            string lastCycleStep = reader.Get<string>("CokerCardConfigurationLastCycleStep");
            decimal? hoursIntoLastCycle = reader.Get<decimal?>("HoursIntoLastCycle");
            string comments = reader.Get<string>("Comments");

            long cycleStepEntryHistoryId = reader.Get<long>("CycleStepEntryHistoryId");
            long cycleStepConfigurationId = reader.Get<long>("CycleStepConfigurationId");
            string cycleStepName = reader.Get<string>("CycleStepName");
            DateTime? startTime = reader.Get<DateTime?>("StartTime");
            DateTime? endTime = reader.Get<DateTime?>("EndTime");

            return new FlattenedDrumEntryHistoryAndCycleStepHistory(
                drumEntryHistoryId, drumConfigurationId, drumName, lastCycleStep, hoursIntoLastCycle, comments,
                cycleStepEntryHistoryId,
                cycleStepConfigurationId, cycleStepName, startTime.ToTime(), endTime.ToTime());
        }

        private class FlattenedDrumEntryHistoryAndCycleStepHistory
        {
            public long DrumEntryHistoryId { get; private set; }
            public long DrumConfigurationId { get; private set; }
            public string DrumName { get; private set; }
            public string LastCycleStep { get; private set; }
            public decimal? HoursIntoLastCycle { get; private set; }
            public string Comments { get; private set; }
            public long CycleStepEntryHistoryId { get; private set; }
            public long CycleStepConfigurationId { get; private set; }
            public string CycleStepName { get; private set; }
            public Time StartTime { get; private set; }
            public Time EndTime { get; private set; }

            public FlattenedDrumEntryHistoryAndCycleStepHistory(long drumEntryHistoryId, long drumConfigurationId,
                                                                string drumName, string lastCycleStep, decimal? hoursIntoLastCycle, string comments,
                                                                long cycleStepEntryHistoryId, long cycleStepConfigurationId,
                                                                string cycleStepName, Time startTime, Time endTime)
            {
                DrumEntryHistoryId = drumEntryHistoryId;
                DrumConfigurationId = drumConfigurationId;
                DrumName = drumName;
                LastCycleStep = lastCycleStep;
                HoursIntoLastCycle = hoursIntoLastCycle;
                Comments = comments;
                CycleStepEntryHistoryId = cycleStepEntryHistoryId;
                CycleStepConfigurationId = cycleStepConfigurationId;
                CycleStepName = cycleStepName;
                StartTime = startTime;
                EndTime = endTime;
            }
        }
    }
}
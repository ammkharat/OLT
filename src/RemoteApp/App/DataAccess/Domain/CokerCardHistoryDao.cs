using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardHistoryDao : AbstractManagedDao, ICokerCardHistoryDao
    {
        private readonly IUserDao userDao;
        private readonly ICokerCardDrumEntryHistoryDao entryHistoryDao;

        public CokerCardHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            entryHistoryDao = DaoRegistry.GetDao<ICokerCardDrumEntryHistoryDao>();
        }
        
        public void Insert(CokerCardHistory logHistory)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("CokerCardId", logHistory.CokerCardId);
            command.AddParameter("LastModifiedUserId", logHistory.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", logHistory.LastModifiedDate);

            long historyId = command.InsertAndReturnId("InsertCokerCardHistory");
            InsertDrumAndCycleSteps(historyId, logHistory.DrumEntryHistories);
    }

        private void InsertDrumAndCycleSteps(long historyId, List<CokerCardDrumEntryHistory> drumEntryHistories)
        {
            foreach (CokerCardDrumEntryHistory drumEntryHistory in drumEntryHistories)
            {
                SqlCommand command = ManagedCommand;
                command.AddParameter("CokerCardHistoryId", historyId);
                command.AddParameter("DrumConfigurationId", drumEntryHistory.DrumConfigurationId);
                command.AddParameter("DrumName", drumEntryHistory.Name);
                command.AddParameter("CokerCardConfigurationLastCycleStep", drumEntryHistory.LastCycleStep);
                command.AddParameter("HoursIntoLastCycle", drumEntryHistory.HoursIntoLastCycle);
                command.AddParameter("Comments", drumEntryHistory.Comments);

                long cokerCardDrumEntryHistoryId = command.InsertAndReturnId("InsertCokerCardDrumEntryHistory");

                drumEntryHistory.CycleStepHistory.ForEach(delegate(CokerCardCycleStepHistory csh)
                                                              {
                                                                  command.ClearParameters();
                                                                  command.AddParameter("CokerCardDrumEntryHistoryId", cokerCardDrumEntryHistoryId);
                                                                  command.AddParameter("CycleStepConfigurationId", csh.CycleStepConfigurationId);
                                                                  command.AddParameter("CycleStepName", csh.CycleStepName);

                                                                  if (csh.StartTime != null)
                                                                    command.AddParameter("StartTime", csh.StartTime.ToDateTime());
                                                                  if (csh.EndTime != null)
                                                                    command.AddParameter("EndTime", csh.EndTime.ToDateTime());

                                                                  command.InsertAndReturnId("InsertCokerCardCycleStepEntryHistory");
                                                              });
            }
        }


        public List<CokerCardHistory> GetById(long cokerCardId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardId", cokerCardId);
            return command.QueryForListResult<CokerCardHistory>(PopulateInstance, "QueryCokerCardHistoriesByCokerCardId");
        }

        private CokerCardHistory PopulateInstance(SqlDataReader reader)
        {
            // create a new CokerCardHistory object
            long cokerCardHistoryId = reader.Get<long>("Id");
            long cokerCardId = reader.Get<long>("CokerCardId");
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");

            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));

            List<CokerCardDrumEntryHistory> entries = entryHistoryDao.GetDrumEntryHistoryByCokerCardHistoryId(cokerCardHistoryId);

            CokerCardHistory cokerCardHistory = new CokerCardHistory(
                cokerCardId, lastModifiedUser, lastModifiedDate, entries) { Id = cokerCardHistoryId };

            return cokerCardHistory;
        }
    }
}
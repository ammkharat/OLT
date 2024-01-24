using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardDao : AbstractManagedDao, ICokerCardDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryCokerCardById";
        private const string QUERY_BY_CONFIGURATION_AND_SHIFT = "QueryCokerCardByConfigurationAndShift";
        private const string QUERY_COKER_CARD_SUMMARY = "QueryCokerCardSummary";

        private const string INSERT_STORED_PROCEDURE = "InsertCokerCard";
        private const string UPDATE_STORED_PROCEDURE = "UpdateCokerCard";
        private const string REMOVE_STORED_PROCEDURE = "RemoveCokerCard";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly IUserDao userDao;
        private readonly IShiftPatternDao shiftPatternDao;
        private readonly ICokerCardCycleStepEntryDao cycleStepEntryDao;
        private readonly ICokerCardDrumEntryDao drumEntryDao;

        public CokerCardDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            cycleStepEntryDao = DaoRegistry.GetDao<ICokerCardCycleStepEntryDao>();
            drumEntryDao = DaoRegistry.GetDao<ICokerCardDrumEntryDao>();
        }

        public CokerCard QueryById(long id)
        {
            return ManagedCommand.QueryById < CokerCard>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public CokerCard QueryByConfigurationAndShift(long configurationId, UserShift shift)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardConfigurationId",  configurationId);
            command.AddParameter("@ShiftId",  shift.ShiftPatternId);
            command.AddParameter("@ShiftStartDate",  shift.StartDate.ToDateTimeAtStartOfDay());
            return command.QueryForSingleResult < CokerCard>(PopulateInstance, QUERY_BY_CONFIGURATION_AND_SHIFT);
        }

        private CokerCard PopulateInstance(SqlDataReader reader)
        {
            WorkAssignment workAssignment = null;
            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            if (workAssignmentId.HasValue)
            {
                workAssignment = workAssignmentDao.QueryById(workAssignmentId.Value);
            }

            CokerCard cokerCard = new CokerCard(
                reader.Get<long?>("Id"),
                reader.Get<long>("CokerCardConfigurationId"),
                reader.Get<string>("CokerCardConfigurationName"),
                functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID")),
                workAssignment,
                shiftPatternDao.QueryById(reader.Get<long>("ShiftId")),
                new Date(reader.Get<DateTime>("ShiftStartDate")),
                userDao.QueryById(reader.Get<long>("CreatedByUserId")),
                reader.Get<DateTime>("CreatedDateTime"),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.Get<bool>("Deleted"));

            cokerCard.DrumEntries.AddRange(drumEntryDao.QueryByCokerCardId(cokerCard.IdValue));
            cokerCard.CycleStepEntries.AddRange(cycleStepEntryDao.QueryByCokerCardId(cokerCard.IdValue));

            return cokerCard;
        }

        public CokerCard Insert(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(cokerCard, AddInsertParameters, INSERT_STORED_PROCEDURE);
            cokerCard.Id = (long?)idParameter.Value;

            InsertEntries(cokerCard);
            UpdatePreviousEntries(previousEntries);

            return cokerCard;
        }

        private static void AddInsertParameters(CokerCard cokerCard, SqlCommand command)
        {
            command.AddParameter("@CokerCardConfigurationId", cokerCard.ConfigurationId);
            command.AddParameter("@FunctionalLocationId", cokerCard.FunctionalLocation.Id);
            if (cokerCard.WorkAssignment != null)
            {
                command.AddParameter("@WorkAssignmentId", cokerCard.WorkAssignment.Id);
            }

            command.AddParameter("@ShiftId", cokerCard.Shift.Id);
            command.AddParameter("@ShiftStartDate", cokerCard.ShiftStartDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@CreatedByUserId", cokerCard.CreatedBy.Id);
            command.AddParameter("@CreatedDateTime", cokerCard.CreatedDateTime);
            SetInsertUpdateAttributes(cokerCard, command);
        }

        private void InsertEntries(CokerCard cokerCard)
        {
            foreach (CokerCardDrumEntry entry in cokerCard.DrumEntries)
            {
                drumEntryDao.Insert(entry, cokerCard.IdValue);
            }
            foreach (CokerCardCycleStepEntry entry in cokerCard.CycleStepEntries)
            {
                cycleStepEntryDao.Insert(entry, cokerCard.IdValue);
            }
        }

        private void UpdatePreviousEntries(List<CokerCardCycleStepEntry> previousEntries)
        {
            foreach (CokerCardCycleStepEntry entry in previousEntries)
            {
                cycleStepEntryDao.UpdateEndEntry(entry);                
            }
        }

        public void Update(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries)
        {
            SqlCommand command = ManagedCommand;
            command.Update(cokerCard, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            DeleteEntries(cokerCard);
            InsertEntries(cokerCard);
            UpdatePreviousEntries(previousEntries);
        }

        private void DeleteEntries(CokerCard cokerCard)
        {
            drumEntryDao.DeleteByCokerCardId(cokerCard.IdValue);
            cycleStepEntryDao.DeleteByCokerCardId(cokerCard.IdValue);
        }

        private static void AddUpdateParameters(CokerCard cokerCard, SqlCommand command)
        {
            command.AddParameter("@Id", cokerCard.Id);
            SetInsertUpdateAttributes(cokerCard, command);
        }

        private static void SetInsertUpdateAttributes(CokerCard cokerCard, SqlCommand command)
        {
            command.AddParameter("@LastModifiedByUserId", cokerCard.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", cokerCard.LastModifiedDate);
        }

        public void Remove(CokerCard cokerCard)
        {
            ManagedCommand.ExecuteNonQuery(cokerCard, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public List<CokerCardDrumEntryDTO> QueryCokerCardSummaries(Date shiftStartDate, long shiftId, long workAssignmentId, List<long> cokerCardConfigurationIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftStartDate", Time.START_OF_DAY.ToDateTime(shiftStartDate));
            command.AddParameter("@ShiftId", shiftId);
            command.AddParameter("@WorkAssignmentId", workAssignmentId);
            command.AddParameter("@ConfigurationIds", cokerCardConfigurationIds.ToCommaSeparatedString());
            return command.QueryForListResult<CokerCardDrumEntryDTO>(PopulateCokerCardEntryDTO, QUERY_COKER_CARD_SUMMARY);
        }

        private static CokerCardDrumEntryDTO PopulateCokerCardEntryDTO(SqlDataReader reader)
        {
            long cokerCardConfigurationId = reader.Get<long>("CokerCardConfigurationId");
            string cokerCardName = reader.Get<string>("CokerCardName");
            string drumName = reader.Get<string>("DrumName");
            string lastCycleStep = reader.Get<string>("LastCycleStep");
            decimal hoursIntoLastCycle = reader.Get<decimal>("HoursIntoLastCycle");
            string comments = reader.Get<string>("Comments");

            return new CokerCardDrumEntryDTO(cokerCardConfigurationId, cokerCardName, drumName, lastCycleStep,
                                             hoursIntoLastCycle, comments);
        }

        private static void AddRemoveParameters(CokerCard cokerCard, SqlCommand command)
        {
            command.AddParameter("@Id", cokerCard.Id);
            command.AddParameter("@LastModifiedByUserId", cokerCard.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", cokerCard.LastModifiedDate);
        }

    }
}

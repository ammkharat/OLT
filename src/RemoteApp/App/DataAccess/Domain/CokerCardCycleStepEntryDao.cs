using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardCycleStepEntryDao :AbstractManagedDao, ICokerCardCycleStepEntryDao
    {
        private const string QUERY_BY_COKER_CARD_ID = "QueryCokerCardCycleStepEntryByCokerCardId";
        private const string INSERT = "InsertCokerCardCycleStepEntry";
        private const string DELETE_BY_COKER_CARD_ID = "DeleteCokerCardCycleStepEntryByCokerCardId";
        private const string UPDATE_END_ENTRY = "UpdateCokerCardCycleStepEntryEndEntry";

        public List<CokerCardCycleStepEntry> QueryByCokerCardId(long cokerCardId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardId",  cokerCardId);
            return command.QueryForListResult < CokerCardCycleStepEntry>(PopulateInstance, QUERY_BY_COKER_CARD_ID);      
        }

        private static CokerCardCycleStepEntry PopulateInstance(SqlDataReader reader)
        {
            TimeEntry startEntry = new TimeEntry(
                new Time(reader.Get<DateTime>("StartTime")),
                reader.Get<long>("StartEntryShiftId"),
                new Date(reader.Get<DateTime>("StartEntryShiftStartDate")));

            TimeEntry endEntry = null;
            DateTime? endTimeAsDateTime = reader.Get<DateTime?>("EndTime");
            if (endTimeAsDateTime.HasValue)
            {
                endEntry = new TimeEntry(new Time(endTimeAsDateTime.Value), reader.Get<long>("EndEntryShiftId"), new Date((reader.Get<DateTime?>("EndEntryShiftStartDate")).Value));
            }

            CokerCardCycleStepEntry cycleStepEntry = new CokerCardCycleStepEntry(
                reader.Get<long>("Id"),
                reader.Get<long>("CokerCardConfigurationDrumId"),
                reader.Get<long>("CokerCardConfigurationCycleStepId"),
                startEntry,
                endEntry);

            return cycleStepEntry;
        }

        public void Insert(CokerCardCycleStepEntry entry, long cokerCardId)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@CokerCardId", cokerCardId);
            command.Insert(entry, AddInsertParameters, INSERT);
            entry.Id = (long?)idParameter.Value;
        }

        private static void AddInsertParameters(CokerCardCycleStepEntry entry, SqlCommand command)
        {
            command.AddParameter("@CokerCardConfigurationDrumId", entry.DrumId);
            command.AddParameter("@CokerCardConfigurationCycleStepId", entry.CycleStepId);
            command.AddParameter("@StartTime", entry.StartEntry.Time.ToDateTime());
            command.AddParameter("@StartEntryShiftId", entry.StartEntry.ShiftId);
            command.AddParameter("@StartEntryShiftStartDate", entry.StartEntry.ShiftStartDate.ToDateTimeAtStartOfDay());
            if (entry.EndEntry != null)
            {
                command.AddParameter("@EndTime", entry.EndEntry.Time.ToDateTime());
                command.AddParameter("@EndEntryShiftId", entry.EndEntry.ShiftId);
                command.AddParameter("@EndEntryShiftStartDate", entry.EndEntry.ShiftStartDate.ToDateTimeAtStartOfDay());
            }
        }

        public void DeleteByCokerCardId(long cokerCardId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardId",  cokerCardId);
            command.ExecuteNonQuery(DELETE_BY_COKER_CARD_ID);
        }

        public void UpdateEndEntry(CokerCardCycleStepEntry entry)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(entry, AddUpdateParameters, UPDATE_END_ENTRY);
        }

        private static void AddUpdateParameters(CokerCardCycleStepEntry entry, SqlCommand command)
        {
            command.AddParameter("@Id", entry.IdValue);
            if (entry.EndEntry != null)
            {
                command.AddParameter("@EndTime", entry.EndEntry.Time.ToDateTime());
                command.AddParameter("@EndEntryShiftId", entry.EndEntry.ShiftId);
                command.AddParameter("@EndEntryShiftStartDate", entry.EndEntry.ShiftStartDate.ToDateTimeAtStartOfDay());
            }
        }
    }
}

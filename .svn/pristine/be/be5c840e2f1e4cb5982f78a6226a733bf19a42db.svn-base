using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class CokerCardCycleStepEntryDTODao : AbstractManagedDao, ICokerCardCycleStepEntryDTODao
    {
        private const string QUERY_BY_CONFIG_AND_DATE_RANGE = "QueryCokerCardCycleStepEntryDTOByConfigurationIdsAndDateRange";

        public List<CokerCardCycleStepEntryDTO> QueryByConfigurationIdsAndDateRange(List<long> configurationIds, Date startOfRange, Date endOfRange)
        {
            SqlCommand command = ManagedCommand;
            string configurationIdList = configurationIds.BuildCommaSeparatedList(Convert.ToString);

            command.AddParameter("@ConfigurationIds", configurationIdList);
            command.AddParameter("@StartOfRange",  startOfRange.CreateDateTime(Time.START_OF_DAY));
            command.AddParameter("@EndOfRange",  endOfRange.CreateDateTime(Time.END_OF_DAY));

            return command.QueryForListResult<CokerCardCycleStepEntryDTO>(PopulateInstance , QUERY_BY_CONFIG_AND_DATE_RANGE);      
        }

        private static CokerCardCycleStepEntryDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string drum = reader.Get<string>("Drum");
            string cycle = reader.Get<string>("Cycle");
            string shiftName = reader.Get<string>("ShiftName");
            DateTime shiftStartDate = reader.Get<DateTime>("ShiftStartDate");
            DateTime startDateTime = reader.Get<DateTime>("StartTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndTime");
            string comments = reader.Get<string>("Comments");
                       
            return new CokerCardCycleStepEntryDTO(id, drum, cycle, startDateTime, endDateTime, shiftName, shiftStartDate, comments);
        }

    }
}

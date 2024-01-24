using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class CokerCardDTODao : AbstractManagedDao, ICokerCardDTODao
    {
        private const string QUERY_BY_FLOC_ID_STORED_PROCEDURE = "QueryCokerCardDTOsByFLOCIDsAndDateRange";

        public List<CokerCardDTO> QueryByExactFlocMatch(
            ExactFlocSet flocSet, DateRange dateRange)
        {
            string commaIDs = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@IDs", commaIDs);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<CokerCardDTO>(PopulateInstance , QUERY_BY_FLOC_ID_STORED_PROCEDURE);
        }

        private static CokerCardDTO PopulateInstance(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("CreatedByFirstName");
            string lastName = reader.Get<string>("CreatedByLastName");
            string userName = reader.Get<string>("CreatedByUserName");

            CokerCardDTO dto = new CokerCardDTO(
                reader.Get<long>("Id"),
                reader.Get<string>("CokerCardConfigurationName"),
                reader.Get<string>("FunctionalLocationName"),
                reader.Get<string>("WorkAssignmentName"),
                reader.Get<long>("ShiftId"),
                reader.Get<string>("ShiftName"),
                new Date(reader.Get<DateTime>("ShiftStartDate")),
                reader.Get<long>("CreatedByUserId"),
                User.ToFullNameWithUserName(lastName, firstName, userName),
                reader.Get<DateTime>("CreatedDateTime"));

            return dto;
        }
    }
}

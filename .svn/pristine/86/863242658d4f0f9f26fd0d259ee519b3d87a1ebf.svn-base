using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class ConfinedSpaceDTODao : AbstractManagedDao, IConfinedSpaceDTODao
    {
        private string QUERY_BY_FLOC_STORED_PROCEDURE = "QueryConfinedSpaceDTOsByFlocUnitAndBelow";

        public List<ConfinedSpaceDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@FlocIds", flocids);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<ConfinedSpaceDTO>(PopulateInstance, QUERY_BY_FLOC_STORED_PROCEDURE);
        }

        private static ConfinedSpaceDTO PopulateInstance(SqlDataReader reader)
        {
            string firstName = reader.Get<string>("LastModifiedByFirstName");
            string lastName = reader.Get<string>("LastModifiedByLastName");
            string userName = reader.Get<string>("LastModifiedByUserName");

            string fullNameWithUserName = User.ToFullNameWithUserName(lastName, firstName, userName);

            ConfinedSpaceDTO confinedSpace = new ConfinedSpaceDTO(
                reader.Get<long>("Id"),
                reader.Get<long>("ConfinedSpaceNumber"),
                reader.Get<string>("FunctionalLocationName"),
                reader.Get<DateTime>("StartDateTime"),
                reader.Get<long>("CreatedByUserId"),
                fullNameWithUserName,
                reader.Get<int>("ConfinedSpaceStatus"));

            return confinedSpace;
        }

    }
}
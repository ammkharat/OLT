using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class RestrictionDefinitionDTODao : AbstractManagedDao, IRestrictionDefinitionDTODao
    {
        private const string QUERY_BY_FLOC_ID_STORED_PROCEDURE = "QueryRestrictionDefinitionDTOsByFLOCIDs";

        public List<RestrictionDefinitionDTO> QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(IFlocSet flocSet, DateRange dateRange)
        {
            string commaIDs = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@IDs", commaIDs);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<RestrictionDefinitionDTO>(PopulateInstance , QUERY_BY_FLOC_ID_STORED_PROCEDURE);
        }

        private static RestrictionDefinitionDTO PopulateInstance(SqlDataReader reader)
        {
            long statusId = reader.Get<long>("RestrictionDefinitionStatusID");

            string lastModifiedLastName = reader.Get<string>("LastModifiedLastName");
            string lastModifiedFirstName = reader.Get<string>("LastModifiedFirstName");
            string lastModifiedUserName = reader.Get<string>("LastModifiedUserName");
            string lastModifiedByFullNameWithUserName = User.ToFullNameWithUserName(lastModifiedLastName, lastModifiedFirstName, lastModifiedUserName);

            RestrictionDefinitionDTO definition = new RestrictionDefinitionDTO(
                reader.Get<long?>("Id"),
                statusId,
                RestrictionDefinitionStatus.Get(statusId).Name,
                reader.Get<bool>("IsActive"),
                reader.Get<bool>("IsOnlyVisibleOnReports"),
                reader.Get<string>("FunctionalLocationName"),
                reader.Get<string>("Name"),
                reader.Get<string>("MeasurementTagName"),
                reader.Get<int?>("ProductionTargetValue"),
                reader.Get<string>("ProductionTargetTagName"),
                reader.Get<string>("Description"),
                reader.Get<long>("LastModifiedUserId"),
                lastModifiedByFullNameWithUserName);

            return definition;
        }
    }
}

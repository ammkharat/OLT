using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class LabAlertDefinitionDTODao : AbstractManagedDao, ILabAlertDefinitionDTODao
    {
        private const string QUERY_BY_FLOC_ID_STORED_PROCEDURE = "QueryLabAlertDefinitionDTOsByFLOCIDs";

        public List<LabAlertDefinitionDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(IFlocSet flocSet, DateRange dateRange)
        {
            string commaIDs = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@IDs", commaIDs);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<LabAlertDefinitionDTO>(PopulateInstance , QUERY_BY_FLOC_ID_STORED_PROCEDURE);
        }

        private static LabAlertDefinitionDTO PopulateInstance(SqlDataReader reader)
        {
            long statusId = reader.Get<long>("LabAlertDefinitionStatusID");

            string lastModifiedLastName = reader.Get<string>("LastModifiedLastName");
            string lastModifiedFirstName = reader.Get<string>("LastModifiedFirstName");
            string lastModifiedUserName = reader.Get<string>("LastModifiedUserName");
            string lastModifiedByFullNameWithUserName = User.ToFullNameWithUserName(lastModifiedLastName, lastModifiedFirstName, lastModifiedUserName);

            LabAlertDefinitionDTO definition = new LabAlertDefinitionDTO(
                reader.Get<long?>("Id"),
                statusId,
                LabAlertDefinitionStatus.Get(statusId).Name,
                reader.Get<bool>("IsActive"),
                reader.Get<string>("FunctionalLocationName"),
                reader.Get<string>("Name"),
                reader.Get<string>("TagName"),
                reader.Get<string>("Description"),
                reader.Get<long>("LastModifiedByUserId"),
                lastModifiedByFullNameWithUserName);

            return definition;
        }
    }
}

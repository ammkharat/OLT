using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class LabAlertDTODao : AbstractManagedDao, ILabAlertDTODao
    {
        private const string QUERY_BY_FLOC_ID_STORED_PROCEDURE = "QueryLabAlertDTOsByFLOCIDs";

        public List<LabAlertDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(IFlocSet flocSet, DateRange dateRange, List<LabAlertStatus> statuses)
        {
            string commaIDs = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@IDs", commaIDs);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);
            if (statuses != null)
            {
                command.AddParameter("@StatusIds", statuses.BuildIdStringFromList());
            }

            return command.QueryForListResult<LabAlertDTO>(PopulateInstance, QUERY_BY_FLOC_ID_STORED_PROCEDURE);
        }

        private static LabAlertDTO PopulateInstance(SqlDataReader reader)
        {
            LabAlertDTO definition = new LabAlertDTO(
                reader.Get<long?>("Id"),
                reader.Get<long>("LabAlertStatusID"),
                reader.Get<string>("FunctionalLocationName"),
                reader.Get<string>("Name"),
                reader.Get<string>("TagName"),
                reader.Get<int>("MinimumNumberOfSamples"),
                reader.Get<int>("ActualNumberOfSamples"),
                reader.Get<DateTime>("CreatedDateTime"),
                reader.Get<long>("LastModifiedByUserId"));

            return definition;
        }
    }
}

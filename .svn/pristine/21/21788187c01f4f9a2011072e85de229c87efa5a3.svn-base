using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class WorkPermitEdmontonHazardDTODao : AbstractManagedDao, IWorkPermitEdmontonHazardDTODao
    {
        private const string QUERY_BY_FLOCS_AND_STATUSES = "QueryWorkPermitEdmontonHazardDTOByFlocIdsAndStatusIds";

        public List<WorkPermitEdmontonHazardDTO> QueryByFlocsAndStatus(IFlocSet flocSet, List<PermitRequestBasedWorkPermitStatus> statuses)
        {
            SqlCommand command = ManagedCommand;
            string csvFLOCIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            string csvStatusIds = statuses.BuildIdStringFromList();

            command.AddParameter("@FlocIds", csvFLOCIds);
            command.AddParameter("@StatusIds", csvStatusIds);

            return command.QueryForListResult<WorkPermitEdmontonHazardDTO>(PopulateInstance, QUERY_BY_FLOCS_AND_STATUSES);
        }

        private static WorkPermitEdmontonHazardDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int dataSourceId = reader.Get<int>("DataSourceId");
            int workPermitStatusId = reader.Get<int>("WorkPermitStatusId");
            DateTime? issuedDateTime = reader.Get<DateTime?>("IssuedDateTime");
            string occupation = reader.Get<string>("Occupation");
            string description = reader.Get<string>("TaskDescription");
            string hazards = reader.Get<string>("HazardsAndOrRequirements");
            string createdByFirstName = reader.Get<string>("CreatedByFirstName");
            string createdByLastName = reader.Get<string>("CreatedByLastName");
            string createdByUserName = reader.Get<string>("CreatedByUserName");
            string createdByFullNameWithUserName = null;

            if (createdByFirstName != null && createdByLastName != null && createdByUserName != null)
            {
                createdByFullNameWithUserName = User.ToFullNameWithUserName(createdByLastName, createdByFirstName, createdByUserName);
            }

            return new WorkPermitEdmontonHazardDTO(id, dataSourceId, workPermitStatusId, issuedDateTime, occupation, description, hazards, createdByFullNameWithUserName);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FunctionalLocationOperationalModeDTODao : AbstractManagedDao, IFunctionalLocationOperationalModeDTODao
    {
        private const string QUERY_ALL = "QueryFunctionalLocationOpModeDTOsBySiteId";
       // private const string QUERY_BY_LEVEL_THREE_AND_BELOW = "QueryFunctionalLocationOpModeDTOByLevelThreeAndBelow";
        private const string QUERY_BY_LEVEL_THREE_TWO_AND_ONE = "QueryFunctionalLocationOpModeDTOByLevelOneTwoThree";

        public List<FunctionalLocationOperationalModeDTO> GetAllBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);

            return command.QueryForListResult<FunctionalLocationOperationalModeDTO>(PopulateInstance , QUERY_ALL);
        }

        public FunctionalLocationOperationalModeDTO GetForLevel3AndBelowFloc(long flocId)
        {
            return ManagedCommand.QueryById<FunctionalLocationOperationalModeDTO>(flocId, PopulateInstance, QUERY_BY_LEVEL_THREE_TWO_AND_ONE);
        }
       
        private FunctionalLocationOperationalModeDTO PopulateInstance(SqlDataReader reader)
        {
            string fullHierarchy = reader.Get<string>("FullHierarchy");
            string description = reader.Get<string>("Description");
            long unitId = reader.Get<long>("UnitId");

            long operationalModeId = reader.Get<long>("OperationalModeId");
            OperationalMode opMode = OperationalMode.GetById(operationalModeId);

            long availabilityReasonId = reader.Get<long>("AvailabilityReasonId");
            AvailabilityReason reason = AvailabilityReason.GetById(availabilityReasonId);

            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            return new FunctionalLocationOperationalModeDTO(unitId, fullHierarchy, description, opMode, reason, lastModifiedDate);
        }
    }
}
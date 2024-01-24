using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class DeviationAlertDTODao : AbstractManagedDao, IDeviationAlertDTODao
    {
        private const string QUERY_BY_FLOC_LIST_FOR_DATE_RANGE_STORED_PROCEDURE = "QueryDeviationAlertDTOsByFLOCIdsAndDateRange";
        private const string QUERY_BY_FLOC_LIST_WITH_OVERLAP_IN_DATE_RANGE_STORED_PROCEDURE = "QueryDeviationAlertDTOsByFLOCIdsWithOverlapInDateRange";

        public List<DeviationAlertDTO> QueryByFunctionalLocationsAndTimePeriod(
            IFlocSet flocSet, DateTime? fromDateTime, DateTime? toDateTime)
        {
            if (fromDateTime.HasNoValue())
            {
                fromDateTime = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            if (toDateTime.HasNoValue())
            {
                toDateTime = DateTimeExtensions.CreateSQLServerFriendlyMaxDate();
            }

            SqlCommand command = ManagedCommand;

            command.AddParameter("@Ids", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@FromDate", fromDateTime);
            command.AddParameter("@ToDate", toDateTime);

            return command.QueryForListResult<DeviationAlertDTO>(PopulateInstance , QUERY_BY_FLOC_LIST_FOR_DATE_RANGE_STORED_PROCEDURE);            
        }

        public List<DeviationAlertDTO> QueryByFunctionalLocationsAndOverlapInDateRange(
            IFlocSet flocSet, DateTime fromDateTime, DateTime toDateTime)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@Ids", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@FromDate", fromDateTime);
            command.AddParameter("@ToDate", toDateTime);

            return command.QueryForListResult<DeviationAlertDTO>(PopulateInstance , QUERY_BY_FLOC_LIST_WITH_OVERLAP_IN_DATE_RANGE_STORED_PROCEDURE); 
        }

        private DeviationAlertDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            long? responseId = reader.Get<long?>("DeviationAlertResponseId");
            string restrictionDefinitionName = reader.Get<string>("RestrictionDefinitionName");
            string restrictionDefinitionDescription = reader.Get<string>("RestrictionDefinitionDescription");
            long restrictionDefinitionId = reader.Get<long>("RestrictionDefinitionId");
            int? productionTargetValue = reader.Get<int?>("ProductionTargetValue");
            int? measurementValue = reader.Get<int?>("MeasurementValue");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");
            string functionalLocationName = reader.Get<string>("FunctionalLocationName");
            string productionTargetValueTagName = reader.Get<string>("ProductionTargetValueTagName");
            string measurementValueTagName = reader.Get<string>("MeasurementValueTagName");
            string measurementValueTagUnit = reader.Get<string>("MeasurementValueTagUnit");
            string productionTargetValueTagUnit = reader.Get<string>("ProductionTargetValueTagUnit");

            long lastModifiedUserId = reader.Get<long>("LastModifiedUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            //Added by Mukesh for RITM0219490
            int? ToleranceValue = reader.Get<int>("ToleranceValue");

            DeviationAlertDTO deviationAlertDto = new DeviationAlertDTO(
                id,
                restrictionDefinitionName, 
                restrictionDefinitionDescription,
                productionTargetValue, 
                measurementValue, 
                startDateTime, 
                endDateTime, 
                functionalLocationName, 
                productionTargetValueTagName, 
                measurementValueTagName, 
                measurementValueTagUnit,
                productionTargetValueTagUnit,
                restrictionDefinitionId,
                DeviationAlert.GetStatus(responseId != null, DeviationAlert.GetDeviationValue(measurementValue, productionTargetValue), ToleranceValue),
                responseId != null,
                lastModifiedUserId,
                lastModifiedDateTime,
                createdDateTime);
           
            return deviationAlertDto;
        }
    }
}

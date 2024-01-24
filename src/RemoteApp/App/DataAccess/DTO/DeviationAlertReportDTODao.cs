using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class DeviationAlertReportDTODao : AbstractManagedDao, IDeviationAlertReportDTODao
    {
        private const string QUERY_BY_DATE_RANGE_AND_PARENT_FUNCTIONAL_LOCATION_STORED_PROCEDURE = 
            "QueryDeviationAlertReportDTOsByDateRangeAndParentFloc";

        public List<DeviationAlertReportDTO> QueryByDateRangeAndParentFunctionalLocation(
            Date startDate, Date endDate, IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Ids", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@FromDate", startDate.CreateDateTime(Time.START_OF_DAY));
            command.AddParameter("@ToDate", endDate.CreateDateTime(Time.START_OF_DAY).AddDays(1));
            return command.QueryForListResult<DeviationAlertReportDTO>(PopulateInstance , QUERY_BY_DATE_RANGE_AND_PARENT_FUNCTIONAL_LOCATION_STORED_PROCEDURE);
        }

        private DeviationAlertReportDTO PopulateInstance(SqlDataReader reader)
        {
            DeviationAlertReportDTO deviationAlertDto = new DeviationAlertReportDTO(
                reader.Get<long>("Id"),
                reader.Get<string>("RestrictionDefinitionName"),
                reader.Get<string>("AlertFlocFullHierarchy"), 
                reader.Get<string>("MeasurementTagName"), 
                reader.Get<int?>("MeasurementValue"),
                reader.Get<string>("ProductionTargetTagName"), 
                reader.Get<int?>("ProductionTargetValue"),
                reader.Get<DateTime>("StartDateTime"), 
                reader.Get<DateTime>("EndDateTime"), 
                reader.Get<bool>("IsHiddenDeviation"),
                reader.Get<string>("ReasonCodeName"), 
                reader.Get<int?>("AssignedAmount"),
                reader.Get<string>("PlantState"),
                reader.Get<string>("ReasonCodeFlocFullHierarchy"),
                reader.Get<string>("ReasonCodeFlocDescription"),
                reader.Get<string>("ReasonCodeAssignmentComments"));
            return deviationAlertDto;
        }
    }
}

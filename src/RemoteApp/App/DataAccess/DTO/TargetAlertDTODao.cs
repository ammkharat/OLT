using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class TargetAlertDTODao : AbstractManagedDao, ITargetAlertDTODao
    {
        private const string QUERY_BY_FLOCS_AND_STATUSES_STORED_PROCEDURE = "QueryTargetAlertDTOsByFLOCsAndStatuses";
        private const string QUERY_BY_FLOCS_AND_STATUSES_AND_DATE_OF_LAST_VIOLATION_STORED_PROCEDURE = "QueryTargetAlertDTOsByFLOCsAndStatusesAndDateOfLastViolation";

        private readonly ITargetAlertResponseDao targetAlertResponseDao;
        private readonly ITargetAlertDao targetAlertDao;

        public TargetAlertDTODao()
        {
            targetAlertResponseDao = DaoRegistry.GetDao<ITargetAlertResponseDao>();
            targetAlertDao = DaoRegistry.GetDao<ITargetAlertDao>();
        }

        public List<TargetAlertDTO> QueryByFunctionalLocationsAndStatuses(IFlocSet flocSet, List<TargetAlertStatus> statuses, DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvStatusIds", statuses.BuildIdStringFromList());
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<TargetAlertDTO>(PopulateInstance, QUERY_BY_FLOCS_AND_STATUSES_STORED_PROCEDURE);
        }

        public List<TargetAlertExcelReportDTO> QueryForExcelReport(IFlocSet flocSet, List<TargetAlertStatus> statuses, DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvStatusIds", statuses.BuildIdStringFromList());
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<TargetAlertExcelReportDTO>(PopulateInstanceForExcelReport,
                                              QUERY_BY_FLOCS_AND_STATUSES_AND_DATE_OF_LAST_VIOLATION_STORED_PROCEDURE);            
        }

        private TargetAlertDTO PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            string targetName = reader.Get<string>("TargetName");
            string flocName = reader.Get<string>("FunctionalLocationName");
            TargetCategory targetCategory = TargetCategory.GetTargetCategory(reader.Get<long>("TargetCategoryID"));
            string categoryName = targetCategory.Name;

            string description = reader.Get<string>("Description");
            TargetValue targetValue = ReadTargetValue(reader);
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            DateTime? acknowledgedDateTime = reader.Get<DateTime?>("AcknowledgedDateTime");
            TargetAlertStatus status = ReadTargetAlertStatus(reader, "TargetAlertStatusId");
            Priority priority = Priority.GetById(reader.Get<long>("PriorityId"));

            decimal? neverToExceedMax = reader.Get<decimal?>("NeverToExceedMax");
            decimal? maxValue = reader.Get<decimal?>("MaxValue");
            decimal? minValue = reader.Get<decimal?>("MinValue");
            decimal? neverToExceedMin = reader.Get<decimal?>("NeverToExceedMin");
            decimal? gapUnitValue = reader.Get<decimal?>("GapUnitValue");
            decimal? actualValue = reader.Get<decimal?>("ActualValue");
                        
            DateTime lastViolatedDateTime = reader.Get<DateTime>("LastViolatedDateTime");

            decimal? losses = TargetAlert.CalculateLosses(actualValue,
                                                          neverToExceedMax,
                                                          maxValue,
                                                          minValue,
                                                          neverToExceedMin,
                                                          gapUnitValue);

            bool requiresResponse = reader.Get<bool>("RequiresResponse");

            long? lastModifiedUserId = reader.Get<long?>("LastModifiedUserId");

            string workAssignmentName = reader.Get<string>("WorkAssignmentName");

            TargetAlertDTO result = new TargetAlertDTO( id,
                                                        targetName,
                                                        flocName,
                                                        categoryName,
                                                        description,
                                                        targetValue,
                                                        actualValue,
                                                        neverToExceedMax,
                                                        maxValue,
                                                        minValue,
                                                        neverToExceedMin,
                                                        gapUnitValue,
                                                        createdDateTime,
                                                        status,
                                                        priority,
                                                        losses,
                                                        requiresResponse,
                                                        acknowledgedDateTime,
                                                        lastModifiedUserId,
                                                        lastViolatedDateTime,
                                                        workAssignmentName);
           
            return result;
        }

        private TargetAlertExcelReportDTO PopulateInstanceForExcelReport(SqlDataReader reader)
        {
            TargetAlertDTO targetAlertDto = PopulateInstance(reader);

            string targetDefinitionName = reader.Get<string>("TargetDefinitionName");
            bool definitionIsActive = reader.Get<bool>("DefinitionIsActive");
            bool definitionDeleted = reader.Get<bool>("DefinitionDeleted");
            bool isActive = definitionIsActive && !definitionDeleted;

            string tagName = reader.Get<string>("TagName");

            long lastViolatedStatusId = reader.Get<int>("TypeOfViolationStatusId");
            TargetAlertStatus lastViolatedStatus = TargetAlertStatus.Get(lastViolatedStatusId);
            decimal? maxAtEvaluation = reader.Get<decimal?>("MaxAtEvaluation");
            decimal? minAtEvaluation = reader.Get<decimal?>("MinAtEvaluation");
            decimal? nteMaxAtEvaluation = reader.Get<decimal?>("NTEMaxAtEvaluation");
            decimal? nteMinAtEvaluation = reader.Get<decimal?>("NTEMinAtEvaluation");
            decimal? actualValueAtEvaluation = reader.Get<decimal?>("ActualValueAtEvaluation"); 

            TargetAlert targetAlert = targetAlertDao.QueryById(targetAlertDto.IdValue);

            List<TargetAlertResponse> targetAlertResponses = targetAlertResponseDao.QueryByTargetAlert(targetAlert);

            List<TargetAlertResponseReportDetailDTO> targetAlertResponseReportDetailDtos = 
                targetAlertResponses.ConvertAll(tar => new TargetAlertResponseReportDetailDTO(tar.ResponseComment.CreatedBy, tar.ResponseComment.CreatedDate, tar.ResponseComment.Text, tar.GapReason));

            TargetAlertExcelReportDTO excelReportDto = new TargetAlertExcelReportDTO(
                targetAlertDto, targetDefinitionName, isActive, tagName, lastViolatedStatus, maxAtEvaluation, minAtEvaluation, 
                nteMaxAtEvaluation, nteMinAtEvaluation, actualValueAtEvaluation, targetAlertResponseReportDetailDtos);

            return excelReportDto;
        }

        private static TargetValue ReadTargetValue(SqlDataReader reader)
        {
            long targetValueTypeId = reader.Get<long>("TargetValueTypeId");
            decimal? targetValue = reader.Get<decimal?>("TargetAlertValue");
            return TargetValueType.ToTargetValue(targetValueTypeId, targetValue);
        }

        private static TargetAlertStatus ReadTargetAlertStatus(SqlDataReader reader, string columnName)
        {
            long statusId = reader.Get<long>(columnName);
            return TargetAlertStatus.Get(statusId);
        }
    }
}

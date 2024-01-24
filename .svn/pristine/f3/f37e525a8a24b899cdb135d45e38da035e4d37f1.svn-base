using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class SafeWorkPermitAssessmentReportDTODao : AbstractManagedDao, ISafeWorkPermitAssessmentReportDTODao
    {
        private const string QUERY_PERMIT_ASSESSMENT_DTOS_BY_FLOCS =
            "QueryFormOilsandsPermitAssessmentByFunctionalLocationsForExcelDump";

        private readonly ILog logger = GenericLogManager.GetLogger<SafeWorkPermitAssessmentReportDTODao>();

        public List<SafeWorkPermitAssessmentReportDTO> QuerySafeWorkPermitAssessmentReportDTODao(IFlocSet flocSet,
            DateRange dateRange)
        {
            var command = ManagedCommand;
            var sqlFriendlyStart = dateRange.SqlFriendlyStart;
            command.AddParameter("@StartOfDateRange", sqlFriendlyStart);
            var sqlFriendlyEnd = dateRange.SqlFriendlyEnd;
            command.AddParameter("@EndOfDateRange", sqlFriendlyEnd);
            var buildIdStringFromList = flocSet.FunctionalLocations.BuildIdStringFromList();
            command.AddParameter("@CsvFlocIds", buildIdStringFromList);

            logger.Debug("Querying from: " + sqlFriendlyStart.ToShortDateAndTimeString() + " to: " +
                         sqlFriendlyEnd.ToShortDateAndTimeString() + " with: " + buildIdStringFromList);

            return GetDtos(command, QUERY_PERMIT_ASSESSMENT_DTOS_BY_FLOCS);
        }


        private static List<SafeWorkPermitAssessmentReportDTO> GetDtos(SqlCommand command, string query)
        {
            var result = new Dictionary<long, SafeWorkPermitAssessmentReportDTO>();

            command.CommandText = query;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var key = GetId(reader);

                    if (result.ContainsKey(key))
                    {
                        var dto = result[key];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));
                    }
                    else
                    {
                        result.Add(key, PopulateInstance(reader));
                    }
                }
            }

            return new List<SafeWorkPermitAssessmentReportDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }


        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static SafeWorkPermitAssessmentReportDTO PopulateInstance(SqlDataReader reader)
        {
            var id = GetId(reader);
            var site = reader.Get<string>("Site");
            var formNumber = reader.Get<long>("FormNumber");
            var versionNumber = reader.Get<int>("VersionNumber");
            var formStatus = FormStatus.GetById(reader.Get<int>("StatusId")).GetName();
            var floc = GetFunctionalLocationName(reader);
            var locationEquipmentNumber = reader.Get<string>("LocationEquipmentNumber");
            var permitStartDateTime = reader.Get<DateTime>("PermitStartDateTime");
            var permitExpireDateTime = reader.Get<DateTime>("PermitExpireDateTime");
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            var createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName",
                "CreatedByUserName");
            var lastModifiedUserFullNameWithUserName = reader.GetUser("LastModifiedByFirstName",
                "LastModifiedByLastName",
                "LastModifiedByUserName");
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            var isIlpRecommended = reader.Get<bool>("IlpRecommended");
            var permitNumber = reader.Get<string>("PermitNumber");
            var permitType = OilsandsWorkPermitType.Get(reader.Get<int>("PermitType")).Name;
            var issuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            var issuedToContractor = reader.Get<bool>("IssuedToContractor");
            var contractor = reader.Get<string>("Contractor");
            var trade = reader.Get<string>("Trade");
            var jobDescription = reader.Get<string>("JobDescription");
            var jobCoordinator = reader.Get<string>("JobCoordinator");
            var section = reader.Get<string>("Section");
            var questionNumber = reader.Get<int>("QuestionNumber");
            var crewSize = reader.Get<int>("CrewSize");
            var question = reader.Get<string>("Question");
            var score = reader.Get<int>("Score");
            var weight = reader.Get<int>("Weight");
            var overallScore = reader.Get<int>("OverallScore");
            var sectionWeightPercentage = reader.Get<decimal>("SectionWeightPercentage").ToPercent(100);
            var sectionScorePercentage = reader.Get<decimal>("SectionScorePercentage").ToPercent(100);
            var totalScorePercentage = reader.Get<decimal>("TotalScorePercentage").ToPercent(100);
            var feedback = reader.Get<String>("Feedback");
            var questionFeedback = reader.Get<String>("QuestionFeedback");

            return new SafeWorkPermitAssessmentReportDTO(id, site, formNumber, versionNumber, formStatus, floc,
                locationEquipmentNumber, permitStartDateTime, permitExpireDateTime, createdByFullNameWithUserName,
                createdDateTime, lastModifiedUserFullNameWithUserName, lastModifiedDateTime, isIlpRecommended,
                permitNumber, permitType, issuedToSuncor, issuedToContractor, contractor, trade, jobCoordinator,
                jobDescription, section, questionNumber, question, score, weight, overallScore, sectionWeightPercentage,
                sectionScorePercentage, totalScorePercentage, feedback,questionFeedback, crewSize);
        }
    }
}
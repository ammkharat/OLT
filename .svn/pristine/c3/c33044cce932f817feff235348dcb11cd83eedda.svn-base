using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class PermitAssessmentDTODao : AbstractManagedDao, IPermitAssessmentDTODao
    {
        private const string QUERY_PERMIT_ASSESSMENT_DTOS_BY_FLOCS = "QueryFormOilsandsPermitAssessmentByFunctionalLocations";

        public List<PermitAssessmentDTO> QueryPermitAssessmentDtos(IFlocSet flocSet, DateRange dateRange)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());

            return GetDtos(command, QUERY_PERMIT_ASSESSMENT_DTOS_BY_FLOCS);
        }


        private static List<PermitAssessmentDTO> GetDtos(SqlCommand command, string query)
        {
            var result = new Dictionary<long, PermitAssessmentDTO>();

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

            return new List<PermitAssessmentDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }


        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static PermitAssessmentDTO PopulateInstance(SqlDataReader reader)
        {
            var id = GetId(reader);
            var floc = GetFunctionalLocationName(reader);


            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var createdByUserId = reader.Get<long>("CreatedByUserId");
            var createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName",
                "CreatedByUserName");

            var lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            var validFrom = reader.Get<DateTime>("ValidFromDateTime");
            var validTo = reader.Get<DateTime>("ValidToDateTime");
            var lastModifiedOn = reader.Get<DateTime>("LastModifiedDateTime");
            var oilsandsWorkPermitType = OilsandsWorkPermitType.Get(reader.Get<int>("OilsandsWorkPermitType"));
            var overallFeedback = reader.Get<String>("OverallFeedback");
            var jobDescription = reader.Get<String>("JobDescription");
            var totalScoredPercentage = reader.Get<decimal>("TotalScoredPercentage");
            var permitNumber = reader.Get<string>("PermitNumber");

            var creationUserShiftPatternId = reader.Get<long>("CreationUserShiftPatternId");

            var lastModifiedUserFullNameWithUserName = reader.GetUser("LastModifiedByFirstName",
                "LastModifiedByLastName",
                "LastModifiedByUserName");


            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            
            bool isIlpRecommended = reader.Get<Boolean>("IsIlpRecommended");

            return new PermitAssessmentDTO(id, new List<string> {floc}, createdByUserId, createdByFullNameWithUserName,
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus,
                lastModifiedUserFullNameWithUserName,
                oilsandsWorkPermitType, permitNumber, totalScoredPercentage, jobDescription, overallFeedback,
                lastModifiedOn, isIlpRecommended, creationUserShiftPatternId);
        }
    }
}
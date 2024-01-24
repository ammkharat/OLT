using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FormOilsandsTrainingDTODao : AbstractManagedDao, IFormOilsandsTrainingDTODao
    {
        private const string QUERY_BY_FLOCS_AND_DATE_RANGE = "QueryFormOilsandsTrainingDTOsByFunctionalLocationsAndDateRange";

        public List<FormOilsandsTrainingDTO> QueryByFunctionalLocationsAndDateRange(IFlocSet flocSet, DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());

            List<FormOilsandsTrainingDTO> result = GetDtos(command, QUERY_BY_FLOCS_AND_DATE_RANGE);

            return result;
        }

        private static List<FormOilsandsTrainingDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormOilsandsTrainingDTO> result = new Dictionary<long, FormOilsandsTrainingDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);

                    if (result.ContainsKey(id))
                    {
                        FormOilsandsTrainingDTO dto = result[id];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<FormOilsandsTrainingDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static FormOilsandsTrainingDTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            decimal totalHours = reader.Get<decimal>("TotalHours");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            Date trainingDate = reader.Get<DateTime>("TrainingDate").ToDate();

            string shiftName = reader.Get<string>("ShiftName");

            string assignmentName = reader.Get<string>("WorkAssignmentName");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");

            long createdByRoleId = reader.Get<long>("CreatedByRoleId");

            FormOilsandsTrainingDTO result = new FormOilsandsTrainingDTO(id, new List<string> { floc }, totalHours, assignmentName, createdByUserId, createdByFullNameWithUserName, 
                    createdDateTime, lastModifiedDateTime, lastModifiedByUserId, trainingDate, shiftName, formStatus, approvedDateTime, createdByRoleId);

            return result;
        }

    }
}

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
    public class FormOilsandsPriorityPageDTODao : AbstractManagedDao, IFormOilsandsPriorityPageDTODao
    {
        private const string QUERY_AWAITING_APPROVAL = "QueryFormOilsandsPriorityPageDTOsAwaitingApprovalByFunctionalLocationsAndDateRange";

        public List<FormOilsandsPriorityPageDTO> QueryAwaitingApprovalByFunctionalLocationsAndDateRange(IFlocSet flocSet, DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());

            return GetDtos(command, QUERY_AWAITING_APPROVAL);
        }

        private static List<FormOilsandsPriorityPageDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<string, FormOilsandsPriorityPageDTO> result = new Dictionary<string, FormOilsandsPriorityPageDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    OilsandsFormType formType = GetFormType(reader);
                    string key = GetKey(id, formType);

                    if (result.ContainsKey(key))
                    {
                        FormOilsandsPriorityPageDTO dto = result[key];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));                     
                    }
                    else
                    {
                        result.Add(key, PopulateInstance(reader));
                    }
                }
            }

            return new List<FormOilsandsPriorityPageDTO>(result.Values);
        }
     
        private static string GetKey(long id, OilsandsFormType formType)
        {
            return String.Format("{0}_{1}", id, formType);
        }

        private static OilsandsFormType GetFormType(SqlDataReader reader)
        {
            return OilsandsFormType.GetById(reader.Get<int>("FormTypeId"));
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static FormOilsandsPriorityPageDTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            OilsandsFormType formType = GetFormType(reader);

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUserFullName("CreatedByFirstName", "CreatedByLastName");

            string workAssignmentName = reader.Get<string>("WorkAssignmentName");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            Date trainingDate = reader.Get<DateTime>("TrainingDate").ToDate();

            string shiftName = reader.Get<string>("ShiftName");

            decimal totalHours = reader.Get<decimal>("TotalHours");

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            
            FormOilsandsPriorityPageDTO result = new FormOilsandsPriorityPageDTO(
                id, new List<string> { floc }, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime, 
                    lastModifiedByUserId, trainingDate, shiftName, formStatus, workAssignmentName, totalHours);

            return result;
        }
    }
}

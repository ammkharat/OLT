using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FormOilsandsTrainingReportDTODao : AbstractManagedDao, IFormOilsandsTrainingReportDTODao
    {
        private const string QUERY_REPORT_DATA = "QueryFormOilsandsTrainingReportData";
        
        public List<FormOilsandsTrainingReportDTO> QueryFormOilsandsTrainingReportData(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<WorkAssignment> workAssignments)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartDateTime", startDateTime);
            command.AddParameter("@EndDateTime", endDateTime);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvAssignmentIds", workAssignments.BuildIdStringFromList());

            return GetDtos(command, QUERY_REPORT_DATA);
        }

        private static List<FormOilsandsTrainingReportDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormOilsandsTrainingReportDTO> result = new Dictionary<long, FormOilsandsTrainingReportDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetItemId(reader);

                    if (result.ContainsKey(id))
                    {
                        FormOilsandsTrainingReportDTO dto = result[id];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<FormOilsandsTrainingReportDTO>(result.Values);
        }

        private static long GetFormId(SqlDataReader reader)
        {
            return reader.Get<long>("FormId");
        }

        private static long GetItemId(SqlDataReader reader)
        {
            return reader.Get<long>("ItemId");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static FormOilsandsTrainingReportDTO PopulateInstance(SqlDataReader reader)
        {
            long formId = GetFormId(reader);
            long itemId = GetItemId(reader);
            string floc = GetFunctionalLocationName(reader);

            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");
            
            string createdByAssignmentName = reader.Get<string>("CreatedByWorkAssignmentName");

            Date trainingDate = reader.Get<DateTime>("TrainingDate").ToDate();
            string trainingShiftName = reader.Get<string>("ShiftName");
            string trainingDateString = String.Format("{0} - {1}", trainingDate.ToDateTimeAtStartOfDay().ToShortDateString(), trainingShiftName);

            string badge = reader.Get<string>("Badge");
            string blockName = reader.Get<string>("TrainingBlockName");
            string trainingCode = reader.Get<string>("TrainingBlockCode");
            string comments = reader.Get<string>("Comments");
            decimal hours = reader.Get<decimal>("Hours");
            bool blockCompleted = reader.Get<bool>("BlockCompleted");

            string approver = reader.Get<string>("Approver");
            string approvedByFullNameWithUserName = reader.GetUser("ApprovedByUserFirstName", "ApprovedByUserLastName", "ApprovedByUserUserName");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");

            string generalComments = reader.Get<string>("GeneralComments");

            return new FormOilsandsTrainingReportDTO(formId, itemId, formStatus, new List<string> { floc }, trainingDateString, createdByAssignmentName, createdByFullNameWithUserName, badge, createdDateTime, blockName, trainingCode, comments, hours, blockCompleted, approver, approvedByFullNameWithUserName, approvedDateTime, generalComments);
        }
    }
}

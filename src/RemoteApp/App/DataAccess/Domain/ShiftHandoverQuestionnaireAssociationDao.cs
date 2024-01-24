using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverQuestionnaireAssociationDao : AbstractManagedDao, IShiftHandoverQuestionnaireAssociationDao
    {
        public void InsertLogAssocications(ShiftHandoverQuestionnaire questionnaire)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", questionnaire.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@WorkAssignmentId", questionnaire.Assignment.IdValue);
            command.AddParameter("@StartOfDateRange", questionnaire.CreatedShiftStartDateWithPadding);
            command.AddParameter("@EndOfDateRange", questionnaire.CreatedShiftEndDateWithPadding);
            command.AddParameter("@ShiftHandoverQuestionnaireId", questionnaire.IdValue);
            command.AddParameter("@ShiftId", questionnaire.Shift.IdValue);
            command.ExecuteNonQuery("InsertShiftHandoverLogAssociationsForNewShiftHandover");

        }

        public void InsertLogAssocications(Log log)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", log.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@WorkAssignmentId", log.WorkAssignment.IdValue);
            command.AddParameter("@StartOfDateRange", log.CreatedShiftStartDateWithPadding);
            command.AddParameter("@EndOfDateRange", log.CreatedShiftEndDateWithPadding);
            command.AddParameter("@LogId", log.IdValue);
            command.AddParameter("@ShiftId", log.CreatedShiftPattern.IdValue);

            command.ExecuteNonQuery("InsertShiftHandoverLogAssociationsForNewLog");
        }

        public void InsertSummaryLogAssocications(ShiftHandoverQuestionnaire questionnaire)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", questionnaire.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@WorkAssignmentId", questionnaire.Assignment.IdValue);
            command.AddParameter("@StartOfDateRange", questionnaire.CreatedShiftStartDateWithPadding);
            command.AddParameter("@EndOfDateRange", questionnaire.CreatedShiftEndDateWithPadding);
            command.AddParameter("@ShiftHandoverQuestionnaireId", questionnaire.IdValue);
            command.AddParameter("@ShiftId", questionnaire.Shift.IdValue);
            command.ExecuteNonQuery("InsertShiftHandoverSummaryLogAssociationsForNewShiftHandover");
        }

        public void InsertSummaryLogAssocications(SummaryLog summaryLog)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", summaryLog.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@WorkAssignmentId", summaryLog.WorkAssignment.IdValue);
            command.AddParameter("@StartOfDateRange", summaryLog.CreatedShiftStartDateWithPadding);
            command.AddParameter("@EndOfDateRange", summaryLog.CreatedShiftEndDateWithPadding);
            command.AddParameter("@SummaryLogId", summaryLog.IdValue);
            command.AddParameter("@ShiftId", summaryLog.CreatedShiftPattern.IdValue);
            command.ExecuteNonQuery("InsertShiftHandoverSummaryLogAssociationsForNewSummaryLog");
        }

        public void UpdateSummaryLogAssociations(SummaryLog log)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "DeleteShiftHandoverQuestionnaireSummaryLogAssocationsForSummaryLog";
            command.Parameters.Clear();
            command.AddParameter("@SummaryLogId", log.Id);
            command.ExecuteNonQuery();

            InsertSummaryLogAssocications(log);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ProcedureDeviationHistoryDao : AbstractManagedDao, IProcedureDeviationHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryProcedureDeviationHistoryById";
        private const string INSERT = "InsertProcedureDeviationHistory";

        private readonly IUserDao userDao;

        public ProcedureDeviationHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<ProcedureDeviationHistory> GetById(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(ProcedureDeviationHistory history)
        {
            var command = ManagedCommand;

            var idParameter = command.Parameters.Add("@ProcedureDeviationHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(ProcedureDeviationHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("@FormStatusId", history.FormStatus.Id);
            command.AddParameter("@DeviationType", history.Type.Id);

            command.AddParameter("@ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("@ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("@PermanentRevisionRequired", history.PermanentRevisionRequired);
            command.AddParameter("@RevertedBackToOriginal", history.RevertedBackToOriginal);
            command.AddParameter("@LocationEquipmentNumber", history.LocationEquipmentNumber);

            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);

            command.AddParameter("FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("@NumberOfExtensions", history.NumberOfExtensions);
            command.AddParameter("@ReasonsForExtension", history.ReasonsForExtension);

            command.AddParameter("@OperatingProcedureNumber", history.OperatingProcedureNumber);
            command.AddParameter("@OperatingProcedureTitle", history.OperatingProcedureTitle);
            command.AddParameter("@OperatingProcedureLevel", history.OperatingProcedureLevel.Id);

            command.AddParameter("@Description", history.Description);

            command.AddParameter("@CauseDeterminationCauses", history.CauseDeterminationCauses);
            command.AddParameter("@CauseDeterminationCategory", history.CauseDeterminationCategory);
            command.AddParameter("@CauseDeterminationComments", history.CauseDeterminationComments);
            command.AddParameter("@FixDocumentDurationType", history.FixDocumentDurationType.Id);
            command.AddParameter("@CorrectiveActionIlpNumber", history.CorrectiveActionIlpNumber);
            command.AddParameter("@CorrectiveActionWorkRequestNumber", history.CorrectiveActionWorkRequestNumber);
            command.AddParameter("@CorrectiveActionOtherComments", history.CorrectiveActionOtherComments);

            command.AddParameter("@AffectsToe", history.AffectsToe);
            command.AddParameter("@RiskAssessmentAttendee1Type", history.RiskAssessmentAttendee1Type.Id);
            command.AddParameter("@RiskAssessmentAttendee1Name", history.RiskAssessmentAttendee1Name);
            command.AddParameter("@RiskAssessmentAttendee2Type", history.RiskAssessmentAttendee2Type.Id);
            command.AddParameter("@RiskAssessmentAttendee2Name", history.RiskAssessmentAttendee2Name);
            command.AddParameter("@RiskAssessmentAttendee3Type", history.RiskAssessmentAttendee3Type.Id);
            command.AddParameter("@RiskAssessmentAttendee3Name", history.RiskAssessmentAttendee3Name);
            command.AddParameter("@RiskAssessmentAttendee4Type", history.RiskAssessmentAttendee4Type.Id);
            command.AddParameter("@RiskAssessmentAttendee4Name", history.RiskAssessmentAttendee4Name);
            command.AddParameter("@RiskAssessmentAnswer1", history.RiskAssessmentAnswer1);
            command.AddParameter("@RiskAssessmentAnswer2", history.RiskAssessmentAnswer2);
            command.AddParameter("@RiskAssessmentAnswer3", history.RiskAssessmentAnswer3);
            command.AddParameter("@RiskAssessmentAnswer4", history.RiskAssessmentAnswer4);
            command.AddParameter("@RiskAssessmentAnswer5", history.RiskAssessmentAnswer5);
            command.AddParameter("@RiskAssessmentComments", history.RiskAssessmentComments);

            command.AddParameter("@ImmediateApprovalsApprover1Type", history.ImmediateApprovalsApprover1Type.Id);
            command.AddParameter("@ImmediateApprovalsApprover1Title", history.ImmediateApprovalsApprover1Title);
            command.AddParameter("@ImmediateApprovalsApprover1Name", history.ImmediateApprovalsApprover1Name);
            command.AddParameter("@ImmediateApprovalsApprover1ObtainedVia",
                history.ImmediateApprovalsApprover1ObtainedVia.Id);
            command.AddParameter("@ImmediateApprovalsApprover1ApprovedDateTime",
                history.ImmediateApprovalsApprover1ApprovedDateTime);
            command.AddParameter("@ImmediateApprovalsApprover2Type", history.ImmediateApprovalsApprover2Type.Id);
            command.AddParameter("@ImmediateApprovalsApprover2Title", history.ImmediateApprovalsApprover2Title);
            command.AddParameter("@ImmediateApprovalsApprover2Name", history.ImmediateApprovalsApprover2Name);
            command.AddParameter("@ImmediateApprovalsApprover2ObtainedVia",
                history.ImmediateApprovalsApprover2ObtainedVia.Id);
            command.AddParameter("@ImmediateApprovalsApprover2ApprovedDateTime",
                history.ImmediateApprovalsApprover2ApprovedDateTime);

            command.AddParameter("@TemporaryApprovalsApprover1Type", history.TemporaryApprovalsApprover1Type.Id);
            command.AddParameter("@TemporaryApprovalsApprover1Title", history.TemporaryApprovalsApprover1Title);
            command.AddParameter("@TemporaryApprovalsApprover1Name", history.TemporaryApprovalsApprover1Name);
            command.AddParameter("@TemporaryApprovalsApprover1ObtainedVia",
                history.TemporaryApprovalsApprover1ObtainedVia.Id);
            command.AddParameter("@TemporaryApprovalsApprover1ApprovedDateTime",
                history.TemporaryApprovalsApprover1ApprovedDateTime);
            command.AddParameter("@TemporaryApprovalsApprover2Type", history.TemporaryApprovalsApprover2Type.Id);
            command.AddParameter("@TemporaryApprovalsApprover2Title", history.TemporaryApprovalsApprover2Title);
            command.AddParameter("@TemporaryApprovalsApprover2Name", history.TemporaryApprovalsApprover2Name);
            command.AddParameter("@TemporaryApprovalsApprover2ObtainedVia",
                history.TemporaryApprovalsApprover2ObtainedVia.Id);
            command.AddParameter("@TemporaryApprovalsApprover2ApprovedDateTime",
                history.TemporaryApprovalsApprover2ApprovedDateTime);

            command.AddParameter("@CancelledBy", history.CancelledBy);
            command.AddParameter("@CancelledDateTime", history.CancelledDateTime);
            command.AddParameter("@CancelledReason", history.CancelledReason);
        }

        private ProcedureDeviationHistory PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var deviationType = ProcedureDeviationType.GetById(reader.Get<int>("DeviationType"));
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var startDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var endDateTime = reader.Get<DateTime>("ValidToDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var functionalLocations = reader.Get<string>("FunctionalLocations");
            var documentLinks = reader.Get<string>("DocumentLinks");

            var permanentRevisionRequired = reader.Get<bool>("PermanentRevisionRequired");
            var revertedBackToOriginal = reader.Get<bool>("RevertedBackToOriginal");
            var locationEquipmentNumber = reader.Get<string>("LocationEquipmentNumber");

            var numberOfExtensions = reader.Get<int>("NumberOfExtensions");
            var reasonsForExtension = reader.Get<string>("ReasonsForExtension");

            var operatingProcedureNumber = reader.Get<string>("OperatingProcedureNumber");
            var operatingProcedureTitle = reader.Get<string>("OperatingProcedureTitle");
            var operatingProcedureLevel = OperatingProcedureLevel.GetById(reader.Get<int>("OperatingProcedureLevel"));

            var description = reader.Get<string>("Description");

            var causeDeterminationCauses = reader.Get<string>("CauseDeterminationCauses");
            var causeDeterminationCategory = reader.Get<string>("CauseDeterminationCategory");
            var causeDeterminationComments = reader.Get<string>("CauseDeterminationComments");

            var fixDocumentDurationType =
                CorrectiveActionFixDocumentDurationType.GetById(reader.Get<int>("FixDocumentDurationType"));
            var correctiveActionIlpNumber = reader.Get<string>("CorrectiveActionIlpNumber");
            var correctiveActionWorkRequestNumber = reader.Get<string>("CorrectiveActionWorkRequestNumber");
            var correctiveActionOtherComments = reader.Get<string>("CorrectiveActionOtherComments");

            var affectsToe = reader.Get<bool>("AffectsToe");

            var riskAssessmentAttendee1Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee1Type"));
            var riskAssessmentAttendee1Name = reader.Get<string>("RiskAssessmentAttendee1Name");
            var riskAssessmentAttendee2Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee2Type"));
            var riskAssessmentAttendee2Name = reader.Get<string>("RiskAssessmentAttendee2Name");
            var riskAssessmentAttendee3Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee3Type"));
            var riskAssessmentAttendee3Name = reader.Get<string>("RiskAssessmentAttendee3Name");
            var riskAssessmentAttendee4Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee4Type"));
            var riskAssessmentAttendee4Name = reader.Get<string>("RiskAssessmentAttendee4Name");

            var riskAssessmentAnswer1 = reader.Get<bool>("RiskAssessmentAnswer1");
            var riskAssessmentAnswer2 = reader.Get<bool>("RiskAssessmentAnswer2");
            var riskAssessmentAnswer3 = reader.Get<bool>("RiskAssessmentAnswer3");
            var riskAssessmentAnswer4 = reader.Get<bool>("RiskAssessmentAnswer4");
            var riskAssessmentAnswer5 = reader.Get<bool>("RiskAssessmentAnswer5");
            var riskAssessmentComments = reader.Get<string>("RiskAssessmentComments");

            var immediateApprovalsApprover1Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("ImmediateApprovalsApprover1Type"));
            var immediateApprovalsApprover1Title = reader.Get<string>("ImmediateApprovalsApprover1Title");
            var immediateApprovalsApprover1Name = reader.Get<string>("ImmediateApprovalsApprover1Name");
            var immediateApprovalsApprover1ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("ImmediateApprovalsApprover1ObtainedVia"));
            var immediateApprovalsApprover1ApprovedDateTime =
                reader.Get<DateTime?>("ImmediateApprovalsApprover1ApprovedDateTime");
            var immediateApprovalsApprover2Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("ImmediateApprovalsApprover2Type"));
            var immediateApprovalsApprover2Title = reader.Get<string>("ImmediateApprovalsApprover2Title");
            var immediateApprovalsApprover2Name = reader.Get<string>("ImmediateApprovalsApprover2Name");
            var immediateApprovalsApprover2ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("ImmediateApprovalsApprover2ObtainedVia"));
            var immediateApprovalsApprover2ApprovedDateTime =
                reader.Get<DateTime?>("ImmediateApprovalsApprover2ApprovedDateTime");

            var temporaryApprovalsApprover1Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("TemporaryApprovalsApprover1Type"));
            var temporaryApprovalsApprover1Title = reader.Get<string>("TemporaryApprovalsApprover1Title");
            var temporaryApprovalsApprover1Name = reader.Get<string>("TemporaryApprovalsApprover1Name");
            var temporaryApprovalsApprover1ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("TemporaryApprovalsApprover1ObtainedVia"));
            var temporaryApprovalsApprover1ApprovedDateTime =
                reader.Get<DateTime?>("TemporaryApprovalsApprover1ApprovedDateTime");
            var temporaryApprovalsApprover2Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("TemporaryApprovalsApprover2Type"));
            var temporaryApprovalsApprover2Title = reader.Get<string>("TemporaryApprovalsApprover2Title");
            var temporaryApprovalsApprover2Name = reader.Get<string>("TemporaryApprovalsApprover2Name");
            var temporaryApprovalsApprover2ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("TemporaryApprovalsApprover2ObtainedVia"));
            var temporaryApprovalsApprover2ApprovedDateTime =
                reader.Get<DateTime?>("TemporaryApprovalsApprover2ApprovedDateTime");

            var cancelledBy = reader.Get<string>("CancelledBy");
            var cancelledDateTime = reader.Get<DateTime?>("CancelledDateTime");
            var cancelledReason = reader.Get<string>("CancelledReason");

            var form = new ProcedureDeviationHistory(id,
                startDateTime,
                endDateTime,
                formStatus,
                lastModifiedBy,
                lastModifiedDateTime,
                deviationType,
                permanentRevisionRequired,
                revertedBackToOriginal,
                functionalLocations,
                locationEquipmentNumber,
                documentLinks,
                numberOfExtensions,
                reasonsForExtension,
                operatingProcedureNumber,
                operatingProcedureTitle,
                operatingProcedureLevel,
                description,
                causeDeterminationCauses,
                causeDeterminationCategory,
                causeDeterminationComments,
                fixDocumentDurationType,
                correctiveActionIlpNumber,
                correctiveActionWorkRequestNumber,
                correctiveActionOtherComments,
                affectsToe,
                riskAssessmentAttendee1Type,
                riskAssessmentAttendee1Name,
                riskAssessmentAttendee2Type,
                riskAssessmentAttendee2Name,
                riskAssessmentAttendee3Type,
                riskAssessmentAttendee3Name,
                riskAssessmentAttendee4Type,
                riskAssessmentAttendee4Name,
                riskAssessmentAnswer1,
                riskAssessmentAnswer2,
                riskAssessmentAnswer3,
                riskAssessmentAnswer4,
                riskAssessmentAnswer5,
                riskAssessmentComments,
                immediateApprovalsApprover1Type,
                immediateApprovalsApprover1Title,
                immediateApprovalsApprover1Name,
                immediateApprovalsApprover1ObtainedVia,
                immediateApprovalsApprover1ApprovedDateTime,
                immediateApprovalsApprover2Type,
                immediateApprovalsApprover2Title,
                immediateApprovalsApprover2Name,
                immediateApprovalsApprover2ObtainedVia,
                immediateApprovalsApprover2ApprovedDateTime,
                temporaryApprovalsApprover1Type,
                temporaryApprovalsApprover1Title,
                temporaryApprovalsApprover1Name,
                temporaryApprovalsApprover1ObtainedVia,
                temporaryApprovalsApprover1ApprovedDateTime,
                temporaryApprovalsApprover2Type,
                temporaryApprovalsApprover2Title,
                temporaryApprovalsApprover2Name,
                temporaryApprovalsApprover2ObtainedVia,
                temporaryApprovalsApprover2ApprovedDateTime,
                cancelledBy,
                cancelledDateTime,
                cancelledReason);

            return form;
        }
    }
}
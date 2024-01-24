using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ProcedureDeviationDao : AbstractManagedDao, IProcedureDeviationDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryProcedureDeviationById";
        private const string INSERT_STORED_PROCEDURE = "InsertProcedureDeviation";
        private const string UPDATE_STORED_PROCEDURE = "UpdateProcedureDeviation";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertProcedureDeviationFunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION =
            "DeleteProcedureDeviationFunctionalLocationsByProcedureDeviationId";

        private const string DELETE_FORM_CAUSE_DETERMINATION = "DeleteProcedureDeviationCauseDeterminationCausesByProcedureDeviationId";
        private const string INSERT_FORM_CAUSE_DETERMINATION = "InsertProcedureDeviationCauseDetermination";

        private const string REMOVE_STORED_PROCEDURE = "RemoveProcedureDeviation";

        private readonly ICommentDao commentDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IUserDao userDao;
        private readonly IProcedureDeviationCauseDeterminationDao causeDeterminationDao;

        public ProcedureDeviationDao()
        {
            commentDao = DaoRegistry.GetDao<ICommentDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            causeDeterminationDao = DaoRegistry.GetDao<IProcedureDeviationCauseDeterminationDao>();
        }

        public ProcedureDeviation Insert(ProcedureDeviation form)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            InsertNewComments(form);
            UpdateCauseDeterminationCauses(command, form);
            return form;
        }

        //ayman generic forms
        public ProcedureDeviation QueryByIdAndSiteId(long id,long siteid)
        {
            var command = ManagedCommand;
            return command.QueryByIdAndSiteId(id,siteid, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }
        
        
        public ProcedureDeviation QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Update(ProcedureDeviation form)
        {
            var command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(form);
            InsertNewComments(form);
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            UpdateCauseDeterminationCauses(command, form);
        }

        public void Remove(ProcedureDeviation form)
        {
            var command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormOP14Id);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormProcedureDeviation);
        }

        private void AddUpdateParameters(ProcedureDeviation form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateFunctionalLocations(SqlCommand command, ProcedureDeviation form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@ProcedureDeviationId", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void InsertFunctionalLocations(SqlCommand command, ProcedureDeviation form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (var functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ProcedureDeviationId", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateCauseDeterminationCauses(SqlCommand command, ProcedureDeviation form)
        {
            command.CommandText = DELETE_FORM_CAUSE_DETERMINATION;
            command.Parameters.Clear();
            command.AddParameter("@ProcedureDeviationId", form.Id);
            command.ExecuteNonQuery();

            InsertCauseDeterminationCauses(command, form);
        }

        private void InsertCauseDeterminationCauses(SqlCommand command, ProcedureDeviation form)
        {
            if (!form.CauseDeterminationCauses.IsEmpty())
            {
                command.CommandText = INSERT_FORM_CAUSE_DETERMINATION;
                foreach (var cause in form.CauseDeterminationCauses)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ProcedureDeviationId", form.Id);
                    command.AddParameter("@CauseDeterminationTypeId", cause.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddInsertParameters(ProcedureDeviation form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
        }

        private void SetCommonAttributes(ProcedureDeviation form, SqlCommand command)
        {
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);

            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@DeviationType", form.Type.Id);
            command.AddParameter("@SiteId", form.SiteId);

            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);

            command.AddParameter("@PermanentRevisionRequired", form.PermanentRevisionRequired);
            command.AddParameter("@RevertedBackToOriginal", form.RevertedBackToOriginal);
            command.AddParameter("@LocationEquipmentNumber", form.LocationEquipmentNumber);

            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);

            command.AddParameter("@NumberOfExtensions", form.NumberOfExtensions);

            command.AddParameter("@OperatingProcedureNumber", form.OperatingProcedureNumber);
            command.AddParameter("@OperatingProcedureTitle", form.OperatingProcedureTitle);

            command.AddParameter("@OperatingProcedureLevel", form.OperatingProcedureLevel.Id);

            command.AddParameter("@Description", form.Description);
            command.AddParameter("@RichTextDescription", form.RichTextDescription);

            command.AddParameter("@CauseDeterminationCategory", form.CauseDeterminationCategory);
            command.AddParameter("@CauseDeterminationComments", form.CauseDeterminationComments);

            command.AddParameter("@FixDocumentDurationType", form.FixDocumentDurationType.Id);
            command.AddParameter("@CorrectiveActionIlpNumber", form.CorrectiveActionIlpNumber);
            command.AddParameter("@CorrectiveActionWorkRequestNumber", form.CorrectiveActionWorkRequestNumber);
            command.AddParameter("@CorrectiveActionOtherComments", form.CorrectiveActionOtherComments);

            command.AddParameter("@AffectsToe", form.AffectsToe);
            command.AddParameter("@RiskAssessmentAttendee1Type", form.RiskAssessmentAttendee1Type.Id);
            command.AddParameter("@RiskAssessmentAttendee1Name", form.RiskAssessmentAttendee1Name);
            command.AddParameter("@RiskAssessmentAttendee2Type", form.RiskAssessmentAttendee2Type.Id);
            command.AddParameter("@RiskAssessmentAttendee2Name", form.RiskAssessmentAttendee2Name);
            command.AddParameter("@RiskAssessmentAttendee3Type", form.RiskAssessmentAttendee3Type.Id);
            command.AddParameter("@RiskAssessmentAttendee3Name", form.RiskAssessmentAttendee3Name);
            command.AddParameter("@RiskAssessmentAttendee4Type", form.RiskAssessmentAttendee4Type.Id);
            command.AddParameter("@RiskAssessmentAttendee4Name", form.RiskAssessmentAttendee4Name);
            command.AddParameter("@RiskAssessmentAnswer1", form.RiskAssessmentAnswer1);
            command.AddParameter("@RiskAssessmentAnswer2", form.RiskAssessmentAnswer2);
            command.AddParameter("@RiskAssessmentAnswer3", form.RiskAssessmentAnswer3);
            command.AddParameter("@RiskAssessmentAnswer4", form.RiskAssessmentAnswer4);
            command.AddParameter("@RiskAssessmentAnswer5", form.RiskAssessmentAnswer5);
            command.AddParameter("@RiskAssessmentComments", form.RiskAssessmentComments);

            command.AddParameter("@ImmediateApprovalsApprover1Type", form.ImmediateApprovalsApprover1Type.Id);
            command.AddParameter("@ImmediateApprovalsApprover1Title", form.ImmediateApprovalsApprover1Title);
            command.AddParameter("@ImmediateApprovalsApprover1Name", form.ImmediateApprovalsApprover1Name);
            command.AddParameter("@ImmediateApprovalsApprover1ObtainedVia",
                form.ImmediateApprovalsApprover1ObtainedVia.Id);
            command.AddParameter("@ImmediateApprovalsApprover1ApprovedDateTime",
                form.ImmediateApprovalsApprover1ApprovedDateTime);
            command.AddParameter("@ImmediateApprovalsApprover2Type", form.ImmediateApprovalsApprover2Type.Id);
            command.AddParameter("@ImmediateApprovalsApprover2Title", form.ImmediateApprovalsApprover2Title);
            command.AddParameter("@ImmediateApprovalsApprover2Name", form.ImmediateApprovalsApprover2Name);
            command.AddParameter("@ImmediateApprovalsApprover2ObtainedVia",
                form.ImmediateApprovalsApprover2ObtainedVia.Id);
            command.AddParameter("@ImmediateApprovalsApprover2ApprovedDateTime",
                form.ImmediateApprovalsApprover2ApprovedDateTime);

            command.AddParameter("@TemporaryApprovalsApprover1Type", form.TemporaryApprovalsApprover1Type.Id);
            command.AddParameter("@TemporaryApprovalsApprover1Title", form.TemporaryApprovalsApprover1Title);
            command.AddParameter("@TemporaryApprovalsApprover1Name", form.TemporaryApprovalsApprover1Name);
            command.AddParameter("@TemporaryApprovalsApprover1ObtainedVia",
                form.TemporaryApprovalsApprover1ObtainedVia.Id);
            command.AddParameter("@TemporaryApprovalsApprover1ApprovedDateTime",
                form.TemporaryApprovalsApprover1ApprovedDateTime);
            command.AddParameter("@TemporaryApprovalsApprover2Type", form.TemporaryApprovalsApprover2Type.Id);
            command.AddParameter("@TemporaryApprovalsApprover2Title", form.TemporaryApprovalsApprover2Title);
            command.AddParameter("@TemporaryApprovalsApprover2Name", form.TemporaryApprovalsApprover2Name);
            command.AddParameter("@TemporaryApprovalsApprover2ObtainedVia",
                form.TemporaryApprovalsApprover2ObtainedVia.Id);
            command.AddParameter("@TemporaryApprovalsApprover2ApprovedDateTime",
                form.TemporaryApprovalsApprover2ApprovedDateTime);

            command.AddParameter("@CancelledBy", form.CancelledBy);
            command.AddParameter("@CancelledDateTime", form.CancelledDateTime);
            command.AddParameter("@CancelledReason", form.CancelledReason);
        }

        private ProcedureDeviation PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var deviationType = ProcedureDeviationType.GetById(reader.Get<int>("DeviationType"));
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var startDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var endDateTime = reader.Get<DateTime>("ValidToDateTime");

            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var documentLinks = documentLinkDao.QueryByFormProcedureDeviationId(id);
            var functionalLocations = flocDao.QueryByFormProcedureDeviationId(id);

            var causeDeterminationCauses = causeDeterminationDao.QueryByProcedureDeviationId(id);
            var causeDeterminationCategory = reader.Get<string>("CauseDeterminationCategory");
            var causeDeterminationComments = reader.Get<String>("CauseDeterminationComments");

            var fixDocumentDurationType =
                CorrectiveActionFixDocumentDurationType.GetById(reader.Get<int>("FixDocumentDurationType"));
            var correctiveActionIlpNumber = reader.Get<String>("CorrectiveActionIlpNumber");
            var correctiveActionWorkRequestNumber = reader.Get<String>("CorrectiveActionWorkRequestNumber");
            var correctiveActionOtherComments = reader.Get<String>("CorrectiveActionOtherComments");

            var riskAssessmentAttendee1Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee1Type"));
            var riskAssessmentAttendee1Name = reader.Get<String>("RiskAssessmentAttendee1Name");
            var riskAssessmentAttendee2Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee2Type"));
            var riskAssessmentAttendee2Name = reader.Get<String>("RiskAssessmentAttendee2Name");
            var riskAssessmentAttendee3Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee3Type"));
            var riskAssessmentAttendee3Name = reader.Get<String>("RiskAssessmentAttendee3Name");
            var riskAssessmentAttendee4Type =
                ProcedureDeviationAttendeeType.GetById(reader.Get<int>("RiskAssessmentAttendee4Type"));
            var riskAssessmentAttendee4Name = reader.Get<String>("RiskAssessmentAttendee4Name");

            var riskAssessmentAnswer1 = reader.Get<bool>("RiskAssessmentAnswer1");
            var riskAssessmentAnswer2 = reader.Get<bool>("RiskAssessmentAnswer2");
            var riskAssessmentAnswer3 = reader.Get<bool>("RiskAssessmentAnswer3");
            var riskAssessmentAnswer4 = reader.Get<bool>("RiskAssessmentAnswer4");
            var riskAssessmentAnswer5 = reader.Get<bool>("RiskAssessmentAnswer5");
            var riskAssessmentComments = reader.Get<String>("RiskAssessmentComments");

            var immediateApprovalsApprover1Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("ImmediateApprovalsApprover1Type"));
            var immediateApprovalsApprover1Title = reader.Get<String>("ImmediateApprovalsApprover1Title");
            var immediateApprovalsApprover1Name = reader.Get<String>("ImmediateApprovalsApprover1Name");
            var immediateApprovalsApprover1ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("ImmediateApprovalsApprover1ObtainedVia"));
            var immediateApprovalsApprover1ApprovedDateTime =
                reader.Get<DateTime?>("ImmediateApprovalsApprover1ApprovedDateTime");
            var immediateApprovalsApprover2Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("ImmediateApprovalsApprover2Type"));
            var immediateApprovalsApprover2Title = reader.Get<String>("ImmediateApprovalsApprover2Title");
            var immediateApprovalsApprover2Name = reader.Get<String>("ImmediateApprovalsApprover2Name");
            var immediateApprovalsApprover2ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("ImmediateApprovalsApprover2ObtainedVia"));
            var immediateApprovalsApprover2ApprovedDateTime =
                reader.Get<DateTime?>("ImmediateApprovalsApprover2ApprovedDateTime");

            var temporaryApprovalsApprover1Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("TemporaryApprovalsApprover1Type"));
            var temporaryApprovalsApprover1Title = reader.Get<String>("TemporaryApprovalsApprover1Title");
            var temporaryApprovalsApprover1Name = reader.Get<String>("TemporaryApprovalsApprover1Name");
            var temporaryApprovalsApprover1ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("TemporaryApprovalsApprover1ObtainedVia"));
            var temporaryApprovalsApprover1ApprovedDateTime =
                reader.Get<DateTime?>("TemporaryApprovalsApprover1ApprovedDateTime");
            var temporaryApprovalsApprover2Type =
                ProcedureDeviationApprovalType.GetById(reader.Get<int>("TemporaryApprovalsApprover2Type"));
            var temporaryApprovalsApprover2Title = reader.Get<String>("TemporaryApprovalsApprover2Title");
            var temporaryApprovalsApprover2Name = reader.Get<String>("TemporaryApprovalsApprover2Name");
            var temporaryApprovalsApprover2ObtainedVia =
                ProcedureDeviationApprovalObtainedVia.GetById(reader.Get<int>("TemporaryApprovalsApprover2ObtainedVia"));
            var temporaryApprovalsApprover2ApprovedDateTime =
                reader.Get<DateTime?>("TemporaryApprovalsApprover2ApprovedDateTime");

            var siteid = reader.Get<long>("SiteId");    //ayman generic forms

            var form = new ProcedureDeviation(id, deviationType, startDateTime, endDateTime, formStatus, createdBy,
                createdDateTime, lastModifiedBy, lastModifiedDateTime, siteid)          //ayman generic forms
            {
                ApprovedDateTime = reader.Get<DateTime?>("ApprovedDateTime"),
                IsDeleted = reader.Get<Boolean>("Deleted"),
                SiteId = reader.Get<long>("SiteId"),
                PermanentRevisionRequired = reader.Get<bool>("PermanentRevisionRequired"),
                RevertedBackToOriginal = reader.Get<bool>("RevertedBackToOriginal"),
                LocationEquipmentNumber = reader.Get<String>("LocationEquipmentNumber"),
                NumberOfExtensions = reader.Get<int>("NumberOfExtensions"),
                OperatingProcedureNumber = reader.Get<string>("OperatingProcedureNumber"),
                OperatingProcedureTitle = reader.Get<string>("OperatingProcedureTitle"),
                OperatingProcedureLevel = OperatingProcedureLevel.GetById(reader.Get<int>("OperatingProcedureLevel")),
                Description = reader.Get<String>("Description"),
                RichTextDescription = reader.Get<String>("RichTextDescription"),
                CauseDeterminationCauses = causeDeterminationCauses,
//                CauseDeterminationCategory = causeDeterminationCategory,
                CauseDeterminationComments = causeDeterminationComments,
                FixDocumentDurationType = fixDocumentDurationType,
                CorrectiveActionIlpNumber = correctiveActionIlpNumber,
                CorrectiveActionWorkRequestNumber = correctiveActionWorkRequestNumber,
                CorrectiveActionOtherComments = correctiveActionOtherComments,
                AffectsToe = reader.Get<bool>("AffectsToe"),
                RiskAssessmentAttendee1Type = riskAssessmentAttendee1Type,
                RiskAssessmentAttendee1Name = riskAssessmentAttendee1Name,
                RiskAssessmentAttendee2Type = riskAssessmentAttendee2Type,
                RiskAssessmentAttendee2Name = riskAssessmentAttendee2Name,
                RiskAssessmentAttendee3Type = riskAssessmentAttendee3Type,
                RiskAssessmentAttendee3Name = riskAssessmentAttendee3Name,
                RiskAssessmentAttendee4Type = riskAssessmentAttendee4Type,
                RiskAssessmentAttendee4Name = riskAssessmentAttendee4Name,
                RiskAssessmentAnswer1 = riskAssessmentAnswer1,
                RiskAssessmentAnswer2 = riskAssessmentAnswer2,
                RiskAssessmentAnswer3 = riskAssessmentAnswer3,
                RiskAssessmentAnswer4 = riskAssessmentAnswer4,
                RiskAssessmentAnswer5 = riskAssessmentAnswer5,
                RiskAssessmentComments = riskAssessmentComments,
                ImmediateApprovalsApprover1Type = immediateApprovalsApprover1Type,
                ImmediateApprovalsApprover1Title = immediateApprovalsApprover1Title,
                ImmediateApprovalsApprover1Name = immediateApprovalsApprover1Name,
                ImmediateApprovalsApprover1ObtainedVia = immediateApprovalsApprover1ObtainedVia,
                ImmediateApprovalsApprover1ApprovedDateTime = immediateApprovalsApprover1ApprovedDateTime,
                ImmediateApprovalsApprover2Type = immediateApprovalsApprover2Type,
                ImmediateApprovalsApprover2Title = immediateApprovalsApprover2Title,
                ImmediateApprovalsApprover2Name = immediateApprovalsApprover2Name,
                ImmediateApprovalsApprover2ObtainedVia = immediateApprovalsApprover2ObtainedVia,
                ImmediateApprovalsApprover2ApprovedDateTime = immediateApprovalsApprover2ApprovedDateTime,
                TemporaryApprovalsApprover1Type = temporaryApprovalsApprover1Type,
                TemporaryApprovalsApprover1Title = temporaryApprovalsApprover1Title,
                TemporaryApprovalsApprover1Name = temporaryApprovalsApprover1Name,
                TemporaryApprovalsApprover1ObtainedVia = temporaryApprovalsApprover1ObtainedVia,
                TemporaryApprovalsApprover1ApprovedDateTime = temporaryApprovalsApprover1ApprovedDateTime,
                TemporaryApprovalsApprover2Type = temporaryApprovalsApprover2Type,
                TemporaryApprovalsApprover2Title = temporaryApprovalsApprover2Title,
                TemporaryApprovalsApprover2Name = temporaryApprovalsApprover2Name,
                TemporaryApprovalsApprover2ObtainedVia = temporaryApprovalsApprover2ObtainedVia,
                TemporaryApprovalsApprover2ApprovedDateTime = temporaryApprovalsApprover2ApprovedDateTime,
                CancelledBy = reader.Get<String>("CancelledBy"),
                CancelledDateTime = reader.Get<DateTime?>("CancelledDateTime"),
                CancelledReason = reader.Get<String>("CancelledReason"),
                DocumentLinks = documentLinks,
                FunctionalLocations = functionalLocations,
                ReasonsForExtension = commentDao.QueryByProcedureDeviationId(id),
            };

            return form;
        }

        private void InsertNewComments(ProcedureDeviation procedureDeviation)
        {
            if (!procedureDeviation.ReasonsForExtension.IsEmpty())
            {
                foreach (var comment in procedureDeviation.ReasonsForExtension)
                {
                    if (comment.Id.HasNoValue())
                    {
                        commentDao.InsertProcedureDeviationComment(procedureDeviation.IdValue, comment);
                    }
                }
            }
        }
    }
}
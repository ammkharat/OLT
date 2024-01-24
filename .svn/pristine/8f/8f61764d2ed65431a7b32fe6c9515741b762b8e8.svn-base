using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitAssessmentDao : AbstractManagedDao, IPermitAssessmentDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryOilsandPermitAssessmentById";
        private const string INSERT_STORED_PROCEDURE = "InsertOilsandPermitAssessment";
        private const string UPDATE_STORED_PROCEDURE = "UpdateOilsandPermitAssessment";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertFormPermitAssessmentFunctionalLocation";

        private const string DELETE_FORM_FUNCTIONAL_LOCATION =
            "DeleteOilsandPermitAssessmentFunctionalLocationsByOilsandPermitAssessmentId";

        private const string REMOVE_STORED_PROCEDURE = "RemoveOilsandPermitAssessment";
        private readonly IPermitAssessmentAnswerDao answerDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IUserDao userDao;

        public PermitAssessmentDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            answerDao = DaoRegistry.GetDao<IPermitAssessmentAnswerDao>();
        }

        public PermitAssessment Insert(PermitAssessment form)
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
            InsertPermitAssessmentAnswers(form);
            return form;
        }

        //ayman generic forms
        public PermitAssessment QueryByIdAndSiteId(long id,long siteid)
        {
            var command = ManagedCommand;
            return command.QueryByIdAndSiteId(id, siteid, PopulateInstance, "QueryOilsandPermitAssessmentByIdAndSiteId");
        }
        
        
        public PermitAssessment QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }


        public void Update(PermitAssessment form)
        {
            var command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            UpdatePermitAssessmentAnswers(form);
        }

        public void Remove(PermitAssessment form)
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
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormOilsandsPermitAssessment);
        }

        private void AddUpdateParameters(PermitAssessment form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }


        private void UpdateFunctionalLocations(SqlCommand command, PermitAssessment form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@PermitAssessmentId", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }


        private void InsertFunctionalLocations(SqlCommand command, PermitAssessment form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (var functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@PermitAssessmentId", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertPermitAssessmentAnswers(PermitAssessment form)
        {
            foreach (var permitAssessmentAnswer in form.Answers)
            {
                permitAssessmentAnswer.PermitAssessmentId = form.IdValue;
                answerDao.Insert(permitAssessmentAnswer, form.IdValue);
            }
        }

        private void UpdatePermitAssessmentAnswers(PermitAssessment form)
        {
            foreach (var permitAssessmentAnswer in form.Answers)
            {
                answerDao.Update(permitAssessmentAnswer);
            }
        }

        private List<PermitAssessmentAnswer> GetAnswers(long permitAssessmentId)
        {
            var answers = answerDao.QueryByPermitAssessmentId(permitAssessmentId);
            return answers;
        }

        private void AddInsertParameters(PermitAssessment form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
            command.AddParameter("@CreationUserShiftPatternId", form.CreationUserShiftPatternId);
            command.AddParameter("@TotalQuestionnaireWeight", form.TotalQuestionnaireWeight);
            command.AddParameter("@QuestionnaireId", form.QuestionnaireId);
            command.AddParameter("@QuestionnaireName", form.QuestionnaireName);
            command.AddParameter("@QuestionnaireVersion", form.QuestionnaireVersion);
        }

        private void SetCommonAttributes(PermitAssessment form, SqlCommand command)
        {
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@SiteId", form.SiteId);
            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);
            command.AddParameter("@CrewSize", form.CrewSize);
            command.AddParameter("@IssuedToSuncor", form.IssuedToSuncor);
            command.AddParameter("@IssuedToContractor", form.IssuedToContractor);
            command.AddParameter("@IsIlpRecommended", form.IsIlpRecommended);
            command.AddParameter("@Contractor", form.Contractor);
            command.AddParameter("@PermitNumber", form.PermitNumber);
            command.AddParameter("@TotalScoredPercentage", form.TotalScoredPercentage);
            command.AddParameter("@TotalAnswerScore", form.TotalAnswerScore);
            command.AddParameter("@TotalAnswerWeightedScore", form.TotalAnswerWeightedScore);
            command.AddParameter("@JobDescription", form.JobDescription);
            command.AddParameter("@OverallFeedback", form.OverallFeedback);
            command.AddParameter("@LocationEquipmentNumber", form.LocationEquipmentNumber);
            command.AddParameter("@JobCoordinator", form.JobCoordinator);
            command.AddParameter("@Trade", form.Trade);
            command.AddParameter("@OilsandsWorkPermitTypeId", form.OilsandsWorkPermitType.IdValue);
        }

        private PermitAssessment PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            var validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var validToDateTime = reader.Get<DateTime>("ValidToDateTime");
            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            var creationUserShiftPatternId = reader.Get<long>("CreationUserShiftPatternId");
            var answers = GetAnswers(id);
            var documentLinks = documentLinkDao.QueryByFormOilsandsPermitAssessmentId(id);
            var functionalLocations = flocDao.QueryByFormOilsandsPermitAssessmentId(id);

            var form = new PermitAssessment(id, validFromDateTime, validToDateTime, formStatus, createdBy,
                createdDateTime, creationUserShiftPatternId, lastModifiedBy, lastModifiedDateTime, answers)
            {
                LastModifiedBy = lastModifiedBy,
                LastModifiedDateTime = lastModifiedDateTime,
                ApprovedDateTime = approvedDateTime,
                JobDescription = reader.Get<String>("JobDescription"),
                Contractor = reader.Get<String>("Contractor"),
                Trade = reader.Get<String>("Trade"),
                JobCoordinator = reader.Get<String>("JobCoordinator"),
                IssuedToContractor = reader.Get<Boolean>("IssuedToContractor"),
                IssuedToSuncor = reader.Get<Boolean>("IssuedToSuncor"),
                IsIlpRecommended = reader.Get<Boolean>("IsIlpRecommended"),
                LocationEquipmentNumber = reader.Get<String>("LocationEquipmentNumber"),
                OverallFeedback = reader.Get<String>("OverallFeedback"),
                PermitNumber = reader.Get<String>("PermitNumber"),
                QuestionnaireId = reader.Get<long>("QuestionnaireId"),
                QuestionnaireName = reader.Get<String>("QuestionnaireName"),
                TotalAnswerScore = reader.Get<int>("TotalAnswerScore"),
                TotalAnswerWeightedScore = reader.Get<int>("TotalAnswerWeightedScore"),
                TotalQuestionnaireWeight = reader.Get<int>("TotalQuestionnaireWeight"),
                TotalScoredPercentage = reader.Get<decimal>("TotalScoredPercentage"),
                CrewSize = reader.Get<int>("CrewSize"),
                QuestionnaireVersion = reader.Get<int>("QuestionnaireVersion"),
                OilsandsWorkPermitType = OilsandsWorkPermitType.Get(reader.Get<int>("OilsandsWorkPermitType")),
                SiteId = reader.Get<long>("SiteId"),
                DocumentLinks = documentLinks,
                FunctionalLocations = functionalLocations
            };

            return form;
        }
    }
}
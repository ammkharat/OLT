using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitAssessmentHistoryDao : AbstractManagedDao, IPermitAssessmentHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryPermitAssessmentHistoryById";
        private const string INSERT = "InsertPermitAssessmentHistory";

        private readonly IPermitAssessmentAnswerHistoryDao answerHistoryDao;
        private readonly IUserDao userDao;

        public PermitAssessmentHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            answerHistoryDao = DaoRegistry.GetDao<IPermitAssessmentAnswerHistoryDao>();
        }

        public List<PermitAssessmentHistory> GetById(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(PermitAssessmentHistory history)
        {
            var command = ManagedCommand;

            var idParameter = command.Parameters.Add("@PermitAssessmentHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.Insert(history, AddInsertParameters, INSERT);

            var historyId = (long) idParameter.Value;
            InsertAnswers(historyId, history.Answers);
        }

        private void InsertAnswers(long historyId, List<PermitAssessmentAnswerHistory> answers)
        {
            foreach (var answer in answers)
            {
                answer.HistoryId = historyId;
                answerHistoryDao.Insert(answer);
            }
        }

        private void AddInsertParameters(PermitAssessmentHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);

            command.AddParameter("FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("IssuedToSuncor", history.IssuedToSuncor);
            command.AddParameter("IssuedToContractor", history.IssuedToContractor);

            command.AddParameter("CrewSize", history.CrewSize);
            command.AddParameter("OilsandsWorkPermitType", history.OilsandsWorkPermitType.IdValue);

            command.AddParameter("TotalScoredPercentage", history.TotalScoredPercentage);
            command.AddParameter("TotalAnswerScore", history.TotalAnswerScore);
            command.AddParameter("TotalAnswerWeightedScore", history.TotalAnswerWeightedScore);
            command.AddParameter("TotalQuestionnaireWeight", history.TotalQuestionnaireWeight);

            command.AddParameter("JobDescription", history.JobDescription);
            command.AddParameter("OverallFeedback", history.OverallFeedback);

            command.AddParameter("LocationEquipmentNumber", history.LocationEquipmentNumber);
            command.AddParameter("JobCoordinator", history.JobCoordinator);
            command.AddParameter("PermitNumber", history.PermitNumber);
            command.AddParameter("contractor", history.Contractor);

            command.AddParameter("IsIlpRecommended", history.IsIlpRecommended);
            command.AddParameter("Trade", history.Trade);
        }

        private PermitAssessmentHistory PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var functionalLocations = reader.Get<string>("FunctionalLocations");
            var documentLinks = reader.Get<string>("DocumentLinks");

            var validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            var issuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            var issuedToContractor = reader.Get<bool>("IssuedToContractor");

            var crewSize = reader.Get<int>("CrewSize");
            var oilSandsWorkPermitType = OilsandsWorkPermitType.Get(reader.Get<int>("OilsandsWorkPermitType"));

            var totalScoredPercentage = reader.Get<decimal>("TotalScoredPercentage");
            var totalAnswerScore = reader.Get<int>("TotalAnswerScore");
            var totalAnswerWeightedScore = reader.Get<int>("TotalAnswerWeightedScore");
            var totalQuestionnaireWeight = reader.Get<int>("TotalQuestionnaireWeight");

            var jobDescription = reader.Get<string>("JobDescription");
            var overallFeedback = reader.Get<string>("OverallFeedback");

            var locationEquipmentNumber = reader.Get<string>("LocationEquipmentNumber");
            var jobCoordinator = reader.Get<string>("JobCoordinator");
            var permitNumber = reader.Get<string>("PermitNumber");
            var contractor = reader.Get<string>("contractor");

            var isIlpRecommended = reader.Get<bool>("IsIlpRecommended");
            var trade = reader.Get<string>("Trade");

            var answers = answerHistoryDao.GetByHistoryId(reader.Get<long>("PermitAssessmentHistoryId"));

            return new PermitAssessmentHistory(id, validFromDateTime, validToDateTime, formStatus, lastModifiedBy,
                lastModifiedDateTime, issuedToSuncor, issuedToContractor, contractor, trade, crewSize,
                oilSandsWorkPermitType, permitNumber, locationEquipmentNumber, totalScoredPercentage, totalAnswerScore,
                totalAnswerWeightedScore, totalQuestionnaireWeight, jobDescription, overallFeedback, jobCoordinator,
                isIlpRecommended, functionalLocations, documentLinks, answers);
        }
    }
}
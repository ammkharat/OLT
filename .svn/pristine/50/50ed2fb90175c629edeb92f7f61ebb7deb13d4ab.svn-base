using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class MontrealCsdHistoryDao : AbstractManagedDao, IMontrealCsdHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormMontrealCsdHistoryById";
        private const string INSERT = "InsertFormMontrealCsdHistory";

        private readonly IUserDao userDao;

        public MontrealCsdHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<MontrealCsdHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<MontrealCsdHistory>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(MontrealCsdHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(MontrealCsdHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("PlainTextContent", history.PlainTextContent);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocations", history.FunctionalLocations);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("IsTheCSDForAPressureSafetyValve", history.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("HasBeenCommunicated", history.HasBeenCommunicated);
            command.AddParameter("HasAttachments", history.HasAttachments);
            command.AddParameter("CriticalSystemDefeated", history.CriticalSystemDefeated);
            command.AddParameter("CsdReason", history.CsdReason);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private MontrealCsdHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string approvals = reader.Get<string>("Approvals");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            string plainTextContent = reader.Get<string>("PlainTextContent");

            bool isTheCSDForAPressureSafetyValve = reader.Get<bool>("IsTheCSDForAPressureSafetyValve");
            string criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");
            string csdReason = reader.Get<string>("CsdReason");

            bool hasBeenCommunicated =reader.Get<bool>("HasBeenCommunicated");
            bool hasAttachments =reader.Get<bool>("HasAttachments");

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");
            string documentLinks = reader.Get<string>("DocumentLinks");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return new MontrealCsdHistory(id, formStatus, functionalLocations, plainTextContent, validFromDateTime,
                validToDateTime, approvals, lastModifiedBy,
                lastModifiedDateTime, approvedDateTime, closedDateTime, hasBeenCommunicated,hasAttachments, csdReason, isTheCSDForAPressureSafetyValve,
                criticalSystemDefeated, documentLinks);
        }
    }
}
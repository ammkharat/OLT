using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN24HistoryDao : AbstractManagedDao, IFormGN24HistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormGN24HistoryById";
        private const string INSERT = "InsertFormGN24History";

        private readonly IUserDao userDao;

        public FormGN24HistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormGN24History> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormGN24History>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormGN24History history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(FormGN24History history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("PlainTextContent", history.PlainTextContent);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocations", history.FunctionalLocations);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("IsTheSafeWorkPlanForPSVRemovalOrInstallation", history.IsTheSafeWorkPlanForPSVRemovalOrInstallation);
            command.AddParameter("IsTheSafeWorkPlanForWorkInTheAlkylationUnit", history.IsTheSafeWorkPlanForWorkInTheAlkylationUnit);
            command.AddParameter("AlkylationClass", history.AlkylationClass == null ? null : history.AlkylationClass.Id);

            command.AddParameter("PlainTextPreJobMeetingSignatures", history.PlainTextPreJobMeetingSignatures);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private FormGN24History PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string approvals = reader.Get<string>("Approvals");

            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            string plainTextContent = reader.Get<string>("PlainTextContent");

            DateTime validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ValidToDateTime");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            bool isTheSafeWorkPlanForPSVRemovalOrInstallation = reader.Get<bool>("IsTheSafeWorkPlanForPSVRemovalOrInstallation");
            bool isTheSafeWorkPlanForWorkInTheAlkylationUnit = reader.Get<bool>("IsTheSafeWorkPlanForWorkInTheAlkylationUnit");

            int? alkylationClassId = reader.Get<int?>("AlkylationClass");
            FormGN24AlkylationClass alkylationClass = null;
            if (alkylationClassId != null)
            {
                alkylationClass = FormGN24AlkylationClass.GetById(alkylationClassId.Value);
            }

            string documentLinks = reader.Get<string>("DocumentLinks");
            string plainTextPreJobMeetingSignatures = reader.Get<string>("PlainTextPreJobMeetingSignatures");

            return new FormGN24History(id, formStatus, functionalLocations, plainTextContent, validFromDateTime, validToDateTime, approvals, lastModifiedBy, lastModifiedDateTime, approvedDateTime, closedDateTime, isTheSafeWorkPlanForPSVRemovalOrInstallation, isTheSafeWorkPlanForWorkInTheAlkylationUnit, alkylationClass, documentLinks, plainTextPreJobMeetingSignatures);
        }
    }
}

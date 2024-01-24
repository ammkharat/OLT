using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormOvertimeFormHistoryDao : AbstractManagedDao, IFormOvertimeFormHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormOvertimeFormHistoryById";
        private const string INSERT = "InsertFormOvertimeFormHistory";

        private readonly IUserDao userDao;

        public FormOvertimeFormHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormOvertimeFormHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormOvertimeFormHistory>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormOvertimeFormHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(FormOvertimeFormHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);
            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("FromDateTime", history.ValidFromDateTime);
            command.AddParameter("ToDateTime", history.ValidToDateTime);
            command.AddParameter("DocumentLinks", history.DocumentLinks);
            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("OnSitePersonnel", history.OnSitePersonnel);
            command.AddParameter("TradeOccupation", history.TradeOccupation);
            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("CancelledDateTime", history.CancelledDateTime);
        }

        private FormOvertimeFormHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);
            string functionalLocation = reader.Get<string>("FunctionalLocation");
            DateTime validFromDateTime = reader.Get<DateTime>("FromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ToDateTime");
            string documentLinks = reader.Get<string>("DocumentLinks");
            string onSitePersonnel = reader.Get<string>("OnSitePersonnel");
            string tradeOccupation = reader.Get<string>("TradeOccupation");
            string approvals = reader.Get<string>("Approvals");
            DateTime? cancelledDateTime = reader.Get<DateTime?>("CancelledDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return new FormOvertimeFormHistory(id, formStatus, validFromDateTime, validToDateTime, lastModifiedBy,
                lastModifiedDateTime, functionalLocation, onSitePersonnel, tradeOccupation, approvals, documentLinks,
                approvedDateTime, cancelledDateTime);
        }
    }
}
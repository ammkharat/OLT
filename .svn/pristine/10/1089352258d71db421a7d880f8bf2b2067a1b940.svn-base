using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FormGN75AHistoryDao : AbstractManagedDao, IFormGN75AHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormGN75AHistoryById";
        private const string INSERT = "InsertFormGN75AHistory";

        private readonly IUserDao userDao;

        public FormGN75AHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<FormGN75AHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<FormGN75AHistory>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(FormGN75AHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);            
        }

        private void AddInsertParameters(FormGN75AHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);
            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Approvals", history.Approvals);            
            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);
            command.AddParameter("PlainTextContent", history.PlainTextContent);
            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);
            command.AddParameter("AssociatedFormGN75BNumber", history.AssociatedFormGN75BNumber);
            command.AddParameter("DocumentLinks", history.DocumentLinks);
            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private FormGN75AHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            string functionalLocation = reader.Get<string>("FunctionalLocation");
            string plainTextContent = reader.Get<string>("PlainTextContent");
            long? associatedGN75BNumber = reader.Get<long?>("AssociatedFormGN75BId");

            string documentLinks = reader.Get<string>("DocumentLinks");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            int formStatusId = reader.Get<int>("FormStatusId");
            FormStatus formStatus = FormStatus.GetById(formStatusId);
            
            DateTime validFromDateTime = reader.Get<DateTime>("FromDateTime");
            DateTime validToDateTime = reader.Get<DateTime>("ToDateTime");

            string approvals = reader.Get<string>("Approvals");
           
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
                                    
            return new FormGN75AHistory(id, functionalLocation, plainTextContent, associatedGN75BNumber, documentLinks, closedDateTime, approvedDateTime, formStatus, 
                validFromDateTime, validToDateTime, approvals, lastModifiedBy, lastModifiedDateTime);
        }

    }
}

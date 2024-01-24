using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LubesAlarmDisableHistoryDao : AbstractManagedDao, ILubesAlarmDisableHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryFormLubesAlarmDisableHistoryById";
        private const string INSERT = "InsertFormLubesAlarmDisableHistory";

        private readonly IUserDao userDao;

        public LubesAlarmDisableHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<LubesAlarmDisableFormHistory> GetById(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(LubesAlarmDisableFormHistory history)
        {
            var command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(LubesAlarmDisableFormHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("PlainTextContent", history.PlainTextContent);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("Location", history.Location);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("Alarm", history.Alarm);
            command.AddParameter("Criticality", history.Criticality);
            command.AddParameter("SapNotification", history.SapNotification);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private LubesAlarmDisableFormHistory PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");

            var formStatusId = reader.Get<int>("FormStatusId");
            var formStatus = FormStatus.GetById(formStatusId);

            var functionalLocation = reader.Get<string>("FunctionalLocation");
            var location = reader.Get<string>("Location");
            var approvals = reader.Get<string>("Approvals");

            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            var closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            var plainTextContent = reader.Get<string>("PlainTextContent");

            var alarm = reader.Get<string>("Alarm");
            var criticality = reader.Get<string>("Criticality");
            var sapNotification = reader.Get<string>("SapNotification");

            var validFromDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var validToDateTime = reader.Get<DateTime>("ValidToDateTime");
            var documentLinks = reader.Get<string>("DocumentLinks");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return new LubesAlarmDisableFormHistory(id, formStatus, functionalLocation, location, plainTextContent,
                validFromDateTime,
                validToDateTime, approvals, lastModifiedBy,
                lastModifiedDateTime, approvedDateTime, closedDateTime, alarm, criticality, sapNotification,
                documentLinks);
        }
    }
}
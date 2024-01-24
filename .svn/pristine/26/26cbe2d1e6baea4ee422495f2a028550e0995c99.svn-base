using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestMontrealHistoryDao : AbstractManagedDao, IPermitRequestMontrealHistoryDao
    {
        private const string QUERY_BY_ID = "QueryPermitRequestMontrealHistoriesById";
        private const string INSERT = "InsertPermitRequestMontrealHistory";

        private readonly IUserDao userDao;

        public PermitRequestMontrealHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<PermitRequestMontrealHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<PermitRequestMontrealHistory>(PopulateInstance, QUERY_BY_ID);
        }

        private PermitRequestMontrealHistory PopulateInstance(SqlDataReader reader)
        {
            DataSource source = DataSource.GetById(reader.Get<int>("SourceId"));

            PermitRequestMontrealHistory definition = new PermitRequestMontrealHistory(
                reader.Get<long>("Id"),
                WorkPermitMontrealType.Get(reader.Get<int>("WorkPermitTypeId")),
                source,
                reader.Get<string>("FunctionalLocations"),
                new Date(reader.Get<DateTime>("StartDate")),
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("WorkOrderNumber"),
                reader.Get<string>("OperationNumber"),
                reader.Get<string>("Trade"),
                reader.Get<string>("Description"),
                reader.Get<string>("SapDescription"),
                reader.Get<string>("Company"),
                reader.Get<string>("Supervisor"),
                reader.Get<string>("ExcavationNumber"),
                reader.Get<string>("Attributes"),
                GetUser(reader, "LastImportedByUserId"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                GetUser(reader, "LastSubmittedByUserId"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.Get<string>("DocumentLinks"),
                reader.Get<string>("RequestedByGroup"),
                PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId")));

            return definition;
        }

        private User GetUser(SqlDataReader reader, string userIdColumn)
        {
            long? userId = reader.Get<long?>(userIdColumn);
            return userId.HasValue ? userDao.QueryById(userId.Value) : null;
        }

        public void Insert(PermitRequestMontrealHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(PermitRequestMontrealHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.IdValue);
            
            command.AddParameter("@WorkPermitTypeId", history.WorkPermitType.Id);
            command.AddParameter("@FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("@StartDate", history.StartDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@EndDate", history.EndDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@WorkOrderNumber", history.WorkOrderNumber);
            command.AddParameter("@OperationNumber", history.OperationNumber);
            command.AddParameter("@Trade", history.Trade);            
            command.AddParameter("@Description", history.Description);
            command.AddParameter("@SapDescription", history.SapDescription);
            command.AddParameter("@Company", history.Company);
            command.AddParameter("@Supervisor", history.Supervisor);
            command.AddParameter("@ExcavationNumber", history.ExcavationNumber);
            command.AddParameter("@Attributes", history.Attributes);
            command.AddParameter("@DocumentLinks", history.DocumentLinks);
            command.AddParameter("@RequestedByGroup", history.RequestedByGroup);
            command.AddParameter("@CompletionStatusId", history.CompletionStatus.Id);
            command.AddParameter("@SourceId", history.Source.Id);

            if (history.LastImportedByUser != null)
            {
                command.AddParameter("@LastImportedByUserId", history.LastImportedByUser.IdValue);
            }
            if (history.LastImportedDateTime.HasValue)
            {
                command.AddParameter("@LastImportedDateTime", history.LastImportedDateTime);
            }
            if (history.LastSubmittedByUser != null)
            {
                command.AddParameter("@LastSubmittedByUserId", history.LastSubmittedByUser.IdValue);
            }
            if (history.LastSubmittedDateTime.HasValue)
            {
                command.AddParameter("@LastSubmittedDateTime", history.LastSubmittedDateTime);
            }

            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
        }
    }
}
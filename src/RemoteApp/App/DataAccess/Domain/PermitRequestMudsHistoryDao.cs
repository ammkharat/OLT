using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestMudsHistoryDao : AbstractManagedDao, IPermitRequestMudsHistoryDao
    {
        private const string QUERY_BY_ID = "QueryPermitRequestMudsHistoriesById";
        private const string INSERT = "InsertPermitRequestMudsHistory";

        private readonly IUserDao userDao;

        public PermitRequestMudsHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<PermitRequestMudsHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<PermitRequestMudsHistory>(PopulateInstance, QUERY_BY_ID);
        }

        private PermitRequestMudsHistory PopulateInstance(SqlDataReader reader)
        {
            DataSource source = DataSource.GetById(reader.Get<int>("SourceId"));

            PermitRequestMudsHistory definition = new PermitRequestMudsHistory(
                reader.Get<long>("Id"),
                WorkPermitMudsType.Get(reader.Get<int>("WorkPermitTypeId")),
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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                reader.Get<string>("Company_1"), 
                reader.Get<string>("Company_2"),
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
                PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId")),
                reader.Get<DateTime>("StartDateTime"),
                reader.Get<DateTime>("EndDateTime")
                
                );

            return definition;
        }

        private User GetUser(SqlDataReader reader, string userIdColumn)
        {
            long? userId = reader.Get<long?>(userIdColumn);
            return userId.HasValue ? userDao.QueryById(userId.Value) : null;
        }

        public void Insert(PermitRequestMudsHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(PermitRequestMudsHistory history, SqlCommand command)
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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            command.AddParameter("@Company_1", history.Company_1);
            command.AddParameter("@Company_2", history.Company_2);
            command.AddParameter("@Supervisor", history.Supervisor);
            command.AddParameter("@ExcavationNumber", history.ExcavationNumber);
            command.AddParameter("@Attributes", history.Attributes);
            command.AddParameter("@DocumentLinks", history.DocumentLinks);
            command.AddParameter("@RequestedByGroup", history.RequestedByGroup);
            command.AddParameter("@CompletionStatusId", history.CompletionStatus.Id);
            command.AddParameter("@SourceId", history.Source.Id);

            command.AddParameter("@StartDateTime", history.StartDateTime);
            command.AddParameter("@EndDateTime", history.EndDateTime);

            

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
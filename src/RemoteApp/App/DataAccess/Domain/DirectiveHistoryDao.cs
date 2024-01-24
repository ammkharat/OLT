using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DirectiveHistoryDao : AbstractManagedDao, IDirectiveHistoryDao
    {
        private readonly IUserDao userDao;

        public DirectiveHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();            
        }

        public List<DirectiveHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<DirectiveHistory>(PopulateInstance, "QueryDirectiveHistoryById");        
        }

        public void Insert(DirectiveHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, "InsertDirectiveHistory");
        }

        private DirectiveHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            string workAssignments = reader.Get<string>("WorkAssignments");
            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string documentLinks = reader.Get<string>("DocumentLinks");

            string plainTextContent = reader.Get<string>("PlainTextContent");

            DateTime activeFromDateTime = reader.Get<DateTime>("ActiveFromDateTime");            
            DateTime activeToDateTime = reader.Get<DateTime>("ActiveToDateTime");
            
            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DirectiveHistory directiveHistory = new DirectiveHistory(
                id, functionalLocations, workAssignments, documentLinks, activeFromDateTime, activeToDateTime, plainTextContent, lastModifiedUser, lastModifiedDateTime);

            return directiveHistory;
        }

        private void AddInsertParameters(DirectiveHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@WorkAssignments", history.WorkAssignments);
            command.AddParameter("@FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("@DocumentLinks", history.DocumentLinks);
            command.AddParameter("@PlainTextContent", history.PlainTextContent);
            command.AddParameter("@ActiveFromDateTime", history.ActiveFromDateTime);            
            command.AddParameter("@ActiveToDateTime", history.ActiveToDateTime);
            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
        }
    }
}

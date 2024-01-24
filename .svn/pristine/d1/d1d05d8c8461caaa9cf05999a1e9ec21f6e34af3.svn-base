using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmToeDefinitionCommentHistoryDao : AbstractManagedDao, IOpmToeDefinitionCommentHistoryDao

    {
        private readonly IUserDao userDao;

        public OpmToeDefinitionCommentHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<OpmToeDefinitionCommentHistory> GetByToeName(string toeName)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ToeName", toeName);
            return command.QueryForListResult<OpmToeDefinitionCommentHistory>(PopulateInstance, "QueryOpmToeDefinitionCommentHistoryByToeName");
        }
   
        public void Insert(OpmToeDefinitionCommentHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, "InsertOpmToeDefinitionCommentHistory");
        }


        private OpmToeDefinitionCommentHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string comment = reader.Get<string>("Comment");
            string toeName = reader.Get<string>("ToeName");
            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var opmToeDefinitionCommentHistory = new OpmToeDefinitionCommentHistory(
                id,toeName, lastModifiedUser, lastModifiedDateTime, comment);
            return opmToeDefinitionCommentHistory;
        }

        private void AddInsertParameters(OpmToeDefinitionCommentHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("@Comment", history.Comment);
            command.AddParameter("@ToeName", history.ToeName);
        }
    }
}

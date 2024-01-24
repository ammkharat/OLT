using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TradeChecklistHistoryDao : AbstractManagedDao, ITradeChecklistHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryTradeChecklistHistoryById";
        private const string INSERT = "InsertTradeChecklistHistory";

        private readonly IUserDao userDao;

        public TradeChecklistHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<TradeChecklistHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<TradeChecklistHistory>(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(TradeChecklistHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);            
        }

        private void AddInsertParameters(TradeChecklistHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("Trade", history.Trade);
            command.AddParameter("Content", history.Content);
            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
        }

        private TradeChecklistHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            
            string trade = reader.Get<string>("Trade");
            string content = reader.Get<string>("Content");
                                   
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
                                    
            return new TradeChecklistHistory(id, trade, content, lastModifiedBy, lastModifiedDateTime);
        }
    }
}

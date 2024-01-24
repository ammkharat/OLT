using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ExcursionResponseHistoryDao : AbstractManagedDao, IExcursionResponseHistoryDao
    {
        private readonly IUserDao userDao;

        public ExcursionResponseHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<ExcursionResponseHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<ExcursionResponseHistory>(PopulateInstance, "QueryExcursionResponseHistoryById");
        }

        public void Insert(ExcursionResponseHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, "InsertExcursionResponseHistory");
        }

        private ExcursionResponseHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string response = reader.Get<string>("Response");
            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            string asset = reader.Get<string>("Asset");
            string code = reader.Get<string>("Code");

            ExcursionResponseHistory excursionResponseHistory = new ExcursionResponseHistory(
                id,  lastModifiedUser, lastModifiedDateTime, response,asset, code);
            return excursionResponseHistory;
        }

        private void AddInsertParameters(ExcursionResponseHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("@Response", history.Response);
            command.AddParameter("@Asset", history.Asset); //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            command.AddParameter("@Code", history.Code);
        }
    }
}

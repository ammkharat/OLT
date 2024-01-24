using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LabAlertResponseDao : AbstractManagedDao, ILabAlertResponseDao
    {
        private const string QUERY_BY_LAB_ALERT_ID_STORED_PROCEDURE = "QueryLabAlertResponseByLabAlertId";
        private const string INSERT_STORED_PROCEDURE = "InsertLabAlertResponse";

        private readonly IUserDao userDao;

        public LabAlertResponseDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<LabAlertResponse> QueryByLabAlertId(long labAlertId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LabAlertId",  labAlertId);
            return command.QueryForListResult<LabAlertResponse>(PopulateInstance, QUERY_BY_LAB_ALERT_ID_STORED_PROCEDURE);
        }

        private LabAlertResponse PopulateInstance(SqlDataReader reader)
        {
            LabAlertResponse response = new LabAlertResponse(
                reader.Get<long>("Id"),
                reader.Get<long>("LabAlertId"),
                LabAlertStatus.Get(reader.Get<long>("LabAlertStatusId")),
                reader.Get<string>("Comments"),
                userDao.QueryById(reader.Get<long>("CreatedByUserId")),
                reader.Get<DateTime>("CreatedDateTime"));

            return response;
        }

        public LabAlertResponse Insert(LabAlertResponse response)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(response, AddInsertParameters, INSERT_STORED_PROCEDURE);
            response.Id = (long?)idParameter.Value;
            return response;
        }

        private static void AddInsertParameters(LabAlertResponse response, SqlCommand command)
        {
            command.AddParameter("@LabAlertId", response.LabAlertId);
            command.AddParameter("@LabAlertStatusId", response.Status.Id);
            command.AddParameter("@Comments", response.Comments);
            command.AddParameter("@CreatedByUserId", response.CreatedByUser.Id);
            command.AddParameter("@CreatedDateTime", response.CreatedDateTime);
        }
    }
}
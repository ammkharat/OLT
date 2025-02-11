﻿using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmExcursionResponseDao : AbstractManagedDao, IOpmExcursionResponseDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryOpmExcursionResponseById";
        private const string QUERY_BY_EXCURSION_ID_STORED_PROCEDURE = "QueryOpmExcursionResponseByExcursionId";
        private const string INSERT_STORED_PROCEDURE = "InsertOpmExcursionResponse";
        private const string UPDATE_STORED_PROCEDURE = "UpdateOpmExcursionResponse";
        private readonly IUserDao userDao;


        public OpmExcursionResponseDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public OpmExcursionResponse QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public OpmExcursionResponse QueryByExcursionId(long excursionId)
        {
            return ManagedCommand.QueryById(excursionId, PopulateInstance, QUERY_BY_EXCURSION_ID_STORED_PROCEDURE);
        }

        public OpmExcursionResponse Insert(OpmExcursionResponse opmExcursionResponse)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(opmExcursionResponse, AddInsertParameters, INSERT_STORED_PROCEDURE);
            opmExcursionResponse.Id = (long?) idParameter.Value;
            return opmExcursionResponse;
        }

        public void Update(OpmExcursionResponse opmExcursionResponse)
        {
            var command = ManagedCommand;
            command.Update(opmExcursionResponse, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }


        private OpmExcursionResponse PopulateInstance(SqlDataReader reader)
        {
            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var excursion = new OpmExcursionResponse(
                reader.Get<long>("Id"),
                reader.Get<long>("OltExcursionId"),
                reader.Get<long>("OpmExcursionId"),
                reader.Get<long>("ToeVersion"),
                reader.Get<string>("HistorianTag"),
                lastModifiedBy,
                reader.Get<string>("Response"),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.Get<string>("Asset"), //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
                reader.Get<string>("Code")
                
                );
            return excursion;
        }


        private static void AddInsertParameters(OpmExcursionResponse excursion, SqlCommand command)
        {
            command.AddParameter("@OpmExcursionId", excursion.OpmExcursionId);
            command.AddParameter("@OltExcursionId", excursion.OltExcursionId);
            command.AddParameter("@ToeVersion", excursion.ToeVersion);
            command.AddParameter("@HistorianTag", excursion.HistorianTag);
            SetInsertUpdateAttributes(excursion, command);
        }


        private static void AddUpdateParameters(OpmExcursionResponse excursion, SqlCommand command)
        {
            command.AddParameter("@Id", excursion.Id);
            SetInsertUpdateAttributes(excursion, command);
        }

        private static void SetInsertUpdateAttributes(OpmExcursionResponse excursion, SqlCommand command)
        {
            command.AddParameter("@LastModifiedByUserId", excursion.LastModifiedBy.IdValue);
            command.AddParameter("@Response", excursion.Response);
            command.AddParameter("@Asset", excursion.Asset); //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            command.AddParameter("@Code", excursion.Code);
            command.AddParameter("@LastModifiedDateTime", excursion.LastModifiedDateTime);
        }
    }
}
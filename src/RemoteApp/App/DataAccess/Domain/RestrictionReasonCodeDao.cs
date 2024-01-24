using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RestrictionReasonCodeDao : AbstractManagedDao, IRestrictionReasonCodeDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryRestrictionReasonCodeById";
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllRestrictionReasonCodes";
        private const string INSERT_STORED_PROCEDURE = "InsertRestrictionReasonCode";
        private const string UPDATE_STORED_PROCEDURE = "UpdateRestrictionReasonCode";
        private const string REMOVE_STORED_PROCEDURE = "RemoveRestrictionReasonCode";

        private readonly IUserDao userDao;

        public RestrictionReasonCodeDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public RestrictionReasonCode QueryById(long id)
        {
            return ManagedCommand.QueryById<RestrictionReasonCode>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public RestrictionReasonCode Insert(RestrictionReasonCode restrictionReasonCode)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(restrictionReasonCode, AddInsertParameters, INSERT_STORED_PROCEDURE);
            restrictionReasonCode.Id = long.Parse(idParameter.Value.ToString());
            return restrictionReasonCode;
        }

        public List<RestrictionReasonCode> QueryAll(long SiteId)               //ayman restriction reason codes
        {
            SqlCommand command = ManagedCommand;
            command.Parameters.Add("@SiteID", SiteId);
            return command.QueryForListResult<RestrictionReasonCode>(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public void Update(RestrictionReasonCode restrictionReasonCode)
        {
            SqlCommand command = ManagedCommand;                       
            command.Update(restrictionReasonCode, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }
        
        public void Remove(RestrictionReasonCode reasonCode)
        {
            ManagedCommand.ExecuteNonQuery(reasonCode, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        private static void AddRemoveParameters(RestrictionReasonCode restrictionReasonCode, SqlCommand command)
        {
            command.AddParameter("@Id", restrictionReasonCode.Id);
            command.AddParameter("@LastModifiedUserId", restrictionReasonCode.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", restrictionReasonCode.LastModifiedDate);
            command.AddParameter("@SiteID", restrictionReasonCode.SiteID);    //ayman restriction reason codes
        }

        private RestrictionReasonCode PopulateInstance(SqlDataReader reader)
        {
            long newId = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            bool deleted = reader.Get<bool>("Deleted");
            User user = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");

            long siteid = reader.Get<long>("siteid");     //ayman restriction reason codes

            RestrictionReasonCode restrictionReasonCode = new RestrictionReasonCode(name, user, lastModifiedDate, siteid)         //ayman restriction reason codes
                                                              {
                                                                  Deleted = deleted,
                                                                  Id = newId
                                                              };

            return restrictionReasonCode;
        }

        private void AddInsertParameters(RestrictionReasonCode restrictionReasonCode, SqlCommand command)
        {
            SetCommonParameters(restrictionReasonCode, command);                  
        }

        private static void AddUpdateParameters(RestrictionReasonCode restrictionReasonCode, SqlCommand command)
        {
            command.AddParameter("@Id", restrictionReasonCode.Id);
         //   command.AddParameter("@SiteID", restrictionReasonCode.SiteID);   //ayman restriction reason codes
            SetCommonParameters(restrictionReasonCode, command);
        }

        private static void SetCommonParameters(RestrictionReasonCode restrictionReasonCode, SqlCommand command)
        {
            command.AddParameter("@Name", restrictionReasonCode.Name);
            command.AddParameter("@LastModifiedUserId",  restrictionReasonCode.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime",  restrictionReasonCode.LastModifiedDate);
            command.AddParameter("@SiteID", restrictionReasonCode.SiteID);     //ayman restriction reason codes
        }

    }
}
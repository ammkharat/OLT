using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;


namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SiteCommunicationDao : AbstractManagedDao, ISiteCommunicationDao
    {
        private readonly IUserDao userDao;

        public SiteCommunicationDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        //ayman site communication
        public List<SiteCommunication> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<SiteCommunication>(PopulateInstance, "QueryAllSiteCommunication");
        }

        public List<SiteCommunication> QueryBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<SiteCommunication>(PopulateInstance , "QuerySiteCommunicationBySiteId");
        }

        //ayman site communication
        public List<SiteCommunication> InsertAllSites(SiteCommunication siteCommunication)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.AddParameter("Message", siteCommunication.Message);
            command.AddParameter("StartDateTime", siteCommunication.StartDateTime);
            command.AddParameter("EndDateTime", siteCommunication.EndDateTime);
            command.AddParameter("LastModifiedByUserId", siteCommunication.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", siteCommunication.LastModifiedDateTime);
            command.AddParameter("SiteId", siteCommunication.SiteId);
            command.AddParameter("CreatedByUserId", siteCommunication.CreatedByUser.IdValue);
            command.AddParameter("CreatedDateTime", siteCommunication.CreatedDateTime);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "InsertAllSiteCommunication";

            return command.QueryForListResult<SiteCommunication>(PopulateInstance, "InsertAllSiteCommunication");
        }

        public SiteCommunication Insert(SiteCommunication siteCommunication)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();

            command.Insert(siteCommunication, AddInsertParameters, "InsertSiteCommunication");
            siteCommunication.Id = (long)idParameter.Value;
            return siteCommunication;
        }

        public void Update(SiteCommunication siteCommunication)
        {
            ManagedCommand.Update(siteCommunication, AddUpdateParameters, "UpdateSiteCommunication");
        }

        public void Remove(SiteCommunication siteCommunication)
        {
            ManagedCommand.ExecuteNonQuery<SiteCommunication>(siteCommunication, "RemoveSiteCommunication", AddRemoveParameters);
        }

        protected static void AddUpdateParameters(SiteCommunication siteCommunication, SqlCommand command)
        {
            command.AddParameter("@Id", siteCommunication.Id);
            SetInsertAndUpdateParameters(siteCommunication, command);
        }

        private void AddInsertParameters(SiteCommunication siteCommunication, SqlCommand command)
        {
            SetInsertAndUpdateParameters(siteCommunication, command);
            command.AddParameter("SiteId", siteCommunication.SiteId);
            command.AddParameter("CreatedByUserId", siteCommunication.CreatedByUser.IdValue);
            command.AddParameter("CreatedDateTime", siteCommunication.CreatedDateTime);
        }

        private static void SetInsertAndUpdateParameters(SiteCommunication siteCommunication, SqlCommand command)
        {
            command.AddParameter("Message", siteCommunication.Message);
            command.AddParameter("StartDateTime", siteCommunication.StartDateTime);
            command.AddParameter("EndDateTime", siteCommunication.EndDateTime);
            command.AddParameter("LastModifiedByUserId", siteCommunication.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", siteCommunication.LastModifiedDateTime);
        }

        private void AddRemoveParameters(SiteCommunication siteCommunication, SqlCommand command)
        {
            command.AddParameter("@Id", siteCommunication.Id);
        }

        private SiteCommunication PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            long siteId = reader.Get<long>("SiteId");
            string sitename = reader.Get<string>("SiteName");                        //ayman site communication
            string message = reader.Get<string>("Message");            
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");

            User createdByUser = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createdByDateTime = reader.Get<DateTime>("CreatedDateTime");

            User lastModifiedByUser = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            DateTime lastModifiedByDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            SiteCommunication siteCommunication = new SiteCommunication(id, siteId,sitename, message, startDateTime, endDateTime, createdByUser, createdByDateTime);
            siteCommunication.LastModifiedBy = lastModifiedByUser;
            siteCommunication.LastModifiedDateTime = lastModifiedByDateTime;

            return siteCommunication;
        }

    }
}

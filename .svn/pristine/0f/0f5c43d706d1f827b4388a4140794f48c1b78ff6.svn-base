using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class BusinessCategoryDao : AbstractManagedDao, IBusinessCategoryDao
    {
        private const string QUERY_BY_SITE_STORED_PROCEDURE = "QueryBusinessCategoryBySiteId";
        private const string INSERT_STORED_PROCEDURE = "InsertBusinessCategory";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryBusinessCategoryById";        
        private const string REMOVE_STORED_PROCEDURE = "RemoveBusinessCategory";
        private const string UPDATE_STORED_PROCEDURE = "UpdateBusinessCategory";

        private const string QUERY_DEFAULT_SAP_WORK_ORDER_CATEGORY = "QueryBusinessCategoryDefaultSAPWorkOrderCategory";
        private const string QUERY_DEFAULT_SAP_NOTIFICATION_CATEGORY = "QueryBusinessCategoryDefaultSAPNotificationCategory";
        
        private readonly IUserDao userDao;
        
        public BusinessCategoryDao()
        {            
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<BusinessCategory> QueryAllBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult < BusinessCategory>(PopulateInstance, QUERY_BY_SITE_STORED_PROCEDURE);
        }

        public BusinessCategory Insert(BusinessCategory category)
        {
            SqlCommand command = ManagedCommand;
            
            long id = command.InsertAndReturnId(category, AddInsertParameters, INSERT_STORED_PROCEDURE);
            category.Id = id;
            return category;
        }

        public void Update(BusinessCategory businessCategory)
        {
            SqlCommand command = ManagedCommand;
            command.Update(businessCategory, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        public BusinessCategory QueryById(long id)
        {
            return ManagedCommand.QueryById<BusinessCategory>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public BusinessCategory GetDefaultSAPWorkOrderCategory(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForSingleResult<BusinessCategory>(PopulateInstance, QUERY_DEFAULT_SAP_WORK_ORDER_CATEGORY);           
        }

        public BusinessCategory GetDefaultSAPNotificationCategory(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForSingleResult<BusinessCategory>(PopulateInstance, QUERY_DEFAULT_SAP_NOTIFICATION_CATEGORY);           
        }

        private BusinessCategory PopulateInstance(SqlDataReader reader)
        {
            long newId = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            string shortName = reader.Get<string>("ShortName");
            bool deleted = reader.Get<bool>("Deleted");

            bool isSAPWorkOrderDefault = reader.Get<bool>("IsSAPWorkOrderDefault");
            bool isSAPNotificationDefault = reader.Get<bool>("IsSAPNotificationDefault");

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDate = reader.Get<DateTime>("CreatedDateTime");

            long siteId = reader.Get<long>("SiteId");

            BusinessCategory businessCategory = new BusinessCategory(
                    name, shortName, isSAPWorkOrderDefault, isSAPNotificationDefault,
                        lastModifiedBy, lastModifiedDate, createdDate, siteId) {Deleted = deleted, Id = newId};

            return businessCategory;
        }

        public void Remove(BusinessCategory businessCategory)
        {
            SqlCommand managedCommand = ManagedCommand;

            managedCommand.AddParameter("@LastModifiedUserId", businessCategory.LastModifiedBy.Id);
            managedCommand.AddParameter("@LastModifiedDateTime", businessCategory.LastModifiedDateTime);

            managedCommand.ExecuteNonQuery(businessCategory, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        private static void AddRemoveParameters(BusinessCategory businessCategory, SqlCommand command)
        {
            command.AddParameter("@Id", businessCategory.Id);
        }

        private static void AddInsertParameters(BusinessCategory category, SqlCommand command)
        {
            command.AddParameter("@CreatedDateTime", category.CreatedDateTime);            
            command.AddParameter("@SiteId", category.SiteId);
            SetCommonAttributes(category, command);
        }

        private static void AddUpdateParameters(BusinessCategory businessCategory, SqlCommand command)
        {
            command.AddParameter("@Id", businessCategory.Id);
            command.AddParameter("@Deleted", businessCategory.Deleted);
            SetCommonAttributes(businessCategory, command);
        }

        private static void SetCommonAttributes(BusinessCategory category, SqlCommand command)
        {            
            command.AddParameter("@Name", category.Name);
            command.AddParameter("@ShortName", category.ShortName);

            command.AddParameter("@IsSAPWorkOrderDefault", category.IsDefaultSAPWorkOrderCategory);
            command.AddParameter("@IsSAPNotificationDefault", category.IsDefaultSAPNotificationCategory);

            command.AddParameter("@LastModifiedUserId", category.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", category.LastModifiedDateTime);            
        }
    }
}
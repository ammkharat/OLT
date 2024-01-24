using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DropdownValueDao : AbstractManagedDao, IDropdownValueDao
    {
        private const string QUERY_BY_KEY_STORED_PROCEDURE = "QueryDropdownValuesByKey";
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllDropdownValues";
        private const string INSERT_STORED_PROCEDURE = "InsertDropdownValue";
        private const string REMOVE_STORED_PROCEDURE = "RemoveDropdownValue";
        private const string UPDATE_STORED_PROCEDURE = "UpdateDropdownValue";

        public List<DropdownValue> QueryAll(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public List<DropdownValue> QueryByKey(long siteId, string key)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@Key", key);

            return command.QueryForListResult(PopulateInstance, QUERY_BY_KEY_STORED_PROCEDURE);
        }

        public void Update(DropdownValue value)
        {
            ManagedCommand.Update(value, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private static void AddUpdateParameters(DropdownValue value, SqlCommand command)
        {
            command.AddParameter("@Id", value.Id);
            SetCommonAttributes(value, command);
        }

        public void Remove(DropdownValue value)
        {
            ManagedCommand.ExecuteNonQuery(value, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public void Insert(DropdownValue value)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(value, AddInsertParameters, INSERT_STORED_PROCEDURE);
            value.Id = id;
        }
        
        private static DropdownValue PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string key = reader.Get<string>("Key") ?? string.Empty;
            string value = reader.Get<string>("Value") ?? string.Empty;
            int displayOrder = reader.Get<int>("DisplayOrder");
            long siteId = reader.Get<long>("SiteId");

            DropdownValue dropdownValue = new DropdownValue(id, siteId, key, value, displayOrder);

            return dropdownValue;
        }

        private static void AddInsertParameters(DropdownValue value, SqlCommand command)
        {
            command.AddParameter("@SiteId", value.SiteId);
            SetCommonAttributes(value, command);
        }

        private void AddRemoveParameters(DropdownValue value, SqlCommand command)
        {
            command.AddParameter("@Id", value.Id);
        }

        private static void SetCommonAttributes(DropdownValue value, SqlCommand command)
        {            
            command.AddParameter("@Key", value.Key);
            command.AddParameter("@Value", value.Value);
            command.AddParameter("@DisplayOrder", value.DisplayOrder);
        }

    }
}
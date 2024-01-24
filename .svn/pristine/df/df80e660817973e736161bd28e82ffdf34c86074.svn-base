using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CustomFieldDropDownValueDao : AbstractManagedDao, ICustomFieldDropDownValueDao
    {
        private const string QUERY_BY_CUSTOM_FIELD_ID_STORED_PROCEDURE = "QueryCustomFieldDropDownValuesByCustomFieldId";
        private const string INSERT_STORED_PROCEDURE = "InsertCustomFieldDropDownValue";

        public List<CustomFieldDropDownValue> QueryByCustomFieldId(long? customFieldId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CustomFieldId", customFieldId);

            return command.QueryForListResult<CustomFieldDropDownValue>(PopulateInstance, QUERY_BY_CUSTOM_FIELD_ID_STORED_PROCEDURE);
        }

        public List<string> QueryByCustomFieldIdForReading(long? customFieldId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CustomFieldId", customFieldId);

            return command.QueryForListResult<string>(PopulateInstanceForReading, QUERY_BY_CUSTOM_FIELD_ID_STORED_PROCEDURE);
        }


        public void Insert(CustomFieldDropDownValue customFieldDropDownValue)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(customFieldDropDownValue, AddInsertParameters, INSERT_STORED_PROCEDURE);
        }

        public void DeleteByCustomFieldId(long customFieldId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CustomFieldId", customFieldId);
            command.ExecuteNonQuery("DeleteCustomFieldDropdownValuesByCustomFieldId");
        }

        private void AddInsertParameters(CustomFieldDropDownValue dropDownValue, SqlCommand command)
        {
            command.AddParameter("@CustomFieldId", dropDownValue.CustomFieldId);
            command.AddParameter("@DisplayOrder", dropDownValue.DisplayOrder);
            command.AddParameter("@Value", dropDownValue.Value);
        }

        private static CustomFieldDropDownValue PopulateInstance(SqlDataReader reader)
        {
            long customFieldId = reader.Get<long>("CustomFieldId");
            string value = reader.Get<string>("Value");
            int displayOrder = reader.Get<int>("DisplayOrder");

            CustomFieldDropDownValue dropdownValue = new CustomFieldDropDownValue(customFieldId, value, displayOrder);

            return dropdownValue;
        }

        private static string PopulateInstanceForReading(SqlDataReader reader)
        {
            string value = reader.Get<string>("Value");
            var dropdownValue = value;

            return dropdownValue;
        }
    }
}

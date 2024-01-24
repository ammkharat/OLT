using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public abstract class AbstractCustomFieldEntryDao : AbstractManagedDao
    {
        protected abstract string InsertStoredProcedureName { get; }
        protected abstract string QueryByParentIdStoredProcedureName { get; }
        protected abstract string UpdateStoredProcedureName { get; }
        protected abstract string DeleteThoseNoLongerAssociatedToEntityStoredProcedureName { get; }
        protected abstract string QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName { get; }

        protected abstract string ParentEntityIdParameter { get; }

        public CustomFieldEntry Insert(CustomFieldEntry fieldEntry, long entityId)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter(ParentEntityIdParameter, entityId);
            long id = command.InsertAndReturnId(fieldEntry, AddInsertParameters, InsertStoredProcedureName);
            fieldEntry.Id = id;
            return fieldEntry;
        }

        //ayman action item reading
        public long GetTrackerLastBatchNumber()
        {
            SqlCommand command = ManagedCommand;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetTrackerLastBatchNumber";
            return (long)command.ExecuteScalar();
        }

        //ayman action item reading
        public CustomFieldEntry InsertTracker(CustomFieldEntry fieldEntry, long entityId, long Batchnumber)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter(ParentEntityIdParameter, entityId);
            command.AddParameter("@BatchNumber", Batchnumber+1);
            command.InsertAndReturnId(fieldEntry, AddInsertTrackerParameters, "InsertActionItemResponseTracker");
            return fieldEntry;
        }

        //ayman action item reading
        private bool PopulateInstanceForNewValue(SqlDataReader reader)
        {
            var readingvalue = reader.Get<bool>("NewNumericFieldEntry");
            return readingvalue;
        }

        //ayman action item reading
        //private Decimal? GetNewNumericFieldEntry(long customfieldid,long actionitemid)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@CustomFieldId", customfieldid);
        //    command.AddParameter("@ActionItemId", actionitemid);
        //    command.CommandType = System.Data.CommandType.StoredProcedure;
        //    command.CommandText = "GetActionItemCustomFieldNewNumericValue";
        //    var newValue = command.ExecuteScalar();
        //    return (Decimal?)newValue;
        //}

        protected List<CustomFieldEntry> QueryByParentEntityId(long entityId)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter(ParentEntityIdParameter, (object) entityId);
            return command.QueryForListResult<CustomFieldEntry>(PopulateInstance, QueryByParentIdStoredProcedureName);
        }

        public void Update(CustomFieldEntry entry)
        {
            SqlCommand command = ManagedCommand;
            command.Update(entry, AddUpdateParameters, UpdateStoredProcedureName);
        }

        public void DeleteThoseNoLongerAssociatedToEntity(long entityId, List<CustomFieldEntry> customFieldEntriesAssociatedToEntity)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("EntityId", entityId);
            command.AddParameter("CsvCustomFieldEntryIdsAssociatedToEntity", customFieldEntriesAssociatedToEntity.ConvertAll(entry => entry.IdValue).BuildCommaSeparatedList());
            command.ExecuteNonQuery(DeleteThoseNoLongerAssociatedToEntityStoredProcedureName);
        }

        public List<NumericCustomFieldEntryDTO> QueryNumericCustomFieldEntriesForLogs(long customFieldId, long workAssignmentId, Site site, DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", site.IdValue);
            command.AddParameter("WorkAssignmentId", workAssignmentId);
            command.AddParameter("CustomFieldId", customFieldId);
            command.AddParameter("StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("NumericType", true);

            return command.QueryForListResult<NumericCustomFieldEntryDTO>(PopulateNumericCustomFieldEntryDto, QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName);
        }

        public List<NonnumericCustomFieldEntryDTO> QueryNonnumericCustomFieldEntriesForLogs(long customFieldId, long workAssignmentId, Site site, DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId", site.IdValue);
            command.AddParameter("WorkAssignmentId", workAssignmentId);
            command.AddParameter("CustomFieldId", customFieldId);
            command.AddParameter("StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("NumericType", false);

            return command.QueryForListResult<NonnumericCustomFieldEntryDTO>(PopulateNonnumericCustomFieldEntryDto, QueryNumericOrNonnumericCustomFieldEntriesStoredProcedureName);
        }

        private static void AddUpdateParameters(CustomFieldEntry entry, SqlCommand command)
        {
            command.AddParameter("@Id", entry.Id);
            SetCommonAttributes(entry, command);
        }

        private static void SetCommonAttributes(CustomFieldEntry entry, SqlCommand command)
        {
            command.AddParameter("@FieldEntry", entry.FieldEntry);
            command.AddParameter("@NumericFieldEntry", entry.NumericFieldEntry);
        }

        private static void AddInsertParameters(CustomFieldEntry entry, SqlCommand command)
        {
            SetCommonAttributes(entry, command);
            command.AddParameter("@CustomFieldId", entry.CustomFieldId);
            command.AddParameter("@DisplayOrder", entry.DisplayOrder);
            command.AddParameter("@CustomFieldName", entry.CustomFieldName);
            if (entry.Type != null)
            {
                command.AddParameter("@TypeId", entry.Type.IdValue);
            }
            else
            {
                command.AddParameter("@TypeId", 0);
            }
            command.AddParameter("@PhdLinkTypeId", entry.PhdLinkType);
        }

        //ayman action item reading
        private static void AddInsertTrackerParameters(CustomFieldEntry entry, SqlCommand command)
        {
            command.AddParameter("@CustomFieldId", entry.CustomFieldId);
            command.AddParameter("@CustomFieldName", entry.CustomFieldName);
            command.AddParameter("@FieldEntry", entry.FieldEntry);
            command.AddParameter("@DisplayOrder", entry.DisplayOrder);
            command.AddParameter("@TypeId", entry.Type.IdValue);
            command.AddParameter("@CurrentNumericFieldEntry", entry.NumericFieldEntry);
            command.AddParameter("@NewNumericFieldEntry", entry.NewNumericFieldEntry);
            command.AddParameter("@PhdLinkTypeId", entry.PhdLinkType);
        }

        private static CustomFieldEntry PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long customFieldId = reader.Get<long>("CustomFieldId");
            string customFieldName = reader.Get<string>("CustomFieldName");
            string fieldEntry = reader.Get<string>("FieldEntry");
            decimal? numericFieldEntry = reader.Get<decimal?>("NumericFieldEntry");
            int displayOrder = reader.Get<int>("DisplayOrder");
            CustomFieldType type = CustomFieldType.FindById(reader.Get<byte>("TypeId"));
            byte phdLinkTypeId = reader.Get<byte>("PhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();
            //E&U Custom Field changes start
            decimal? greaterthan = IsColumnExists(reader, "GreaterThanValue") ? reader.Get<decimal?>("GreaterThanValue") : null;
            decimal? lessthan = IsColumnExists(reader, "LessThanValue") ? reader.Get<decimal?>("LessThanValue") : null;
            decimal? maxvalue = IsColumnExists(reader, "RangeGreaterThanValue") ? reader.Get<decimal?>("RangeGreaterThanValue") : null;
            decimal? minvalue = IsColumnExists(reader, "RangeLessThanValue") ? reader.Get<decimal?>("RangeLessThanValue") : null;
            string color = IsColumnExists(reader, "COLOR") ? reader.Get<string>("COLOR"): "B";
            //E&U Custom Field changes end
            return new CustomFieldEntry(id, customFieldId, customFieldName, fieldEntry, numericFieldEntry,null, displayOrder, type, phdLinkType, minvalue, maxvalue, greaterthan, lessthan, color,null); // Custom Field Changes By : Swapnil Patki
        }

        //Added new for E&U changes
        private static bool IsColumnExists(System.Data.IDataReader dr, string columnName)
        {
            bool retVal = false;

            dr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);
            if (dr.GetSchemaTable().DefaultView.Count > 0)
            {
                retVal = true;
            }
            return retVal;

            //for (int i = 0; i < dr.FieldCount; i++)
            //{
            //    if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
            //        return true;
            //}
            //return false;
        }

        private NumericCustomFieldEntryDTO PopulateNumericCustomFieldEntryDto(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            decimal numericValue = reader.Get<decimal>("NumericFieldEntry");
            DateTime dateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return new NumericCustomFieldEntryDTO(id, numericValue, dateTime);
        }

        private NonnumericCustomFieldEntryDTO PopulateNonnumericCustomFieldEntryDto(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string value = reader.Get<string>("FieldEntry");
            DateTime dateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return new NonnumericCustomFieldEntryDTO(id, value, dateTime);
        }
    }
}
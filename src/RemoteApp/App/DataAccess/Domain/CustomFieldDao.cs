using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CustomFieldDao : AbstractManagedDao, ICustomFieldDao
    {
        private readonly ITagDao tagDao;
        private readonly ICustomFieldDropDownValueDao dropDownValueDao;

        public CustomFieldDao()
        {
            tagDao = DaoRegistry.GetDao<ITagDao>();
            dropDownValueDao = DaoRegistry.GetDao<ICustomFieldDropDownValueDao>();
        }

        public List<CustomField> QueryByGroupId(long customFieldGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CustomFieldGroupId", customFieldGroupId);
            return command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByGroupId");
        }

        //ayman action item reading
        public void InsertTracker(ActionItemResponseTracker actionitem)
        {
            SqlCommand command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(actionitem, AddInsertParamsForTracker, "[InsertActionItemResponseTracker]");
        }

        public CustomField Insert(long customFieldGroupId, CustomField field)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(field, AddInsertParameters, "InsertCustomField");

            field.Id = id;
            field.OriginCustomFieldId = field.OriginCustomFieldId ?? field.Id;
            field.GroupId = customFieldGroupId;

            ICustomFieldGroupDao groupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            groupDao.AddFieldsToGroup(customFieldGroupId, new List<CustomField> { field });

            if (field.Type.Equals(CustomFieldType.DropDownList) && field.DropDownValues != null)
            {
                InsertDropDownValues(field);
            }

            return field;
        }

        private void InsertDropDownValues(CustomField field)
        {
            foreach (CustomFieldDropDownValue customFieldDropDownValue in field.DropDownValues)
            {
                customFieldDropDownValue.CustomFieldId = field.Id;
                dropDownValueDao.Insert(customFieldDropDownValue);
            }
        }

        //ayman action item reading
        private static void AddInsertParamsForTracker(ActionItemResponseTracker tracker, SqlCommand command)
        {
            command.AddParameter("@ActionItemDefinitionId", tracker.ActionItemDefinitionId);
            command.AddParameter("@ActionItemId", tracker.ActionItemId);
            command.AddParameter("@BatchNumber", tracker.BatchNumber + 1);
            command.AddParameter("@CustomFieldId", tracker.CustomFieldId);
            command.AddParameter("@CustomFieldName", tracker.CustomFieldName);
            command.AddParameter("@FieldEntry", null);
            if (tracker.FieldEntry == "Unavailable")
            {
                command.AddParameter("@DisplayField", "");
            }
            else
            {
                //Added by Mukesh to set Numerici value to filed entryy
                if (tracker.FieldEntry==null && tracker.NumericFieldEntry!=null)
                {
                    tracker.FieldEntry =Convert.ToString(tracker.NumericFieldEntry);
                }
                //End
                command.AddParameter("@DisplayField", tracker.FieldEntry);
            }
            command.AddParameter("@DisplayOrder", tracker.DisplayOrder);
            command.AddParameter("@TypeId", tracker.TypeId);
            command.AddParameter("@NewNumericFieldEntry", null);
            command.AddParameter("@PhdLinkTypeId", tracker.PhdLinkTypeId);
            command.AddParameter("@Comment", tracker.Comment);
        }

        private static void AddInsertParameters(CustomField customField, SqlCommand command)
        {
            AddCommonParameters(customField, command);
            command.AddParameter("@OriginCustomFieldId", customField.OriginCustomFieldId);
        }

        private static void AddUpdateParameters(CustomField customField, SqlCommand command)
        {
            command.ClearParameters();
            command.AddParameter("@Id", customField.Id);
            AddCommonParameters(customField, command);
        }        
        
        private static void AddCommonParameters(CustomField customField, SqlCommand command)
        {
            command.AddParameter("@Name", customField.Name);
            command.AddParameter("@TypeId", customField.Type.IdValue);
            command.AddParameter("@PhdLinkTypeId", customField.PhdLinkType);
            command.AddParameter("@TagId", customField.TagInfo == null ? null : customField.TagInfo.Id);
            command.AddParameter("@GreaterThan", customField.GreaterThanValue == null ? null : customField.GreaterThanValue);  // Custom Field Changes By : Swapnil Patki
            command.AddParameter("@LessThan", customField.LessThanValue == null ? null : customField.LessThanValue); // Custom Field Changes By : Swapnil Patki
            command.AddParameter("@RangeMin", customField.MinValueofRange == null ? null : customField.MinValueofRange); // Custom Field Changes By : Swapnil Patki
            command.AddParameter("@RangeMax", customField.MaxValueofRange == null ? null : customField.MaxValueofRange); // Custom Field Changes By : Swapnil Patki
            command.AddParameter("@Date", customField.Date); // Custom Field Changes By : Swapnil Patki
            command.AddParameter("@IsActive", customField.IsActive); // Custom Field Changes By : Swapnil Patki
            
        }

        public List<CustomField> QueryByWorkAssignmentForSummaryLogs(WorkAssignment assignment)
        {
            return QueryByWorkAssignment(assignment, "@appliesToSummaryLogs");
        }

        public List<CustomField> QueryByWorkAssignmentForLogs(WorkAssignment assignment)
        {
            return QueryByWorkAssignment(assignment, "@appliesToLogs");                        
        }

        //ayman custom fields DMND0010030
        public List<CustomField> QueryCustomFieldsForActionItems(long actionitemId)
        {
            return Queryforactionitems(actionitemId);
        }

        ////ayman action item reading
        //public List<ActionItemResponseTracker> QueryActionItemResponseTracker(long actionitemId)
        //{
        //    return QueryForactionitemResponseTracker(actionitemId);
        //}

        public List<CustomField> QueryByWorkAssignmentForDailyDirectives(WorkAssignment assignment)
        {
            return QueryByWorkAssignment(assignment, "@appliesToDailyDirectives");                           
        }
        
        public void Update(CustomField field, out bool aNewCustomFieldWasInserted)
        {
            SqlCommand command = ManagedCommand;
            CustomField originalField = command.QueryById<CustomField>(field.IdValue, PopulateInstance, "QueryCustomFieldById");

            // If the name of a custom field has changed, create a new field. This is so that old logs can show the name of the field as it was when the log was created.
            if (ShouldCreateNewField(originalField, field))
            {
                field = field.Clone();
                field.OriginCustomFieldId = originalField.OriginCustomFieldId;

                Insert(field.GroupId.Value, field);
                aNewCustomFieldWasInserted = true;
            }
            else
            {
                dropDownValueDao.DeleteByCustomFieldId(field.IdValue);

                command.Update(field, AddUpdateParameters, "UpdateCustomField");
                aNewCustomFieldWasInserted = false;

                if (field.Type.Equals(CustomFieldType.DropDownList) && field.DropDownValues != null)
                {
                    InsertDropDownValues(field);
                }
            }
        }

        private bool ShouldCreateNewField(CustomField originalField, CustomField field)
        {
            return originalField.Name != field.Name;
        }

        //ayman custom fields DMND0010030
        public List<CustomField> QueryByCustomFieldGroupsForActionItems(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemId", id);

            List<CustomField> customFields = command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByGroupsForActionItem");
            CustomField.SortAndResetDisplayOrder(customFields);
            return customFields;
        }

        //ayman custom fields DMND0010030
        public List<CustomField> QueryByCustomFieldGroupsForActionItemDefinition(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", id);

            List<CustomField> customFields = command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByGroupsForActionItemDefinition");
            CustomField.SortAndResetDisplayOrder(customFields);
            return customFields;
        }

        public List<CustomField> QueryByCustomFieldGroupsForSummaryLogs(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SummaryLogId", id);

            List<CustomField> customFields = command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByGroupsForSummaryLog");
            CustomField.SortAndResetDisplayOrder(customFields);
            return customFields;
        }

        public List<CustomField> QueryByCustomFieldGroupsForLogs(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogId", id);

            List<CustomField> customFields = command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByGroupsForLog");
            CustomField.SortAndResetDisplayOrder(customFields);
            return customFields;
        }

        public List<CustomField> QueryByCustomFieldGroupsForLogDefinitions(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogDefinitionId", id);

            List<CustomField> customFields = command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByGroupsForLogDefinition");
            CustomField.SortAndResetDisplayOrder(customFields);
            return customFields;
        }


        //ayman custom fields DMND0010030
        private List<CustomField> Queryforactionitems(long actionitemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemId", actionitemId);
            return command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldForActionItems");
        }

        //ayman action item reading
        public List<ActionItemResponseTracker> QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId(long entryId,long actionitemid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@EntryId", entryId);
            command.AddParameter("@ActionItemId", actionitemid);
            return command.QueryForListResult<ActionItemResponseTracker>(PopulateInstanceTracker, "QueryActionItemResponseTrackerEntryByEntryIdAndActionItemId");
        }

        //ayman action item reading
        public List<Dictionary<long,string>> GetLastReading(long actionitemdefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionitemdefinitionId);
            return command.QueryForListResult(PopulateInstanceReading, "GetLastReading");
        }
        
        //ayman action item reading
        public List<ActionItemResponseTracker> QueryActionItemResponseTracker(long actionitemdefinitionId, long actionitemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionitemdefinitionId);
            command.AddParameter("@ActionItemId", actionitemId);
            return command.QueryForListResult<ActionItemResponseTracker>(PopulateInstanceTracker, "QueryActionItemResponseTracker");
        }

        private List<CustomField> QueryByWorkAssignment(WorkAssignment assignment, string appliesToFieldName)
        {
            if (assignment == null)
            {
                return new List<CustomField>();
            }

            SqlCommand command = ManagedCommand;
            command.AddParameter("@AssignmentId", assignment.IdValue);
            command.AddParameter(appliesToFieldName, true);

            return command.QueryForListResult<CustomField>(PopulateInstance, "QueryCustomFieldByWorkAssignment");                                           
        }

        //ayman action item reading
        private Dictionary<long,string> PopulateInstanceReading(SqlDataReader reader)
        {
            long customfieldid = reader.Get<long>("customfieldid");
            string displayfield = reader.Get<string>("displayField");
            Dictionary<long, string> value = new Dictionary<long, string>();
            value.Add(customfieldid, displayfield);
            return value;
        }

        //ayman action item reading
        private ActionItemResponseTracker PopulateInstanceTracker(SqlDataReader reader)
        {
            long actionitemdefinitionid = reader.Get<long>("actionitemdefinitionid");
            long actionitemid = reader.Get<long>("actionitemid");
            long customfieldid = reader.Get<long>("customfieldid");
            string actionitemcustomfieldname = reader.Get<string>("actionitemcustomfieldname");
            decimal? currentvalue = reader.Get<decimal?>("currentnumericfieldentry");
            decimal? newvalue = reader.Get<decimal?>("newnumericfieldentry");
            int displayorder = reader.Get<int>("displayorder");
            string comment = string.Empty; // = reader.Get<string>("comment");
            byte phdlinktype = reader.Get<byte>("PHDLinkTypeId");
            long batchnumber = reader.Get<long>("BatchNumber");
            byte typeid = reader.Get<byte>("TypeId");
            string fieldentry = null; // reader.Get<string>("FieldEntry");
            List<string> dropDownValues = new List<string>();
            if (typeid == 2)
            {
               dropDownValues = dropDownValueDao.QueryByCustomFieldIdForReading(customfieldid);
            }
            string displayfield = reader.Get<string>("DisplayField");

            ActionItemResponseTracker tracker = new ActionItemResponseTracker(actionitemdefinitionid, actionitemid, customfieldid, actionitemcustomfieldname, displayorder,typeid, currentvalue, newvalue,comment,phdlinktype,batchnumber,fieldentry, dropDownValues, displayfield);

            return tracker;
        }

        private CustomField PopulateInstance(SqlDataReader reader)
        {
            TagInfo tagInfo = null;
            long? tagId = reader.Get<long?>("TagId");
            if (tagId != null)
            {
                tagInfo = tagDao.QueryById(tagId.Value);
            }

            long id = reader.Get<long>("Id");

            byte typeId = reader.Get<byte>("TypeId");
            CustomFieldType type = CustomFieldType.FindById(typeId);
            
            byte phdLinkTypeId = reader.Get<byte>("PhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();

            CustomField field = new CustomField(
                id,
                reader.Get<string>("Name"),
                reader.Get<int>("DisplayOrder"),
                reader.Get<long>("CustomFieldGroupId"),
                reader.Get<long>("OriginCustomFieldGroupId"),
                reader.Get<long?>("OriginCustomFieldId"),
                tagInfo,
                type, phdLinkType,null,
                //E&U Custom Field changes start
                IsColumnExists(reader, "RangeLessThanValue") ? reader.Get<decimal?>("RangeLessThanValue") : null,
                IsColumnExists(reader, "RangeGreaterThanValue") ? reader.Get<decimal?>("RangeGreaterThanValue") : null,
                IsColumnExists(reader, "GreaterThanValue") ? reader.Get<decimal?>("GreaterThanValue") : null,
                IsColumnExists(reader, "LessThanValue") ? reader.Get<decimal?>("LessThanValue") : null,
                IsColumnExists(reader, "COLOR") ? reader.Get<string>("COLOR") : null,
                IsColumnExists(reader, "IsActive") ? reader.Get<bool?>("IsActive") : null,
                null
                //reader.Get<bool>("IsActive") 
               
                ////E&U Custom Field changes end
                );

            if (type.Equals(CustomFieldType.DropDownList))
            {
                field.DropDownValues = dropDownValueDao.QueryByCustomFieldId(id); 
            }

            return field;
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
        }
    }
}
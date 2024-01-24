using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CustomFieldGroupDao : AbstractManagedDao, ICustomFieldGroupDao
    {
        private readonly ICustomFieldDao fieldDao;
        private readonly ICustomFieldGroupWorkAssignmentDao groupWorkAssignmentDao;

        public CustomFieldGroupDao()
        {
            fieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
            groupWorkAssignmentDao = DaoRegistry.GetDao<ICustomFieldGroupWorkAssignmentDao>();
        }

        public List<CustomFieldGroup> QueryCustomFieldGroupsForActionItems()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<CustomFieldGroup>(PopulateInstance, "QueryCustomFieldGroupsForActionItems");
        }

        public List<CustomFieldGroup> QueryBySite(Site site)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  site.Id.Value);
            return command.QueryForListResult<CustomFieldGroup>(PopulateInstance, "QueryCustomFieldGroupBySiteId");
        }




        public CustomFieldGroup QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForSingleResult<CustomFieldGroup>(PopulateInstance, "QueryCustomFieldGroupById");            
        }

        private CustomFieldGroup PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long? originCustomFieldGroupId = reader.Get<long?>("OriginCustomFieldGroupId");
            string name = reader.Get<string>("Name");

            bool appliesToLogs = reader.Get<bool>("AppliesToLogs");
            bool appliesToSummaryLogs = reader.Get<bool>("AppliesToSummaryLogs");
            bool appliesToDailyDirectives = reader.Get<bool>("AppliesToDailyDirectives");
            bool appliesToActionItems = reader.Get<bool>("AppliesToActionItems");            //ayman custom fields DMND0010030

            List<CustomField> fields = fieldDao.QueryByGroupId(id);
            List<WorkAssignment> workAssignments = groupWorkAssignmentDao.QueryByGroupId(id).ConvertAll(obj => obj.WorkAssignment);

            return new CustomFieldGroup(
                id,
                originCustomFieldGroupId,
                name,
                workAssignments,
                fields,
                appliesToLogs,
                appliesToSummaryLogs,
                appliesToDailyDirectives,
                appliesToActionItems);               //ayman custom fields DMND0010030
        }

        public CustomFieldGroup Insert(CustomFieldGroup group)
        {
            SqlCommand command = ManagedCommand;
            
            long id = command.InsertAndReturnId(@group, AddInsertParameters, "InsertCustomFieldGroup");
            group.Id = id;
            group.OriginCustomFieldGroupId = group.OriginCustomFieldGroupId ?? group.Id;

            InsertWorkAssignments(group);
            InsertFields(group);

            return group;
        }
       
        private static void AddInsertParameters(CustomFieldGroup group, SqlCommand command)
        {
            SetCommonParameters(command, group);
            command.AddParameter("@OriginCustomFieldGroupId", group.OriginCustomFieldGroupId);
        }

        private void InsertWorkAssignments(CustomFieldGroup group)
        {
            foreach (WorkAssignment workAssignment in group.WorkAssignments)
            {
                groupWorkAssignmentDao.Insert(group.Id.Value, new CustomFieldGroupWorkAssignment(workAssignment));
            }
        }

        private void InsertFields(CustomFieldGroup group)
        {
            foreach (CustomField field in group.Fields)
            {
                fieldDao.Insert(group.IdValue, field);
            }
        }

        // Soft delete the old group and create a new one. This is so that logs created under the old versions of a group can retain their custom fields in the correct order.
        public CustomFieldGroup Update(CustomFieldGroup group)
        {
            CustomFieldGroup originalGroup = QueryById(group.IdValue);

            List<CustomField> newGroupsFields = new List<CustomField>(group.Fields);

            List<CustomField> fieldsToInsert = new List<CustomField>();
            List<CustomField> fieldsToUpdate = new List<CustomField>();

            foreach (CustomField customField in newGroupsFields)
            {
                if (customField.Id == null)
                {
                    fieldsToInsert.Add(customField);
                }
                else if (originalGroup.Fields.ExistsById(customField))
                {
                    fieldsToUpdate.Add(customField);
                }
            }

            Remove(group);

            group = group.Clone();
            group.Fields.Clear();
            Insert(group);

            fieldsToInsert.ForEach(field => fieldDao.Insert(group.IdValue, field));
            fieldsToUpdate.ForEach(field =>
                                       {
                                           bool aNewCustomFieldWasInserted;
                                           field.GroupId = group.IdValue;
                                           fieldDao.Update(field, out aNewCustomFieldWasInserted);

                                           // If a new custom field was inserted, it was already added to the group
                                           if (!aNewCustomFieldWasInserted)
                                           {
                                               AddFieldsToGroup(group.IdValue, new List<CustomField> { field });
                                           }
                                       });


            return QueryById(group.IdValue);  // requerying is the easiest way to make sure we're returning all the correct fields
        }

        public void AddFieldsToGroup(long customFieldGroupId, List<CustomField> fields)
        {
            SqlCommand command = ManagedCommand;
            foreach (CustomField customField in fields)
            {
                command.ClearParameters();
                command.AddParameter("@CustomFieldGroupId", customFieldGroupId);
                command.AddParameter("@CustomFieldId", customField.IdValue);
                command.AddParameter("@DisplayOrder", customField.DisplayOrder);
                command.ExecuteNonQuery("AddCustomFieldsToCustomFieldGroup");
            }
        }

        //ayman custom fields DMND0010030
        public CustomFieldGroup QueryCustomFieldGroupByActionItemDefinitionId(long? actionitemDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinitionId);
            return command.QueryForSingleResult<CustomFieldGroup>(PopulateInstance, "QueryCustomFieldGroupByActionItemDefinitionId");
        }

        //ayman custom fields DMND0010030
        public CustomFieldGroup QueryCustomFieldGroupByActionItemId(long? actionitemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemId", actionitemId);
            return command.QueryForSingleResult<CustomFieldGroup>(PopulateInstance, "QueryCustomFieldGroupByActionItemId");
        }

        public List<CustomFieldGroup> QueryByLogDefinitionId(long logDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogDefinitionId", logDefinitionId);
            return command.QueryForListResult<CustomFieldGroup>(PopulateInstance, "QueryCustomFieldGroupByLogDefinitionId");
        }

        public void Remove(CustomFieldGroup group)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id",  @group.Id);
            command.ExecuteNonQuery("RemoveCustomFieldGroup");
        }

        private static void SetCommonParameters(SqlCommand command, CustomFieldGroup group)
        {
            command.AddParameter("@Name", group.Name);
            command.AddParameter("@AppliesToLogs", group.AppliesToLogs);
            command.AddParameter("@AppliesToSummaryLogs", group.AppliesToSummaryLogs);
            command.AddParameter("@AppliesToDailyDirectives", group.AppliesToDailyDirectives);
            command.AddParameter("@AppliesToActionItems", group.AppliesToActionItems);                                  //ayman custom fields DMND0010030
        } 

    }
}

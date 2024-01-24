using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ActionItemDao : AbstractManagedDao, IActionItemDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryActionItemById";
        private const string INSERT_STORED_PROCEDURE = "InsertActionItem";
        private const string REMOVE_STORED_PROCEDURE = "RemoveActionItem";
        private const string UPDATE_STORED_PROCEDURE = "UpdateActionItem";
        private readonly ICustomFieldDao customFieldDao;                         //ayman custom fields DMND0010030
        private readonly ICustomFieldDropDownValueDao dropDownValueDao;   //ayman action item reading
        private readonly IActionItemCustomFieldEntryDao customFieldEntryDao;     //ayman custom fields DMND0010030
        private const string INSERT_ACTIONITEM_CUSTOM_FIELD_GROUP = "InsertActionItemCustomFieldGroup";
        private const string REMOVE_ACTIONITEM_CUSTOM_FIELD_GROUP = "RemoveActionItemCustomFieldGroup";
        private const string UPDATE_NO_RESPONSE_REQUIRED =
            "UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed";

        private const string QUERY_ALL_ACTION_ITEMS_NEEDING_ATTENTION = "QueryAllActionItemsNeedingAttention";

        private const string QUERY_BY_ACTION_ITEM_DEFINITION_STATUS_AND_SHIFT_END =
            "QueryActionItemByActionItemDefinitionAndStatusAfterCurrentTime";

        private const string QUERY_UNRESPONDED_BY_ACTION_ITEM_DEFINITION_ID =
            "QueryUnrespondedToActionItemByActionItemDefinitionId";

        private const string INSERT_ACTION_ITEM_FUNCTIONAL_LOCATION = "InsertActionItemFunctionalLocation";

        private readonly IActionItemDefinitionDao actionItemDefinitionDao;
        private readonly IWorkAssignmentDao assignmentDao;
        private readonly IBusinessCategoryDao businessCategoryDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IUserDao userDao;

        private readonly ICustomFieldGroupDao customFieldgroupDao;     //ayman custom fields DMND0010030

        public ActionItemDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();

            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();                    //ayman custom fields DMND0010030
            dropDownValueDao = DaoRegistry.GetDao<ICustomFieldDropDownValueDao>();  //ayman action item reading
            customFieldEntryDao = DaoRegistry.GetDao<IActionItemCustomFieldEntryDao>();  //ayman custom fields DMND0010030
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
            assignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldgroupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();        //ayman custom fields DMND0010030
        }

        public ActionItem QueryById(long id)
        {
            //return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);

            //SetLogImage();
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            ActionItem aid = ManagedCommand.QueryById<ActionItem>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            if (aid != null)
            {
                SetLogImage(aid);
            }

            return aid;
            //reader.Get<long?>("CreatedByActionItemDefinitionId");
        }

        public bool QueryReadingByAIDId(long actionItemDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionID", actionItemDefinitionId);
            command.QueryForSingleResult(PopulateInstanceForReading, "QueryReadingByActionItemDefinitionId");
            return false;
        }

        //ayman action item reading
        private bool PopulateInstanceForReading(SqlDataReader reader)
        {
            var readingvalue = reader.Get<bool>("Reading");
            return readingvalue;
        }


        public void Update(ActionItem actionItem)
        {
            var command = ManagedCommand;

            command.Update(actionItem, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(actionItem);
            InsertNewDocumentLinks(actionItem);
            RemoveDeletedDocumentLinks(actionItem);
            //Dharmesh  --  End -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            UpdateCustomFieldEntries(actionItem);   //ayman custom fields DMND0010030
            UpdateTrackers(actionItem);              //ayman action item reading

        }

        //ayman action item reading
        //ayman custom fields DMND0010030
        private void UpdateTrackers(ActionItem actionItem)
        {
            long lastbatchnumber = customFieldEntryDao.GetTrackerLastBatchNumber();
            foreach (ActionItemResponseTracker trckr in actionItem.Trackers)
            {
                customFieldDao.InsertTracker(trckr);
           }
        }


        //ayman custom fields DMND0010030
        private void UpdateCustomFieldEntries(ActionItem actionItem)
        {
            long lastbatchnumber = customFieldEntryDao.GetTrackerLastBatchNumber();
            foreach (CustomFieldEntry entry in actionItem.CustomFieldEntries)
            {
                if (entry.IsInDatabase())
                {
                    customFieldEntryDao.Update(entry);
//                    customFieldEntryDao.InsertTracker(entry, actionItem.IdValue,lastbatchnumber);      //ayman action item reading
                }
                else
                {
                    customFieldEntryDao.Insert(entry, actionItem.IdValue);
 //                   customFieldEntryDao.InsertTracker(entry, actionItem.IdValue,lastbatchnumber);      //ayman action item reading
                }
            }

            customFieldEntryDao.DeleteThoseNoLongerAssociatedToEntity(actionItem.IdValue, actionItem.CustomFieldEntries);
        }

        //ayman custom fields DMND0010030
        private void InsertCustomFieldEntries(ActionItem actionitem)
        {
            actionitem.CustomFieldEntries.ForEach(entry => customFieldEntryDao.Insert(entry, actionitem.IdValue));
        }

        public void Insert(ActionItem actionItem)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(actionItem, AddInsertParameters, INSERT_STORED_PROCEDURE);
            actionItem.Id = long.Parse(idParameter.Value.ToString());
            if (actionItem.Id > 0)
            {
                if (actionItem.CustomFieldGroup != null)
                {
                    if (actionItem.CustomFieldGroup.Name != null)
                        InsertCustomFieldGroupForActionItem(actionItem, actionItem.CustomFieldGroup);     //ayman custom fields DMND0010030
                }
                InsertNewDocumentLinks(actionItem);
                //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
                RemoveDeletedDocumentLinks(actionItem);
                //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
                InsertFunctionalLocations(command, actionItem);

                //ayman custom fields DMND0010030
                if (!actionItem.CustomFields.IsEmpty())
                {
                    InsertCustomFieldEntries(actionItem);
                    InsertCustomFieldGroupRelationships(actionItem, actionItem.CustomFields.ConvertAll(field => field.GroupId.Value).Unique());
                }
            }
        }

        public void UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(ActionItemStatus newStatus, Site site,
            DateTime currentDateTimeAtSite,
            User user)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", site.Id);
            command.AddParameter("@CurrentDateTimeAtSite", currentDateTimeAtSite);
            command.AddParameter("@NewStatusId", newStatus.Id);
            command.AddParameter("@StatusModifiedUserId", user.Id);
            command.ExecuteNonQuery(UPDATE_NO_RESPONSE_REQUIRED);
        }

        public List<ActionItem> QueryAllActionItemsNeedingAttention(List<FunctionalLocation> functionalLocations)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", functionalLocations.BuildIdStringFromList());
            return command.QueryForListResult(PopulateInstance, QUERY_ALL_ACTION_ITEMS_NEEDING_ATTENTION);
        }

        public void Remove(ActionItem actionItem)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", actionItem.Id);
            ManagedCommand.ExecuteNonQuery(actionItem, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public List<ActionItem> QueryCurrentActionItemsForActionItemDefinition(
            ActionItemDefinition actionItemDefinition, DateTime currentTimeAtSite)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinition.Id);
            command.AddParameter("@Status", ActionItemStatus.Current.Id);
            command.AddParameter("@CurrentTimeAtSite", currentTimeAtSite);
            command.AddParameter("@StartDateTimeMustBeAfterCurrentTime", actionItemDefinition.Schedule.IsRecurring);

            return command.QueryForListResult(PopulateInstance, QUERY_BY_ACTION_ITEM_DEFINITION_STATUS_AND_SHIFT_END);
        }

        //ayman action item reading
        public List<TrackerReport> QueryTrackersByAidId(long aidid,DateTime startDate,DateTime Enddate)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", aidid);
            command.AddParameter("@StartDate", startDate);
            command.AddParameter("@EndDate", Enddate);
            return command.QueryForListResult(PopulateInstanceForTrackers, "GET_READINGREPORT");
           // return command.QueryForListResult(PopulateInstanceForTrackers, "GetTrackerReport");
        }

        public List<ActionItem> QueryUnrespondedToActionItemsByDefinitionId(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", id);
            return command.QueryForListResult(PopulateInstance, QUERY_UNRESPONDED_BY_ACTION_ITEM_DEFINITION_ID);
        }

        /// <summary>
        ///     Remove Deleted Document Links
        /// </summary>
        private void RemoveDeletedDocumentLinks(IDocumentLinksObject actionItem)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(actionItem, documentLinkDao.QueryByActionItemId);
        }


        //private void RemoveActionItemCustomFieldGroup(ActionItem actionItem)
        //{
        //    var command = ManagedCommand;
        //    command.AddParameter("@Id", actionItem.CustomFieldGroup.IdValue);
        //    ManagedCommand.ExecuteNonQuery(actionItem, REMOVE_ACTIONITEM_CUSTOM_FIELD_GROUP, AddRemoveParameters);
        //}


        /// <summary>
        ///     Inserts new (no id) document links associated with the Action Item
        /// </summary>
        private void InsertNewDocumentLinks(IDocumentLinksObject actionItem)
        {

            documentLinkDao.InsertNewDocumentLinks(actionItem, documentLinkDao.InsertForAssociatedActionItem);
        }


        //ayman custom fields DMND0010030
        public void InsertCustomFieldGroupForActionItem(ActionItem actionitemID, CustomFieldGroup customFieldGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_ACTIONITEM_CUSTOM_FIELD_GROUP;
            command.AddParameter("@ActionItemId", actionitemID.IdValue);
            command.AddParameter("@CustomFieldGroupId", customFieldGroupId.IdValue);
            command.ExecuteNonQuery();
        }

        //ayman custom fields DMND0010030
        private void InsertCustomFieldGroupRelationships(ActionItem actionitem, List<long> customFieldGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_ACTIONITEM_CUSTOM_FIELD_GROUP;
            command.AddParameter("@ActionItemId", actionitem.IdValue);
            command.AddParameter("@CsvCustomFieldGroupIds", customFieldGroupIds.BuildCommaSeparatedList());
            command.ExecuteNonQuery();
        }


        private static void InsertFunctionalLocations(SqlCommand command, ActionItem actionItem)
        {
            if (!actionItem.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_ACTION_ITEM_FUNCTIONAL_LOCATION;
                foreach (var functionalLocation in actionItem.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ActionItemId", actionItem.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //ayman action item reading
        private TrackerReport PopulateInstanceForTrackers(SqlDataReader reader)
        {
            //var ID = reader.Get<long>("id");
            //var actionitemcustomfieldname = reader.Get<string>("ActionItemDefinitionName");
            //var customfieldname = reader.Get<string>("CustomFieldName");
            //var listval = reader.Get<string>("ListStr");
            //var listtime = reader.Get<string>("ListTime");
            //var trackerrprt = new TrackerReport(ID, actionitemcustomfieldname, customfieldname, listval,listtime);
            //return trackerrprt;
            var customfieldname = "";
            var listval = "";
            var listtime = "";
           
                customfieldname = reader.Get<string>("ActionItemCustomFieldName");
                for (int i = 1; i < reader.FieldCount; i++)
                {
                   listtime= listtime + reader.GetName(i)+";";
                   listval = listval + reader.Get<string>(reader.GetName(i)) + ";";
                }
           
            var ID = 0;
            var actionitemcustomfieldname = "";
            var trackerrprt = new TrackerReport(ID, actionitemcustomfieldname, customfieldname, listval, listtime);
            return trackerrprt;
        }

        private ActionItem PopulateInstance(SqlDataReader reader)
        {
            var newId = reader.Get<long>("Id");

            var name = reader.Get<string>("Name");
            var description = reader.Get<string>("Description");
            var startDateTime = reader.Get<DateTime>("StartDateTime");
            var endDateTime = reader.Get<DateTime?>("EndDateTime");
            var shiftAdjustedEndDateTime = reader.Get<DateTime?>("ShiftAdjustedEndDateTime");
            var status = ActionItemStatus.Get(reader.Get<long>("ActionItemStatusId"));
            var priority = Priority.GetById(reader.Get<long>("PriorityId"));
            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            var lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            var responseRequired = reader.Get<bool>("ResponseRequired");
            var source = DataSource.GetById(reader.Get<int>("SourceId"));

            var createdByScheduleTypeId = reader.Get<int>("CreatedByScheduleTypeId");
            var createdByScheduleType = ScheduleType.GetById(createdByScheduleTypeId);
            var businessCategoryId = reader.Get<long?>("BusinessCategoryId");

            var category = !businessCategoryId.HasValue
                ? null
                : businessCategoryDao.QueryById(businessCategoryId.Value);

            var actionItemStatusModification = ReadActionItemStatusModification(reader);

            var documentLinks =
                documentLinkDao.QueryByActionItemId(newId);

            var createdByActionItemDefinitionId = reader.Get<long?>("CreatedByActionItemDefinitionId");
            var createdByActionItemDefinition = createdByActionItemDefinitionId.HasValue
                ? actionItemDefinitionDao.QueryById(createdByActionItemDefinitionId.Value)
                : null;

            var assignmentId = reader.Get<long?>("WorkAssignmentId");
            WorkAssignment assignment = null;
            if (assignmentId != null)           

            {
                assignment = assignmentDao.QueryById(assignmentId.Value);
            }

            var formGn75BId = reader.Get<long?>("FormGN75BId");

            var formGn75BId1 = reader.Get<long?>("FormGN75BId1");//mangesh: DMND0005327 - Request 15
            var formGn75BId2 = reader.Get<long?>("FormGN75BId2");

            //ayman visibility groups
            var VisGroupsStartingWith = reader.Get<string>("VisibilityGroupIDs");             //ayman visibility groups

            //ayman action item definition
            var DefinitionId = reader.Get<long>("CreatedByActionItemDefinitionId");  

            var flocs = functionalLocationDao.QueryByActionItemId(newId);


            List<CustomFieldEntry> customFieldEntries = customFieldEntryDao.QueryByActionItemId(newId);  //ayman custom fields DMND0010030
            List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForActionItems(newId);   //ayman custom fields DMND0010030
            CustomFieldGroup customFieldGroup = customFieldgroupDao.QueryCustomFieldGroupByActionItemId(newId); //ayman custom fields DMND0010030
            List<ActionItemResponseTracker> trackers = customFieldDao.QueryActionItemResponseTracker(DefinitionId, newId);         //ayman action item reading
            bool reading = createdByActionItemDefinition.Reading;          //ayman action item reading

            var actionItem = new ActionItem(name,
                description,
                responseRequired,
                status,
                priority,
                source,
                startDateTime,
                endDateTime,
                shiftAdjustedEndDateTime,
                createdByScheduleType,
                flocs,
                category,
                lastModifiedBy,
                lastModifiedDate,
                documentLinks,
                actionItemStatusModification,
                createdByActionItemDefinition,
                assignment,
                formGn75BId,
                formGn75BId1, formGn75BId2, VisGroupsStartingWith,DefinitionId,customFieldEntries,customFields, customFieldGroup,string.Empty,trackers,reading) { Id = newId };//mangesh: DMND0005327 - Request 15                   //ayman visibility groups   ayman action item definition        , customFieldEntries, customFields

            return actionItem;
        }

        private ActionItemStatusModification ReadActionItemStatusModification(SqlDataReader reader)
        {
            var previousStatusId = reader.Get<long?>("PreviousActionItemStatusId");

            if (previousStatusId.HasNoValue())
            {
                return null;
            }

            var previousActionItemStatus = ActionItemStatus.Get(previousStatusId.Value);
            var statusModifiedUser = userDao.QueryById(reader.Get<long>("StatusModifiedUserId"));
            var statusModifiedDateTime = reader.Get<DateTime>("StatusModifiedDateTime");
            return new ActionItemStatusModification(previousActionItemStatus, statusModifiedUser,
                statusModifiedDateTime);
        }

        private static void AddUpdateParameters(ActionItem actionItem, SqlCommand command)
        {
            command.AddParameter("@Id", actionItem.Id);

            if (actionItem.StatusModification != null)
            {
                command.AddParameter("@PreviousActionItemStatusId", actionItem.StatusModification.PreviousStatus.Id);
                command.AddParameter("@StatusModifiedUserId", actionItem.StatusModification.ModifiedUser.Id);
                command.AddParameter("@StatusModifiedDateTime", actionItem.StatusModification.ModifiedDateTime);
            }

            SetCommonAttributes(actionItem, command);
        }

        private static void AddInsertParameters(ActionItem actionItem, SqlCommand command)
        {
            command.AddParameter("@CreatedByScheduleTypeId", actionItem.CreatedByScheduleType.Id);
            command.AddParameter("@ShiftAdjustedEndDateTime", actionItem.ShiftAdjustedEndDateTime);
            command.AddParameter("@PriorityId", actionItem.Priority.Id);
            SetCommonAttributes(actionItem, command);
        }

        private static void SetCommonAttributes(ActionItem actionItem, SqlCommand command)
        {
            command.AddParameter("@ActionItemStatusId", actionItem.Status.Id);
            command.AddParameter("@Description", actionItem.Description);
            command.AddParameter("@StartDateTime", actionItem.StartDateTime);
            command.AddParameter("@SourceId", actionItem.Source.Id);
            command.AddParameter("@EndDateTime", actionItem.EndDateTime);
            command.AddParameter("@LastModifiedUserId", actionItem.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", actionItem.LastModifiedDate);
            command.AddParameter("@BusinessCategoryId", (actionItem.Category != null ? actionItem.Category.Id : null));
            command.AddParameter("@ResponseRequired", actionItem.ResponseRequired);
            command.AddParameter("@Name", actionItem.Name);
            command.AddParameter("@AssignmentId", (actionItem.Assignment == null ? null : actionItem.Assignment.Id));
            command.AddParameter("@FormGN75BId",
                (actionItem.AssociatedFormGn75BId.HasValue ? actionItem.AssociatedFormGn75BId.Value : (long?) null));

            //mangesh - DMND0005327 - Request 15
            command.AddParameter("@FormGN75BId1",
                (actionItem.AssociatedFormGn75BId1.HasValue ? actionItem.AssociatedFormGn75BId1.Value : (long?)null));
            command.AddParameter("@FormGN75BId2",
                (actionItem.AssociatedFormGn75BId2.HasValue ? actionItem.AssociatedFormGn75BId2.Value : (long?)null));
            //---
            var createdByActionItemDefinitionId = actionItem.CreatedByActionItemDefinition == null
                ? null
                : actionItem.CreatedByActionItemDefinition.Id;
            command.AddParameter("@CreatedByActionItemDefinitionId", createdByActionItemDefinitionId);

            //ayman visibility groups
            command.AddParameter("@VisGroupsStartingWith",actionItem.VisGroupsStartingWith);

            //ayman action item duplicate fix
            var flocids = actionItem.FunctionalLocations.Select(x => x.Id).ToArray();
            command.AddParameter("@flocIDs", flocids.ToCommaSeparatedString());

        }

        private static void AddRemoveParameters(ActionItem actionItem, SqlCommand command)
        {
            command.AddParameter("@Id", actionItem.Id);
            command.AddParameter("@LastModifiedUserId", actionItem.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", actionItem.LastModifiedDate);
        }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        private void SetLogImage(ActionItem Logs)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "GetItemImage";
            command.AddParameter("@ItemIDs", Logs.DefinitionId);
            command.AddParameter("@RecordFor", (int)ImageUploader.RecordTypes.ActionItemDef);
            SqlDataReader reader = command.ExecuteReader();
            List<ImageUploader> lst = new List<ImageUploader>();
            while (reader.Read())
            {
                ImageUploader Img = new ImageUploader();
                Img.Id = reader.Get<long>("Id");
                Img.Name = reader.Get<string>("Name");
                Img.Description = reader.Get<string>("Description");
                Img.ImagePath = reader.Get<string>("ImagePath");
                Img.Action = "";
                if (reader.Get("RecordType") != null && reader.Get<int>("RecordType") == 0)
                {
                    // Img.Types = ActionItemImage.Type.Title;
                }
                else
                {
                    Img.Types = ImageUploader.Type.Image;
                }

                lst.Add(Img);
            }
            reader.Dispose();
            Logs.Imagelist = lst;
        }
    }
}
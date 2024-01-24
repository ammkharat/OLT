using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ActionItemDefinitionDao : AbstractManagedDao, IActionItemDefinitionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryActionItemDefinitionById";
        private const string QUERY_BY_SAP_OPERATION_ID_STORED_PROCEDURE = "QueryActionItemDefinitionBySapOperationId";

        private const string QUERY_ACTIVE_BY_ASSIGNMENT_AND_PARENT_FLOCS =
            "QueryActionItemDefinitionsThatAreActiveByAssignmentAndParentFlocs";

        private const string INSERT_STORED_PROCEDURE = "InsertActionItemDefinition";


        private const string INSERT_ACTIONITEM_DEFINITION_CUSTOM_FIELD_GROUP = "InsertActionitemDefinitionCustomFieldGroup";              //ayman custom fields DMND0010030
        private const string INSERT_SEND_EMAIL = "InsertActionitemDefinitionSendEmail";              //ayman custom fields DMND0010030
        private const string INSERT_SEND_EMAIL_TO = "InsertActionitemDefinitionSendEmailTo";              //ayman custom fields DMND0010030
        private const string REMOVE_SEND_EMAIL_TO = "RemoveActionitemDefinitionSendEmailTo";              //ayman custom fields DMND0010030
        private const string QUERY_SEND_EMAIL = "QueryActionItemDefSendEmail";                       //ayman custom fields DMND0010030
        private const string QUERY_AUTO_POPULATE = "QueryAutoPopulateByActionItemDefinitionId";                            //ayman action item reading
        private const string QUERY_READING = "QueryReadingByActionItemDefinitionId";                            //ayman action item reading
        private const string QUERY_READING_BY_SITE = "QueryReadingBySite";                                 //ayman action item reading
        private const string QUERY_SEND_EMAIL_TO = "QueryActionItemDefSendEmailTo";                       //ayman custom fields DMND0010030
        private const string UPDATE_SEND_EMAIL = "UpdateActionItemDefSendEmail";                       //ayman custom fields DMND0010030


        private const string INSERT_ACTION_ITEM_FUNCTIONAL_LOCATION_ASSOCIATION =
            "InsertActionItemDefinitionFunctionalLocation";                              

        private const string QUERY_FUTURE_ACTION_ITEM_DEFINITIONS = "QueryFutureActionItemDefinitions";

        private const string REMOVE_ACTION_ITEM_FUNCTIONAL_LOCATION_ASSOCIATION =
            "RemoveActionItemDefinitionFunctionalLocation";     

        private const string REMOVE_STORED_PROCEDURE = "RemoveActionItemDefinition";
        private const string UPDATE_STORED_PROCEDURE = "UpdateActionItemDefinition";

        private const string COUNT_SAP_SOURCED_ACTION_ITEM_DEFINITIONS_BY_NAME =
            "CountSAPSourcedActionItemDefinitionsByName";

        private const string INSERT_LINKED_TARGET_STORED_PROCEDURE = "InsertLinkedTargetDefinition";
        private const string QUERY_ALL_FOR_SCHEDULING = "QueryActionItemDefinitionsForScheduling";

        private const string REMOVE_ACTIONITEM_DEF_TARGET_DEF_ASSOCIATION =
            "RemoveActionItemDefinitionTargetDefinitionAssociation";

        private const string QUERY_COUNT_BY_GN75B_ID = "QueryActionItemDefinitionCountByGN75BId";
        private readonly IWorkAssignmentDao assignmentDao;
        private readonly IBusinessCategoryDao businessCategoryDao;

        private readonly ICommentDao commentDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ILog logger = GenericLogManager.GetLogger<ActionItemDefinitionDao>();
        private readonly IScheduleDao scheduleDao;
        private readonly ITargetDefinitionDTODao targetDefinitionDtoDao;
        private readonly IUserDao userDao;

        private readonly ICustomFieldGroupDao customFieldgroupDao;

        private readonly ILogDefinitionCustomFieldEntryDao customFieldEntryDao;
        private readonly ICustomFieldDao customFieldDao;

        public ActionItemDefinitionDao()
        {

            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            targetDefinitionDtoDao = DaoRegistry.GetDao<ITargetDefinitionDTODao>();
            commentDao = DaoRegistry.GetDao<ICommentDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
            assignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldgroupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            customFieldEntryDao = DaoRegistry.GetDao<ILogDefinitionCustomFieldEntryDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
        }


        // TODO: this method actually overcounts because the proc joins on the floc association table. Either make it count correctly or make it return
        // a boolean if the 'count' is more than 0 and call it something like SAPSourcedActionItemDefinitionWithNameAlreadyExists.
        public int GetCountOfSAPSourced(string name, long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@Name", name);
            command.AddParameter("@SiteId", siteId);
            return command.GetCount(COUNT_SAP_SOURCED_ACTION_ITEM_DEFINITIONS_BY_NAME);
        }

        //ayman custom fields DMND0010030
        public object QueryActionItemDefSendEmailByActionItemDefinitionId(long actionItemDefID)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefID);
            return command.QueryForSingleResult(PopulateInstanceForSendEmail, QUERY_SEND_EMAIL);
        }

        //ayman action item reading
        public object QueryActionItemDefAutoPopulateByActionItemDefinitionId(long actionItemDefID)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefID);
            return command.QueryForSingleResult(PopulateInstanceForAutoPopulate, QUERY_AUTO_POPULATE);
        }

        //ayman action item reading
        public object QueryActionItemDefReadingByActionItemDefinitionId(long actionItemDefID)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefID);
            return command.QueryForSingleResult(PopulateInstanceForReading, QUERY_READING);
        }

        //ayman action item reading
        public List<ActionItemDefinition> QueryReadingDefinitionsBySite(long siteid,Date startdate,Date enddate)
        {
            var vstartdate = Date.ToDateString(startdate);
            var venddate = Date.ToDateString(enddate);
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteid);
            command.AddParameter("@StartDate", vstartdate);
            command.AddParameter("@EndDate", venddate);
            return command.QueryForListResult(PopulateInstance, QUERY_READING_BY_SITE);
        }

        //ayman custom fields DMND0010030 
        public List<string> QueryActionItemDefSendEmailToByActionItemDefinitionId(long actionItemDefID)
        {
            var command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefID);
            return command.QueryForListResult(PopulateInstanceForSendEmailTo, QUERY_SEND_EMAIL_TO);
        }


        public ActionItemDefinition QueryById(long id)
        {
            //return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            ActionItemDefinition aid = ManagedCommand.QueryById<ActionItemDefinition>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            if (aid != null)
            {
                SetLogImage(aid);
            }

            return aid;
            
        }

        public ActionItemDefinition QueryBySapOperationId(long sapOperationId)
        {
            var command = ManagedCommand;
            command.AddParameter("@SapOperationId", sapOperationId);

            return command.QueryForSingleResult(PopulateInstance, QUERY_BY_SAP_OPERATION_ID_STORED_PROCEDURE);
        }

        public List<ActionItemDefinition> QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(
            WorkAssignment assignment, IFlocSet flocSet, DateTime todaysDate, List<long> readableVisibilityGroupIds)
        {
            return QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(assignment, flocSet, todaysDate, true,
                readableVisibilityGroupIds);
        }

        public List<ActionItemDefinition> QueryActiveDtosByParentFunctionalLocations(IFlocSet flocSet,
            DateTime todaysDate, List<long> readableVisibilityGroupIds)
        {
            return QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(null, flocSet, todaysDate, false,
                readableVisibilityGroupIds);
        }


        public void Remove(ActionItemDefinition actionItemDefinition)
        {
            ManagedCommand.ExecuteNonQuery(actionItemDefinition, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }


        public void Update(ActionItemDefinition actionItemDefinition)
        {
            var command = ManagedCommand;
            if (actionItemDefinition.Schedule.Id.HasValue)
            {
                scheduleDao.Update(actionItemDefinition.Schedule);
            }
            else
            {
                throw new AttemptedToUpdateObjectWithoutIdException(actionItemDefinition, typeof (ISchedule));
            }
            var recordsUpdated = command.Update(actionItemDefinition, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            if (recordsUpdated > 1)
            {
                logger.Error(
                    "More than ActionItemDefinition was updated when only one should have been updated for id " +
                    actionItemDefinition.Id);
            }

            //ayman custom fields DMND0010030
            UpdateSendEmail(actionItemDefinition);
            InsertSendEmailTo(actionItemDefinition);                         //ayman action item email

            //Added By Vibhor : INC0538975 - When we edit an existing Action item definition and select a custom field, Reading check box and auto populate flags and save; on re opening this Action item Definition the above selection disappears
            var customfieldGroup = customFieldgroupDao.QueryCustomFieldGroupByActionItemDefinitionId(actionItemDefinition.IdValue);
            if (customfieldGroup != null)
            {
                if (actionItemDefinition.Customfieldgroup != null)
                {
                    if (actionItemDefinition.Customfieldgroup.Name != null) // INC0442981 : Added by Vibhor to fix Newly created  Action Item definition  Approve Issue
                        UpdateCustomFieldGroup(actionItemDefinition, actionItemDefinition.Customfieldgroup);
                }  
            }
            else
            {
                if (actionItemDefinition.Customfieldgroup != null)
                {
                    if (actionItemDefinition.Customfieldgroup.Name != null)
                        InsertCustomFieldGroupRelationships(actionItemDefinition, actionItemDefinition.Customfieldgroup);     //ayman custom fields DMND0010030
                }
            }
            
            
            

            DeleteActionItemFunctionalLocationAssociation(command, actionItemDefinition);
            InsertActionItemFunctionalLocationAssociation(command, actionItemDefinition);
            InsertLinkToTargetDefinition(command, actionItemDefinition);
            InsertNewComments(actionItemDefinition);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(actionItemDefinition);
            InsertNewDocumentLinks(actionItemDefinition);
            RemoveDeletedDocumentLinks(actionItemDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            if (actionItemDefinition.Imagelist != null)
            {
                InsertLogImage(actionItemDefinition);
            }

        }

        //ayman custom fields DMND0010030
        private void InsertCustomFieldGroupRelationships(ActionItemDefinition actionitemDefinition, CustomFieldGroup customFieldGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_ACTIONITEM_DEFINITION_CUSTOM_FIELD_GROUP;
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinition.IdValue);
            command.AddParameter("@CustomFieldGroupId", customFieldGroupId.IdValue);
            command.AddParameter("@AutoPopulate", actionitemDefinition.AutoPopulate);
            command.AddParameter("@Reading", actionitemDefinition.Reading);
            command.ExecuteNonQuery();
        }


        //ayman custom fields DMND0010030
        private void InsertSendEmail(ActionItemDefinition actionitemDefinition, bool sendEmail)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_SEND_EMAIL;
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinition.IdValue);
            command.AddParameter("@SendEmail", sendEmail);
            command.ExecuteNonQuery();
        }


        //ayman custom fields DMND0010030
        private void InsertSendEmailTo(ActionItemDefinition actionitemDefinition)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = REMOVE_SEND_EMAIL_TO;
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinition.IdValue);
            command.ExecuteNonQuery();

            foreach (string email in actionitemDefinition.SendEmailTo)
            {
            command = ManagedCommand;
            command.CommandText = INSERT_SEND_EMAIL_TO;
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinition.IdValue);
            command.AddParameter("@SendEmailTo", email);
            command.ExecuteNonQuery();
            }
        }


        //ayman custom fields DMND0010030
        private void UpdateSendEmail(ActionItemDefinition actionitemDefinition)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = UPDATE_SEND_EMAIL;
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinition.IdValue);
            command.AddParameter("@SendEmail", actionitemDefinition.SendEmail);
            command.ExecuteNonQuery();
        }

        //ayman custom fields DMND0010030
        private void UpdateCustomFieldGroup(ActionItemDefinition actionitemDefinition, CustomFieldGroup customFieldGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "UpdateCustomFieldGroup";
            command.AddParameter("@ActionItemDefinitionId", actionitemDefinition.IdValue);
            command.AddParameter("@CustomFieldGroupId", customFieldGroupId.IdValue);
            command.AddParameter("@AutoPopulate", actionitemDefinition.AutoPopulate);
            command.AddParameter("@Reading", actionitemDefinition.Reading);
            command.ExecuteNonQuery();
        }


        //ayman custom fields DMND0010030
        public void InsertWithCustomFieldGroupID(ActionItemDefinition actionItemDefinition, CustomFieldGroup customfieldgroupid)
        {
            var command = ManagedCommand;
            scheduleDao.Insert(actionItemDefinition.Schedule);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(actionItemDefinition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            actionItemDefinition.Id = long.Parse(idParameter.Value.ToString());

            InsertCustomFieldGroupRelationships(actionItemDefinition, customfieldgroupid);                 //ayman custom fields DMND0010030
            InsertSendEmail(actionItemDefinition,actionItemDefinition.SendEmailTo.Count > 0);                         //ayman custom fields DMND0010030

            InsertSendEmailTo(actionItemDefinition);                         //ayman action item email


            InsertActionItemFunctionalLocationAssociation(command, actionItemDefinition);
            InsertLinkToTargetDefinition(command, actionItemDefinition);
            InsertNewComments(actionItemDefinition);
            InsertNewDocumentLinks(actionItemDefinition);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(actionItemDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
        }


        public void Insert(ActionItemDefinition actionItemDefinition)
        {
            var command = ManagedCommand;
            scheduleDao.Insert(actionItemDefinition.Schedule);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(actionItemDefinition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            actionItemDefinition.Id = long.Parse(idParameter.Value.ToString());

            if (actionItemDefinition.Customfieldgroup != null)
            {
                if(actionItemDefinition.Customfieldgroup.Name != null)
                InsertCustomFieldGroupRelationships(actionItemDefinition, actionItemDefinition.Customfieldgroup);     //ayman custom fields DMND0010030
            }
            InsertSendEmail(actionItemDefinition, actionItemDefinition.SendEmail);                                              //ayman custom fields DMND0010030

            if (actionItemDefinition.SapOperationId == null) // Added by Vibhor : INC0585946 / INC0581754 - OLT action items are not being generated for SAP workcentre - OPRPR
            {
                InsertSendEmailTo(actionItemDefinition);                         //ayman action item email
            }
            

            InsertActionItemFunctionalLocationAssociation(command, actionItemDefinition);
            InsertLinkToTargetDefinition(command, actionItemDefinition);
            InsertNewComments(actionItemDefinition);
            InsertNewDocumentLinks(actionItemDefinition);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(actionItemDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            if (actionItemDefinition.Imagelist != null)
            {
                InsertLogImage(actionItemDefinition);
            }
        }

        public List<ActionItemDefinition> QueryAllAvailableForScheduling()
        {
            return ManagedCommand.QueryForListResult(PopulateInstance, QUERY_ALL_FOR_SCHEDULING);
        }

        public int QueryCountByGN75BId(long gn75BId)
        {
            var command = ManagedCommand;
            command.AddParameter("@gn75BId", gn75BId);
            return command.QueryForSingleResult(reader => reader.Get<int>("ActionItemDefinitionCount"),
                QUERY_COUNT_BY_GN75B_ID);
        }

        public List<ActionItemDefinition> QueryFutureActionItemDefinitions(RootFlocSet rootFlocSet,
            DateTime beginDateTime, DateTime endDateTime,
            List<long> readableVisibilityGroupIds)
        {
            var csvFunctionalLocationIds = rootFlocSet.FunctionalLocations.BuildIdStringFromList();
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            command.AddParameter("@StartOfDateRange", beginDateTime);
            command.AddParameter("@EndOfDateRange", endDateTime);
            command.AddParameter("@CsvVisibilityGroupIds",
                readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return command.QueryForListResult(PopulateInstance,
                QUERY_FUTURE_ACTION_ITEM_DEFINITIONS);
        }

        private List<ActionItemDefinition> QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(
            WorkAssignment assignment, IFlocSet flocSet, DateTime todaysDate, bool useWorkAssignment,
            List<long> readableVisibilityGroupIds)
        {
            var csvFunctionalLocationIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);

            command.AddParameter("@IncludeAssignmentInCondition", useWorkAssignment);

            if (assignment != null)
            {
                command.AddParameter("@AssignmentId", assignment.Id);
            }

            var twoDaysAgo = todaysDate.SubtractDays(2);
            command.AddParameter("@EndOfDateRange", twoDaysAgo);

            command.AddParameter("@CsvVisibilityGroupIds",
                readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return command.QueryForListResult(PopulateInstance, QUERY_ACTIVE_BY_ASSIGNMENT_AND_PARENT_FLOCS);
        }

        /// <summary>
        ///     Remove Deleted Document Links
        /// </summary>
        /// <param name="definition"></param>
        private void RemoveDeletedDocumentLinks(IDocumentLinksObject definition)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(definition, documentLinkDao.QueryByActionItemDefinitionId);
        }

        /// <summary>
        ///     Inserts new (no id) document links associated with the Action Item definition
        /// </summary>
        /// <param name="definition"></param>
        private void InsertNewDocumentLinks(IDocumentLinksObject definition)
        {
            documentLinkDao.InsertNewDocumentLinks(definition, documentLinkDao.InsertForAssociatedActionItemDefinition);
        }

        private static void InsertActionItemFunctionalLocationAssociation(SqlCommand command,
            ActionItemDefinition actionItemDefinition)
        {
            if (!actionItemDefinition.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_ACTION_ITEM_FUNCTIONAL_LOCATION_ASSOCIATION;
                foreach (var functionalLocation in actionItemDefinition.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ActionItemDefinitionId", actionItemDefinition.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void DeleteActionItemFunctionalLocationAssociation(SqlCommand command,
            ActionItemDefinition actionItemDefinition)
        {
            command.CommandText = REMOVE_ACTION_ITEM_FUNCTIONAL_LOCATION_ASSOCIATION;
            command.Parameters.Clear();
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinition.Id);
            command.ExecuteNonQuery();
        }

        private bool PopulateInstanceForSendEmail(SqlDataReader reader)
        {
            var sendemailvalue = reader.Get<bool>("SendEmail");
            return sendemailvalue;
        }

        //ayman action item reading
        private bool PopulateInstanceForAutoPopulate(SqlDataReader reader)
        {
            var autopopulatevalue = reader.Get<bool>("AutoPopulate");
            return autopopulatevalue;
        }

        //ayman action item reading
        private bool PopulateInstanceForReading(SqlDataReader reader)
        {
            var readingvalue = reader.Get<bool>("Reading");
            return readingvalue;
        }

        private string PopulateInstanceForSendEmailTo(SqlDataReader reader)
        {
            var sendemailvalue = reader.Get<string>("EmailTo");
            return sendemailvalue;
        }

        private ActionItemDefinition PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var workPermitId = reader.Get<long?>("WorkPermitId");
            var operationalModeId = reader.Get<int>("OperationalModeId");
            var opMode = OperationalMode.GetById(operationalModeId);

            var name = reader.Get<string>("Name");
            var functionalLocations =
                functionalLocationDao.QueryByActionItemDefinitionId(id);
            var targetDefinitionDtos =
                targetDefinitionDtoDao.QueryByActionItemDefinitionId(id);


            var businessCategoryId = reader.Get<long?>("BusinessCategoryId");
            var actionItemCategory = !businessCategoryId.HasValue
                ? null
                : businessCategoryDao.QueryById(businessCategoryId.Value);

            var priority = Priority.GetById(reader.Get<long>("PriorityId"));
            var description = reader.Get<string>("Description");
            var status =
                ActionItemDefinitionStatus.GetById(reader.Get<long>("ActionItemDefinitionStatusId"));
            var schedule = scheduleDao.QueryById(reader.Get<long>("ScheduleId"));
            var lastModifiedby = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            var lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            var source = DataSource.GetById(reader.Get<int>("SourceId"));
            var requiresApproval = reader.Get<bool>("RequiresApproval");
            var active = reader.Get<bool>("Active");
            var CopyResponseToLog = reader.Get<bool>("CopyResponseToLog"); //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            var responseRequired = reader.Get<bool>("ResponseRequired");

            var sapOperationId = reader.Get<long?>("SapOperationId");

            var deleted = reader.Get<bool>("Deleted");
            var documentLinks =
                documentLinkDao.QueryByActionItemDefinitionId(id);

            WorkAssignment assignment = null;
            var assignmentId = reader.Get<long?>("WorkAssignmentId");
            if (assignmentId != null)
            {
                assignment = assignmentDao.QueryById(assignmentId.Value);
            }

            var createAnActionItemForEachFunctionalLocation =
                reader.Get<bool>("CreateAnActionItemForEachFunctionalLocation");

            var gn75bId = reader.Get<long?>("GN75BId");

            var gn75bId1 = reader.Get<long?>("GN75BId1");//mangesh - Request 15: DMND0005327
            var gn75bId2 = reader.Get<long?>("GN75BId2");

            //ayman visibility groups
            var VisGroups = reader.Get<string>("VisibilityGroupIDs");             //ayman visibility groups

            //ayman custom fields DMND0010030
            var customfieldGroup = customFieldgroupDao.QueryCustomFieldGroupByActionItemDefinitionId(id);
            List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForLogDefinitions(id);

            var sendEmailResult = QueryActionItemDefSendEmailByActionItemDefinitionId(id);
            var autopopulateResult = QueryActionItemDefAutoPopulateByActionItemDefinitionId(id);          //ayman action item reading
            var readingResult = QueryActionItemDefReadingByActionItemDefinitionId(id);          //ayman action item reading

            var SendEmailTo = QueryActionItemDefSendEmailToByActionItemDefinitionId(id);
            List<string> sendemailto = SendEmailTo as List<string>;
            bool sendEmail = false;
            bool autopopulate = false;
            bool reading = false;
            
            if(autopopulateResult != null)

            {
                autopopulate = (bool)autopopulateResult;
            }
            else
            {
                autopopulate = false;
            }

            if (readingResult != null)

            {
                reading = (bool)readingResult;
            }
            else
            {
                reading = false;
            }

            if (sendEmailResult != null)
            {
                sendEmail = (bool)sendEmailResult;
            }
            else
            {
                sendEmail = false;
            }

            //RITM0265710 mangesh
            //            var everyShift = reader.Get<bool>("EveryShift");     commented by Ayman ro resolve code overlap 
            ActionItemDefinition result;
            if (workPermitId != null)
            {
                result =
              new ActionItemDefinition(name,
                  actionItemCategory,
                  status,
                  schedule,
                  description,
                  source,                 
                  requiresApproval,
                  active,
                  CopyResponseToLog,
                  responseRequired,
                  lastModifiedby,
                  lastModifiedDate,
                  createdBy,
                  createdDateTime,
                  functionalLocations,
                  targetDefinitionDtos,
                  documentLinks,
                  opMode,
                  assignment,

                  createAnActionItemForEachFunctionalLocation, gn75bId, VisGroups, customfieldGroup, sendEmail, autopopulate, reading, sendemailto,workPermitId) //mangesh - Request 15: DMND0005327 (added gn75bId1 and gn75bId2)   //ayman custom fields DMND0010030
              {
                  Id = id,
                  SapOperationId = sapOperationId,
                  Deleted = deleted,
                  Comments = commentDao.QueryByActionItemDefinitionId(id),
                  Priority = priority
              };

            }
            else
            {
                result =
               new ActionItemDefinition(name,
                   actionItemCategory,
                   status,
                   schedule,
                   description,
                   source,
                   requiresApproval,
                   active,
                   CopyResponseToLog, //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                   responseRequired,
                   lastModifiedby,
                   lastModifiedDate,
                   createdBy,
                   createdDateTime,
                   functionalLocations,
                   targetDefinitionDtos,
                   documentLinks,
                   opMode,
                   assignment,

                   createAnActionItemForEachFunctionalLocation, gn75bId, gn75bId1, gn75bId2, VisGroups, customfieldGroup, sendEmail, autopopulate, reading, sendemailto, false) //mangesh - Request 15: DMND0005327 (added gn75bId1 and gn75bId2)   //ayman custom fields DMND0010030
               {
                   Id = id,
                   SapOperationId = sapOperationId,
                   Deleted = deleted,
                   Comments = commentDao.QueryByActionItemDefinitionId(id),
                   Priority = priority
               };

                
            }

            return result;
        }

        private static void AddUpdateParameters(ActionItemDefinition actionItemDefinition, SqlCommand command)
        {
            command.AddParameter("@Id", actionItemDefinition.Id);
            SetCommonAttributes(actionItemDefinition, command);
        }

        private static void AddRemoveParameters(ActionItemDefinition actionItemDefinition, SqlCommand command)
        {
            command.AddParameter("@Id", actionItemDefinition.Id);
            command.AddParameter("@LastModifiedUserId", actionItemDefinition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", actionItemDefinition.LastModifiedDate);
        }

        private static void AddInsertParameters(ActionItemDefinition actionItemDefinition, SqlCommand command)
        {
            command.AddParameter("@CreatedByUserId", actionItemDefinition.CreatedBy.Id);
            command.AddParameter("@CreatedDateTime", actionItemDefinition.CreatedDateTime);
            SetCommonAttributes(actionItemDefinition, command);
        }

        private static void SetCommonAttributes(ActionItemDefinition actionItemDefinition, SqlCommand command)
        {
            //UserContext userContext = ClientSession.GetUserContext();

            command.AddParameter("@workpermitId", actionItemDefinition.workpermitId !=null ? actionItemDefinition.workpermitId : 0);
            command.AddParameter("@Name", actionItemDefinition.Name);
            command.AddParameter("@BusinessCategoryId",
                actionItemDefinition.Category != null ? actionItemDefinition.Category.Id : null);
            command.AddParameter("@ActionItemDefinitionStatusId", actionItemDefinition.Status.Id);
            command.AddParameter("@PriorityId", actionItemDefinition.Priority.Id);
            command.AddParameter("@Description", actionItemDefinition.Description);
            command.AddParameter("@Active", actionItemDefinition.Active);
            command.AddParameter("@CopyResponseToLog", actionItemDefinition.CopyResponseToLog); //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            command.AddParameter("@RequiresApproval", actionItemDefinition.RequiresApproval);
            command.AddParameter("@LastModifiedUserId", actionItemDefinition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", actionItemDefinition.LastModifiedDate);
            command.AddParameter("@ScheduleId", actionItemDefinition.Schedule.Id);
            command.AddParameter("@SourceId", actionItemDefinition.Source.Id);
            command.AddParameter("@ResponseRequired", actionItemDefinition.ResponseRequired);
            command.AddParameter("@SapOperationId", actionItemDefinition.SapOperationId);
            command.AddParameter("@OperationalModeId", actionItemDefinition.OperationalMode.Id);
            command.AddParameter("@AssignmentId",
                actionItemDefinition.Assignment != null ? actionItemDefinition.Assignment.Id : null);
            command.AddParameter("@CreateAnActionItemForEachFunctionalLocation",
                actionItemDefinition.CreateAnActionItemForEachFunctionalLocation);
            command.AddParameter("@GN75BId",
                actionItemDefinition.AssociatedFormGN75BId.HasValue ? actionItemDefinition.AssociatedFormGN75BId : null);
            
            //mangesh: DMND0005327-Request15
            command.AddParameter("@GN75BId1",
                actionItemDefinition.AssociatedFormGN75BId1.HasValue ? actionItemDefinition.AssociatedFormGN75BId1 : null);
            command.AddParameter("@GN75BId2",
                actionItemDefinition.AssociatedFormGN75BId2.HasValue ? actionItemDefinition.AssociatedFormGN75BId2 : null);

            //ayman visibility groups
            command.AddParameter("@visgroupsstartingwith",actionItemDefinition.VisGroupsStartingWith);
        }

        private static void RemoveTargetDefinitionAssociation(SqlCommand command,
            ActionItemDefinition actionItemDefinition)
        {
            command.CommandText = REMOVE_ACTIONITEM_DEF_TARGET_DEF_ASSOCIATION;
            command.Parameters.Clear();
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinition.Id);
            command.ExecuteNonQuery();
        }

        private static void InsertLinkToTargetDefinition(SqlCommand command, ActionItemDefinition actionItemDefinition)
        {
            RemoveTargetDefinitionAssociation(command, actionItemDefinition);

            if (!actionItemDefinition.TargetDefinitionDTOs.IsEmpty())
            {
                command.CommandText = INSERT_LINKED_TARGET_STORED_PROCEDURE;
                foreach (var targetDefinitionDto in actionItemDefinition.TargetDefinitionDTOs)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ActionItemDefinitionId", actionItemDefinition.Id);
                    command.AddParameter("@TargetDefinitionId", targetDefinitionDto.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertNewComments(ActionItemDefinition actionItemDefinition)
        {
            if (!actionItemDefinition.Comments.IsEmpty())
            {
                foreach (var comment in actionItemDefinition.Comments)
                {
                    if (comment.Id.HasNoValue())
                    {
                        commentDao.InsertActionItemDefinitionComment(actionItemDefinition.IdValue, comment);
                    }
                }
            }
        }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        private void InsertLogImage(ActionItemDefinition Aids)
        {

            foreach (ImageUploader Img in Aids.Imagelist)
            {
                if (Img.Id == 0 && Img.Action != "Remove")
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "InsertImageData";
                    command.AddParameter("@ItemID", Aids.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.AddParameter("@ImagePath", Img.ImagePath);
                    command.AddParameter("@Createdby", Aids.CreatedBy.Id);
                    command.AddParameter("@CreatedDate", Aids.CreatedDateTime);
                    command.AddParameter("@RecordType", (int)Img.Types);
                    command.AddParameter("@RecordFor ", (int)Img.RecordType);
                    command.ExecuteNonQuery();
                }
                else if (Convert.ToString(Img.Action).ToUpper() == "Remove".ToUpper())
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "RemoveImageData";
                    command.AddParameter("@Id", Img.Id);

                    command.ExecuteNonQuery();

                }
                else if (Img.Id > 0)
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "UpdateImageData";
                    command.AddParameter("@ID", Img.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.ExecuteNonQuery();
                }
            }

        }

        private void SetLogImage(ActionItemDefinition Aids)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "GetItemImage";
            command.AddParameter("@ItemIDs", Aids.Id);
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
                    //Img.Types = ActionItemImage.Type.Title;
                }
                else
                {
                    Img.Types = ImageUploader.Type.Image;
                }

                if (reader.Get("RecordFor") != null && reader.Get<int>("RecordFor") == 1)
                {
                    Img.RecordType = ImageUploader.RecordTypes.Directive;
                }
                else
                {
                    Img.RecordType = ImageUploader.RecordTypes.ActionItemDef;
                }

                lst.Add(Img);
            }
            reader.Dispose();
            Aids.Imagelist = lst;
        }

    }
}
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkAssignmentDao : AbstractManagedDao, IWorkAssignmentDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryWorkAssignmentById";
        private const string INSERT_STORED_PROCEDURE = "InsertWorkAssignment";
        private const string QUERY_BY_SITE_ID = "QueryWorkAssignmentBySiteId";
        private const string QUERY_BY_FLOC_LIST = "QueryWorkAssignmentByFunctionalLocationList";
        private const string QUERY_BY_SHIFT_HANDOVER_EMAIL_CONFIG_ID = "QueryWorkAssignmentByShiftHandoverEmailConfigurationId";                
        private const string QUERY_BY_DIRECTIVE_ID = "QueryWorkAssignmentByDirectiveId";
        private const string QUERY_BY_PRIORITY_PAGE_SECTION_CONFIGURATION_ID = "QueryWorkAssignmentByPriorityPageSectionConfigurationId";
        private const string QUERY_BY_RESTRICTION_LOCATION_ID = "QueryWorkAssignmentByRestrictionLocationId";                
        private const string INSERT_FLOC_FOR_WORK_ASSIGNMENT = "InsertFunctionalLocationForWorkAssignment";
        private const string DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS = "DeleteWorkAssignmentFunctionalLocationMappings";
        private const string UPDATE_WORK_ASSIGNMENT = "UpdateWorkAssignment";
        private const string REMOVE_WORK_ASSIGNMENT = "RemoveWorkAssignment";
        private const string DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS_FOR_WORK_PERMIT_AUTO_ASSIGNMENT = "DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermitAutoAssignment";
        private const string DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS_FOR_RESTRICTIONS = "DeleteWorkAssignmentFunctionalLocationMappingsForRestrictions";
        private const string INSERT_FLOC_FOR_WORK_ASSIGNMENT_FOR_WORK_PERMIT_AUTO_ASSIGNMENT = "InsertFunctionalLocationForWorkAssignmentForWorkPermitAutoAssignment";
        private const string INSERT_FLOC_FOR_WORK_ASSIGNMENT_FOR_RESTRICTIONS = "InsertFunctionalLocationForWorkAssignmentForRestrictions";
        private const string DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS_FOR_WORK_PERMIT = "DeleteWorkAssignmentFunctionalLocationMappingsForWorkPermit";
        private const string INSERT_FLOC_FOR_WORK_ASSIGNMENT_FOR_WORK_PERMIT = "InsertFunctionalLocationForWorkAssignmentForWorkPermit";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IWorkAssignmentVisibilityGroupDao workAssignmentVisibilityGroupDao;
        private readonly IRoleDao roleDao;

        public WorkAssignmentDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();            
        }

        public WorkAssignment QueryById(long id)
        {
            return ManagedCommand.QueryById<WorkAssignment>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public WorkAssignment QueryByIdWithoutCache(long id)
        {
            return ManagedCommand.QueryById<WorkAssignment>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public WorkAssignment Insert(WorkAssignment workAssignment)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(workAssignment, AddInsertParameters, INSERT_STORED_PROCEDURE);
            workAssignment.Id = long.Parse(idParameter.Value.ToString());
            
            InsertNewVisibilityGroups(workAssignment);
            
            return workAssignment;
        }

        public List<WorkAssignment> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            return command.QueryForListResult<WorkAssignment>(PopulateInstance, QUERY_BY_SITE_ID);
        }

        public List<WorkAssignment> TemplateCategoriesQueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            return command.QueryForListResult<WorkAssignment>(PopulateInstanceforTemplateCategory, "QueryWorkPermitTemplateCategory");
        }

        public List<WorkAssignment> PermitRequestTemplateCategoriesQueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            return command.QueryForListResult<WorkAssignment>(PopulateInstanceforTemplateCategory, "QueryPermitRequestTemplateCategory");
        }
        

        private WorkAssignment PopulateInstanceforTemplateCategory(SqlDataReader reader)
        {
           string category = reader.Get<string>("Categories");
            return new WorkAssignment(
                    
                    category
                   );
        }

        

        public List<WorkAssignment> QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            return command.QueryForListResult<WorkAssignment>(PopulateInstance, QUERY_BY_FLOC_LIST);
        }

        public List<WorkAssignment> QueryByShiftHandoverEmailConfigurationId(long shiftHandoverEmailConfigurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ConfigurationId", shiftHandoverEmailConfigurationId);
            return command.QueryForListResult<WorkAssignment>(PopulateInstance, QUERY_BY_SHIFT_HANDOVER_EMAIL_CONFIG_ID);
        }

        public List<WorkAssignment> QueryByDirectiveId(long directiveId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@DirectiveId", directiveId);
            return command.QueryForListResult<WorkAssignment>(PopulateInstance, QUERY_BY_DIRECTIVE_ID);            
        }

        public List<WorkAssignment> QueryByPriorityPageSectionConfigurationId(long directiveId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@PriorityPageSectionConfigurationId", directiveId);
            return command.QueryForListResult<WorkAssignment>(PopulateInstance, QUERY_BY_PRIORITY_PAGE_SECTION_CONFIGURATION_ID);                        
        }

        public List<WorkAssignment> QueryByRestrictionLocation(long restrictionLocationId,long siteid) //ayman restriction
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RestrictionLocationId", restrictionLocationId);
            command.AddParameter("@SiteId",siteid);    //ayman restriction 
            return command.QueryForListResult<WorkAssignment>(PopulateInstance, QUERY_BY_RESTRICTION_LOCATION_ID);
        }

        public void UpdateFunctionalLocations(WorkAssignment workAssignment)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkAssignmentId",  workAssignment.Id);
            command.ExecuteNonQuery(DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS);
            
            foreach (FunctionalLocation functionalLocation in workAssignment.FunctionalLocations)
            {
                command.Parameters.Clear();
                command.AddParameter("@WorkAssignmentId",  workAssignment.Id);
                command.AddParameter("@FlocId",  functionalLocation.Id);
                command.ExecuteNonQuery(INSERT_FLOC_FOR_WORK_ASSIGNMENT);
            }                                    
        }

        public void UpdateFunctionalLocationsForWorkPermitAutoAssignment(AssignmentFlocConfiguration configuration)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkAssignmentId",  configuration.WorkAssignmentId);
            command.ExecuteNonQuery(DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS_FOR_WORK_PERMIT_AUTO_ASSIGNMENT);
            
            foreach (FunctionalLocation functionalLocation in configuration.FunctionalLocations)
            {
                command.Parameters.Clear();
                command.AddParameter("@WorkAssignmentId",  configuration.WorkAssignmentId);
                command.AddParameter("@FlocId",  functionalLocation.Id);
                command.ExecuteNonQuery(INSERT_FLOC_FOR_WORK_ASSIGNMENT_FOR_WORK_PERMIT_AUTO_ASSIGNMENT);
            }                                    
        }

        public void UpdateFunctionalLocationsForRestrictions(AssignmentFlocConfiguration configuration)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkAssignmentId",  configuration.WorkAssignmentId);
            command.ExecuteNonQuery(DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS_FOR_RESTRICTIONS);
            
            foreach (FunctionalLocation functionalLocation in configuration.FunctionalLocations)
            {
                command.Parameters.Clear();
                command.AddParameter("@WorkAssignmentId",  configuration.WorkAssignmentId);
                command.AddParameter("@FlocId",  functionalLocation.Id);
                command.ExecuteNonQuery(INSERT_FLOC_FOR_WORK_ASSIGNMENT_FOR_RESTRICTIONS);
            }                                    
        }

        public void UpdateFunctionalLocationsForWorkPermits(AssignmentFlocConfiguration configuration)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@WorkAssignmentId",  configuration.WorkAssignmentId);
            command.ExecuteNonQuery(DELETE_WORK_ASSIGNMENT_FLOC_MAPPINGS_FOR_WORK_PERMIT);

            foreach (FunctionalLocation functionalLocation in configuration.FunctionalLocations)
            {
                command.Parameters.Clear();
                command.AddParameter("@WorkAssignmentId",  configuration.WorkAssignmentId);
                command.AddParameter("@FlocId",  functionalLocation.Id);
                command.ExecuteNonQuery(INSERT_FLOC_FOR_WORK_ASSIGNMENT_FOR_WORK_PERMIT);
            }
        }

        private static void AddInsertParameters(WorkAssignment workAssignment, SqlCommand command)
        {
            command.AddParameter("@Name", workAssignment.Name);
            command.AddParameter("@Description", workAssignment.Description);
            command.AddParameter("@Category", workAssignment.Category);
            command.AddParameter("@SiteId",  workAssignment.SiteId);
            command.AddParameter("@UseWorkAssignmentForActionItemHandoverDisplay",  workAssignment.UseWorkAssignmentForActionItemHandoverDisplay);
            command.AddParameter("@CopyTargetAlertResponseToLog", workAssignment.CopyTargetAlertResponseToLog);
            command.AddParameter("@AutoInsertLogTemplateId", workAssignment.AutoInsertLogTemplateId);
            command.AddParameter("@ShowLubesCsdOnShiftHandoverReport", workAssignment.ShowLubesCsdOnShiftHandoverReport);
            command.AddParameter("@ShowEventExcursionsOnShiftHandoverReport", workAssignment.ShowEventExcursionsOnShiftHandoverReport);

            long? roleId = workAssignment.Role != null ? workAssignment.Role.Id : null;
            command.AddParameter("@RoleId",  roleId);
        }

        private WorkAssignment PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            string description = reader.Get<string>("Description");
            string category = reader.Get<string>("Category");
            long siteId = reader.Get<long>("SiteId");
            bool useWorkAssignmentForActionItemHandoverDisplay = reader.Get<bool>("UseWorkAssignmentForActionItemHandoverDisplay");
            bool copyTargetAlertResponseToLog = reader.Get<bool>("CopyTargetAlertResponseToLog");
            long? autoInsertLogTemplateId = reader.Get<long?>("AutoInsertLogTemplateId");
            bool showLubesCsdOnShiftHandoverReport = reader.Get<bool>("ShowLubesCsdOnShiftHandoverReport");
            bool showEventExcursionsOnShiftHandoverReport = reader.Get<bool>("ShowEventExcursionsOnShiftHandoverReport");
            Role role = roleDao.QueryById(reader.Get<long>("RoleId"));            

            List<FunctionalLocation> flocList = functionalLocationDao.QueryByWorkAssignmentId(id);
            List<WorkAssignmentVisibilityGroup> groups = workAssignmentVisibilityGroupDao.QueryByWorkAssignmentId(id);

            return new WorkAssignment(
                    id, 
                    name, 
                    description, 
                    category,
                    siteId,
                    role,
                    useWorkAssignmentForActionItemHandoverDisplay,
                    copyTargetAlertResponseToLog,
                    flocList, 
                    groups,
                    autoInsertLogTemplateId,
                    showLubesCsdOnShiftHandoverReport,
                    showEventExcursionsOnShiftHandoverReport);
        }

        public void Update(WorkAssignment workAssignment)
        {
            ManagedCommand.Update(workAssignment, UpdateParameters, UPDATE_WORK_ASSIGNMENT);
            RemoveDeletedVisibilityGroups(workAssignment);
            InsertNewVisibilityGroups(workAssignment);
        }

        private void InsertNewVisibilityGroups(WorkAssignment workAssignment)
        {
            List<WorkAssignmentVisibilityGroup> existingGroups = workAssignmentVisibilityGroupDao.QueryByWorkAssignmentId(workAssignment.IdValue);
            IList<WorkAssignmentVisibilityGroup> groupsToInsert = workAssignment.WorkAssignmentVisibilityGroups.FindAll(existingGroups.DoesNotContainById);
            foreach(WorkAssignmentVisibilityGroup group in groupsToInsert)
            {
                workAssignmentVisibilityGroupDao.Insert(group);
            }
        }

        private void RemoveDeletedVisibilityGroups(WorkAssignment workAssignment)
        {
            List<WorkAssignmentVisibilityGroup> existingGroups = workAssignmentVisibilityGroupDao.QueryByWorkAssignmentId(workAssignment.IdValue);
            List<WorkAssignmentVisibilityGroup> toDelete = existingGroups.FindAll(workAssignment.WorkAssignmentVisibilityGroups.DoesNotContainById);
            foreach(WorkAssignmentVisibilityGroup group in toDelete)
            {
                workAssignmentVisibilityGroupDao.Remove(group);
            }
        }

        public void Remove(WorkAssignment workAssignment)
        {
            if (workAssignment.IsInDatabase())
            {
                ManagedCommand.Remove(workAssignment.IdValue, REMOVE_WORK_ASSIGNMENT);
            }
        }

        private static void UpdateParameters(WorkAssignment workAssignment, SqlCommand command)
        {
            command.AddParameter("@workAssignmentId",  workAssignment.Id);
            command.AddParameter("@description", workAssignment.Description);
            command.AddParameter("@category", workAssignment.Category);
            command.AddParameter("@name", workAssignment.Name);
            command.AddParameter("@roleId",  workAssignment.Role.Id);
            command.AddParameter("@useWorkAssignmentForActionItemHandoverDisplay",  workAssignment.UseWorkAssignmentForActionItemHandoverDisplay);
            command.AddParameter("@CopyTargetAlertResponseToLog", workAssignment.CopyTargetAlertResponseToLog);
            command.AddParameter("@AutoInsertLogTemplateId", workAssignment.AutoInsertLogTemplateId);
            command.AddParameter("@ShowLubesCsdOnShiftHandoverReport", workAssignment.ShowLubesCsdOnShiftHandoverReport);
            command.AddParameter("@ShowEventExcursionsOnShiftHandoverReport", workAssignment.ShowEventExcursionsOnShiftHandoverReport);
        }
    }
}
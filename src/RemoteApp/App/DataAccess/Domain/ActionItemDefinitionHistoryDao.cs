using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ActionItemDefinitionHistoryDao : AbstractManagedDao, IActionItemDefinitionHistoryDao
    {
        private readonly IUserDao userDao;
        private readonly IBusinessCategoryDao businessCategoryDao;

        public ActionItemDefinitionHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
        }

        public List<ActionItemDefinitionHistory> GetById(long id) 
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult < ActionItemDefinitionHistory>(PopulateInstance, "QueryActionItemDefinitionHistoriesById");
        }
        
        public void Insert(ActionItemDefinitionHistory actionItemDefinitionHistory)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(actionItemDefinitionHistory, AddInsertParameters, "InsertActionItemDefinitionHistory");
        }

        private ActionItemDefinitionHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            string description = reader.Get<string>("Description");
            string schedule = reader.Get<string>("Schedule");
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            DataSource source = DataSource.GetById(reader.Get<int>("SourceId"));
            bool requiresApproval = reader.Get<bool>("RequiresApproval");
            bool active = reader.Get<bool>("Active");
            bool responseRequired = reader.Get<bool>("ResponseRequired");
            long? sapOperationId = reader.Get<long?>("SapOperationId");
            bool deleted = reader.Get<bool>("Deleted");

            long? businessCategoryId = reader.Get<long?>("BusinessCategoryId");

            BusinessCategory actionItemCategory = !businessCategoryId.HasValue ? null :
                    businessCategoryDao.QueryById(businessCategoryId.Value);
                
            ActionItemDefinitionStatus status = ActionItemDefinitionStatus.GetById(reader.Get<long>("ActionItemDefinitionStatusId"));
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            int operationalModeId = reader.Get<int>("OperationalModeId");
            OperationalMode opMode = OperationalMode.GetById(operationalModeId);

            long priorityId = reader.Get<long>("PriorityId");
            Priority priority = Priority.GetById(priorityId);

            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string targetDefinitions = reader.Get<string>("TargetDefinitions");
            string documentLinks = reader.Get<string>("DocumentLinks");

            string workAssignmentName = reader.Get<string>("WorkAssignmentName");
            bool createAnActionItemForEachFunctionalLocation = reader.Get<bool>("CreateAnActionItemForEachFunctionalLocation");
            long? formGn75BId = reader.Get<long?>("GN75BId");

            //mangesh -DMND0005327 Request 15
            long? formGn75BId1 = reader.Get<long?>("GN75BId1");
            long? formGn75BId2 = reader.Get<long?>("GN75BId2");
            bool copyResponseToLog = reader.Get<bool>("CopyResponseToLog");  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades

            var result =
                new ActionItemDefinitionHistory(id,
                                                name,
                                                actionItemCategory,
                                                status,
                                                schedule,
                                                description,
                                                copyResponseToLog,  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                                                source,
                                                requiresApproval,
                                                active,
                                                responseRequired,
                                                lastModifiedBy,
                                                lastModifiedDate,
                                                functionalLocations,
                                                targetDefinitions,
                                                documentLinks,
                                                opMode,
                                                priority,
                                                workAssignmentName,
                                                createAnActionItemForEachFunctionalLocation, formGn75BId,
                                                formGn75BId1, formGn75BId2) //<-- added formGn75BId1, formGn75BId1-  mangesh - DMND0005327 - Request 15
                                                { Id = id, SapOperationId = sapOperationId, Deleted = deleted };

            return result;
        }

        private static void AddInsertParameters(ActionItemDefinitionHistory actionItemDefinitionHistory, SqlCommand command)
        {
            command.AddParameter("@Id", actionItemDefinitionHistory.Id);
            command.AddParameter("@Name", actionItemDefinitionHistory.Name);
            command.AddParameter("@BusinessCategoryId", 
                    actionItemDefinitionHistory.Category != null ? actionItemDefinitionHistory.Category.Id : null);
            command.AddParameter("@ActionItemDefinitionStatusId", actionItemDefinitionHistory.Status.Id);
            command.AddParameter("@Description", actionItemDefinitionHistory.Description);
            command.AddParameter("@CopyResponseToLog", actionItemDefinitionHistory.CopyResponseToLog);  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            
            command.AddParameter("@Active", actionItemDefinitionHistory.Active);
            command.AddParameter("@RequiresApproval", actionItemDefinitionHistory.RequiresApproval);
            command.AddParameter("@LastModifiedUserId", actionItemDefinitionHistory.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", actionItemDefinitionHistory.LastModifiedDate);
            command.AddParameter("@Schedule", actionItemDefinitionHistory.Schedule);
            command.AddParameter("@SourceId", actionItemDefinitionHistory.Source.Id);
            command.AddParameter("@ResponseRequired", actionItemDefinitionHistory.ResponseRequired);
            command.AddParameter("@SapOperationId", actionItemDefinitionHistory.SapOperationId);
            command.AddParameter("@OperationalModeId", actionItemDefinitionHistory.OperationalMode.Id);
            command.AddParameter("@PriorityId", actionItemDefinitionHistory.Priority.Id);
            command.AddParameter("@FunctionalLocations", actionItemDefinitionHistory.FunctionalLocations);
            command.AddParameter("@TargetDefinitions", actionItemDefinitionHistory.TargetDefinitions);
            command.AddParameter("@DocumentLinks", actionItemDefinitionHistory.DocumentLinks);
            command.AddParameter("@WorkAssignmentName", actionItemDefinitionHistory.WorkAssignment);
            command.AddParameter("@CreateAnActionItemForEachFunctionalLocation", actionItemDefinitionHistory.CreateAnActionItemForEachFunctionalLocation);
            command.AddParameter("@Gn75BId", actionItemDefinitionHistory.AssociatedFormGn75B.HasValue ? actionItemDefinitionHistory.AssociatedFormGn75B.Value : (long?) null);

            //mangesh - DMND0005327 - Request 15
            command.AddParameter("@Gn75BId1", actionItemDefinitionHistory.AssociatedFormGn75B1.HasValue ? actionItemDefinitionHistory.AssociatedFormGn75B1.Value : (long?)null);
            command.AddParameter("@Gn75BId2", actionItemDefinitionHistory.AssociatedFormGn75B2.HasValue ? actionItemDefinitionHistory.AssociatedFormGn75B2.Value : (long?)null);
        }
    }
}

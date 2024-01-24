
// DATODO: Delete me.
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using Com.Suncor.Olt.Common.Domain;

//namespace Com.Suncor.Olt.Remote.DataAccess.Domain
//{
//    public class PriorityPageSectionConfigurationWorkAssignmentDao : AbstractManagedDao, IPriorityPageSectionConfigurationWorkAssignmentDao
//    {
//        private readonly IWorkAssignmentDao workAssignmentDao;

//        private const string DELETE_BY_CONFIGURATION_SECTION_ID_STORED_PROCEDURE = "DeletePriorityPageSectionConfigurationWorkAssignmentByConfigurationId";
//        private const string INSERT_STORED_PROCEDURE = "InsertPriorityPageSectionConfigurationWorkAssignment";
//        private const string QUERY_BY_LOG_TEMPLATE_ID = "QueryPriorityPageSectionConfigurationWorkAssignmentByConfigurationId";

//        public PriorityPageSectionConfigurationWorkAssignmentDao()
//        {
//            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
//        }

//        public List<PriorityPageSectionConfigurationWorkAssignment> QueryByPriorityPageSectionConfigurationId(long id)
//        {
//            SqlCommand command = ManagedCommand;
//            command.AddParameter("@ConfigurationSectionId", id);
//            return command.QueryForListResult<PriorityPageSectionConfigurationWorkAssignment>(PopulateInstance, QUERY_BY_LOG_TEMPLATE_ID);
            
//        }
//    }
//}

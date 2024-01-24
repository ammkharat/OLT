using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PriorityPageSectionConfigurationDao : AbstractManagedDao, IPriorityPageSectionConfigurationDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertPriorityPageSectionConfiguration";
        private const string UPDATE_STORED_PROCEDURE = "UpdatePriorityPageSectionConfiguration";
        private const string DELETE_CONFIGURATION_STORED_PROCEDURE = "DeletePriorityPageSectionConfiguration";
        private const string QUERY_BY_USER_ID_STORED_PROCEDURE = "QueryPriorityPageSectionConfigurationByUserId";
        private const string QUERY_BY_SECTION_KEY_AND_USER_ID_STORED_PROCEDURE = "QueryPriorityPageSectionConfigurationBySectionKeyAndUserId";

        private const string INSERT_WORK_ASSIGNMENT_ASSOCIATIONS = "InsertPriorityPageSectionConfigurationWorkAssignment";
        private const string DELETE_WORK_ASSIGNMENT_ASSOCIATIONS = "DeletePriorityPageSectionConfigurationWorkAssignmentByConfigurationId";
        
        private readonly IUserDao userDao;
        private readonly IWorkAssignmentDao workAssignmentDao;

        public PriorityPageSectionConfigurationDao()
        {            
            userDao = DaoRegistry.GetDao<IUserDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public void Insert(PriorityPageSectionConfiguration sectionConfiguration)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(sectionConfiguration, AddInsertParameters, INSERT_STORED_PROCEDURE);
            sectionConfiguration.Id = long.Parse(idParameter.Value.ToString());
            InsertWorkAssignments(command, sectionConfiguration);                        
        }

        public void Update(PriorityPageSectionConfiguration sectionConfiguration)
        {
            SqlCommand command = ManagedCommand;
            command.Update(sectionConfiguration, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            RemoveWorkAssignments(command, sectionConfiguration.IdValue);
            InsertWorkAssignments(command, sectionConfiguration);
        }

        public void Delete(long configurationId)
        {
            SqlCommand command = ManagedCommand;

            RemoveWorkAssignments(command, configurationId);

            command.ClearParameters();
            command.CommandText = DELETE_CONFIGURATION_STORED_PROCEDURE;            
            command.AddParameter("@ConfigurationId", configurationId);
            command.ExecuteNonQuery();
        }

        private void AddInsertParameters(PriorityPageSectionConfiguration sectionConfiguration, SqlCommand command)
        {
            SetCommonParameters(command, sectionConfiguration);
            command.AddParameter("@SectionKey", sectionConfiguration.SectionKey.Id);
            command.AddParameter("@UserId", sectionConfiguration.User.IdValue);
        }

        private void AddUpdateParameters(PriorityPageSectionConfiguration sectionConfiguration, SqlCommand command)
        {
            command.AddParameter("@Id", sectionConfiguration.IdValue);
            SetCommonParameters(command, sectionConfiguration);
        }

        private static void SetCommonParameters(SqlCommand command, PriorityPageSectionConfiguration sectionConfiguration)
        {            
            command.AddParameter("@SectionExpandedByDefault", sectionConfiguration.SectionExpandedByDefault);
            command.AddParameter("@LastModifiedDateTime", sectionConfiguration.LastModifiedDateTime);
        }

        private void InsertWorkAssignments(SqlCommand command, PriorityPageSectionConfiguration configuration)
        {
            if (!configuration.WorkAssignments.IsEmpty())
            {
                command.CommandText = INSERT_WORK_ASSIGNMENT_ASSOCIATIONS;

                foreach (WorkAssignment workAssignment in configuration.WorkAssignments)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ConfigurationId", configuration.IdValue);
                    command.AddParameter("@WorkAssignmentId", workAssignment.IdValue);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RemoveWorkAssignments(SqlCommand command, long configurationId)
        {
            command.CommandText = DELETE_WORK_ASSIGNMENT_ASSOCIATIONS;
            command.Parameters.Clear();
            command.AddParameter("@ConfigurationId", configurationId);
            command.ExecuteNonQuery();
        }

        public List<PriorityPageSectionConfiguration> QueryByUserId(long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            return command.QueryForListResult<PriorityPageSectionConfiguration>(PopulateInstance, QUERY_BY_USER_ID_STORED_PROCEDURE);
        }

        public PriorityPageSectionConfiguration QueryBySectionKeyAndUserId(PriorityPageSectionKey priorityPageSectionKey, long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SectionKey", priorityPageSectionKey.Id);
            command.AddParameter("@UserId", userId);
            return command.QueryForSingleResult<PriorityPageSectionConfiguration>(PopulateInstance, QUERY_BY_SECTION_KEY_AND_USER_ID_STORED_PROCEDURE);
        }

        private PriorityPageSectionConfiguration PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int sectionKeyId = reader.Get<int>("SectionKey");
            long userId = reader.Get<long>("UserId");
            bool sectionExpandedByDefault = reader.Get<bool>("SectionExpandedByDefault");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            User user = userDao.QueryById(userId);
            PriorityPageSectionKey sectionKey = PriorityPageSectionKey.GetById(sectionKeyId);

            List<WorkAssignment> workAssignments = workAssignmentDao.QueryByPriorityPageSectionConfigurationId(id);

            PriorityPageSectionConfiguration config = 
                    new PriorityPageSectionConfiguration(sectionKey, user, sectionExpandedByDefault, workAssignments, lastModifiedDateTime) { Id = id };
            return config;
        }
    }
}

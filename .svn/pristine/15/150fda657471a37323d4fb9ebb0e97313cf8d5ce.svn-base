using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardConfigurationDao : AbstractManagedDao, ICokerCardConfigurationDao
    {
        private const string QUERY_BY_ID = "QueryCokerCardConfigurationById";
        private const string QUERY_BY_FLOC = "QueryCokerCardConfigurationByFloc";
        private const string QUERY_BY_SITE = "QueryCokerCardConfigurationBySite";
        private const string QUERY_BY_WORK_ASSIGNMENT = "QueryCokerCardConfigurationByWorkAssignment";
        private const string QUERY_DISTINCT_NAMES_BY_SITE = "QueryCokerCardConfigurationNameBySite";
        private const string QUERY_BY_NAME = "QueryCokerCardConfigurationByName";
        private const string INSERT = "InsertCokerCardConfiguration";
        private const string UPDATE = "UpdateCokerCardConfiguration";
        private const string REMOVE = "RemoveCokerCardConfiguration";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ICokerCardConfigurationDrumDao configurationDrumDao;
        private readonly ICokerCardConfigurationCycleStepDao configurationCycleStepDao;
        private readonly ICokerCardConfigurationWorkAssignmentDao configurationWorkAssignmentDao;

        public CokerCardConfigurationDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            configurationDrumDao = DaoRegistry.GetDao<ICokerCardConfigurationDrumDao>();
            configurationCycleStepDao = DaoRegistry.GetDao<ICokerCardConfigurationCycleStepDao>();
            configurationWorkAssignmentDao = DaoRegistry.GetDao<ICokerCardConfigurationWorkAssignmentDao>();
        }

        public CokerCardConfiguration Insert(CokerCardConfiguration cokerCardConfiguration)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(cokerCardConfiguration, AddInsertParameters, INSERT);
            cokerCardConfiguration.Id = long.Parse(idParameter.Value.ToString());

            InsertDrumConfigurations(cokerCardConfiguration);
            InsertCycleStepConfigurations(cokerCardConfiguration);
            InsertWorkAssignments(cokerCardConfiguration);

            return cokerCardConfiguration;
        }

        public void Update(CokerCardConfiguration cokerCardConfiguration)
        {
            ManagedCommand.Update(cokerCardConfiguration, AddUpdateParameters, UPDATE);

            cokerCardConfiguration.Drums.ForEach(drum => configurationDrumDao.Update(drum));
            cokerCardConfiguration.Steps.ForEach(step => configurationCycleStepDao.Update(step));

            configurationWorkAssignmentDao.DeleteByConfigurationId(cokerCardConfiguration.IdValue);
            InsertWorkAssignments(cokerCardConfiguration);
        }

        private void InsertDrumConfigurations(CokerCardConfiguration cokerCardConfiguration)
        {
            cokerCardConfiguration.Drums.ForEach(drum => configurationDrumDao.Insert(drum, cokerCardConfiguration.IdValue));
        }

        private void InsertCycleStepConfigurations(CokerCardConfiguration cokerCardConfiguration)
        {
            cokerCardConfiguration.Steps.ForEach(step => configurationCycleStepDao.Insert(step, cokerCardConfiguration.IdValue));
        }

        private void InsertWorkAssignments(CokerCardConfiguration configuration)
        {
            foreach (WorkAssignment assignment in configuration.WorkAssignments)
            {
                CokerCardConfigurationWorkAssignment configurationWorkAssignment = new CokerCardConfigurationWorkAssignment(configuration.IdValue, assignment);
                configurationWorkAssignmentDao.Insert(configurationWorkAssignment);
            }
        }

        public CokerCardConfiguration QueryById(long id)
        {
            return ManagedCommand.QueryById<CokerCardConfiguration>(id, PopulateInstance, QUERY_BY_ID);
        }

        public CokerCardConfiguration QueryByIdWithCaching(long id)
        {
            return ManagedCommand.QueryById<CokerCardConfiguration>(id, PopulateInstance, QUERY_BY_ID);
        }

        public List<CokerCardConfiguration> QueryCokerCardConfigurationsByExactFlocMatch(ExactFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@flocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            return command.QueryForListResult<CokerCardConfiguration>(PopulateInstance, QUERY_BY_FLOC);
        }

        public List<CokerCardConfiguration> QueryCokerCardConfigurationsBySite(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult<CokerCardConfiguration>(PopulateInstance, QUERY_BY_SITE);            
        }

        public List<long> QueryCokerCardConfigurationByName(string name)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ConfigurationName", name);
            return command.QueryForListResult<long>(PopulateId, QUERY_BY_NAME);
        }

        public List<string> QueryDistinctCokerCardConfigurationNamesBySite(Site site)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", site.IdValue);
            return command.QueryForListResult<string>(PopulateName, QUERY_DISTINCT_NAMES_BY_SITE);
        }

        private static string PopulateName(SqlDataReader reader)
        {
            return reader.Get<string>("Name");
        }

        public List<long> QueryCokerCardConfigurationByWorkAssignment(WorkAssignment workAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignment.IdValue);
            return command.QueryForListResult<long>(PopulateId, QUERY_BY_WORK_ASSIGNMENT);            
        }

        private static long PopulateId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        public void Remove(CokerCardConfiguration cokerCardConfiguration)
        {
            ManagedCommand.Remove(cokerCardConfiguration.IdValue, REMOVE);
        }

        private static void AddInsertParameters(CokerCardConfiguration cokerCardConfiguration, SqlCommand command)
        {
            AddCommonParameters(cokerCardConfiguration, command);
        }

        private static void AddUpdateParameters(CokerCardConfiguration cokerCardConfiguration, SqlCommand command)
        {
            command.AddParameter("@Id", cokerCardConfiguration.IdValue);
            AddCommonParameters(cokerCardConfiguration, command);
        }

        private static void AddCommonParameters(CokerCardConfiguration cokerCardConfiguration, SqlCommand command)
        {
            command.AddParameter("@Name", cokerCardConfiguration.Name);
            command.AddParameter("@FunctionalLocationId", cokerCardConfiguration.FunctionalLocation.IdValue);
        }
      
        private CokerCardConfiguration PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            long functionalLocationId = reader.Get<long>("FunctionalLocationId");
            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(functionalLocationId);

            CokerCardConfiguration cokerCardConfiguration = new CokerCardConfiguration(id, name, functionalLocation);
            cokerCardConfiguration.Drums.AddRange(configurationDrumDao.QueryByCokerCardConfigurationId(cokerCardConfiguration.IdValue));
            cokerCardConfiguration.Steps.AddRange(configurationCycleStepDao.QueryByCokerCardConfigurationId(cokerCardConfiguration.IdValue));
            cokerCardConfiguration.WorkAssignments.AddRange(configurationWorkAssignmentDao.QueryByConfigurationId(cokerCardConfiguration.IdValue).ConvertAll(obj => obj.WorkAssignment));

            return cokerCardConfiguration;
        }
    }
}

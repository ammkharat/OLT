using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TrainingBlockDao : AbstractManagedDao, ITrainingBlockDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryTrainingBlockById";
        private const string QUERY_BY_FUNCTIONAL_LOCATIONS_STORED_PROCEDURE = "QueryTrainingBlocksByFunctionalLocations";
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryTrainingBlocks";
        private const string INSERT_STORED_PROCEDURE = "InsertTrainingBlock";
        private const string UPDATE_STORED_PROCEDURE = "UpdateTrainingBlock";
        private const string REMOVE_STORED_PROCEDURE = "RemoveTrainingBlock";
        private const string INSERT_TRAINING_BLOCK_FUNCTIONAL_LOCATION = "InsertTrainingBlockFunctionalLocation";
        private const string DELETE_TRAINING_BLOCK_FUNCTIONAL_LOCATIONS = "DeleteTrainingBlockFunctionalLocationsByTrainingBlockId";
        private const string COUNT_OF_BLOCKS_WITH_NAME = "CountOfTrainingBlocksWithGivenName";

        private readonly IFunctionalLocationDao flocDao;

        public TrainingBlockDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public TrainingBlock QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<TrainingBlock>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<TrainingBlock> QueryByFunctionalLocations(IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());

            return command.QueryForListResult<TrainingBlock>(PopulateInstance, QUERY_BY_FUNCTIONAL_LOCATIONS_STORED_PROCEDURE);
        }

        public List<TrainingBlock> QueryAll(long Siteid)   //ayman training block
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Siteid",Siteid);         //ayman training block
            return command.QueryForListResult<TrainingBlock>(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public void Insert(TrainingBlock trainingBlock)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(trainingBlock, AddInsertParameters, INSERT_STORED_PROCEDURE);
            trainingBlock.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, trainingBlock);
        }

        public void Update(TrainingBlock trainingBlock)
        {
            SqlCommand command = ManagedCommand;
            command.Update(trainingBlock, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            DeleteFunctionalLocations(command, trainingBlock);
            InsertFunctionalLocations(command, trainingBlock);
        }

        public void Remove(TrainingBlock trainingBlock)
        {
            SqlCommand command = ManagedCommand;
            command.Remove(trainingBlock.IdValue, REMOVE_STORED_PROCEDURE);
        }

        public int CountOfTrainingBlocksWithName(string trainingBlockName, long? trainingBlockId, long Siteid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TrainingBlockName", trainingBlockName);
            command.AddParameter("@TrainingBlockId", trainingBlockId);
            command.AddParameter("@Siteid",Siteid);
            return command.GetCount(COUNT_OF_BLOCKS_WITH_NAME);
        }

        private static void AddInsertParameters(TrainingBlock trainingBlock, SqlCommand command)
        {
            SetCommonAttributes(trainingBlock, command);
        }

        private static void AddUpdateParameters(TrainingBlock trainingBlock, SqlCommand command)
        {
            command.AddParameter("@Id", trainingBlock.IdValue);
            SetCommonAttributes(trainingBlock, command);
        }

        private static void SetCommonAttributes(TrainingBlock trainingBlock, SqlCommand command)
        {            
            command.AddParameter("@Name", trainingBlock.Name);
            command.AddParameter("@Code", trainingBlock.Code);
            command.AddParameter("@Siteid", trainingBlock.Siteid);         //ayman training block 
        }

        private TrainingBlock PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            string name = reader.Get<string>("Name");
            string code = reader.Get<string>("Code");
            long siteid = reader.Get<long>("Siteid");                 //ayman training block

            List<FunctionalLocation> flocs = flocDao.QueryByTrainingBlockId(id);

            return new TrainingBlock(id, name, code, siteid, flocs);                //ayman training block
        }

        private static void InsertFunctionalLocations(SqlCommand command, TrainingBlock trainingBlock)
        {
            if (!trainingBlock.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_TRAINING_BLOCK_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in trainingBlock.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@TrainingBlockId", trainingBlock.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteFunctionalLocations(SqlCommand command, TrainingBlock trainingBlock)
        {
            command.CommandText = DELETE_TRAINING_BLOCK_FUNCTIONAL_LOCATIONS;
            command.Parameters.Clear();
            command.AddParameter("@TrainingBlockId", trainingBlock.Id);
            command.ExecuteNonQuery();
        }


    }
}

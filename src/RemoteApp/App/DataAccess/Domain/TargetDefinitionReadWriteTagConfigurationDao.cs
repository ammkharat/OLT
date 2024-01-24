using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetDefinitionReadWriteTagConfigurationDao : AbstractManagedDao, ITargetDefinitionReadWriteTagConfigurationDao
    {
        private const string QUERY_BY_ID = "QueryTargetDefinitionReadWriteTagConfigurationById";
        private const string INSERT = "InsertTargetDefinitionReadWriteTagConfiguration";
        private const string UPDATE = "UpdateTargetDefinitionReadWriteTagConfiguration";
        
        private readonly ITagDao tagdao;

        public TargetDefinitionReadWriteTagConfigurationDao()
        {
            tagdao = DaoRegistry.GetDao<ITagDao>();
        }

        public TargetDefinitionReadWriteTagConfiguration QueryByTargetDefinitionId(long targetDefinitionId)
        {
            return ManagedCommand.QueryById(targetDefinitionId, (PopulateInstance<TargetDefinitionReadWriteTagConfiguration>) PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(TargetDefinition targetDefinition)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@TargetDefinitionId",  targetDefinition.Id);
            TargetDefinitionReadWriteTagConfiguration readWriteTagConfiguration =
                targetDefinition.ReadWriteTagsConfiguration;
            command.Insert(readWriteTagConfiguration, SetCommonAttributes, INSERT);
            readWriteTagConfiguration.Id = long.Parse(idParameter.Value.ToString());
        }

        private static void SetCommonAttributes(TargetDefinitionReadWriteTagConfiguration configuration, SqlCommand command)
        {
            command.AddParameter("@MaxDirectionId",  configuration.MaxValue.Direction.Id);
            command.AddParameter("@MaxTagId",  configuration.MaxValue.Tag.Id);

            command.AddParameter("@MinDirectionId",  configuration.MinValue.Direction.Id);
            command.AddParameter("@MinTagId",  configuration.MinValue.Tag.Id);

            command.AddParameter("@TargetDirectionId",  configuration.TargetValue.Direction.Id);
            command.AddParameter("@TargetTagId",  configuration.TargetValue.Tag.Id);

            command.AddParameter("@GapUnitValueDirectionId",  configuration.GapUnitValue.Direction.Id);
            command.AddParameter("@GapUnitValueTagId",  configuration.GapUnitValue.Tag.Id);
        }

        private static void AddUpdateParameters(TargetDefinitionReadWriteTagConfiguration configuration, SqlCommand command)
        {
            command.AddParameter("@Id", configuration.Id);
            SetCommonAttributes(configuration, command);
        }

        public void Update(TargetDefinitionReadWriteTagConfiguration readWriteTagConfiguration)
        {
            ManagedCommand.Update(readWriteTagConfiguration, AddUpdateParameters, UPDATE);
        }

        private TargetDefinitionReadWriteTagConfiguration PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long>("Id");
            TagDirection maxDirection = TagDirection.Get(reader.Get<long>("MaxDirectionId"));
            TagInfo maxValueTag = GetTagInfo(reader.Get<long?>("MaxTagId"));
            TagDirection minDirection = TagDirection.Get(reader.Get<long>("MinDirectionId"));
            TagInfo minValueTag = GetTagInfo(reader.Get<long?>("MinTagId"));
            TagDirection targetDirection = TagDirection.Get(reader.Get<long>("TargetDirectionId"));
            TagInfo targetValueTag = GetTagInfo(reader.Get<long?>("TargetTagId"));
            TagDirection gapUnitDirection = TagDirection.Get(reader.Get<long>("GapUnitValueDirectionId"));
            TagInfo gapUnitValueTag = GetTagInfo(reader.Get<long?>("GapUnitValueTagId"));
            var configuration =
                    new TargetDefinitionReadWriteTagConfiguration(id,
                                                                  new ReadWriteTagConfiguration(maxDirection, maxValueTag),
                                                                  new ReadWriteTagConfiguration(minDirection, minValueTag),
                                                                  new ReadWriteTagConfiguration(targetDirection, targetValueTag),
                                                                  new ReadWriteTagConfiguration(gapUnitDirection, gapUnitValueTag));
            return configuration;
        }

        private TagInfo GetTagInfo(long? tagInfoId)
        {
            return tagInfoId.HasValue ? tagdao.QueryById(tagInfoId.Value) : TagInfo.CreateEmpty();
        }
    }
}
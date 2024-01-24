using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetDefinitionReadWriteTagConfiguration : DomainObject
    {
        public TargetDefinitionReadWriteTagConfiguration(long? id, ReadWriteTagConfiguration maxValue,
            ReadWriteTagConfiguration minValue, ReadWriteTagConfiguration targetValue,
            ReadWriteTagConfiguration gapUnitValue)
        {
            this.id = id;
            MaxValue = maxValue;
            MinValue = minValue;
            TargetValue = targetValue;
            GapUnitValue = gapUnitValue;
        }

        public ReadWriteTagConfiguration MaxValue { get; set; }

        public ReadWriteTagConfiguration MinValue { get; set; }

        public ReadWriteTagConfiguration TargetValue { get; set; }

        public ReadWriteTagConfiguration GapUnitValue { get; set; }

        public List<TagInfo> ReadTags
        {
            get
            {
                var readTags = new List<TagInfo>();
                if (MaxValue.IsReadDirection())
                {
                    readTags.Add(MaxValue.Tag);
                }
                if (MinValue.IsReadDirection())
                {
                    readTags.Add(MinValue.Tag);
                }
                if (TargetValue.IsReadDirection())
                {
                    readTags.Add(TargetValue.Tag);
                }
                if (GapUnitValue.IsReadDirection())
                {
                    readTags.Add(GapUnitValue.Tag);
                }

                return readTags;
            }
        }

        public static TargetDefinitionReadWriteTagConfiguration CreateDefault()
        {
            return new TargetDefinitionReadWriteTagConfiguration(new long?(),
                ReadWriteTagConfiguration.CreateEmpty(),
                ReadWriteTagConfiguration.CreateEmpty(),
                ReadWriteTagConfiguration.CreateEmpty(),
                ReadWriteTagConfiguration.CreateEmpty());
        }

        public static TargetDefinitionReadWriteTagConfiguration CreateRead()
        {
            return new TargetDefinitionReadWriteTagConfiguration(new long?(),
                CreateReadWithNoTag(),
                CreateReadWithNoTag(),
                CreateReadWithNoTag(),
                CreateReadWithNoTag());
        }

        private static ReadWriteTagConfiguration CreateReadWithNoTag()
        {
            return new ReadWriteTagConfiguration(TagDirection.Read, TagInfo.CreateEmpty());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(MaxValue.HasTag()
                ? string.Format(StringResources.TargetDefinitionReadWriteHistory_Max_Direction_With_Tag,
                    MaxValue.Direction.Name, MaxValue.Tag.Name)
                : string.Format(StringResources.TargetDefinitionReadWriteHistory_Max_Direction, MaxValue.Direction.Name));
            sb.AppendLine(MinValue.HasTag()
                ? string.Format(StringResources.TargetDefinitionReadWriteHistory_Min_Direction_With_Tag,
                    MinValue.Direction.Name, MinValue.Tag.Name)
                : string.Format(StringResources.TargetDefinitionReadWriteHistory_Min_Direction, MinValue.Direction.Name));
            sb.AppendLine(GapUnitValue.HasTag()
                ? string.Format(StringResources.TargetDefinitionReadWriteHistory_GapUnitValue_Direction_With_Tag,
                    GapUnitValue.Direction.Name, GapUnitValue.Tag.Name)
                : string.Format(StringResources.TargetDefinitionReadWriteHistory_GapUnitValue_Direction,
                    GapUnitValue.Direction.Name));
            sb.AppendLine(TargetValue.HasTag()
                ? string.Format(StringResources.TargetDefinitionReadWriteHistory_Target_Direction_With_Tag,
                    TargetValue.Direction.Name, TargetValue.Tag.Name)
                : string.Format(StringResources.TargetDefinitionReadWriteHistory_Target_Direction,
                    TargetValue.Direction.Name));

            return sb.ToString();
        }
    }
}
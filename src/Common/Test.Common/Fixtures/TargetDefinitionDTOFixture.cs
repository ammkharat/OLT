using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TargetDefinitionDTOFixture
    {
        public static TargetDefinitionDTO CreateTargetDefinitionDTO()
        {
            return new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition());
        }

        public static List<TargetDefinitionDTO> CreateTargetDefinitionDTOList(List<long> ids)
        {
            return CreateTargetDefinitionDTOList(ids.ToArray());
        }

        public static List<TargetDefinitionDTO> CreateTargetDefinitionDTOList()
        {
            return CreateTargetDefinitionDTOList(new long[] {1, 2, 3});
        }

        public static List<TargetDefinitionDTO> CreateTargetDefinitionDTOList(long[] ids)
        {
            List<TargetDefinitionDTO> targetDTOList = new List<TargetDefinitionDTO>();
            foreach (long id in ids)
            {
                TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(id);
                targetDTOList.Add(new TargetDefinitionDTO(targetDefinition));
            }
            return targetDTOList;
        }
    }
}
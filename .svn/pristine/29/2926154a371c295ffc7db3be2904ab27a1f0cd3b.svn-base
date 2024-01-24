using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LogDefinitionDTOFixture
    {
        public static LogDefinitionDTO CreateLogDefinitionDTO()
        {
            return new LogDefinitionDTO(LogDefinitionFixture.CreateLogDefinition(1));
        }

        public static List<LogDefinitionDTO> CreateLogDefinitionDTOList()
        {
            List<LogDefinitionDTO> list = new List<LogDefinitionDTO>();
            list.Add(CreateLogDefinitionDTO());
            return list;
        }
    }
}
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemDefinitionDTOFixture
    {
        public static List<ActionItemDefinitionDTO> CreateActionItemDefinitionDTOList()
        {
            var dtoList = new List<ActionItemDefinitionDTO> {CreateActionItemDefinitionDTO()};
            return dtoList;
        }

        public static ActionItemDefinitionDTO CreateWithGivenId(long? id)
        {
            var dto = CreateAPendingActionItem();
            dto.Id = id;
            return dto;
        }


        public static ActionItemDefinitionDTO CreateActionItemDefinitionDTO()
        {
            var dto =
                new ActionItemDefinitionDTO(ActionItemDefinitionFixture.CreateActionItemDefinition());
            return dto;
        }

        public static ActionItemDefinitionDTO CreateActionItemDefinitionDTO(BusinessCategory category)
        {
            var dto = new ActionItemDefinitionDTO(1,
                "Pending With FLOC List",
                DateTimeFixture.DateNow,
                new Time(DateTimeFixture.DateTimeNow),
                DateTimeFixture.DateNow,
                new Time(DateTimeFixture.DateTimeNow),
                1,
                1,
                "User",
                "A Fixture AID DTO",
                "Single",
                category.IdValue,
                category.Name,
                0,
                true,
                1,
                Priority.Normal,false);              //ayman action item reading
            return dto;
        }

        public static ActionItemDefinitionDTO CreateAPendingActionItem()
        {
            var dto = new ActionItemDefinitionDTO(1,
                "Pending With FLOC List",
                DateTimeFixture.DateNow,
                new Time(DateTimeFixture.DateTimeNow),
                DateTimeFixture.DateNow,
                new Time(DateTimeFixture.DateTimeNow),
                1,
                1,
                "User",
                "A Fixture AID DTO",
                "Single",
                1,
                "Test",
                0,
                true,
                1,
                Priority.Normal,false);          //ayman action item reading

            return dto;
        }
    }
}
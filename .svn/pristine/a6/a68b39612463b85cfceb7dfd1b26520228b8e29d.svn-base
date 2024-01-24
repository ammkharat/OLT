using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemDTOFixture
    {
        public static ActionItemDTO CreateActionItemDto()
        {
            return new ActionItemDTO(ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId());
        }

        public static ActionItemDTO CreateActionItemDto(DateTime startDateTime, DateTime endDateTime)
        {
            return
                new ActionItemDTO(1, startDateTime, startDateTime, endDateTime, endDateTime, 1, 
                                  Priority.Normal, "BLA", 2, "the description", "1", new List<string> { "SR1" }, new List<string> { "SR1 (SR1)" }, true, null, "some name", null, null, null,null,0,false);   
        }

        public static ActionItemDTO CreateActionItemRequiresResponseDto(long id)
        {
            ActionItemDTO actionItemDto =
                new ActionItemDTO(ActionItemFixture.CreateAPendingResponseRequiredActionItemWithIdPassedIn(id));
            return actionItemDto;
        }
        public static ActionItemDTO CreateActionItemRequiresResponseDto()
        {
            return CreateActionItemRequiresResponseDto(1);
        }

        public static ActionItemDTO CreateActionItemRequiresResponseDtoWithDates(DateTime startDate, DateTime startTime,
                                                                                 DateTime endTime)
        {
            return
                new ActionItemDTO(1, startDate, startTime, endTime, endTime, 1, Priority.Normal, "BLA",
                                  2, "the description", "1", new List<string> { "SR1" }, new List<string> { "SR1 (SR1)" }, true, null, "some name", null, null, null,null,0,false);          //ayman action item reading
        }

        public static ActionItemDTO CreateActionItemDoesntRequiresResponseDtoWithDates(DateTime startDate,
                                                                                       DateTime startTime,
                                                                                       DateTime endTime)
        {
            return
                new ActionItemDTO(1, startDate, startTime, endTime, endTime, 1, Priority.Normal, "BLA",
                                  2, "the description", "1", new List<string> { "SR1" }, new List<string> { "SR1 (SR1)" }, false, null, "some name", null, null, null,null,0,false);         //ayman action item reading
        }

        public static List<ActionItemDTO> CreateActionItemDtoList()
        {
            List<ActionItemDTO> list = new List<ActionItemDTO> {CreateActionItemDto()};
            return list;
        }
    }
}
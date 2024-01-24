using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ShiftGapReasonReportDTOFixture
    {
        public static List<ShiftGapReasonReportDTO> GetListWithTwoShiftGapReasonReportDTOs()
        {
            List<ShiftGapReasonReportDTO> constraintReportList = new List<ShiftGapReasonReportDTO>();
            DateTime lastModified = new DateTime(2005, 03, 09);
            ShiftGapReasonReportDTO dtoOne = GetARandomShiftGapReasonReportDTO();
            ShiftGapReasonReportDTO dtoTwo = new ShiftGapReasonReportDTO("12DA",
                                                                         DateTimeFixture.DateTimeNow,
                                                                         "ABC-DEF-HAHA",
                                                                         "ABC-DEF-HAHA Description",
                                                                         "ZZZ-YYY-XXX",
                                                                         "ZZZ-YYY-XXX Description",
                                                                         "TargetAlertName",
                                                                         "TagName",
                                                                         "1",
                                                                         "2",
                                                                         lastModified,
                                                                         "first last (user)",
                                                                         lastModified,
                                                                         TargetGapReason.EquipmentFailure.ToString(),
                                                                         "Description for constraint 2");
            constraintReportList.Add(dtoOne);
            constraintReportList.Add(dtoTwo);
            return constraintReportList;
        }

        public static ShiftGapReasonReportDTO GetARandomShiftGapReasonReportDTO()
        {
            return GetARandomShiftGapReasonReportDTO("ABC-DEF-HAHA Description");
        }
       
        public static ShiftGapReasonReportDTO GetARandomShiftGapReasonReportDTO(string targetAlertUnitDescription)
        {
            DateTime lastModified = new DateTime(2005, 03, 09);
            DateTime createdDate = new DateTime(2005, 03, 09);
            return   new ShiftGapReasonReportDTO("12DA",
                                         createdDate,
                                         "ABC-DEF-HAHA",
                                         targetAlertUnitDescription,
                                         "ZZZ-YYY-XXX",
                                         "ZZZ-YYY-XXX Description", 
                                         "TargetAlertName",
                                         "TagName",
                                         "1",
                                         "2",
                                         lastModified,
                                         "first last (user)",
                                         lastModified,
                                         TargetGapReason.EquipmentFailure.ToString(),
                                         "Description for constraint 1");
          
        }
    }
}
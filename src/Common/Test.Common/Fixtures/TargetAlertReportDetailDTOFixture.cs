using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class TargetAlertReportDetailDTOFixture
    {
        public static TargetAlertReportDetailDTO CreateTargetAlertReportDetailDTO()
        {
            return
                new TargetAlertReportDetailDTO(-99, "name", FunctionalLocationFixture.GetAny_Unit1(),
                                               TargetAlertStatus.StandardAlert,
                                               new DateTime(2006, 8, 5), new DateTime(2006, 8, 5), 
                                               UserShiftFixture.CreateUserShift(),
                                               TagInfoFixture.CreateTagInfoWithoutId(),
                                               new TargetThresholdEvaluation(
                                                   TargetThresholdExcessLevel.NeverToExceedMax, 100, 125, 25), 200, UserFixture.CreateAdmin(),
                                               new DateTime(2006, 5, 30),
                                               new List<TargetAlertResponseReportDetailDTO>{
                                                   new TargetAlertResponseReportDetailDTO(
                                                       UserFixture.CreateAdmin(), new DateTime(2006, 5, 30), "Comment", TargetGapReason.EquipmentFailure)});

        }
    }
}

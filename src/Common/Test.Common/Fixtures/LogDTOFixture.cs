using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LogDTOFixture
    {
        public static LogDTO CreateLogDTO()
        {
            return new LogDTO(LogFixture.CreateLogItemGoofySarnia());
        }

        public static List<LogReportDTO> CreateLogReportDTOListWithTwoLogs()
        {
            var list = new List<LogReportDTO>
                           {
                               new LogReportDTO(1, 2, "12e", new DateTime(1975, 3, 9, 4, 30, 0), 
                                                "A-B-C-D", "A Description",
                                                "A-B-C", "ABC Desc", 
                                                "Jimmy", new DateTime(2006, 12, 25, 14, 30, 0),
                                                "Report Log 1",
                                                "Report Log 1"),


                               new LogReportDTO(2, 2, "12e", new DateTime(1975, 3, 9, 4, 30, 0),
                                                "A-B-C-D", "A Description",
                                                "A-B-C", "ABC Desc", 
                                                "Jimmy", new DateTime(2006, 12, 25, 14, 30, 0), 
                                                "Report Log 2",
                                                "Report Log 2")
                           };

            return list;
        }

        public static LogDTO CreateReplyTo(LogDTO dto)
        {
            Log log = LogFixture.CreateLogItemGoofySarnia();

            return new LogDTO(dto.IdValue + 1,
                              dto.RootLogId,
                              dto.Id,
                              dto.FunctionalLocationNames,
                              log.InspectionFollowUp,
                              log.ProcessControlFollowUp,
                              log.OperationsFollowUp,
                              log.SupervisionFollowUp,
                              log.EnvironmentalHealthSafetyFollowUp,
                              log.OtherFollowUp,
                              log.LogDateTime,                              
                              log.CreationUser.IdValue,
                              log.CreationUser.FirstName,
                              log.CreationUser.LastName,
                              log.CreationUser.Username,
                              log.CreationUser.FullName,
                              log.CreatedDateTime,
                              log.LastModifiedDate,
                              log.CreatedShiftPattern.IdValue,
                              dto.CreatedShiftStartDate,
                              dto.CreatedShiftStartTime,
                              dto.CreatedShiftEndDate,
                              dto.CreatedShiftEndTime,
                              log.CreatedShiftPattern.Name,
                              false,
                              false,
                              log.Source.IdValue,
                              log.IsOperatingEngineerLog,
                              log.CreatedByRole.IdValue,
                              null,
                              false, false, null, "all comments", null, null);
        }

        public static LogDTO CreateLogDTOWithUnavailableParent(long rootLogId)
        {
            const long replyToLogId = 123232322;

            Log baseLog = LogFixture.CreateLogItemGoofySarnia();
            baseLog.ReplyToLogId = replyToLogId;
            baseLog.RootLogId = rootLogId;

            return new LogDTO(baseLog);
        }
    }
}
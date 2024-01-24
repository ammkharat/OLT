using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class DailyShiftLogReportDTO : DomainObject
    {
        private readonly List<LogReportDTO> logs;
        private readonly List<TagInfoReportDetail> tagInfoReportDetails;

        public DailyShiftLogReportDTO(List<LogReportDTO> logs, List<TagInfoReportDetail> tagInfoReportDetails)
        {
            this.logs = logs;
            this.tagInfoReportDetails = tagInfoReportDetails;
        }

        public List<LogReportDTO> Logs
        {
            get { return logs; }
        }

        public List<TagInfoReportDetail> TagInfoReportDetailList
        {
            get { return tagInfoReportDetails; }
        }

        public bool IsEmpty
        {
            get { return logs.IsEmpty() && tagInfoReportDetails.IsEmpty(); }
        }
    }
}
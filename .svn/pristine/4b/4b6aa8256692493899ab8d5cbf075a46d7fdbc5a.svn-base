using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class OperatingEngineerLogReportDTO
    {
        private readonly List<LogReportDTO> logs;
        private readonly List<TagInfoReportDetail> tagInfoReportDetails;
        private readonly List<WorkAssignmentReportDetail> workAssignmentReportDetails;

        public OperatingEngineerLogReportDTO(List<LogReportDTO> logs,
            List<WorkAssignmentReportDetail> workAssignmentReportDetails,
            List<TagInfoReportDetail> tagInfoReportDetails)
        {
            this.logs = logs;
            this.workAssignmentReportDetails = workAssignmentReportDetails;
            this.tagInfoReportDetails = tagInfoReportDetails;
        }

        public List<LogReportDTO> Logs
        {
            get { return logs; }
        }

        public List<WorkAssignmentReportDetail> WorkAssignmentReportDetails
        {
            get { return workAssignmentReportDetails; }
        }

        public List<TagInfoReportDetail> TagInfoReportDetailList
        {
            get { return tagInfoReportDetails; }
        }

        public bool Empty
        {
            get
            {
                return Logs.IsEmpty() &&
                       WorkAssignmentReportDetails.IsEmpty() &&
                       TagInfoReportDetailList.IsEmpty();
            }
        }
    }
}
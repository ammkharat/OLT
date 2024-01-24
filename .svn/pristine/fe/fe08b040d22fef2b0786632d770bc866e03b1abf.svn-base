using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class PermitRequestFortHillsDTO : BasePermitRequestDTO, IHasStatus<PermitRequestCompletionStatus>,
        IHasPriority
    {
        public PermitRequestFortHillsDTO(long? id, WorkPermitFortHillsType workPermitType, string functionalLocationName,
            PermitRequestCompletionStatus completionStatus, Date requestedStartDate, Time requestedStartTime,
            Date endDate, Time requestedEndTime, string workOrderNumber, string description,
            DataSource dataSource, string @group, string trade, string lastImportedByFullnameWithUserName,
            DateTime? lastImportedDateTime, string lastSubmittedByFullnameWithUserName, DateTime? lastSubmittedDateTime,
            long createdByUserId, DateTime lastModifiedDateTime, string lastModifiedByFullnameWithUserName,
            Priority priority) :
                base(id, endDate, description, dataSource, lastImportedByFullnameWithUserName,
                    lastImportedDateTime, lastSubmittedByFullnameWithUserName, lastSubmittedDateTime, createdByUserId,
                    lastModifiedDateTime,
                    lastModifiedByFullnameWithUserName)
        {
            WorkPermitType = workPermitType;
            FunctionalLocationNamesAsString = functionalLocationName;
            RequestedStartDate = requestedStartDate;
            RequestedStartTime = requestedStartTime;
            RequestedEndDate = endDate;
            RequestedEndTime = requestedEndTime;
            //RequestedStartTimeDay = requestedStartTimeDay;
            //RequestedStartTimeNight = requestedStartDateTimeNight;
            CompletionStatus = completionStatus;
            Group = group;
            Trade = trade;
            WorkOrderNumber = workOrderNumber;
            Priority = priority;
           // AreaLabelName = areaLabelName;
        }

        public PermitRequestFortHillsDTO(PermitRequestFortHills request) : this(
            request.Id,
            request.WorkPermitType,
            request.FunctionalLocation.FullHierarchy,
            request.CompletionStatus,
            request.RequestedStartDate,
            request.RequestedStartTime,
            request.EndDate,
            request.RequestedEndTime,
            request.WorkOrderNumber,
            request.Description,
            request.DataSource,
            request.Group == null ? null : request.Group.Name,
            request.Occupation,
            request.LastImportedByUser == null ? null : request.LastImportedByUser.FullNameWithUserName,
            request.LastImportedDateTime,
            request.LastSubmittedByUser == null ? null : request.LastSubmittedByUser.FullNameWithUserName,
            request.LastSubmittedDateTime,
            request.CreatedBy.IdValue,
            request.LastModifiedDateTime,
            request.LastModifiedBy.FullNameWithUserName,
            request.Priority)
            //,request.AreaLabel == null ? null : request.AreaLabel.Name)
        {
        }

        public WorkPermitFortHillsType WorkPermitType { get; private set; }
        public WorkAssignment WorkAssignment{ get; private set; }
        [IncludeInSearch]
        public string FunctionalLocationNamesAsString { get; private set; }

        public override Date StartDate
        {
            get { return RequestedStartDate; }
        }

        public Date RequestedStartDate { get; private set; }
        public Time RequestedStartTime { get; private set; }
        public Date RequestedEndDate { get; private set; }
        public Time RequestedEndTime { get; private set; }
       // public Time RequestedStartTimeDay { get; private set; }
       // public Time RequestedStartTimeNight { get; private set; }

        public PermitRequestCompletionStatus CompletionStatus { get; private set; }

        [IncludeInSearch]
        public string Group { get; set; }

        [IncludeInSearch]
        public string Trade { get; private set; }

        [IncludeInSearch]
        public string AreaLabelName { get; private set; }

        [IncludeInSearch]
        public override DateTime? StartDateAsDateTime
        {
            get
            {
                var time = new Time(0);
                time = RequestedStartTime;
                //if (RequestedStartTimeDay != null && RequestedStartTimeNight == null)
                //{
                //    time = RequestedStartTimeDay;
                //}
                //else if (RequestedStartTimeDay == null && RequestedStartTimeNight != null)
                //{
                //    time = RequestedStartTimeNight;
                //}
                //else if (RequestedStartTimeDay != null && RequestedStartTimeNight != null)
                //{
                //    time = RequestedStartTimeDay;
                //}

                return StartDate != null ? (DateTime?) StartDate.CreateDateTime(time) : null;
            }
        }

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        [IncludeInSearch]
        public PermitRequestCompletionStatus Status
        {
            get { return CompletionStatus; }
        }
    }
}
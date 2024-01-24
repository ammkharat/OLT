using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class PermitRequestLubesDTO : BasePermitRequestDTO, IHasStatus<PermitRequestCompletionStatus>,
        ICreatedByARole
    {
        public const long CreatedByImportRoleID = -999;

        public PermitRequestLubesDTO(long? id, WorkPermitLubesType workPermitType, string functionalLocationName,
            PermitRequestCompletionStatus completionStatus, Date requestedStartDate, Time requestedStartTimeDay,
            Time requestedStartDateTimeNight, Date endDate, string workOrderNumber, string description,
            DataSource dataSource, string trade, string lastImportedByFullnameWithUserName,
            DateTime? lastImportedDateTime,
            string lastSubmittedByFullnameWithUserName, DateTime? lastSubmittedDateTime, long createdByUserId,
            DateTime lastModifiedDateTime, string lastModifiedByFullnameWithUserName, long createdByRoleId,
            string requestedByGroupName) :
                base(id, endDate, description, dataSource, lastImportedByFullnameWithUserName,
                    lastImportedDateTime, lastSubmittedByFullnameWithUserName, lastSubmittedDateTime, createdByUserId,
                    lastModifiedDateTime,
                    lastModifiedByFullnameWithUserName)
        {
            WorkPermitType = workPermitType;
            FunctionalLocationNamesAsString = functionalLocationName;
            RequestedStartDate = requestedStartDate;
            RequestedStartTimeDay = requestedStartTimeDay;
            RequestedStartTimeNight = requestedStartDateTimeNight;
            CompletionStatus = completionStatus;
            Trade = trade;
            WorkOrderNumber = workOrderNumber;
            CreatedByRoleId = createdByRoleId;
            RequestedByGroup = requestedByGroupName;
        }

        public PermitRequestLubesDTO(PermitRequestLubes request)
            : this(
                request.Id,
                request.WorkPermitType,
                request.FunctionalLocation.FullHierarchy,
                request.CompletionStatus,
                request.RequestedStartDate,
                request.RequestedStartTimeDay,
                request.RequestedStartTimeNight,
                request.EndDate,
                request.WorkOrderNumber,
                request.Description,
                request.DataSource,
                request.Trade,
                request.LastImportedByUser == null ? null : request.LastImportedByUser.FullNameWithUserName,
                request.LastImportedDateTime,
                request.LastSubmittedByUser == null ? null : request.LastSubmittedByUser.FullNameWithUserName,
                request.LastSubmittedDateTime,
                request.CreatedBy.IdValue,
                request.LastModifiedDateTime,
                request.LastModifiedBy.FullNameWithUserName,
                request.CreatedByRole != null ? request.CreatedByRole.IdValue : CreatedByImportRoleID,
                request.RequestedByGroup.GetName())
        {
        }

        public WorkPermitLubesType WorkPermitType { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationNamesAsString { get; private set; }

        public override Date StartDate
        {
            get { return RequestedStartDate; }
        }

        public Date RequestedStartDate { get; private set; }
        public Time RequestedStartTimeDay { get; private set; }
        public Time RequestedStartTimeNight { get; private set; }

        public string RequestedByGroup { get; private set; }

        public PermitRequestCompletionStatus CompletionStatus { get; private set; }

        [IncludeInSearch]
        public string Trade { get; private set; }

        [IncludeInSearch]
        public override DateTime? StartDateAsDateTime
        {
            get
            {
                var time = new Time(0);
                if (RequestedStartTimeDay != null && RequestedStartTimeNight == null)
                {
                    time = RequestedStartTimeDay;
                }
                else if (RequestedStartTimeDay == null && RequestedStartTimeNight != null)
                {
                    time = RequestedStartTimeNight;
                }
                else if (RequestedStartTimeDay != null && RequestedStartTimeNight != null)
                {
                    time = RequestedStartTimeDay;
                }

                return StartDate != null ? (DateTime?) StartDate.CreateDateTime(time) : null;
            }
        }

        public long CreatedByRoleId { get; private set; }

        [IncludeInSearch]
        public PermitRequestCompletionStatus Status
        {
            get { return CompletionStatus; }
        }
    }
}
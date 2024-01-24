using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class PermitRequestEdmontonDTO : BasePermitRequestDTO, IHasStatus<PermitRequestCompletionStatus>,
        IHasPriority
    {
        private readonly string templateName;
        private string categories;
        private string wp_TypeName;
        private string desc;
        private  bool global;

        private readonly long templateId;

        public PermitRequestEdmontonDTO(long? id, WorkPermitEdmontonType workPermitType, string functionalLocationName,
            PermitRequestCompletionStatus completionStatus, Date requestedStartDate, Time requestedStartTimeDay,
            Time requestedStartDateTimeNight, Date endDate, string workOrderNumber, string description,
            DataSource dataSource, string @group, string trade, string lastImportedByFullnameWithUserName,
            DateTime? lastImportedDateTime, string lastSubmittedByFullnameWithUserName, DateTime? lastSubmittedDateTime,
            long createdByUserId, DateTime lastModifiedDateTime, string lastModifiedByFullnameWithUserName,
            Priority priority, string areaLabelName) :
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
            Group = group;
            Trade = trade;
            WorkOrderNumber = workOrderNumber;
            Priority = priority;
            AreaLabelName = areaLabelName;
        }

        public PermitRequestEdmontonDTO(PermitRequestEdmonton request) : this(
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
            request.Group == null ? null : request.Group.Name,
            request.Occupation,
            request.LastImportedByUser == null ? null : request.LastImportedByUser.FullNameWithUserName,
            request.LastImportedDateTime,
            request.LastSubmittedByUser == null ? null : request.LastSubmittedByUser.FullNameWithUserName,
            request.LastSubmittedDateTime,
            request.CreatedBy.IdValue,
            request.LastModifiedDateTime,
            request.LastModifiedBy.FullNameWithUserName,
            request.Priority,
            request.AreaLabel == null ? null : request.AreaLabel.Name)
        {
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public PermitRequestEdmontonDTO(long id, string templateName, string categories, string wp_TypeName, string desc, bool global, long templateId) :
            base(id, templateName, categories, wp_TypeName, desc, global, templateId)
        {
            Id = id;
            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            this.global = global;
            this.templateId = templateId;
            
        }


        public WorkPermitEdmontonType WorkPermitType { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationNamesAsString { get; private set; }

        public override Date StartDate
        {
            get { return RequestedStartDate; }
        }

        public Date RequestedStartDate { get; private set; }
        public Time RequestedStartTimeDay { get; private set; }
        public Time RequestedStartTimeNight { get; private set; }

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

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        [IncludeInSearch]
        public PermitRequestCompletionStatus Status
        {
            get { return CompletionStatus; }
        }
       
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        [IncludeInSearch]
        public string TemplateName
        {
            get { return templateName; }
        }
        [IncludeInSearch]
        public string Categories
        {
            get { return categories; }
        }

        [IncludeInSearch]
        public string WP_Type
        {
            get { return wp_TypeName; }
        }

        [IncludeInSearch]
        public string Desc
        {
            get { return desc; }
        }
        [IncludeInSearch]
        public bool Global
        {
            get { return global; }
        }
        public long TemplateId
        {
            get { return templateId; }
        }
    }
}
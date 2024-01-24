using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormEdmontonGN75BDTO : DomainObject, IFormEdmontonDTO, IHasStatus<FormStatus> 
    {
        public FormEdmontonGN75BDTO(FormGN75B form)
            : this(
                form.IdValue, form.FormStatus, form.FunctionalLocation.FullHierarchy, form.LocationOfWork,
                form.EquipmentType, form.LockBoxNumber,
                form.CreatedBy.IdValue, form.CreatedBy.FullNameWithUserName, form.LastModifiedBy.IdValue,
                form.LastModifiedBy.FullNameWithUserName, form.CreatedDateTime, form.ClosedDateTime,
                form.LastModifiedDateTime,false,form.TemplateID)            //ayman Sarnia eip DMND0008992
        {
        }

        public FormEdmontonGN75BDTO(long id, FormStatus formStatus, string functionalLocation, string location,
            string equipmentType, string lockBoxNumber,
            long createdByUserId, string createdByFullNameWithUserName, long lastModifiedByUserId,
            string lastModifiedByFullName, DateTime createdDateTime, DateTime? closedDateTime,
            DateTime lastModifiedDateTime, bool deleted,long templateid)    //ayman Sarnia eip DMND0008992
        {
            this.id = id;
            Status = formStatus;
            FunctionalLocation = functionalLocation;
            Location = location;

            EquipmentType = equipmentType;
            LockBoxNumber = lockBoxNumber;

            CreatedByUserId = createdByUserId;
            CreatedByFullNameWithUserName = createdByFullNameWithUserName;
            LastModifiedByUserId = lastModifiedByUserId;
            LastModifiedByFullName = lastModifiedByFullName;
            CreatedDateTime = createdDateTime;
            ClosedDateTime = closedDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Deleted = deleted;
            TemplateId = templateid;               //ayman Sarnia eip DMND0008992
        }

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime? ClosedDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime CreatedDateTime { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocation { get; private set; }

        [IncludeInSearch]
        public string Location { get; private set; }

        [IncludeInSearch]
        public string EquipmentType { get; private set; }

        [IncludeInSearch]
        public string LockBoxNumber { get; private set; }

        [IncludeInSearch]
        public string CreatedByFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public string LastModifiedByFullName { get; private set; }

        public bool Deleted { get; private set; }

        public long TemplateId { get; private set; }    //ayman Sarnia eip DMND0008992
        [IncludeInSearch]
        public FormStatus Status { get; private set; }

        public long CreatedByUserId { get; set; }

        [IncludeInSearch]
        public long FormNumber
        {
            get { return IdValue; }
        }

        public long LastModifiedByUserId { get; set; }

        public bool IsWorkPermitDateTimesWithinFormDateTimes(Range<DateTime> workPermitDateRange)
        {
            // we have no date/times on Gn-75b. so always allow them to be selected.
            return true;
        }

        public bool IsPermitRequestDatesWithinFormDates(Range<Date> workPermitDateRange)
        {
            // we have no date/times on Gn-75b. so always allow them to be selected.
            return true;
        }

        public EdmontonFormType FormType            //ayman Sarnia eip DMND0008992
        {
            get
            {
                if (TemplateId > 0)
                    return EdmontonFormType.GN75BSarniaEIP;
                    return EdmontonFormType.GN75B;                    
            }
        }
    }
}
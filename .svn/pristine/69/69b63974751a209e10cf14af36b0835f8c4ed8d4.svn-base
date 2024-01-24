using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormOilsandsTrainingDTO : DomainObject, IHasStatus<FormStatus>, ICreatedByARole
    {
        private readonly List<string> functionalLocations = new List<string>();

        public FormOilsandsTrainingDTO(long id, List<string> functionalLocations, decimal totalHours, string assignment,
            long createdByUserId, string createdByFullNameWithUserName, DateTime createdDateTime,
            DateTime lastModifiedDateTime, long lastModifiedByUserId,
            Date trainingDate, string shiftName, FormStatus formStatus, DateTime? approvedDateTime, long createdByRoleId)
        {
            this.id = id;
            functionalLocations.ForEach(AddFunctionalLocation);
            TotalHours = totalHours;
            CreatedByUserId = createdByUserId;
            CreatedByFullNameWithUserName = createdByFullNameWithUserName;
            TrainingDate = trainingDate;
            ShiftName = shiftName;
            Status = formStatus;
            Assignment = assignment;
            ApprovedDateTime = approvedDateTime;
            CreatedDateTime = createdDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedByUserId = lastModifiedByUserId;
            CreatedByRoleId = createdByRoleId;
        }

        public FormOilsandsTrainingDTO(FormOilsandsTraining form)
            : this(
                form.IdValue, form.FunctionalLocations.ConvertAll(floc => floc.FullHierarchy), form.TotalHours,
                form.WorkAssignment == null ? null : form.WorkAssignment.Name, form.CreatedBy.IdValue,
                form.CreatedBy.FullNameWithUserName, form.CreatedDateTime, form.LastModifiedDateTime,
                form.LastModifiedBy.IdValue, form.TrainingDate, form.ShiftPattern.Name, form.FormStatus,
                form.ApprovedDateTime, form.CreatedByRole.IdValue)
        {
        }

        [IncludeInSearch]
        public long? FormNumber
        {
            get { return Id; }
        }

        [IncludeInSearch]
        public string FunctionalLocationNames
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public string CreatedByFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public Date TrainingDate { get; private set; }

        [IncludeInSearch]
        public DateTime TrainingDateAsDateTime
        {
            get { return TrainingDate.ToDateTimeAtStartOfDay(); }
        }

        [IncludeInSearch]
        public string Assignment { get; private set; }

        [IncludeInSearch]
        public DateTime CreatedDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime? ApprovedDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { get; private set; }

        [IncludeInSearch]
        public decimal TotalHours { get; private set; }

        [IncludeInSearch]
        public string ShiftName { get; private set; }

        public long LastModifiedByUserId { get; set; }

        public bool IsOutsideIdealNumberOfHours
        {
            get { return FormOilsandsTraining.IsOutsideIdealNumberOfHours(TotalHours); }
        }

        public long CreatedByRoleId { get; private set; }

        public long CreatedByUserId { get; set; }

        [IncludeInSearch]
        public FormStatus Status { get; private set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }
    }
}
using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormOilsandsPriorityPageDTO : DomainObject, IHasStatus<FormStatus>
    {
        private readonly List<string> functionalLocations = new List<string>();

        public FormOilsandsPriorityPageDTO(
            long id, List<string> functionalLocations, OilsandsFormType formType, long createdByUserId,
            string createdByFullName, DateTime createdDateTime,
            long lastModifiedByUserId, Date trainingDate, string shiftName, FormStatus formStatus,
            string workAssignmentName, decimal totalHours)
        {
            Id = id;
            functionalLocations.ForEach(AddFunctionalLocation);
            FormType = formType;
            CreatedByUserId = createdByUserId;
            CreatedByFullName = createdByFullName;
            TrainingDate = trainingDate;
            ShiftName = shiftName;
            Status = formStatus;
            CreatedDateTime = createdDateTime;
            LastModifiedByUserId = lastModifiedByUserId;
            CreatedByWorkAssignmentName = workAssignmentName;
            TotalHours = totalHours;
        }

        public OilsandsFormType FormType { get; private set; }

        public long? FormNumber
        {
            get { return Id; }
        }

        public long CreatedByUserId { get; set; }

        public string CreatedByFullName { get; private set; }

        public string CreatedByWorkAssignmentName { get; private set; }

        public Date TrainingDate { get; private set; }

        public string ShiftName { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public long LastModifiedByUserId { get; set; }

        public decimal TotalHours { get; private set; }

        public string FunctionalLocationNames
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        public string FormTypeAndNumber
        {
            get { return String.Format("{0} #{1}", FormType.Name, FormNumber); }
        }

        public string CreatedByNameAndWorkAssignment
        {
            get
            {
                if (CreatedByWorkAssignmentName != null)
                {
                    return string.Format("{0} ({1})", CreatedByFullName, CreatedByWorkAssignmentName);
                }

                return CreatedByFullName;
            }
        }

        public bool IsOutsideIdealNumberOfHours
        {
            get { return FormOilsandsTraining.IsOutsideIdealNumberOfHours(TotalHours); }
        }

        public FormStatus Status { get; private set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }
    }
}
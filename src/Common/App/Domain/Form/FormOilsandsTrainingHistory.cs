using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormOilsandsTrainingHistory : DomainObjectHistorySnapshot
    {
        public FormOilsandsTrainingHistory(FormOilsandsTraining form)
            : base(form.IdValue, form.LastModifiedBy, form.LastModifiedDateTime)
        {
            FormStatus = form.FormStatus;

            ApprovedDateTime = form.ApprovedDateTime;
            TrainingDate = form.TrainingDate;
            ShiftName = form.ShiftPattern.DisplayName;
            GeneralComments = form.GeneralComments;
            TotalHours = form.TotalHours;

            FunctionalLocations = form.FunctionalLocations.FullHierarchyListToString(true, false);
            Approvals = form.GetApprovalsSnapshot();
            TrainingItems = form.GetTrainingItemsSnapshot();
        }

        public FormOilsandsTrainingHistory(long id, FormStatus formStatus, string functionalLocations, string approvals,
            string trainingItems, DateTime? approvedDateTime, Date trainingDate, string shiftName, decimal totalHours,
            string generalComments, User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
            FormStatus = formStatus;

            ApprovedDateTime = approvedDateTime;
            TrainingDate = trainingDate;
            ShiftName = shiftName;
            GeneralComments = generalComments;
            TotalHours = totalHours;

            FunctionalLocations = functionalLocations;
            Approvals = approvals;
            TrainingItems = trainingItems;
        }

        public FormStatus FormStatus { get; set; }

        public DateTime? ApprovedDateTime { get; set; }
        public Date TrainingDate { get; set; }
        public string ShiftName { get; set; }
        public string GeneralComments { get; set; }
        public decimal TotalHours { get; set; }

        public string FunctionalLocations { get; set; }
        public string Approvals { get; set; }
        public string TrainingItems { get; set; }
    }
}
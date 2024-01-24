using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormOilsandsTraining : BaseFormOilsands, IFunctionalLocationRelevant
    {
        public const decimal IdealNumberOfTrainingHours = 10.5m;

        public FormOilsandsTraining(long? id, FormStatus formStatus, User createdBy, DateTime createdDateTime,
            Role createdByRole) : base(createdBy, createdDateTime)
        {
            this.id = id;

            FormStatus = formStatus;
            ResetApprovals();

            FunctionalLocations = new List<FunctionalLocation>();
            TrainingItems = new List<FormOilsandsTrainingItem>();

            CreatedByRole = createdByRole;
        }

        public override List<FormApproval> Approvals { get; set; }

        public FormStatus FormStatus { get; set; }

        public Role CreatedByRole { get; set; }

        public override Date FromDate
        {
            get { return TrainingDate; }
        }

        public override Date ToDate
        {
            get { return TrainingDate; }
        }

        public DateTime? ApprovedDateTime { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        [CachedRelationship]
        public WorkAssignment WorkAssignment { get; set; }

        public List<FormOilsandsTrainingItem> TrainingItems { get; set; }

        public Date TrainingDate { get; set; }

        public ShiftPattern ShiftPattern { get; set; }

        public string GeneralComments { get; set; }

        public decimal TotalHours
        {
            get { return CalculateHours(TrainingItems); }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkUpRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevant)
                    return true;
            }
            return false;
        }

        private void ResetApprovals()
        {
            //RITM0249565 - Vibhor
           // Approvals = new List<FormApproval> { new FormApproval(null, id, "Shift Supervisor", null, null, null, 1) };
            Approvals = new List<FormApproval> { new FormApproval(null, id, "Approver", null, null, null, 1) };
        }

        public override FormOilsandsPriorityPageDTO CreatePriorityPageDTO()
        {
            return new FormOilsandsPriorityPageDTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                OilsandsFormType.Training,
                CreatedBy.IdValue,
                CreatedBy.FullName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                TrainingDate,
                ShiftPattern.Name,
                FormStatus,
                WorkAssignment != null ? WorkAssignment.Name : null,
                TotalHours);
        }

        public static decimal CalculateHours(List<FormOilsandsTrainingItem> trainingItems)
        {
            decimal totalHours = 0;
            trainingItems.ForEach(item => totalHours += item.Hours.GetValueOrDefault(0m));
            return totalHours;
        }

        public string GetTrainingItemsSnapshot()
        {
            return
                TrainingItems.ConvertAll(
                    item =>
                        String.Format(StringResources.FormOilsandsTraining_TrainingItemHistorySnapshot,
                            item.TrainingBlock.Name,
                            item.Comments,
                            item.Supervisor,                                     //ayman training form add column
                            item.BlockCompleted.BooleanToYesNoString(),
                            item.Hours.GetValueOrDefault(0m).ToString("###0.00"))).BuildCommaSeparatedList();
        }

        public string GetApprovalsSnapshot()
        {
            return FormApproval.GetApprovalsSnapshot(Approvals);
        }

        public void MarkAsApproved(DateTime approvedDateTime)
        {
            ApprovedDateTime = approvedDateTime;
            FormStatus = FormStatus.Approved;
        }

        public void MarkAsUnapproved()
        {
            ApprovedDateTime = null;
            FormStatus = FormStatus.Draft;
        }

        public bool WillNeedReapproval(string originalGeneralComments,
            Date originalTrainingDate,
            ShiftPattern originalShiftPattern,
            List<FormOilsandsTrainingItem> originalTrainingItems,
            List<FunctionalLocation> originalFlocs,
            User currentUser)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            var trainingItemsChanged = TrainingItems.Count != originalTrainingItems.Count ||
                                       !TrainingItems.TrueForAll(originalTrainingItems.Contains);

            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);
            var generalCommentsChanged = originalGeneralComments != GeneralComments;
            var shiftPatternChanged = originalShiftPattern.IdValue != ShiftPattern.IdValue;
            var trainingDateChanged = originalTrainingDate != TrainingDate;

            return (trainingItemsChanged || flocsChanged || generalCommentsChanged || shiftPatternChanged ||
                    trainingDateChanged);
        }

        protected bool ThereAreCurrentlyApprovalsByOtherPeople(User currentUser)
        {
            return FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(Approvals, currentUser);
        }

        public FormOilsandsTrainingHistory TakeSnapshot()
        {
            return new FormOilsandsTrainingHistory(this);
        }

        public override void ConvertToClone(User createdByUser, DateTime now)
        {
            base.ConvertToClone(createdByUser, now);
            ResetApprovals();
            ApprovedDateTime = null;
            FormStatus = FormStatus.Draft;
        }

        public static bool IsOutsideIdealNumberOfHours(decimal numberOfHours)
        {
            return numberOfHours != IdealNumberOfTrainingHours;
        }
    }
}
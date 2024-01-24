using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN1 : BaseEdmontonForm, IDocumentLinksObject
    {
        public const string ConstFieldMaintCoordApprovalName = "Const / Field / Maint Coordinator";
        public const string OpsCoordApprovalName = "Ops Coordinator";
        public const string AreaManagerApprovalName = "Manager Area Operations";
        private List<TradeChecklist> _tradeChecklists;

        public FormGN1(long? id, FormStatus formStatus, FunctionalLocation functionalLocation, string cseLevel,
            DateTime validFromDateTime, DateTime validToDateTime, User createdBy, DateTime createdDateTime,long siteid)       //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)       
        {
            FunctionalLocation = functionalLocation;
            CSELevel = cseLevel;
            TradeChecklists = new List<TradeChecklist>();
            DocumentLinks = new List<DocumentLink>();

            PlanningWorksheetApprovals = new List<FormApproval>
            {
                new FormApproval(null, id, ConstFieldMaintCoordApprovalName, null, null, null, 1),
                new FormApproval(null, id, OpsCoordApprovalName, null, null, null, 2),
                new FormApproval(null, id, AreaManagerApprovalName, null, null, null, 3),
            };

            RescuePlanApprovals = new List<FormApproval>
            {
                new FormApproval(null, id, "Rescue Team Representative", null, null, null, 1)
            };
        }

        public override List<FormApproval> AllApprovals
        {
            get
            {
                var allApprovals = new List<FormApproval>();
                allApprovals.AddRange(PlanningWorksheetApprovals);
                allApprovals.AddRange(RescuePlanApprovals);
                return allApprovals;
            }
        }

        public List<FormApproval> EnabledPlanningWorksheetApprovals
        {
            get { return PlanningWorksheetApprovals.FindAll(a => a.Enabled); }
        }

        public List<FormApproval> EnabledRescuePlanApprovals
        {
            get { return RescuePlanApprovals.FindAll(a => a.Enabled); }
        }

        public FunctionalLocation FunctionalLocation { get; set; }

        public string Location { get; set; }

        //ayman generic forms
        public long SiteId { get; set; }

        public string CSELevel { get; set; }

        public string JobDescription { get; set; }

        public string PlanningWorksheetContent { get; set; }
        public string PlanningWorksheetPlainTextContent { get; set; }

        
        public List<FormApproval> PlanningWorksheetApprovals { get; set; }

        public List<TradeChecklist> TradeChecklists
        {
            get { return _tradeChecklists; }
            set
            {
                _tradeChecklists = value;
                TradeChecklistNames = value.Any()
                    ? value.Distinct(TradeChecklist.TradeComparer)
                        .ToList()
                        .ConvertAll(input => input.Trade)
                        .ToCommaSeparatedString()
                    : null;
            }
        }

        public string RescuePlanContent { get; set; }
        public string RescuePlanPlainTextContent { get; set; }

        public List<FormApproval> RescuePlanApprovals { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.GN1; }
        }

        public string TradeChecklistNames { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new FormEdmontonGN1DTO(
                IdValue,
                FunctionalLocation.FullHierarchy,
                TradeChecklistNames,
                EdmontonFormType.GN1,
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                LastModifiedDateTime,
                FromDateTime,
                ToDateTime,
                FormStatus,
                ApprovedDateTime,
                ClosedDateTime,
                RemainingApprovalsAsStringList());
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForASingleFloc(siteIdOfClient, fullHierarchies, FunctionalLocation);
        }

        public bool EntireFormWillNeedReapproval(User currentUser, FunctionalLocation originalFunctionalLocation)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return SomethingRequiringReapprovalOfTheEntireFormHasChanged(originalFunctionalLocation);
        }

        private bool SomethingRequiringReapprovalOfTheEntireFormHasChanged(FunctionalLocation originalFunctionalLocation)
        {
            var flocHasChanged = originalFunctionalLocation.IdValue != FunctionalLocation.IdValue;
            return flocHasChanged;
        }

        public bool PlanningWorksheetAndRescuePlanWillNeedReapproval(
            bool noReapprovalRequiredForEndDateChange,
            User currentUser,
            FunctionalLocation originalFunctionalLocation,
            DateTime originalStartDateTime,
            DateTime originalEndDateTime,
            string originalJobDescription,
            string originalCSELevel)
        {
            if (!ThereAreCurrentlyPlanningWorksheetOrRescuePlanApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return SomethingRequiringReapprovalOfPlanningWorksheetAndRescuePlanHasChanged(
                noReapprovalRequiredForEndDateChange, originalFunctionalLocation, originalStartDateTime,
                originalEndDateTime, originalJobDescription, originalCSELevel);
        }

        private bool SomethingRequiringReapprovalOfPlanningWorksheetAndRescuePlanHasChanged(
            bool noReapprovalRequiredForEndDateChange,
            FunctionalLocation originalFunctionalLocation,
            DateTime originalStartDateTime,
            DateTime originalEndDateTime,
            string originalJobDescription,
            string originalCSELevel)
        {
            if (SomethingRequiringReapprovalOfTheEntireFormHasChanged(originalFunctionalLocation))
            {
                return true;
            }

            var cseLevelHasChangedAndMatters = !Equals(originalCSELevel, CSELevel) &&
                                               ((WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(CSELevel) ||
                                                 WorkPermitEdmonton.ConfinedSpaceLevel2.Equals(CSELevel)) &&
                                                !Equals(WorkPermitEdmonton.ConfinedSpaceLevel3, originalCSELevel));

            var startDateTimeHasChanged = !Equals(originalStartDateTime, FromDateTime) &&
                                          ((WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(CSELevel) ||
                                            WorkPermitEdmonton.ConfinedSpaceLevel2.Equals(CSELevel)) &&
                                           !Equals(WorkPermitEdmonton.ConfinedSpaceLevel3, originalCSELevel));
            var endDateTimeHasChanged = !Equals(originalEndDateTime, ToDateTime) &&
                                        ((WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(CSELevel) ||
                                          WorkPermitEdmonton.ConfinedSpaceLevel2.Equals(CSELevel)) &&
                                         !Equals(WorkPermitEdmonton.ConfinedSpaceLevel3, originalCSELevel));
            var jobDescriptionHasChanged = !Equals(originalJobDescription, JobDescription);

            var onlyEndDateChanged = !startDateTimeHasChanged && endDateTimeHasChanged;

            if (noReapprovalRequiredForEndDateChange && onlyEndDateChanged)
            {
                return false;
            }

            return startDateTimeHasChanged || endDateTimeHasChanged || jobDescriptionHasChanged ||
                   cseLevelHasChangedAndMatters;
        }

        public bool PlanningWorksheetWillNeedReapproval(User currentUser,
            string originalPlanningWorksheetPlainTextContent)
        {
            if (!ThereAreCurrentlyPlanningWorksheetApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return !Equals(originalPlanningWorksheetPlainTextContent, PlanningWorksheetPlainTextContent);
        }

        public bool RescuePlanWillNeedReapproval(User currentUser, string originalRescuePlanPlainTextContent)
        {
            if (!ThereAreCurrentlyRescuePlanApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return !Equals(originalRescuePlanPlainTextContent, RescuePlanPlainTextContent);
        }

        public bool SomethingRequiringReapprovalHasChanged(
            bool noReapprovalRequiredForEndDateChange,
            FunctionalLocation originalFunctionalLocation,
            DateTime originalStartDateTime,
            DateTime originalEndDateTime,
            string originalCSELevel,
            string originalJobDescription,
            string originalPlanningWorksheetPlainTextContent,
            string originalRescuePlanPlainTextContent)
        {
            var flocHasChanged = originalFunctionalLocation.IdValue != FunctionalLocation.IdValue;
            var startDateTimeHasChanged = !Equals(originalStartDateTime, FromDateTime);
            var endDateTimeHasChanged = !Equals(originalEndDateTime, ToDateTime);
            var cseLevelHasChanged = !Equals(originalCSELevel, CSELevel);
            var jobDescriptionHasChanged = !Equals(originalJobDescription, JobDescription);
            var planningWorksheetContentHasChanged =
                !Equals(originalPlanningWorksheetPlainTextContent, PlanningWorksheetPlainTextContent);
            var rescuePlanContentHasChanged = !Equals(originalRescuePlanPlainTextContent, RescuePlanPlainTextContent);

            if (noReapprovalRequiredForEndDateChange &&
                OnlyEndDateChanged(flocHasChanged, startDateTimeHasChanged, endDateTimeHasChanged, cseLevelHasChanged,
                    jobDescriptionHasChanged, planningWorksheetContentHasChanged, rescuePlanContentHasChanged))
            {
                return false;
            }

            if (CSELevel.Equals(WorkPermitEdmonton.ConfinedSpaceLevel3))
            {
                return flocHasChanged;
            }

            return flocHasChanged || startDateTimeHasChanged || endDateTimeHasChanged || cseLevelHasChanged ||
                   jobDescriptionHasChanged || planningWorksheetContentHasChanged || rescuePlanContentHasChanged;
        }

        private bool OnlyEndDateChanged(
            bool flocHasChanged,
            bool startDateTimeHasChanged,
            bool endDateTimeHasChanged,
            bool cseLevelHasChanged,
            bool jobDescriptionHasChanged,
            bool planningWorksheetContentHasChanged,
            bool rescuePlanContentHasChanged)
        {
            return !flocHasChanged &&
                   !startDateTimeHasChanged &&
                   endDateTimeHasChanged &&
                   !cseLevelHasChanged &&
                   !jobDescriptionHasChanged &&
                   !planningWorksheetContentHasChanged &&
                   !rescuePlanContentHasChanged;
        }

        public bool HasAtLeastOneApproval()
        {
            if (IsApproved())
            {
                return true;
            }

            return AllApprovals.Exists(ap => ap.Enabled && ap.IsApproved) || TradeChecklists.Exists(tc => tc.IsApproved);
        }

        protected override bool ThereAreCurrentlyApprovalsByOtherPeople(User currentUser)
        {
            var otherApprovals = false;

            if (CSELevel != WorkPermitEdmonton.ConfinedSpaceLevel3)
            {
                otherApprovals |= FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(AllApprovals, currentUser);
            }

            otherApprovals |= TradeChecklists.Exists(tc => tc.HasApprovalByOtherPeople(currentUser));

            return otherApprovals;
        }

        private bool ThereAreCurrentlyPlanningWorksheetOrRescuePlanApprovalsByOtherPeople(User currentUser)
        {
            return FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(AllApprovals, currentUser);
        }

        private bool ThereAreCurrentlyPlanningWorksheetApprovalsByOtherPeople(User currentUser)
        {
            return FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(PlanningWorksheetApprovals, currentUser);
        }

        private bool ThereAreCurrentlyRescuePlanApprovalsByOtherPeople(User currentUser)
        {
            return FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(RescuePlanApprovals, currentUser);
        }

        public override bool AllApprovalsAreIn()
        {
            if (CSELevel != WorkPermitEdmonton.ConfinedSpaceLevel3)
            {
                return FormApproval.AllApprovalsAreIn(AllApprovals) && TradeChecklists.TrueForAll(tc => tc.IsApproved);
            }

            return true;
        }

        protected override string GetApprovalsSnapshot()
        {
            throw new NotImplementedException("Not used because there are multiple approval fields for GN1");
        }

        public FormGN1History TakeSnapshot()
        {
            return new FormGN1History(
                IdValue,
                FormStatus,
                FunctionalLocation.FullHierarchy,
                Location,
                CSELevel,
                JobDescription,
                FromDateTime,
                ToDateTime,
                PlanningWorksheetPlainTextContent,
                RescuePlanPlainTextContent,
                TradeChecklist.BuildHistoryString(TradeChecklists),
                FormApproval.GetApprovalsSnapshot(PlanningWorksheetApprovals),
                FormApproval.GetApprovalsSnapshot(RescuePlanApprovals),
                TradeChecklist.BuildApprovalsHistoryString(TradeChecklists),
                DocumentLinks.AsString(link => link.TitleWithUrl),
                LastModifiedBy,
                LastModifiedDateTime,
                ClosedDateTime,
                ApprovedDateTime);
        }

        public override void ConvertToClone(User createdByUser)
        {
            base.ConvertToClone(createdByUser);

            TradeChecklists.ForEach(tc => tc.ConvertToClone(createdByUser));

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            RescuePlanApprovals.ForEach(rca => rca.Unapprove());
            PlanningWorksheetApprovals.ForEach(pwa => pwa.Unapprove());

            TradeChecklists.ForEach(cl => cl.ParentFormNumber = null);
        }

        protected override List<string> RemainingApprovalsAsStringList()
        {
            var remainingApprovalList = new List<string>();

            if (WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(CSELevel))
                return remainingApprovalList;

            remainingApprovalList.AddRange(base.RemainingApprovalsAsStringList());

            foreach (var tradeChecklist in TradeChecklists)
            {
                if (!tradeChecklist.ConstFieldMaintCoordApproval)
                {
                    AddApprovalIfNotInList(remainingApprovalList, ConstFieldMaintCoordApprovalName);
                }

                if (!tradeChecklist.AreaManagerApproval)
                {
                    AddApprovalIfNotInList(remainingApprovalList, AreaManagerApprovalName);
                }

                if (!tradeChecklist.OpsCoordApproval)
                {
                    AddApprovalIfNotInList(remainingApprovalList, OpsCoordApprovalName);
                }
            }

            return remainingApprovalList;
        }

        private void AddApprovalIfNotInList(List<string> approvalList, string approval)
        {
            if (!approvalList.Contains(approval))
            {
                approvalList.Add(approval);
            }
        }
    }
}
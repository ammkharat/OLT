using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class LubesCsdForm : BaseEdmontonForm, IDocumentLinksObject
    {
        public LubesCsdForm(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime)            //ayman generic forms  disable siteid
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();

            IsTheCSDForAPressureSafetyValve = null;

            Approvals = new List<FormApproval>
            {
                new FormApproval(null, id, "Lead Tech", null, null, null, 1),
                new FormApproval(null, id, "Area Team Lead/Supervisor", null, null, null, 2),
                new FormApproval(null,
                    id,
                    "Process Engineer (Pressure Relief System defeated)",
                    null,
                    null,
                    null,
                    3,
                    ApprovalShouldBeEnabledBehaviour.LubesCsdPressureSafetyValve,
                    false),
                new FormApproval(null,
                    id,
                    "Director of Production (> 7 Days)",
                    null,
                    null,
                    null,
                    4,
                    ApprovalShouldBeEnabledBehaviour.SevenDayValidity,
                    false)
            };
        }

        public FunctionalLocation FunctionalLocation { get; set; }

        public string Location { get; set; }

        public bool? IsTheCSDForAPressureSafetyValve { get; set; }

        public string CriticalSystemDefeated { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.LubesCsd; }
        }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public bool HasBeenApproved { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new LubesCsdFormDTO(IdValue,
                FunctionalLocation.FullHierarchy,
                CriticalSystemDefeated,
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                ApprovedDateTime,
                ClosedDateTime,
                RemainingApprovalsAsStringList(),
                HasBeenApproved,
                LastModifiedBy.FullNameWithUserName,
                CriticalSystemDefeated);
        }

        public override void SetDefaultDatesBasedOnShift(bool isDayShift, Date currentDate, Time currentTime)
        {
            var userShift = WorkPermitLubes.UserShift(Clock.Now);

            FromDateTime = userShift.StartDateTime;
            ToDateTime = userShift.EndDateTime;
        }

        public override void ConvertToClone(User createdByUser)
        {
            base.ConvertToClone(createdByUser);
            HasBeenApproved = false;
        }

        public bool IsActiveAndRequiresApproval(DateTime now)
        {
            return FromDateTime < now && ToDateTime > now && FormStatus == FormStatus.Draft;
        }

        public LubesCsdFormHistory TakeSnapshot()
        {
            var approvals = GetApprovalsSnapshot();
            return new LubesCsdFormHistory(IdValue,
                FormStatus,
                FunctionalLocation.FullHierarchy,
                Location,
                PlainTextContent,
                FromDateTime,
                ToDateTime,
                approvals,
                LastModifiedBy,
                LastModifiedDateTime,
                ApprovedDateTime,
                ClosedDateTime,
                IsTheCSDForAPressureSafetyValve,
                CriticalSystemDefeated,
                DocumentLinks.AsString(link => link.TitleWithUrl));
        }

        public override void MarkAsApproved(DateTime? approvedDateTime)
        {
            base.MarkAsApproved(approvedDateTime);
            HasBeenApproved = true;
        }

        public bool WillNeedReapproval(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            FunctionalLocation originalFloc,
            string originalLocationText,
            User user,
            bool userCanChangeValidToWithoutReApproval,
            bool? originalCsdAnswer,
            string originalCriticalSystemDefeated)
        {
            var thereAreCurrentlyApprovalsByOtherPeople = ThereAreCurrentlyApprovalsByOtherPeople(user);
            if (!thereAreCurrentlyApprovalsByOtherPeople)
            {
                return false;
            }

            return SomethingRequiringReapprovalHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFloc,
                originalLocationText,
                userCanChangeValidToWithoutReApproval,
                originalCsdAnswer,
                originalCriticalSystemDefeated);
        }

        public bool SomethingRequiringReapprovalHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            FunctionalLocation originalFloc,
            string originalLocationText,
            bool userCanChangeValidToWithoutReApproval,
            bool? originalCsdAnswer,
            string originalCriticalSystemDefeated)
        {
            var aMainValueHasChanged = AMainValueHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFloc, 
                originalLocationText,
                userCanChangeValidToWithoutReApproval);
            var pressureSafetyValveAnswerChanged = originalCsdAnswer != IsTheCSDForAPressureSafetyValve;
            var criticalSystemDefeatedChanged = originalCriticalSystemDefeated != CriticalSystemDefeated;

            return aMainValueHasChanged || pressureSafetyValveAnswerChanged || criticalSystemDefeatedChanged;
        }

        private bool AMainValueHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            FunctionalLocation originalFloc,
            string originalLocationText,
            bool userCanChangeValidToWithoutReApproval)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            if (userCanChangeValidToWithoutReApproval)
            {
                validToChanged = false;
            }

            var flocChanged = originalFloc.FullHierarchyWithDescription !=
                              FunctionalLocation.FullHierarchyWithDescription;

            var locationTextChanged = originalLocationText != Location;

            return (contentChanged || validFromChanged || validToChanged || flocChanged || locationTextChanged);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForASingleFloc(siteIdOfClient, fullHierarchies, FunctionalLocation);
        }
    }
}
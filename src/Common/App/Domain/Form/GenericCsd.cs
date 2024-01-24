using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class GenericCsd : BaseEdmontonForm, IDocumentLinksObject
    {
        public GenericCsd(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime)       //ayman generic forms remove siteid
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();

            FunctionalLocations = new List<FunctionalLocation>();

            Approvals = new List<FormApproval>
            {
                new FormApproval(null, id, "Technicien de Procédé", null, null, null, 1),
                new FormApproval(null, id, "Coordonnateur de l'Opération / Superviseur de Quart", null, null, null, 2),
                new FormApproval(null,
                    id,
                    "Manager Opération (pour toutes les soupapes)",
                    null,
                    null,
                    null,
                    3,
                    ApprovalShouldBeEnabledBehaviour.MontrealCsdPressureSafetyValve,
                    false),
                new FormApproval(null,
                    id,
                    "Manager Opération (> 72 heures)",
                    null,
                    null,
                    null,
                    4,
                    ApprovalShouldBeEnabledBehaviour.ThreeDayValidityNoPressureSafetyValue,
                    false),
                new FormApproval(null,
                    id,
                    "Directeur des Opérations (pour toutes les soupapes > 5 journées)",
                    null,
                    null,
                    null,
                    5,
                    ApprovalShouldBeEnabledBehaviour.MontrealCsdPressureSafetyValveAndFiveDays,
                    false)
            };
        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public bool? HasBeenCommunicated { get; set; }
        public bool? HasAttachments { get; set; }
        public string CsdReason { get; set; }
        public bool? IsTheCSDForAPressureSafetyValve { get; set; }

        public string CriticalSystemDefeated { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.MontrealCsd; }
        }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public bool HasBeenApproved { get; set; }

        public bool IsClosedAndNeverApproved
        {
            get { return FormStatus == FormStatus.Closed && !HasBeenApproved; }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new MontrealCsdDTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
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
                LastModifiedBy.FullNameWithUserName,
                HasBeenApproved);
        }

        public override void SetDefaultDatesBasedOnShift(bool isDayShift, Date currentDate, Time currentTime)
        {
            var userShift = PermitRequestMontreal.UserShift(Clock.Now);

            FromDateTime = userShift.StartDateTime;
            ToDateTime = userShift.EndDateTime;
        }


        public override void MarkAsApproved(DateTime? approvedDateTime)
        {
            base.MarkAsApproved(approvedDateTime);
            HasBeenApproved = true;
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

        public GenericCsdHistory TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var approvals = GetApprovalsSnapshot();
            return new GenericCsdHistory(IdValue,
                FormStatus,
                flocListString,
                PlainTextContent,
                FromDateTime,
                ToDateTime,
                approvals,
                LastModifiedBy,
                LastModifiedDateTime,
                ApprovedDateTime,
                ClosedDateTime,
                HasBeenCommunicated,
                HasAttachments,
                CsdReason,
                IsTheCSDForAPressureSafetyValve,
                CriticalSystemDefeated,
                DocumentLinks.AsString(link => link.TitleWithUrl));
        }

        public bool WillNeedReapproval(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs,
            User user,
            bool? originalHasAttachments,
            bool? originalHasBeenCommunicated,
            string originalCsdReason,
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
                originalFlocs,
                user,
                originalHasBeenCommunicated,
                originalHasAttachments,
                originalCsdReason,
                originalCsdAnswer,
                originalCriticalSystemDefeated);
        }

        public bool SomethingRequiringReapprovalHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            List<FunctionalLocation> originalFlocs,
            User user,
            bool? originalHasBeenCommunicated,
            bool? originalHasAttachments,
            string originalCsdReason,
            bool? originalCsdAnswer,
            string originalCriticalSystemDefeated)
        {
            var aMainValueHasChanged = AMainValueHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalFlocs);
            var pressureSafetyValveAnswerChanged = originalCsdAnswer != IsTheCSDForAPressureSafetyValve;
            var originalHasBeenCommunicatedChanged = originalHasBeenCommunicated != HasBeenCommunicated;
            var originalHasAttachmentsChanged = originalHasAttachments != HasAttachments;
            var originalCsdReasonChanged = originalCsdReason != CsdReason;
            var criticalSystemDefeatedChanged = originalCriticalSystemDefeated != CriticalSystemDefeated;

            return aMainValueHasChanged || pressureSafetyValveAnswerChanged || originalHasBeenCommunicatedChanged ||
                   originalHasAttachmentsChanged || originalCsdReasonChanged ||
                   criticalSystemDefeatedChanged;
        }

        private bool AMainValueHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            List<FunctionalLocation> originalFlocs)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);

            return (contentChanged || validFromChanged || flocsChanged);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }
    }
}
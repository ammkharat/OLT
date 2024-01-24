using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN24 : BaseEdmontonForm, IDocumentLinksObject
    {
        public FormGN24(long? id, FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime,
            User createdBy, DateTime createdDateTime, long siteid)          //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime) 
        {
            DocumentLinks = new List<DocumentLink>();

            Approvals = new List<FormApproval>
            {
                new FormApproval(null, id, "Maintenance Coordinator", null, null, null, 1),
                new FormApproval(null, id, "Operations Coordinator", null, null, null, 2),
                new FormApproval(null, id, "Area Operations Manager", null, null, null, 3),
                new FormApproval(null, id, "Maintenance Director", null, null, null, 4),
                new FormApproval(null, id, "Operations Director", null, null, null, 5)
            };

            FunctionalLocations = new List<FunctionalLocation>();
        }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.GN24; }
        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public bool IsTheSafeWorkPlanForPSVRemovalOrInstallation { get; set; }

        public bool IsTheSafeWorkPlanForWorkInTheAlkylationUnit { get; set; }

        public FormGN24AlkylationClass AlkylationClass { get; set; }

        //ayman generic forms
        public long SiteId { get; set; }

        public string PreJobMeetingSignatures { get; set; }
        public string PlainTextPreJobMeetingSignatures { get; set; }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            var dto = new FormEdmontonGN24DTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                FormType,
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                LastModifiedDateTime,
                FromDateTime,
                ToDateTime,
                IsTheSafeWorkPlanForPSVRemovalOrInstallation,
                FormStatus,
                ApprovedDateTime,
                ClosedDateTime,
                RemainingApprovalsAsStringList());

            return dto;
        }

        public FormGN24History TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var approvals = GetApprovalsSnapshot();
            return new FormGN24History(IdValue,
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
                IsTheSafeWorkPlanForPSVRemovalOrInstallation,
                IsTheSafeWorkPlanForWorkInTheAlkylationUnit,
                AlkylationClass,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                PlainTextPreJobMeetingSignatures);
        }

        public bool WillNeedReapproval(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs,
            List<DocumentLink> originalDocumentLinks,
            bool originalIsTheSafeWorkPlanForPsvRemovalOrInstallation,
            bool originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit,
            FormGN24AlkylationClass originalAlkylationClass,
            User currentUser,
            bool noReapprovalRequiredForEndDateChange)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return SomethingRequiringReapprovalHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFlocs,
                originalDocumentLinks,
                originalIsTheSafeWorkPlanForPsvRemovalOrInstallation,
                originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit,
                originalAlkylationClass,
                currentUser,
                noReapprovalRequiredForEndDateChange);
        }

        public bool SomethingRequiringReapprovalHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs,
            List<DocumentLink> originalDocumentLinks,
            bool originalIsTheSafeWorkPlanForPsvRemovalOrInstallation,
            bool originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit,
            FormGN24AlkylationClass originalAlkylationClass,
            User currentUser,
            bool noReapprovalRequiredForEndDateChange)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);
            var isTheSafeWorkPlanForPSVRemovalOrInstallationHasChanged = IsTheSafeWorkPlanForPSVRemovalOrInstallation !=
                                                                         originalIsTheSafeWorkPlanForPsvRemovalOrInstallation;
            var isTheSafeWorkPlanForWorkInTheAlkylationUnitHasChanged = IsTheSafeWorkPlanForWorkInTheAlkylationUnit !=
                                                                        originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit;
            var alkylationClassHasChanged = AlkylationClass != originalAlkylationClass;
            var documentLinksHaveChanged = !DocumentLinks.EqualsByElement(originalDocumentLinks);

            if (noReapprovalRequiredForEndDateChange &&
                OnlyEndDateChanged(contentChanged,
                    validFromChanged,
                    validToChanged,
                    flocsChanged,
                    isTheSafeWorkPlanForPSVRemovalOrInstallationHasChanged,
                    isTheSafeWorkPlanForWorkInTheAlkylationUnitHasChanged,
                    alkylationClassHasChanged,
                    documentLinksHaveChanged)
                )
            {
                return false;
            }

            return contentChanged || validFromChanged || validToChanged || flocsChanged ||
                   isTheSafeWorkPlanForPSVRemovalOrInstallationHasChanged ||
                   isTheSafeWorkPlanForWorkInTheAlkylationUnitHasChanged || alkylationClassHasChanged ||
                   documentLinksHaveChanged;
        }

        private bool OnlyEndDateChanged(bool contentChanged,
            bool validFromChanged,
            bool validToChanged,
            bool flocsChanged,
            bool isTheSafeWorkPlanForPSVRemovalOrInstallationHasChanged,
            bool isTheSafeWorkPlanForWorkInTheAlkylationUnitHasChanged,
            bool alkylationClassHasChanged,
            bool documentLinksHaveChanged)
        {
            return !contentChanged &&
                   !validFromChanged &&
                   !flocsChanged &&
                   validToChanged &&
                   !isTheSafeWorkPlanForPSVRemovalOrInstallationHasChanged &&
                   !isTheSafeWorkPlanForWorkInTheAlkylationUnitHasChanged &&
                   !alkylationClassHasChanged &&
                   !documentLinksHaveChanged;
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }

        public override void ConvertToClone(User createdByUser)
        {
            base.ConvertToClone(createdByUser);

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());
        }
    }
}
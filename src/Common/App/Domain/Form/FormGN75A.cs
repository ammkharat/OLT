using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN75A : BaseEdmontonForm, IDocumentLinksObject
    {
        public FormGN75A(long? id, FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime,
            User createdBy, DateTime createdDateTime, long siteid)             //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)  
        {
            DocumentLinks = new List<DocumentLink>();

            Approvals = new List<FormApproval>
            {
                new FormApproval(null, id, "Maintenance Coordinator / Supervisor", null, null, null, 1),
                new FormApproval(null, id, "Manager Area Ops / Operations Coordinator / Shift Supervisor", null, null,
                    null, 2),
                new FormApproval(null, id, "Engineer (PEng req'd only for GN75 5.1 Applications)", null, null, null, 3),
            };
        }

        public FunctionalLocation FunctionalLocation { get; set; }

        public string Content { get; set; }

        public string PlainTextContent { get; set; }

        //ayman generic forms
        public long SiteId { get; set; }

        public long? AssociatedFormGN75BNumber { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.GN75A; }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            var dto = new FormEdmontonGN75ADTO(
                IdValue,
                FunctionalLocation.FullHierarchy,
                FormType,
                AssociatedFormGN75BNumber,
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

            return dto;
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForASingleFloc(siteIdOfClient, fullHierarchies, FunctionalLocation);
        }

        public void ConvertToClone(User createdByUser, FormEdmontonGN75BDTO associatedGN75BDto)
        {
            if (associatedGN75BDto == null || FormStatus.Closed.Equals(associatedGN75BDto.Status) ||
                associatedGN75BDto.Deleted)
            {
                AssociatedFormGN75BNumber = null;
            }

            base.ConvertToClone(createdByUser);

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());
        }

        public override void ConvertToClone(User createdByUser)
        {
            throw new NotImplementedException();
        }

        public FormGN75AHistory TakeSnapshot()
        {
            var approvals = GetApprovalsSnapshot();
            return new FormGN75AHistory(
                IdValue, FunctionalLocation.FullHierarchy, PlainTextContent, AssociatedFormGN75BNumber,
                DocumentLinks.AsString(link => link.TitleWithUrl), ClosedDateTime, ApprovedDateTime, FormStatus,
                FromDateTime, ToDateTime, approvals, LastModifiedBy, LastModifiedDateTime);
        }

        public bool WillNeedReapproval(User currentUser, bool noReapprovalRequiredForEndDateChange,
            FunctionalLocation originalFloc, DateTime originalFromDateTime, DateTime originalToDateTime,
            string originalPlainTextContent, long? originalGn75BAssociationId, List<DocumentLink> originalDocumentLinks)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return SomethingRequiringReapprovalHasChanged(noReapprovalRequiredForEndDateChange, originalFloc,
                originalFromDateTime, originalToDateTime, originalPlainTextContent, originalGn75BAssociationId,
                originalDocumentLinks);
        }

        public bool SomethingRequiringReapprovalHasChanged(bool noReapprovalRequiredForEndDateChange,
            FunctionalLocation originalFloc, DateTime originalFromDateTime, DateTime originalToDateTime,
            string originalPlainTextContent,
            long? originalGn75BAssociationId, List<DocumentLink> originalDocumentLinks)
        {
            var flocChanged = originalFloc.IdValue != FunctionalLocation.IdValue;
            var fromDateTimeChanged = originalFromDateTime != FromDateTime;
            var toDateTimeChanged = originalToDateTime != ToDateTime;
            var contentChanged = !Equals(originalPlainTextContent, PlainTextContent);
            var gn75BAssociationChanged = originalGn75BAssociationId != AssociatedFormGN75BNumber;
            var documentLinksChanged = !DocumentLinks.EqualsByElement(originalDocumentLinks);

            if (noReapprovalRequiredForEndDateChange &&
                OnlyEndDateChanged(flocChanged, fromDateTimeChanged, toDateTimeChanged, contentChanged,
                    gn75BAssociationChanged, documentLinksChanged))
            {
                return false;
            }

            return flocChanged || fromDateTimeChanged || toDateTimeChanged || contentChanged || gn75BAssociationChanged ||
                   documentLinksChanged;
        }

        private bool OnlyEndDateChanged(bool flocsChanged, bool fromDateTimeChanged, bool toDateTimeChanged,
            bool contentChanged, bool gn75AssociationChanged, bool documentLinksChanged)
        {
            return !contentChanged &&
                   !fromDateTimeChanged &&
                   toDateTimeChanged &&
                   !flocsChanged &&
                   !gn75AssociationChanged &&
                   !documentLinksChanged;
        }
    }
}
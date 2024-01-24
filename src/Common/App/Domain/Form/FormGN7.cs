using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN7 : BaseEdmontonForm, IDocumentLinksObject
    {
        public FormGN7(long? id, FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime,
            User createdBy, DateTime createdDateTime, long siteid)                 //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)   
        {
            DocumentLinks = new List<DocumentLink>();
            FunctionalLocations = new List<FunctionalLocation>();
            Approvals = new List<FormApproval>
            {
                new FormApproval(null, id, "Shift Supervisor or EH&S Advisor", null, null, null, 1)
            };
        }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.GN7; }
        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        //ayman generic forms
        public long SiteId { get; set; }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new FormEdmontonDTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                FormType,
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                ApprovedDateTime,
                ClosedDateTime,
                RemainingApprovalsAsStringList());
        }

        public FormGN7History TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);

            var approvals = GetApprovalsSnapshot();

            return new FormGN7History(IdValue,
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
                DocumentLinks.AsString(link => link.TitleWithUrl));
        }

        public bool WillNeedReapproval(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs,
            User currentUser)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return AValueHasChanged(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime,
                originalFlocs);
        }

        protected bool OnlyEndDateChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);

            return !contentChanged && !validFromChanged && !flocsChanged && validToChanged;
        }

        protected bool AValueHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);

            return (contentChanged || validFromChanged || validToChanged || flocsChanged);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }
    }
}
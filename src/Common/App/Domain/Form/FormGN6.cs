using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN6 : BaseEdmontonForm, IDocumentLinksObject
    {
        private const string ElectricalApprover = "Electrical Maintenance Rep (Section 3 Reviewed By)";

        public FormGN6(long? id, FormStatus formStatus, DateTime validFromDateTime, DateTime validToDateTime,
            User createdBy, DateTime createdDateTime, long siteid)          //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime) 
        {
            DocumentLinks = new List<DocumentLink>();

            Approvals = new List<FormApproval>
            {
                CreateElectricalRepFormApproval(id),
                new FormApproval(null, id, "Maintenance / Crane Coordinator", null, null, null, 2)
            };

            FunctionalLocations = new List<FunctionalLocation>();
        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.GN6; }
        }

        public string JobDescription { get; set; }
        public string ReasonForCriticalLift { get; set; }

        public string Section1Content { get; set; }
        public string Section1PlainTextContent { get; set; }
        public bool Section1NotApplicableToJob { get; set; }

        public long SiteId { get; set; }    //ayman generic forms

        public string Section2Content { get; set; }
        public string Section2PlainTextContent { get; set; }
        public bool Section2NotApplicableToJob { get; set; }

        public string Section3Content { get; set; }
        public string Section3PlainTextContent { get; set; }
        public bool Section3NotApplicableToJob { get; set; }

        public string Section4Content { get; set; }
        public string Section4PlainTextContent { get; set; }
        public bool Section4NotApplicableToJob { get; set; }

        public string Section5Content { get; set; }
        public string Section5PlainTextContent { get; set; }
        public bool Section5NotApplicableToJob { get; set; }

        public string Section6Content { get; set; }
        public string Section6PlainTextContent { get; set; }
        public bool Section6NotApplicableToJob { get; set; }

        public string WorkerResponsibiltiesTemplateText { get; set; }
        public string PreJobMeetingSignatures { get; set; }
        public string PlainTextPreJobMeetingSignatures { get; set; }

        public List<DocumentLink> DocumentLinks { get; set; }

        public static FormApproval CreateElectricalRepFormApproval(long? formId)
        {
            return new FormApproval(null, formId, ElectricalApprover, null, null, null, 1);
        }

        public static bool IsElectricalRepApproval(FormApproval formApproval)
        {
            return formApproval != null && ElectricalApprover.Equals(formApproval.Approver);
        }

        public override IFormEdmontonDTO CreateDTO()
        {
            var dto = new FormEdmontonGN6DTO(IdValue,
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
                RemainingApprovalsAsStringList(),
                FormEdmontonGN6DTO.GetApplicableSections(Section1NotApplicableToJob, Section2NotApplicableToJob,
                    Section3NotApplicableToJob, Section4NotApplicableToJob, Section5NotApplicableToJob,
                    Section6NotApplicableToJob),
                JobDescription,
                LastModifiedDateTime);

            return dto;
        }

        public FormGN6History TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var approvals = GetApprovalsSnapshot();
            return new FormGN6History(IdValue, FormStatus, flocListString, FromDateTime, ToDateTime, approvals,
                LastModifiedBy, LastModifiedDateTime, ApprovedDateTime, ClosedDateTime, JobDescription,
                ReasonForCriticalLift, Section1PlainTextContent, Section1NotApplicableToJob, Section2PlainTextContent,
                Section2NotApplicableToJob, Section3PlainTextContent, Section3NotApplicableToJob,
                Section4PlainTextContent, Section4NotApplicableToJob, Section5PlainTextContent,
                Section5NotApplicableToJob, Section6PlainTextContent, Section6NotApplicableToJob,
                DocumentLinks.AsString(link => link.TitleWithUrl), PlainTextPreJobMeetingSignatures);
        }

        public bool WillNeedElectricalReapproval(bool originalSection3NotApplicableToJob,
            string originalSection3PlainTextContent, User currentUser)
        {
            var someoneElseHasApprovedTheElectricalBit =
                FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(Approvals.FindAll(IsElectricalRepApproval),
                    currentUser);

            if (!someoneElseHasApprovedTheElectricalBit)
            {
                return false;
            }

            var section3Changed = (originalSection3NotApplicableToJob != Section3NotApplicableToJob) ||
                                  (!Section3NotApplicableToJob &&
                                   (Section3PlainTextContent != originalSection3PlainTextContent));
            return section3Changed;
        }

        public bool WillNeedReapproval(string originalJobDescription, string originalReasonForCriticalLift,
            bool originalSection1NotApplicableToJob, string originalSection1PlainTextContent,
            bool originalSection2NotApplicableToJob, string originalSection2PlainTextContent,
            bool originalSection3NotApplicableToJob, string originalSection3PlainTextContent,
            bool originalSection4NotApplicableToJob, string originalSection4PlainTextContent,
            bool originalSection5NotApplicableToJob, string originalSection5PlainTextContent,
            bool originalSection6NotApplicableToJob, string originalSection6PlainTextContent,
            DateTime originalValidFromDateTime, DateTime originalValidToDateTime, List<FunctionalLocation> originalFlocs,
            List<DocumentLink> originalDocumentLinks, User currentUser, bool noReapprovalRequiredForEndDateChange)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
            {
                return false;
            }

            return SomethingRequiringReapprovalHasChanged(originalJobDescription, originalReasonForCriticalLift,
                originalSection1NotApplicableToJob, originalSection1PlainTextContent,
                originalSection2NotApplicableToJob, originalSection2PlainTextContent, originalSection3NotApplicableToJob,
                originalSection3PlainTextContent, originalSection4NotApplicableToJob, originalSection4PlainTextContent,
                originalSection5NotApplicableToJob, originalSection5PlainTextContent, originalSection6NotApplicableToJob,
                originalSection6PlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs,
                originalDocumentLinks,
                currentUser, noReapprovalRequiredForEndDateChange);
        }

        public bool SomethingRequiringReapprovalHasChanged(string originalJobDescription,
            string originalReasonForCriticalLift,
            bool originalSection1NotApplicableToJob, string originalSection1PlainTextContent,
            bool originalSection2NotApplicableToJob, string originalSection2PlainTextContent,
            bool originalSection3NotApplicableToJob, string originalSection3PlainTextContent,
            bool originalSection4NotApplicableToJob, string originalSection4PlainTextContent,
            bool originalSection5NotApplicableToJob, string originalSection5PlainTextContent,
            bool originalSection6NotApplicableToJob, string originalSection6PlainTextContent,
            DateTime originalValidFromDateTime, DateTime originalValidToDateTime, List<FunctionalLocation> originalFlocs,
            List<DocumentLink> originalDocumentLinks, User currentUser, bool noReapprovalRequiredForEndDateChange)
        {
            var jobDescriptionChanged = originalJobDescription != JobDescription;
            var reasonForCriticalLiftChanged = originalReasonForCriticalLift != ReasonForCriticalLift;
            var section1Changed = (originalSection1NotApplicableToJob != Section1NotApplicableToJob) ||
                                  (!Section1NotApplicableToJob &&
                                   (Section1PlainTextContent != originalSection1PlainTextContent));
            var section2Changed = (originalSection2NotApplicableToJob != Section2NotApplicableToJob) ||
                                  (!Section2NotApplicableToJob &&
                                   (Section2PlainTextContent != originalSection2PlainTextContent));
            var section3Changed = (originalSection3NotApplicableToJob != Section3NotApplicableToJob) ||
                                  (!Section3NotApplicableToJob &&
                                   (Section3PlainTextContent != originalSection3PlainTextContent));
            var section4Changed = (originalSection4NotApplicableToJob != Section4NotApplicableToJob) ||
                                  (!Section4NotApplicableToJob &&
                                   (Section4PlainTextContent != originalSection4PlainTextContent));
            var section5Changed = (originalSection5NotApplicableToJob != Section5NotApplicableToJob) ||
                                  (!Section5NotApplicableToJob &&
                                   (Section5PlainTextContent != originalSection5PlainTextContent));
            var section6Changed = (originalSection6NotApplicableToJob != Section6NotApplicableToJob) ||
                                  (!Section6NotApplicableToJob &&
                                   (Section6PlainTextContent != originalSection6PlainTextContent));
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);
            var documentLinksHaveChanged = !DocumentLinks.EqualsByElement(originalDocumentLinks);

            if (noReapprovalRequiredForEndDateChange &&
                OnlyEndDateChanged(jobDescriptionChanged, reasonForCriticalLiftChanged, section1Changed, section2Changed,
                    section3Changed, section4Changed, section5Changed, section6Changed,
                    validFromChanged, validToChanged, flocsChanged, documentLinksHaveChanged))
            {
                return false;
            }

            return jobDescriptionChanged || reasonForCriticalLiftChanged || section1Changed || section2Changed ||
                   section3Changed || section4Changed || section5Changed || section6Changed || validFromChanged ||
                   validToChanged || flocsChanged || documentLinksHaveChanged;
        }

        protected bool OnlyEndDateChanged(bool jobDescriptionChanged,
            bool reasonForCriticalLiftChanged,
            bool section1Changed,
            bool section2Changed,
            bool section3Changed,
            bool section4Changed,
            bool section5Changed,
            bool section6Changed,
            bool validFromChanged, bool validToChanged, bool flocsChanged, bool documentLinksHaveChanged)
        {
            return !jobDescriptionChanged && !reasonForCriticalLiftChanged && !section1Changed && !section2Changed &&
                   !section3Changed && !section4Changed & !section5Changed && !section6Changed && !validFromChanged &&
                   validToChanged && !flocsChanged && !documentLinksHaveChanged;
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
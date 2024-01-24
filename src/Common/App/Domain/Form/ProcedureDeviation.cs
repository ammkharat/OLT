using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviation : BaseEdmontonForm, IDocumentLinksObject
    {
        public const int DefaultEndDateHoursForImmediateDeviation = 144;
        public const int DefaultEndDateYearsForTemporaryDeviation = 1;

        public ProcedureDeviation(long? id,
            ProcedureDeviationType type,
            DateTime startDateTime,
            DateTime endDateTime,
            FormStatus formStatus,
            User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDateTime, long siteid)            //ayman generic forms
            : base(id, formStatus, startDateTime, endDateTime, createdBy, createdDateTime)            
        {
            Type = type;
            DocumentLinks = new List<DocumentLink>();
            FunctionalLocations = new List<FunctionalLocation>();
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            AffectsToe = false;
            RiskAssessmentAttendee1Type = ProcedureDeviationAttendeeType.OperationsSME;
            RiskAssessmentAttendee2Type = ProcedureDeviationAttendeeType.TechnicalSME;
            RiskAssessmentAttendee3Type = ProcedureDeviationAttendeeType.ShiftSupervisor;
            RiskAssessmentAttendee4Type = ProcedureDeviationAttendeeType.Other;
            RiskAssessmentAnswer1 = false;
            RiskAssessmentAnswer2 = false;
            RiskAssessmentAnswer3 = false;
            RiskAssessmentAnswer4 = false;
            RiskAssessmentAnswer5 = false;
            ImmediateApprovalsApprover1Type = ProcedureDeviationApprovalType.Other;
            ImmediateApprovalsApprover1Title = "Shift Supervisor";
            ImmediateApprovalsApprover2Type = ProcedureDeviationApprovalType.Other;
            ImmediateApprovalsApprover2Title = ProcedureDeviationApprovalType.Other.GetName();
            TemporaryApprovalsApprover1Type = ProcedureDeviationApprovalType.Other;
            TemporaryApprovalsApprover1Title = "Shift Supervisor";
            TemporaryApprovalsApprover2Type = ProcedureDeviationApprovalType.Other;
            TemporaryApprovalsApprover2Title = ProcedureDeviationApprovalType.Other.GetName();
            ImmediateApprovalsApprover1ObtainedVia = ProcedureDeviationApprovalObtainedVia.Email;
            ImmediateApprovalsApprover2ObtainedVia = ProcedureDeviationApprovalObtainedVia.Email;
            TemporaryApprovalsApprover1ObtainedVia = ProcedureDeviationApprovalObtainedVia.Email;
            TemporaryApprovalsApprover2ObtainedVia = ProcedureDeviationApprovalObtainedVia.Email;
        }

        public long SiteId { get; set; }

        public ProcedureDeviationType Type { get; set; }

        public bool PermanentRevisionRequired { get; set; }

        public bool RevertedBackToOriginal { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public string LocationEquipmentNumber { get; set; }

        public int NumberOfExtensions { get; set; } 

        public List<Comment> ReasonsForExtension { get; set; }

        public List<Comment> ReasonsForExtensionSortedByCreatedDate
        {
            get
            {
                return ReasonsForExtension != null
                    ? ReasonsForExtension.OrderBy(comment => comment.CreatedDate).ToList()
                    : null;
            }
        }

        public string OperatingProcedureNumber { get; set; }

        public string OperatingProcedureTitle { get; set; }

        public OperatingProcedureLevel OperatingProcedureLevel { get; set; }

        public string Description { get; set; }
        public string RichTextDescription { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.ProcedureDeviation; }
        }

        public List<CauseDeterminationWhyType> CauseDeterminationCauses { get; set; }

        public string CauseDeterminationCategory
        {
            get
            {
                var commaDelimitedNames = CauseDeterminationCauses != null &&
                                          CauseDeterminationCauses.Count > 0
                    ? string.Join(",",
                        CauseDeterminationCauses.Select(cause => cause.GetCategoryName()))
                    : string.Empty;

                return commaDelimitedNames;
            }
        }

        public string CauseDeterminationComments { get; set; }

        public CorrectiveActionFixDocumentDurationType FixDocumentDurationType { get; set; }

        public bool HasCorrectiveActionIlpNumber
        {
            get { return CorrectiveActionIlpNumber.IsNullOrEmpty() == false; }
        }

        public string CorrectiveActionIlpNumber { get; set; }

        public bool HasCorrectiveActionWorkRequestNumber
        {
            get { return CorrectiveActionWorkRequestNumber.IsNullOrEmpty() == false; }
        }

        public string CorrectiveActionWorkRequestNumber { get; set; }

        public bool HasCorrectiveActionOtherComments
        {
            get { return CorrectiveActionOtherComments.IsNullOrEmpty() == false; }
        }

        public string CorrectiveActionOtherComments { get; set; }

        public bool AffectsToe { get; set; }

        public ProcedureDeviationAttendeeType RiskAssessmentAttendee1Type { get; set; }
        public string RiskAssessmentAttendee1Name { get; set; }
        public ProcedureDeviationAttendeeType RiskAssessmentAttendee2Type { get; set; }
        public string RiskAssessmentAttendee2Name { get; set; }
        public ProcedureDeviationAttendeeType RiskAssessmentAttendee3Type { get; set; }
        public string RiskAssessmentAttendee3Name { get; set; }
        public ProcedureDeviationAttendeeType RiskAssessmentAttendee4Type { get; set; }
        public string RiskAssessmentAttendee4Name { get; set; }

        public bool RiskAssessmentAnswer1 { get; set; }
        public bool RiskAssessmentAnswer2 { get; set; }
        public bool RiskAssessmentAnswer3 { get; set; }
        public bool RiskAssessmentAnswer4 { get; set; }
        public bool RiskAssessmentAnswer5 { get; set; }
        public string RiskAssessmentComments { get; set; }

        public List<ProcedureDeviationFormAttendee> RiskAssessmentAttendees
        {
            get
            {
                var attendees = new List<ProcedureDeviationFormAttendee>();
                var disableAttendees = false;

                var attendee1 = new ProcedureDeviationFormAttendee(Id, RiskAssessmentAttendee1Type,
                    RiskAssessmentAttendee1Name, 1, disableAttendees);

                attendees.Add(attendee1);

                var attendee2 = new ProcedureDeviationFormAttendee(Id, RiskAssessmentAttendee2Type,
                    RiskAssessmentAttendee2Name, 2, disableAttendees);

                attendees.Add(attendee2);

                var attendee3 = new ProcedureDeviationFormAttendee(Id, RiskAssessmentAttendee3Type,
                    RiskAssessmentAttendee3Name, 3, disableAttendees);

                attendees.Add(attendee3);

                var attendee4 = new ProcedureDeviationFormAttendee(Id, RiskAssessmentAttendee4Type,
                    RiskAssessmentAttendee4Name, 4, disableAttendees);

                attendees.Add(attendee4);

                return attendees;
            }
        } 

        public ProcedureDeviationApprovalType ImmediateApprovalsApprover1Type { get; set; }
        public string ImmediateApprovalsApprover1Title { get; set; }
        public string ImmediateApprovalsApprover1Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia ImmediateApprovalsApprover1ObtainedVia { get; set; }
        public DateTime? ImmediateApprovalsApprover1ApprovedDateTime { get; set; }

        public ProcedureDeviationApprovalType ImmediateApprovalsApprover2Type { get; set; }
        public string ImmediateApprovalsApprover2Title { get; set; }
        public string ImmediateApprovalsApprover2Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia ImmediateApprovalsApprover2ObtainedVia { get; set; }
        public DateTime? ImmediateApprovalsApprover2ApprovedDateTime { get; set; }

        public ProcedureDeviationApprovalType TemporaryApprovalsApprover1Type { get; set; }
        public string TemporaryApprovalsApprover1Title { get; set; }
        public string TemporaryApprovalsApprover1Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia TemporaryApprovalsApprover1ObtainedVia { get; set; }
        public DateTime? TemporaryApprovalsApprover1ApprovedDateTime { get; set; }

        public ProcedureDeviationApprovalType TemporaryApprovalsApprover2Type { get; set; }
        public string TemporaryApprovalsApprover2Title { get; set; }
        public string TemporaryApprovalsApprover2Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia TemporaryApprovalsApprover2ObtainedVia { get; set; }
        public DateTime? TemporaryApprovalsApprover2ApprovedDateTime { get; set; }

        public string CancelledBy { get; set; }
        public DateTime? CancelledDateTime { get; set; }
        public string CancelledReason { get; set; }

        public List<ProcedureDeviationFormApproval> ImmediateApprovals
        {
            get
            {
                var immediateApprovals = new List<ProcedureDeviationFormApproval>();
                var stubUser = CreatedBy;
                var disableEditOfImmediateApprovals = Type != ProcedureDeviationType.Immediate;

                var immediateApprover1 = new ProcedureDeviationFormApproval(Id, ImmediateApprovalsApprover1Type,
                    ImmediateApprovalsApprover1Title, ImmediateApprovalsApprover1Name, stubUser,
                    ImmediateApprovalsApprover1ObtainedVia, ImmediateApprovalsApprover1ApprovedDateTime, 1)
                {
                    DisableEdit = disableEditOfImmediateApprovals
                };

                if (ImmediateApprovalsApprover1Name.IsNullOrEmpty())
                {
                    immediateApprover1.Unapprove();
                }
                immediateApprovals.Add(immediateApprover1);

                var immediateApprover2 = new ProcedureDeviationFormApproval(Id, ImmediateApprovalsApprover2Type,
                    ImmediateApprovalsApprover2Title, ImmediateApprovalsApprover2Name, stubUser,
                    ImmediateApprovalsApprover2ObtainedVia, ImmediateApprovalsApprover2ApprovedDateTime, 2)
                {
                    DisableEdit = disableEditOfImmediateApprovals
                };

                if (ImmediateApprovalsApprover2Name.IsNullOrEmpty())
                {
                    immediateApprover2.Unapprove();
                }
                immediateApprovals.Add(immediateApprover2);

                return immediateApprovals;
            }
        }

        public List<ProcedureDeviationFormApproval> TemporaryApprovals
        {
            get
            {
                var temporaryApprovals = new List<ProcedureDeviationFormApproval>();
                var stubUser = CreatedBy;
                var disableEditOfTemporaryApprovals = Type != ProcedureDeviationType.Temporary;

                var temporaryApprover1 = new ProcedureDeviationFormApproval(Id, TemporaryApprovalsApprover1Type,
                    TemporaryApprovalsApprover1Title, TemporaryApprovalsApprover1Name, stubUser,
                    TemporaryApprovalsApprover1ObtainedVia, TemporaryApprovalsApprover1ApprovedDateTime, 1)
                {
                    DisableEdit = disableEditOfTemporaryApprovals
                };

                if (TemporaryApprovalsApprover1Name.IsNullOrEmpty())
                {
                    temporaryApprover1.Unapprove();
                }
                temporaryApprovals.Add(temporaryApprover1);

                var temporaryApprover2 = new ProcedureDeviationFormApproval(Id, TemporaryApprovalsApprover2Type,
                    TemporaryApprovalsApprover2Title, TemporaryApprovalsApprover2Name, stubUser,
                    TemporaryApprovalsApprover2ObtainedVia, TemporaryApprovalsApprover2ApprovedDateTime, 2)
                {
                    DisableEdit = disableEditOfTemporaryApprovals
                };

                if (TemporaryApprovalsApprover2Name.IsNullOrEmpty())
                {
                    temporaryApprover2.Unapprove();
                }
                temporaryApprovals.Add(temporaryApprover2);

                return temporaryApprovals;
            }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public override void ConvertToClone(User createdByUser)
        {
            var now = Clock.Now;

            Id = null;
            CreatedBy = createdByUser;
            CreatedDateTime = now;
            LastModifiedBy = createdByUser;
            LastModifiedDateTime = now;

            FormStatus = FormStatus.Draft;

            ApprovedDateTime = null;
            ClosedDateTime = null;

            AllApprovals.ForEach(approval => approval.Unapprove());
        }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new ProcedureDeviationDTO(IdValue,
                Type,
                PermanentRevisionRequired,
                RevertedBackToOriginal,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                CreatedBy.IdValue,
                CreatedBy.FullName,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                LastModifiedBy.FullNameWithUserName,
                LastModifiedDateTime,
                NumberOfExtensions,
                OperatingProcedureNumber,
                OperatingProcedureTitle,
                OperatingProcedureLevel,
                Description,
                CauseDeterminationCategory,
                CancelledBy,
                CancelledDateTime,
                CancelledReason);
        }

        public ProcedureDeviationHistory TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var reasonsForExtension = ReasonsForExtension != null && ReasonsForExtension.Count > 0
                ? ReasonsForExtension.AsString(reason => reason.Text)
                : null;

            return new ProcedureDeviationHistory(IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                LastModifiedBy,
                LastModifiedDateTime,
                Type,
                PermanentRevisionRequired,
                RevertedBackToOriginal,
                flocListString,
                LocationEquipmentNumber,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                NumberOfExtensions,
                reasonsForExtension,
                OperatingProcedureNumber,
                OperatingProcedureTitle,
                OperatingProcedureLevel,
                Description,
                CauseDeterminationCauses.AsString(cause => cause.GetName()),
                CauseDeterminationCategory,
                CauseDeterminationComments,
                FixDocumentDurationType,
                CorrectiveActionIlpNumber,
                CorrectiveActionWorkRequestNumber,
                CorrectiveActionOtherComments,
                AffectsToe,
                RiskAssessmentAttendee1Type,
                RiskAssessmentAttendee1Name,
                RiskAssessmentAttendee2Type,
                RiskAssessmentAttendee2Name,
                RiskAssessmentAttendee3Type,
                RiskAssessmentAttendee3Name,
                RiskAssessmentAttendee4Type,
                RiskAssessmentAttendee4Name,
                RiskAssessmentAnswer1,
                RiskAssessmentAnswer2,
                RiskAssessmentAnswer3,
                RiskAssessmentAnswer4,
                RiskAssessmentAnswer5,
                RiskAssessmentComments,
                ImmediateApprovalsApprover1Type,
                ImmediateApprovalsApprover1Title,
                ImmediateApprovalsApprover1Name,
                ImmediateApprovalsApprover1ObtainedVia,
                ImmediateApprovalsApprover1ApprovedDateTime,
                ImmediateApprovalsApprover2Type,
                ImmediateApprovalsApprover2Title,
                ImmediateApprovalsApprover2Name,
                ImmediateApprovalsApprover2ObtainedVia,
                ImmediateApprovalsApprover2ApprovedDateTime,
                TemporaryApprovalsApprover1Type,
                TemporaryApprovalsApprover1Title,
                TemporaryApprovalsApprover1Name,
                TemporaryApprovalsApprover1ObtainedVia,
                TemporaryApprovalsApprover1ApprovedDateTime,
                TemporaryApprovalsApprover2Type,
                TemporaryApprovalsApprover2Title,
                TemporaryApprovalsApprover2Name,
                TemporaryApprovalsApprover2ObtainedVia,
                TemporaryApprovalsApprover2ApprovedDateTime,
                CancelledBy,
                CancelledDateTime,
                CancelledReason);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }
    }
}
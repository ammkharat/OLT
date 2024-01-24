using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ProcedureDeviationFormPresenter :
        AbstractFormEdmontonFormPresenter<ProcedureDeviation, IProcedureDeviationFormView>
    {
        private static DateTime defaultEndDateForImmediateDeviation;
        private static DateTime defaultEndDateForTemporaryDeviation;
        private readonly IAuthorized authorized;

        private readonly IContractorService contractorService;
        private readonly IFunctionalLocationService flocService;
        private readonly FormStatus originalStatus;
        private readonly IFormEdmontonService service;
        private bool approvingForm;
        private List<Contractor> contractors;
        private bool notApprovingForm;

        public ProcedureDeviationFormPresenter()
            : this(CreateDefaultForm())
        {
        }

        public ProcedureDeviationFormPresenter(ProcedureDeviation form)
            : base(new ProcedureDeviationForm(), form)
        {
            authorized = new Authorized();
            flocService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.FormLoad += HandleViewLoad;
            view.HistoryClicked += HandleHistoryClicked;
            view.ExpandClicked += HandleExpandClicked;

            view.DeviationTypeChanged += HandleDeviationTypeChanged;

            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.CancelDeviationButtonClicked += HandleCancelDeviationClicked;
            view.ConvertDeviationButtonClicked += HandleConvertDeviationClicked;

            view.CompleteButtonClicked += HandleCompleteClicked;
            view.CompleteAndRevertButtonClicked += HandleCompleteAndRevertClicked;
            view.CompleteAndPermanentRevisionButtonClicked += HandleCompleteAndPermanentRevisionClicked;

            view.ImmediateApprovalSelected += HandleImmediateApprovalSelected;
            view.ImmediateApprovalUnselected += HandleImmediateApprovalUnselected;
            view.TemporaryApprovalSelected += HandleTemporaryApprovalSelected;
            view.TemporaryApprovalUnselected += HandleTemporaryApprovalUnselected;

            originalStatus = form.FormStatus;
        }

        private void HandleConvertDeviationClicked()
        {
            // TODO:

        }

        private void HandleImmediateApprovalSelected(ProcedureDeviationFormApproval approval)
        {
            var user = ClientSession.GetUserContext().User;

            approval.ApprovedByUser = user;
            approval.Approver = user.FullNameWithFirstNameFirst;
            approval.ApprovalDateTime = Clock.Now;
        }

        private void HandleImmediateApprovalUnselected(ProcedureDeviationFormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.Approver = null;
            approval.ApprovalDateTime = null;
        }

        private void HandleTemporaryApprovalSelected(ProcedureDeviationFormApproval approval)
        {
            var user = ClientSession.GetUserContext().User;

            approval.ApprovedByUser = user;
            approval.Approver = user.FullNameWithFirstNameFirst;
            approval.ApprovalDateTime = Clock.Now;
        }

        private void HandleTemporaryApprovalUnselected(ProcedureDeviationFormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.Approver = null;
            approval.ApprovalDateTime = null;
        }

        private void HandleDeviationTypeChanged()
        {
            // If new form and the end date hasn't changed since it was created, 
            // set the default end date for the deviation type selected.
            if (editObject.Id.HasValue == false)
            {
                if (view.ProcedureDeviationType == ProcedureDeviationType.Immediate &&
                    view.ValidTo == defaultEndDateForTemporaryDeviation)
                {
                    view.ValidTo = defaultEndDateForImmediateDeviation;
                }

                if (view.ProcedureDeviationType == ProcedureDeviationType.Temporary &&
                    view.ValidTo == defaultEndDateForImmediateDeviation)
                {
                    view.ValidTo = defaultEndDateForTemporaryDeviation;
                }
            }

            // Allow the user to change the deviation type and enable/disable the approvals accordingly
            if (editObject.FormStatus == FormStatus.Draft)
            {
                editObject.Type = view.ProcedureDeviationType;
                UpdateEditObjectApprovalsFromView();
                SetApprovals();
            }
        }

        protected override void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            if (editObject.FormStatus == FormStatus.DocumentIssued ||
                editObject.FormStatus == FormStatus.DocumentArchived ||
                editObject.FormStatus == FormStatus.NotApproved)
            {
                shouldSkipConfirm = true;
            }

            base.HandleFormClosing(sender, e);
        }

        private void HandleHistoryClicked()
        {
            EditHistoryFormPresenter presenter = new ProcedureDeviationHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private static ProcedureDeviation CreateDefaultForm()
        {
            var now = Clock.Now;
            var context = ClientSession.GetUserContext();
            var currentUser = context.User;

            defaultEndDateForImmediateDeviation =
                context.UserShift.EndDateTime.AddHours(ProcedureDeviation.DefaultEndDateHoursForImmediateDeviation);
            defaultEndDateForTemporaryDeviation =
                context.UserShift.EndDateTime.AddYears(ProcedureDeviation.DefaultEndDateYearsForTemporaryDeviation);

            var startDateTime = context.UserShift.StartDateTime;
            var endDateTime = defaultEndDateForImmediateDeviation;

            var siteid = ClientSession.GetUserContext().SiteId;            //ayman generic forms

            var form = new ProcedureDeviation(null, ProcedureDeviationType.Immediate, startDateTime, endDateTime,
                FormStatus.Draft, currentUser, now,
                currentUser, now, siteid)                     //ayman generic forms
            {
                FromDateTime = startDateTime,
                ToDateTime = endDateTime,
                SiteId = context.SiteId,
                LocationEquipmentNumber = null,
                Type = ProcedureDeviationType.Immediate,
                PermanentRevisionRequired = false,
                RevertedBackToOriginal = false,
                OperatingProcedureNumber = null,
                OperatingProcedureTitle = null,
                NumberOfExtensions = 0,
                ReasonsForExtension = null,
                Description = null,
                CauseDeterminationComments = null,
                CorrectiveActionIlpNumber = null,
                CorrectiveActionWorkRequestNumber = null,
                CorrectiveActionOtherComments = null
            };

            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;

            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.LocationEquipmentNumber = view.LocationEquipmentNumber;
            editObject.DocumentLinks = view.DocumentLinks;

            editObject.Type = view.ProcedureDeviationType;

            editObject.OperatingProcedureNumber = view.OperatingProcedureNumber;
            editObject.OperatingProcedureTitle = view.OperatingProcedureTitle;
            editObject.OperatingProcedureLevel = view.OperatingProcedureLevel;

            editObject.Description = view.PlainTextContent;
            editObject.RichTextDescription = view.Content;

            editObject.CauseDeterminationCauses = view.CauseDeterminationCauses;
            editObject.CauseDeterminationComments = view.CauseDeterminationComments;

            editObject.FixDocumentDurationType = view.FixDocumentDurationType;
            editObject.CorrectiveActionIlpNumber = view.CorrectiveActionIlpNumber;
            editObject.CorrectiveActionWorkRequestNumber = view.CorrectiveActionWorkRequestNumber;
            editObject.CorrectiveActionOtherComments = view.CorrectiveActionOtherComments;

            UpdateEditObjectRiskAssessmentFromView();
            UpdateEditObjectApprovalsFromView();
        }

        private void UpdateEditObjectRiskAssessmentFromView()
        {
            editObject.AffectsToe = view.AffectsToe;

            editObject.RiskAssessmentAnswer1 = view.RiskAssessmentAnswer1;
            editObject.RiskAssessmentAnswer2 = view.RiskAssessmentAnswer2;
            editObject.RiskAssessmentAnswer3 = view.RiskAssessmentAnswer3;
            editObject.RiskAssessmentAnswer4 = view.RiskAssessmentAnswer4;
            editObject.RiskAssessmentAnswer5 = view.RiskAssessmentAnswer5;
            editObject.RiskAssessmentComments = view.RiskAssessmentComments;

            var riskAssessmentAttendees = new List<ProcedureDeviationFormAttendee>(view.RiskAssessmentAttendees);

            var attendee1 = riskAssessmentAttendees.Find(attendee => attendee.DisplayOrder == 1);
            if (attendee1 != null)
            {
                editObject.RiskAssessmentAttendee1Type = attendee1.AttendeeType;
                editObject.RiskAssessmentAttendee1Name = attendee1.AttendeeName;
            }

            var attendee2 = riskAssessmentAttendees.Find(attendee => attendee.DisplayOrder == 2);
            if (attendee2 != null)
            {
                editObject.RiskAssessmentAttendee2Type = attendee2.AttendeeType;
                editObject.RiskAssessmentAttendee2Name = attendee2.AttendeeName;
            }

            var attendee3 = riskAssessmentAttendees.Find(attendee => attendee.DisplayOrder == 3);
            if (attendee3 != null)
            {
                editObject.RiskAssessmentAttendee3Type = attendee3.AttendeeType;
                editObject.RiskAssessmentAttendee3Name = attendee3.AttendeeName;
            }

            var attendee4 = riskAssessmentAttendees.Find(attendee => attendee.DisplayOrder == 4);
            if (attendee4 != null)
            {
                editObject.RiskAssessmentAttendee4Type = attendee4.AttendeeType;
                editObject.RiskAssessmentAttendee4Name = attendee4.AttendeeName;
            }
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            var immediateApprovals = new List<ProcedureDeviationFormApproval>(view.ImmediateApprovals);

            var immediateApprover1 =
                immediateApprovals.Find(approval => approval.WorkAssignmentDisplayName.Equals("Shift Supervisor"));

            if (immediateApprover1 != null)
            {
                editObject.ImmediateApprovalsApprover1Name = immediateApprover1.Approver;
                editObject.ImmediateApprovalsApprover1ObtainedVia = immediateApprover1.ObtainedVia;
                editObject.ImmediateApprovalsApprover1ApprovedDateTime = immediateApprover1.ApprovalDateTime;
            }

            var immediateApprover2 =
                immediateApprovals.Find(
                    approval =>
                        approval.WorkAssignmentDisplayName != null && approval.WorkAssignmentDisplayName.Equals("Other"));

            if (immediateApprover2 != null)
            {
                editObject.ImmediateApprovalsApprover2Name = immediateApprover2.Approver;
                editObject.ImmediateApprovalsApprover2ObtainedVia = immediateApprover2.ObtainedVia;
                editObject.ImmediateApprovalsApprover2ApprovedDateTime = immediateApprover2.ApprovalDateTime;
            }

            var temporaryApprovals = new List<ProcedureDeviationFormApproval>(view.TemporaryApprovals);

            var temporaryApprover1 =
                temporaryApprovals.Find(
                    approval =>
                        approval.WorkAssignmentDisplayName != null &&
                        approval.WorkAssignmentDisplayName.Equals("Shift Supervisor"));

            if (temporaryApprover1 != null)
            {
                editObject.TemporaryApprovalsApprover1Name = temporaryApprover1.Approver;
                editObject.TemporaryApprovalsApprover1ObtainedVia = temporaryApprover1.ObtainedVia;
                editObject.TemporaryApprovalsApprover1ApprovedDateTime = temporaryApprover1.ApprovalDateTime;
            }

            var temporaryApprover2 =
                temporaryApprovals.Find(
                    approval =>
                        approval.WorkAssignmentDisplayName != null && approval.WorkAssignmentDisplayName.Equals("Other"));

            if (temporaryApprover2 != null)
            {
                editObject.TemporaryApprovalsApprover2Name = temporaryApprover2.Approver;
                editObject.TemporaryApprovalsApprover2ObtainedVia = temporaryApprover2.ObtainedVia;
                editObject.TemporaryApprovalsApprover2ApprovedDateTime = temporaryApprover2.ApprovalDateTime;
            }
        }

        protected override void ShowEmail()
        {
            FormProcedureDeviationPagePresenterHelper.ShowEmailForRevisionRequired(editObject);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return false;
        }

        private void UpdateViewFromEditObject()
        {
            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            view.FormStatus = editObject.FormStatus.Name;

            view.ValidFrom = editObject.FromDateTime;
            view.ValidTo = editObject.ToDateTime;

            view.FunctionalLocations = editObject.FunctionalLocations;
            view.LocationEquipmentNumber = editObject.LocationEquipmentNumber;

            view.NumberOfExtensions = editObject.NumberOfExtensions;
            view.ReasonForExtensions = editObject.ReasonsForExtensionSortedByCreatedDate;

            view.DocumentLinks = editObject.DocumentLinks;

            view.ProcedureDeviationType = editObject.Type;
            view.PermanentRevisionRequired = editObject.PermanentRevisionRequired;
            view.RevertedBackToOriginal = editObject.RevertedBackToOriginal;

            view.OperatingProcedureNumber = editObject.OperatingProcedureNumber;
            view.OperatingProcedureTitle = editObject.OperatingProcedureTitle;
            view.OperatingProcedureLevel = editObject.OperatingProcedureLevel;

            view.Content = editObject.RichTextDescription;

            view.CauseDeterminationCauses = editObject.CauseDeterminationCauses;
            view.CauseDeterminationComments = editObject.CauseDeterminationComments;

            view.FixDocumentDurationType = editObject.FixDocumentDurationType;
            view.HasCorrectiveActionIlpNumber = editObject.HasCorrectiveActionIlpNumber;
            view.CorrectiveActionIlpNumber = editObject.CorrectiveActionIlpNumber;
            view.HasCorrectiveActionWorkRequestNumber = editObject.HasCorrectiveActionWorkRequestNumber;
            view.CorrectiveActionWorkRequestNumber = editObject.CorrectiveActionWorkRequestNumber;
            view.HasCorrectiveActionOtherComments = editObject.HasCorrectiveActionOtherComments;
            view.CorrectiveActionOtherComments = editObject.CorrectiveActionOtherComments;

            SetFormButtons();
            SetRiskAssessment();
            SetApprovals();

            view.ProcedureDeviation = editObject;
        }

        private void SetFormButtons()
        {
            var siteId = userContext.SiteId;
            var userRoleElements = userContext.UserRoleElements;
            var canApprove = authorized.ToApproveFormProcedureDeviation(userRoleElements, siteId);
            var canEdit = authorized.ToEditFormProcedureDeviation(userRoleElements, siteId);
            var isImmediateDeviation = editObject.Type == ProcedureDeviationType.Immediate;
            var isTemporaryDeviation = editObject.Type == ProcedureDeviationType.Temporary;

            if (editObject.FormStatus == FormStatus.Draft)
            {
                view.EnableDeviationType = true;
                view.EnableCompleteButton = false;
                view.EnableCancelDeviationButton = false;
                view.EnableSaveAndEmailButton = true;
                view.SaveAndEmailButtonText = @"Save && Send for Revision";
                view.EnableSaveAndCloseButton = true;
            }
            else if (editObject.FormStatus == FormStatus.RevisionInProgress)
            {
                view.EnableDeviationType = true;
                view.EnableCompleteButton = false;
                view.EnableCancelDeviationButton = canApprove;
                view.EnableSaveAndEmailButton = canApprove && isTemporaryDeviation;
                view.SaveAndEmailButtonText = @"Save && Send for Revision";
                view.EnableSaveAndCloseButton = canEdit;
            }
            else if (editObject.FormStatus == FormStatus.Approved)
            {
                view.EnableDeviationType = false;
                view.EnableCompleteButton = canApprove;
                view.EnableCancelDeviationButton = canApprove;
                view.EnableSaveAndEmailButton = canApprove && isImmediateDeviation;
                view.SaveAndEmailButtonText = @"Save && Send for Revision";
                view.EnableSaveAndCloseButton = canEdit;
                view.EnableConvertDeviationButton = isImmediateDeviation;
            }
            else if (editObject.FormStatus == FormStatus.Cancelled)
            {
                view.EnableDeviationType = false;
                view.EnableCompleteButton = false;
                view.EnableCancelDeviationButton = false;
                view.EnableSaveAndEmailButton = false;
                view.EnableSaveAndCloseButton = false;
            }
            else if (editObject.FormStatus == FormStatus.Complete)
            {
                view.EnableDeviationType = false;
                view.EnableCompleteButton = false;
                view.EnableCancelDeviationButton = false;
                view.EnableSaveAndEmailButton = false;
                view.EnableSaveAndCloseButton = false;
            }
        }

        private void SetRiskAssessment()
        {
            view.AffectsToe = editObject.AffectsToe;
            view.RiskAssessmentAttendees = editObject.RiskAssessmentAttendees;

            if (editObject.IsInDatabase())
            {
                view.RiskAssessmentAnswer1 = editObject.RiskAssessmentAnswer1;
                view.RiskAssessmentAnswer2 = editObject.RiskAssessmentAnswer2;
                view.RiskAssessmentAnswer3 = editObject.RiskAssessmentAnswer3;
                view.RiskAssessmentAnswer4 = editObject.RiskAssessmentAnswer4;
                view.RiskAssessmentAnswer5 = editObject.RiskAssessmentAnswer5;
            }
            else
            {
                view.ResetRiskAssessmentAnswers();
            }

            view.RiskAssessmentComments = editObject.RiskAssessmentComments;
        }

        private void SetApprovals()
        {
            var siteId = userContext.SiteId;
            var userRoleElements = userContext.UserRoleElements;
            var canApprove = authorized.ToApproveFormProcedureDeviation(userRoleElements, siteId);

            var isImmediateDeviation = editObject.Type == ProcedureDeviationType.Immediate;
            var isTemporaryDeviation = editObject.Type == ProcedureDeviationType.Temporary;

            var disableEditImmediateApproval =
                !((editObject.FormStatus == FormStatus.Draft || editObject.FormStatus == FormStatus.RevisionInProgress) &&
                  isImmediateDeviation && canApprove);

            var disableEditTemporaryApproval =
                !((editObject.FormStatus == FormStatus.Draft || editObject.FormStatus == FormStatus.RevisionInProgress) &&
                  isTemporaryDeviation && canApprove);

            var immediateApprovals = editObject.ImmediateApprovals;
            foreach (var immediateApproval in immediateApprovals)
            {
                immediateApproval.DisableEdit = disableEditImmediateApproval;
            }
            DisplayOrderHelper.SortAndResetDisplayOrder(immediateApprovals);
            view.ImmediateApprovals = immediateApprovals;

            var temporaryApprovals = editObject.TemporaryApprovals;
            foreach (var temporaryApproval in temporaryApprovals)
            {
                temporaryApproval.DisableEdit = disableEditTemporaryApproval;
            }
            DisplayOrderHelper.SortAndResetDisplayOrder(temporaryApprovals);
            view.TemporaryApprovals = temporaryApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    service.InsertProcedureDeviationForm, editObject);
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                service.UpdateProcedureDeviationForm, editObject);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            Save(false);
        }

        private void HandleSaveAndEmailClicked()
        {
            approvingForm = true;

            Save(true);
        }

        private void Save(bool showEmail)
        {
            if (Validate())
            {
                return;
            }

            if (!UpdateNumberOfExtensionsAndReasonIfEndDateChanged()) return;

            UpdateEditObjectFromView();

            UpdateEditObjectFormStatus();

            SaveOrUpdate(true);

            if (showEmail)
            {
                ShowEmail();
            }
        }

        private bool UpdateNumberOfExtensionsAndReasonIfEndDateChanged()
        {
            if (editObject.FormStatus != FormStatus.Draft && editObject.ToDateTime < view.ValidTo)
            {
                string userReason;
                var result = OltPromptMessageBox.Show(view as Form,
                    "Enter a reason for extending the end date of this form:",
                    "Reason for Extension", MessageBoxIcon.Exclamation, out userReason);

                if (result != DialogResult.OK && result != DialogResult.Yes) return false;

                var reasonForExtension = userReason.IsNullOrEmpty()
                    ? "Reason not provided"
                    : userReason.Replace(Environment.NewLine, " ");

                editObject.NumberOfExtensions++;
                reasonForExtension = editObject.NumberOfExtensions + ". " + reasonForExtension;

                if (editObject.ReasonsForExtension == null)
                {
                    editObject.ReasonsForExtension = new List<Comment>();
                }
                editObject.ReasonsForExtension.Add(new Comment(userContext.User, Clock.Now, reasonForExtension));
            }

            return true;
        }

        private void HandleCancelDeviationClicked()
        {
            notApprovingForm = true;

            if (Validate())
            {
                return;
            }

            if (!UpdateEditObjectWithCancelledFormStatus()) return;

            UpdateEditObjectFromView();

            SaveOrUpdate(true);
        }

        private void HandleCompleteAndPermanentRevisionClicked()
        {
            notApprovingForm = true;

            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            editObject.FormStatus = FormStatus.Complete;
            editObject.PermanentRevisionRequired = true;

            SaveOrUpdate(true);

            // TODO: launch new Document Suggestion eForm
        }

        private void HandleCompleteAndRevertClicked()
        {
            notApprovingForm = true;

            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            editObject.FormStatus = FormStatus.Complete;
            editObject.RevertedBackToOriginal = true;

            SaveOrUpdate(true);
        }

        private void HandleCompleteClicked()
        {
            notApprovingForm = true;

            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            editObject.FormStatus = FormStatus.Complete;

            SaveOrUpdate(true);
        }

        private bool UpdateEditObjectWithCancelledFormStatus()
        {
            string userReason;
            var result = OltPromptMessageBox.Show(view as Form, "Enter a reason for cancelling this form:",
                "Reason for Cancelling is Required", MessageBoxIcon.Exclamation, out userReason);

            if (result != DialogResult.OK && result != DialogResult.Yes) return false;

            var cancelledReason = userReason.IsNullOrEmpty() ? "Reason not provided" : userReason;

            editObject.CancelledBy = userContext.User.FullNameWithUserName;
            editObject.CancelledDateTime = Clock.Now;
            editObject.CancelledReason = cancelledReason;
            editObject.FormStatus = FormStatus.Cancelled;

            return true;
        }

        private bool HasAllRequiredApprovals()
        {
            if (editObject.Type == ProcedureDeviationType.Immediate)
            {
                return editObject.ImmediateApprovalsApprover1ApprovedDateTime.HasValue ||
                       editObject.ImmediateApprovalsApprover2ApprovedDateTime.HasValue;
            }

            if (editObject.Type == ProcedureDeviationType.Temporary)
            {
                return editObject.TemporaryApprovalsApprover1ApprovedDateTime.HasValue ||
                       editObject.TemporaryApprovalsApprover2ApprovedDateTime.HasValue;
            }

            return false;
        }

        private void UpdateEditObjectFormStatus()
        {
            var hasRequiredApprovals = HasAllRequiredApprovals();

            if (editObject.FormStatus == FormStatus.Draft)
            {
                if (hasRequiredApprovals)
                {
                    editObject.FormStatus = editObject.Type == ProcedureDeviationType.Immediate
                        ? FormStatus.Approved
                        : FormStatus.RevisionInProgress;
                }
            }
            else if (editObject.FormStatus == FormStatus.RevisionInProgress)
            {
                if (hasRequiredApprovals)
                {
                    if (editObject.Type == ProcedureDeviationType.Temporary)
                    {
                        editObject.FormStatus = FormStatus.Approved;
                    }
                }
            }
        }

        protected override bool ValidateViewHasError()
        {
            var context = ClientSession.GetUserContext();

            view.ClearErrorProviders();
            var hasError = base.ValidateViewHasError();

            if (view.ValidFrom > context.UserShift.StartDateTime && view.ValidFrom < editObject.CreatedDateTime)
            {
                view.SetErrorForValidFromIsBeforeCreatedDateTime();
                hasError = true;
            }

            if (view.ValidFrom < context.UserShift.StartDateTime)
            {
                view.SetErrorForValidFromIsInThePast();
                hasError = true;
            }

            if (view.ValidTo < editObject.CreatedDateTime)
            {
                view.SetErrorForValidToIsBeforeCreatedDateTime();
                hasError = true;
            }

            if (view.ValidTo < Clock.Now)
            {
                view.SetErrorForValidToIsInThePast();
                hasError = true;
            }

            if (view.ValidFrom >= view.ValidTo)
            {
                view.SetErrorForValidFromMustBeBeforeValidTo();
                hasError = true;
            }

            if (view.LocationEquipmentNumber.IsNullOrEmpty())
            {
                view.SetErrorForLocationEquipmentNumberNotSet();
                hasError = true;
            }

            if (view.OperatingProcedureNumber.IsNullOrEmpty())
            {
                view.SetErrorForOperatingProcedureNumberNotSet();
                hasError = true;
            }

            if (view.OperatingProcedureTitle.IsNullOrEmpty())
            {
                view.SetErrorForOperatingProcedureTitleNotSet();
                hasError = true;
            }

            if (view.OperatingProcedureLevel == null)
            {
                view.SetErrorForOperatingProcedureLevelNotSet();
                hasError = true;
            }

            if (view.PlainTextContent.IsNullOrEmpty())
            {
                view.SetErrorForDescriptionNotSet();
                hasError = true;
            }

            if (view.CauseDeterminationCauseSelected == false)
            {
                view.SetErrorWhy1ReasonNotSet();
                hasError = true;
            }

            if (view.CauseDeterminationCauseSelected && view.CauseDeterminationCauses.Contains(CauseDeterminationWhyType.Other) &&
                view.CauseDeterminationComments.IsNullOrEmpty())
            {
                view.SetErrorCauseDeterminationCommentsNotSet();
                hasError = true;
            }

            if (view.FixDocumentDurationTypeSelected == false)
            {
                view.SetErrorCorrectiveActionNotSet();
                hasError = true;
            }

            if (view.HasCorrectiveActionIlpNumber && view.CorrectiveActionIlpNumber.IsNullOrEmpty())
            {
                view.SetErrorCorrectiveActionIlpNumberNotSet();
                hasError = true;
            }

            if (view.HasCorrectiveActionWorkRequestNumber && view.CorrectiveActionWorkRequestNumber.IsNullOrEmpty())
            {
                view.SetErrorCorrectiveActionWorkRequestNumberNotSet();
                hasError = true;
            }

            if (view.HasCorrectiveActionOtherComments && view.CorrectiveActionOtherComments.IsNullOrEmpty())
            {
                view.SetErrorCorrectiveActionOtherCommentsNotSet();
                hasError = true;
            }

            var hasTechnicalSME =
                view.RiskAssessmentAttendees.Exists(
                    attendee => attendee.AttendeeType == ProcedureDeviationAttendeeType.TechnicalSME && !attendee.AttendeeName.IsNullOrEmpty());
            if (hasTechnicalSME == false && (view.AffectsToe || view.ProcedureDeviationType == ProcedureDeviationType.Temporary))
            {
                view.SetErrorForTechnicalSMERequired();
                hasError = true;
            }

            if (view.RiskAssessmentAnswer1NotSet)
            {
                view.SetErrorForRiskAssessmentAnswer1NotSet();
                hasError = true;
            }

            if (view.RiskAssessmentAnswer2NotSet)
            {
                view.SetErrorForRiskAssessmentAnswer2NotSet();
                hasError = true;
            }

            if (view.RiskAssessmentAnswer3NotSet)
            {
                view.SetErrorForRiskAssessmentAnswer3NotSet();
                hasError = true;
            }

            if (view.RiskAssessmentAnswer4NotSet)
            {
                view.SetErrorForRiskAssessmentAnswer4NotSet();
                hasError = true;
            }

            if (view.RiskAssessmentAnswer5NotSet)
            {
                view.SetErrorForRiskAssessmentAnswer5NotSet();
                hasError = true;
            }

            if (view.HasAtLeastOneRiskAssessmentYesAnswer && view.RiskAssessmentComments.IsNullOrEmpty())
            {
                view.SetErrorForRiskAssessmentCommentsNotSet();
                hasError = true;
            }

            return hasError;
        }

        private void QueryContractors()
        {
            contractors = contractorService.QueryBySite(userContext.Site);
            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> {QueryContractors});
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormProcedureDeviationFormTitle);
            view.OperatingProcedureLevels = new List<OperatingProcedureLevel>(OperatingProcedureLevel.All);
            view.ImmediateApprovalsObtainedViaList =
                new List<string>(ProcedureDeviationApprovalObtainedVia.AllAsStringNames());

            UpdateViewFromEditObject();
        }
    }
}
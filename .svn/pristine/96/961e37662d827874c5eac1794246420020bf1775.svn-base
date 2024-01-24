using System;
using System.Collections.Generic;
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
    public class DocumentSuggestionFormPresenter :
        AbstractFormEdmontonFormPresenter<DocumentSuggestion, IDocumentSuggestionFormView>
    {
        private const int DefaultEndDateDays = 14;
        private const string DefaultNewDocName = "NEW";
        private readonly IAuthorized authorized;

        private readonly IContractorService contractorService;
        private readonly IFunctionalLocationService flocService;
        private readonly FormStatus originalStatus;
        private readonly IFormEdmontonService service;
        private bool approvingForm;
        private List<Contractor> contractors;
        private bool notApprovingForm;

        public DocumentSuggestionFormPresenter()
            : this(CreateDefaultForm())
        {
        }

        public DocumentSuggestionFormPresenter(DocumentSuggestion form)
            : base(new DocumentSuggestionForm(), form)
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

            view.NewOrExistingDocumentChanged += HandleNewOrExistingDocumentChanged;
            view.RecommendedToBeArchivedCheckedChanged += HandleRecommendedToBeArchivedCheckedChanged;

            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.NotApprovedButtonClicked += HandleNotApprovedClicked;

            originalStatus = form.FormStatus;
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

        private void HandleNewOrExistingDocumentChanged()
        {
            var newDocumentSelected = view.NewDocument;

            if (newDocumentSelected)
            {
                view.RecommendedToBeArchived = false;

                if (view.DocumentNumber.IsNullOrEmpty())
                {
                    view.DocumentNumber = DefaultNewDocName;
                }

                if (view.DocumentTitle.IsNullOrEmpty())
                {
                    view.DocumentTitle = DefaultNewDocName;
                }
            }
            else
            {
                view.RecommendedToBeArchived = editObject.RecommendedToBeArchived;

                if (view.DocumentNumber.ToUpper().Trim().Equals(DefaultNewDocName.ToUpper()))
                {
                    view.DocumentNumber = string.Empty;
                }

                if (view.DocumentTitle.ToUpper().Trim().Equals(DefaultNewDocName.ToUpper()))
                {
                    view.DocumentTitle = string.Empty;
                }
            }

            view.EnableRecommendedToBeArchived = !newDocumentSelected;
        }

        private void HandleRecommendedToBeArchivedCheckedChanged()
        {
            if (editObject.FormStatus == FormStatus.RevisionInProgress)
            {
                view.SaveAndEmailButtonText = view.RecommendedToBeArchived ? @"Document Archived" : @"Document Issued";
            }
        }

        private void HandleHistoryClicked()
        {
            EditHistoryFormPresenter presenter = new DocumentSuggestionHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private static DocumentSuggestion CreateDefaultForm()
        {
            var now = Clock.Now;
            var context = ClientSession.GetUserContext();
            var currentUser = context.User;

            var startDateTime = context.UserShift.StartDateTime;
            var endDateTime = context.UserShift.EndDateTime.AddDays(DefaultEndDateDays);

            var siteid = ClientSession.GetUserContext().SiteId;             //ayman generic forms

            var form = new DocumentSuggestion(null, startDateTime, endDateTime, FormStatus.Draft, currentUser, now,
                currentUser, now, siteid)               //ayman generic forms
            {
                FromDateTime = startDateTime,
                SiteId = context.SiteId,
                ScheduledCompletionDateTime = null,
                LocationEquipmentNumber = null,
                IsExistingDocument = true,
                DocumentOwner = null,
                DocumentNumber = null,
                DocumentTitle = null,
                NumberOfExtensions = 0,
                ReasonsForExtension = null,
                OriginalMarkedUp = false,
                HardCopySubmittedTo = null,
                RecommendedToBeArchived = false,
                Description = null
            };

            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.ToDateTime = view.ValidTo; // Suggested completion datetime

            // If the scheduled date has not yet been set and the form was in 
            // owner review but we're not approving it - don't save a value for 
            // the completion date.
            if (notApprovingForm && originalStatus == FormStatus.OwnerReview &&
                editObject.ScheduledCompletionDateTime.HasValue == false)
            {
                editObject.ScheduledCompletionDateTime = null;
            }
            else if (editObject.AllowEditScheduledCompletionDate)
            {
                editObject.ScheduledCompletionDateTime = view.ScheduledCompletionDateTime;
            }

            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.LocationEquipmentNumber = view.LocationEquipmentNumber;
            editObject.DocumentLinks = view.DocumentLinks;

            editObject.IsExistingDocument = view.ExistingDocument;
            editObject.DocumentOwner = view.DocumentOwner;
            editObject.DocumentNumber = view.DocumentNumber;
            editObject.DocumentTitle = view.DocumentTitle;

            editObject.OriginalMarkedUp = view.OriginalMarkedUp;
            editObject.HardCopySubmittedTo = view.HardCopySubmittedTo;

            editObject.RecommendedToBeArchived = view.RecommendedToBeArchived;
            editObject.Description = view.PlainTextContent;
            editObject.RichTextDescription = view.Content;
        }

        protected override void ShowEmail()
        {
            if (editObject.FormStatus == FormStatus.InitialReview)
            {
                FormDocumentSuggestionPagePresenterHelper.ShowEmailForInitialReview(editObject);
            }
            else if (editObject.FormStatus == FormStatus.OwnerReview)
            {
                FormDocumentSuggestionPagePresenterHelper.ShowEmailForOwnerReview(editObject);
            }
            else if (editObject.FormStatus == FormStatus.DocumentIssued ||
                     editObject.FormStatus == FormStatus.DocumentArchived)
            {
                FormDocumentSuggestionPagePresenterHelper.ShowEmailForDocumentIssuedOrArchived(editObject);
            }
            else if (editObject.FormStatus == FormStatus.NotApproved)
            {
                FormDocumentSuggestionPagePresenterHelper.ShowEmailForNotApproved(editObject);
            }
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

            view.ValidTo = editObject.ToDateTime; // Suggestion completion datetime

            view.ScheduledCompletionDateTime = editObject.ScheduledCompletionDateTime.HasValue == false
                ? editObject.ToDateTime // Set the displayed value to the suggestion completion date
                : editObject.ScheduledCompletionDateTime;

            view.EnableSuggestedCompletionDateTime = editObject.AllowEditSuggestedCompletionDate;
            view.EnableScheduledCompletionDateTime = editObject.AllowEditScheduledCompletionDate;

            view.FunctionalLocations = editObject.FunctionalLocations;
            view.LocationEquipmentNumber = editObject.LocationEquipmentNumber;
            view.DocumentLinks = editObject.DocumentLinks;

            view.NumberOfExtensions = editObject.NumberOfExtensions;
            view.ReasonForExtensions = editObject.ReasonsForExtensionSortedByCreatedDate;

            if (IsEdit)
            {
                view.ExistingDocument = editObject.IsExistingDocument;
            }

            view.NewDocument = !editObject.IsExistingDocument;

            view.DocumentOwner = editObject.DocumentOwner;
            view.DocumentNumber = editObject.DocumentNumber;
            view.DocumentTitle = editObject.DocumentTitle;

            view.OriginalMarkedUp = editObject.OriginalMarkedUp;
            view.HardCopySubmittedTo = editObject.HardCopySubmittedTo;

            view.RecommendedToBeArchived = editObject.RecommendedToBeArchived;
            view.Content = editObject.RichTextDescription;

            SetFormButtons();
            SetApprovals();

            view.DocumentSuggestion = editObject;
        }

        private void SetFormButtons()
        {
            var siteId = userContext.SiteId;
            var userRoleElements = userContext.UserRoleElements;
            var canApprove = authorized.ToApproveFormDocumentSuggestion(userRoleElements, siteId);
            var canEdit = authorized.ToEditFormDocumentSuggestion(userRoleElements, siteId);

            if (editObject.FormStatus == FormStatus.Draft)
            {
                view.EnableNotApprovedButton = false;
                view.EnableSaveAndEmailButton = true;
                view.SaveAndEmailButtonText = @"Save && Send for Initial Review";
                view.EnableSaveAndCloseButton = true;
            }
            else if (editObject.FormStatus == FormStatus.InitialReview)
            {
                view.EnableNotApprovedButton = canApprove;
                view.EnableSaveAndEmailButton = canApprove;
                view.SaveAndEmailButtonText = @"Save && Send for Owner Review";
                view.EnableSaveAndCloseButton = canEdit;
            }
            else if (editObject.FormStatus == FormStatus.OwnerReview)
            {
                view.EnableNotApprovedButton = canApprove;
                view.EnableSaveAndEmailButton = canApprove;
                view.SaveAndEmailButtonText = @"Revision in Progress";
                view.EnableSaveAndCloseButton = canEdit;
            }
            else if (editObject.FormStatus == FormStatus.RevisionInProgress)
            {
                view.EnableNotApprovedButton = canApprove;
                view.EnableSaveAndEmailButton = canApprove;
                view.SaveAndEmailButtonText = editObject.RecommendedToBeArchived
                    ? @"Document Archived"
                    : @"Document Issued";
                view.EnableSaveAndCloseButton = canEdit;
            }
            else if (editObject.FormStatus == FormStatus.NotApproved)
            {
                view.EnableNotApprovedButton = false;
                view.EnableSaveAndEmailButton = false;
                view.EnableSaveAndCloseButton = false;
            }
            else if (editObject.FormStatus == FormStatus.DocumentIssued ||
                     editObject.FormStatus == FormStatus.DocumentArchived)
            {
                view.EnableNotApprovedButton = false;
                view.EnableSaveAndEmailButton = false;
                view.EnableSaveAndCloseButton = false;
            }
        }

        private void SetApprovals()
        {
            var viewApprovals = editObject.AllApprovals;
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            view.Approvals = viewApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    service.InsertDocumentSuggestionForm, editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                service.UpdateDocumentSuggestionForm, editObject);
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

        private void Save(bool approveAndShowEmail)
        {
            if (Validate())
            {
                return;
            }

            if (!UpdateNumberOfExtensionsAndReasonIfScheduledCompletionDateChanged()) return;

            UpdateEditObjectFromView();

            if (approveAndShowEmail)
            {
                UpdateEditObjectFormStatus();
            }

            SaveOrUpdate(true);

            if (approveAndShowEmail)
            {
                ShowEmail();
            }
        }

        private bool UpdateNumberOfExtensionsAndReasonIfScheduledCompletionDateChanged()
        {
            if (editObject.ScheduledCompletionDateTime.HasValue &&
                editObject.ScheduledCompletionDateTime < view.ScheduledCompletionDateTime)
            {
                string userReason;
                var result = OltPromptMessageBox.Show(view as Form,
                    "Enter a reason for extending the scheduled completion date of this form:",
                    "Reason for Extension", MessageBoxIcon.Exclamation, out userReason);

                if (result != DialogResult.OK && result != DialogResult.Yes) return false;

                var reasonForExtension = userReason.IsNullOrEmpty() ? "Reason not provided" : userReason.Replace(Environment.NewLine, " ");

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

        private void HandleNotApprovedClicked(object sender, EventArgs e)
        {
            notApprovingForm = true;

            if (Validate())
            {
                return;
            }

            if (!UpdateEditObjectWithNotApprovedFormStatus()) return;

            UpdateEditObjectFromView();

            SaveOrUpdate(true);

            ShowEmail();
        }

        private bool UpdateEditObjectWithNotApprovedFormStatus()
        {
            string userReason;
            var result = OltPromptMessageBox.Show(view as Form, "Enter a reason for not approving this form:",
                "Reason for Not Approving is Required", MessageBoxIcon.Exclamation, out userReason);

            if (result != DialogResult.OK && result != DialogResult.Yes) return false;

            var notApprovedReason = userReason.IsNullOrEmpty() ? "Reason not provided" : userReason;

            editObject.NotApprovedBy = userContext.User.FullNameWithUserName;
            editObject.NotApprovedDateTime = Clock.Now;
            editObject.NotApprovedReason = notApprovedReason;
            editObject.FormStatus = FormStatus.NotApproved;

            return true;
        }

        private void UpdateEditObjectFormStatus()
        {
            var approvedBy = userContext.User.FullNameWithUserName;
            var approvedDateTime = Clock.Now;

            if (editObject.FormStatus == FormStatus.Draft)
            {
                editObject.FormStatus = FormStatus.InitialReview;
            }
            else if (editObject.FormStatus == FormStatus.InitialReview)
            {
                editObject.InitialReviewApprovedBy = approvedBy;
                editObject.InitialReviewApprovedDateTime = approvedDateTime;
                editObject.FormStatus = FormStatus.OwnerReview;
            }
            else if (editObject.FormStatus == FormStatus.OwnerReview)
            {
                editObject.OwnerReviewApprovedBy = approvedBy;
                editObject.OwnerReviewApprovedDateTime = approvedDateTime;
                editObject.FormStatus = FormStatus.RevisionInProgress;
            }
            else if (editObject.FormStatus == FormStatus.RevisionInProgress)
            {
                if (editObject.RecommendedToBeArchived)
                {
                    editObject.DocumentArchivedApprovedBy = approvedBy;
                    editObject.DocumentArchivedApprovedDateTime = approvedDateTime;
                    editObject.FormStatus = FormStatus.DocumentArchived;
                }
                else
                {
                    editObject.DocumentIssuedApprovedBy = approvedBy;
                    editObject.DocumentIssuedApprovedDateTime = approvedDateTime;
                    editObject.FormStatus = FormStatus.DocumentIssued;
                }
            }
        }

        protected override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            var hasError = base.ValidateViewHasError();

            if (view.ValidTo < Clock.Now && editObject.AllowEditSuggestedCompletionDate)
            {
                view.SetErrorForValidToIsInThePast();
                hasError = true;
            }

            if (editObject.CreatedDateTime >= view.ScheduledCompletionDateTime)
            {
                view.SetErrorForScheduledCompletionMustBeBeforeValidTo();
                hasError = true;
            }

            if (view.ScheduledCompletionDateTime < Clock.Now &&
                !(approvingForm && editObject.FormStatus == FormStatus.RevisionInProgress))
            {
                view.SetErrorForScheduledCompletionIsInThePast();
                hasError = true;
            }

            if (view.ScheduledCompletionDateTime == null &&
                (approvingForm && editObject.FormStatus == FormStatus.OwnerReview))
            {
                view.SetErrorForScheduledCompletionNotSet();
                hasError = true;
            }

            if (view.LocationEquipmentNumber.IsNullOrEmpty())
            {
                view.SetErrorForLocationEquipmentNumberNotSet();
                hasError = true;
            }

            if (view.ExistingDocument == false && view.NewDocument == false)
            {
                view.SetErrorForNewDocumentNotSelected();
                hasError = true;
            }

            if (view.DocumentOwner.IsNullOrEmpty() && view.ExistingDocument)
            {
                view.SetErrorForDocumentOwnerNotSet();
                hasError = true;
            }

            if (view.DocumentNumber.IsNullOrEmpty())
            {
                view.SetErrorForDocumentNumberNotSet();
                hasError = true;
            }

            if (view.DocumentTitle.IsNullOrEmpty())
            {
                view.SetErrorForDocumentTitleNotSet();
                hasError = true;
            }

            if (view.NewDocument && view.DocumentNumber.Trim().ToUpper() == "NEW" &&
                 (approvingForm && editObject.FormStatus == FormStatus.RevisionInProgress))
            {
                view.SetErrorForDocumentNumberNotValid();
                hasError = true;
            }

            if (view.NewDocument && view.DocumentTitle.Trim().ToUpper() == "NEW" &&
                 (approvingForm && editObject.FormStatus == FormStatus.RevisionInProgress))
            {
                view.SetErrorForDocumentTitleNotValid();
                hasError = true;
            }

            if (view.OriginalMarkedUp && view.HardCopySubmittedTo.IsNullOrEmpty())
            {
                view.SetErrorForHardCopySubmittedToNotSet();
                hasError = true;
            }

            if (view.PlainTextContent.IsNullOrEmpty())
            {
                view.SetErrorForDescriptionNotSet();
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
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormDocumentSuggestionFormTitle);

            UpdateViewFromEditObject();
        }
    }
}
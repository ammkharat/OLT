using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DocumentSuggestionForm : BaseForm, IDocumentSuggestionFormView
    {
        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        private DocumentSuggestion documentSuggestion;

        public DocumentSuggestionForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            historyButton.Click += HandleHistoryButtonClicked;
            notApprovedButton.Click += HandleNotApprovedButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;

            var userContext = ClientSession.GetUserContext();
            var rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(userContext.SiteConfiguration),
                    null,
                    true, 
                    rootFlocsForActiveSelection);

            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocatnButton.Click += HandleRemoveFunctionalLocationButtonClicked;

            existingDocumentRadioButton.CheckedChanged += NewOrExistingDocumentRadioButtonOnCheckedChanged;
            newDocumentRadioButton.CheckedChanged += NewOrExistingDocumentRadioButtonOnCheckedChanged;

            originalMarkedUpCheckBox.CheckedChanged += OriginalMarkedUpCheckBoxOnCheckedChanged;

            recommendedToBeArchivedCheckBox.CheckedChanged += RecommendedToBeArchivedCheckBoxOnCheckedChanged;

            expandLinkLabel.Click += ExpandLinkLabelOnClick;

            scrollingPanel.MouseEnter += ScrollingPanelOnMouseEnter;
        }

        private void RecommendedToBeArchivedCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (RecommendedToBeArchivedCheckedChanged != null)
            {
                RecommendedToBeArchivedCheckedChanged();
            }
        }

        private void OriginalMarkedUpCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            hardCopySubmittedToTextBox.Enabled = originalMarkedUpCheckBox.Checked;
        }

        private void ExpandLinkLabelOnClick(object sender, EventArgs eventArgs)
        {
            if (ExpandClicked != null)
            {
                ExpandClicked();
            }
        }

        private void NewOrExistingDocumentRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (NewOrExistingDocumentChanged != null)
            {
                NewOrExistingDocumentChanged();
            }
        }

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        public event Action HistoryClicked;
        public event EventHandler NotApprovedButtonClicked;
        public event Action SaveAndEmailButtonClicked;

        public event Action FormLoad;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;

        public event Action ExpandClicked;

        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        
        public event Action ValidityDatesChanged;

        public event Action NewOrExistingDocumentChanged;
        public event Action RecommendedToBeArchivedCheckedChanged;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set
            {
                functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value);

                if (value != null && value.Count == 1 && LocationEquipmentNumber.IsNullOrEmpty())
                {
                    var firstFloc = value[0];
                    LocationEquipmentNumber = firstFloc.Description;
                }
            }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public User CreatedByUser
        {
            set { createdByUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime CreatedDateTime
        {
            set { createdDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public string FormStatus
        {
            set { statusLabel.Text = value; }
        }

        public DateTime ValidTo
        {
            get
            {
                var date = suggestedCompletionDatePicker.Value;
                var time = suggestedCompletionTimePicker.Value;

                return date.CreateDateTime(time);
            }
            set
            {
                suggestedCompletionDatePicker.Value = new Date(value);
                suggestedCompletionTimePicker.Value = new Time(value);
            }
        }

        public DateTime ValidFrom { get; set; }

        public bool EnableSuggestedCompletionDateTime
        {
            set
            {
                suggestedCompletionDatePicker.Enabled = value;
                suggestedCompletionTimePicker.Enabled = value;
            }
        }

        public bool EnableScheduledCompletionDateTime
        {
            set
            {
                scheduledCompletionDatePicker.Enabled = value;
                scheduledCompletionTimePicker.Enabled = value;
            }
        }

        public DateTime? ScheduledCompletionDateTime
        {
            get
            {
                if (scheduledCompletionDatePicker.Enabled == false)
                {
                    return null;
                }

                var date = scheduledCompletionDatePicker.Value;
                var time = scheduledCompletionTimePicker.Value;

                return date != null && time != null? date.CreateDateTime(time) : (DateTime?)null;
            }
            set
            {
                if (value.HasValue)
                {
                    scheduledCompletionDatePicker.Value = new Date(value.Value);
                    scheduledCompletionTimePicker.Value = new Time(value.Value);
                }
                else
                {
                    scheduledCompletionDatePicker.Value = null;
                    scheduledCompletionTimePicker.Value = null;
                }
            }
        }

        public int NumberOfExtensions
        {
            set { numberOfExtensionsLabel.Text = string.Format("{0}", value); }
        }

        public List<Comment> ReasonForExtensions
        {
            set 
            { 
                extensionReasonsListBox.Items.Clear();
                if (value == null) return;

                foreach (var reason in value)
                {
                    extensionReasonsListBox.Items.Add(reason.Text);
                }
            }
        } 

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> initialUserFLOCSelections)
        {
            var dialogResult = flocSelector.ShowDialog(this, initialUserFLOCSelections);

            var selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult,
                new List<FunctionalLocation>(selectedFunctionalLocations));
        }

        public void DisplayExpandedLogCommentForm()
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(Content, false);
            expandedLogCommentForm.ShowDialog(this);
            Content = expandedLogCommentForm.TextEditorText;
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            return new DialogResult();
        }

        public string LocationEquipmentNumber
        {
            get { return locationEquipmentTextBox.Text; }
            set { locationEquipmentTextBox.Text = value; }
        }

        public bool ExistingDocument
        {
            get { return existingDocumentRadioButton.Checked; }
            set { existingDocumentRadioButton.Checked = value; }
        }

        public bool NewDocument
        {
            get { return newDocumentRadioButton.Checked; }
            set { newDocumentRadioButton.Checked = value; }
        }

        public string DocumentOwner
        {
            get { return documentOwnerTextBox.Text; }
            set { documentOwnerTextBox.Text = value; }
        }

        public string DocumentNumber
        {
            get { return documentNumberTextBox.Text; }
            set { documentNumberTextBox.Text = value; }
        }
        
        public string DocumentTitle
        {
            get { return documentTitleTextBox.Text; }
            set { documentTitleTextBox.Text = value; }
        }

        public bool OriginalMarkedUp
        {
            get { return originalMarkedUpCheckBox.Checked; }
            set { originalMarkedUpCheckBox.Checked = value; }
        }

        public string HardCopySubmittedTo
        {
            get { return hardCopySubmittedToTextBox.Text; }
            set { hardCopySubmittedToTextBox.Text = value; }
        }

        public bool EnableRecommendedToBeArchived
        {
            set { recommendedToBeArchivedCheckBox.Enabled = value; }
        }

        public bool RecommendedToBeArchived
        {
            get { return recommendedToBeArchivedCheckBox.Checked; }
            set { recommendedToBeArchivedCheckBox.Checked = value; }
        }

        public string Content
        {
            get { return descriptionRichTextEditor.Text; }
            set { descriptionRichTextEditor.Text = value; }
        }

        public string PlainTextContent
        {
            get { return descriptionRichTextEditor.PlainText; }
        }

        public DocumentSuggestion DocumentSuggestion
        {
            set
            {
                SuspendLayout();

                documentSuggestion = value;

                // TODO: init form controls from domain object?

                ResumeLayout(false);
                PerformLayout();
            }
        }

        public bool EnableNotApprovedButton
        {
            set { notApprovedButton.Visible = value; }
        }

        public bool EnableSaveAndEmailButton
        {
            set { saveAndEmailButton.Visible = value; }
        }

        public bool EnableSaveAndCloseButton
        {
            set { saveButton.Visible = value; }
        }

        public string SaveAndEmailButtonText
        {
            set { saveAndEmailButton.Text = value; }
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForLocationEquipmentNumberNotSet()
        {
            errorProvider.SetError(locationEquipmentTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(suggestedCompletionTimePicker,
                StringResources.SuggestedCompletionDateBeforeStartDate);
        }
        
        public void SetErrorForScheduledCompletionMustBeBeforeValidTo()
        {
            errorProvider.SetError(scheduledCompletionTimePicker,
                StringResources.ScheduledCompletionDateBeforeStartDate);
        }
        
        public void SetErrorForValidToIsInThePast()
        {
            errorProvider.SetError(suggestedCompletionDatePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForScheduledCompletionIsInThePast()
        {
            errorProvider.SetError(scheduledCompletionDatePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForScheduledCompletionNotSet()
        {
            errorProvider.SetError(scheduledCompletionDatePicker, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForExistingDocumentNotSelected()
        {
            errorProvider.SetError(existingDocumentRadioButton, StringResources.DocumentTypeMustBeSelected);            
        }

        public void SetErrorForNewDocumentNotSelected()
        {
            errorProvider.SetError(newDocumentRadioButton, StringResources.DocumentTypeMustBeSelected);            
        }

        public void SetErrorForDocumentOwnerNotSet()
        {
            errorProvider.SetError(documentOwnerTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForDocumentNumberNotSet()
        {
            errorProvider.SetError(documentNumberTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForDocumentTitleNotSet()
        {
            errorProvider.SetError(documentTitleTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForDocumentNumberNotValid()
        {
            errorProvider.SetError(documentNumberTextBox, StringResources.DocumentNumberNotValid);
        }

        public void SetErrorForDocumentTitleNotValid()
        {
            errorProvider.SetError(documentTitleTextBox, StringResources.DocumentTitleNotValid);
        }

        public void SetErrorForHardCopySubmittedToNotSet()
        {
            errorProvider.SetError(hardCopySubmittedToTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForDescriptionNotSet()
        {
            errorProvider.SetError(descriptionRichTextEditor, StringResources.FieldCannotBeEmpty);
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public List<FormApproval> Approvals
        {
            set
            {
                var items = value.ConvertAll(approval => new DocumentSuggestionFormApprovalGridDisplayAdapter(approval));
                approvalsGridControl.Items = items;
            }
            get { return null; }
        }

        private void HandleHistoryButtonClicked(object sender, EventArgs e)
        {
            if (HistoryClicked != null)
            {
                HistoryClicked();
            }
        }

        private void ScrollingPanelOnMouseEnter(object sender, EventArgs eventArgs)
        {
            scrollingPanel.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void HandleAddFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (AddFunctionalLocationButtonClicked != null)
            {
                AddFunctionalLocationButtonClicked();
            }
        }

        private void HandleRemoveFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (RemoveFunctionalLocationButtonClicked != null)
            {
                RemoveFunctionalLocationButtonClicked();
            }
        }




        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {

        }

        public void DisableWaitingForApprovalButton()
        {

        }




        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs e)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
            }
        }

        private void HandleNotApprovedButtonClicked(object sender, EventArgs e)
        {
            if (NotApprovedButtonClicked != null)
            {
                NotApprovedButtonClicked(sender, e);
            }
        }
    }
}
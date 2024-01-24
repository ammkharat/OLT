using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormTemporaryInstallationsForm : BaseForm, IFormTemporaryInstallationsView
    {
        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        public FormTemporaryInstallationsForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;

            var userContext = ClientSession.GetUserContext();
            var rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(userContext.SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2,
                        rootFlocsForActiveSelection),
                    true, rootFlocsForActiveSelection);

            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocatnButton.Click += HandleRemoveFunctionalLocationButtonClicked;
            expandLinkLabel.Click += HandleExpandClicked;
            waitingapprovalButton.Click += HandleWaitingApprovalButtonClicked;

            //pressureSafetyValveYesRadioButton.CheckedChanged += HandlePressureSafetyValveYesRadioButtonOnCheckedChanged;
            //pressureSafetyValveNoRadioButton.CheckedChanged += HandlePressureSafetyValveNoRadioButtonOnCheckedChanged; 
            validToDatePicker.ValueChanged += HandleValidityDatesChanged;
            validFromDatePicker.ValueChanged += HandleValidityDatesChanged;
            validToTimePicker.ValueChanged += HandleValidityDatesChanged;
            validFromTimePicker.ValueChanged += HandleValidityDatesChanged;

            mainPanel.Layout += HandleMainPanelLayout;
            historyButton.Click += HandleHistoryButtonClicked;
       
            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;
        }

        private void HandleHistoryButtonClicked(object sender, EventArgs e)
        {
            if (HistoryClicked != null)
            {
                HistoryClicked();
            }
        }

        public event Action HistoryClicked;

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        
        public event Action FormLoad;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action ExpandClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action PressureSafetyValveAnswerChanged;
        public event Action ValidityDatesChanged;
        public event Action WaitingApprovalButtonClicked; 

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public bool ApprovalsEnabled
        {
            set
            {
                approvalsGridControl.Enabled = value;
            }
        }

        public List<FormApproval> Approvals
        {
            set
            {
                approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval));
            }
            get
            {
                var list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public string ApprovalsGroupBoxLabel
        {
            set { approvalsGridControl.GroupBoxLabel = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
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

        public DateTime ValidTo
        {
            get
            {
                var date = validToDatePicker.Value;
                var time = validToTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validToDatePicker.Value = new Date(value);
                validToTimePicker.Value = new Time(value);
            }
        }

        public DateTime ValidFrom
        {
            get
            {
                var date = validFromDatePicker.Value;
                var time = validFromTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validFromDatePicker.Value = new Date(value);
                validFromTimePicker.Value = new Time(value);
            }
        }

        public string Content
        {
            get { return contentRichTextEditor.Text; }
            set { contentRichTextEditor.Text = value; }
        }

        public string PlainTextContent
        {
            get { return contentRichTextEditor.PlainText; }
        }

        public void EnableWaitingForApprovalButton()
        {
            waitingapprovalButton.Enabled = true;
            saveButton.Text = StringResources.MudsSaveButtonText;//"Save as Draft";
        }

        public void DisableWaitingForApprovalButton()
        {
            waitingapprovalButton.Enabled = false;
            saveButton.Text = StringResources.MudsSaveWithAllApprovalButtonText; //"Save && Close";
        }

        private void HandleWaitingApprovalButtonClicked(object sender, EventArgs eventArgs) 
        {
            if (WaitingApprovalButtonClicked != null)
            {
                WaitingApprovalButtonClicked();
            }
        }

        //public bool? IsTheCSDForAPressureSafetyValve
        //{
        //    get
        //    {
        //        if (pressureSafetyValveYesRadioButton.Checked) return true;
        //        if (pressureSafetyValveNoRadioButton.Checked) return false;
        //        return default(bool?);
        //    }
        //    set
        //    {
        //        if (value.HasValue)
        //        {
        //            pressureSafetyValveYesRadioButton.Checked = value.Value;
        //            pressureSafetyValveNoRadioButton.Checked = !value.Value;
        //        }
        //        else
        //        {
        //            pressureSafetyValveYesRadioButton.Checked = false;
        //            pressureSafetyValveNoRadioButton.Checked = false;
        //        }
        //    }
        //}

        //public bool? HasAttachments
        //{
        //    get
        //    {
        //        if (hasAttachmentsYesRadioButton.Checked) return true;
        //        if (hasAttachmentsNoRadioButton.Checked) return false;
        //        return default(bool?);

        //    }
        //    set
        //    {
        //        if (value.HasValue)
        //        {
        //            hasAttachmentsYesRadioButton.Checked = value.Value;
        //            hasAttachmentsNoRadioButton.Checked = !value.Value;
        //        }
        //        else
        //        {
        //            hasAttachmentsYesRadioButton.Checked = false;
        //            hasAttachmentsNoRadioButton.Checked = false;
        //        }
        //    }
        //}


        //public bool? HasBeenCommunicated
        //{
        //    get
        //    {
        //        if (hasBeenCommunicatedYesRadioButton.Checked) return true;
        //        if (hasBeenCommunicatedNoRadioButton.Checked) return false;
        //        return default(bool?);
        //    }
        //    set
        //    {
        //        if (value.HasValue)
        //        {
        //            hasBeenCommunicatedYesRadioButton.Checked = value.Value;
        //            hasBeenCommunicatedNoRadioButton.Checked = !value.Value;
        //        }
        //        else
        //        {
        //            hasBeenCommunicatedYesRadioButton.Checked = false;
        //            hasBeenCommunicatedNoRadioButton.Checked = false;
        //        }
        //    }
        //}

        //public string CriticalSystemDefeated
        //{
        //    get { return criticalSystemDefeatedTextBox.Text; }
        //    set { criticalSystemDefeatedTextBox.Text = value; }
        //}

        public string CsdReason
        {
            get { return csdReasonTextBox.Text; }
            set { csdReasonTextBox.Text = value; }
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

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.EstimatedBackInServiceDateCannotBeBeforeSystemDefeatedDate);
        }

        //public void SetErrorForEmptyCriticalSystemDefeated()
        //{
        //    errorProvider.SetError(criticalSystemDefeatedTextBox, StringResources.FieldEmptyError);
        //}

        public void SetErrorForValidToIsInThePast()
        {
            errorProvider.SetError(validToDatePicker, StringResources.BackInServiceDateInPast);
        }

        //public void SetErrorForNoPressureSafetyValveResponse()
        //{
        //    errorProvider.SetError(pressureSafetyValveNoRadioButton, StringResources.YesNoError);
        //}

        //public void SetErrorForNoHasAttachmentsResponse()
        //{
        //    errorProvider.SetError(hasAttachmentsNoRadioButton, StringResources.YesNoError);
        //}

        //public void SetErrorForNoHasBeenCommunicatedResponse()
        //{
        //    errorProvider.SetError(hasBeenCommunicatedNoRadioButton, StringResources.YesNoError);
        //}

        public void SetErrorForNoCsdReasonGiven()
        {
            errorProvider.SetError(csdReasonTextBox, StringResources.FieldEmptyError);
        }

        public DialogResult ShowFormHasAdditionalApproversRequired()
        {
            var message = StringResources.FormAdditionalApproversQuestion;
            var title = StringResources.FormAdditionalApproversQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            var message = StringResources.FormReapprovalQuestion;
            var title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs layoutEventArgs)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        protected virtual List<string> RemainingApprovals()
        {
            var remainingApprovals =
                Approvals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
            remainingApprovals.RemoveAll(approvalString => approvalString == null);
            return remainingApprovals;
        } 

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
            waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
            saveButton.Text = waitingapprovalButton.Enabled == true ? StringResources.MudsSaveButtonText : StringResources.MudsSaveWithAllApprovalButtonText;
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }
            waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
            saveButton.Text = waitingapprovalButton.Enabled == true ? StringResources.MudsSaveButtonText : StringResources.MudsSaveWithAllApprovalButtonText;
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

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleExpandClicked(object sender, EventArgs e)
        {
            if (ExpandClicked != null)
            {
                ExpandClicked();
            }
        }

        private void HandlePressureSafetyValveYesRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (PressureSafetyValveAnswerChanged != null)
            {
                PressureSafetyValveAnswerChanged();
            }
        }


        //MS: 3664 - Ayman
        private void HandlePressureSafetyValveNoRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (PressureSafetyValveAnswerChanged != null)
            {
                PressureSafetyValveAnswerChanged();
            }
        }






        private void HandleValidityDatesChanged(object sender, EventArgs e)
        {
            if (ValidityDatesChanged != null)
            {
                ValidityDatesChanged();
            }
        }
    }
}
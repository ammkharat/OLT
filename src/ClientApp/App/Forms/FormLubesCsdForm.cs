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
    public partial class FormLubesCsdForm : BaseForm, IFormLubesCsdFormView
    {
        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelector;

        public FormLubesCsdForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;

            var userContext = ClientSession.GetUserContext();
            var rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetAll(
                userContext.SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2, rootFlocsForActiveSelection));

            browseFunctionalLocationButton.Click += HandleBrowseFunctionalLocationButtonClicked;
            expandLinkLabel.Click += HandleExpandClicked;

            pressureSafetyValveYesRadioButton.CheckedChanged += HandlePressureSafetyValveYesRadioButtonOnCheckedChanged;
            validToDatePicker.ValueChanged += HandleValidityDatesChanged;
            validFromDatePicker.ValueChanged += HandleValidityDatesChanged;
            validToTimePicker.ValueChanged += HandleValidityDatesChanged;
            validFromTimePicker.ValueChanged += HandleValidityDatesChanged;

            mainPanel.Layout += HandleMainPanelLayout;
            historyButton.Click += HandleHistoryButtonClicked;
            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
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

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action PressureSafetyValveAnswerChanged;
        public event Action BrowseFunctionalLocationButtonClicked;
        public event Action HistoryClicked;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    toolTip.SetToolTip(functionalLocationTextBox, value.Description);
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    toolTip.RemoveAll();
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(
            FunctionalLocation functionalLocation)
        {
            var dialogResult = flocSelector.ShowDialog(this);

            var selectedFunctionalLocation = flocSelector.SelectedFunctionalLocation;
            return new DialogResultAndOutput<FunctionalLocation>(dialogResult, selectedFunctionalLocation);
        }

        public void SetErrorForNoPressureSafetyValveResponse()
        {
            errorProvider.SetError(pressureSafetyValveNoRadioButton, StringResources.YesNoError);
        }

        public bool? IsTheCSDForAPressureSafetyValve
        {
            get
            {
                if (pressureSafetyValveYesRadioButton.Checked) return true;
                if (pressureSafetyValveNoRadioButton.Checked) return false;
                return default(bool?);
            }
            set
            {
                if (value.HasValue)
                {
                    pressureSafetyValveYesRadioButton.Checked = value.Value;
                    pressureSafetyValveNoRadioButton.Checked = !value.Value;
                }
                else
                {
                    pressureSafetyValveYesRadioButton.Checked = false;
                    pressureSafetyValveNoRadioButton.Checked = false;
                }
            }
        }

        public string CriticalSystemDefeated
        {
            get { return criticalSystemDefeatedTextBox.Text; }
            set { criticalSystemDefeatedTextBox.Text = value; }
        }

        public void SetErrorForEmptyOP14CriticalSystemDefeated()
        {
            errorProvider.SetError(criticalSystemDefeatedTextBox, StringResources.FieldEmptyError);
        }

        public void SetErrorForValidToIsInThePast()
        {
            errorProvider.SetError(validToDatePicker, StringResources.BackInServiceDateInPast);
        }

        public string LocationText
        {
            get { return locationTextBox.Text; }
            set { locationTextBox.Text = value; }
        }



        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {

        }

        public void DisableWaitingForApprovalButton()
        {

        }


        public DialogResult ShowFormHasAdditionalApproversRequired()
        {
            var message = StringResources.FormAdditionalApproversQuestion;
            var title = StringResources.FormAdditionalApproversQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public event Action FormLoad;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action ExpandClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action ValidityDatesChanged;

        public void DisplayExpandedLogCommentForm()
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(Content, false);
            expandedLogCommentForm.ShowDialog(this);
            Content = expandedLogCommentForm.TextEditorText;
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForEmptyLocation()
        {
            errorProvider.SetError(locationTextBox, StringResources.LocationEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.EstimatedBackInServiceDateCannotBeBeforeSystemDefeatedDate);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            var message = StringResources.FormReapprovalQuestion;
            var title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void HandleHistoryButtonClicked(object sender, EventArgs e)
        {
            if (HistoryClicked != null)
            {
                HistoryClicked();
            }
        }

        private void HandleBrowseFunctionalLocationButtonClicked(object sender, EventArgs e)
        {
            if (BrowseFunctionalLocationButtonClicked != null)
            {
                BrowseFunctionalLocationButtonClicked();
            }
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

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
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

        private void HandleValidityDatesChanged(object sender, EventArgs e)
        {
            if (ValidityDatesChanged != null)
            {
                ValidityDatesChanged();
            }
        }

        #region IFormView Members - Not used

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> initialUserFLOCSelections)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
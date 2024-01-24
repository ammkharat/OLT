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
    public partial class FormGN24Form : BaseForm, IFormGN24View
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action ExpandContentClicked;
        public event Action ExpandPreJobMeetingSignaturesClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action IsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged;
        public event Action IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        public FormGN24Form()
        {
            InitializeComponent();

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelThreeAndBelow(userContext.SiteConfiguration),
                                                              new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1, rootFlocsForActiveSelection),                                                                                                           
                                                              true, 
                                                              rootFlocsForActiveSelection);

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            waitingapprovalButton.Click += HandleWaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
            cancelButton.Click += HandleCancelButtonClicked;
            expandContentLinkLabel.Click += HandleExpandContentClicked;
            expandPreJobMeetingSignaturesLinkLabel.Click += HandleExpandPreJobMeetingSignaturesClicked;
            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocationButton.Click += HandleRemoveFunctionalLocationButtonClicked;
            historyButton.Click += HandleHistoryButtonClick;

            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;

            isTheSafeWorkPlanForWorkInTheAlkylationUnitYesRadioButton.CheckedChanged += HandleIsTheSafeWorkPlanForWorkInTheAlkylationUnitRadioButtonCheckedChanged;
            isTheSafeWorkPlanForWorkInTheAlkylationUnitNoRadioButton.CheckedChanged += HandleIsTheSafeWorkPlanForWorkInTheAlkylationUnitRadioButtonCheckedChanged;

            isTheSafeWorkPlanForPsvRemovalInstallationYesRadioButton.CheckedChanged += HandleIsTheSafeWorkPlanForPsvRemovalInstallationRadioButtonCheckedChanged;
            isTheSafeWorkPlanForPsvRemovalInstallationNoRadioButton.CheckedChanged += HandleIsTheSafeWorkPlanForPsvRemovalInstallationRadioButtonCheckedChanged;

        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (HistoryButtonClicked != null)
            {
                HistoryButtonClicked();
            }
        }

       
        private void HandleIsTheSafeWorkPlanForPsvRemovalInstallationRadioButtonCheckedChanged(object sender, EventArgs eventArgs)
        {
            RadioButton radioButton = (RadioButton) sender;

            if (radioButton.Checked && IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged != null)
            {
                IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged();
            }
        }

        private void HandleIsTheSafeWorkPlanForWorkInTheAlkylationUnitRadioButtonCheckedChanged(object sender, EventArgs eventArgs)
        {
            RadioButton radioButton = (RadioButton) sender;

            if (radioButton.Checked && IsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged != null)
            {
                IsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged();
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

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }


        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {
            waitingapprovalButton.Enabled = true;
            saveButton.Text = "Save as Draft";
        }

        public void DisableWaitingForApprovalButton()
        {
            waitingapprovalButton.Enabled = false;
            saveButton.Text = "Save && Close";
        }


        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
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
                Date date = validToDatePicker.Value;
                Time time = validToTimePicker.Value;

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
                Date date = validFromDatePicker.Value;
                Time time = validFromTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validFromDatePicker.Value = new Date(value);
                validFromTimePicker.Value = new Time(value);
            }
        }

        public bool IsTheSafeWorkPlanForPSVRemovalOrInstallation
        {
            get { return isTheSafeWorkPlanForPsvRemovalInstallationYesRadioButton.Checked; }
            set
            {
                isTheSafeWorkPlanForPsvRemovalInstallationYesRadioButton.Checked = value;
                isTheSafeWorkPlanForPsvRemovalInstallationNoRadioButton.Checked = !value;
            }
        }

        public bool IsTheSafeWorkPlanForWorkInTheAlkylationUnit
        {
            get { return isTheSafeWorkPlanForWorkInTheAlkylationUnitYesRadioButton.Checked; }
            set
            {
                isTheSafeWorkPlanForWorkInTheAlkylationUnitYesRadioButton.Checked = value;
                isTheSafeWorkPlanForWorkInTheAlkylationUnitNoRadioButton.Checked = !value;
            }
        }

        public FormGN24AlkylationClass AlkylationClass
        {
            get
            {
                if (!alkylationClassComboBox.Enabled)
                {
                    return null;
                }
                return (FormGN24AlkylationClass) alkylationClassComboBox.SelectedItem;
            }
            set { alkylationClassComboBox.SelectedItem = value; }
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

        public string PreJobMeetingSignatures
        {
            get { return preJobMeetingSignaturesRichTextEditor.Text; }
            set { preJobMeetingSignaturesRichTextEditor.Text = value; }
        }

        public string PlainTextPreJobMeetingSignatures
        {
            get { return preJobMeetingSignaturesRichTextEditor.PlainText; }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public List<FormGN24AlkylationClass> AlkylationClasses
        {
            set { alkylationClassComboBox.DataSource = value; }
        }

        public bool AlkylationClassSelectionEnabled
        {
            set { alkylationClassComboBox.Enabled = value; }
        }

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public List<FormApproval> Approvals
        {
            set { approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval)); }
            get
            {
                List<FormApprovalGridDisplayAdapter> list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this, initialUserFLOCSelections);

            IList<FunctionalLocation> selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult, new List<FunctionalLocation>(selectedFunctionalLocations));
        }
        
        public void DisplayExpandedContentForm()
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(Content, false);
            expandedLogCommentForm.ShowDialog(this);
            Content = expandedLogCommentForm.TextEditorText;
            expandedLogCommentForm.Dispose();
        }

        public void DisplayExpandedPreJobMeetingSignaturesForm()
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(PreJobMeetingSignatures, false);
            expandedLogCommentForm.ShowDialog(this);
            PreJobMeetingSignatures = expandedLogCommentForm.TextEditorText;
            expandedLogCommentForm.Dispose();
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.EndDateBeforeStartDate);
        }

        public void SetErrorForNoAlkylationClassSelected()
        {
            errorProvider.SetError(alkylationClassComboBox, StringResources.SelectAnAlkylationClass);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void HandleWaitingApprovalButtonClicked(object sender, EventArgs eventArgs) // Swapnil Patki For DMND0005325 Point Number 7
        {
            if (WaitingApprovalButtonClicked != null)
            {
                WaitingApprovalButtonClicked();
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleExpandContentClicked(object sender, EventArgs e)
        {
            if (ExpandContentClicked != null)
            {
                ExpandContentClicked();
            }
        }

        private void HandleExpandPreJobMeetingSignaturesClicked(object sender, EventArgs e)
        {
            if (ExpandPreJobMeetingSignaturesClicked != null)
            {
                ExpandPreJobMeetingSignaturesClicked();
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
    }
}

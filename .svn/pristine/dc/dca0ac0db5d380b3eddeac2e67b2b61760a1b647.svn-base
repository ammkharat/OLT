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
    public partial class FormGN6Form : BaseForm, IFormGN6View
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action ExpandSection1Clicked;        
        public event Action ExpandSection2Clicked;
        public event Action ExpandSection3Clicked;        
        public event Action ExpandSection4Clicked;
        public event Action ExpandSection5Clicked;
        public event Action ExpandSection6Clicked;
        public event Action Section1NotApplicableToJobCheckedChanged;
        public event Action Section2NotApplicableToJobCheckedChanged;
        public event Action Section3NotApplicableToJobCheckedChanged;
        public event Action Section4NotApplicableToJobCheckedChanged;
        public event Action Section5NotApplicableToJobCheckedChanged;
        public event Action Section6NotApplicableToJobCheckedChanged;
        public event Action ExpandPreJobMeetingSignaturesClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;
        private float initialHeightOfSection1ContentRow;
        private float initialHeightOfSection2ContentRow;
        private float initialHeightOfSection3ContentRow;
        private float initialHeightOfSection4ContentRow;
        private float initialHeightOfSection5ContentRow;
        private float initialHeightOfSection6ContentRow;

        public FormGN6Form()
        {
            InitializeComponent();

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new MultiSelectFunctionalLocationSelectionForm(
                                                  FunctionalLocationMode.GetLevelThreeAndBelow(userContext.SiteConfiguration),
                                                  new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3, rootFlocsForActiveSelection),
                                                  true,
                                                  rootFlocsForActiveSelection);

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            waitingapprovalButton.Click += HandleWaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
            cancelButton.Click += HandleCancelButtonClicked;
            expandPreJobMeetingSignaturesLinkLabel.Click += HandleExpandPreJobMeetingSignaturesClicked;
            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocationButton.Click += HandleRemoveFunctionalLocationButtonClicked;
            historyButton.Click += HandleHistoryButtonClick;
            section1NotApplicableToJobCheckBox.CheckedChanged += HandleSection1NotApplicableToJobCheckBoxChecked;
            section2NotApplicableToJobCheckBox.CheckedChanged += HandleSection2NotApplicableToJobCheckBoxChecked;
            section3NotApplicableToJobCheckBox.CheckedChanged += HandleSection3NotApplicableToJobCheckBoxChecked;
            section4NotApplicableToJobCheckBox.CheckedChanged += HandleSection4NotApplicableToJobCheckBoxChecked;
            section5NotApplicableToJobCheckBox.CheckedChanged += HandleSection5NotApplicableToJobCheckBoxChecked;
            section6NotApplicableToJobCheckBox.CheckedChanged += HandleSection6NotApplicableToJobCheckBoxChecked;
            expandSection1ContentLinkLabel.Click += (sender, args) => ExpandSection1Clicked();
            expandSection2ContentLinkLabel.Click += (sender, args) => ExpandSection2Clicked();
            expandSection3ContentLinkLabel.Click += (sender, args) => ExpandSection3Clicked();
            expandSection4ContentLinkLabel.Click += (sender, args) => ExpandSection4Clicked();
            expandSection5ContentLinkLabel.Click += (sender, args) => ExpandSection5Clicked();
            expandSection6ContentLinkLabel.Click += (sender, args) => ExpandSection6Clicked();

            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;
        
        }


        ////ayman testing enable/disable waiting for approval button
        //protected virtual List<string> RemainingApprovals()
        //{
        //    var remainingApprovals =
        //        Approvals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
        //    remainingApprovals.RemoveAll(approvalString => approvalString == null);
        //    return remainingApprovals;
        //}

        private void HandleSection1NotApplicableToJobCheckBoxChecked(object sender, EventArgs e)
        {
            HideOrShowSectionContent(section1NotApplicableToJobCheckBox, GetSection1ContentRowStyle(), initialHeightOfSection1ContentRow);
            
            if (Section1NotApplicableToJobCheckedChanged != null)
            {
                Section1NotApplicableToJobCheckedChanged();
            }
        }

        private void HandleSection2NotApplicableToJobCheckBoxChecked(object sender, EventArgs e)
        {
            HideOrShowSectionContent(section2NotApplicableToJobCheckBox, GetSection2ContentRowStyle(), initialHeightOfSection2ContentRow);
            
            if (Section2NotApplicableToJobCheckedChanged != null)
            {
                Section2NotApplicableToJobCheckedChanged();
            }
        }

        private void HandleSection3NotApplicableToJobCheckBoxChecked(object sender, EventArgs e)
        {
            HideOrShowSectionContent(section3NotApplicableToJobCheckBox, GetSection3ContentRowStyle(), initialHeightOfSection3ContentRow);

            if (Section3NotApplicableToJobCheckedChanged != null)
            {
                Section3NotApplicableToJobCheckedChanged();
            }
        }

        private void HandleSection4NotApplicableToJobCheckBoxChecked(object sender, EventArgs e)
        {
            HideOrShowSectionContent(section4NotApplicableToJobCheckBox, GetSection4ContentRowStyle(), initialHeightOfSection4ContentRow);

            if (Section4NotApplicableToJobCheckedChanged != null)
            {
                Section4NotApplicableToJobCheckedChanged();
            }
        }

        private void HandleSection5NotApplicableToJobCheckBoxChecked(object sender, EventArgs e)
        {
            HideOrShowSectionContent(section5NotApplicableToJobCheckBox, GetSection5ContentRowStyle(), initialHeightOfSection5ContentRow);

            if (Section5NotApplicableToJobCheckedChanged != null)
            {
                Section5NotApplicableToJobCheckedChanged();
            }
        }

        private void HandleSection6NotApplicableToJobCheckBoxChecked(object sender, EventArgs e)
        {
            HideOrShowSectionContent(section6NotApplicableToJobCheckBox, GetSection6ContentRowStyle(), initialHeightOfSection6ContentRow);

            if (Section6NotApplicableToJobCheckedChanged != null)
            {
                Section6NotApplicableToJobCheckedChanged();
            }
        }

        private void HideOrShowSectionContent(CheckBox sectionNotApplicableToJobCheckBox, RowStyle rowStyle, float initialHeightOfSectionContentRow)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                mainTableLayoutPanel.Height = (int)(mainTableLayoutPanel.Height - Math.Floor(initialHeightOfSectionContentRow));
                rowStyle.Height = 0;
            }
            else
            {
                rowStyle.Height = initialHeightOfSectionContentRow;
                mainTableLayoutPanel.Height = (int)(mainTableLayoutPanel.Height + Math.Floor(initialHeightOfSectionContentRow));
            }
        }

        private RowStyle GetSection1ContentRowStyle()
        {
            return GetRowStyleForControlInMainTableLayoutPanel(section1ContentPanel);
        }

        private RowStyle GetSection2ContentRowStyle()
        {
            return GetRowStyleForControlInMainTableLayoutPanel(section2ContentPanel);
        }

        private RowStyle GetSection3ContentRowStyle()
        {
            return GetRowStyleForControlInMainTableLayoutPanel(section3ContentPanel);
        }

        private RowStyle GetSection4ContentRowStyle()
        {
            return GetRowStyleForControlInMainTableLayoutPanel(section4ContentPanel);
        }

        private RowStyle GetSection5ContentRowStyle()
        {
            return GetRowStyleForControlInMainTableLayoutPanel(section5ContentPanel);
        }

        private RowStyle GetSection6ContentRowStyle()
        {
            return GetRowStyleForControlInMainTableLayoutPanel(section6ContentPanel);
        }

        private RowStyle GetRowStyleForControlInMainTableLayoutPanel(Control control)
        {
            int row = mainTableLayoutPanel.GetRow(control);
            return mainTableLayoutPanel.RowStyles[row];
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            initialHeightOfSection1ContentRow = GetSection1ContentRowStyle().Height;
            initialHeightOfSection2ContentRow = GetSection2ContentRowStyle().Height;
            initialHeightOfSection3ContentRow = GetSection3ContentRowStyle().Height;
            initialHeightOfSection4ContentRow = GetSection4ContentRowStyle().Height;
            initialHeightOfSection5ContentRow = GetSection5ContentRowStyle().Height;
            initialHeightOfSection6ContentRow = GetSection6ContentRowStyle().Height;

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
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


        //ayman enable/disable waiting for approval button
        public void EnableWaitingApprovalButton()
        {
            waitingapprovalButton.Enabled = true;
            saveButton.Text = "Save as Draft";
        }

        public void DisableWaitingApprovalButton()
        {
            waitingapprovalButton.Enabled = false;
            saveButton.Text = "Save && Close";
        }



        public string JobDescription
        {
            get { return jobDescriptionTextBox.Text.TrimOrNull(); }
            set { jobDescriptionTextBox.Text = value; }
        }

        public string ReasonForCriticalLift
        {
            get { return reasonForCriticalLiftTextBox.Text.TrimOrNull(); }
            set { reasonForCriticalLiftTextBox.Text = value; }
        }

        public string Section1Content
        {
            get { return section1ContentRichTextEditor.Text.TrimOrNull(); }
            set { section1ContentRichTextEditor.Text = value; }
        }

        public string Section1PlainTextContent
        {
            get { return section1ContentRichTextEditor.PlainText.TrimOrNull(); }
        }

        public bool Section1NotApplicableToJob
        {
            get { return section1NotApplicableToJobCheckBox.Checked; }
            set { section1NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section2Content
        {
            get { return section2ContentRichTextEditor.Text.TrimOrNull(); }
            set { section2ContentRichTextEditor.Text = value; }
        }

        public string Section2PlainTextContent
        {
            get { return section2ContentRichTextEditor.PlainText.TrimOrNull(); }
        }

        public bool Section2NotApplicableToJob
        {
            get { return section2NotApplicableToJobCheckBox.Checked; }
            set { section2NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section3Content
        {
            get { return section3ContentRichTextEditor.Text.TrimOrNull(); }
            set { section3ContentRichTextEditor.Text = value; }
        }

        public string Section3PlainTextContent
        {
            get { return section3ContentRichTextEditor.PlainText; }
        }

        public bool Section3NotApplicableToJob
        {
            get { return section3NotApplicableToJobCheckBox.Checked; }
            set { section3NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section4Content
        {
            get { return section4ContentRichTextEditor.Text.TrimOrNull(); }
            set { section4ContentRichTextEditor.Text = value; }
        }

        public string Section4PlainTextContent
        {
            get { return section4ContentRichTextEditor.PlainText; }
        }

        public bool Section4NotApplicableToJob
        {
            get { return section4NotApplicableToJobCheckBox.Checked; }
            set { section4NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section5Content
        {
            get { return section5ContentRichTextEditor.Text.TrimOrNull(); }
            set { section5ContentRichTextEditor.Text = value; }
        }

        public string Section5PlainTextContent
        {
            get { return section5ContentRichTextEditor.PlainText; }
        }

        public bool Section5NotApplicableToJob
        {
            get { return section5NotApplicableToJobCheckBox.Checked; }
            set { section5NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section6Content
        {
            get { return section6ContentRichTextEditor.Text.TrimOrNull(); }
            set { section6ContentRichTextEditor.Text = value; }
        }

        public string Section6PlainTextContent
        {
            get { return section6ContentRichTextEditor.PlainText; }
        }

        public bool Section6NotApplicableToJob
        {
            get { return section6NotApplicableToJobCheckBox.Checked; }
            set { section6NotApplicableToJobCheckBox.Checked = value; }
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

        public List<FormApproval> Approvals
        {
            set { approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval)); }
            get
            {
                List<FormApprovalGridDisplayAdapter> list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this, initialUserFLOCSelections);

            IList<FunctionalLocation> selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult, new List<FunctionalLocation>(selectedFunctionalLocations));
        }

        public string DisplayExpandedContentForm(string text)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(text, false);
            expandedLogCommentForm.ShowDialog(this);
            string editedText = expandedLogCommentForm.TextEditorText;
            expandedLogCommentForm.Dispose();
            return editedText;
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.ValidToDateBeforeValidFromDate);
        }

        public void SetErrorForJobDescriptionRequired()
        {
            errorProvider.SetError(jobDescriptionTextBox, StringResources.FieldEmptyError);
        }

        public void SetErrorForReasonForCriticalLiftRequired()
        {
            errorProvider.SetError(reasonForCriticalLiftTextBox, StringResources.FieldEmptyError);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowFormWillNeedElectricalReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion_Electrical;
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

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (HistoryButtonClicked != null)
            {
                HistoryButtonClicked();
            }
        }

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
            ////ayman enable/disable waiting for approval button
            //waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
            //saveButton.Text = waitingapprovalButton.Enabled == true ? "Save as Draft" : "Save && Close";
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }
            ////ayman enable/disable waiting for approval button
            //waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
            //saveButton.Text = waitingapprovalButton.Enabled == true ? "Save as Draft" : "Save && Close";
        }

    }
}

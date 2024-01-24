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
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.Utils.Menu;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ProcedureDeviationForm : BaseForm, IProcedureDeviationFormView
    {
        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        private ProcedureDeviation procedureDeviation;

        private const string CompleteButtonText = "Complete Deviation";
        private const string CompleteAndRevertButtonText = "Complete && Revert back to Original";
        private const string CompleteAndPermanentRevisionButtonText = "Complete && Permanent Revision";

        public ProcedureDeviationForm()
        {
            InitializeComponent();

            causesValidationPlaceholderTextBox.Text = string.Empty;
            correctiveActionsValidationPlaceholderTextBox.Text = string.Empty;

            // This header panel keeps snapping 10 pixels narrower
            headerLinkPanel.Width = tableLayoutPanel1.Width;

            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            historyButton.Click += HandleHistoryButtonClicked;
            cancelDeviationButton.Click += HandleCancelDeviationButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            convertButton.Click += HandleConvertDeviationButtonClicked;

            var governingDocPrefixText = "This form is governed by:  ";
            var governingDocumentLinkText = "Deviations to Governing Documents RGP11007";
            governingDocumentLinkLabel.Text = governingDocPrefixText + governingDocumentLinkText;
            governingDocumentLinkLabel.Links.Add(governingDocPrefixText.Length, governingDocumentLinkText.Length,
                "http://ecm/ecmlivelinkprd/llisapi.dll?func=ll&objId=376595097&objAction=download&viewType=1");
            governingDocumentLinkLabel.LinkClicked += HandleGoverningDocumentLinkClicked;

            completeButton.Click += CompleteButtonOnClick;

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

            SetDeviationTypeCheckBoxHandlers();
            SetCorrectiveActionsFixDocumentDurationTypeCheckBoxHandlers();

            causeDeterminationWhyType4CheckBox.CheckedChanged += CauseDeterminationWhyType4CheckBoxOnCheckedChanged;
            correctiveActionHasILPNumberCheckBox.CheckedChanged += CorrectiveActionHasIlpNumberCheckBoxOnCheckedChanged;
            correctiveActionHasWorkRequestNumberCheckBox.CheckedChanged +=
                CorrectiveActionHasWorkRequestNumberCheckBoxOnCheckedChanged;
            correctiveActionHasOtherCommentsCheckBox.CheckedChanged +=
                CorrectiveActionHasOtherCommentsCheckBoxOnCheckedChanged;

            expandLinkLabel.Click += ExpandLinkLabelOnClick;

            scrollingPanel.MouseEnter += ScrollingPanelOnMouseEnter;

            approvalsGridControl.ImmediateApprovalSelected += HandleImmediateApprovalSelected;
            approvalsGridControl.ImmediateApprovalUnselected += HandleImmediateApprovalUnselected;
            approvalsGridControl.TemporaryApprovalSelected += HandleTemporaryApprovalSelected;
            approvalsGridControl.TemporaryApprovalUnselected += HandleTemporaryApprovalUnselected;
        }

        private void HandleGoverningDocumentLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link == null || e.Link.LinkData == null) return;

            var linkUrl = e.Link.LinkData.ToString();
            FileUtility.OpenFileOrDirectoryOrWebsite(linkUrl);
        }

        private void HandleConvertDeviationButtonClicked(object sender, EventArgs e)
        {
            if (ConvertDeviationButtonClicked != null)
            {
                ConvertDeviationButtonClicked();
            }
        }

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        public event Action HistoryClicked;
        public event Action CompleteButtonClicked;
        public event Action CompleteAndRevertButtonClicked;
        public event Action CompleteAndPermanentRevisionButtonClicked;
        public event Action CancelDeviationButtonClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action ConvertDeviationButtonClicked;
        public event Action WaitingApprovalButtonClicked; //swapnil test new
        public event Action FormLoad;

        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;

        public event Action<ProcedureDeviationFormApproval> ImmediateApprovalSelected;
        public event Action<ProcedureDeviationFormApproval> ImmediateApprovalUnselected;

        public event Action<ProcedureDeviationFormApproval> TemporaryApprovalSelected;
        public event Action<ProcedureDeviationFormApproval> TemporaryApprovalUnselected;

        public event Action ExpandClicked;

        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;

        public event Action ValidityDatesChanged;

        public event Action DeviationTypeChanged;

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            riskAssessmentControl.ClearErrorProviders();
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

        public ProcedureDeviationType ProcedureDeviationType
        {
            get
            {
                return immediateDeviationCheckBox.Checked
                    ? ProcedureDeviationType.Immediate
                    : ProcedureDeviationType.Temporary;
            }
            set
            {
                immediateDeviationCheckBox.Checked = value == ProcedureDeviationType.Immediate;
                temporaryDeviationCheckBox.Checked = value == ProcedureDeviationType.Temporary;
            }
        }

        public bool PermanentRevisionRequired { get; set; }

        public bool RevertedBackToOriginal { get; set; }

        public string OperatingProcedureNumber
        {
            get { return operatingProcedureNumberTextBox.Text; }
            set { operatingProcedureNumberTextBox.Text = value; }
        }

        public string OperatingProcedureTitle
        {
            get { return operatingProcedureTitleTextBox.Text; }
            set { operatingProcedureTitleTextBox.Text = value; }
        }

        public OperatingProcedureLevel OperatingProcedureLevel
        {
            get { return operatingProcedureLevelComboBox.SelectedItem as OperatingProcedureLevel; }
            set { operatingProcedureLevelComboBox.SelectedItem = value; }
        }

        public List<OperatingProcedureLevel> OperatingProcedureLevels
        {
            set
            {
                operatingProcedureLevelComboBox.DataSource = value;
                operatingProcedureLevelComboBox.DisplayMember = "Name";
            }
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

        public bool CauseDeterminationCauseSelected
        {
            get
            {
                return causeDeterminationWhyType1CheckBox.Checked || causeDeterminationWhyType2CheckBox.Checked ||
                       causeDeterminationWhyType3CheckBox.Checked || causeDeterminationWhyType4CheckBox.Checked;
            }
        }

        public List<CauseDeterminationWhyType> CauseDeterminationCauses
        {
            get
            {
                var causes = new List<CauseDeterminationWhyType>();

                if (causeDeterminationWhyType1CheckBox.Checked)
                    causes.Add(CauseDeterminationWhyType.DocumentIncorrect);
                if (causeDeterminationWhyType2CheckBox.Checked)
                    causes.Add(CauseDeterminationWhyType.EquipmentMalfunction);
                if (causeDeterminationWhyType3CheckBox.Checked)
                    causes.Add(CauseDeterminationWhyType.UnexpectedConditions);
                if (causeDeterminationWhyType4CheckBox.Checked)
                    causes.Add(CauseDeterminationWhyType.Other);

                return causes;
            }

            set
            {
                if (value != null && !value.IsEmpty())
                {
                    causeDeterminationWhyType1CheckBox.Checked =
                        value.Contains(CauseDeterminationWhyType.DocumentIncorrect);
                    causeDeterminationWhyType2CheckBox.Checked =
                        value.Contains(CauseDeterminationWhyType.EquipmentMalfunction);
                    causeDeterminationWhyType3CheckBox.Checked =
                        value.Contains(CauseDeterminationWhyType.UnexpectedConditions);
                    causeDeterminationWhyType4CheckBox.Checked = value.Contains(CauseDeterminationWhyType.Other);
                }
                else
                {
                    causeDeterminationWhyType1CheckBox.Checked = false;
                    causeDeterminationWhyType2CheckBox.Checked = false;
                    causeDeterminationWhyType3CheckBox.Checked = false;
                    causeDeterminationWhyType4CheckBox.Checked = false;
                }
            }
        }

        public string CauseDeterminationComments
        {
            get { return causeDeterminationCommentsTextBox.Text; }
            set { causeDeterminationCommentsTextBox.Text = value; }
        }

        public bool FixDocumentDurationTypeSelected
        {
            get { return fixDocumentDurationType1CheckBox.Checked || fixDocumentDurationType2CheckBox.Checked; }
        }

        public CorrectiveActionFixDocumentDurationType FixDocumentDurationType
        {
            get
            {
                var selectedValue =
                    CorrectiveActionFixDocumentDurationType.DeviationDurationOnly;

                if (fixDocumentDurationType1CheckBox.Checked)
                    selectedValue = CorrectiveActionFixDocumentDurationType.DeviationDurationOnly;
                if (fixDocumentDurationType2CheckBox.Checked)
                    selectedValue =
                        CorrectiveActionFixDocumentDurationType.DeviationDurationAndPermanentRevisionRequired;

                return selectedValue;
            }
            set
            {
                fixDocumentDurationType1CheckBox.Checked = value ==
                                                           CorrectiveActionFixDocumentDurationType.DeviationDurationOnly;
                fixDocumentDurationType2CheckBox.Checked = value ==
                                                           CorrectiveActionFixDocumentDurationType
                                                               .DeviationDurationAndPermanentRevisionRequired;
            }
        }

        public bool HasCorrectiveActionIlpNumber
        {
            get { return correctiveActionHasILPNumberCheckBox.Checked; }
            set { correctiveActionHasILPNumberCheckBox.Checked = value; }
        }

        public string CorrectiveActionIlpNumber
        {
            get { return correctiveActionIlpNumberTextBox.Text; }
            set { correctiveActionIlpNumberTextBox.Text = value; }
        }

        public bool HasCorrectiveActionWorkRequestNumber
        {
            get { return correctiveActionHasWorkRequestNumberCheckBox.Checked; }
            set { correctiveActionHasWorkRequestNumberCheckBox.Checked = value; }
        }

        public string CorrectiveActionWorkRequestNumber
        {
            get { return correctiveActionWorkRequestNumberTextBox.Text; }
            set { correctiveActionWorkRequestNumberTextBox.Text = value; }
        }

        public bool HasCorrectiveActionOtherComments
        {
            get { return correctiveActionHasOtherCommentsCheckBox.Checked; }
            set { correctiveActionHasOtherCommentsCheckBox.Checked = value; }
        }

        public string CorrectiveActionOtherComments
        {
            get { return correctiveActionOtherCommentsTextBox.Text; }
            set { correctiveActionOtherCommentsTextBox.Text = value; }
        }

        public ProcedureDeviation ProcedureDeviation
        {
            set
            {
                SuspendLayout();

                procedureDeviation = value;

                ResumeLayout(false);
                PerformLayout();
            }
        }

        public bool EnableDeviationType
        {
            set
            {
                immediateDeviationCheckBox.AutoCheck = value;
                temporaryDeviationCheckBox.AutoCheck = value;
            }
        }

        public bool EnableCompleteButton
        {
            set { completeButton.Visible = value; }
        }

        public bool EnableCancelDeviationButton
        {
            set { cancelDeviationButton.Visible = value; }
        }

        public bool EnableConvertDeviationButton
        {
            set { convertButton.Visible = value; }
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

        public List<string> ImmediateApprovalsObtainedViaList
        {
            set { approvalsGridControl.ImmediateApprovalsObtainedViaList = value; }
        }

        public void SetErrorForTechnicalSMERequired()
        {
            riskAssessmentControl.SetErrorForTechnicalSMERequired();
        }

        public void SetErrorForValidFromIsBeforeCreatedDateTime()
        {
            errorProvider.SetError(validFromDatePicker, StringResources.StartDateCannotBeBeforeCreatedDate);
        }

        public void SetErrorForValidFromIsInThePast()
        {
            errorProvider.SetError(validFromDatePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForValidToIsBeforeCreatedDateTime()
        {
            errorProvider.SetError(validToDatePicker, StringResources.EndDateCannotBeBeforeCreatedDate);
        }

        public void SetErrorForValidToIsInThePast()
        {
            errorProvider.SetError(validToDatePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validFromTimePicker, StringResources.StartDateBeforeEndDate);
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForLocationEquipmentNumberNotSet()
        {
            errorProvider.SetError(locationEquipmentTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForOperatingProcedureNumberNotSet()
        {
            errorProvider.SetError(operatingProcedureNumberTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForOperatingProcedureTitleNotSet()
        {
            errorProvider.SetError(operatingProcedureTitleTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForOperatingProcedureLevelNotSet()
        {
            errorProvider.SetError(operatingProcedureLevelComboBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForDescriptionNotSet()
        {
            errorProvider.SetError(descriptionRichTextEditor, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorWhy1ReasonNotSet()
        {
            errorProvider.SetError(causesValidationPlaceholderTextBox, StringResources.ReasonMustBeSelected);
        }

        public void SetErrorCauseDeterminationCommentsNotSet()
        {
            errorProvider.SetError(causeDeterminationCommentsTextBox,
                StringResources.CommentsRequiredIfOtherSelected);
        }

        public void SetErrorCorrectiveActionNotSet()
        {
            errorProvider.SetError(correctiveActionsValidationPlaceholderTextBox, StringResources.CorrectiveActionMustBeSelected);
        }

        public void SetErrorCorrectiveActionIlpNumberNotSet()
        {
            errorProvider.SetError(correctiveActionIlpNumberTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorCorrectiveActionWorkRequestNumberNotSet()
        {
            errorProvider.SetError(correctiveActionWorkRequestNumberTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorCorrectiveActionOtherCommentsNotSet()
        {
            errorProvider.SetError(correctiveActionOtherCommentsTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForRiskAssessmentAnswer1NotSet()
        {
            riskAssessmentControl.SetErrorForAnswer1NotSet();
        }

        public void SetErrorForRiskAssessmentAnswer2NotSet()
        {
            riskAssessmentControl.SetErrorForAnswer2NotSet();
        }

        public void SetErrorForRiskAssessmentAnswer3NotSet()
        {
            riskAssessmentControl.SetErrorForAnswer3NotSet();
        }

        public void SetErrorForRiskAssessmentAnswer4NotSet()
        {
            riskAssessmentControl.SetErrorForAnswer4NotSet();
        }

        public void SetErrorForRiskAssessmentAnswer5NotSet()
        {
            riskAssessmentControl.SetErrorForAnswer5NotSet();
        }

        public void SetErrorForRiskAssessmentCommentsNotSet()
        {
            riskAssessmentControl.SetErrorForCommentsNotSet();
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        // We use 2 sets of specific approvals instead of the generic IFormView Approvals
        public List<FormApproval> Approvals { get; set; }

        public List<ProcedureDeviationFormApproval> ImmediateApprovals
        {
            set
            {
                var items = value.ConvertAll(approval => new ProcedureDeviationFormApprovalGridDisplayAdapter(approval));
                approvalsGridControl.ImmediateApprovalItems = items;
            }
            get
            {
                if (approvalsGridControl.ImmediateApprovalItems == null)
                    return new List<ProcedureDeviationFormApproval>();

                var list =
                    new List<ProcedureDeviationFormApprovalGridDisplayAdapter>(
                        approvalsGridControl.ImmediateApprovalItems);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public List<ProcedureDeviationFormApproval> TemporaryApprovals
        {
            set
            {
                var items = value.ConvertAll(approval => new ProcedureDeviationFormApprovalGridDisplayAdapter(approval));
                approvalsGridControl.TemporaryApprovalItems = items;
            }
            get
            {
                if (approvalsGridControl.TemporaryApprovalItems == null)
                    return new List<ProcedureDeviationFormApproval>();

                var list =
                    new List<ProcedureDeviationFormApprovalGridDisplayAdapter>(
                        approvalsGridControl.TemporaryApprovalItems);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public bool AffectsToe
        {
            get { return riskAssessmentControl.AffectsToe; }
            set { riskAssessmentControl.AffectsToe = value; }
        }

        public List<ProcedureDeviationFormAttendee> RiskAssessmentAttendees
        {
            get
            {
                if (riskAssessmentControl.RiskAssessmentAttendeeItems == null)
                    return new List<ProcedureDeviationFormAttendee>();

                var list =
                    new List<ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter>(
                        riskAssessmentControl.RiskAssessmentAttendeeItems);
                return list.ConvertAll(adapter => adapter.GetAttendee());
            }
            set
            {
                var items =
                    value.ConvertAll(
                        attendee => new ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter(attendee));
                riskAssessmentControl.RiskAssessmentAttendeeItems = items;
            }
        }

        public bool RiskAssessmentAnswer1
        {
            get { return riskAssessmentControl.Answer1; }
            set { riskAssessmentControl.Answer1 = value; }
        }

        public bool RiskAssessmentAnswer2
        {
            get { return riskAssessmentControl.Answer2; }
            set { riskAssessmentControl.Answer2 = value; }
        }

        public bool RiskAssessmentAnswer3
        {
            get { return riskAssessmentControl.Answer3; }
            set { riskAssessmentControl.Answer3 = value; }
        }

        public bool RiskAssessmentAnswer4
        {
            get { return riskAssessmentControl.Answer4; }
            set { riskAssessmentControl.Answer4 = value; }
        }

        public bool RiskAssessmentAnswer5
        {
            get { return riskAssessmentControl.Answer5; }
            set { riskAssessmentControl.Answer5 = value; }
        }

        public string RiskAssessmentComments
        {
            get { return riskAssessmentControl.Comments; }
            set { riskAssessmentControl.Comments = value; }
        }

        public bool HasAtLeastOneRiskAssessmentYesAnswer
        {
            get { return riskAssessmentControl.HasAtLeastOneYesAnswer; }
        }

        public bool RiskAssessmentAnswer1NotSet
        {
            get { return !riskAssessmentControl.Answer1Checked; }
        }

        public bool RiskAssessmentAnswer2NotSet
        {
            get { return !riskAssessmentControl.Answer2Checked; }
        }

        public bool RiskAssessmentAnswer3NotSet
        {
            get { return !riskAssessmentControl.Answer3Checked; }
        }

        public bool RiskAssessmentAnswer4NotSet
        {
            get { return !riskAssessmentControl.Answer4Checked; }
        }

        public bool RiskAssessmentAnswer5NotSet
        {
            get { return !riskAssessmentControl.Answer5Checked; }
        }

        public void ResetRiskAssessmentAnswers()
        {
            riskAssessmentControl.ResetAnswers();
        }

        private void HandleImmediateApprovalSelected(ProcedureDeviationFormApproval immediateApproval)
        {
            if (ImmediateApprovalSelected != null)
            {
                ImmediateApprovalSelected(immediateApproval);
            }
        }

        private void HandleImmediateApprovalUnselected(ProcedureDeviationFormApproval immediateApproval)
        {
            if (ImmediateApprovalUnselected != null)
            {
                ImmediateApprovalUnselected(immediateApproval);
            }
        }

        private void HandleTemporaryApprovalSelected(ProcedureDeviationFormApproval temporaryApproval)
        {
            if (TemporaryApprovalSelected != null)
            {
                TemporaryApprovalSelected(temporaryApproval);
            }
        }

        private void HandleTemporaryApprovalUnselected(ProcedureDeviationFormApproval temporaryApproval)
        {
            if (TemporaryApprovalUnselected != null)
            {
                TemporaryApprovalUnselected(temporaryApproval);
            }
        }

        private void CompleteButtonOnClick(object sender, EventArgs e)
        {
            if (fixDocumentDurationType1CheckBox.Checked)
            {
                if (CompleteAndRevertButtonClicked != null)
                {
                    CompleteAndRevertButtonClicked();
                }
            }
            else if (fixDocumentDurationType2CheckBox.Checked)
            {
                if (CompleteAndPermanentRevisionButtonClicked != null)
                {
                    CompleteAndPermanentRevisionButtonClicked();
                }
            }
            else
            {
                if (CompleteButtonClicked != null)
                {
                    CompleteButtonClicked();
                }
            }
        }

        private void CorrectiveActionHasOtherCommentsCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            correctiveActionOtherCommentsTextBox.Enabled = correctiveActionHasOtherCommentsCheckBox.Checked;
        }

        private void CorrectiveActionHasWorkRequestNumberCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            correctiveActionWorkRequestNumberTextBox.Enabled = correctiveActionHasWorkRequestNumberCheckBox.Checked;
        }

        private void CorrectiveActionHasIlpNumberCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            correctiveActionIlpNumberTextBox.Enabled = correctiveActionHasILPNumberCheckBox.Checked;
        }

        private void CauseDeterminationWhyType4CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            causeDeterminationCommentsTextBox.Enabled = causeDeterminationWhyType4CheckBox.Checked;
        }

        private void SetDeviationTypeCheckBoxHandlers()
        {
            immediateDeviationCheckBox.CheckedChanged += DeviationTypeCheckBoxOnCheckedChanged;
            temporaryDeviationCheckBox.CheckedChanged += DeviationTypeCheckBoxOnCheckedChanged;
        }

        private void RemoveDeviationTypeCheckBoxHandlers()
        {
            immediateDeviationCheckBox.CheckedChanged -= DeviationTypeCheckBoxOnCheckedChanged;
            temporaryDeviationCheckBox.CheckedChanged -= DeviationTypeCheckBoxOnCheckedChanged;
        }

        private void DeviationTypeCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveDeviationTypeCheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in deviationTypePanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetDeviationTypeCheckBoxHandlers();

                if (DeviationTypeChanged != null)
                {
                    DeviationTypeChanged();
                }
            }
        }

        private void SetCauseDeterminationWhy1CheckBoxHandlers()
        {
            causeDeterminationWhyType1CheckBox.CheckedChanged += CauseDeterminationWhy1CheckBoxOnCheckedChanged;
            causeDeterminationWhyType2CheckBox.CheckedChanged += CauseDeterminationWhy1CheckBoxOnCheckedChanged;
            causeDeterminationWhyType3CheckBox.CheckedChanged += CauseDeterminationWhy1CheckBoxOnCheckedChanged;
            causeDeterminationWhyType4CheckBox.CheckedChanged += CauseDeterminationWhy1CheckBoxOnCheckedChanged;
        }

        private void RemoveCauseDeterminationWhy1CheckBoxHandlers()
        {
            causeDeterminationWhyType1CheckBox.CheckedChanged -= CauseDeterminationWhy1CheckBoxOnCheckedChanged;
            causeDeterminationWhyType2CheckBox.CheckedChanged -= CauseDeterminationWhy1CheckBoxOnCheckedChanged;
            causeDeterminationWhyType3CheckBox.CheckedChanged -= CauseDeterminationWhy1CheckBoxOnCheckedChanged;
            causeDeterminationWhyType4CheckBox.CheckedChanged -= CauseDeterminationWhy1CheckBoxOnCheckedChanged;
        }

        private void CauseDeterminationWhy1CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveCauseDeterminationWhy1CheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in causeDeterminationPanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetCauseDeterminationWhy1CheckBoxHandlers();
            }
        }

        private void SetCorrectiveActionsFixDocumentDurationTypeCheckBoxHandlers()
        {
            fixDocumentDurationType1CheckBox.CheckedChanged +=
                CorrectiveActionsFixDocumentDurationTypeCheckBoxOnCheckedChanged;
            fixDocumentDurationType2CheckBox.CheckedChanged +=
                CorrectiveActionsFixDocumentDurationTypeCheckBoxOnCheckedChanged;
        }

        private void RemoveCorrectiveActionsFixDocumentDurationTypeCheckBoxHandlers()
        {
            fixDocumentDurationType1CheckBox.CheckedChanged -=
                CorrectiveActionsFixDocumentDurationTypeCheckBoxOnCheckedChanged;
            fixDocumentDurationType2CheckBox.CheckedChanged -=
                CorrectiveActionsFixDocumentDurationTypeCheckBoxOnCheckedChanged;
        }

        private void CorrectiveActionsFixDocumentDurationTypeCheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveCorrectiveActionsFixDocumentDurationTypeCheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in correctiveActionsFixDocumentDurationTypePanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }

                if (currentSelectedCheckBox == fixDocumentDurationType1CheckBox)
                {
                    completeButton.Text = CompleteAndRevertButtonText;
                }
                else if (currentSelectedCheckBox == fixDocumentDurationType2CheckBox)
                {
                    completeButton.Text = CompleteAndPermanentRevisionButtonText;
                }
                else
                {
                    completeButton.Text = CompleteButtonText;
                }
            }
            finally
            {
                SetCorrectiveActionsFixDocumentDurationTypeCheckBoxHandlers();
            }
        }

        private void ExpandLinkLabelOnClick(object sender, EventArgs eventArgs)
        {
            if (ExpandClicked != null)
            {
                ExpandClicked();
            }
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








        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {
           
        }

        public void DisableWaitingForApprovalButton()
        {
           
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

        private void HandleCancelDeviationButtonClicked(object sender, EventArgs e)
        {
            if (CancelDeviationButtonClicked != null)
            {
                CancelDeviationButtonClicked();
            }
        }
    }
}
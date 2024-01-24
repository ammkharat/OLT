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
    public partial class PermitAssessmentForm : BaseForm, IPermitAssessmentFormView
    {
        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        private PermitAssessment permitAssessment;

        public PermitAssessmentForm()
        {
            // for some reason this gets wacked in the designer all the time
            jobDescriptionTextBox = new OltSpellCheckTextBox(components);

            // if the designer complains about components not initialized, add 
            // this code to the beginning of the InitializeComponent() method:
            // this.components = new System.ComponentModel.Container();

            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            historyButton.Click += HandleHistoryButtonClicked;

            var userContext = ClientSession.GetUserContext();
            var rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(userContext.SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1,
                        rootFlocsForActiveSelection),
                    true, rootFlocsForActiveSelection);

            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocatnButton.Click += HandleRemoveFunctionalLocationButtonClicked;
            issuedToContractorCheckBox.CheckedChanged += HandleIssuedToContractorCheckedChanged;

            questionnaireComboBox.MouseWheel += QuestionnaireComboBoxOnMouseWheel;
            questionnaireComboBox.SelectedValueChanged += QuestionnaireComboBoxOnSelectedValueChanged;

            scrollingPanel.MouseEnter += ScrollingPanelOnMouseEnter;

            Resize += OnResize;
        }

        public DateTime ValidTo
        {
            get
            {
                var date = permitExpiredDatePicker.Value;
                var time = permitExpiredTimePicker.Value;

                return date.CreateDateTime(time);
            }
            set
            {
                permitExpiredDatePicker.Value = new Date(value);
                permitExpiredTimePicker.Value = new Time(value);
            }
        }

        public bool? IsIlpRecommended
        {
            get
            {
                if (yesIlpRecommendedRadioButton.Checked) return true;
                if (noIlpRecommendedRadioButton.Checked) return false;
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    yesIlpRecommendedRadioButton.Checked = value.Value;
                    noIlpRecommendedRadioButton.Checked = !value.Value;
                }
                else
                {
                    yesIlpRecommendedRadioButton.Checked = false;
                    noIlpRecommendedRadioButton.Checked = false;
                }
            }
        }

        public DateTime ValidFrom
        {
            get
            {
                var date = permitStartDatePicker.Value;
                var time = permitStartTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                permitStartDatePicker.Value = new Date(value);
                permitStartTimePicker.Value = new Time(value);
            }
        }

        public string Content { get; set; }

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        public event Action FormLoad;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action ExpandClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action ValidityDatesChanged;
        public event Action QuestionnaireConfigurationChanged;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
        public bool EnableWaitingForApproval { get; set; }//mangesh - waiting for approval

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
        }


        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(permitExpiredTimePicker,
                StringResources.ExpiredDateBeforeStartDate);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            return new DialogResult();
        }

        public void SetErrorForValidToIsInThePast()
        {
            errorProvider.SetError(permitExpiredDatePicker, StringResources.BackInServiceDateInPast);
        }

        public string LocationEquipmentNumber
        {
            get { return locationEquipmentTextBox.Text; }
            set { locationEquipmentTextBox.Text = value; }
        }

        public string PermitNumber
        {
            get { return permitNumberTextBox.Text; }
            set { permitNumberTextBox.Text = value; }
        }

        public string Contractor
        {
            get { return PermitFormHelper.GetTextComboBoxValue(contractorComboBox, issuedToContractorCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, contractorComboBox, issuedToContractorCheckBox); }
        }

        public string Trade
        {
            get { return tradeComboBox.Text; }
            set { tradeComboBox.Text = value; }
        }

        public OilsandsWorkPermitType PermitType
        {
            get { return permitTypeComboBox.SelectedItem as OilsandsWorkPermitType; }
            set { permitTypeComboBox.SelectedItem = value; }
        }

        public int CrewSize
        {
            get { return (int) crewSizeNumericUpDown.Value; }
            set { crewSizeNumericUpDown.Value = value; }
        }

        public string JobDescription
        {
            get { return jobDescriptionTextBox.Text; }
            set { jobDescriptionTextBox.Text = value; }
        }

        public bool IssuedToSuncor
        {
            get { return issuedToSuncorCheckBox.Checked; }
            set { issuedToSuncorCheckBox.Checked = value; }
        }

        public bool IssuedToContractor
        {
            get { return issuedToContractorCheckBox.Checked; }
            set { issuedToContractorCheckBox.Checked = value; }
        }

        public string JobCoordinator
        {
            get { return jobCoordinatorTextBox.Text; }
            set { jobCoordinatorTextBox.Text = value; }
        }

        public List<OilsandsWorkPermitType> OilsandsWorkPermitTypes
        {
            set
            {
                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";
            }
        }

        public List<Contractor> Contractors
        {
            set
            {
                contractorComboBox.DataSource = value;
                contractorComboBox.DisplayMember = "Name";
            }
        }

        public List<CraftOrTrade> Trades
        {
            set
            {
                tradeComboBox.DataSource = value;
                tradeComboBox.DisplayMember = "Name";
            }
        }

        public List<QuestionnaireConfigurationDTO> QuestionnaireConfigurations
        {
            set
            {
                questionnaireComboBox.DataSource = value;
                questionnaireComboBox.DisplayMember = "Name";
            }
        }

        public QuestionnaireConfigurationDTO SelectedQuestionnaireConfiguration
        {
            get { return questionnaireComboBox.SelectedItem as QuestionnaireConfigurationDTO; }
            set { questionnaireComboBox.SelectedItem = value; }
        }

        public bool EnableQuestionnaireSelection
        {
            set { questionnaireComboBox.Enabled = value; }
        }

        public PermitAssessment PermitAssessment
        {
            set
            {
                SuspendLayout();

                permitAssessment = value;
                permitAssessmentControl.PermitAssessment = value;

                if (value == null || value.QuestionnaireName.IsNullOrEmpty())
                {
                    permitAssessmentControl.Visible = false;
                    assessmentPanel.Visible = false;
                }
                else
                {
                    permitAssessmentControl.Visible = true;
                    assessmentPanel.Visible = true;
                    assessmentPanel.Height = permitAssessmentControl.Height;
                }

                buttonsPanel.Top = assessmentPanel.Top + assessmentPanel.Height;

                ResumeLayout(false);
                PerformLayout();
            }
        }

        public void SetQuestionnaireConfigurationNotSelectedError()
        {
            errorProvider.SetError(questionnaireComboBox, StringResources.QuestionnaireNotSelected);
        }

        public void SetPermitNumberNotSelectedError()
        {
            errorProvider.SetError(permitNumberTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetPermitTypeNotSelectedError()
        {
            errorProvider.SetError(permitTypeComboBox, StringResources.PermitTypeNotSelected);
        }

        public void SetTradeNotSelectedError()
        {
            errorProvider.SetError(tradeComboBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetLocationEquipmentNumberNotSetError()
        {
            errorProvider.SetError(locationEquipmentTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetCrewSizeNotSetError()
        {
            errorProvider.SetError(crewSizeNumericUpDown, StringResources.FieldCannotBeZero);
        }

        public void SetJobDescriptionNotSetError()
        {
            errorProvider.SetError(jobDescriptionTextBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetIssuedToNotSetError()
        {
            errorProvider.SetError(contractorComboBox, StringResources.IssuedToNotSelected);
        }

        public void SetContractorNotSelectedError()
        {
            errorProvider.SetError(contractorComboBox, StringResources.ContractorNotSelected);
        }

        public void SetJobCoordinatorNotSetError()
        {
            errorProvider.SetError(jobCoordinatorTextBox, StringResources.FieldCannotBeEmpty);
        }

        public string PlainTextContent { get; private set; }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public List<FormApproval> Approvals { get; set; }

        private void HandleHistoryButtonClicked(object sender, EventArgs e)
        {
            if (HistoryClicked != null)
            {
                HistoryClicked();
            }
        }

        public event Action HistoryClicked;

        private void OnResize(object sender, EventArgs eventArgs)
        {
            PermitAssessment = permitAssessment;
        }

        private void ScrollingPanelOnMouseEnter(object sender, EventArgs eventArgs)
        {
            scrollingPanel.Focus();
        }

        private void QuestionnaireComboBoxOnMouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs) e).Handled = true;
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

        private void QuestionnaireComboBoxOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (QuestionnaireConfigurationChanged != null)
            {
                QuestionnaireConfigurationChanged();
            }
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleIssuedToContractorCheckedChanged(object sender, EventArgs e)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
        }



        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {

        }

        public void DisableWaitingForApprovalButton()
        {

        }



        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }
    }
}
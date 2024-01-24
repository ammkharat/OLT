using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class TargetDefinitionForm : BaseForm, ITargetDefinitionFormView
    {
        private static readonly string freqLabelText = string.Format("{0} ",
            StringResources.TargetDefinitionForm_FrequencyLabelText);

        private ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;
        private ITagSearchFormView tagSelectorFormView;
        private ITargetAssociationSelectionView targetAssociationSelectionForm;

        public TargetDefinitionForm() : this(null)
        {
        }

        public TargetDefinitionForm(TargetDefinition editTargetDefinition)
        {
            Initialize(editTargetDefinition);
            var presenter = CreatePresenter(editTargetDefinition);
            RegisterEventHandlersOnPresenter(presenter);
        }

        public DialogResult ShowFunctionalLocationSelector()
        {
            return functionalLocationSelectorForm.ShowDialog(this);
        }

        public DialogResultAndOutput<TagInfo> ShowTagSelector()
        {
            return new DialogResultAndOutput<TagInfo>(tagSelectorFormView.ShowDialog(this),
                tagSelectorFormView.SelectedTag);
        }

        public TargetDefinition ShowConfigurePreApprovedTargetRangesForm(TargetDefinition targetDefinition)
        {
            var form = new ConfigurePreApprovedTargetRangesForm(targetDefinition);
            if (form.ShowDialog(this) == DialogResult.OK)
                return form.TargetDefinition;

            return targetDefinition;
        }

        public bool PreApprovedTargetRangesWarningIsVisible
        {
            get { return preApprovedTargetRangesNotificationPictureBox.Visible; }
            set { preApprovedTargetRangesNotificationPictureBox.Visible = value; }
        }

        public string PreApprovedTargetRangesWarning
        {
            set { toolTip.SetToolTip(preApprovedTargetRangesNotificationPictureBox, value); }
        }

        public bool NameChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, nameGroupBox); }
        }

        public bool CategoryChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, categoryGroupBox); }
        }

        public bool OperationalModeChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, operationalGroupBox); }
        }

        public bool PriorityChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, prioritiesGroupBox); }
        }

        public bool DescriptionChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, descriptionGroupBox); }
        }

        public bool DocumentLinksChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, documentLinksGroupBox); }
        }

        public bool FunctionalLocationChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, flocGroupBox); }
        }

        public bool PHTagChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, tagGroupBox); }
        }

        public bool TargetDependenciesChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, targetDependencyGroupBox); }
        }

        public bool ScheduleChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, schedulingLine); }
        }

        public bool GenerateActionItemChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, generateActionItemChkBox); }
        }

        public bool RequiresResponseWhenAlertedChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, requiresResponseWhenAlertedCheckBox); }
        }

        public bool SuppressAlertChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, suppressAlertCheckBox); }
        }

        public bool MinValueChangeAlwaysRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, valuesGroupBox,
                    StringResources.EditingOutsidePreapprovedRangesRequiresApproval);
            }
        }

        public bool MaxValueChangeAlwaysRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, valuesGroupBox,
                    StringResources.EditingOutsidePreapprovedRangesRequiresApproval);
            }
        }

        public bool NeverToExceedMinValueChangeAlwaysRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, valuesGroupBox,
                    StringResources.EditingOutsidePreapprovedRangesRequiresApproval);
            }
        }

        public bool NeverToExceedMaxValueChangeAlwaysRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, valuesGroupBox,
                    StringResources.EditingOutsidePreapprovedRangesRequiresApproval);
            }
        }

        public string TagValue
        {
            set { tagValueTextBox.Text = value; }
        }

        public bool TagValueEnabled
        {
            set { refreshTagValueButton.Enabled = value; }
        }
        
        public bool OperationalModeEnabled
        {
            set { operationalModeComboBox.Enabled = value; }
        }

        public FunctionalLocation UserSelectedFunctionalLocation
        {
            get { return functionalLocationSelectorForm.SelectedFunctionalLocation; }
        }

        public DialogResult ShowTargetDefinitionSelector()
        {
            targetAssociationSelectionForm.AssociatedTargets = DependentTargetDefinitions;
            return targetAssociationSelectionForm.ShowDialog(this);
        }

        public void ShowActionItemDefinitionForm(ActionItemDefinition actionItemDefinition)
        {
            var aidForm = new ActionItemDefinitionForm(actionItemDefinition);
            aidForm.ShowDialog(this);
        }

        public List<TargetDefinitionDTO> DependentTargetDefinitions
        {
            get { return associatedTargetDefinitionListBox.DataSource as List<TargetDefinitionDTO>; }
            set { associatedTargetDefinitionListBox.DataSource = value; }
        }

        public List<TargetDefinitionDTO> UserSelectedDependentTargetDefinitions
        {
            get { return new List<TargetDefinitionDTO>(targetAssociationSelectionForm.AssociatedTargets); }
        }

        public List<ScheduleType> ScheduleTypes
        {
            set { schedulePicker.AllowedScheduleTypes = value; }
        }

        public List<TargetCategory> TargetCategories
        {
            set { targetCategoryComboBox.DataSource = value; }
        }

        public List<WorkAssignment> WorkAssignments
        {
            set { workAssignmentComboBox.DataSource = value; }
        }

        public List<Priority> Priorities
        {
            set { priorityComboBox.DataSource = value; }
        }

        public Priority Priority
        {
            get { return priorityComboBox.SelectedItem as Priority; }
            set { priorityComboBox.SelectedItem = value; }
        }

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime CreateDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
            get { return lastModifiedDateAuthorHeader.LastModifiedDate; }
        }

        public bool RequiresApprovalEnabled
        {
            set { requiresApprovalCheckBox.Enabled = value; }
        }

        public new string Name
        {
            get { return nameTextBox.Text.Trim(); }
            set { nameTextBox.Text = value; }
        }

        public ISchedule Schedule
        {
            get { return schedulePicker.Schedule; }
            set { schedulePicker.Schedule = value; }
        }

        public decimal? NeverToExceedMinimum
        {
            get { return neverToExceedMinValueAndFrequencyBoxes.Value; }
            set { neverToExceedMinValueAndFrequencyBoxes.Value = value; }
        }

        public decimal? NeverToExceedMaximum
        {
            get { return neverToExceedMaxValueAndFrequencyBoxes.Value; }
            set { neverToExceedMaxValueAndFrequencyBoxes.Value = value; }
        }

        public int NeverToExceedMaximumFrequency
        {
            get { return neverToExceedMaxValueAndFrequencyBoxes.Frequency; }
            set { neverToExceedMaxValueAndFrequencyBoxes.Frequency = value; }
        }

        public int NeverToExceedMinimumFrequency
        {
            get { return neverToExceedMinValueAndFrequencyBoxes.Frequency; }
            set { neverToExceedMinValueAndFrequencyBoxes.Frequency = value; }
        }

        public decimal? MaxValue
        {
            get { return maxValueAndFrequencyBoxes.Value; }
            set { maxValueAndFrequencyBoxes.Value = value; }
        }

        public decimal? MinValue
        {
            get { return minValueAndFrequencyBoxes.Value; }
            set { minValueAndFrequencyBoxes.Value = value; }
        }

        public int MaxValueFrequency
        {
            get { return maxValueAndFrequencyBoxes.Frequency; }
            set { maxValueAndFrequencyBoxes.Frequency = value; }
        }

        public int MinValueFrequency
        {
            get { return minValueAndFrequencyBoxes.Frequency; }
            set { minValueAndFrequencyBoxes.Frequency = value; }
        }

        public bool TargetSetToMinimize
        {
            get { return targetValueControl.MinimizeTarget; }
        }

        public bool TargetSetToMaximize
        {
            get { return targetValueControl.MaximizeTarget; }
        }

        public void SetTargetToMinimize()
        {
            targetValueControl.SetTargetToMinimize();
        }

        public void SetTargetToMaximize()
        {
            targetValueControl.SetTargetToMaximize();
        }

        public decimal? TargetValue
        {
            get { return targetValueControl.TargetValue; }
            set { targetValueControl.TargetValue = value; }
        }

        public decimal? GapUnitValue
        {
            get { return gapUnitValueNumericBox.DecimalValueOrNull; }
            set
            {
                if (value == null)
                {
                    gapUnitValueNumericBox.Value = null;
                }
                else
                {
                    gapUnitValueNumericBox.Value = (double) value.Value;
                }
            }
        }

        public string Description
        {
            get { return descriptionTextBox.Text.Trim(); }
            set { descriptionTextBox.Text = value; }
        }

        public bool IsActive
        {
            get { return !temporarilyInactiveCheckBox.Checked; }
            set { temporarilyInactiveCheckBox.Checked = !value; }
        }

        public bool GenerateActionItem
        {
            get { return generateActionItemChkBox.Checked; }
            set { generateActionItemChkBox.Checked = value; }
        }

        public bool RequiresApproval
        {
            get { return requiresApprovalCheckBox.Checked; }
            set { requiresApprovalCheckBox.Checked = value; }
        }

        public bool RequiresResponseWhenAlerted
        {
            get { return requiresResponseWhenAlertedCheckBox.Checked; }
            set { requiresResponseWhenAlertedCheckBox.Checked = value; }
        }

        public bool RequiresResponseWhenAlertedEnabled
        {
            get { return requiresResponseWhenAlertedCheckBox.Enabled; }
            set { requiresResponseWhenAlertedCheckBox.Enabled = value; }
        }

        public TagInfo TagInfo
        {
            get { return tagInfoTextBox.Tag as TagInfo; }
            set
            {
                if (value != null)
                {
                    tagInfoTextBox.Text = string.Format("{0} ({1})", value.Name, value.Description);
                    tagInfoTextBox.Tag = value;
                    gapUnitMeasureLabel.Text = value.Units;
                    neverToExceedMinValueAndFrequencyBoxes.UnitLabelText = value.Units;
                    minValueAndFrequencyBoxes.UnitLabelText = value.Units;
                    maxValueAndFrequencyBoxes.UnitLabelText = value.Units;
                    neverToExceedMaxValueAndFrequencyBoxes.UnitLabelText = value.Units;
                }
                else
                {
                    tagInfoTextBox.Text = string.Empty;
                    tagInfoTextBox.Tag = null;
                    gapUnitMeasureLabel.Text = string.Empty;
                    neverToExceedMinValueAndFrequencyBoxes.UnitLabelText = string.Empty;
                    minValueAndFrequencyBoxes.UnitLabelText = string.Empty;
                    maxValueAndFrequencyBoxes.UnitLabelText = string.Empty;
                    neverToExceedMaxValueAndFrequencyBoxes.UnitLabelText = string.Empty;
                }
            }
        }

        public bool IsAlertRequired
        {
            get { return !suppressAlertCheckBox.Checked; }
            set { suppressAlertCheckBox.Checked = !value; }
        }

        public bool SuppressAlertCheckBoxEnabled
        {
            get { return !suppressAlertCheckBox.Enabled; }
            set { suppressAlertCheckBox.Enabled = !value; }
        }

        public TargetCategory Category
        {
            get { return targetCategoryComboBox.SelectedItem as TargetCategory; }
            set { targetCategoryComboBox.SelectedItem = value; }
        }

        public WorkAssignment WorkAssignment
        {
            get
            {
                WorkAssignment selected = (WorkAssignment)workAssignmentComboBox.SelectedItem;

                if (Equals(selected, WorkAssignment.NoneWorkAssignment))
                {
                    return null;
                }

                return selected;
            }
            set { workAssignmentComboBox.SelectedItem = value ?? WorkAssignment.NoneWorkAssignment; }
        }
        public FunctionalLocation FunctionalLocation
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

        public bool IsActiveCheckBoxEnabled
        {
            get { return temporarilyInactiveCheckBox.Enabled; }
            set { temporarilyInactiveCheckBox.Enabled = value; }
        }

        public void ClearErrorProviders()
        {
            ClearScheduleErrors();
            TargetValueErrorProvider.Clear();
            GapUnitValueErrorProvider.Clear();
            MaxLessThanMinErrorProvider.Clear();
            NTEMaxLessThanNTEMinErrorProvider.Clear();
            NTEMaxLessThanMaxErrorProvider.Clear();
            NTEMinGreaterThanMinErrorProvider.Clear();
            NTEMaxLessThanNTEMinErrorProvider.Clear();
            NTEMinGreaterThanMaxErrorProvider.Clear();
            functionalLocationErrorProvider.Clear();
            tagInfoErrorProvider.Clear();
            allValuesErrorProvider.Clear();
            nameErrorProvider.Clear();
        }

        public void ShowDescriptionIsEmptyError()
        {
            descriptionErrorProvider.SetError(descriptionTextBox, StringResources.DescriptionEmptyError);
        }

        public void ShowNameIsEmptyError()
        {
            nameErrorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void ShowNoFunctionalLocationsSelectedError()
        {
            functionalLocationErrorProvider.SetError(functionalLocationTextBox, StringResources.FieldEmptyError);
        }

        public void ShowNoTagInfoSelectedError()
        {
            tagInfoErrorProvider.SetError(tagInfoTextBox, StringResources.FieldEmptyError);
        }

        public void ShowMaxValueShouldBeGreaterThanMinValueError()
        {
            MaxLessThanMinErrorProvider.SetError(maxValueAndFrequencyBoxes, StringResources.MaxLessThanMinError);
            MaxLessThanMinErrorProvider.SetError(minValueAndFrequencyBoxes, StringResources.MaxLessThanMinError);
        }

        public void ShowMaxValueShouldBeGreaterThanNTEMinValueError()
        {
            NTEMinGreaterThanMaxErrorProvider.SetError(maxValueAndFrequencyBoxes,
                StringResources.NTEMinGreaterThanMaxError);
            NTEMinGreaterThanMaxErrorProvider.SetError(neverToExceedMinValueAndFrequencyBoxes,
                StringResources.NTEMinGreaterThanMaxError);
        }

        public void ShowNTEMaxValueShouldBeGreaterThanNTEMinValueError()
        {
            NTEMaxLessThanNTEMinErrorProvider.SetError(neverToExceedMaxValueAndFrequencyBoxes,
                StringResources.MaxLessThanMinError);
            NTEMaxLessThanNTEMinErrorProvider.SetError(neverToExceedMinValueAndFrequencyBoxes,
                StringResources.MaxLessThanMinError);
        }

        public void ShowNTEMaxValueShouldBeGreaterThanMaxError()
        {
            NTEMaxLessThanMaxErrorProvider.SetError(neverToExceedMaxValueAndFrequencyBoxes,
                StringResources.NTEMaxLessThanMaxError);
            NTEMaxLessThanMaxErrorProvider.SetError(maxValueAndFrequencyBoxes, StringResources.NTEMaxLessThanMaxError);
        }

        public void ShowNTEMaxValueShouldBeGreaterThanMinError()
        {
            NTEMaxLessThanNTEMinErrorProvider.SetError(neverToExceedMaxValueAndFrequencyBoxes,
                StringResources.NTEMaxLessThanMinError);
            NTEMaxLessThanNTEMinErrorProvider.SetError(minValueAndFrequencyBoxes, StringResources.NTEMaxLessThanMinError);
        }

        public void ShowMinValueShouldBeGreaterThanNTEMinError()
        {
            NTEMinGreaterThanMinErrorProvider.SetError(neverToExceedMinValueAndFrequencyBoxes,
                StringResources.NTEMinGreaterThanMinError);
            NTEMinGreaterThanMinErrorProvider.SetError(minValueAndFrequencyBoxes,
                StringResources.NTEMinGreaterThanMinError);
        }

        public void ShowAllValuesAreEmptyError()
        {
            allValuesErrorProvider.SetError(maxValueAndFrequencyBoxes, StringResources.IsAtLeastOneMinOrMaxValueSetError);
            allValuesErrorProvider.SetError(minValueAndFrequencyBoxes, StringResources.IsAtLeastOneMinOrMaxValueSetError);
            allValuesErrorProvider.SetError(neverToExceedMaxValueAndFrequencyBoxes,
                StringResources.IsAtLeastOneMinOrMaxValueSetError);
            allValuesErrorProvider.SetError(neverToExceedMinValueAndFrequencyBoxes,
                StringResources.IsAtLeastOneMinOrMaxValueSetError);
        }

        public void ShowWriteTagError(string message)
        {
            writeTagErrorProvider.SetError(configurePreApprovedTargetRangesButton, message);
        }

        public void ShowTargetValueIsOutsideOfThreshold()
        {
            allValuesErrorProvider.SetError(targetValueControl, StringResources.TargetValueIsOutsideThresholds);
        }

        public void ShowNameError(string message)
        {
            nameErrorProvider.SetError(nameTextBox, message);
        }

        public void ClearScheduleErrors()
        {
            schedulePicker.ClearErrors();
        }

        public bool HasScheduleError
        {
            get { return schedulePicker.HasScheduleError; }
        }

        public IList<OperationalMode> OperationalModes
        {
            set { operationalModeComboBox.DataSource = value; }
        }

        public bool ReadWriteConfigurationEnabled
        {
            set { configureReadWriteTagButton.Enabled = value; }
        }

        public TagDirection MaxReadWriteDirection
        {
            set { maxReadWriteTagDirectionLabel.Direction = value; }
        }

        public TagDirection MinReadWriteDirection
        {
            set { minReadWriteTagDirectionLabel.Direction = value; }
        }

        public TagDirection TargetReadWriteDirection
        {
            set { targetReadWriteTagDirectionLabel.Direction = value; }
        }

        public TagDirection GapUnitReadWriteDirection
        {
            set { gapUnitValueReadWriteTagDirectionLabel.Direction = value; }
        }

        public bool ConfigurePreApprovedTargetRangesEnabled
        {
            set { configurePreApprovedTargetRangesButton.Enabled = value; }
        }

        public bool MaxValueEnabled
        {
            set { maxValueAndFrequencyBoxes.ValueEnabled = value; }
        }

        public bool MinValueEnabled
        {
            set { minValueAndFrequencyBoxes.ValueEnabled = value; }
        }

        public bool TargetValueEnabled
        {
            set { targetValueControl.Enabled = value; }
        }

        public bool GapUnitValueEnabled
        {
            set { gapUnitValueNumericBox.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public List<DocumentLink> AssociatedDocumentLinks
        {
            get { return targetDefinitionDocumentLinksControl.DataSource as List<DocumentLink>; }
            set { targetDefinitionDocumentLinksControl.DataSource = value; }
        }

        public OperationalMode OperationalMode
        {
            get { return operationalModeComboBox.SelectedItem as OperationalMode; }
            set { operationalModeComboBox.SelectedItem = value; }
        }

        public ITargetDefinitionReadWriteTagConfigurationView DisplayReadWriteConfigurationForm(
            TargetDefinition targetDefinition)
        {
            return new TargetDefinitionReadWriteTagConfigurationForm(targetDefinition);
        }

        private TargetDefinitionFormPresenter CreatePresenter(TargetDefinition editTargetDefinition)
        {
            if (editTargetDefinition == null)
            {
                return new TargetDefinitionFormPresenter(this);
            }
            return new TargetDefinitionFormPresenter(this, editTargetDefinition);
        }

        private void Initialize(TargetDefinition editTargetDefinition)
        {
            InitializeComponent();
            //Amit Shukla break Fix RITM0099536 Start 02/June/2017
            if (editTargetDefinition != null)// this is to avoid below code execution when user clicks on new button for target
            {
                if (editTargetDefinition.Schedule.StartDate <= Clock.DateNow) //if the start date is a future date then no change will happen
                {
                    if (editTargetDefinition.Schedule.HasEndDate == true && editTargetDefinition.Schedule.EndDate <= Clock.DateNow) //if End date is a future date and has end date true than do not change the end date 
                    {
                        editTargetDefinition.Schedule.EndDate = Clock.DateNow;
                        //editTargetDefinition.Schedule.EndTime = Clock.TimeNow;
                    }
                    editTargetDefinition.Schedule.StartDate = Clock.DateNow;
                    //editTargetDefinition.Schedule.StartTime = Clock.TimeNow;
                }
            }
            //Amit Shukla break Fix RITM0099536 End 02/June/2017
            associatedTargetDefinitionListBox.DisplayMember = "Name";
            targetCategoryComboBox.DisplayMember = "Name";
            targetCategoryComboBox.ValueMember = "Id";
            workAssignmentComboBox.DisplayMember = "Name";
            workAssignmentComboBox.ValueMember = "Id";
            schedulePicker.TimeRangeLabel = StringResources.TargetDefinitionForm_SchedulePickerTimeRangeLabel;
            functionalLocationSelectorForm =
                new SingleSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3));
            tagSelectorFormView = new TagSearchForm(true, false);
            targetAssociationSelectionForm = new TargetAssociationSelectionForm(editTargetDefinition);
            neverToExceedMinValueAndFrequencyBoxes.FrequencyLabelText = freqLabelText;
            minValueAndFrequencyBoxes.FrequencyLabelText = freqLabelText;
            maxValueAndFrequencyBoxes.FrequencyLabelText = freqLabelText;
            neverToExceedMaxValueAndFrequencyBoxes.FrequencyLabelText = freqLabelText;
            operationalModeComboBox.DisplayMember = "Name";
            operationalModeComboBox.ValueMember = "Id";
            maxReadWriteTagDirectionLabel.Text = string.Empty;
            minReadWriteTagDirectionLabel.Text = string.Empty;
            targetReadWriteTagDirectionLabel.Text = string.Empty;
            gapUnitValueReadWriteTagDirectionLabel.Text = string.Empty;
        }

        private void RegisterEventHandlersOnPresenter(TargetDefinitionFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            searchTagButton.Click += presenter.SearchTagClickEvent;
            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            FormClosing += presenter.HandleFormClosing;
            dependentTargetButton.Click += presenter.HandleDependentTargetButtonClick;
            requiresApprovalCheckBox.CheckedChanged += presenter.HandleRequiresApprovalCheckBoxCheckedChanged;
            suppressAlertCheckBox.CheckedChanged += presenter.HandleSuppressAlertCheckBoxCheckedChanged;
            requiresResponseWhenAlertedCheckBox.CheckedChanged +=
                presenter.HandleRequiresResponseWhenAlertedCheckBoxCheckedChanged;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;
            configureReadWriteTagButton.Click += presenter.HandleConfigureReadWriteTagButtonClick;
            nameTextBox.TextChanged += presenter.HandleNameChanged;
            configurePreApprovedTargetRangesButton.Click +=
                presenter.HandleConfigurePreApprovedTargetRangesButtonClick;
            refreshTagValueButton.Click += presenter.HandleRefreshTagValueButtonClick;
        }

        private void SetColourForFieldRequiringReApproval(bool requireReApproval, Control control)
        {
            SetColourForFieldRequiringReApproval(requireReApproval, control, StringResources.EditingRequiresReapproval);
        }

        private void SetColourForFieldRequiringReApproval(bool requireReApproval, Control control,
            string toolTipDescription)
        {
            if (requireReApproval)
            {
                control.ForeColor = UIConstants.RequireApprovalFieldColor;
                toolTip.SetToolTip(control, toolTipDescription);
            }
        }
    }
}
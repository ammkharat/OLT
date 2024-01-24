using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LabAlertDefinitionForm : BaseForm, ILabAlertDefinitionFormView
    {
        private ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;
        private ITagSearchFormView tagSelectorFormView;
        private LabAlertTagQueryRangeType currentRangeType;
        
        public LabAlertDefinitionForm() : this(null)
        {
        }

        public LabAlertDefinitionForm(LabAlertDefinition definition)
        {
            Initialize();
            LabAlertDefinitionFormPresenter presenter = CreatePresenter(definition);
            RegisterEventHandlersOnPresenter(presenter);
        }

        private LabAlertDefinitionFormPresenter CreatePresenter(LabAlertDefinition definition)
        {
            if (definition == null)
            {
                return new LabAlertDefinitionFormPresenter(this);
            }
            return new LabAlertDefinitionFormPresenter(this, definition);
        }

        private void Initialize()
        {
            InitializeComponent();
            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsOrIsAncestorOfOrIsDescendantOfFlocSelectedByUserFilter());
            tagSelectorFormView = new TagSearchForm(false, false);
        }
      
        private void RegisterEventHandlersOnPresenter(LabAlertDefinitionFormPresenter presenter)
        {
            Load += presenter.Form_Load;
            FormClosing += presenter.HandleFormClosing;

            schedulePicker.ScheduleTypeChanged += presenter.SchedulePicker_ScheduleTypeChanged;

            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;

            functionalLocationButton.Click += presenter.FunctionalLocationButton_Click;
            searchTagButton.Click += presenter.SearchTagButtonClick;
            viewEditHistoryButton.Click += presenter.ViewEditHistoryButton_Click;
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return new DialogResultAndOutput<FunctionalLocation>(result, functionalLocationSelectorForm.SelectedFunctionalLocation);
        }

        public DialogResultAndOutput<TagInfo> ShowTagSelector()
        {
            DialogResult result = tagSelectorFormView.ShowDialog(this);
            return new DialogResultAndOutput<TagInfo>(result, tagSelectorFormView.SelectedTag);
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

        public new string Name
        {
            get { return nameTextBox.Text.Trim(); }
            set { nameTextBox.Text = value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text.Trim(); }
            set { descriptionTextBox.Text = value; }
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
        
        public TagInfo TagInfo
        {
            get { return tagInfoTextBox.Tag as TagInfo; }
            set
            {
                if(value != null)
                {
                    tagInfoTextBox.Text = string.Format("{0} ({1})", value.Name, value.Description);
                    tagInfoTextBox.Tag = value;
                }
                else
                {
                    tagInfoTextBox.Text = string.Empty;
                    tagInfoTextBox.Tag = null;
                }
            }
        }

        public int MinimumNumberOfSamples
        {
            get { return (int)minimumNumberOfSamplesTextBox.Value; }
            set { minimumNumberOfSamplesTextBox.Value = value; }
        }

        public LabAlertTagQueryRange LabAlertTagQueryRange
        {
            get
            {
                if (currentRangeType == LabAlertTagQueryRangeType.Daily)
                {
                    return labAlertTagQueryDailyRangeControl.LabAlertTagQueryRange;
                }
                if (currentRangeType == LabAlertTagQueryRangeType.Weekly)
                {
                    return labAlertTagQueryWeeklyRangeControl.LabAlertTagQueryRange;
                }
                if (currentRangeType == LabAlertTagQueryRangeType.MonthlyDayOfWeek)
                {
                    return labAlertTagQueryMonthlyDayOfWeekRangeControl.LabAlertTagQueryRange;
                }
                if (currentRangeType == LabAlertTagQueryRangeType.MonthlyDayOfMonth)
                {
                    return labAlertTagQueryMonthlyDayOfMonthRangeControl.LabAlertTagQueryRange;
                }
                throw new Exception("Unrecognized lab sample range type: " + currentRangeType);
            }
            set
            {
                currentRangeType = value.LabAlertTagQueryRangeType;

                labAlertTagQueryDailyRangeControl.Visible = false;
                labAlertTagQueryWeeklyRangeControl.Visible = false;
                labAlertTagQueryMonthlyDayOfWeekRangeControl.Visible = false;
                labAlertTagQueryMonthlyDayOfMonthRangeControl.Visible = false;

                if (currentRangeType == LabAlertTagQueryRangeType.Daily)
                {
                    labAlertTagQueryDailyRangeControl.Visible = true;
                    labAlertTagQueryDailyRangeControl.LabAlertTagQueryRange = (LabAlertTagQueryDailyRange) value;
                }
                else if (currentRangeType == LabAlertTagQueryRangeType.Weekly)
                {
                    labAlertTagQueryWeeklyRangeControl.Visible = true;
                    labAlertTagQueryWeeklyRangeControl.LabAlertTagQueryRange = (LabAlertTagQueryWeeklyRange)value;
                }
                else if (currentRangeType == LabAlertTagQueryRangeType.MonthlyDayOfWeek)
                {
                    labAlertTagQueryMonthlyDayOfWeekRangeControl.Visible = true;
                    labAlertTagQueryMonthlyDayOfWeekRangeControl.LabAlertTagQueryRange = (LabAlertTagQueryMonthlyDayOfWeekRange)value;
                }
                else if (currentRangeType == LabAlertTagQueryRangeType.MonthlyDayOfMonth)
                {
                    labAlertTagQueryMonthlyDayOfMonthRangeControl.Visible = true;
                    labAlertTagQueryMonthlyDayOfMonthRangeControl.LabAlertTagQueryRange = (LabAlertTagQueryMonthlyDayOfMonthRange)value;
                }
                else
                {
                    throw new Exception("Unrecognized lab sample range type: " + currentRangeType);
                }
            }
        }

        public ISchedule Schedule
        {
            get { return schedulePicker.Schedule; }
            set { schedulePicker.Schedule = value; }
        }

        public bool IsActive
        {
            get { return !temporarilyInactiveCheckBox.Checked; }
            set { temporarilyInactiveCheckBox.Checked = !value; }
        }

        public void ClearErrorProviders()
        {
            schedulePicker.ClearErrors();
            nameErrorProvider.Clear();
            descriptionErrorProvider.Clear();
            functionalLocationErrorProvider.Clear();
            tagInfoErrorProvider.Clear();
        }

        public bool HasScheduleError
        {
            get { return schedulePicker.HasScheduleError; }
        }

        public void ShowNameIsEmptyError()
        {
            nameErrorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void ShowDescriptionIsEmptyError()
        {
            descriptionErrorProvider.SetError(descriptionTextBox, StringResources.DescriptionEmptyError);
        }

        public void ShowNoFunctionalLocationsSelectedError()
        {
            functionalLocationErrorProvider.SetError(functionalLocationTextBox, StringResources.FieldEmptyError);
        }

        public void ShowNoTagInfoSelectedError()
        {
            tagInfoErrorProvider.SetError(tagInfoTextBox, StringResources.FieldEmptyError);
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public void ShowNameError(string message)
        {
            nameErrorProvider.SetError(nameTextBox, message);
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }
    }
}
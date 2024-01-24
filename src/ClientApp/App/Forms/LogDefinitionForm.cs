using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LogDefinitionForm : BaseForm, ILogDefinitionFormView
    {
        public event Action HandleLogTemplateButtonClick;
        private static readonly ILog logger = LogManager.GetLogger(typeof(LogDefinitionForm));
        private LogDefinitionFormPresenter presenter;
        private readonly IMultiSelectFunctionalLocationSelectionForm unitLevelFunctionalLocationSelector;
        private readonly IMultiSelectFunctionalLocationSelectionForm sectionLevelFunctionalLocationSelector;

        public static LogDefinitionForm CreateForRepeatingLog()
        {
            return new LogDefinitionForm(true);
        }

        public static LogDefinitionForm CreateForStandingOrder()
        {
            return new LogDefinitionForm(false);
        }

        private LogDefinitionForm(bool isRepeatingLog) : this(null, isRepeatingLog)
        {
        }

        public LogDefinitionForm(LogDefinition logToUpdate, bool isRepeatingLog)
        {
            InitializeComponent();

            if (logToUpdate != null)
            {
                isRepeatingLog = logToUpdate.LogType.Equals(LogType.Standard);
            }

            tableLayoutPanel.ControlThatShouldFillEmptySpace = templateAndCommentsTableLayoutPanel;

            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;

            unitLevelFunctionalLocationSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelThreeAndBelow(siteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3), true);

            //sectionLevelFunctionalLocationSelector =
            //  new MultiSelectFunctionalLocationSelectionForm(
            //      FunctionalLocationMode.GetLevelTwoAndBelow(siteConfiguration),
            //      new FunctionalLocationIsSelectedByUserFilter(), true);
            sectionLevelFunctionalLocationSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(siteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(), true);

            presenter = new LogDefinitionFormPresenter(this, logToUpdate, isRepeatingLog);
            RegisterEventHandler(presenter);
        }

        private void RegisterEventHandler(LogDefinitionFormPresenter presenter)
        {
            scrollingPanel.MouseWheeling += ScrollingPanel_MouseWheeling;
            additionalDetailsToggleButton.Toggled += AdditionalDetailsButton_Toggled;

            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClicked;
            logCommentControl.GuidelineLinkClick += presenter.HandleLogCommentGuidelineLinkClick;

            FormClosed += Form_Closed;
            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            removeFLOCButton.Click += presenter.HandleRemoveFlocButton_Clicked;
            insertTemplateButton.Click += InsertLogTemplateButtonClick;
        }

        private void InsertLogTemplateButtonClick(object sender, EventArgs e)
        {
            if (HandleLogTemplateButtonClick != null)
            {
                HandleLogTemplateButtonClick();
            }           
        }

        private void UnRegisterEventHandler()
        {
            scrollingPanel.MouseWheeling -= ScrollingPanel_MouseWheeling;
            additionalDetailsToggleButton.Toggled -= AdditionalDetailsButton_Toggled;

            Load -= presenter.HandleFormLoad;
            FormClosing -= presenter.HandleFormClosing;
            saveAndCloseButton.Click -= presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click -= presenter.HandleCancelButtonClick;
            viewEditHistoryButton.Click -= presenter.HandleViewEditHistoryButtonClicked;
            logCommentControl.GuidelineLinkClick -= presenter.HandleLogCommentGuidelineLinkClick;

            FormClosed -= Form_Closed;
            functionalLocationButton.Click -= presenter.HandleFunctionalLocationButtonClick;
            removeFLOCButton.Click -= presenter.HandleRemoveFlocButton_Clicked;
            insertTemplateButton.Click -= InsertLogTemplateButtonClick;
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        private bool ScrollingPanel_MouseWheeling()
        {
            return logCommentControl != ActiveControl;
        }

        private void AdditionalDetailsButton_Toggled(bool expanded)
        {
            advancedDetailsPanel.Visible = expanded;
            tableLayoutPanel.FillUpAnyExtraVerticalSpace();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            UnRegisterEventHandler();
            presenter = null;
        }

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime LastModifiedDateTime
        {
            set
            {
                lastModifiedDateAuthorHeader.LastModifiedDate = value;
            }
        }

        public bool EHSFollowUp
        {
            get { return eHSFollowUpCheckBox.Checked; }
            set { eHSFollowUpCheckBox.Checked = value; }
        }

        public bool InspectionFollowUp
        {
            get { return inspectionFollowUpCheckbox.Checked; }
            set { inspectionFollowUpCheckbox.Checked = value; }
        }

        public bool OperationsFollowUp
        {
            get { return operationsFollowUpCheckbox.Checked; }
            set { operationsFollowUpCheckbox.Checked = value; }
        }

        public bool ProcessControlFollowUp
        {
            get { return processControlFollowUpCheckBox.Checked; }
            set { processControlFollowUpCheckBox.Checked = value; }
        }

        public bool SupervisionFollowUp
        {
            get { return supervisorFollowUpCheckbox.Checked; }
            set { supervisorFollowUpCheckbox.Checked = value; }
        }

        public bool OtherFollowUp
        {
            get { return otherFollowUpCheckBox.Checked; }
            set { otherFollowUpCheckBox.Checked = value; }
        }

        public bool IsOperatingEngineerLog
        {
            get { return IsOperatingEngineerLogCheckBox.Checked; }
            set { IsOperatingEngineerLogCheckBox.Checked = value; }
        }

        public bool IsInactive
        {
            get { return isInactiveCheckBox.Checked; }
            set { isInactiveCheckBox.Checked = value; }
        }

        public bool CreateALogForEachFunctionalLocation
        {
            get { return createLogForEachFlocRadioButton.Checked; }
            set
            {
                createLogForEachFlocRadioButton.Checked = value;
                createOneLogRadioButton.Checked = !value;
            }
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public string Comments
        {
            get { return logCommentControl.Text; }
            set { logCommentControl.Text = value; }          
        }

        public string CommentsAsPlainText
        {
            get { return logCommentControl.PlainText; }
        }

        public List<FunctionalLocation> FunctionalLocationData
        {
            set { functionalLocationListBox.FunctionalLocations = value; }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public string Title
        {
            set
            {
                Text = value;
            }
        }

        public void SetCustomFieldMustContainANumberError(CustomFieldEntry entry)
        {
            customFieldControl.SetError(errorProvider, entry, StringResources.NumericFieldError);
        }

        public void SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(CustomFieldEntry entry)
        {
            customFieldControl.SetError(errorProvider, entry, StringResources.NumberNeedsToConformToPrecision18AndScale6Error);
        }

        public void SetCommentsBlankError()
        {
            logCommentControl.SetError(StringResources.CommentFieldEmpty);
        }

        public void RepeatingLogCannotBeAtASecondLevelFloc()
        {
            errorProvider.SetError(
                functionalLocationListBox,
                StringResources.RepeatingLogCannotBeAtSecondLevelFlocError);
        }

        public ISchedule Schedule
        {
            get { return schedulePicker.Schedule; }
            set { schedulePicker.Schedule = value; }
        }

        public List<DocumentLink> AssociatedDocumentLinks
        {
            get { return logDocumentLinksControl.DataSource as List<DocumentLink>; }
            set { logDocumentLinksControl.DataSource = value; }
        }

        public List <ScheduleType> ScheduleTypes
        {
            set { schedulePicker.AllowedScheduleTypes = value; }
        }

        public bool HasScheduleError
        {
            get { return schedulePicker.HasScheduleError; }
        }

        public void ClearErrorProviders()
        {
            logCommentControl.ClearErrorProviders();
            errorProvider.Clear();
        }

        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            customFieldControl.CustomFieldClicked += presenter.HandleCustomFieldClick;
            customFieldControl.SetCustomFieldEntries(customFieldEntries, customFields, false);
            customFieldsPanel.Visible = customFields.Count > 0;
        }

        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return customFieldControl.GetCustomFieldEntryText(entry);
        }

        public void SetCustomFieldEntryText(CustomFieldEntry entry, string text)
        {
            customFieldControl.SetCustomFieldEntryText(entry, text);
        }

        public string GetCustomFieldEntryText(long customFieldId)
        {
            return customFieldControl.GetCustomFieldEntryText(customFieldId);
        }

        public bool IsCommentEmpty
        {
            get { return logCommentControl.IsEmpty; }            
        }

        public bool ExpandAdditionalDetails
        {
            set
            {
                additionalDetailsToggleButton.Expanded = value;
                AdditionalDetailsButton_Toggled(value);
            }
        }

        public bool OptionsSectionHidden
        {
            set
            {
                if (value)
                {
                    optionsGroupBox.Hide();
                }
                else
                {
                    optionsGroupBox.Show();
                }
            }
        }

        public bool IsOperatingEngineerLogCheckboxHidden
        {
            set
            {
                if (value)
                {
                    IsOperatingEngineerLogCheckBox.Hide();
                }
                else
                {
                    IsOperatingEngineerLogCheckBox.Show();
                }
            }
        }

        public bool IsInactiveCheckboxHidden
        {
            set
            {
                if (value)
                {
                    isInactiveCheckBox.Hide();
                }
                else
                {
                    isInactiveCheckBox.Show();
                }
            }
        }

        public bool IsOperatingEngineerLogCheckboxEnabled
        {
            set { IsOperatingEngineerLogCheckBox.Enabled = value; }
        }

        public void ShowGuidelines(List<LogGuideline> guidelines)
        {
            logCommentControl.ShowLogGuidelineForm(guidelines);
        }

        public void HideFollowupFlags()
        {
            followupGroupBox.Hide();
        }

        public void HideMultipleFunctionalLocationOptions()
        {
            multipleFunctionalLocationGroupBox.Hide();
        }

        public bool MultipleFunctionalLocationOptionsEnabled
        {
            set
            {
                if (!value)
                {
                    createOneLogRadioButton.Checked = true;
                }
                createLogForEachFlocRadioButton.Enabled = value;
                createOneLogRadioButton.Enabled = value;
                multipleFunctionalLocationGroupBox.Enabled = value;
            }
        }

        public void TurnOffCustomFieldPhTagHighlights()
        {
            customFieldControl.TurnOffHighlighting();
        }

        public string OperatingEngineerLogDisplayName
        {
            set { IsOperatingEngineerLogCheckBox.Text = value; }
        }

        public void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions()
        {
            flocButtonsPanel.Visible = false;
            multipleFunctionalLocationGroupBox.Enabled = false;
        }

        public void SetLogTemplates(List<LogTemplateDTO> logTemplates)
        {
            logTemplateComboBox.Items.Clear();

            foreach (LogTemplateDTO logTemplate in logTemplates)
            {
                logTemplateComboBox.Items.Add(logTemplate);
            }
        }

        public void HideLogTemplateComponent()
        {
            templatePanel.Visible = false;
        }

        public void ShowLogTemplateComponent()
        {
            templatePanel.Visible = true;
        }

        public void SetFunctionalLocationsEmptyError()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelection, FunctionalLocationType selectionFLOCLevel)    
        {
            IMultiSelectFunctionalLocationSelectionForm selector;

            if (selectionFLOCLevel.Equals(FunctionalLocationType.Level2))
            {
                selector = sectionLevelFunctionalLocationSelector;
            }
            else if (selectionFLOCLevel.Equals(FunctionalLocationType.Level3))
            {
                selector = unitLevelFunctionalLocationSelector;
            }
            else
            {
                logger.Error("Internal error: An unrecognized FLOC level was provided for the FLOC selector. Defaulting to Unit.");
                selector = unitLevelFunctionalLocationSelector;
            }

            DialogResult dialogResult = selector.ShowDialog(this, initialUserFLOCSelection);
            IList<FunctionalLocation> selected = selector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<IList<FunctionalLocation>>(dialogResult, selected);
        }

        public LogTemplateDTO SelectedLogTemplate
        {
            get { return (LogTemplateDTO)logTemplateComboBox.SelectedItem; }
            set { logTemplateComboBox.SelectedItem = value; }
        }

        public void ApplyLogTemplateText(string text)
        {
            logCommentControl.AppendText(text);
        }
    }
}

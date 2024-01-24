using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinExplorerBar;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DirectiveLogForm : BaseForm, IDirectiveLogFormView
    {
        public event Action HandleLogTemplateButtonClick;

        private DirectiveLogFormPresenter presenter;
        private IMultiSelectFunctionalLocationSelectionForm sectionLevelFunctionalLocationSelectorThatAllowsAncestorSelection;        
        private DateTime logDateTime;

        // Least evil solution: This is used to resize the comments explorer bar group. The event is set in the base class's constructor.
        private LogCommentExplorerBarRenderer commentsRenderer;

        private enum Mode { Edit, Copy };

        public DirectiveLogForm()
        {
            Initialize();
            presenter = new DirectiveLogFormPresenter(this);
            RegisterEventHandler();          
        }

        private DirectiveLogForm(Log log, Mode mode)
        {
            Initialize();
            if (mode == Mode.Edit)
            {
                presenter = new DirectiveLogFormPresenter(this, log);
            } 
            else if (mode == Mode.Copy)
            {
                presenter = new DirectiveLogFormPresenter(this, new LogCopyStrategy(log));
            }
            RegisterEventHandler();
        }

        public static DirectiveLogForm CreateForUpdate(Log logToUpdate)
        {
            return new DirectiveLogForm(logToUpdate, Mode.Edit);
        }

        public static DirectiveLogForm CreateForCopy(Log logToCopy)
        {
            return new DirectiveLogForm(logToCopy, Mode.Copy);
        }

        private void Initialize()
        {
            InitializeComponent();
            explorerBar.MouseWheeling += ExplorerBar_MouseWheeling;
           
            commentsRenderer = new LogCommentExplorerBarRenderer(this, explorerBar, 220);
            sectionLevelFunctionalLocationSelectorThatAllowsAncestorSelection =
                new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsOrIsAncestorOfOrIsDescendantOfFlocSelectedByUserFilter(), true);
        }

        private bool ExplorerBar_MouseWheeling()
        {
            return logCommentControl != ActiveControl;
        }

        private void RegisterEventHandler()
        {
            FormClosed += presenter.HandleFormClosed;
            FormClosed += Form_Closed;
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            removeFLOCButton.Click += presenter.HandleRemoveFlocButtonClick;
            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;            
            actualLoggedTime.ValueChanged += presenter.LogDateTimeChanged;
            insertTemplateButton.Click += InsertLogTemplateButtonClick;
            logCommentControl.GuidelineLinkClick += presenter.LogCommentControlGuidelineLinkClick;
            importCustomFieldsButton.Click += presenter.HandleImportCustomFieldButtonClicked;
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
            FormClosed -= presenter.HandleFormClosed;
            FormClosed -= Form_Closed;
            Load -= presenter.HandleFormLoad;
            FormClosing -= presenter.HandleFormClosing;
            cancelButton.Click -= presenter.HandleCancelButtonClick;
            functionalLocationButton.Click -= presenter.HandleFunctionalLocationButtonClick;
            removeFLOCButton.Click -= presenter.HandleRemoveFlocButtonClick;
            saveAndCloseButton.Click -= presenter.HandleSaveAndCloseButtonClick;
            viewEditHistoryButton.Click -= presenter.HandleViewEditHistoryButtonClick;
            actualLoggedTime.ValueChanged -= presenter.LogDateTimeChanged;
            insertTemplateButton.Click += InsertLogTemplateButtonClick;
            logCommentControl.GuidelineLinkClick -= presenter.LogCommentControlGuidelineLinkClick;
            importCustomFieldsButton.Click -= presenter.HandleImportCustomFieldButtonClicked;
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            UnRegisterEventHandler();
            presenter = null;
        }

        public DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> initialUserFLOCSelection)
        {
            IMultiSelectFunctionalLocationSelectionForm selector = sectionLevelFunctionalLocationSelectorThatAllowsAncestorSelection;
            DialogResult dialogResult = selector.ShowDialog(this, initialUserFLOCSelection);
            IList<FunctionalLocation> selected = selector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<IList<FunctionalLocation>>(dialogResult, selected);
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public bool EHSFollowUp
        {
            get
            {
                return eHSFollowUpCheckBox.Checked;
            }
            set
            {
                eHSFollowUpCheckBox.Checked = value;
            }
        }

        public bool InspectionFollowUp
        {
            get
            {
                return inspectionFollowUpCheckbox.Checked;
            }
            set
            {
                inspectionFollowUpCheckbox.Checked = value;
            }
        }

        public bool OperationsFollowUp
        {
            get
            {

                return operationsFollowUpCheckbox.Checked;
            }
            set
            {
                operationsFollowUpCheckbox.Checked = value;
            }
        }

        public bool ProcessControlFollowUp
        {
            get
            {
                return processControlFollowUpCheckBox.Checked;
            }
            set
            {
                processControlFollowUpCheckBox.Checked = value;
            }
        }

        public bool SupervisionFollowUp
        {
            get
            {
                return supervisorFollowUpCheckbox.Checked;
            }
            set
            {
                supervisorFollowUpCheckbox.Checked = value;
            }
        }

        public bool OtherFollowUp
        {
            get
            {
                return otherFollowUpCheckBox.Checked;
            }
            set
            {
                otherFollowUpCheckBox.Checked = value;
            }
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

        public bool LogTimeControlEnabled
        {
            get { return actualLoggedTime.Enabled; }
            set { actualLoggedTime.Enabled = value; }
        }

        public string Shift
        {
            set { shiftLabelData.Text = value; }
        }
        
        public string Author
        {
            set { createdByLabelData.Text = value; }
        }
       
        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocationListBox.FunctionalLocations; }
            set
            {
                functionalLocationListBox.FunctionalLocations = value;
                MultipleFunctionalLocationOptionsEnabled = value.Count > 1;
            }
        }

        public bool CreateALogForEachFunctionalLocation
        {
            get { return createLogForEachFlocRadioButton.Checked; }
            set
            {
                if (value)
                {
                    createLogForEachFlocRadioButton.Checked = true;
                }
                else
                {
                    createOneLogRadioButton.Checked = true;
                }
            }
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

        public void SetFunctionLocationBlankError()
        {
            functionLocationBlankErrorProvider.SetError(functionalLocationListBox, StringResources.FieldEmptyError);
        }

        public void SetLogTimeInTheFutureError()
        {
            actualLoggedDateErrorProvider.SetError(actualLoggedTime, StringResources.FutureTimeError);    
        }

        public void SetLogDateTimeError()
        {
            actualLoggedDateErrorProvider.SetError(actualLoggedTime,
                String.Format(StringResources.LogActualTimeMustBeWithinCurrentShift,
                ClientSession.GetUserContext().UserShift.StartDateTimeWithPadding.ToTime(),
                ClientSession.GetUserContext().UserShift.EndDateTimeWithPadding.ToTime()));
        }

        public void RepeatingLogCannotBeAtASecondLevelFloc()
        {
            functionLocationBlankErrorProvider.SetError(
                functionalLocationListBox,
                StringResources.RepeatingLogCannotBeAtSecondLevelFlocError);
        }

        public List<DocumentLink> AssociatedDocumentLinks
        {
            get { return logDocumentLinksControl.DataSource as List<DocumentLink>; }
            set { logDocumentLinksControl.DataSource = value; }
        }

        public Time ActualLoggedTime
        {
            get { return actualLoggedTime.Value; }
        }

        public DateTime LogDateTime
        {
            get { return logDateTime; }
            set
            {
                logDateTime = value;
                actualLoggedTime.Value = logDateTime.ToTime();
                logDateTimeLabelData.Text = logDateTime.ToLongDateString();               
            }
        }

        public void ClearErrorProviders()
        {     
            logCommentControl.ClearErrorProviders();      
            functionLocationBlankErrorProvider.Clear();
            actualLoggedDateErrorProvider.Clear();
            errorProvider.Clear();
        }

        public void SetupForEdit()
        {
            functionalLocationListBox.ReadOnly = true;
            functionalLocationListBox.Width = functionalLocationGroupBox.Width - 12;
            functionalLocationButton.Hide();
        }

        public void HideLogTemplateComponent()
        {
            ChangeSectionVisibleState(ultraExplorerBarContainerControl5, false);
        }

        public void ShowLogTemplateComponent()
        {
            ChangeSectionVisibleState(ultraExplorerBarContainerControl5, true);
        }

        private void ChangeSectionVisibleState(UltraExplorerBarContainerControl explorerBarContainerControl, bool expand)
        {
            SuspendLayout();
            foreach (UltraExplorerBarGroup group in explorerBar.Groups)
            {
                if (group.Container == explorerBarContainerControl)
                {
                    group.Expanded = expand;
                }
            }
            ResumeLayout();
        }
       
        public void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions()
        {
            functionalLocationButton.Visible = false;
            removeFLOCButton.Visible = false;
            multipleFunctionalLocationGroupBox.Enabled = false;
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public void SetLogTemplates(List<LogTemplateDTO> logTemplates)
        {
            logTemplateComboBox.Items.Clear();

            foreach (LogTemplateDTO logTemplate in logTemplates)
            {
                logTemplateComboBox.Items.Add(logTemplate);
            }                        
        }

        public LogTemplateDTO SelectedLogTemplate
        {
            get { return (LogTemplateDTO) logTemplateComboBox.SelectedItem; }
            set { logTemplateComboBox.SelectedItem = value; }
        }

        public void ApplyLogTemplateText(string text)
        {
            logCommentControl.AppendText(text);            
        }

        

        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            customFieldControl.CustomFieldClicked += presenter.HandleCustomFieldClick;
            customFieldControl.SetCustomFieldEntries(customFieldEntries, customFields, false);
            if (customFields.Count == 0)
            {
                explorerBar.Groups["CustomFields"].Expanded = false;
            }
        }

        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return customFieldControl.GetCustomFieldEntryText(entry);
        }

        public string GetCustomFieldEntryText(long customFieldId)
        {
            return customFieldControl.GetCustomFieldEntryText(customFieldId);
        }

        public void SetCustomFieldEntryText(CustomFieldEntry entry, String text)
        {
            customFieldControl.SetCustomFieldEntryText(entry, text);
        }

        public bool IsCommentEmpty
        {
            get { return logCommentControl.IsEmpty; }            
        }

        public void ShowGuidelines(List<LogGuideline> guidelines)
        {
            logCommentControl.ShowLogGuidelineForm(guidelines);
        }

        public bool ShowLogMarkedAsReadWarning()
        {
            DialogResult result = OltMessageBox.Show(
                this, 
                StringResources.EditingItemMarkedAsReadWarning, 
                StringResources.EditingItemMarkedAsReadWarning_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return DialogResult.Yes.Equals(result);
        }

        public bool CustomFieldPhTagAssociationControlsVisible
        {
            set
            {
                customFieldPhTagLegendControl.Visible = value;
                importCustomFieldsButton.Visible = value;

                if (value)
                {
                    ultraExplorerBarContainerControl6.Height = customFieldControl.Height + customFieldPhTagLegendControl.Height + 35;

                    int yCoordOfCustomFieldControlBottom = customFieldControl.Location.Y + customFieldControl.Height;
                    customFieldPhTagLegendControl.Location = new Point(customFieldPhTagLegendControl.Location.X, yCoordOfCustomFieldControlBottom);
                }
                else
                {
                    ultraExplorerBarContainerControl6.Height = customFieldControl.Height;
                }
            }
        }

        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries)
        {
            customFieldControl.TurnOnHighlighting(entries);
        }

        public void DisableControls()
        {
            ControlsEnabled = false;
        }

        public void EnableControls()
        {
            ControlsEnabled = true;
        }

        private bool ControlsEnabled
        {
            set
            {
                buttonPanel.Enabled = value;
                logTimeGroupBox.Enabled = value;
                functionalLocationGroupBox.Enabled = value;
                multipleFunctionalLocationGroupBox.Enabled = value;
                requiresFollowUpGroupBox.Enabled = value;
                linkGroupBox.Enabled = value;
                customFieldControl.Enabled = value;
                logTemplateComboBox.Enabled = value;
                logCommentControl.Enabled = value;
            }
        }
    }
}
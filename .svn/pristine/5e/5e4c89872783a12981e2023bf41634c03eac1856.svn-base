using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using System.IO;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SummaryLogForm : BaseForm, ISummaryLogFormView
    {
        public event Action HandleLogTemplateButtonClick;

        private readonly bool onlyAllowedToEditDORComments;
        private readonly bool hideDORCommentEntry;

        private DateTime logDateTime;

        private IMultiSelectFunctionalLocationSelectionForm sectionLevelFlocSelector;

        private readonly SummaryLogFormPresenter presenter;
        

        public SummaryLogForm(bool hideDORCommentEntry, bool allowedToAddShiftInformation)
        {
            this.hideDORCommentEntry = hideDORCommentEntry;

            Initialize();
            this.selectLogsForSummaryButton.Enabled = allowedToAddShiftInformation;
            presenter = new SummaryLogFormPresenter(this);
            RegisterEventHandler();
        }

        //Aarti RITM0512605:Copy feature for Shift Summary log
        public SummaryLogForm(SummaryLog logToUpdate, bool hideDORCommentEntry)
        {
            this.hideDORCommentEntry = hideDORCommentEntry;
            Initialize();
            presenter = new SummaryLogFormPresenter(this, logToUpdate);
            RegisterEventHandler();
        }
       
        public SummaryLogForm(SummaryLog logToUpdate, bool onlyAllowedToEditDORComments, bool hideDORCommentEntry, bool allowedToAddShiftInformation)
        {
            this.onlyAllowedToEditDORComments = onlyAllowedToEditDORComments;
            this.hideDORCommentEntry = hideDORCommentEntry;

            Initialize();

            presenter = new SummaryLogFormPresenter(this, logToUpdate, onlyAllowedToEditDORComments);
            RegisterEventHandler();

            if (onlyAllowedToEditDORComments)
            {
                MakeControlsAndChildControlsReadOnly(scrollingPanel.Controls);
                selectLogsForSummaryButton.Enabled = false;
                dorTextBox.ReadOnly = false;
                dorTextBox.Enabled = true;
            }
            else
            {
                selectLogsForSummaryButton.Enabled = allowedToAddShiftInformation;
            }
        }
        
        
        private void Initialize()
        {
            InitializeComponent();
            tableLayoutPanel.ControlThatShouldFillEmptySpace = templateAndCommentsTableLayoutPanel;


            //ayman floc level from site conf
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConf = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            var itemFlocSelectionLevel = siteConf.ShiftLogFlocLevel;

            if (itemFlocSelectionLevel > 0)
            {
                if (itemFlocSelectionLevel == 1)
                {
                    sectionLevelFlocSelector =
                        new MultiSelectFunctionalLocationSelectionForm(
                            FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                            new FunctionalLocationIsSelectedByUserFilter(), true);
                }


                else if (itemFlocSelectionLevel == 2)
                {
                    sectionLevelFlocSelector =
                        new MultiSelectFunctionalLocationSelectionForm(
                            FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                            new FunctionalLocationIsSelectedByUserFilter(), true);
                }
                else if (itemFlocSelectionLevel == 3)
                {
                    sectionLevelFlocSelector =
                        new MultiSelectFunctionalLocationSelectionForm(
                            FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                            new FunctionalLocationIsSelectedByUserFilter(), true);
                }

            }
            else
            {
                sectionLevelFlocSelector =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(), true);
            }

            if (hideDORCommentEntry)
            {
                HideDorCommentEntry();
            }
        }

        private void RegisterEventHandler()
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            FormClosed += presenter.HandleFormClosed;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            addFunctionalLocationButton.Click += presenter.HandleAddFunctionalLocationButtonClick;
            removeFunctionalLocatnButton.Click += presenter.HandleRemoveFunctionalLocationButtonClick;

            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            saveButton.Click += presenter.HandleSaveClick;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;
            selectLogsForSummaryButton.Click += presenter.SelectLogsForSummaryButtonClick;
            importCustomFieldsButton.Click += presenter.HandleImportCustomFieldsButtonClick;
            actualLoggedTime.ValueChanged += presenter.HandleLogDateTimeChanged;
            logCommentControl.GuidelineLinkClick += presenter.HandleLogCommentGuidelineLinkClick;
            insertTemplateButton.Click += InsertLogTemplateButtonClicked;
        }

        private void InsertLogTemplateButtonClicked(object sender, EventArgs e)
        {
            if (HandleLogTemplateButtonClick != null)
            {
                HandleLogTemplateButtonClick();
            }
        }

        
        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections)
        {
            //ayman floc level from site conf
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConf = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            var itemFlocSelectionLevel = siteConf.ShiftLogFlocLevel;



            if (itemFlocSelectionLevel > 0)
            {

                IMultiSelectFunctionalLocationSelectionForm selector;

                selector = sectionLevelFlocSelector;



                DialogResult dialogResult = selector.ShowDialog(this, initialUserFLOCSelections);
                IList<FunctionalLocation> selectedFunctionalLocations = sectionLevelFlocSelector.UserSelectedFunctionalLocations;

                List<FunctionalLocation> listBecauseSillyControlReturnsAnIListForSomeReason =
                    new List<FunctionalLocation>(selectedFunctionalLocations);
                return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult, listBecauseSillyControlReturnsAnIListForSomeReason);
            }
            else
            {
                DialogResult dialogResult = sectionLevelFlocSelector.ShowDialog(this, initialUserFLOCSelections);
                IList<FunctionalLocation> selectedFunctionalLocations = sectionLevelFlocSelector.UserSelectedFunctionalLocations;

                List<FunctionalLocation> listBecauseSillyControlReturnsAnIListForSomeReason =
                    new List<FunctionalLocation>(selectedFunctionalLocations);
                return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult, listBecauseSillyControlReturnsAnIListForSomeReason);
            }
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

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public List<FunctionalLocation> AssociatedFunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public void CloseForm()
        {
            Close();
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

        public string RtfComments
        {
            get { return logCommentControl.Text; }
            set { logCommentControl.Text = value; }
        }

        public string CommentsAsPlainText
        {
            get { return logCommentControl.PlainText; }
        }

        public string DorComments
        {
            get { return dorTextBox.Text; }
            set { dorTextBox.Text = value; }
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

        public void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
        {
            LogFormHelper.SetCustomFieldPhTagAssociationControlsVisible(customFieldPhTagLegendControl, importCustomFieldsButton, customFieldControl, customFieldsPanel,
                hasPhdReadCustomField, hasPhdWriteCustomField);
        }

        public LogTemplateDTO SelectedLogTemplate
        {
            get { return (LogTemplateDTO)logTemplateComboBox.SelectedItem; }
            set { logTemplateComboBox.SelectedItem = value; }
        }

        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            customFieldControl.CustomFieldClicked += presenter.HandleCustomFieldClick;
            customFieldControl.SetCustomFieldEntries(customFieldEntries, customFields, onlyAllowedToEditDORComments);
            customFieldsPanel.Visible = customFields.Count > 0;
        }

        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries)
        {
            customFieldControl.TurnOnHighlighting(entries);
        }

        public void MakeCommentControlFillAnyVerticalSpace()
        {
            tableLayoutPanel.FillUpAnyExtraVerticalSpace();
        }

        private void HideDorCommentEntry()
        {
            int rowWithDorCommentsInside = templateAndCommentsTableLayoutPanel.GetRow(dorCommentGroupBox);
            templateAndCommentsTableLayoutPanel.RowStyles[rowWithDorCommentsInside].Height = 0;
        }

        public string Shift
        {
            set { shiftLabelData.Text = value; }
        }

        public string Author
        {
            set { createdByLabelData.Text = value; }
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
            errorProvider.SetError(functionalLocationListBox, StringResources.FieldEmptyError);
        }

        public void SetLogDateTimeError()
        {
            errorProvider.SetError(actualLoggedTime,
                String.Format(StringResources.LogActualTimeMustBeWithinCurrentShift,
                ClientSession.GetUserContext().UserShift.StartDateTimeWithPadding.ToTime(),
                ClientSession.GetUserContext().UserShift.EndDateTimeWithPadding.ToTime()));
        }

        public void SetLogTimeInTheFutureError()
        {
            errorProvider.SetError(actualLoggedTime, StringResources.FutureTimeError);
        }

        public List<DocumentLink> AssociatedDocumentLinks
        {
            get { return logDocumentLinksControl.DataSource as List<DocumentLink>; }
            set { logDocumentLinksControl.DataSource = value; }
        }

        public void ClearErrorProviders()
        {
            logCommentControl.ClearErrorProviders();
            errorProvider.Clear();
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public DialogResultAndOutput<List<string>> ShowSelectLogsForSummaryForm()
        {
            SelectItemsForShiftSummaryPresenter presenter = new SelectItemsForShiftSummaryPresenter(new SelectItemsForShiftSummaryForm());
            DialogResult result = presenter.Run(this);
            selectLogIDsForSummaryPresenter = SetSelectLogItemsForSummaryPresenter(presenter);//RITM0164968-  mangesh
            return new DialogResultAndOutput<List<string>>(result, presenter.LogTextForSummary);
        }

        //RITM0164968-  mangesh
        private string selectLogIDsForSummaryPresenter = string.Empty;
        public string SelectLogIDsForSummaryPresenter
        {
            get
            {
                return selectLogIDsForSummaryPresenter;
            }
            set
            {
                selectLogIDsForSummaryPresenter = value;
            }
        }

        
        private string SetSelectLogItemsForSummaryPresenter(SelectItemsForShiftSummaryPresenter presenter)
        {
            return presenter.LogIdForSummary;
        }

        public void ShowTooLateToSaveDialog()
        {
            OltMessageBox.Show(this, StringResources.SummaryLog_SaveNoLongerPermitted);
        }

        public bool IsCommentEmpty
        {
            get { return logCommentControl.IsEmpty; }
        }

        public void AppendComments(List<string> comments)
        {
            comments.ForEach(logCommentControl.AppendText);
        }

        public void ShowGuidelines(List<LogGuideline> logGuidelines)
        {
            logCommentControl.ShowLogGuidelineForm(logGuidelines);
        }

        public bool ShowLogMarkedAsReadWarning()
        {
            DialogResult result = OltMessageBox.Show(
                this,
                StringResources.EditingItemMarkedAsReadWarning,
                StringResources.EditingItemMarkedAsReadWarning_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return DialogResult.Yes.Equals(result);
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

        public void ApplyLogTemplateText(string text)
        {
            logCommentControl.AppendText(text);
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
                linkGroupBox.Enabled = value;
                functionalLocationGroupBox.Enabled = value;
                requiresFollowUpGroupBox.Enabled = value;
            }
        }

        //RITM0443261 : Added by Amit {Change the name for Shift Summary log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        public string SetShiftSummaryLogMenuItemName
        {
            set { this.Text = value; }
        }
        //END




        //Mukesh for Log Image
        //System.Data.DataTable dt = new System.Data.DataTable();
        List<LogImage> lstimage = new List<LogImage>();
        public List<LogImage> ImageLogdetails
        {
            set
            {

                lstimage = value;
                oltDGVImage.AutoGenerateColumns = false;
                oltDGVImage.DataSource = value;
                oltDGVImage.Refresh();
            }
            get
            {
                foreach (DataGridViewRow row in oltDGVImage.Rows)
                {
                    if (row.Index > 0)
                    {
                        lstimage[row.Index].Name = Convert.ToString(row.Cells["ImageName"].Value);
                        lstimage[row.Index].Description = Convert.ToString(row.Cells["Description"].Value);

                    }
                }

                return lstimage;
            }
        }
        private void oltButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            txtFilePath.Text = openFileDialog1.FileName;
        }

        private void oltButton2_Click(object sender, EventArgs e)
        {
            errorProviderImage.Clear();

            if (oltCmbImageType.Text.ToUpper() == "IMAGE")
            {
                foreach (string strFileName in openFileDialog1.FileNames)
                {
                    LogImage Img = new LogImage();
                    Img.RecordType = LogImage.RecordTypes.Summary;
                    Img.Name = txtName.Text;
                    Img.Description = txtDescription.Text;
                    Img.ImagePath = strFileName;// txtFilePath.Text;
                    Img.Id = 0;
                    Img.Action = "Insert";    
                    Img.Types = LogImage.Type.Image;
                if (!File.Exists(txtFilePath.Text))
                {
                    errorProviderImage.SetError(txtFilePath, "File not exists");
                    return;
                }

                  
                    lstimage.Add(Img);
                }
            }
            else if (oltCmbImageType.Text.ToUpper() == "TITLE")
            {
                LogImage Img = new LogImage();
                Img.RecordType = LogImage.RecordTypes.Summary;
                Img.Name = txtName.Text;
                Img.Description = txtDescription.Text;
                Img.ImagePath = string.Empty;
                Img.Id = 0;
                Img.Action = "Insert"; 
                Img.Types = LogImage.Type.Title;
                Img.ImagePath = string.Empty;
                lstimage.Add(Img);
            }


            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            oltCmbImageType.SelectedIndex = -1;

           
            List<LogImage> lst = new List<LogImage>(lstimage);
            oltDGVImage.AutoGenerateColumns = false;
            oltDGVImage.DataSource = null;
            oltDGVImage.DataSource = lst;
            //.FindAll(A => A.Action != "Remove");
            oltDGVImage.Refresh();
        }

        private void oltComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (oltCmbImageType.Text == "")
            {
                oltbtnAdd.Enabled = false;
            }
            else
            {
                oltbtnAdd.Enabled = true;
            }
            if (oltCmbImageType.Text.ToUpper() == "Image".ToUpper())
            {
                txtFilePath.Enabled = true;
                oltbtnbrowse.Enabled = true;
                txtDescription.Enabled = true;


            }
            else
            {
                txtFilePath.Text = string.Empty;
                txtFilePath.Enabled = false;
                oltbtnbrowse.Enabled = false;
                txtDescription.Text = string.Empty;
                txtDescription.Enabled = false;
            }
        }

        private void oltDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            oltDGVImage.Rows[e.RowIndex].Cells[6].Value = "Remove";
           // lstimage[e.RowIndex].Action = "Remove";
           // ImageLogdetails = lstimage;

        }



        public bool setLogImage
        {
            set
            {
                oltLabelLogImagesTitle.Visible = value;
                oltTableLayoutLogImagesPanel.Visible = value;
                saveButton.Visible = !value;

            }

        }


    }
}

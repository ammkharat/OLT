using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using log4net;
using System.IO;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LogForm : BaseForm, ILogFormView
    {
        public event Action HandleLogTemplateButtonClick;

        private static readonly ILog logger = LogManager.GetLogger(typeof(LogForm));
        
        private LogFormPresenter presenter;
        private IMultiSelectFunctionalLocationSelectionForm unitLevelFunctionalLocationSelector;
        private IMultiSelectFunctionalLocationSelectionForm sectionLevelFunctionalLocationSelector;        
        private DateTime logDateTime;
        private List<DocumentRootUncPath> documentRoots;

        private enum Mode { Edit, Copy };

        public LogForm()
        {
            Initialize();
            presenter = new LogFormPresenter(this);
            RegisterEventHandler();          
           
        }

        private LogForm(Log log, Mode mode)
        {
            Initialize();
            if (mode == Mode.Edit)
            {
                presenter = new LogFormPresenter(this, log);
            } 
            else if (mode == Mode.Copy)
            {
                presenter = new LogFormPresenter(this, new LogCopyStrategy(log));
            }
            RegisterEventHandler();
            // By Vibhor : RITM0272920              
            if (ClientSession.GetUserContext().UserRoleElements.Role.IsAdministratorRole && ClientSession.GetUserContext().SiteConfiguration.AllowAdminToCreateAndEditPastDateLog)
            {
                logDateTimeLabelData.Enabled = true;
                actualLoggedTime.Enabled = false;
            }
            //END
        }

        public static LogForm CreateForUpdate(Log logToUpdate)
        {
            return new LogForm(logToUpdate, Mode.Edit);
        }

        public static LogForm CreateForCopy(Log logToCopy)
        {
            return new LogForm(logToCopy, Mode.Copy);
        }

        private void Initialize()
        {
            InitializeComponent();
            tableLayoutPanel.ControlThatShouldFillEmptySpace = templateAndCommentsTableLayoutPanel;

            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            
            unitLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level3);
            
            //Change Log creation to display FLOC from Level 1  ---implemented by Sarika
           
            #region if-else..getting Fuctional Mode

            //ayman floc level from site configuration
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConf = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            var itemFlocSelectionLevel = siteConf.ShiftLogFlocLevel;
            //- floc level --setting  value flocSelectionLevel--while loading- 24jan
            ClientSession.GetUserContext().SiteConfiguration.ShiftLogFlocLevel = itemFlocSelectionLevel;
            //siteConf.ItemFlocSelectionLevel = itemFlocSelectionLevel;
          
            if (itemFlocSelectionLevel == 1)
            {
                sectionLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level1);
            }


            else if (itemFlocSelectionLevel == 2)
            {
                sectionLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level2);
            }
            else if (itemFlocSelectionLevel == 3)
            {
                sectionLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level3);
            }

            else
                sectionLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level2);
                 //throw new ArgumentException("The Value of  ShiftLogFlocLevel must be within 1 to 3 <" + this + ">");
       
            #endregion
        }

        private void RegisterEventHandler()
        {
            scrollingPanel.MouseWheeling += ScrollingPanel_MouseWheeling;
            additionalDetailsToggleButton.Toggled += AdditionalDetailsButton_Toggled;

            FormClosed += presenter.HandleFormClosed;
            FormClosed += HandleFormClosed;
            Load += presenter.HandleLoadPage; 
            FormClosing += presenter.HandleFormClosing;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            removeFLOCButton.Click += presenter.HandleRemoveFlocButtonClick;
            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;
            // By Vibhor : RITM0272920 
            if (ClientSession.GetUserContext().UserRoleElements.Role.IsAdministratorRole && ClientSession.GetUserContext().SiteConfiguration.AllowAdminToCreateAndEditPastDateLog)
            {
                actualLoggedTime.Leave += presenter.actualLoggedTime_Leave;
            }
            else
            {
                actualLoggedTime.ValueChanged += presenter.LogDateTimeChanged;
            }
            //end   
            
            insertTemplateButton.Click += InsertLogTemplateButtonClick;
            selectLogsForSummaryButton.Click += presenter.SelectLogsForSummaryButton_Click;
            logCommentControl.GuidelineLinkClick += presenter.LogCommentControlGuidelineLinkClick;
            importCustomFieldsButton.Click += presenter.HandleImportCustomFieldButtonClick;
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

            FormClosed -= presenter.HandleFormClosed;
            FormClosed -= HandleFormClosed;
            Load -= presenter.HandleLoadPage;
            FormClosing -= presenter.HandleFormClosing;
            cancelButton.Click -= presenter.HandleCancelButtonClick;
            functionalLocationButton.Click -= presenter.HandleFunctionalLocationButtonClick;
            removeFLOCButton.Click -= presenter.HandleRemoveFlocButtonClick;
            saveAndCloseButton.Click -= presenter.HandleSaveAndCloseButtonClick;
            viewEditHistoryButton.Click -= presenter.HandleViewEditHistoryButtonClick;
            actualLoggedTime.ValueChanged -= presenter.LogDateTimeChanged;
            insertTemplateButton.Click -= InsertTemplateButtonClick;
            selectLogsForSummaryButton.Click -= presenter.SelectLogsForSummaryButton_Click;
            logCommentControl.GuidelineLinkClick -= presenter.LogCommentControlGuidelineLinkClick;
        }

        private void InsertTemplateButtonClick(object sender, EventArgs e)
        {
            if (HandleLogTemplateButtonClick != null)
            {
                HandleLogTemplateButtonClick();
            }
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

        private void HandleFormClosed(object sender, FormClosedEventArgs e)
        {
            UnRegisterEventHandler();
            presenter = null;
        }

        public DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> initialUserFLOCSelection, FunctionalLocationType selectionFLOCLevel)
        {
            IMultiSelectFunctionalLocationSelectionForm selector;

            if (selectionFLOCLevel.Equals(FunctionalLocationType.Level2))
            {
                selector = sectionLevelFunctionalLocationSelector;
            }
            //sarika---floc level changes- 24jan
            else if (selectionFLOCLevel.Equals(FunctionalLocationType.Level1))
            {
                selector = sectionLevelFunctionalLocationSelector;
            }
                //end//
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

        //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
        public string SetShiftLogMenuItemName
        {
            set {    this.Text = value; }
        }
        //END

        public string CommentsAsPlainText
        {
            get { return logCommentControl.PlainText; }
        }

        public bool LogTimeControlEnabled
        {
            get { return actualLoggedTime.Enabled; }
            set { actualLoggedTime.Enabled = value; }
        }

        public bool SelectLogsForSummaryButtonEnabled
        {
            set { selectLogsForSummaryButton.Enabled = value; }
        }

        public string Shift
        {
            set
            {
                shiftLabelData.Text = value; 
            }
            
            
        }      
        
        public string Author
        {
            set { createdByLabelData.Text = value; }
        }

        public void ClearLogValidationErrorProviders()
        {
            ClearErrorProviders();
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
            // By Vibhor : RITM0272920 
            actualLoggedDateErrorProvider.SetError(logDateTimeLabelData, StringResources.FutureTimeError); 
            //END
        }

        public void SetLogDateTimeError()
        {
            UserShift userShift = ClientSession.GetUserContext().UserShift;
            LogFormHelper.SetLogDateTimeError(actualLoggedDateErrorProvider, userShift, actualLoggedTime);
        }

        public void SetCustomFieldMustContainANumberError(CustomFieldEntry entry)
        {
            customFieldControl.SetError(errorProvider, entry, StringResources.NumericFieldError);
        }

        public void SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(CustomFieldEntry entry)
        {
            customFieldControl.SetError(errorProvider, entry, StringResources.NumberNeedsToConformToPrecision18AndScale6Error);
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
            get
            {
                // By Vibhor : RITM0272920 
                return Convert.ToDateTime(logDateTimeLabelData.Value + " " + actualLoggedTime.Value);
                    //logDateTime; 
                //end
            }
            set
            {
                logDateTime = value;
                actualLoggedTime.Value = logDateTime.ToTime();
                // By Vibhor : RITM0272920 
                logDateTimeLabelData.Value = new Date(value.Date);   
                //END
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
            flocButtonsPanel.Visible = false;
        }

        public void HideLogTemplateComponent()
        {
            templatePanel.Visible = false;
        }

        public void ShowLogTemplateComponent()
        {
            templatePanel.Visible = true;
        }

        public string OperatingEngineerLogDisplayName
        {
            set { IsOperatingEngineerLogCheckBox.Text = value; }
        }

        public void HideOperatingEngineerCheckBox()
        {
            IsOperatingEngineerLogCheckBox.Hide();
        }

        public bool RecommendForShiftSummary
        {
            get { return recommendForShiftSummaryCheckBox.Checked; }
            set { recommendForShiftSummaryCheckBox.Checked = value; }
        }

        public void HideFunctionalLocationButtonsAndDisableMultipleFunctionalLocationOptions()
        {
            flocButtonsPanel.Visible = false;
            multipleFunctionalLocationGroupBox.Enabled = false;
        }

        public bool IsOperatingEngineerLog
        {
            get
            {
                return IsOperatingEngineerLogCheckBox.Checked;
            }
            set
            {
                IsOperatingEngineerLogCheckBox.Checked = value;
            }
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

        

        public DialogResultAndOutput<List<string>> ShowSelectLogsForSummaryForm()
        {
            SelectItemsForShiftSummaryPresenter presenter = new SelectItemsForShiftSummaryPresenter(new SelectItemsForShiftSummaryForm());
            DialogResult result = presenter.Run(this);
            return new DialogResultAndOutput<List<string>>(result, presenter.LogTextForSummary);
        }
        
        public void AppendComments(List<string> textToAppend)
        {
            textToAppend.ForEach(logCommentControl.AppendText);                   
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

        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries)
        {
            customFieldControl.TurnOnHighlighting(entries);
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

        public void HideFollowupFlags()
        {
            followupGroupBox.Visible = false;
        }

        public void HideMultipleFunctionalLocationOptions()
        {
            multipleFunctionalLocationGroupBox.Visible = false;
        }

        public bool ExpandAdditionalDetails
        {
            set
            {
                additionalDetailsToggleButton.Expanded = value;
                AdditionalDetailsButton_Toggled(value);
            }
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
                templatePanel.Enabled = value;
                advancedDetailsTableLayoutPanel.Enabled = value;
                functionalLocationAndOptionsPanel.Enabled = value;
                logTimeGroupBox.Enabled = value;
            }
        }
        //Mukesh for Log Image
        //System.Data.DataTable dt = new System.Data.DataTable();
        List<LogImage> lstimage = new List<LogImage>();
        public List<LogImage> ImageLogdetails
        {
            set{

                lstimage = value;
                oltDGVImage.AutoGenerateColumns = false;
                oltDGVImage.DataSource = null;
                oltDGVImage.DataSource = value;
               
            }
            get
            {
                foreach(DataGridViewRow row in oltDGVImage.Rows)
                {
                       if (row.Index > 0 )
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
            //openFileDialog1.ShowDialog();
          
            //txtFilePath.Text = openFileDialog1.FileName;

            //Added by Vibhor : RITM0502408 - Browse option for images similar to Add document form

            AddNewDocumentLinkFormPresenter doc = new AddNewDocumentLinkFormPresenter(ClientServiceRegistry.Instance.GetService<IDocumentLinkService>());
            documentRoots = doc.GetFlocData();

            if (documentRoots.Count == 1)
                DisplayFileBrowser(documentRoots[0]);
            else
            {
                DocumentRootUncPath selectedDocumentRoot = DisplayRootSelector();

                if (selectedDocumentRoot != null)
                    DisplayFileBrowser(selectedDocumentRoot);
            }
            //END
        }

        //Added by Vibhor : RITM0502408 - Browse option for images similar to Add document form
        #region Added by Vibhor : RITM0502408 - Browse option for images similar to Add document form

        private void SelectFile(DocumentRootUncPath uncPath)
        {
            string path = uncPath.Path;

            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
                openFileDialog1.Title = string.Format(StringResources.AddDocumentLinkFileDialogTitle, uncPath.PathName);
            }

            DialogResult dialogResult = openFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                documentLink = fileName;
            }

        }

        public string documentLink
        {
            get
            {
                return txtFilePath.Text;
            }
            private set { txtFilePath.Text = value; }
        }

        public DocumentRootUncPath DisplayRootSelector()
        {
            DocumentRootSelectionForm form = new DocumentRootSelectionForm { StartPosition = FormStartPosition.CenterParent };
            DialogResult dialogResult = form.ShowDialog(this);

            return dialogResult == DialogResult.OK ? form.SelectedItem : null;
        }

        private void DisplayFileBrowser(DocumentRootUncPath uncPath)
        {
            SelectFile(uncPath);
        }

        #endregion 



        private void oltButton2_Click(object sender, EventArgs e)
        {
            errorProviderImage.Clear();
            if (oltCmbImageType.Text.ToUpper() == "IMAGE")
            {
                foreach (string strfileName in openFileDialog1.FileNames)
                {
                    LogImage Img = new LogImage();
                    Img.RecordType = LogImage.RecordTypes.Log;
                    Img.Name = txtName.Text;
                    Img.Description = txtDescription.Text;
                    Img.ImagePath = strfileName;// txtFilePath.Text;
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
                        Img.RecordType = LogImage.RecordTypes.Log;
                        Img.Id = 0;
                        Img.Name = txtName.Text;
                        Img.Types = LogImage.Type.Title;
                        Img.ImagePath = string.Empty;
                        Img.Action = "Insert"; 
                        lstimage.Add(Img);
                    }
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            oltCmbImageType.SelectedIndex = -1 ;
            List<LogImage> lst = new List<LogImage>(lstimage);
            oltDGVImage.AutoGenerateColumns = false;
            oltDGVImage.DataSource = null;
            oltDGVImage.DataSource = lst;//.FindAll(A => A.Action != "Remove");
           
        }

        private void oltComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (oltCmbImageType.Text=="")
            {
                oltbtnAdd.Enabled=false;
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
                txtDescription.Enabled = false;
                txtDescription.Text = string.Empty;
                
            }
        }

        private void oltDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=0) return;
            oltDGVImage.Rows[e.RowIndex].Cells[6].Value = "Remove";
           // lstimage[e.RowIndex].Action = "Remove";
           

        }


        public bool setLogImage
        {
            set{
                oltLabelLogImagesTitle.Visible = value;
                oltTableLayoutLogImagesPanel.Visible = value;
            
            }

        }

       

      
        
        
        
    }
}
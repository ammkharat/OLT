using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using System.IO;
using Com.Suncor.Olt.Common;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ShiftHandoverQuestionnaireAndLogForm : BaseForm, IShiftHandoverQuestionnaireAndLogFormView
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Func<bool> HandoverTypeChanged;
        public event Action FormLoad;
        public event Action<CustomField> CustomFieldClicked;
        public event Action AddFunctionalLocation;
        public event Action RemoveFunctionalLocation;
        public event Action Cancel;
        public event Action SelectInfoForSummary;
        public event Action LogGuidelineClick;
        public event Action Save;
        public event Action ActualLoggedTimeValueChanged;
        public event Action ImportCustomFields;
        public event Action HandleLogTemplateButtonClick;
        public event Action<bool> Flexishifthandovercheck;
        private readonly ShiftHandoverAnswerTableLayoutRenderer answerRenderer;
        private ShiftHandoverConfiguration lastSelectedConfiguration;
        private DateTime logDateTime;
        private readonly IMultiSelectFunctionalLocationSelectionForm unitLevelFunctionalLocationSelector;
        private readonly IMultiSelectFunctionalLocationSelectionForm sectionLevelFunctionalLocationSelector;

        public ShiftHandoverQuestionnaireAndLogForm()
        {
            InitializeComponent();

            answerRenderer = new ShiftHandoverAnswerTableLayoutRenderer(this, questionsTableLayoutPanel);

            handoverTypeComboBox.SelectedValueChanged += HandleHandoverTypeSelectedValueChanged;
            additionalDetailsToggleButton.Toggled += HandleAdditionalDetailsToggled;
            customFieldTableLayoutPanel.CustomFieldClicked += HandleCustomFieldClicked;
            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClick;
            removeFunctionalLocationButton.Click += HandleRemoveFlocButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            selectInfoForSummaryButton.Click += HandleSelectInfoForSummaryButtonOnClick;
            logCommentControl.GuidelineLinkClick += HandleLogCommentGuidelineClick;
            saveAndCloseButton.Click += HandleSaveButtonClicked;

            actualLoggedTime.ValueChanged += HandleActualLoggedTimeValueChanged;
            insertTemplateButton.Click += InsertLogTemplateClicked;
            importCustomFieldsButton.Click += HandleImportCustomFieldsButtonClicked;

            /**/
            FlextShiftHandoverChkBox.CheckedChanged += HandleFlexibleShiftHandoverCheckChange;
            /**/


            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            unitLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level3);
            sectionLevelFunctionalLocationSelector = LogFormHelper.CreateFlocSelector(siteConfiguration, FunctionalLocationType.Level2);
        }


        private void HandleFlexibleShiftHandoverCheckChange(object sender, EventArgs e)
        {

            if (Flexishifthandovercheck != null)
            {
                // AddFunctionalLocation();
                Flexishifthandovercheck(FlextShiftHandoverChkBox.Checked);
            }

        }

        private void HandleImportCustomFieldsButtonClicked(object sender, EventArgs e)
        {
            if (ImportCustomFields != null)
            {
                ImportCustomFields();
            }
        }

        private void InsertLogTemplateClicked(object sender, EventArgs e)
        {
            if (HandleLogTemplateButtonClick != null)
            {
                HandleLogTemplateButtonClick();
            }
        }

        private void HandleActualLoggedTimeValueChanged(object sender, EventArgs e)
        {
            if (ActualLoggedTimeValueChanged != null)
            {
                ActualLoggedTimeValueChanged();
            }
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (Save != null)
            {
                Save();
            }
        }

        private void HandleLogCommentGuidelineClick(object sender, EventArgs eventArgs)
        {
            if (LogGuidelineClick != null)
            {
                LogGuidelineClick();
            }
        }

        private void HandleSelectInfoForSummaryButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (SelectInfoForSummary != null)
            {
                SelectInfoForSummary();
            }            
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel();
            }
        }

        private void HandleRemoveFlocButtonClick(object sender, EventArgs e)
        {
            if (RemoveFunctionalLocation != null)
            {
                RemoveFunctionalLocation();
            }
        }

        private void HandleAddFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            if (AddFunctionalLocation != null)
            {
                AddFunctionalLocation();
            }
        }

        private void HandleCustomFieldClicked(CustomField customField)
        {
            if (customField == null || customField.Type == CustomFieldType.Heading ||
               customField.Type == CustomFieldType.BlankSpace) return;

            if (CustomFieldClicked != null)
            {
                CustomFieldClicked(customField);
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

        private void HandleHandoverTypeSelectedValueChanged(object sender, EventArgs eventArgs)
        {
            if (HandoverTypeChanged != null)
            {
                bool handled = HandoverTypeChanged();
                if (handled)
                {
                    lastSelectedConfiguration = SelectedConfiguration;
                }
            }
        }

        public void SetCustomFieldMustContainANumberError(CustomFieldEntry entry)
        {
            customFieldTableLayoutPanel.SetError(logValidationErrorProvider, entry, StringResources.NumericFieldError);
        }

        public void SetCustomFieldMustContainANumberWithCorrectNumberOfDigitsError(CustomFieldEntry entry)
        {
            customFieldTableLayoutPanel.SetError(logValidationErrorProvider, entry, StringResources.NumberNeedsToConformToPrecision18AndScale6Error);
        }

        //Added by ppanigrahi.
        public bool GetAnswerCommentEnabled(ShiftHandoverAnswer answer)
        {
            return answerRenderer.GetControlEnabled(answer);
        }
        public void ClearErrorProviders()
        {
            ClearLogValidationErrorProviders();
            ClearShiftQuestionnaireErrorProviders();
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
                questionsTableLayoutPanel.Enabled = value;
                buttonPanel.Enabled = value;
                templatePanel.Enabled = value;
                advancedDetailsTableLayoutPanel.Enabled = value;
                functionalLocationAndOptionsPanel.Enabled = value;
                logTimeGroupBox.Enabled = value;
            }
        }

        public void SetYesNoError(ShiftHandoverAnswer answer)
        {
            answerRenderer.SetYesNoError(answer);
        }

        public void SetAnswerCommentsError(ShiftHandoverAnswer answer)
        {
            answerRenderer.SetCommentsError(answer);
        }

        public void SetHelpText(ShiftHandoverQuestion question)
        {
            answerRenderer.SetHelpText(question);
        }

        public List<ShiftHandoverAnswer> Answers
        {
            set
            {
                SuspendLayout();
                answerRenderer.SetAnswers(value);
                ResumeLayout(false);
            }
        }

        public bool ExpandAdditionalDetails
        {
            set
            {
                additionalDetailsToggleButton.Expanded = value;
                HandleAdditionalDetailsToggled(value);
            }
        }

        public string Shift
        {
            set { shiftLabelData.Text = value; }
        }

        public string Author
        {
            set { createdByLabelData.Text = value; }
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

        private void HandleAdditionalDetailsToggled(bool expanded)
        {
            advancedDetailsTableLayoutPanel.Visible = expanded;
            tableLayoutPanel.FillUpAnyExtraVerticalSpace();
        }

        public string OperatingEngineerLogDisplayName
        {
            set { isOperatingEngineerLogCheckBox.Text = value; }
        }

        public void HideOperatingEngineerCheckBox()
        {
            isOperatingEngineerLogCheckBox.Hide();
        }

        public void ClearLogValidationErrorProviders()
        {
            logCommentControl.ClearErrorProviders();
            logValidationErrorProvider.Clear();
        }

        public void ClearShiftQuestionnaireErrorProviders()
        {
            answerRenderer.ClearErrorProviders();
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocationListBox.FunctionalLocations; }
            set
            {
                functionalLocationListBox.FunctionalLocations = value;
            }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public bool IsCommentEmpty
        {
            get { return logCommentControl.IsEmpty; }
        }

        public void SetCommentsBlankError()
        {
            logCommentControl.SetError(StringResources.CommentFieldEmpty);
        }

        public bool HasAnsweredYesNo(ShiftHandoverAnswer answer)
        {
            return answerRenderer.YesNoAnswer(answer).HasValue;
        }

        public bool? YesNoAnswer(ShiftHandoverAnswer answer)
        {
            return answerRenderer.YesNoAnswer(answer);
        }

        public string GetAnswerComments(ShiftHandoverAnswer answer)
        {
            return answerRenderer.GetAnswerComments(answer);
        }

        public void SetLogTimeInTheFutureError()
        {
            logValidationErrorProvider.SetError(actualLoggedTime, StringResources.FutureTimeError);
        }

        public Time ActualLoggedTime
        {
            get { return actualLoggedTime.Value; }
        }

        public void SetLogDateTimeError()
        {
            UserShift userShift = ClientSession.GetUserContext().UserShift;
            LogFormHelper.SetLogDateTimeError(logValidationErrorProvider, userShift, actualLoggedTime);
        }

        public ShiftHandoverConfiguration SelectedConfiguration
        {
            get { return (ShiftHandoverConfiguration) handoverTypeComboBox.SelectedItem; }
        }

        public List<ShiftHandoverConfiguration> Configurations
        {
            set
            {
                value.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

                handoverTypeComboBox.Items.Clear();
                foreach (ShiftHandoverConfiguration configuration in value)
                {
                    handoverTypeComboBox.Items.Add(configuration);
                }

                if (value.Count > 0)
                {
                    handoverTypeComboBox.SelectedIndex = 0;
                }
            }
        }

        public bool ConfirmDeleteExistingAnswers()
        {
            return ShiftHandoverQuestionnaireFormHelper.ConfirmDeleteExistingAnswers(this);
        }

        public void RevertToLastSelectedConfiguration()
        {
            handoverTypeComboBox.SelectedValueChanged -= HandleHandoverTypeSelectedValueChanged;

            if (lastSelectedConfiguration != null)
            {
                handoverTypeComboBox.SelectedItem = lastSelectedConfiguration;
            }

            handoverTypeComboBox.SelectedValueChanged += HandleHandoverTypeSelectedValueChanged;
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

        public bool IsOperatingEngineerLog
        {
            get
            {
                return isOperatingEngineerLogCheckBox.Checked;                
            }
            set
            {
                isOperatingEngineerLogCheckBox.Checked = value;
            }
        }

        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            customFieldTableLayoutPanel.SetCustomFieldEntries(customFieldEntries, customFields, false);
            customFieldsPanel.Visible = customFields.Count > 0;
        }

        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return customFieldTableLayoutPanel.GetCustomFieldEntryText(entry);
        }

        public string GetCustomFieldEntryText(long customFieldId)
        {
            return customFieldTableLayoutPanel.GetCustomFieldEntryText(customFieldId);
        }

        public void SetCustomFieldEntryText(CustomFieldEntry entry, String text)
        {
            customFieldTableLayoutPanel.SetCustomFieldEntryText(entry, text);
        }

        public void SetLogTemplates(List<LogTemplateDTO> logTemplates)
        {
            logTemplateComboBox.Items.Clear();

            foreach (LogTemplateDTO logTemplate in logTemplates)
            {
                logTemplateComboBox.Items.Add(logTemplate);
            }
        }

        public void ShowLogTemplateComponent()
        {
            templatePanel.Visible = true;
        }

        public void HideLogTemplateComponent()
        {
            templatePanel.Visible = false;
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

        public DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> functionalLocations, FunctionalLocationType flocSelectionLevel)
        {
            IMultiSelectFunctionalLocationSelectionForm selector;

            if (flocSelectionLevel.Equals(FunctionalLocationType.Level2))
            {
                selector = sectionLevelFunctionalLocationSelector;
            }
            else if (flocSelectionLevel.Equals(FunctionalLocationType.Level3))
            {
                selector = unitLevelFunctionalLocationSelector;
            }
            else
            {
                throw new ArgumentException("The flocSelectionLevel argument must be Level2 or Level3");
            }

            DialogResult dialogResult = selector.ShowDialog(this, functionalLocations);
            IList<FunctionalLocation> selected = selector.UserSelectedFunctionalLocations;            
            return new DialogResultAndOutput<IList<FunctionalLocation>>(dialogResult, selected);
        }

        public void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
        {
            LogFormHelper.SetCustomFieldPhTagAssociationControlsVisible(customFieldPhTagLegendControl, importCustomFieldsButton, customFieldTableLayoutPanel, customFieldsPanel,
                hasPhdReadCustomField, hasPhdWriteCustomField);
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return logDocumentLinksControl.DataSource as List<DocumentLink>; }
            set { logDocumentLinksControl.DataSource = value; }
        }

        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries)
        {
            customFieldTableLayoutPanel.TurnOnHighlighting(entries);
        }

        public bool RecommendForShiftSummary
        {
            get { return recommendForShiftSummaryCheckBox.Checked; }
            set { recommendForShiftSummaryCheckBox.Checked = value; }
        }

        public DialogResultAndOutput<List<string>> ShowSelectInfoForSummaryForm()
        {
            SelectItemsForShiftSummaryPresenter presenter = new SelectItemsForShiftSummaryPresenter(new SelectItemsForShiftSummaryForm());
            DialogResult result = presenter.Run(this);
            return new DialogResultAndOutput<List<string>>(result, presenter.LogTextForSummary);
        }

        public void AppendComments(List<string> textToAppend)
        {
            textToAppend.ForEach(logCommentControl.AppendText);
        }

        public void ShowGuidelines(List<LogGuideline> guidelines)
        {
            logCommentControl.ShowLogGuidelineForm(guidelines);
        }

        public void ShowNoConfigurationMessageBox()
        {
            ShiftHandoverQuestionnaireFormHelper.ShowNoConfigurationMessageBox(this);
        }

        public void SetReadOnlyConfiguration(string shiftHandoverConfiguratioName)
        {
            handoverTypeComboBox.SelectedValueChanged -= HandleHandoverTypeSelectedValueChanged;
            handoverTypeComboBox.Items.Clear();
            handoverTypeComboBox.Items.Add(shiftHandoverConfiguratioName);
            handoverTypeComboBox.SelectedIndex = 0;
            handoverTypeComboBox.Enabled = false;
        }

        public void MakeFunctionalLocationsReadOnly()
        {
            functionalLocationListBox.ReadOnly = true;
            functionalLocationListBox.Width = functionalLocationGroupBox.Width - 12;
            addFunctionalLocationButton.Hide();
            removeFunctionalLocationButton.Hide();
        }

        public bool ShowHandoverMarkedAsReadWarning()
        {
            return ShiftHandoverQuestionnaireFormHelper.ShowHandoverMarkedAsReadWarning(this);

        }

        public void SetTooltipOnExistingLogsSection(string caption)
        {
            toolTip.SetToolTip(richTextCommentDisplay, caption);
        }

        public void SetAndFormatComments(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> summaryLogComments, List<HasCommentsDTO> logComments)
        {
            ShiftHandoverQuestionnaireFormHelper.SetAndFormatComments(handover, summaryLogComments, logComments, richTextCommentDisplay);
        }

        public void AddCokerCardSummaries(List<CokerCardDrumEntryDTO> drumEntryDtos)
        {
            CokerCardSummaryRenderer renderer = new CokerCardSummaryRenderer(richTextCommentDisplay);
            renderer.RenderCokerCardSummaries(drumEntryDtos);
        }

        public void SetFunctionLocationBlankError()
        {
            logValidationErrorProvider.SetError(functionalLocationListBox, StringResources.FieldEmptyError);
        }

        /*amit Shukla RITM RITM0185797 Flexi Shift handover*/
        public void SetFlexibleShiftDateError(string errorToBeDisplayed)
        {
            questionnaireValidationErrorProvider.SetError(ShiftEndDatePickerDatePicker, errorToBeDisplayed);
        }

        public bool IsFlexishifthandoverWithLog
        {
            get { return FlextShiftHandoverChkBox.Checked; }
            set {FlextShiftHandoverChkBox.Checked = value; }     
        }

        public DateTime FlexiShiftStartDate
         {
             get { return new DateTime(ShiftStartDateDatePicker.Year, ShiftStartDateDatePicker.Month, ShiftStartDateDatePicker.Day); }
             set
             {ShiftStartDateDatePicker.Value = value.ToDate();}
         }
        public DateTime FlexiShiftEndDate
         {
             get { return new DateTime(ShiftEndDatePickerDatePicker.Year, ShiftEndDatePickerDatePicker.Month, ShiftEndDatePickerDatePicker.Day); }
             set { ShiftEndDatePickerDatePicker.Value = value.ToDate(); }
         }
        public bool FlextShiftHandoverStatus(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_IS_FLEXIBLE_SHIFT);
        }
        public bool ViewFlexiShiftStartDate
         {
             set { ShiftStartDateDatePicker.Enabled = value; }
         }
        public bool ViewFlexiShiftEndDate
         {
             set
             { ShiftEndDatePickerDatePicker.Enabled = value; }
         }
        public void EnableDisableFlexShiftHandoverbyrole(UserRoleElements userRoleElements)
         {
             FlextShiftHandoverChkBox.Enabled = FlextShiftHandoverStatus(userRoleElements);
         }
        public void EnableDisableFlexShiftHandover(bool enabledisable)
        {
            FlextShiftHandoverChkBox.Enabled = enabledisable;
            ShiftStartDateDatePicker.Enabled =  enabledisable;
            ShiftEndDatePickerDatePicker.Enabled =  enabledisable;
        }
        public void EnableDisableVisiblityFlexShiftHandover(UserRoleElements userRoleElements)
        {
            
            FlextShiftHandoverChkBox.Visible = FlextShiftHandoverStatus(userRoleElements);
            ShiftStartDateDatePicker.Visible = FlextShiftHandoverStatus(userRoleElements);
            ShiftEndDatePickerDatePicker.Visible = FlextShiftHandoverStatus(userRoleElements);
            FlexiShiftHandoverGroupBox.Visible = FlextShiftHandoverStatus(userRoleElements);
            startDateTimeLabel.Visible = FlextShiftHandoverStatus(userRoleElements);
            endDateTimeLabel.Visible = FlextShiftHandoverStatus(userRoleElements);
        }
        /**/

        public void HideOptionsSection()
        {
            optionsGroupBox.Width = 0;
        }


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
        private void oltselectImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            txtFilePath.Text = openFileDialog1.FileName;
        }

        private void oltAddImage_Click(object sender, EventArgs e)
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
                    Img.ImagePath = strFileName; //txtFilePath.Text;
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
           
            else  if (oltCmbImageType.Text.ToUpper() == "TITLE")
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
            oltDGVImage.DataSource = lst; //.FindAll(A => A.Action != "Remove");
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
                txtDescription.Enabled = false;
                txtDescription.Text = string.Empty;
            }
        }

        private void oltDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            oltDGVImage.Rows[e.RowIndex].Cells[6].Value = "Remove";
            //lstimage[e.RowIndex].Action = "Remove";
            //ImageLogdetails = lstimage;

        }
        //Add by ppanigrahi
        public void SetYesNo(ShiftHandoverQuestion question)
        {
            answerRenderer.SetYesNo(question);

        }
        //Add by ppanigrahi
        public void SetEmailList(ShiftHandoverQuestion question)
        {
            answerRenderer.SetEmailList(question);

        }


        public bool setLogImage
        {
            set
            {
                oltLabelLogImagesTitle.Visible = value;
                oltTableLayoutLogImagesPanel.Visible = value;
                //saveButton.Visible = !value;

            }

        }
       public string ShiftLogMessages ;
       public List<ShiftLogMessage> lstShiftLogMessages=new List<ShiftLogMessage>();
       private void selectShiftLogMessages_Click(object sender, EventArgs e)
       {

           DialogResult dialogResult = new ShiftLogMessages(lstShiftLogMessages).ShowDialog(this);
           if (dialogResult == DialogResult.OK)
           {
               string textAsRtf = RichTextUtilities.ConvertTextToRTF(ShiftLogMessages);
               ShiftLogMessages = textAsRtf;
              // logCommentControl.AppendText(textAsRtf);
           }
         

       }

       //Operator Round tool Logbody
      public string OpeartorRoundLogText
       {

           get { return ShiftLogMessages; }
           set { ShiftLogMessages = value; } 
       }

      public bool enableSelectShiftLogMessages
      {
          set { selectShiftLogMessages.Visible = value; }
      }
        //Added by ppanigrahi
      public bool ActiveCsdChecked
      {
          get { return chkActiveCsdLog.Checked; }
          set { chkActiveCsdLog.Checked = value; }

      }
      public bool ActiveCsdCheckBoxVisible
      {
          get { return chkActiveCsdLog.Visible; }
          set { chkActiveCsdLog.Visible = value; }

      }
      //Added by ppanigrahi
      public void EnableActiveCsdCheckBox(UserRoleElements userRoleElements)
      {
          chkActiveCsdLog.Visible = ActiveCsdCheckBoxStaus(userRoleElements);
      }
      public bool ActiveCsdCheckBoxStaus(UserRoleElements userRoleElements)
      {
          return userRoleElements.AuthorizedTo(RoleElement.CSD_LOG);
      }

    }
}
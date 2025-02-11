using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common;


namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ShiftHandoverQuestionnaireForm : BaseForm, IShiftHandoverQuestionnaireFormView
    {
        private readonly ShiftHandoverQuestionnaireFormPresenter presenter;
        private ShiftHandoverConfiguration lastSelectedConfiguration;
        private IMultiSelectFunctionalLocationSelectionForm sectionLevelFunctionalLocationSelector;
        private readonly ShiftHandoverAnswerExplorerBarRenderer answerRenderer;
       
        public ShiftHandoverQuestionnaireForm(ShiftHandoverQuestionnaire questionnaire)
        {
            Initialize();
            answerRenderer = new ShiftHandoverAnswerExplorerBarRenderer(this, explorerBar);
            presenter = new ShiftHandoverQuestionnaireFormPresenter(this, questionnaire);
            RegisterEventHandlersOnPresenter();    
        }

        private void Initialize()
        {
            InitializeComponent();
            //Change Handover creation to display FLOC from Level 1 ---implemented by Sarika
            // old code---sectionLevelFunctionalLocationSelector = new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration), new FunctionalLocationIsSelectedByUserFilter(), true);

            #region if-else..getting Fuctional Mode

            //ayman floc level from site configuration
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConfiguration = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            var itemFlocSelectionLevel = siteConfiguration.ShiftHandoverFlocLevel;


            if (itemFlocSelectionLevel == 1)
            {
                sectionLevelFunctionalLocationSelector =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(), true);
            }


            else if (itemFlocSelectionLevel == 2)
            {
                sectionLevelFunctionalLocationSelector =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(), true);
            }
            else if (itemFlocSelectionLevel == 3)
            {
                sectionLevelFunctionalLocationSelector =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(), true);
            }

            else
                sectionLevelFunctionalLocationSelector = new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration), new FunctionalLocationIsSelectedByUserFilter(), true);
        
               // throw new ArgumentException("The Value of  ShiftHandoverFlocLevel must be within 1 to 3 <" + this + ">");

            #endregion
        }

        private void RegisterEventHandlersOnPresenter()
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;

            addFunctionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            removeFunctionalLocationButton.Click += presenter.HandleRemoveFunctionalLocationButtonClick;
            handoverTypeComboBox.SelectedValueChanged += HandleHandoverTypeComboBox_SelectedValueChanged; 

            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            FlextShiftHandover_ChkBox.CheckedChanged += presenter.HandleFlexibleShiftHandoverCheckChange;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;
       //     chkActiveCsdLog.CheckedChanged += presenter.HanleChkActiveCSDLogChecked;
        }

        private void HandleHandoverTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            bool handled = presenter.HandoverType_SelectedChanged();
            if (handled)
            {
                lastSelectedConfiguration = SelectedConfiguration;
            }
                        
        }
        //  Flexi shift handover amit

        public DateTime FlexiShiftStartDate  {
            get { return  new DateTime(ShiftStartDateDatePicker.Year, ShiftStartDateDatePicker.Month,ShiftStartDateDatePicker.Day); }
            set
            {
                ShiftStartDateDatePicker.Value = value.ToDate();
            }
        }

        //new DateTime(control.SelectedStartDate.Year, control.SelectedStartDate.Month,control.SelectedStartDate.Day);
        public DateTime FlexiShiftEndDate
        {
            

            get { return new DateTime(ShiftEndDatePickerDatePicker.Year, ShiftEndDatePickerDatePicker.Month, ShiftEndDatePickerDatePicker.Day); }
            set { ShiftEndDatePickerDatePicker.Value = value.ToDate(); } 
        }
        public List<EmailAddress> EmailAddresses { get; set; }//Added by ppanigrahi
        

        public bool IsFlexible
        {
            get
            {return FlextShiftHandover_ChkBox.Checked;}
            set { FlextShiftHandover_ChkBox.Checked = value; }
        }

        public bool FlextShiftHandoverStatus(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_IS_FLEXIBLE_SHIFT);
        }

        public bool ActiveCsdCheckBoxStaus(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CSD_LOG);
        }
        public void EnableDisableFlexShiftHandover(UserRoleElements userRoleElements)
        {
            FlextShiftHandover_ChkBox.Enabled = FlextShiftHandoverStatus(userRoleElements);
        }

        public void EnableDisableVisiblityFlexShiftHandover(UserRoleElements userRoleElements)
        {
            // FlextShiftHandover_ChkBox.Enabled = FlextShiftHandoverStatus(userRoleElements);
            FlextShiftHandover_ChkBox.Visible = FlextShiftHandoverStatus(userRoleElements);
            ShiftStartDateDatePicker.Visible = FlextShiftHandoverStatus(userRoleElements);
            ShiftEndDatePickerDatePicker.Visible = FlextShiftHandoverStatus(userRoleElements);
            FlexiShiftHandoverGroupBox.Visible = FlextShiftHandoverStatus(userRoleElements);
            startDateTimeLabel.Visible = FlextShiftHandoverStatus(userRoleElements);
            endDateTimeLabel.Visible = FlextShiftHandoverStatus(userRoleElements);
        }

        //Added by ppanigrahi
        public void EnableActiveCsdCheckBox(UserRoleElements userRoleElements)
        {
            chkActiveCsdLog.Visible = ActiveCsdCheckBoxStaus(userRoleElements);
        }

        public bool ViewFlexiShiftStartDate
        {
            set { ShiftStartDateDatePicker.Enabled = value; }
        }
        public bool ViewFlexiShiftEndDate
        {
            set
            {   ShiftEndDatePickerDatePicker.Enabled = value;}
        }
       
        //  Flexi shift handover amit end
 
        public string Shift
        {
            set
            {

                shiftLabelData.Text=IsFlexible ?" F": value;
            }
        }

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime CreateDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public void ClearShiftQuestionnaireErrorProviders()
        {
            ClearErrorProviders();
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocationListBox.FunctionalLocations; }
            set { functionalLocationListBox.FunctionalLocations = value; }
        }

        public DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelection)
        {
            DialogResult dialogResult = sectionLevelFunctionalLocationSelector.ShowDialog(this, initialUserFLOCSelection);
            IList<FunctionalLocation> selected = sectionLevelFunctionalLocationSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<IList<FunctionalLocation>>(dialogResult, selected);
        }

        public void SetFunctionLocationBlankError()
        {
            functionLocationBlankErrorProvider.SetError(functionalLocationListBox, StringResources.FieldEmptyError);
        }
        /*amit Shukla RITM RITM0185797 Flexi Shift handover*/ 
        public void SetFlexibleShiftDateError(string errorToBeDisplayed)
        {
            functionLocationBlankErrorProvider.SetError(ShiftEndDatePickerDatePicker, errorToBeDisplayed);
        }
        /**/

        public void SetYesNoError(ShiftHandoverAnswer answer)
        {
            answerRenderer.SetYesNoError(answer);
        }

        public void SetAnswerCommentsError(ShiftHandoverAnswer answer)
        {
            answerRenderer.SetCommentsError(answer);
        }

        public void ShowNoConfigurationMessageBox()
        {
            ShiftHandoverQuestionnaireFormHelper.ShowNoConfigurationMessageBox(this);
        }

        public void SetReadOnlyConfiguration(string shiftHandoverConfiguratioName)
        {
            handoverTypeComboBox.SelectedValueChanged -= HandleHandoverTypeComboBox_SelectedValueChanged;
            handoverTypeComboBox.Items.Clear();
            handoverTypeComboBox.Items.Add(shiftHandoverConfiguratioName);
            handoverTypeComboBox.SelectedIndex = 0;
            handoverTypeComboBox.Enabled = false;
            //ShiftStartDateDatePicker.Enabled = false;         //INC0464537 : Commented by Vibhor to apply fix for INC0464537
            //ShiftEndDatePickerDatePicker.Enabled = false;     //INC0464537 : Commented by Vibhor to apply fix for INC0464537
            //FlextShiftHandover_ChkBox.Enabled = false;        //INC0464537 : Commented by Vibhor to apply fix for INC0464537
        }

        public void MakeFunctionalLocationsReadOnly()
        {            
            functionalLocationListBox.ReadOnly = true;
            functionalLocationListBox.Width = functionalLocationGroupBox.Width - 12;
            addFunctionalLocationButton.Hide();
            removeFunctionalLocationButton.Hide();
        }

        public List<ShiftHandoverConfiguration> Configurations
        {
            set
            {
                value.Sort((x,y) => String.Compare(x.Name, y.Name, StringComparison.CurrentCulture));

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

        public ShiftHandoverConfiguration SelectedConfiguration
        {
            get {  return (ShiftHandoverConfiguration)handoverTypeComboBox.SelectedItem; }
        }

        public bool ConfirmDeleteExistingAnswers()
        {
            return ShiftHandoverQuestionnaireFormHelper.ConfirmDeleteExistingAnswers(this);
        }

        public void RevertToLastSelectedConfiguration()
        {
            handoverTypeComboBox.SelectedValueChanged -= HandleHandoverTypeComboBox_SelectedValueChanged;

            if (lastSelectedConfiguration != null)
            {
                handoverTypeComboBox.SelectedItem = lastSelectedConfiguration;
            }

            handoverTypeComboBox.SelectedValueChanged += HandleHandoverTypeComboBox_SelectedValueChanged;            
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public void ClearErrorProviders()
        {
            functionLocationBlankErrorProvider.Clear();
            answerRenderer.ClearErrorProviders();
        }

        public void SetHelpText(ShiftHandoverQuestion question)
        {
            answerRenderer.SetHelpText(question);
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

        public List<ShiftHandoverAnswer> Answers
        {
            set
            {
                SuspendLayout();
                answerRenderer.SetAnswers(value);
                ResumeLayout(false);
            }
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
        //Added by ppanigrahi
        public bool GetAnswerCommentEnabled(ShiftHandoverAnswer answer)
        {
            return answerRenderer.GetControlEnabled(answer);
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

        public bool ShowHandoverMarkedAsReadWarning()
        {
            return ShiftHandoverQuestionnaireFormHelper.ShowHandoverMarkedAsReadWarning(this);
        }
        //Added by ppanigrahi
        public void SetEmailAddresses(string emailAddressList)
        {
            EmailAddresses = EmailAddress.ConvertDelimitedListToEmailAddresses(emailAddressList);
        }


        //Operator Round tool Logbody
        public string ShiftLogMessages;
        public List<ShiftLogMessage> lstShiftLogMessages = new List<ShiftLogMessage>();
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
        //Active CSD LogBody
       // public string CsdLogMessages;
       // public List<CsdLogMessage> LstCsdLogMessages= new List<CsdLogMessage>();
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

    }
}
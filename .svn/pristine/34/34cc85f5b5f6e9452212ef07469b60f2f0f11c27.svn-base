using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using System.IO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;


namespace Com.Suncor.Olt.Client.Forms
{
    //DO NOT "REFACTOR" THIS CLASS, THIS IS THE GOLD STANDARD STRUCTURE FOR FORMS -- Please Discuss with Ka-Wai

    /// <summary>
    /// This is the form that edits and creates action item definition
    /// </summary>
    public partial class ActionItemDefinitionForm : BaseForm, IActionItemDefinitionFormView
    {
        private IMultiSelectFunctionalLocationSelectionForm functionalLocationSelectionForm;
        private ITargetAssociationSelectionView targetAssociationSelectionForm;
        private EmailToRecipientForm emailToRecipientForm;               //ayman action item email
        private ActionItemDefinition aidef;
        private List<DocumentRootUncPath> documentRoots;
        
        /// <summary>
        /// Constructor used for creating an action item
        /// </summary>
        public ActionItemDefinitionForm()
        {
            Initialize();

            //ayman custom fields DMND0010030
            if (!ClientSession.GetUserContext().IsEdmontonSite)
            {
                oltgroupboxtemp.Visible = false;
                descriptionGroupBox.Height = descriptionGroupBox.Height + 80;
                flowLayoutPanel2.Height = flowLayoutPanel2.Height + 80;
                panel2.Height = panel2.Height + 80;
                oltGroupBox1.Width = assignmentGroupBox.Width;
                flowLayoutPanel2.Controls.Add(oltGroupBox1);
                autoPopulateLastReadingCheckBox.Left = autoPopulateLastReadingCheckBox.Left + 20;
                flowLayoutPanel2.Controls.Add(autoPopulateLastReadingCheckBox);
                flowLayoutPanel2.Controls.Add(readingCheckBox);
                descriptionGroupBox.BringToFront();
            }
            oltCmbImageType.SelectedIndex = 0;

            //if (ClientSession.GetUserContext().SiteConfiguration.RequireLogForActionItemResponse)
            //{
            //    copyResponsetoLog.Checked = true;
            //    CopyResponseToLogVisible = false;
            //}
            //else
            //{
            //    copyResponsetoLog.Checked = true;
            //    CopyResponseToLogVisible = true;

            //}


            ActionItemDefinitionFormPresenter presenter = new ActionItemDefinitionFormPresenter(this);
            RegisterEventHandlersOnPresenter(presenter);
            
        }

        /// <summary>
        /// Constructor used for editing an action item definition
        /// </summary>
        /// <param name="actionItemDefinition"></param>
        public ActionItemDefinitionForm(ActionItemDefinition actionItemDefinition)
        {
            Initialize();


            if(actionItemDefinition != null)
            {


                System.Media.SystemSounds.Beep.Play();
            }

            ActionItemDefinitionFormPresenter presenter;
                aidef = actionItemDefinition;
            emailToRecipientForm = new EmailToRecipientForm(aidef.SendEmailTo);
            //ayman custom fields DMND0010030
            if (!ClientSession.GetUserContext().IsEdmontonSite)
            {
                oltgroupboxtemp.Visible = false;
                descriptionGroupBox.Height = descriptionGroupBox.Height + 80;
                flowLayoutPanel2.Height = flowLayoutPanel2.Height + 80;
                panel2.Height = panel2.Height + 80;
                oltGroupBox1.Width = assignmentGroupBox.Width;
                flowLayoutPanel2.Controls.Add(oltGroupBox1);
                autoPopulateLastReadingCheckBox.Left = autoPopulateLastReadingCheckBox.Left + 20;
                flowLayoutPanel2.Controls.Add(autoPopulateLastReadingCheckBox);
                flowLayoutPanel2.Controls.Add(readingCheckBox);
                descriptionGroupBox.BringToFront();
            }



            if (actionItemDefinition.Id.HasValue)
            {

                presenter = new ActionItemDefinitionFormPresenter(this, actionItemDefinition);
            }                
            else
            {
                presenter = new ActionItemDefinitionFormPresenter(this);
                presenter.SetDefaultActionItemDefinitionData(actionItemDefinition);
            }
            RegisterEventHandlersOnPresenter(presenter);
        }

        private void Initialize()
        {
            InitializeComponent();

            targetAssociationSelectionForm = new TargetAssociationSelectionForm();
     
            //Change action Item floc display to level 2---implemented by Sarika

            #region if-else..getting Fuctional Mode


            //ayman floc level from site configuration
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConfiguration = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            var itemFlocSelectionLevel = siteConfiguration.ActionItemFlocLevel;



            if (itemFlocSelectionLevel == 1)
            {
                functionalLocationSelectionForm =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1), true);
            }


            else if (itemFlocSelectionLevel == 2)
            {
                functionalLocationSelectionForm =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2), true);
            }
            else if (itemFlocSelectionLevel == 3)
            {
                functionalLocationSelectionForm =
                    new MultiSelectFunctionalLocationSelectionForm(
                        FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                        new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3), true);
            }

            else
            {
                functionalLocationSelectionForm =
               new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration), new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3), true);


            } //throw new ArgumentException("The Value of  ShiftLogFlocLevel must be within 1 to 3 <" + this + ">");

            #endregion

            operationalModeComboBox.DisplayMember = "Name";
            actionCategoryComboBox.DisplayMember = "Name";

            //ayman custom fields DMND0010030
            CustomFieldsComboBox.DisplayMember = "Name";           
            CustomFieldsComboBox.ValueMember = "id";

            targetDefinitionDTOListBox.DisplayMember = "Name";
            schedulePicker.TimeRangeLabel = StringResources.ActionItemDefinitionSchedulePickerTimeRangeLabel;
        }

        private void RegisterEventHandlersOnPresenter(ActionItemDefinitionFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            functionalLocationButton.Click += presenter.HandleFunctionalLocationButtonClick;
            linkTargetDefinitionButton.Click += presenter.HandleLinkTargetDefinitionButtonClick;
            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            removeFlocButton.Click += presenter.HandleRemoveFlocButtonClick;
            removeTargetButton.Click += presenter.HandleRemoveTargetButtonClick;
            requiresApprovalCheckBox.CheckedChanged +=
                presenter.HandleRequiresApprovalCheckBoxCheckedChanged;
            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClicked;
            selectFormGN75BButton.Click += presenter.HandleSelectFormGn75BButtonClicked;
            viewGN75BFormButton.Click += presenter.HandleViewGn75BButtonClicked;
            removeFormGN75BButton.Click += presenter.HandleRemoveGn75BButtonClicked;

            CustomFieldsComboBox.SelectedIndexChanged += presenter.HandleCustomFieldComboBoxSelectedChanged;

            //mangesh - DMND0005327 - Request 15
            selectFormGN75BButton1.Click += presenter.HandleSelectFormGn75BButtonClicked;
            selectFormGN75BButton2.Click += presenter.HandleSelectFormGn75BButtonClicked;
            viewGN75BFormButton1.Click += presenter.HandleViewGn75BButtonClicked;
            viewGN75BFormButton2.Click += presenter.HandleViewGn75BButtonClicked;
            removeFormGN75BButton1.Click += presenter.HandleRemoveGn75BButtonClicked;
            removeFormGN75BButton2.Click += presenter.HandleRemoveGn75BButtonClicked;

            EmailToButton.Click += presenter.HandleEmailToClicked;
        }

        
        public DialogResult ShowFunctionalLocationSelector(List<FunctionalLocation> initialFlocSelection)
        {
            return functionalLocationSelectionForm.ShowDialog(this, initialFlocSelection);
        }
        
        public DialogResult ShowTargetSelector()
        {
            targetAssociationSelectionForm.AssociatedTargets = AssociatedTargetDefinitionDto;
            return targetAssociationSelectionForm.ShowDialog(this);
        }

        //ayman action item email
        public DialogResult ShowEmailToSelector(List<string> emails)
        {
            //emailToRecipientForm.AssociatedEmailToRecipients = UserSelectedEmailToRecipients;
            emailToRecipientForm = new EmailToRecipientForm(emails);
            return emailToRecipientForm.ShowDialog(this);
        }


        public IList<FunctionalLocation> UserSelectedFunctionalLocations
        {
            get { return functionalLocationSelectionForm.UserSelectedFunctionalLocations; }
        }

        public List<string> UserSelectedEmailToRecipients
        {
            get
            {
                if (emailToRecipientForm != null)
                {
                    return emailToRecipientForm.AssociatedEmailToRecipients;
                }
                else
                {
                    return new List<string>();
                }
            }
        }

        public List<TargetDefinitionDTO> UserSelectedTargetDefinitionDto
        {
            get { return targetAssociationSelectionForm.AssociatedTargets; }
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

        public string Description
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }

        //ayman
        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return string.Empty; // customFieldControl.GetCustomFieldEntryText(entry);
        }

        //ayman action item reading
        public void EnableAutoPopulate(bool val)
        {
            autoPopulateLastReadingCheckBox.Enabled = val;
        }

        //ayman action item reading
        public void EnableReading(bool val)
        {
            readingCheckBox.Enabled = val;
        }

        public void SetCustomFieldEntryText(CustomFieldEntry entry, string text)
        {
            // customFieldControl.SetCustomFieldEntryText(entry, text);
        }

        public string GetCustomFieldEntryText(long customFieldId)
        {
            return string.Empty; // customFieldControl.GetCustomFieldEntryText(customFieldId);
        }

        //ayman action item reading
        public bool CustomFieldComboHasValue()
        {
            if(CustomFieldsComboBox.SelectedIndex > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ActionItemDefinitionName
        {
            get { return nameTextBox.Text.Trim(); }
            set { nameTextBox.Text = value; }
        }

        public ISchedule Schedule
        {
            get { return schedulePicker.Schedule; }
            set { schedulePicker.Schedule = value; }
        }

        public List<BusinessCategory> Categories
        {
            set { actionCategoryComboBox.DataSource = value; }
            get { return (List<BusinessCategory>) actionCategoryComboBox.DataSource; }
        }

        //ayman custom fields DMND0010030
        public List<CustomFieldGroup> CustomfieldGroups
        {
            set { CustomFieldsComboBox.DataSource = value; }
            get { return (List<CustomFieldGroup>) CustomFieldsComboBox.DataSource;}
        }

        //ayman custom fields DMND0010030
        public CustomFieldGroup selectedCustomfieldgroup
        {
            get
            {
                CustomFieldGroup selected = (CustomFieldGroup) CustomFieldsComboBox.SelectedItem;
                return selected;
            }
        }



        public WorkAssignment Assignment
        {
            get
            {
                WorkAssignment selected = (WorkAssignment) assignmentComboBox.SelectedItem;

                if (Equals(selected, WorkAssignment.NoneWorkAssignment))
                {
                    return null;
                }

                return selected;
            }
            set { assignmentComboBox.SelectedItem = value ?? WorkAssignment.NoneWorkAssignment; }
        }

        public List<WorkAssignment> WorkAssignments
        {           
            set { assignmentComboBox.DataSource = value; }
        }

        public IList<OperationalMode> OperationalModes
        {
            set { operationalModeComboBox.DataSource = value; }
        }

        public List<Priority> Priorities
        {
            set { priorityComboBox.DataSource = value; }
        }

        public bool NameChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, actionItemNameGroupBox);
            }
        }

        public bool CategoryChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, categoryGroupBox);
            }
        }

        public bool OperationalModeChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, operationalModeGroupBox);
            }
        }

        public bool PriorityChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, priorityGroupBox);
            }
        }

        public bool DescriptionChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, descriptionGroupBox);
            }
        }

        public bool DocumentLinksChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, linkGroupBox);
            }
        }

        public bool FunctionalLocationsChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, functionalLocationsGroupBox);
            }
        }

        public bool TargetDependenciesChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, targetDependenciesGroupBox);
            }
        }

        public bool ScheduleChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, schedulingLine);
            }
        }

        public bool RequiresResponseWhenTriggeredChangeRequiresReApproval
        {
            set
            {
                SetColourForFieldRequiringReApproval(value, responseRequiredCheckBox);
            }
        }

        public bool AssignmentChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, assignmentGroupBox); }
        }

        public bool ActionItemGenerationModeChangeRequiresReApproval
        {
            set { SetColourForFieldRequiringReApproval(value, actionItemGenerationModeGroupBox); }
        }

        public bool ShouldClearCurrentActionItemsForDefinitionUpdate
        {
            get
            {                
                DialogResult result = OltMessageBox.Show(
                    this,
                    StringResources.ClearCurrentActionItemsForDefinitionUpdate,
                    StringResources.ClearCurrentActionItemsForDefinitionUpdateTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                return result == DialogResult.Yes;
            }
        }

        private void SetColourForFieldRequiringReApproval(bool requireReApproval, Control control)
        {
            if (requireReApproval)
            {
                control.ForeColor = UIConstants.RequireApprovalFieldColor;
                toolTip.SetToolTip(control, StringResources.EditingRequiresReapproval);
            }
        }
        

        public CustomFieldGroup Customfieldgroup
        {
            get { return CustomFieldsComboBox.SelectedValue as CustomFieldGroup; }
            set { CustomFieldsComboBox.SelectedItem = value; }
        }

        //ayman action item email
        public bool SendEmailChecked
        {
            get { return sendEmailCheckBox.Checked; }
            set { }
        }

        //ayman action item reading
        public bool AutoPopulateChecked
        {
            get { return autoPopulateLastReadingCheckBox.Checked; }
            set { }
        }

        //ayman action item email
        public void SendEmailControlEnabled(bool value)
        {
            sendEmailCheckBox.Enabled = value;
        }

        public List<string> SendEmailTo
        {
            get { return UserSelectedEmailToRecipients; }
            set
            {
            }
        }

        //ayman action item email
        public bool SendEmail
        {
            get { return sendEmailCheckBox.Checked ; }
            set
            {
                sendEmailCheckBox.Checked = value;
            }
        }

        //ayman action item reading
        public bool AutoPopulate
        {
            get { return autoPopulateLastReadingCheckBox.Checked; }
            set { autoPopulateLastReadingCheckBox.Checked = value; }
        }

        //ayman action item reading
        public bool Reading
        {
            get { return readingCheckBox.Checked; }
            set { readingCheckBox.Checked = value; }
        }

        public BusinessCategory Category
        {
            get { return actionCategoryComboBox.SelectedItem as BusinessCategory; }
            set { actionCategoryComboBox.SelectedItem = value; }
        }
        
        public Priority Priority
        {
            get
            { return priorityComboBox.SelectedItem as Priority; }
            set
            { priorityComboBox.SelectedItem = value; }
        }

        public OperationalMode OperationalMode
        {
            get { return operationalModeComboBox.SelectedItem as OperationalMode; }
            set { operationalModeComboBox.SelectedItem = value; }
        }

        public bool OperationalModeIsEnabled
        {
            set { operationalModeComboBox.Enabled = value; }
        }

        public List<ScheduleType> ScheduleTypes
        {
            set { schedulePicker.AllowedScheduleTypes = value; }
        }
        public void TurnOnAutosetIndicatorsForDateTimes()
        {
            infoProvider.SetError(assignmentComboBox, StringResources.AutosetActionItemDefinitionWorkAssignemntInfoMessage);
        }

        public bool RequiresApproval
        {
            get { return requiresApprovalCheckBox.Checked; }
            set { requiresApprovalCheckBox.Checked = value; }
        }

        public bool IsActive
        {
            get { return ! temporarilyInActiveCheckBox.Checked; }
            set { temporarilyInActiveCheckBox.Checked = ! value; }
        }

        public bool ResponseRequired
        {
            get { return responseRequiredCheckBox.Checked; }
            set { responseRequiredCheckBox.Checked = value; }
        }

        public List<TargetDefinitionDTO> AssociatedTargetDefinitionDto
        {
            get { return targetDefinitionDTOListBox.DataSource as List<TargetDefinitionDTO>; }
            set { targetDefinitionDTOListBox.DataSource = value; }
        }

        public List<string> EmailToRecipients
        {
            get
            {
                return UserSelectedEmailToRecipients;
            }
                 set
            {
               
            }
        }          //ayman action item email

        public List<DocumentLink> AssociatedDocumentLinks
        {
            get { return actionItemDefinitionDocumentsLinkControl.DataSource as List<DocumentLink>; }
            set { actionItemDefinitionDocumentsLinkControl.DataSource = value; }
        }

        public List<FunctionalLocation> AssociatedFunctionalLocations
        {
            get { return functionalLocationListBox.FunctionalLocations; }
            set
            {
                functionalLocationListBox.FunctionalLocations = value;
                CreateAnActionItemForEachFunctionalLocationEnabled = value.Count > 1;
            }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public TargetDefinitionDTO SelectedTargetDefinitionDto
        {
            get { return (TargetDefinitionDTO) targetDefinitionDTOListBox.SelectedItem; }
        }
       
        public bool RequiresApprovalCheckBoxEnabled
        {
            set { requiresApprovalCheckBox.Enabled = value; }
        }

        public bool CreateAnActionItemForEachFunctionalLocation
        {
            get { return createActionItemForEachFlocRadioButton.Checked; }
            set
            {
                if (value)
                {
                    createActionItemForEachFlocRadioButton.Checked = true;
                }
                else
                {
                    createOneActionItemForAllFlocsRadioButton.Checked = true;
                }
            }
        }

        private bool CreateAnActionItemForEachFunctionalLocationEnabled
        {
            set
            {
                if (!value)
                {
                    createOneActionItemForAllFlocsRadioButton.Checked = true;
                }
                createActionItemForEachFlocRadioButton.Enabled = value;
                createOneActionItemForAllFlocsRadioButton.Enabled = value;
                actionItemGenerationModeGroupBox.Enabled = value;
            }
        }

        public bool IsActiveCheckBoxEnabled
        {
            set { temporarilyInActiveCheckBox.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public void ShowNameIsNotUniqueError()
        {
            nameErrorProvider.SetError(nameTextBox, StringResources.SAPSourcedNameNotUniqueError);
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
            functionalLocationErrorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void ShowCategoryNotSelectedError()
        {
            categoryErrorProvider.SetError(actionCategoryComboBox, StringResources.CategoryEmptyError);
        }

        public void ShowWarningMailingListExists()
        {
            infoProvider.SetError(EmailToButton, "Please Check the mailing list");         //ayman action item email
        }
        
        public bool HasScheduleError
        {
            get { return schedulePicker.HasScheduleError; }
        }

        public void ClearErrorProviders()
        {
            schedulePicker.ClearErrors();
            nameErrorProvider.Clear();
            descriptionErrorProvider.Clear();
            functionalLocationErrorProvider.Clear();
            categoryErrorProvider.Clear();
        }
      
        public DataSource Source { get; set; }

        public void DisableBusinessCategoryComboBox()
        {
            actionCategoryComboBox.Enabled = false;
        }

        //ayman custom fields DMND0010030
        public void DisableCustomFieldsComboBox()
        {
            CustomFieldsComboBox.Enabled = false;
        }



        public void HideGn75BAssocationBox()
        {
           gn75AssociationGroupBox.Visible = false;
            Height -= gn75AssociationGroupBox.Height;
            Refresh();           
        }

        public long? FormGn75BId
        {
            get
            {
                return (long?)formGn75bTextBox.Tag;
            }
            set
            {
                formGn75bTextBox.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                formGn75bTextBox.Tag = value;
                viewGN75BFormButton.Enabled = value.HasValue;
                removeFormGN75BButton.Enabled = value.HasValue;//mangesh - DMND0005327 -Request15
            }
        }

        //mangesh - DMND0005327 - Request 15
        public long? FormGn75BId1
        {
            get
            {
                return (long?)formGn75bTextBox1.Tag;
            }
            set
            {
                formGn75bTextBox1.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                formGn75bTextBox1.Tag = value;
                viewGN75BFormButton1.Enabled = value.HasValue;
                removeFormGN75BButton1.Enabled = value.HasValue;
            }
        }
        //mangesh - DMND0005327 - Request 15
        public long? FormGn75BId2
        {
            get
            {
                return (long?)formGn75bTextBox2.Tag;
            }
            set
            {
                formGn75bTextBox2.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                formGn75bTextBox2.Tag = value;
                viewGN75BFormButton2.Enabled = value.HasValue;
                removeFormGN75BButton2.Enabled = value.HasValue;
            }
        }

        public void DisplayDuplicateGN75BMessage(string value)
        {
            OltMessageBox.Show(ActiveForm, string.Format(StringResources.ActionItemDefinition_DuplicateFormGN75BMessage, value),
                StringResources.ActionItemDefinition_DuplicateFormGN75BMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        private void oltPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Action Item Images --//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        List<ImageUploader> lstimage = new List<ImageUploader>();
        public List<ImageUploader> ImageActionItemDefdetails
        {
            set
            {

                lstimage = value;
                oltDGVImage.AutoGenerateColumns = false;
                oltDGVImage.DataSource = null;
                oltDGVImage.DataSource = value;

            }
            get
            {
                foreach (DataGridViewRow row in oltDGVImage.Rows)
                {
                    if (row.Index > 0)
                    {
                        lstimage[row.Index].Name = Convert.ToString(row.Cells["ImageName"].Value);
                        lstimage[row.Index].Description = Convert.ToString(row.Cells["DescriptionActionItemDef"].Value);

                    }
                }

                return lstimage;
            }
        }

        private void oltbtnbrowse_Click(object sender, EventArgs e)
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
            //if (uncPath.Path != null && !uncPath.Path.IsValidUncPath() && uncPath.Path.IsValidUri())
            //{
            //    Process.Start(uncPath.Path);
            //    return;
            //}

            //FileDialog fileDialog = new OpenFileDialog { RestoreDirectory = true };

            //openFileDialog1.ShowDialog();
            //txtFilePath.Text = openFileDialog1.FileName;

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

        private void oltbtnAdd_Click(object sender, EventArgs e)
        {
            errorProviderImage.Clear();
            if (oltCmbImageType.Text.ToUpper() == "IMAGE")
            {
                foreach (string strfileName in openFileDialog1.FileNames)
                {
                    ImageUploader Img = new ImageUploader();
                    Img.RecordType = ImageUploader.RecordTypes.ActionItemDef;
                    Img.Name = txtName.Text;
                    Img.Description = txtDescription.Text;
                    Img.ImagePath = strfileName;// txtFilePath.Text;
                    Img.Id = 0;
                    Img.Action = "Insert";


                    Img.Types = ImageUploader.Type.Image;
                        if (!File.Exists(txtFilePath.Text))
                        {
                            errorProviderImage.SetError(txtFilePath, "File not exists");
                            return;
                        }

                    
                    lstimage.Add(Img);
                }
            }
           
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            oltCmbImageType.SelectedIndex = 0 ;
            List<ImageUploader> lst = new List<ImageUploader>(lstimage);
            oltDGVImage.AutoGenerateColumns = false;
            oltDGVImage.DataSource = null;
            oltDGVImage.DataSource = lst;//.FindAll(A => A.Action != "Remove");

           
        }

        private void oltCmbImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (oltCmbImageType.Text=="")
            {
                oltbtnAdd.Enabled=false;
            }
            else
            {
                oltbtnAdd.Enabled = true;
            }
          if (txtFilePath.Text == "")
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

        private void oltDGVImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            oltDGVImage.Rows[e.RowIndex].Cells[6].Value = "Remove";
        }

        public bool setActionItemDefImage
        {
            set
            {
                oltLabelActionItemDefImagesTitle.Visible = value;
                oltLabelActionItemDefImagesTitle.Visible = value;

            }

        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

            if (txtFilePath.Text == "")
            {
                oltbtnAdd.Enabled = false;
            }
            else
            {
                oltbtnAdd.Enabled = true;
            }

        }


        public bool EnableActionItemImagePanel
        {
            get { return oltPanel1.Visible; }
            set { oltPanel1.Visible = value; }
        }

        public int oltCmbImageTypeValue
        {
            get { return oltCmbImageType.SelectedIndex ; }
            set { oltCmbImageType.SelectedIndex = value; }
        }

        public void SetErrorForAddButton()
        {
            errorProviderImage.SetError(oltTableLayoutPanelActionItemDef, "Please Click on ADD Button to Save the Images");
        }
        public bool EnableAddButton
        {
            get { return oltbtnAdd.Enabled; }

        }
        public string FilePathText
        {
            get { return txtFilePath.Text; }

        }
        
        #endregion

        //END

//Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
        public bool CopyResponseToLog
        {
            get
            {
                return copyResponsetoLog.Checked;
            }
            set
            {
                if (ClientSession.GetUserContext().SiteConfiguration.RequireLogForActionItemResponse)
                {
                    copyResponsetoLog.Checked = true;
                    CopyResponseToLogVisible = false;
                }
                else
                {
                    copyResponsetoLog.Checked = value; // //INC0558851:Action Item Definitions - Copy Response to Log:Aarti
                    CopyResponseToLogVisible = true;
                }
                
            }

        }
        public bool CopyResponseToLogVisible
        {
            get { return copyResponsetoLog.Visible; }
            set { copyResponsetoLog.Visible = value; }

        }

        }
}
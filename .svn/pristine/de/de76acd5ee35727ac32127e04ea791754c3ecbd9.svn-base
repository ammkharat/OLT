using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormOP14Form : BaseForm, IFormOP14View
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        
        public event Action FormLoad;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action ExpandClicked;
        public event Action SaveAndEmailButtonClicked;
        public event Action PressureSafetyValveAnswerChanged;
        /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
        public event Action DepartmentOperationsAnswerChanged; 
        public event Action CriticalSystemDefeatedTextBoxChanged;
        public event Action ContentRichTextEditorChanged; 
        public event Action FunctionalLocationListBoxChanged;//RITM0446491EN50:-End
        public event Action ValidityDatesChanged;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        public FormOP14Form()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            waitingapprovalButton.Click += HandleWaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetAll(userContext.SiteConfiguration),
                                                                          new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1,
                                                                                                                       rootFlocsForActiveSelection),
                                                                          true, rootFlocsForActiveSelection);

            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocatnButton.Click += HandleRemoveFunctionalLocationButtonClicked;
            expandLinkLabel.Click += HandleExpandClicked;

            pressureSafetyValveYesRadioButton.CheckedChanged += HandlePressureSafetyValveYesRadioButtonOnCheckedChanged;

            /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
            departmentOperationsRadioButton.CheckedChanged += HandledepartmentOperationsRadioButtonCheckedChanged;
            criticalSystemDefeatedTextBox.TextChanged += HandlecriticalSystemDefeatedTextBoxChanged;
            //  contentRichTextEditor.BindingContextChanged+= HandleContentRichTextEditorChanged; 
           // contentRichTextEditor.TextChanged += new EventHandler(con);
            functionalLocationListBox.DataSourceChanged += HandleFunctionalLocationListBoxChanged; //RITM0446491:-END
            validToDatePicker.ValueChanged += HandleValidityDatesChanged;
            validFromDatePicker.ValueChanged += HandleValidityDatesChanged;
            validToTimePicker.ValueChanged += HandleValidityDatesChanged;
            validFromTimePicker.ValueChanged += HandleValidityDatesChanged;

            mainPanel.Layout += HandleMainPanelLayout;
                    
           approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
           approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;

        }

       

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }

        }


        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {
            waitingapprovalButton.Enabled = true;
            saveButton.Text = "Save as Draft";
        }

        public void DisableWaitingForApprovalButton()
        {
            waitingapprovalButton.Enabled = false;
            saveButton.Text = "Save && Close";
          }


        private void HandleMainPanelLayout(object sender, LayoutEventArgs layoutEventArgs)
        {
             invisibleLabel.Width = mainPanel.Width - 25;
        }


//ayman testing enable/disable waiting for approval button
        protected virtual List<string> RemainingApprovals()
        {
            var remainingApprovals =
                Approvals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
            remainingApprovals.RemoveAll(approvalString => approvalString == null);
            return remainingApprovals;
        }        

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
            waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
          
             saveButton.Text = waitingapprovalButton.Enabled == true ? "Save as Draft" : "Save && Close";
          }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }

            // ayman enable/disable
            waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
                saveButton.Text = waitingapprovalButton.Enabled == true ? "Save as Draft" : "Save && Close";
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

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
            }
        }

        private void HandleWaitingApprovalButtonClicked(object sender, EventArgs eventArgs) // Swapnil Patki For DMND0005325 Point Number 7
        {
            if (WaitingApprovalButtonClicked != null)
            {
                WaitingApprovalButtonClicked();
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleExpandClicked(object sender, EventArgs e)
        {
            if (ExpandClicked != null)
            {
                ExpandClicked();
            }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public List<FormApproval> Approvals
        {
            set { approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval)); }
            get
            {
                List<FormApprovalGridDisplayAdapter> list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
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
               
        public DateTime ValidTo
        {
            get
            {
                Date date = validToDatePicker.Value;
                Time time = validToTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validToDatePicker.Value = new Date(value);
                validToTimePicker.Value = new Time(value);
            }
        }

        public DateTime ValidFrom
        {
            get
            {
                Date date = validFromDatePicker.Value;
                Time time = validFromTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validFromDatePicker.Value = new Date(value);
                validFromTimePicker.Value = new Time(value);
            }
        }

        public string Content
        {
            get { return contentRichTextEditor.Text; }
            set { contentRichTextEditor.Text = value; }
        }

        public string PlainTextContent
        {
            get { return contentRichTextEditor.PlainText; }
        }

        public FormOP14Department Department
        {
            get
            {
                if (departmentMaintenanceRadioButton.Checked)
                {
                    return FormOP14Department.Maintenance;
                }
                return FormOP14Department.Operations;
            }

            set
            {
                if (FormOP14Department.Maintenance.Equals(value))
                {
                    departmentMaintenanceRadioButton.Checked = true;
                }
                else
                {
                    departmentOperationsRadioButton.Checked = true;
                }
            }
        }

        public bool IsTheCSDForAPressureSafetyValve
        {
            get { return pressureSafetyValveYesRadioButton.Checked; }
            set
            {
                pressureSafetyValveYesRadioButton.Checked = value;
                pressureSafetyValveNoRadioButton.Checked = !value;
            }
        }

        public string CriticalSystemDefeated
        {
            get { return criticalSystemDefeatedTextBox.Text; }
            set { criticalSystemDefeatedTextBox.Text = value; }
        }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this, initialUserFLOCSelections);

            IList<FunctionalLocation> selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult, new List<FunctionalLocation>(selectedFunctionalLocations));
        }

        public void DisplayExpandedLogCommentForm()
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(Content, false);
            expandedLogCommentForm.ShowDialog(this);
            Content = expandedLogCommentForm.TextEditorText;
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.EstimatedBackInServiceDateCannotBeBeforeSystemDefeatedDate);
        }

        public void SetErrorForEmptyOP14CriticalSystemDefeated()
        {
            errorProvider.SetError(criticalSystemDefeatedTextBox, StringResources.FieldEmptyError);
        }

        public void SetErrorForValidToIsInThePast()
        {
            errorProvider.SetError(validToDatePicker, StringResources.BackInServiceDateInPast);
        }

        public DialogResult ShowFormHasAdditionalApproversRequired()
        {
            string message = StringResources.FormAdditionalApproversQuestion;
            string title = StringResources.FormAdditionalApproversQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        private void HandlePressureSafetyValveYesRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (PressureSafetyValveAnswerChanged != null)
            { 
                 /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
                if (ClientSession.GetUserContext().SiteId == Common.Domain.Site.SARNIA_ID)
                {
                    EnableWaitingForApprovalButton();
                }
                PressureSafetyValveAnswerChanged();
            }
        }

        private void HandledepartmentOperationsRadioButtonCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (DepartmentOperationsAnswerChanged != null)
            {
                /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
                if (ClientSession.GetUserContext().SiteId == Common.Domain.Site.SARNIA_ID)
                {
                    EnableWaitingForApprovalButton();
                }
            }
        }

        /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
        private void HandlecriticalSystemDefeatedTextBoxChanged(object sender, EventArgs eventArgs)
        {
            if (CriticalSystemDefeatedTextBoxChanged != null)
            {
                
                if (ClientSession.GetUserContext().SiteId == Common.Domain.Site.SARNIA_ID)
                {
                    EnableWaitingForApprovalButton();
                }
            }
        }

        /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
        private void HandleContentRichTextEditorChanged(object sender, EventArgs eventArgs)
        {
            if(ContentRichTextEditorChanged != null)
            {
                
                if (ClientSession.GetUserContext().SiteId == Common.Domain.Site.SARNIA_ID)
                {
                    EnableWaitingForApprovalButton();
                }
            }

        }

        /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
        private void HandleFunctionalLocationListBoxChanged(object sender, EventArgs eventArgs)
        {
            if(FunctionalLocationListBoxChanged != null)
            {

                if (ClientSession.GetUserContext().SiteId == Common.Domain.Site.SARNIA_ID)
                {
                    EnableWaitingForApprovalButton();
                }
            }
        }

        private void HandleValidityDatesChanged(object sender, EventArgs e)
        {
            if (ValidityDatesChanged != null)
            { 
                /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
                if (ClientSession.GetUserContext().SiteId == Common.Domain.Site.SARNIA_ID)
                {
                    EnableWaitingForApprovalButton();
                }
                ValidityDatesChanged();
            }
        }
        /*RITM0265746 - Sarnia CSD marked as read start*/
        public bool ShowLogMarkedAsReadWarning()
        {
            DialogResult result = OltMessageBox.Show(
                this,
                StringResources.EditingItemMarkedAsReadWarning,
                StringResources.EditingItemMarkedAsReadWarning_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return DialogResult.Yes.Equals(result);
        }
        /*RITM0265746 - Sarnia CSD marked as read end*/

        //DMND0010261-SELC CSD EdmontonPipeline
        public bool IsSCADASupport { get; set; }

        //INC0458108 : Added By Vibhor {Sarnia : Remove references to "OP-14" within form labels and menu items}
        public string SetFormTitleName
        {
            set { this.Text = value; }
        }
        //END
    }
}

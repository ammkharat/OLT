using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class FormGN75AForm : BaseForm, IFormGN75AView
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action ExpandContentClicked;        
        public event Action SaveAndEmailButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action BrowseFunctionalLocationButtonClicked;
        public event Action AssociateFormGN75BButtonClicked;
        public event Action RemoveFormGN75BButtonClicked;
        public event Action ViewFormGN75BButtonClicked;
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
        
        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelector;

        public FormGN75AForm()
        {
            InitializeComponent();

            bulletLabel1.Text = UIConstants.BULLET_CODE;
            bulletLabel2.Text = UIConstants.BULLET_CODE;
            bulletLabel3.Text = UIConstants.BULLET_CODE;
            bulletLabel4.Text = UIConstants.BULLET_CODE;

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelThreeAndBelow(
                userContext.SiteConfiguration), new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1, rootFlocsForActiveSelection));

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            waitingapprovalButton.Click += HandleWaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
            cancelButton.Click += HandleCancelButtonClicked;
            expandContentLinkLabel.Click += HandleExpandContentClicked;            
            browseFunctionalLocationButton.Click += HandleBrowseFunctionalLocationButtonClicked;            
            historyButton.Click += HandleHistoryButtonClick;
            associateFormGN75BButton.Click += HandleAssociateFormGN75BButtonClicked;
            removeFormGN75BButton.Click += HandleRemoveFormGN75BButtonClicked;
            viewGN75BFormButton.Click += HandleViewFormGN75BFormButtonClicked;

            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;

            gn75BFormNumberTextBox.TextChanged += HandleGN75BFormNumberTextBoxTextChanged;

            
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



        private void HandleGN75BFormNumberTextBoxTextChanged(object sender, EventArgs e)
        {
            EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();
        }
        
        public void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet()
        {
            removeFormGN75BButton.Enabled = !gn75BFormNumberTextBox.Text.IsNullOrEmptyOrWhitespace();
            viewGN75BFormButton.Enabled = !gn75BFormNumberTextBox.Text.IsNullOrEmptyOrWhitespace();                        
        }

        private void HandleAssociateFormGN75BButtonClicked(object sender, EventArgs e)
        {
            if (AssociateFormGN75BButtonClicked != null)
            {
                AssociateFormGN75BButtonClicked();
            }
        }

        private void HandleRemoveFormGN75BButtonClicked(object sender, EventArgs e)
        {
            if (RemoveFormGN75BButtonClicked != null)
            {
                RemoveFormGN75BButtonClicked();
            }
        }


        private void HandleViewFormGN75BFormButtonClicked(object sender, EventArgs e)
        {
            if (ViewFormGN75BButtonClicked != null)
            {
                ViewFormGN75BButtonClicked();
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (HistoryButtonClicked != null)
            {
                HistoryButtonClicked();
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

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
        
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }

        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }
               
        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
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

        public long? FormGN75BId
        {
            get { return (long?) gn75BFormNumberTextBox.Tag; }
            set
            {
                if (value != null)
                {
                    gn75BFormNumberTextBox.Text = value.Value.ToString(CultureInfo.InvariantCulture);
                    gn75BFormNumberTextBox.Tag = value;
                }
                else
                {
                    gn75BFormNumberTextBox.Text = null;
                    gn75BFormNumberTextBox.Tag = null;
                }                
            }
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

        public FunctionalLocation SelectedFunctionalLocation
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

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
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

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(FunctionalLocation functionalLocation)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this);

            FunctionalLocation selectedFunctionalLocation = flocSelector.SelectedFunctionalLocation;
            return new DialogResultAndOutput<FunctionalLocation>(dialogResult, selectedFunctionalLocation);
        }
        
        public void DisplayExpandedContentForm()
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(Content, false);
            expandedLogCommentForm.ShowDialog(this);
            Content = expandedLogCommentForm.TextEditorText;
            expandedLogCommentForm.Dispose();
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForValidFromMustBeBeforeValidTo()
        {
            errorProvider.SetError(validToTimePicker, StringResources.EndDateBeforeStartDate);
        }

        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult DisplayNoAssociatedGN75BFormDialog()
        {
            string message = StringResources.NoAssociatedGN75BFormSelected;
            string title = StringResources.NoAssociatedGN75BFormSelectedTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void HandleExpandContentClicked(object sender, EventArgs e)
        {
            if (ExpandContentClicked != null)
            {
                ExpandContentClicked();
            }
        }

        private void HandleBrowseFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (BrowseFunctionalLocationButtonClicked != null)
            {
                BrowseFunctionalLocationButtonClicked();
            }
        }
    }
}

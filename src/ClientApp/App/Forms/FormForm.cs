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
    public partial class FormForm : BaseForm, IFormView
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
        public event Action ValidityDatesChanged;
        public event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        private readonly IMultiSelectFunctionalLocationSelectionForm flocSelector;

        public FormForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClicked;
            saveAndEmailButton.Click += HandleSaveAndEmailButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            waitingapprovalButton.Click += HandleWaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(userContext.SiteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1,
                        rootFlocsForActiveSelection),
                    true, rootFlocsForActiveSelection);

            addFunctionalLocationButton.Click += HandleAddFunctionalLocationButtonClicked;
            removeFunctionalLocatnButton.Click += HandleRemoveFunctionalLocationButtonClicked;
            expandLinkLabel.Click += HandleExpandClicked;

            validToDatePicker.ValueChanged += HandleValidityDatesChanged;
            validFromDatePicker.ValueChanged += HandleValidityDatesChanged;
            validToTimePicker.ValueChanged += HandleValidityDatesChanged;
            validFromTimePicker.ValueChanged += HandleValidityDatesChanged;

            mainPanel.Layout += HandleMainPanelLayout;

            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;

            //ayman enable/disable waiting for approval button
            waitingapprovalButton.Enabled = approvalsGridControl.Items == null;
            saveButton.Text = waitingapprovalButton.Enabled == true ? "Save as Draft" : "Save && Close";            

        }

        //ayman testing enable/disable waiting for approval button
        protected virtual List<string> RemainingApprovals()
        {
            var remainingApprovals =
                Approvals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
            remainingApprovals.RemoveAll(approvalString => approvalString == null);
            return remainingApprovals;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();

            }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs layoutEventArgs)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
            //ayman enable/disable waiting for approval button
            waitingapprovalButton.Enabled = (RemainingApprovals().Count > 0);
            saveButton.Text = waitingapprovalButton.Enabled == true ? "Save as Draft" : "Save && Close";
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }
            //ayman enable/disable waiting for approval button
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

        private void HandleWaitingApprovalButtonClicked(object sender, EventArgs eventArgs) // Swapnil Patki For DMND0005325 Point Number 7
        {
            if (WaitingApprovalButtonClicked != null)
            {
                WaitingApprovalButtonClicked();
            }
        }

        private void HandleSaveAndEmailButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndEmailButtonClicked != null)
            {
                SaveAndEmailButtonClicked();
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
            set
            {
                approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval));
            }
            get
            {
                List<FormApprovalGridDisplayAdapter> list =
                    new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
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








        //public void UseFromAndToLabels()
        //{
        //    systemDefeatedLabel.Visible = false;
        //    estimatedBackInServiceLabel.Visible = false;

        //    fromLabel.Visible = true;
        //    toLabel.Visible = true;

        //    AdjustDateAndTimePickerLocations(fromLabel, toLabel);
        //}

        //public void UseSystemDefeatedAndEstimatedBackInServiceLabels()
        //{
        //    systemDefeatedLabel.Visible = true;
        //    estimatedBackInServiceLabel.Visible = true;

        //    fromLabel.Visible = false;
        //    toLabel.Visible = false;

        //    AdjustDateAndTimePickerLocations(systemDefeatedLabel, estimatedBackInServiceLabel);
        //}

        //private void AdjustDateAndTimePickerLocations(OltLabel validFromLabel, OltLabel validToLabel)
        //{
        //    const int padding = 10;
        //    int maxLabelWidth = Math.Max(validFromLabel.Width, validToLabel.Width);
        //    validFromDatePicker.Location = new Point(validFromLabel.Location.X + maxLabelWidth + padding, validFromDatePicker.Location.Y);
        //    validToDatePicker.Location = new Point(validToLabel.Location.X + maxLabelWidth + padding, validToDatePicker.Location.Y);

        //    const int paddingBetweenDatePickerAndTimePicker = 8;
        //    validFromTimePicker.Location = new Point(validFromDatePicker.Location.X + validFromDatePicker.Size.Width + paddingBetweenDatePickerAndTimePicker, validFromDatePicker.Location.Y);
        //    validToTimePicker.Location = new Point(validToDatePicker.Location.X + validToDatePicker.Size.Width + paddingBetweenDatePickerAndTimePicker, validToDatePicker.Location.Y);            
        //}

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

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> initialUserFLOCSelections)
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this, initialUserFLOCSelections);

            IList<FunctionalLocation> selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult,
                new List<FunctionalLocation>(selectedFunctionalLocations));
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
            errorProvider.SetError(validToTimePicker, StringResources.ValidToDateBeforeValidFromDate);
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

        private void HandleValidityDatesChanged(object sender, EventArgs e)
        {
            if (ValidityDatesChanged != null)
            {
                ValidityDatesChanged();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormProcedureDeviationDetails : AbstractDetails, IFormEdmontonDetails
    {
        private readonly DomainListView<FunctionalLocation> functionalLocationListView;

        private ProcedureDeviation procedureDeviation;

        public FormProcedureDeviationDetails()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;

            functionalLocationListView = new DomainListView<FunctionalLocation>(
                new DetailsFunctionalLocationRenderer(), false) {Dock = DockStyle.Fill};
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;

            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            emailButton.Click += HandleEmailButtonClick;
            exportAllButton.Click += HandleExportButtonClick;
            cancelButton.Click += HandleCancelButtonClick;

            mainPanel.MouseEnter += MainPanelOnMouseEnter;

            expandLinkLabel.Click += HandleExpandClicked;

            Resize += OnResize;
        }

        public ProcedureDeviation ProcedureDeviation
        {
            set
            {
                SuspendLayout();

                procedureDeviation = value;

                approvalsGridControl.AutoSizeGrid();

                ResumeLayout(false);
                PerformLayout();
            }
        }

        public bool DeleteVisible
        {
            set { deleteButton.Visible = value; }
        }

        public bool CancelEnabled
        {
            set { cancelButton.Enabled = value; }
        }

        public bool CancelVisible
        {
            set { cancelButton.Visible = value; }
        }

        public DateTime? CreatedDateTime
        {
            set { createdDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public User CreatedByUser
        {
            set { createdByUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        public DateTime? LastModifiedDateTime
        {
            set
            {
                lastModifiedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString();
            }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        public long? FormNumber
        {
            set { formNumberDataLabel.Text = value == null ? string.Empty : value.Value.ToString(); }
        }

        public string FormStatus
        {
            set { statusDataLabel.Text = value; }
        }

        public DateTime? SuggestedCompletionDateTime
        {
            set
            {
                suggestedCompletionDateLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString();
            }
        }

        public DateTime? ScheduledCompletionDateTime
        {
            set
            {
                scheduledCompletionDateLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString();
            }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value ?? new List<FunctionalLocation>(); }
        }

        public int NumberOfExtensions
        {
            set { numberOfExtensionsDataLabel.Text = string.Format("{0}", value); }
        }

        public List<Comment> ReasonForExtensions
        {
            set
            {
                extensionReasonsListBox.Items.Clear();
                if (value == null) return;

                foreach (var reason in value)
                {
                    extensionReasonsListBox.Items.Add(reason.Text);
                }
            }
        }

        public string LocationEquipmentNumber
        {
            set { locationDataLabel.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); }
        }

        public bool ExistingDocument
        {
            set
            {
                existingDocumentRadioButton.Checked = value;
                newDocumentRadioButton.Checked = !value;
            }
        }

        public string DocumentOwner
        {
            set { documentOwnerDataLabel.Text = value; }
        }

        public string DocumentNumber
        {
            set { documentNumberDataLabel.Text = value; }
        }

        public string DocumentTitle
        {
            set { documentTitleDataLabel.Text = value; }
        }

        public bool OriginalMarkedUp
        {
            set { originalMarkedUpCheckBox.Checked = value; }
        }

        public string HardCopySubmittedTo
        {
            set { hardCopySubmittedToLabel.Text = value; }
        }

        public bool RecommendedToBeArchived
        {
            set { recommendedToByArchivedCheckBox.Checked = value; }
        }

        public string ContentRichText
        {
            set { contentRichTextDisplay.Text = value; }
            private get { return contentRichTextDisplay.Text; }
        }

        public List<FormApproval> Approvals
        {
            set
            {
                var items = value.ConvertAll(approval => new DocumentSuggestionFormApprovalGridDisplayAdapter(approval));
                approvalsGridControl.Items = items;
            }
        }

        public string NotApprovedReason
        {
            set
            {
                notApprovedReasonMemoEdit.Text = value;

                notApprovedReasonGroupBox.Visible = !value.IsNullOrEmpty();
            }
        }

        protected override Panel Details
        {
            get { return mainPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        public bool EmailButtonVisible
        {
            set { emailButton.Visible = value; }
        }

        public bool CloseButtonVisible
        {
            set { cancelButton.Visible = value; }
        }

        public event EventHandler ExportAll;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Delete;
        public event Action Clone;
        public event Func<bool> Cancel;
        public event Func<bool> Close;
        public event EventHandler Print;
        public event Action PrintPreview;
        public event Action Email;

        public bool RangeVisible
        {
            set { dateRangeButton.Visible = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool CloseEnabled
        {
            set { cancelButton.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool EmailEnabled
        {
            set { emailButton.Enabled = value; }
        }

        public bool PrintButtonVisible
        {
            set { printButton.Visible = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        public bool EditVisible
        {
            set { editButton.Visible = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone();
            }
        }

        private void HandleExpandClicked(object sender, EventArgs e)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(ContentRichText, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            ProcedureDeviation = procedureDeviation;
        }

        private void MainPanelOnMouseEnter(object sender, EventArgs eventArgs)
        {
            mainPanel.Focus();
        }

        private void HandleExportButtonClick(object sender, EventArgs eventArgs)
        {
            if (ExportAll != null)
            {
                ExportAll(sender, eventArgs);
            }
        }

        private void HandleEmailButtonClick(object sender, EventArgs eventArgs)
        {
            if (Email != null)
            {
                Email();
            }
        }

        private void HandlePrintPreviewButtonClick(object sender, EventArgs eventArgs)
        {
            if (PrintPreview != null)
            {
                PrintPreview();
            }
        }

        private void HandlePrintButtonClick(object sender, EventArgs eventArgs)
        {
            if (Print != null)
            {
                Print(sender, eventArgs);
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs eventArgs)
        {
            if (Cancel != null)
            {
                Cancel();
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs eventArgs)
        {
            if (Edit != null)
            {
                Edit(sender, eventArgs);
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs eventArgs)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(sender, eventArgs);
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs eventArgs)
        {
            if (Delete != null)
            {
                Delete(sender, eventArgs);
            }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        /*RITM0265746 - Sarnia CSD marked as read start */
        public bool MarkAsReadEnabled
        { set { } }
        public bool MarkAsReadVisible
        { set { } }
        public List<ItemReadBy> MarkedAsReadBy
        { set { } }
        public bool MarkedAsReadToggleCollaps
        { set { } }
        public event Action MarkAsRead;
        public event Action MarkedAsReadByToggled;
        /*RITM0265746 - Sarnia CSD marked as read End*/
        //DMND0010261-SELC CSD EdmontonPipeline
        public bool IsTheCSDForSCADAeDataLabel { get; set; }
    }
}
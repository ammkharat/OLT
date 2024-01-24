using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormEdmontonGN1Details : AbstractDetails, IFormEdmontonDetails
    {
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
        public event Action<TradeChecklist> ViewTradeChecklist;
        
        private readonly DomainListView<FormApproval> planningWorksheetApprovalListView;
        private readonly DomainListView<FormApproval> rescuePlanApprovalListView;
        private readonly DomainListView<WorkPermitEdmontonDTO> workPermitsListView;
        private readonly DomainListView<TradeChecklist> tradeChecklistListView;
        private readonly DetailsTradeChecklistRenderer detailsTradeChecklistRenderer;

        public FormEdmontonGN1Details()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;            

            planningWorksheetApprovalListView = new DomainListView<FormApproval>(new DetailsFormApprovalRenderer(), false) { Dock = DockStyle.Fill };
            planningWorksheetApprovalsGroupBox.Controls.Add(planningWorksheetApprovalListView);

            rescuePlanApprovalListView = new DomainListView<FormApproval>(new DetailsFormApprovalRenderer(), false) { Dock = DockStyle.Fill };
            rescuePlanApprovalsGroupBox.Controls.Add(rescuePlanApprovalListView);

            workPermitsListView = new DomainListView<WorkPermitEdmontonDTO>(new DetailsWorkPermitEdmontonRenderer(), false) { Dock = DockStyle.Fill };
            workPermitsGroupBox.Controls.Add(workPermitsListView);

            detailsTradeChecklistRenderer = new DetailsTradeChecklistRenderer();
            tradeChecklistListView = new DomainListView<TradeChecklist>(detailsTradeChecklistRenderer, false) { Dock = DockStyle.Fill };
            tradeChecklistGridPanel.Controls.Add(tradeChecklistListView);

            explandPlanningWorksheetLinkLabel.Click += HandleExpandPlanningWorksheetContentClicked;
            expandRescuePlanLinkLabel.Click += HandleExpandRescuePlanContentClicked;

            viewTradeChecklistButton.Click += HandleViewTradeChecklistButtonClicked;

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            closeButton.Click += HandleCloseButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            emailButton.Click += HandleEmailButtonClick;
            exportAllButton.Click += HandleExportButtonClick;            
        }

        private void HandleViewTradeChecklistButtonClicked(object sender, EventArgs e)
        {
            DomainListViewItem<TradeChecklist> domainListViewItem = tradeChecklistListView.SelectedItem;

            if (domainListViewItem != null && ViewTradeChecklist != null)
            {
                ViewTradeChecklist(domainListViewItem.Item);
            }            
        }

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
            set { closeButton.Enabled = value; }
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

        public bool CloseButtonVisible
        {
            set { closeButton.Visible = value; }
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

        private void HandleCloseButtonClick(object sender, EventArgs eventArgs)
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

        private void HandleCloneButtonClick(object sender, EventArgs eventArgs)
        {
            if (Clone != null)
            {
                Clone();
            }
        }
       
        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
        }

        private void HandleExpandPlanningWorksheetContentClicked(object sender, EventArgs e)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(PlanningWorksheetContent, true);
            expandedLogCommentForm.ShowDialog(this);
            expandedLogCommentForm.Dispose();
        }

        private void HandleExpandRescuePlanContentClicked(object sender, EventArgs e)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(RescuePlanContent, true);
            expandedLogCommentForm.ShowDialog(this);
            expandedLogCommentForm.Dispose();
        }        

        public void ClearDetails()
        {
            CreatedByUser = null;
            CreatedDateTime = null;
            LastModifiedByUser = null;
            LastModifiedDateTime = null;
            FormNumber = null;
            ApprovedDateTime = null;
            ClosedDateTime = null;
            FunctionalLocation = null;
            FormLocation = null;
            ValidFromDateTime = null;
            ValidToDateTime = null;
            CSELevel = null;
            JobDescription = null;
            PlanningWorksheetContent = null;
            PlanningWorksheetApprovals = null;
            SetTradeChecklists(null, string.Empty);
            RescuePlanContent = null;
            RescuePlanApprovals = null;
            WorkPermitEdmontonDTOs = null;
            
            PlanningWorksheetApprovals = new List<FormApproval>();
            DocumentLinks = new List<DocumentLink>();                
            
        }       

        public string CSELevel
        {
            set { cseLevelLabelData.Text = value; }
        }

        public string JobDescription
        {
            set { jobDescriptionTextBox.Text = value; }
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
            set { lastModifiedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        public DateTime? ValidFromDateTime
        {
            set { validFromDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public DateTime? ValidToDateTime
        {
            set { validToDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public long? FormNumber
        {
            set { formNumberDataLabel.Text = value == null ? string.Empty : value.Value.ToString(); }
        }

        public DateTime? ApprovedDateTime
        {
            set { approvedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public DateTime? ClosedDateTime
        {
            set { closedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public List<FormApproval> PlanningWorksheetApprovals
        {
            set { planningWorksheetApprovalListView.ItemList = value ?? new List<FormApproval>(); }
        }

        public List<FormApproval> RescuePlanApprovals
        {
            set { rescuePlanApprovalListView.ItemList = value ?? new List<FormApproval>(); }
        }

        public void SetTradeChecklists(List<TradeChecklist> tradeChecklists, string cseLevel)
        {
            detailsTradeChecklistRenderer.CseLevel = cseLevel;
            tradeChecklistListView.ItemList = tradeChecklists ?? new List<TradeChecklist>();
            tradeChecklistListView.SelectFirstItem();
        }

        public List<WorkPermitEdmontonDTO> WorkPermitEdmontonDTOs
        {
            set { workPermitsListView.ItemList = value ?? new List<WorkPermitEdmontonDTO>(); }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        public FunctionalLocation FunctionalLocation
        {
            set { functionalLocationDataLabel.Text = value == null ? null : value.FullHierarchyWithDescription; }
        }

        public string FormLocation
        {
            set { locationLabelData.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); }
        }

        public string PlanningWorksheetContent
        {
            set { planningWorksheetContentRichTextDisplay.Text = value; }
            private get { return planningWorksheetContentRichTextDisplay.Text; }
        }
       
        public string RescuePlanContent
        {
            set { rescuePlanContentRichTextDisplay.Text = value; }
            private get { return rescuePlanContentRichTextDisplay.Text; }
        }
       
        public bool WorkPermitEdmontonSectionVisible
        {
            set { workPermitsGroupBox.Visible = value; }
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
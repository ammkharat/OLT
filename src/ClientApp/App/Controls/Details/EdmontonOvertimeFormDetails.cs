using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class EdmontonOvertimeFormDetails : AbstractDetails, IFormEdmontonDetails
    {
        private readonly DomainListView<FormApproval> approvalListView;
        private readonly DomainListView<OnPremiseContractor> contractorsListView;

        private readonly DetailsTradeChecklistRenderer detailsTradeChecklistRenderer;

        public EdmontonOvertimeFormDetails()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;

            contractorsListView =
                new DomainListView<OnPremiseContractor>(new DetailsFormOvertimeOnPremiseContractorsRenderer(), false)
                {
                    Dock = DockStyle.Fill,
                    LabelWrap = true
                };
            onPremiseContractorsGroupBox.Controls.Add(contractorsListView);

            approvalListView = new DomainListView<FormApproval>(new DetailsFormOvertimeApprovalRenderer(), false)
            {
                Dock = DockStyle.Fill
            };
            approvalsGroupBox.Controls.Add(approvalListView);

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            emailButton.Click += HandleEmailButtonClick;
            exportAllButton.Click += HandleExportButtonClick;
        }

        public List<OnPremiseContractor> Contractors { set { contractorsListView.ItemList = value ?? new List<OnPremiseContractor>(); } }

        public List<FormApproval> Approvals { set { approvalListView.ItemList = value ?? new List<FormApproval>(); } }

        public string Trade { set { tradeDataLabel.Text = value; } }
        public DateTime? CreatedDateTime { set { createdDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); } }

        public User CreatedByUser { set { createdByUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; } }

        public DateTime? LastModifiedDateTime { set { lastModifiedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); } }

        public User LastModifiedByUser { set { lastModifiedUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; } }

        public DateTime? ValidFromDateTime { set { validFromDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); } }

        public DateTime? ValidToDateTime { set { validToDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); } }

        public long? FormNumber { set { formNumberDataLabel.Text = value == null ? string.Empty : value.Value.ToString(); } }

        public DateTime? ApprovedDateTime { set { approvedLabelData.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); } }

        public DateTime? CancelledDateTime { set { cancelledLabelData.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); } }
        public List<DocumentLink> DocumentLinks { set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); } }

        protected override Panel Details { get { return mainPanel; } }

        protected override ToolStripButton ToggleDateRangeButton { get { return dateRangeButton; } }

        public override ToolStripButton SaveGridLayoutButton { get { return saveGridLayoutButton; } }

        public bool DeleteVisible { set { deleteButton.Visible = value; } }

        public bool CancelEnabled { set { cancelButton.Enabled = value; } }
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

        public bool RangeVisible { set { dateRangeButton.Visible = value; } }

        public bool EditEnabled { set { editButton.Enabled = value; } }

        public bool ViewEditHistoryEnabled { set { historyButton.Enabled = value; } }

        public bool DeleteEnabled { set { deleteButton.Enabled = value; } }

        public bool CloneEnabled { set { cloneButton.Enabled = value; } }

        public bool CloseEnabled { set { cancelButton.Enabled = value; } }

        public bool PrintEnabled { set { printButton.Enabled = value; } }

        public bool EmailEnabled { set { emailButton.Enabled = value; } }

        public bool PrintButtonVisible { set { printButton.Visible = value; } }

        public bool CloseButtonVisible { set { cancelButton.Visible = value; } }

        public bool PrintPreviewEnabled { set { printPreviewButton.Enabled = value; } }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        public bool EditVisible { set { editButton.Visible = value; } }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
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

        private void HandleCloneButtonClick(object sender, EventArgs eventArgs)
        {
            if (Clone != null)
            {
                Clone();
            }
        }

        public void ClearDetails()
        {
            CreatedByUser = null;
            CreatedDateTime = null;
            LastModifiedByUser = null;
            LastModifiedDateTime = null;
            FormNumber = null;
            ApprovedDateTime = null;
            CancelledDateTime = null;
            ValidFromDateTime = null;
            ValidToDateTime = null;
            DocumentLinks = new List<DocumentLink>();
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }
        /*RITM0265746 - Sarnia CSD marked as read start */

        public bool MarkAsReadEnabled
        {
            set { }
        }

        public bool MarkAsReadVisible
        {
            set { }
        }
        public List<ItemReadBy> MarkedAsReadBy
        {
            set { }
        }

        public bool MarkedAsReadToggleCollaps
        {
            set { }
        }
        public event Action MarkAsRead;
        public event Action MarkedAsReadByToggled;
        /*RITM0265746 - Sarnia CSD marked as read End*/

        //DMND0010261-SELC CSD EdmontonPipeline
      public  bool IsTheCSDForSCADAeDataLabel { get; set; }
    }
}
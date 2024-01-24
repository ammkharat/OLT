using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormTemporaryInstallationsDetails : AbstractDetails, IFormEdmontonDetails
    {
        private readonly DomainListView<FormApproval> approvalListView;
        private readonly DomainListView<FunctionalLocation> functionalLocationListView;
        private readonly DomainListView<WorkPermitEdmontonDTO> workPermitsListView;
        private int? criticalSystemDefeatedDefaultGroupBoxHeight;

        public FormTemporaryInstallationsDetails()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;

            functionalLocationListView = new DomainListView<FunctionalLocation>(
                new DetailsFunctionalLocationRenderer(), false) {Dock = DockStyle.Fill};
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            approvalListView = new DomainListView<FormApproval>(new DetailsFormApprovalRenderer(), false)
            {
                Dock = DockStyle.Fill
            };
            approvalsGroupBox.Controls.Add(approvalListView);

            workPermitsListView = new DomainListView<WorkPermitEdmontonDTO>(new DetailsWorkPermitEdmontonRenderer(),
                false) {Dock = DockStyle.Fill};
            workPermitsGroupBox.Controls.Add(workPermitsListView);

            expandLinkLabel.Click += HandleExpandClicked;

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

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); }
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

        public string ValidFromDateTimeLabel
        {
            set { validFromLabel.Text = value; }
        }

        public string ValidToDateTimeLabel
        {
            set { validToLabel.Text = value; }
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

        public List<FormApproval> Approvals
        {
            set { approvalListView.ItemList = value ?? new List<FormApproval>(); }
        }

        public List<WorkPermitEdmontonDTO> WorkPermitEdmontonDTOs
        {
            set { workPermitsListView.ItemList = value ?? new List<WorkPermitEdmontonDTO>(); }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value ?? new List<FunctionalLocation>(); }
        }

        public string Content
        {
            set { contentRichTextDisplay.Text = value; }
            private get { return contentRichTextDisplay.Text; }
        }


        public bool? HasAttachments
        {
            set { hasAttachmentsDataLabel.Text = value != null ? value.Value.BooleanToYesNoString() : string.Empty; }
        }

        public bool? HasBeenCommunicated
        {
            set
            {
                hasBeenCommunicatedDataLabel.Text = value != null ? value.Value.BooleanToYesNoString() : string.Empty;
            }
        }

        public bool? IsTheCSDForAPressureSafetyValve
        {
            set
            {
                isTheCSDForAPressureSafetyValveDataLabel.Text = value != null
                    ? value.Value.BooleanToYesNoString()
                    : string.Empty;
            }
        }

        public string CriticalSystemDefeated
        {
            set { criticalSystemDefeatedTextBox.Text = value ?? string.Empty; }
        }

        public string CsdReason
        {
            set { csdReasonTextBox.Text = value ?? string.Empty; }
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
            set { closeButton.Enabled = value; }
            get { return closeButton.Enabled; }
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

        public bool PrintVisible
        {
            set { printButton.Visible = value; }
        }

        public bool EmailVisible
        {
            set { emailButton.Visible = value; }
        }

        public bool CloseButtonVisible
        {
            set { closeButton.Visible = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public bool PrintPreviewVisible
        {
            set { printPreviewButton.Visible = value; }
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
            if (Close != null)
            {
                Close();
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

        private void HandleExpandClicked(object sender, EventArgs e)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(Content, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        public void AdjustTextBoxHeights()
        {
            if (criticalSystemDefeatedDefaultGroupBoxHeight == null)
            {
                criticalSystemDefeatedDefaultGroupBoxHeight = criticalSystemDefeatedGroupBox.Height;
            }

            criticalSystemDefeatedGroupBox.Height = criticalSystemDefeatedDefaultGroupBoxHeight.Value;

            AdjustTextBoxHeightToFitText(criticalSystemDefeatedTextBox, criticalSystemDefeatedGroupBox);
        }

        private static void AdjustTextBoxHeightToFitText(TextBox textBox, GroupBox containerGroupBox)
        {
            var oldContainerHeight = containerGroupBox.Height;
            var size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue),
                TextFormatFlags.WordBreak);
            var heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
            }
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
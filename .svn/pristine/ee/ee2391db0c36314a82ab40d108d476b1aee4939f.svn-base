using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormEdmontonGN6Details : AbstractDetails, IFormEdmontonDetails
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

        private readonly DomainListView<FunctionalLocation> functionalLocationListView;
        private readonly DomainListView<FormApproval> approvalListView;
        private readonly DomainListView<WorkPermitEdmontonDTO> workPermitsListView;
        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public FormEdmontonGN6Details()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;

            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            approvalListView = new DomainListView<FormApproval>(new DetailsFormApprovalRenderer(), false) { Dock = DockStyle.Fill };
            approvalsGroupBox.Controls.Add(approvalListView);

            workPermitsListView = new DomainListView<WorkPermitEdmontonDTO>(new DetailsWorkPermitEdmontonRenderer(), false) { Dock = DockStyle.Fill };
            workPermitsGroupBox.Controls.Add(workPermitsListView);

            expandSection1ContentLinkLabel.Click += (sender, args) => Expandify(Section1Content);
            expandSection2ContentLinkLabel.Click += (sender, args) => Expandify(Section2Content);
            expandSection3ContentLinkLabel.Click += (sender, args) => Expandify(Section3Content);
            expandSection4ContentLinkLabel.Click += (sender, args) => Expandify(Section4Content);
            expandSection5ContentLinkLabel.Click += (sender, args) => Expandify(Section5Content);
            expandSection6ContentLinkLabel.Click += (sender, args) => Expandify(Section6Content);

            expandPreJobMeetingSignaturesLinkLabel.Click += (sender, args) => Expandify(PreJobMeetingSignatures);

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            closeButton.Click += HandleCloseButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            emailButton.Click += HandleEmailButtonClick;
            exportAllButton.Click += HandleExportButtonClick;

            Disposed += HandleDisposed;
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            originalControlHeights.Clear();
        }

        public void AdjustTextBoxHeights()
        {
            StoreOriginalHeight(jobDescriptionGroupBox);
            StoreOriginalHeight(reasonForCriticalLiftGroupBox);

            jobDescriptionGroupBox.Height = originalControlHeights[jobDescriptionGroupBox];
            reasonForCriticalLiftGroupBox.Height = originalControlHeights[reasonForCriticalLiftGroupBox];

            AdjustTextBoxHeightToFitText(jobDescriptionTextBox, jobDescriptionGroupBox);
            AdjustTextBoxHeightToFitText(reasonForCriticalLiftTextBox, reasonForCriticalLiftGroupBox);
        }

        private void StoreOriginalHeight(OltGroupBox control)
        {
            if (!originalControlHeights.ContainsKey(control))
            {
                originalControlHeights.Add(control, control.Height);
            }
        }

        private void AdjustTextBoxHeightToFitText(TextBox textBox, GroupBox containerGroupBox)
        {
            int oldContainerHeight = containerGroupBox.Height;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue), TextFormatFlags.WordBreak);
            int heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
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

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
        }

        private void Expandify(string content)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(content, true);
            expandedLogCommentForm.ShowDialog(this);
            expandedLogCommentForm.Dispose();
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

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value ?? new List<FunctionalLocation>(); }
        }

        public bool Section1NotApplicableToJob
        {
            set { section1NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section1Content
        {
            set { section1ContentRichTextDisplay.Text = value; }
            private get { return section1ContentRichTextDisplay.Text; }
        }

        public bool Section2NotApplicableToJob
        {
            set { section2NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section2Content
        {
            set { section2ContentRichTextDisplay.Text = value; }
            private get { return section2ContentRichTextDisplay.Text; }
        }

        public bool Section3NotApplicableToJob
        {
            set { section3NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section3Content
        {
            set { section3ContentRichTextDisplay.Text = value; }
            private get { return section3ContentRichTextDisplay.Text; }
        }

        public bool Section4NotApplicableToJob
        {
            set { section4NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section4Content
        {
            set { section4ContentRichTextDisplay.Text = value; }
            private get { return section4ContentRichTextDisplay.Text; }
        }

        public bool Section5NotApplicableToJob
        {
            set { section5NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section5Content
        {
            set { section5ContentRichTextDisplay.Text = value; }
            private get { return section5ContentRichTextDisplay.Text; }
        }

        public bool Section6NotApplicableToJob
        {
            set { section6NotApplicableToJobCheckBox.Checked = value; }
        }

        public string Section6Content
        {
            set { section6ContentRichTextDisplay.Text = value; }
            private get { return section6ContentRichTextDisplay.Text; }
        }

        public string JobDescription
        {
            set { jobDescriptionTextBox.Text = value; }
        }

        public string ReasonForCriticalLift
        {
            set { reasonForCriticalLiftTextBox.Text = value; }
        }

        public string PreJobMeetingSignatures
        {
            set { preJobMeetingSignaturesRichTextDisplay.Text = value; }
            private get { return preJobMeetingSignaturesRichTextDisplay.Text; }
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

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); }
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

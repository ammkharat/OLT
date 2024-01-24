using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormOilsandsTrainingDetails : AbstractDetails, IFormOilsandsTrainingDetails
    {
        public event EventHandler ExportAll;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Clone;
        public event EventHandler Print;
        public event EventHandler Preview;
        public event EventHandler Email;

        private readonly DomainListView<FormApproval> approvalListView;
        private readonly DomainListView<FunctionalLocation> functionalLocationListView;
        private readonly DomainListView<FormOilsandsTrainingItem> trainingItemListView;

        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public FormOilsandsTrainingDetails()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            exportAllButton.Click += ExportButtonClicked;
            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            emailButton.Click += HandleEmailButtonClick;

            approvalListView = new DomainListView<FormApproval>(new DetailsFormApprovalRenderer(), false) { Dock = DockStyle.Fill };
            approvalsGroupBox.Controls.Add(approvalListView);

            trainingItemListView = new DomainListView<FormOilsandsTrainingItem>(new DetailsFormOilsandsTrainingItemRenderer(), false) { Dock = DockStyle.Fill };
            trainingItemsGroupBox.Controls.Add(trainingItemListView);

            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            Disposed += HandleDisposed;
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            originalControlHeights.Clear();
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveLayoutToolStripButton; }
        }

        private void ExportButtonClicked(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(sender, e);
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(sender, e);
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(sender, e);
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(sender, e);
            }
        }

        private void HandlePrintButtonClick(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(sender, e);
            }
        }

        private void HandlePrintPreviewButtonClick(object sender, EventArgs e)
        {
            if (Preview != null)
            {
                Preview(sender, e);
            }
        }

        private void HandleEmailButtonClick(object sender, EventArgs e)
        {
            if (Email != null)
            {
                Email(sender, e);
            }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool EmailEnabled
        {
            set { emailButton.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        protected override Panel Details
        {
            get { return mainPanel; }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        private void AdjustTextBoxHeights()
        {
            StoreOriginalHeight(generalCommentsGroupBox);

            generalCommentsGroupBox.Height = originalControlHeights[generalCommentsGroupBox];

            AdjustTextBoxHeightToFitText(generalCommentsTextBox, generalCommentsGroupBox);
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

        public void SetDetails(FormOilsandsTraining form)
        {
            if (form == null)
            {
                formNumberDataLabel.Text = string.Empty;
                approvedDateDataLabel.Text = string.Empty;

                createdByUserDataLabel.Text = string.Empty;
                createdDateDataLabel.Text = string.Empty;

                lastModifiedUserDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;

                generalCommentsTextBox.Text = string.Empty;
                trainingDateDataLabel.Text = string.Empty;
                shiftDataLabel.Text = string.Empty;

                trainingItemListView.ItemList = new List<FormOilsandsTrainingItem>();
                approvalListView.ItemList = new List<FormApproval>();
                functionalLocationListView.ItemList = new List<FunctionalLocation>();
            }
            else
            {
                formNumberDataLabel.Text = form.IdValue.ToString();
                approvedDateDataLabel.Text = form.ApprovedDateTime.ToLongDateAndTimeStringOrEmptyString();

                createdByUserDataLabel.Text = form.CreatedBy.FullNameWithUserName;
                createdDateDataLabel.Text = form.CreatedDateTime.ToLongDateAndTimeString();

                lastModifiedUserDataLabel.Text = form.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = form.LastModifiedDateTime.ToLongDateAndTimeString();

                generalCommentsTextBox.Text = form.GeneralComments;
                trainingDateDataLabel.Text = form.TrainingDate.ToLongDate();
                shiftDataLabel.Text = form.ShiftPattern.Name;

                trainingItemListView.ItemList = form.TrainingItems;
                approvalListView.ItemList = form.Approvals;
                functionalLocationListView.ItemList = form.FunctionalLocations;
            }

            AdjustTextBoxHeights();
        }
    }
}

using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class  LabAlertDefinitionDetails : AbstractDetails, ILabAlertDefinitionDetails
    {
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;

        private string minimumNumberOfSamples;

        public LabAlertDefinitionDetails()
        {
            InitializeComponent();
            detailsPanel.MouseEnter += DetailsPanel_MouseEnter;
            deleteButton.Click += DeleteButton_Click;
            editButton.Click += EditButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            exportAllButton.Click += ExportAllButton_Click;
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void DetailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        public string EditedBy
        {
            set { editedByDataLabel.Text = value; }
        }

        public string CreatedBy
        {
            set { createdByDataLabel.Text = value; }
        }

        public bool Active
        {
            set { temporarilyInactiveCheckBox.Checked = ! value; }
        }

        public string DefinitionName
        {
            set { nameData.Text = value; }
        }

        public string FunctionalLocation
        {
            set { functionalLocationData.Text = value; }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        public string Tag
        {
            set { tagData.Text = value; }
        }

        public string MinimumNumberOfSamples
        {
            set
            {
                minimumNumberOfSamples = value;
                UpdateWhatToCheck();
            }
        }

        private void UpdateWhatToCheck()
        {
            minimumNumberOfSamplesLabel.Text = String.Format(StringResources.LabAlertDefinitionWhatToCheckText, minimumNumberOfSamples);
        }

        public string LabAlertTagQueryRangeFrom
        {
            set
            {
                timeRangeFromLabel.Text = value;
                fromLabel.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public string LabAlertTagQueryRangeTo
        {
            set
            {
                timeRangeToLabel.Text = value;
                toLabel.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public string Schedule
        {
            set { scheduleLabelData.Text = value; }
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
            set { editHistoryButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
            }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return toggleShowButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }
    }
}
using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class  RestrictionDefinitionDetails : AbstractDetails, IRestrictionDefinitionDetails
    {
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;

        public RestrictionDefinitionDetails()
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

        public string MeasurementTag
        {
            set { measurementTagData.Text = value; }
        }

        public string ProductionTarget
        {
            set { productionTargetData.Text = value; }
        }

        public string PreviousInvocationDate
        {
            set { previousInvocationDate.Text = value; }
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


        public int? ToleranceValue
        {
            set { oltTolerance.Text =Convert.ToString(value); }
        }

        // DMND0010124 mangesh
        public string FrequencyValue
        {
            set { oltFrequency.Text = Convert.ToString(value); }
        }
    }
}
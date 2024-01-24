using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class TargetAlertDetails : AbstractDetails, ITargetAlertDetails
    {
        public event Action Acknowledge;
        public event EventHandler Respond;
        public event EventHandler GoToDefinition;
        public event EventHandler ExportAll;
        public event Action ViewAssociatedLogs;
        public event EventHandler CopyLastResponse; //DMND0010124 mangesh

        public TargetAlertDetails()
        {
            InitializeComponent();
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            exportAllButton.Click += exportAllButton_Click;
            goToTargetDefinitionButton.Click += goToTargetDefinitionButton_Click;
            viewAssociatedLogsButton.Click += viewAssociatedLogsButton_Click;
        }

        private void viewAssociatedLogsButton_Click(object sender, EventArgs e)
        {
            if (ViewAssociatedLogs != null)
            {
                ViewAssociatedLogs();
            }
        }

        //DMND0010124 mangesh
        public bool CopyLastResponseEnabled
        {
            set { }
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }
        
        private void goToTargetDefinitionButton_Click(object sender, EventArgs e)
        {
            if (GoToDefinition != null)
            {
                GoToDefinition(sender, e);
            }
        }
        private void acknowledgeButton_Click(object sender, EventArgs e)
        {
            if (Acknowledge != null)
            {
                Acknowledge();
            }
        }
        private void respondButton_Click(object sender, EventArgs e)
        {
            if (Respond != null)
            {
                Respond(sender, e);
            }
        }
        private void exportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }
        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        public bool GoToDefinitionEnabled
        {
            set { goToTargetDefinitionButton.Enabled = value; }
        }

        public string TargetName
        {
            set { targetNameDataLabel.Text = value; }
        }

        public string WorkAssignmentName
        {
            set { workAssignmentLabelData.Text = value; }
        }

        public string FunctionalLocationName
        {
            set { functionalLocationDataLabel.Text = value; }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        public DateTime? LastViolatedDateTime
        {
            set
            {
                if (value == null)
                {
                    lastViolatedDataLabel.Text = string.Empty;
                }
                else
                {
                    lastViolatedDataLabel.Text = value.Value.ToLongDateAndTimeString();
                }
            }
        }

        public string TagName
        {
            set { tagDataLabel.Text = value; }
        }

        public string TagUnits
        {
            set { actualValueUnitsDataLabel.Text = value; }
        }

        public string Category
        {
            set { categoryDataLabel.Text = value; }
        }

        public string NeverToExceedMax
        {
            set { neverToExceedMaxDataLabel.Text = value; }
        }

        public string Max
        {
            set { maxDataLabel.Text = value; }
        }

        public string Min
        {
            set { minDataLabel.Text = value; }
        }

        public string NeverToExceedMin
        {
            set { neverToExceedMinDataLabel.Text = value; }
        }

        public string TargetValue
        {
            set { targetDataLabel.Text = value; }
        }

        public string GapUnitValue
        {
            set { gapUnitValueDataLabel.Text = value; }
        }

        public string GapUnitValueUnits
        {
            set { gapUnitValueUnitsLabel.Text = value; }
        }

        public string ActualValue
        {
            set { actualValueDataLabel.Text = value; }
        }

        public string CalculatedLosses
        {
            set { calculatedLossesDataLabel.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        public ISchedule Schedule
        {
            set { scheduleDisplay.Schedule = value; }
        }

        public bool ViewAssociatedLogsEnabled
        {
            set { viewAssociatedLogsButton.Enabled = value; }
        }

        public bool AcknowledgeEnabled
        {
            set { acknowledgeButton.Enabled = value; }
        }

        public bool RespondEnabled
        {
            set { respondButton.Enabled = value; }
        }

        public bool SaveGridLayoutVisible
        {
            set { saveGridLayoutButton.Visible = value; }
        }

        public bool ExportVisible
        {
            set { exportAllButton.Visible = value; }
        }

        public bool RangeVisible
        {
            set { toggleShowButton.Visible = value; }
        }

        public bool GoToDefinitionVisible
        {
            set { goToTargetDefinitionButton.Visible = value; }
        }

        public bool ViewAssociatedLogsVisible
        {
            set { viewAssociatedLogsButton.Visible = value; }
        }

        public void CallDefaultButton()
        {
            if (acknowledgeButton.Enabled)
            {
                acknowledgeButton_Click(this, new EventArgs());
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
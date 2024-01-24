using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class DeviationAlertDetails : AbstractDetails, IDeviationAlertDetails
    {        
        public event EventHandler Respond;
        public event EventHandler GoToDefinition;
        public event EventHandler ExportAll;
        public event EventHandler ViewResponseHistory;
        public event EventHandler CopyLastResponse; //DMND0010124 mangesh

        private DomainSummaryGrid<DeviationAlertResponseReasonCodeAssignment> responseGrid;

        public DeviationAlertDetails()
        {
            InitializeComponent();
            InitializeResponseGrid();
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            exportAllButton.Click += exportAllButton_Click;
            goToTargetDefinitionButton.Click += GoToDefinitionButton_Click;
            responseHistoryButton.Click += ResponseHistoryButton_Click;
            copyLastResponseButton.Click += copyLastResponseButton_Click; //DMND0010124 mangesh
        }

        
        private void InitializeResponseGrid()
        {
            responseGrid = new DomainSummaryGrid<DeviationAlertResponseReasonCodeAssignment>(
                new DeviationAlertResponseReasonCodeAssignmentGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty)
                               {Dock = DockStyle.Fill};

            responseGrid.DisplayLayout.GroupByBox.Hidden = true;
            responsePanel.Controls.Add(responseGrid);
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }
        
        private void GoToDefinitionButton_Click(object sender, EventArgs e)
        {
            if (GoToDefinition != null)
            {
                GoToDefinition(sender, e);
            }
        }

        private void ResponseHistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewResponseHistory != null)
            {
                ViewResponseHistory(sender, e);
            }
        }

        private void respondButton_Click(object sender, EventArgs e)
        {
            if (Respond != null)
            {
                Respond(sender, e);
            }
        }

        //DMND0010124 mangesh
        void copyLastResponseButton_Click(object sender, EventArgs e)
        {
            if(CopyLastResponse != null)
            {
                CopyLastResponse(sender, e);
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

        public bool ViewReponseHistoryEnabled
        {
            set { responseHistoryButton.Enabled = value; }
        }

        public string RestrictionDefinitionName
        {
            set { restrictionNameDataLabel.Text = value; }
        }

        public string FunctionalLocationName
        {
            set { functionalLocationDataLabel.Text = value; }
        }

        public string RestrictionDefinitionDescription
        {
            set { descriptionTextBox.Text = value; }
        }

        public string MeasurementTagName
        {
            set { measurementTagNameDataLabel.Text = value; }
        }

        public string MeasurementTagValue
        {
            set { measurementValueDataLabel.Text = value; }
        }

        public string ProductionTargetTagName
        {
            set { productionTargetTagNameDataLabel.Text = value; }
        }

        public string ProductionTargetTagValue
        {
            set { productionTargetValueDataLabel.Text = value; }
        }

        public string DeviationValue
        {
            set { deviationValueDataLabel.Text = value; }
        }

        public string Comments
        {
            set { engineerCommentTextBox.Text = value; }
        }

        public string StartTime
        {
            set { startTimeDataLabel.Text = value; }
        }

        public string EndTime
        {
            set { endTimeDataLabel.Text = value; }
        }

        public bool RespondEnabled
        {
            set { respondButton.Enabled = value; }
        }

        //DMND0010124 mangesh
        public bool CopyLastResponseEnabled
        {
            set { copyLastResponseButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (respondButton.Enabled)
            {
                respondButton_Click(this, new EventArgs());       
            }
        }

        public List<DeviationAlertResponseReasonCodeAssignment> Assignments
        {
            set { responseGrid.Items = value; }
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
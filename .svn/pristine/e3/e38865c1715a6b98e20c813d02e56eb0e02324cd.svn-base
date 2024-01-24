using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class  LabAlertDetails : AbstractDetails, ILabAlertDetails
    {
        public event EventHandler Respond;
        public event EventHandler GoToDefinition;
        public event EventHandler ExportAll;
        public event EventHandler CopyLastResponse; //DMND0010124 mangesh

        private readonly DomainSummaryGrid<LabAlertResponse> responseGrid;

        public LabAlertDetails()
        {
            InitializeComponent();

            responseGrid = new DomainSummaryGrid<LabAlertResponse>(
                new LabAlertResponseGridRenderer(), OltGridAppearance.NON_OUTLOOK_WRAPPED_TEXT, string.Empty);

            responseGrid.Dock = DockStyle.Fill;
            responseGrid.DisplayLayout.GroupByBox.Hidden = true;
            responsePanel.Controls.Add(responseGrid);

            detailsPanel.MouseEnter += DetailsPanel_MouseEnter;
            respondButton.Click += RespondButton_Click;
            goToDefinitionButton.Click += GoToDefinitionButton_Click;
            exportAllButton.Click += ExportAllButton_Click;
        }

        //DMND0010124 mangesh
        public bool CopyLastResponseEnabled
        {
            set { }
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void DetailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void RespondButton_Click(object sender, EventArgs e)
        {
            if (Respond != null)
            {
                Respond(this, e);
            }
        }

        private void GoToDefinitionButton_Click(object sender, EventArgs e)
        {
            if (GoToDefinition != null)
            {
                GoToDefinition(this, e);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        public string CreatedDateTime
        {
            set { createdDateTimeLabelData.Text = value; }
        }

        public string DefinitionName
        {
            set { nameData.Text = value; }
        }

        public string FunctionalLocation
        {
            set { functionalLocationData.Text = value; }
        }

        public string Tag
        {
            set { tagData.Text = value; }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        public int ActualNumberOfSamples
        {
            set { actualNumberOfSamplesLabelData.Text = value.ToString(); }
        }

        public int MinimumNumberOfSamples
        {
            set
            {
                minimumNumberOfSamplesLabel.Text =
                    String.Format(StringResources.LabAlertDetailsMininumSamplesLabel, value);
            }
        }

        public string LabAlertTagQueryRangeFromDateTime
        {
            set { timeRangeFromLabel.Text = value; }
        }

        public string LabAlertTagQueryRangeToDateTime
        {
            set { timeRangeToLabel.Text = value; }
        }

        public string Schedule
        {
            set { scheduleLabelData.Text = value; }
        }

        public List<LabAlertResponse> Responses
        {
            set { responseGrid.Items = value; }
        }

        public bool GoToDefinitionEnabled
        {
            set { goToDefinitionButton.Enabled = value; }
        }

        public bool RespondEnabled
        {
            set { respondButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (respondButton.Enabled)
            {
                RespondButton_Click(this, new EventArgs());
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
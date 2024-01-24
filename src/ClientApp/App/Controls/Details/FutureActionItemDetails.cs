using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FutureActionItemDetails : AbstractDetails, IFutureActionItemDetails
    {
        public event EventHandler Respond;
        public event EventHandler GoToDefinition;
        public bool GoToDefinitionEnabled { set; private get; }
        public bool RespondEnabled { set; private get; }
        public event EventHandler CopyLastResponse; //DMND0010124 mangesh

        public FutureActionItemDetails()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            refreshButton.Click += RefreshButtonClick;
            exportAllButton.Click += ExportAllButtonClick;
            goToDefinitionButton.Click += goToDefinitionButton_Click;

        }

        //DMND0010124 mangesh
        public bool CopyLastResponseEnabled
        {
            set {  }
        }

        protected override Panel Details { get { return noSpacePanel; } }

        public override ToolStripButton SaveGridLayoutButton { get { return saveLayoutToolStripButton; } }

        protected override ToolStripButton ToggleDateRangeButton { get { return dateRangeToggleButton; } }

        public event EventHandler RefreshAll;

        public void HideRefreshButton()
        {
            refreshButton.Visible = false;
        }

        public event EventHandler ExportAll;

        public void CallDefaultButton()
        {
            // TODO: put the print here? or do nothing?
        }

        private void goToDefinitionButton_Click(object sender, EventArgs e)
        {
            if (GoToDefinition != null)
            {
                GoToDefinition(this, e);
            }
        }


        public bool GoToDefinitionVisible
        {
            set { goToDefinitionButton.Visible = value; }
        }

        private void ExportAllButtonClick(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(sender, e);
            }
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            if (RefreshAll != null)
            {
                RefreshAll(sender,e);
            }
        }
    }
}
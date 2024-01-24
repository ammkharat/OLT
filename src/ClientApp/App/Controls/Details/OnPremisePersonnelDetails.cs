using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class OnPremisePersonnelDetails : AbstractDetails, IOnPremisePersonnelDetails
    {
        public OnPremisePersonnelDetails()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            refreshButton.Click += RefreshButtonClick;
            exportAllButton.Click += ExportAllButtonClick;
        }

        protected override Panel Details { get { return noSpacePanel; } }

        public override ToolStripButton SaveGridLayoutButton { get { return saveLayoutToolStripButton; } }

        protected override ToolStripButton ToggleDateRangeButton { get { return dateRangeToggleButton; } }

        public event Action RefreshAll;

        public void HideRefreshButton()
        {
            refreshButton.Visible = false;
        }

        public event EventHandler ExportAll;

        public void CallDefaultButton()
        {
            // TODO: put the print here? or do nothing?
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
                RefreshAll();
            }
        }
    }
}
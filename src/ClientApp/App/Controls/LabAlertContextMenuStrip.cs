using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public class LabAlertContextMenuStrip : ContextMenuStrip, ILabAlertActions
    {
        public event EventHandler Respond;
        private ToolStripMenuItem respondToolStripMenuItem;

        public LabAlertContextMenuStrip(IContainer container)
                : base(container)
        {
            InitializeComponent();
            respondToolStripMenuItem.Click += respondToolStripMenuItem_Click;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertContextMenuStrip));
            this.respondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // respondToolStripMenuItem
            // 
            this.respondToolStripMenuItem.Name = "respondToolStripMenuItem";
            resources.ApplyResources(this.respondToolStripMenuItem, "respondToolStripMenuItem");
            // 
            // LabAlertContextMenuStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.respondToolStripMenuItem});
            this.Name = "labAlertContextMenuStrip";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);

        }

        private void respondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(null != Respond)
            {
                Respond(sender, e);
            }
        }

        public bool RespondEnabled
        {
            set { respondToolStripMenuItem.Enabled = value; }
        }
    }
}
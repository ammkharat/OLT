using System;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;

namespace Com.Suncor.Olt.Client.Controls
{
    public class TargetAlertContextMenuStrip : ContextMenuStrip, ITargetAlertActions
    {
        public event EventHandler Acknowledge;
        public event EventHandler Respond;
        private ToolStripMenuItem acknowledgeToolStripMenuItem;
        private ToolStripMenuItem respondToolStripMenuItem;

        public TargetAlertContextMenuStrip(IContainer container)
                : base(container)
        {
            InitializeComponent();
            acknowledgeToolStripMenuItem.Click += acknowledgeToolStripMenuItem_Click;
            respondToolStripMenuItem.Click += respondToolStripMenuItem_Click;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetAlertContextMenuStrip));
            this.acknowledgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // acknowledgeToolStripMenuItem
            // 
            this.acknowledgeToolStripMenuItem.Name = "acknowledgeToolStripMenuItem";
            resources.ApplyResources(this.acknowledgeToolStripMenuItem, "acknowledgeToolStripMenuItem");
            // 
            // respondToolStripMenuItem
            // 
            this.respondToolStripMenuItem.Name = "respondToolStripMenuItem";
            resources.ApplyResources(this.respondToolStripMenuItem, "respondToolStripMenuItem");
            // 
            // TargetAlertContextMenuStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acknowledgeToolStripMenuItem,
            this.respondToolStripMenuItem});
            this.Name = "targetContextMenuStrip";
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

        private void acknowledgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(null != Acknowledge)
            {
                Acknowledge(sender, e);
            }
        }

        public bool AcknowledgeEnabled
        {
            set { acknowledgeToolStripMenuItem.Enabled = value; }
        }

        public bool RespondEnabled
        {
            set { respondToolStripMenuItem.Enabled = value; }
        }
    }
}
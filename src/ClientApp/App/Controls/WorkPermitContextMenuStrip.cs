using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public class WorkPermitContextMenuStrip : ContextMenuStrip, IWorkPermitActions
    {
        private ToolStripMenuItem approveToolStripMenuItem;
        private ToolStripMenuItem cloneToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem commentToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem previewToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem rejectToolStripMenuItem;

        public WorkPermitContextMenuStrip(IContainer container)
            : base(container)
        {
            InitializeComponent();
            approveToolStripMenuItem.Click += approveToolStripMenuItem_Click;
            rejectToolStripMenuItem.Click += rejectToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            commentToolStripMenuItem.Click += commentToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            cloneToolStripMenuItem.Click += cloneToolStripMenuItem_Click;
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            previewToolStripMenuItem.Click += previewToolStripMenuItem_Click;
        }

        #region IWorkPermitActions Members

        public event EventHandler Approve;
        public event EventHandler Reject;
        public event EventHandler CloseWorkPermit;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Comment;
        public event EventHandler Copy;
        public event EventHandler Clone;
        public event EventHandler Print;
        public event EventHandler PrintPreview;

        public bool ApproveEnabled
        {
            set { approveToolStripMenuItem.Enabled = value; }
        }

        public bool RejectEnabled
        {
            set { rejectToolStripMenuItem.Enabled = value; }
        }

        public bool CloseEnabled
        {
            set { closeToolStripMenuItem.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteToolStripMenuItem.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editToolStripMenuItem.Enabled = value; }
        }

        public bool CommentEnabled
        {
            set { commentToolStripMenuItem.Enabled = value; }
        }

        public bool CopyEnabled
        {
            set { copyToolStripMenuItem.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneToolStripMenuItem.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printToolStripMenuItem.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { previewToolStripMenuItem.Enabled = value; }
        }

        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitContextMenuStrip));
            this.approveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // approveToolStripMenuItem
            // 
            this.approveToolStripMenuItem.Name = "approveToolStripMenuItem";
            resources.ApplyResources(this.approveToolStripMenuItem, "approveToolStripMenuItem");
            // 
            // rejectToolStripMenuItem
            // 
            this.rejectToolStripMenuItem.Name = "rejectToolStripMenuItem";
            resources.ApplyResources(this.rejectToolStripMenuItem, "rejectToolStripMenuItem");
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // commentToolStripMenuItem
            // 
            this.commentToolStripMenuItem.Name = "commentToolStripMenuItem";
            resources.ApplyResources(this.commentToolStripMenuItem, "commentToolStripMenuItem");
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            resources.ApplyResources(this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            resources.ApplyResources(this.previewToolStripMenuItem, "previewToolStripMenuItem");
            // 
            // WorkPermitContextMenuStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveToolStripMenuItem,
            this.rejectToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem,
            this.commentToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.printToolStripMenuItem,
            this.previewToolStripMenuItem});
            this.Name = "permitContextMenuStrip";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);

        }

        private void HookEvent(EventHandler eventhandler, object sender, EventArgs e)
        {
            if (null != eventhandler)
            {
                eventhandler(sender, e);
            }
        }

        private void approveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Approve, sender, e);
        }

        private void rejectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Reject, sender, e);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(CloseWorkPermit, sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Delete, sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Edit, sender, e);
        }

        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Comment, sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Copy, sender, e);
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Clone, sender, e);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(Print, sender, e);
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HookEvent(PrintPreview, sender, e);
        }
    }
}
using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class OnPremisePersonnelDetails
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnPremisePersonnelDetails));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.exportAllButton = new System.Windows.Forms.ToolStripButton();
            this.dateRangeToggleButton = new System.Windows.Forms.ToolStripButton();
            this.saveLayoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.noSpacePanel = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshButton,
            this.exportAllButton,
            this.dateRangeToggleButton,
            this.saveLayoutToolStripButton});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // refreshButton
            // 
            this.refreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refreshButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.refresh_all;
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            // 
            // exportAllButton
            // 
            this.exportAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportAllButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.export_all;
            resources.ApplyResources(this.exportAllButton, "exportAllButton");
            this.exportAllButton.Name = "exportAllButton";
            // 
            // dateRangeToggleButton
            // 
            this.dateRangeToggleButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dateRangeToggleButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.show_date_range;
            resources.ApplyResources(this.dateRangeToggleButton, "dateRangeToggleButton");
            this.dateRangeToggleButton.Name = "dateRangeToggleButton";
            // 
            // saveLayoutToolStripButton
            // 
            this.saveLayoutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveLayoutToolStripButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.grid_16;
            resources.ApplyResources(this.saveLayoutToolStripButton, "saveLayoutToolStripButton");
            this.saveLayoutToolStripButton.Name = "saveLayoutToolStripButton";
            // 
            // noSpacePanel
            // 
            resources.ApplyResources(this.noSpacePanel, "noSpacePanel");
            this.noSpacePanel.Name = "noSpacePanel";
            // 
            // OnPremisePersonnelDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noSpacePanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "OnPremisePersonnelDetails";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton exportAllButton;
        private System.Windows.Forms.ToolStripButton dateRangeToggleButton;
        private System.Windows.Forms.ToolStripButton saveLayoutToolStripButton;
        private System.Windows.Forms.Panel noSpacePanel;
        internal System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton refreshButton;
    }
}
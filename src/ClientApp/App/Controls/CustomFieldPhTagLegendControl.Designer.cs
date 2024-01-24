using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class CustomFieldPhTagLegendControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFieldPhTagLegendControl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.readPanel = new System.Windows.Forms.Panel();
            this.readColourPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.readLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.writePanel = new System.Windows.Forms.Panel();
            this.writeColourPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.writeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.readPanel.SuspendLayout();
            this.writePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.readPanel);
            this.flowLayoutPanel1.Controls.Add(this.writePanel);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // readPanel
            // 
            resources.ApplyResources(this.readPanel, "readPanel");
            this.readPanel.Controls.Add(this.readColourPanel);
            this.readPanel.Controls.Add(this.readLabel);
            this.readPanel.Name = "readPanel";
            // 
            // readColourPanel
            // 
            resources.ApplyResources(this.readColourPanel, "readColourPanel");
            this.readColourPanel.BackColor = System.Drawing.Color.PaleGreen;
            this.readColourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.readColourPanel.Name = "readColourPanel";
            // 
            // readLabel
            // 
            resources.ApplyResources(this.readLabel, "readLabel");
            this.readLabel.Name = "readLabel";
            // 
            // writePanel
            // 
            resources.ApplyResources(this.writePanel, "writePanel");
            this.writePanel.Controls.Add(this.writeColourPanel);
            this.writePanel.Controls.Add(this.writeLabel);
            this.writePanel.Name = "writePanel";
            // 
            // writeColourPanel
            // 
            resources.ApplyResources(this.writeColourPanel, "writeColourPanel");
            this.writeColourPanel.BackColor = System.Drawing.Color.Plum;
            this.writeColourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.writeColourPanel.Name = "writeColourPanel";
            // 
            // writeLabel
            // 
            resources.ApplyResources(this.writeLabel, "writeLabel");
            this.writeLabel.Name = "writeLabel";
            // 
            // CustomFieldPhTagLegendControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CustomFieldPhTagLegendControl";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.readPanel.ResumeLayout(false);
            this.readPanel.PerformLayout();
            this.writePanel.ResumeLayout(false);
            this.writePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabel readLabel;
        private OltPanel readColourPanel;
        private OltPanel writeColourPanel;
        private OltLabel writeLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel readPanel;
        private System.Windows.Forms.Panel writePanel;
    }
}

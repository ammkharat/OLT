using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureLinkRootsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureLinkRootsForm));
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.siteDisplayLabel = new System.Windows.Forms.Label();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.newButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gridGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.siteGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // siteGroupBox
            // 
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteDisplayLabel);
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // siteDisplayLabel
            // 
            resources.ApplyResources(this.siteDisplayLabel, "siteDisplayLabel");
            this.siteDisplayLabel.Name = "siteDisplayLabel";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            resources.ApplyResources(this.newButton, "newButton");
            this.newButton.Name = "newButton";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // gridGroupBox
            // 
            resources.ApplyResources(this.gridGroupBox, "gridGroupBox");
            this.gridGroupBox.Name = "gridGroupBox";
            this.gridGroupBox.TabStop = false;
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Controls.Add(this.newButton);
            this.buttonPanel.Controls.Add(this.deleteButton);
            this.buttonPanel.Controls.Add(this.editButton);
            this.buttonPanel.Name = "buttonPanel";
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.Controls.Add(this.gridGroupBox);
            this.gridPanel.Name = "gridPanel";
            // 
            // ConfigureLinkRootsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.siteGroupBox);
            this.Name = "ConfigureLinkRootsForm";
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox siteGroupBox;
        private System.Windows.Forms.Label siteDisplayLabel;
        private OltButton closeButton;
        private OltButton deleteButton;
        private OltButton editButton;
        private OltButton newButton;
        private OltGroupBox gridGroupBox;
        private OltPanel buttonPanel;
        private OltPanel gridPanel;
    }
}
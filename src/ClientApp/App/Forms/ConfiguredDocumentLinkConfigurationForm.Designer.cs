using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfiguredDocumentLinkConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguredDocumentLinkConfigurationForm));
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.Name = "gridPanel";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // ConfiguredDocumentLinkConfigurationForm
            // 
            this.AcceptButton = this.editButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.gridPanel);
            this.Name = "ConfiguredDocumentLinkConfigurationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltPanel gridPanel;
        private OltLabel oltLabel1;
        private OltButton editButton;
        private OltButton closeButton;
    }
}
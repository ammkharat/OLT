using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitDropdownsConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitDropdownsConfigurationForm));
            this.gridPanel = new OltPanel();
            this.closeButton = new OltButton();
            this.editButton = new OltButton();
            this.contentsPanel = new OltPanel();
            this.contentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.Name = "gridPanel";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // contentsPanel
            // 
            resources.ApplyResources(this.contentsPanel, "contentsPanel");
            this.contentsPanel.Controls.Add(this.editButton);
            this.contentsPanel.Controls.Add(this.closeButton);
            this.contentsPanel.Controls.Add(this.gridPanel);
            this.contentsPanel.Name = "contentsPanel";
            // 
            // WorkPermitMontrealDropdownsConfigurationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.Controls.Add(this.contentsPanel);
            this.Name = "WorkPermitMontrealDropdownsConfigurationForm";
            this.contentsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton editButton;
        private OltButton closeButton;
        private OltPanel gridPanel;
        private OltPanel contentsPanel;
    }
}
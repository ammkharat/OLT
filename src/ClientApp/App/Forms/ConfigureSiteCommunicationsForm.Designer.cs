namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureSiteCommunicationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureSiteCommunicationsForm));
            this.buttonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.chkDeleteAll = new System.Windows.Forms.CheckBox();
            this.buttonsPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.chkDeleteAll);
            this.buttonsPanel.Controls.Add(this.closeButton);
            this.buttonsPanel.Controls.Add(this.deleteButton);
            this.buttonsPanel.Controls.Add(this.editButton);
            this.buttonsPanel.Controls.Add(this.addButton);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.gridPanel);
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.Name = "gridPanel";
            // 
            // chkDeleteAll     //ayman site communication
            // 
            resources.ApplyResources(this.chkDeleteAll, "chkDeleteAll");
            this.chkDeleteAll.Name = "chkDeleteAll";
            this.chkDeleteAll.UseVisualStyleBackColor = true;
            // 
            // ConfigureSiteCommunicationsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "ConfigureSiteCommunicationsForm";
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonsPanel;
        private OltControls.OltPanel mainPanel;
        private OltControls.OltButton closeButton;
        private OltControls.OltButton deleteButton;
        private OltControls.OltButton editButton;
        private OltControls.OltButton addButton;
        private OltControls.OltPanel gridPanel;
        private System.Windows.Forms.CheckBox chkDeleteAll;
    }
}
namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureAreaLabelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureAreaLabelsForm));
            this.buttonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.moveDownButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.moveUpButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonsPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Controls.Add(this.saveAndCloseButton);
            this.buttonsPanel.Controls.Add(this.deleteButton);
            this.buttonsPanel.Controls.Add(this.editButton);
            this.buttonsPanel.Controls.Add(this.addButton);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveAndCloseButton
            // 
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
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
            this.mainPanel.Controls.Add(this.moveDownButton);
            this.mainPanel.Controls.Add(this.moveUpButton);
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.Name = "gridPanel";
            // 
            // moveDownButton
            // 
            resources.ApplyResources(this.moveDownButton, "moveDownButton");
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.UseVisualStyleBackColor = true;
            // 
            // moveUpButton
            // 
            resources.ApplyResources(this.moveUpButton, "moveUpButton");
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.UseVisualStyleBackColor = true;
            // 
            // ConfigureAreaLabelsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "ConfigureAreaLabelsForm";
            this.buttonsPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonsPanel;
        private OltControls.OltPanel mainPanel;
        private OltControls.OltButton moveUpButton;
        private OltControls.OltButton moveDownButton;
        private OltControls.OltPanel gridPanel;
        private OltControls.OltButton addButton;
        private OltControls.OltButton editButton;
        private OltControls.OltButton deleteButton;
        private OltControls.OltButton saveAndCloseButton;
        private OltControls.OltButton cancelButton;
    }
}
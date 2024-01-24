namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureMudsWorkPermitGroupsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureWorkPermitGroupsForm));
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.moveUpButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.moveDownButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.Info;
            this.gridPanel.Name = "gridPanel";
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
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // moveUpButton
            // 
            resources.ApplyResources(this.moveUpButton, "moveUpButton");
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.UseVisualStyleBackColor = true;
            // 
            // moveDownButton
            // 
            resources.ApplyResources(this.moveDownButton, "moveDownButton");
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.UseVisualStyleBackColor = true;
            // 
            // ConfigureWorkPermitGroupsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.gridPanel);
            this.MaximizeBox = false;
            this.Name = "ConfigureWorkPermitGroupsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel gridPanel;
        private OltControls.OltButton deleteButton;
        private OltControls.OltButton editButton;
        private OltControls.OltButton addButton;
        private OltControls.OltButton cancelButton;
        private OltControls.OltButton saveButton;
        private OltControls.OltButton moveUpButton;
        private OltControls.OltButton moveDownButton;
    }
}
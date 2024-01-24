using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitMudsTemplateConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitMudsTemplateConfigurationForm));
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.categoryGridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.configurableCategoryGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.activeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.configurableCategoryGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
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
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // categoryGridPanel
            // 
            resources.ApplyResources(this.categoryGridPanel, "categoryGridPanel");
            this.categoryGridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.categoryGridPanel.Name = "categoryGridPanel";
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // configurableCategoryGroupBox
            // 
            resources.ApplyResources(this.configurableCategoryGroupBox, "configurableCategoryGroupBox");
            this.configurableCategoryGroupBox.Controls.Add(this.categoryGridPanel);
            this.configurableCategoryGroupBox.Controls.Add(this.buttonPanel);
            this.configurableCategoryGroupBox.Name = "configurableCategoryGroupBox";
            this.configurableCategoryGroupBox.TabStop = false;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.activeButton);
            this.buttonPanel.Controls.Add(this.addButton);
            this.buttonPanel.Controls.Add(this.deleteButton);
            this.buttonPanel.Controls.Add(this.editButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // activeButton
            // 
            resources.ApplyResources(this.activeButton, "activeButton");
            this.activeButton.Name = "activeButton";
            this.activeButton.UseVisualStyleBackColor = true;
            // 
            // WorkPermitMudsTemplateConfigurationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configurableCategoryGroupBox);
            this.Controls.Add(this.closeButton);
            this.Name = "WorkPermitMudsTemplateConfigurationForm";
            this.configurableCategoryGroupBox.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton addButton;
        private OltButton editButton;
        private OltButton closeButton;
        private OltPanel categoryGridPanel;
        private OltButton deleteButton;
        private OltGroupBox configurableCategoryGroupBox;
        private OltPanel buttonPanel;
        private OltButton activeButton;
    }
}
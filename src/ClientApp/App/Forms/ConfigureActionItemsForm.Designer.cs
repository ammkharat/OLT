using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureActionItemsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureActionItemsForm));
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.siteNameDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.autoApproveGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.sapMCCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.sapAMCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.workOrdersCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.logRequiredForResponseGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.logRequiredForActionItemResponseCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.requiresApprovalDefaultGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.requiresResponseDefaultCheckbox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.requiresApprovalDefaultCheckbox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoApproveGroupBox.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            this.logRequiredForResponseGroupBox.SuspendLayout();
            this.requiresApprovalDefaultGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // siteNameDataLabel
            // 
            resources.ApplyResources(this.siteNameDataLabel, "siteNameDataLabel");
            this.siteNameDataLabel.Name = "siteNameDataLabel";
            this.siteNameDataLabel.UseMnemonic = false;
            // 
            // autoApproveGroupBox
            // 
            resources.ApplyResources(this.autoApproveGroupBox, "autoApproveGroupBox");
            this.autoApproveGroupBox.Controls.Add(this.sapMCCheckBox);
            this.autoApproveGroupBox.Controls.Add(this.sapAMCheckBox);
            this.autoApproveGroupBox.Controls.Add(this.workOrdersCheckBox);
            this.autoApproveGroupBox.Name = "autoApproveGroupBox";
            this.autoApproveGroupBox.TabStop = false;
            // 
            // sapMCCheckBox
            // 
            resources.ApplyResources(this.sapMCCheckBox, "sapMCCheckBox");
            this.sapMCCheckBox.Name = "sapMCCheckBox";
            this.sapMCCheckBox.UseVisualStyleBackColor = true;
            this.sapMCCheckBox.Value = null;
            // 
            // sapAMCheckBox
            // 
            resources.ApplyResources(this.sapAMCheckBox, "sapAMCheckBox");
            this.sapAMCheckBox.Name = "sapAMCheckBox";
            this.sapAMCheckBox.UseVisualStyleBackColor = true;
            this.sapAMCheckBox.Value = null;
            // 
            // workOrdersCheckBox
            // 
            resources.ApplyResources(this.workOrdersCheckBox, "workOrdersCheckBox");
            this.workOrdersCheckBox.Name = "workOrdersCheckBox";
            this.workOrdersCheckBox.UseVisualStyleBackColor = true;
            this.workOrdersCheckBox.Value = null;
            // 
            // siteGroupBox
            // 
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteNameDataLabel);
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // logRequiredForResponseGroupBox
            // 
            resources.ApplyResources(this.logRequiredForResponseGroupBox, "logRequiredForResponseGroupBox");
            this.logRequiredForResponseGroupBox.Controls.Add(this.logRequiredForActionItemResponseCheckBox);
            this.logRequiredForResponseGroupBox.Name = "logRequiredForResponseGroupBox";
            this.logRequiredForResponseGroupBox.TabStop = false;
            // 
            // logRequiredForActionItemResponseCheckBox
            // 
            resources.ApplyResources(this.logRequiredForActionItemResponseCheckBox, "logRequiredForActionItemResponseCheckBox");
            this.logRequiredForActionItemResponseCheckBox.Name = "logRequiredForActionItemResponseCheckBox";
            this.logRequiredForActionItemResponseCheckBox.UseVisualStyleBackColor = true;
            this.logRequiredForActionItemResponseCheckBox.Value = null;
            // 
            // requiresApprovalDefaultGroupBox
            // 
            resources.ApplyResources(this.requiresApprovalDefaultGroupBox, "requiresApprovalDefaultGroupBox");
            this.requiresApprovalDefaultGroupBox.Controls.Add(this.requiresResponseDefaultCheckbox);
            this.requiresApprovalDefaultGroupBox.Controls.Add(this.requiresApprovalDefaultCheckbox);
            this.requiresApprovalDefaultGroupBox.Name = "requiresApprovalDefaultGroupBox";
            this.requiresApprovalDefaultGroupBox.TabStop = false;
            // 
            // requiresResponseDefaultCheckbox
            // 
            resources.ApplyResources(this.requiresResponseDefaultCheckbox, "requiresResponseDefaultCheckbox");
            this.requiresResponseDefaultCheckbox.Name = "requiresResponseDefaultCheckbox";
            this.requiresResponseDefaultCheckbox.UseVisualStyleBackColor = true;
            this.requiresResponseDefaultCheckbox.Value = null;
            // 
            // requiresApprovalDefaultCheckbox
            // 
            resources.ApplyResources(this.requiresApprovalDefaultCheckbox, "requiresApprovalDefaultCheckbox");
            this.requiresApprovalDefaultCheckbox.Name = "requiresApprovalDefaultCheckbox";
            this.requiresApprovalDefaultCheckbox.UseVisualStyleBackColor = true;
            this.requiresApprovalDefaultCheckbox.Value = null;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Name = "panel1";
            // 
            // ConfigureActionItemsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.requiresApprovalDefaultGroupBox);
            this.Controls.Add(this.logRequiredForResponseGroupBox);
            this.Controls.Add(this.siteGroupBox);
            this.Controls.Add(this.autoApproveGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigureActionItemsForm";
            this.autoApproveGroupBox.ResumeLayout(false);
            this.autoApproveGroupBox.PerformLayout();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.logRequiredForResponseGroupBox.ResumeLayout(false);
            this.logRequiredForResponseGroupBox.PerformLayout();
            this.requiresApprovalDefaultGroupBox.ResumeLayout(false);
            this.requiresApprovalDefaultGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton saveButton;
        private OltButton cancelButton;
        private OltLabelData siteNameDataLabel;
        private OltGroupBox autoApproveGroupBox;
        private OltCheckBox sapMCCheckBox;
        private OltCheckBox sapAMCheckBox;
        private OltCheckBox workOrdersCheckBox;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private OltGroupBox logRequiredForResponseGroupBox;
        private OltCheckBox logRequiredForActionItemResponseCheckBox;
        private OltGroupBox requiresApprovalDefaultGroupBox;
        private OltCheckBox requiresApprovalDefaultCheckbox;
        private OltCheckBox requiresResponseDefaultCheckbox;
        private System.Windows.Forms.Panel panel1;
    }
}
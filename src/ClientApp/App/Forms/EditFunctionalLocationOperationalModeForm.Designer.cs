using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class EditFunctionalLocationOperationalModeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFunctionalLocationOperationalModeForm));
            this.unitLevelFlocDisplayLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.operationalModeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.availabilityReasonLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.operationalModeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.availabilityReasonComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.unitLevelFLOCGroupBox = new System.Windows.Forms.GroupBox();
            this.opModeSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.unitLevelFLOCGroupBox.SuspendLayout();
            this.opModeSettingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // unitLevelFlocDisplayLabel
            // 
            resources.ApplyResources(this.unitLevelFlocDisplayLabel, "unitLevelFlocDisplayLabel");
            this.unitLevelFlocDisplayLabel.Name = "unitLevelFlocDisplayLabel";
            // 
            // operationalModeLabel
            // 
            resources.ApplyResources(this.operationalModeLabel, "operationalModeLabel");
            this.operationalModeLabel.Name = "operationalModeLabel";
            // 
            // availabilityReasonLabel
            // 
            resources.ApplyResources(this.availabilityReasonLabel, "availabilityReasonLabel");
            this.availabilityReasonLabel.Name = "availabilityReasonLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // operationalModeComboBox
            // 
            resources.ApplyResources(this.operationalModeComboBox, "operationalModeComboBox");
            this.operationalModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationalModeComboBox.FormattingEnabled = true;
            this.operationalModeComboBox.Name = "operationalModeComboBox";
            // 
            // availabilityReasonComboBox
            // 
            resources.ApplyResources(this.availabilityReasonComboBox, "availabilityReasonComboBox");
            this.availabilityReasonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.availabilityReasonComboBox.FormattingEnabled = true;
            this.availabilityReasonComboBox.Name = "availabilityReasonComboBox";
            // 
            // unitLevelFLOCGroupBox
            // 
            resources.ApplyResources(this.unitLevelFLOCGroupBox, "unitLevelFLOCGroupBox");
            this.unitLevelFLOCGroupBox.Controls.Add(this.unitLevelFlocDisplayLabel);
            this.unitLevelFLOCGroupBox.Name = "unitLevelFLOCGroupBox";
            this.unitLevelFLOCGroupBox.TabStop = false;
            // 
            // opModeSettingGroupBox
            // 
            resources.ApplyResources(this.opModeSettingGroupBox, "opModeSettingGroupBox");
            this.opModeSettingGroupBox.Controls.Add(this.operationalModeLabel);
            this.opModeSettingGroupBox.Controls.Add(this.operationalModeComboBox);
            this.opModeSettingGroupBox.Controls.Add(this.availabilityReasonComboBox);
            this.opModeSettingGroupBox.Controls.Add(this.availabilityReasonLabel);
            this.opModeSettingGroupBox.Name = "opModeSettingGroupBox";
            this.opModeSettingGroupBox.TabStop = false;
            // 
            // EditFunctionalLocationOperationalModeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opModeSettingGroupBox);
            this.Controls.Add(this.unitLevelFLOCGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditFunctionalLocationOperationalModeForm";
            this.Load += new System.EventHandler(this.LoadForm);
            this.unitLevelFLOCGroupBox.ResumeLayout(false);
            this.unitLevelFLOCGroupBox.PerformLayout();
            this.opModeSettingGroupBox.ResumeLayout(false);
            this.opModeSettingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabel unitLevelFlocDisplayLabel;
        private OltLabel operationalModeLabel;
        private OltLabel availabilityReasonLabel;
        private OltButton okButton;
        private OltButton cancelButton;
        private OltComboBox operationalModeComboBox;
        private OltComboBox availabilityReasonComboBox;
        private System.Windows.Forms.GroupBox unitLevelFLOCGroupBox;
        private System.Windows.Forms.GroupBox opModeSettingGroupBox;
    }
}
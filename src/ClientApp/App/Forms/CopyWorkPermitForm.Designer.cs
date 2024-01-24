using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class CopyWorkPermitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyWorkPermitForm));
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.acceptButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.workPermitSectionPicker = new Com.Suncor.Olt.Client.Controls.WorkPermitSectionPicker();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.titleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelTitle();
            this.oltPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            resources.ApplyResources(this.acceptButton, "acceptButton");
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // workPermitSectionPicker
            // 
            this.workPermitSectionPicker.AdditionalFormsChecked = false;
            this.workPermitSectionPicker.AsbestosChecked = false;
            resources.ApplyResources(this.workPermitSectionPicker, "workPermitSectionPicker");
            this.workPermitSectionPicker.CommunicationMethodChecked = false;
            this.workPermitSectionPicker.EquipmentPreparationConditionChecked = false;
            this.workPermitSectionPicker.ExtraCloneSectionsEnabled = false;
            this.workPermitSectionPicker.FireConfinedSpaceProtectionRequirementsChecked = false;
            this.workPermitSectionPicker.GasTestInformationChecked = false;
            this.workPermitSectionPicker.JobWorksitePreparationChecked = false;
            this.workPermitSectionPicker.LocationJobSpecificsChecked = false;
            this.workPermitSectionPicker.MiscellaneousChecked = false;
            this.workPermitSectionPicker.Name = "workPermitSectionPicker";
            this.workPermitSectionPicker.NotificationsAuthorizationsChecked = false;
            this.workPermitSectionPicker.PermitTypeAttributesChecked = false;
            this.workPermitSectionPicker.RadiationInformationChecked = false;
            this.workPermitSectionPicker.RespiratoryProtectionRequirementsChecked = false;
            this.workPermitSectionPicker.ShowAsbestos = true;
            this.workPermitSectionPicker.ShowCommunicationMethod = true;
            this.workPermitSectionPicker.ShowRadiation = true;
            this.workPermitSectionPicker.ShowTools = true;
            this.workPermitSectionPicker.SpecialPpeRequirementsChecked = false;
            this.workPermitSectionPicker.SpecialPrecautionsConsiderationsChecked = false;
            this.workPermitSectionPicker.ToolsChecked = false;
            this.workPermitSectionPicker.SelectAllSections += new System.EventHandler(this.workPermitSectionPicker_SelectAllSections);
            this.workPermitSectionPicker.DeselectAllSections += new System.EventHandler(this.workPermitSectionPicker_DeselectAllSections);
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.cancelButton);
            this.oltPanel1.Controls.Add(this.acceptButton);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Name = "oltPanel1";
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Name = "titleLabel";
            // 
            // CopyWorkPermitForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.workPermitSectionPicker);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.oltPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CopyWorkPermitForm";
            this.Load += new System.EventHandler(this.CopyWorkPermitForm_Load);
            this.oltPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton cancelButton;
        private OltButton acceptButton;
        private Com.Suncor.Olt.Client.Controls.WorkPermitSectionPicker workPermitSectionPicker;
        private OltPanel oltPanel1;
        private OltLabelTitle titleLabel;
    }
}
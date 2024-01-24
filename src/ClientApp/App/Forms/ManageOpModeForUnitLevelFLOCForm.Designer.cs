using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ManageOpModeForUnitLevelFLOCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageOpModeForUnitLevelFLOCForm));
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.siteDisplayLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.unitLevelFlocGroupBox = new System.Windows.Forms.GroupBox();
            this.siteGroupBox.SuspendLayout();
            this.unitLevelFlocGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.Name = "gridPanel";
            // 
            // siteDisplayLabel
            // 
            resources.ApplyResources(this.siteDisplayLabel, "siteDisplayLabel");
            this.siteDisplayLabel.Name = "siteDisplayLabel";
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
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
            // siteGroupBox
            // 
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteDisplayLabel);
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // unitLevelFlocGroupBox
            // 
            resources.ApplyResources(this.unitLevelFlocGroupBox, "unitLevelFlocGroupBox");
            this.unitLevelFlocGroupBox.Controls.Add(this.gridPanel);
            this.unitLevelFlocGroupBox.Name = "unitLevelFlocGroupBox";
            this.unitLevelFlocGroupBox.TabStop = false;
            // 
            // ManageOpModeForUnitLevelFLOCForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unitLevelFlocGroupBox);
            this.Controls.Add(this.siteGroupBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageOpModeForUnitLevelFLOCForm";
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.unitLevelFlocGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltPanel gridPanel;
        private OltLabel siteDisplayLabel;
        private OltButton editButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private System.Windows.Forms.GroupBox unitLevelFlocGroupBox;
    }
}
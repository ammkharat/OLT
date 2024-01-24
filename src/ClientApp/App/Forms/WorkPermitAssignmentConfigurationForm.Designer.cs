using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitAssignmentConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitAssignmentConfigurationForm));
            this.splitContainer = new Com.Suncor.Olt.Client.OltControls.OltSplitContainer();
            this.workAssignmentAreaGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.panel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.copyLoginFlocsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.clearButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.siteGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.siteDisplayLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flocSelectionGroupBox.SuspendLayout();
            this.panel.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.Controls.Add(this.workAssignmentAreaGroupBox);
            // 
            // splitContainer.Panel2
            // 
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.Controls.Add(this.flocSelectionGroupBox);
            // 
            // workAssignmentAreaGroupBox
            // 
            resources.ApplyResources(this.workAssignmentAreaGroupBox, "workAssignmentAreaGroupBox");
            this.workAssignmentAreaGroupBox.Name = "workAssignmentAreaGroupBox";
            this.workAssignmentAreaGroupBox.TabStop = false;
            // 
            // flocSelectionGroupBox
            // 
            resources.ApplyResources(this.flocSelectionGroupBox, "flocSelectionGroupBox");
            this.flocSelectionGroupBox.Controls.Add(this.flocSelectionControl);
            this.flocSelectionGroupBox.Controls.Add(this.panel);
            this.flocSelectionGroupBox.Name = "flocSelectionGroupBox";
            this.flocSelectionGroupBox.TabStop = false;
            // 
            // flocSelectionControl
            // 
            resources.ApplyResources(this.flocSelectionControl, "flocSelectionControl");
            this.flocSelectionControl.Name = "flocSelectionControl";
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.Controls.Add(this.copyLoginFlocsButton);
            this.panel.Controls.Add(this.clearButton);
            this.panel.Name = "panel";
            // 
            // copyLoginFlocsButton
            // 
            resources.ApplyResources(this.copyLoginFlocsButton, "copyLoginFlocsButton");
            this.copyLoginFlocsButton.Name = "copyLoginFlocsButton";
            this.copyLoginFlocsButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
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
            // siteGroupBox
            // 
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteDisplayLabel);
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // siteDisplayLabel
            // 
            resources.ApplyResources(this.siteDisplayLabel, "siteDisplayLabel");
            this.siteDisplayLabel.Name = "siteDisplayLabel";
            // 
            // WorkPermitAssignmentConfigurationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.siteGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.Name = "WorkPermitAssignmentConfigurationForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.flocSelectionGroupBox.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox workAssignmentAreaGroupBox;
        private OltGroupBox flocSelectionGroupBox;
        private Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltButton clearButton;
        private OltButton saveButton;
        private OltButton cancelButton;
        private OltGroupBox siteGroupBox;
        private OltLabel siteDisplayLabel;
        private OltSplitContainer splitContainer;
        private OltPanel panel;
        private OltButton copyLoginFlocsButton;
    }
}
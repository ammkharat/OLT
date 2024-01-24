using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitCloseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitCloseForm));
            this.lastModifiedData = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.shiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.detailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.commentTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.commentsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createLogCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.descriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.makeLogAnOperatingEngineerCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.shiftGroupBox.SuspendLayout();
            this.commentsGroupBox.SuspendLayout();
            this.descriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lastModifiedData
            // 
            resources.ApplyResources(this.lastModifiedData, "lastModifiedData");
            this.lastModifiedData.LastModifiedDate = new System.DateTime(((long)(0)));
            this.lastModifiedData.Name = "lastModifiedData";
            this.lastModifiedData.TabStop = false;
            // 
            // shiftGroupBox
            // 
            resources.ApplyResources(this.shiftGroupBox, "shiftGroupBox");
            this.shiftGroupBox.Controls.Add(this.shiftLabel);
            this.shiftGroupBox.Name = "shiftGroupBox";
            this.shiftGroupBox.TabStop = false;
            // 
            // shiftLabel
            // 
            resources.ApplyResources(this.shiftLabel, "shiftLabel");
            this.shiftLabel.Name = "shiftLabel";
            // 
            // detailsLabelLine
            // 
            resources.ApplyResources(this.detailsLabelLine, "detailsLabelLine");
            this.detailsLabelLine.Name = "detailsLabelLine";
            this.detailsLabelLine.TabStop = false;
            // 
            // commentTextBox
            // 
            resources.ApplyResources(this.commentTextBox, "commentTextBox");
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.OltAcceptsReturn = true;
            this.commentTextBox.OltTrimWhitespace = true;
            // 
            // commentsGroupBox
            // 
            resources.ApplyResources(this.commentsGroupBox, "commentsGroupBox");
            this.commentsGroupBox.Controls.Add(this.commentTextBox);
            this.commentsGroupBox.Name = "commentsGroupBox";
            this.commentsGroupBox.TabStop = false;
            // 
            // createLogCheckBox
            // 
            resources.ApplyResources(this.createLogCheckBox, "createLogCheckBox");
            this.createLogCheckBox.Checked = true;
            this.createLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createLogCheckBox.Name = "createLogCheckBox";
            this.createLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltAcceptsReturn = true;
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.ReadOnly = true;
            // 
            // descriptionGroupBox
            // 
            resources.ApplyResources(this.descriptionGroupBox, "descriptionGroupBox");
            this.descriptionGroupBox.Controls.Add(this.descriptionTextBox);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.TabStop = false;
            // 
            // makeLogAnOperatingEngineerCheckBox
            // 
            resources.ApplyResources(this.makeLogAnOperatingEngineerCheckBox, "makeLogAnOperatingEngineerCheckBox");
            this.makeLogAnOperatingEngineerCheckBox.Name = "makeLogAnOperatingEngineerCheckBox";
            this.makeLogAnOperatingEngineerCheckBox.UseVisualStyleBackColor = true;
            this.makeLogAnOperatingEngineerCheckBox.Value = null;
            // 
            // WorkPermitCloseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.makeLogAnOperatingEngineerCheckBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.createLogCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.commentsGroupBox);
            this.Controls.Add(this.detailsLabelLine);
            this.Controls.Add(this.shiftGroupBox);
            this.Controls.Add(this.lastModifiedData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WorkPermitCloseForm";
            this.shiftGroupBox.ResumeLayout(false);
            this.shiftGroupBox.PerformLayout();
            this.commentsGroupBox.ResumeLayout(false);
            this.commentsGroupBox.PerformLayout();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLastModifiedDateAuthorHeader lastModifiedData;
        private OltGroupBox shiftGroupBox;
        private OltLabel shiftLabel;
        private OltLabelLine detailsLabelLine;
        private OltTextBox commentTextBox;
        private OltGroupBox commentsGroupBox;
        private System.Windows.Forms.CheckBox createLogCheckBox;
        private OltButton cancelButton;
        private OltButton submitButton;
        private OltTextBox descriptionTextBox;
        private OltGroupBox descriptionGroupBox;
        private OltCheckBox makeLogAnOperatingEngineerCheckBox;
    }
}

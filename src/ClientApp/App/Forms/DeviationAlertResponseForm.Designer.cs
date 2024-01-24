using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class DeviationAlertResponseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviationAlertResponseForm));
            this.gridPanel = new System.Windows.Forms.Panel();
            this.tagValuesGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.measuredTagLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.measuredTagData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.targetTagLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.targetTagData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.targetTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.measuredTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.summaryAmountToBeAssignedLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.summaryTotalAssignedLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.summaryDeviationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.summaryTotalAssignedTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.summaryAmountRemainingToBeAssignedTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.summaryDeviationTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.newButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.copyLastResponseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.commentsTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.endDateData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.startDateData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.endDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.periodGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.engineerCommentsLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.tagValuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.periodGroupBox.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.Name = "gridPanel";
            // 
            // tagValuesGroupBox
            // 
            resources.ApplyResources(this.tagValuesGroupBox, "tagValuesGroupBox");
            this.tagValuesGroupBox.Controls.Add(this.measuredTagLabel);
            this.tagValuesGroupBox.Controls.Add(this.measuredTagData);
            this.tagValuesGroupBox.Controls.Add(this.targetTagLabel);
            this.tagValuesGroupBox.Controls.Add(this.targetTagData);
            this.tagValuesGroupBox.Controls.Add(this.targetTextBox);
            this.tagValuesGroupBox.Controls.Add(this.measuredTextBox);
            this.tagValuesGroupBox.Name = "tagValuesGroupBox";
            this.tagValuesGroupBox.TabStop = false;
            // 
            // measuredTagLabel
            // 
            resources.ApplyResources(this.measuredTagLabel, "measuredTagLabel");
            this.measuredTagLabel.Name = "measuredTagLabel";
            // 
            // measuredTagData
            // 
            resources.ApplyResources(this.measuredTagData, "measuredTagData");
            this.measuredTagData.Name = "measuredTagData";
            this.measuredTagData.UseMnemonic = false;
            // 
            // targetTagLabel
            // 
            resources.ApplyResources(this.targetTagLabel, "targetTagLabel");
            this.targetTagLabel.Name = "targetTagLabel";
            // 
            // targetTagData
            // 
            resources.ApplyResources(this.targetTagData, "targetTagData");
            this.targetTagData.Name = "targetTagData";
            this.targetTagData.UseMnemonic = false;
            // 
            // targetTextBox
            // 
            this.targetTextBox.DecimalValue = null;
            this.targetTextBox.IntegerValue = null;
            resources.ApplyResources(this.targetTextBox, "targetTextBox");
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.NumericValue = null;
            this.targetTextBox.ReadOnly = true;
            this.targetTextBox.TabStop = false;
            // 
            // measuredTextBox
            // 
            this.measuredTextBox.DecimalValue = null;
            this.measuredTextBox.IntegerValue = null;
            resources.ApplyResources(this.measuredTextBox, "measuredTextBox");
            this.measuredTextBox.Name = "measuredTextBox";
            this.measuredTextBox.NumericValue = null;
            this.measuredTextBox.ReadOnly = true;
            this.measuredTextBox.TabStop = false;
            // 
            // summaryAmountToBeAssignedLabel
            // 
            resources.ApplyResources(this.summaryAmountToBeAssignedLabel, "summaryAmountToBeAssignedLabel");
            this.summaryAmountToBeAssignedLabel.Name = "summaryAmountToBeAssignedLabel";
            // 
            // summaryTotalAssignedLabel
            // 
            resources.ApplyResources(this.summaryTotalAssignedLabel, "summaryTotalAssignedLabel");
            this.summaryTotalAssignedLabel.Name = "summaryTotalAssignedLabel";
            // 
            // summaryDeviationLabel
            // 
            resources.ApplyResources(this.summaryDeviationLabel, "summaryDeviationLabel");
            this.summaryDeviationLabel.Name = "summaryDeviationLabel";
            // 
            // summaryTotalAssignedTextBox
            // 
            resources.ApplyResources(this.summaryTotalAssignedTextBox, "summaryTotalAssignedTextBox");
            this.summaryTotalAssignedTextBox.DecimalValue = null;
            this.summaryTotalAssignedTextBox.IntegerValue = null;
            this.summaryTotalAssignedTextBox.Name = "summaryTotalAssignedTextBox";
            this.summaryTotalAssignedTextBox.NumericValue = null;
            this.summaryTotalAssignedTextBox.ReadOnly = true;
            this.summaryTotalAssignedTextBox.TabStop = false;
            // 
            // summaryAmountRemainingToBeAssignedTextBox
            // 
            resources.ApplyResources(this.summaryAmountRemainingToBeAssignedTextBox, "summaryAmountRemainingToBeAssignedTextBox");
            this.summaryAmountRemainingToBeAssignedTextBox.DecimalValue = null;
            this.summaryAmountRemainingToBeAssignedTextBox.IntegerValue = null;
            this.summaryAmountRemainingToBeAssignedTextBox.Name = "summaryAmountRemainingToBeAssignedTextBox";
            this.summaryAmountRemainingToBeAssignedTextBox.NumericValue = null;
            this.summaryAmountRemainingToBeAssignedTextBox.ReadOnly = true;
            this.summaryAmountRemainingToBeAssignedTextBox.TabStop = false;
            // 
            // summaryDeviationTextBox
            // 
            resources.ApplyResources(this.summaryDeviationTextBox, "summaryDeviationTextBox");
            this.summaryDeviationTextBox.DecimalValue = null;
            this.summaryDeviationTextBox.IntegerValue = null;
            this.summaryDeviationTextBox.Name = "summaryDeviationTextBox";
            this.summaryDeviationTextBox.NumericValue = null;
            this.summaryDeviationTextBox.ReadOnly = true;
            this.summaryDeviationTextBox.TabStop = false;
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
            // newButton
            // 
            resources.ApplyResources(this.newButton, "newButton");
            this.newButton.Name = "newButton";
            this.newButton.UseVisualStyleBackColor = true;
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // copyLastResponseButton
            // 
            resources.ApplyResources(this.copyLastResponseButton, "copyLastResponseButton");
            this.copyLastResponseButton.Name = "copyLastResponseButton";
            this.copyLastResponseButton.UseVisualStyleBackColor = true;
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.AcceptsReturn = true;
            this.commentsTextBox.AcceptsTab = true;
            resources.ApplyResources(this.commentsTextBox, "commentsTextBox");
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.OltAcceptsReturn = true;
            this.commentsTextBox.OltTrimWhitespace = true;
            // 
            // endDateData
            // 
            resources.ApplyResources(this.endDateData, "endDateData");
            this.endDateData.Name = "endDateData";
            this.endDateData.UseMnemonic = false;
            // 
            // startDateData
            // 
            resources.ApplyResources(this.startDateData, "startDateData");
            this.startDateData.Name = "startDateData";
            this.startDateData.UseMnemonic = false;
            // 
            // endDateLabel
            // 
            resources.ApplyResources(this.endDateLabel, "endDateLabel");
            this.endDateLabel.Name = "endDateLabel";
            // 
            // startDateLabel
            // 
            resources.ApplyResources(this.startDateLabel, "startDateLabel");
            this.startDateLabel.Name = "startDateLabel";
            // 
            // periodGroupBox
            // 
            this.periodGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.periodGroupBox.Controls.Add(this.startDateData);
            this.periodGroupBox.Controls.Add(this.startDateLabel);
            this.periodGroupBox.Controls.Add(this.endDateLabel);
            this.periodGroupBox.Controls.Add(this.endDateData);
            resources.ApplyResources(this.periodGroupBox, "periodGroupBox");
            this.periodGroupBox.Name = "periodGroupBox";
            this.periodGroupBox.TabStop = false;
            // 
            // engineerCommentsLabel
            // 
            resources.ApplyResources(this.engineerCommentsLabel, "engineerCommentsLabel");
            this.engineerCommentsLabel.Name = "engineerCommentsLabel";
            // 
            // oltGroupBox1
            // 
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Controls.Add(this.gridPanel);
            this.oltGroupBox1.Controls.Add(this.copyLastResponseButton);
            this.oltGroupBox1.Controls.Add(this.deleteButton);
            this.oltGroupBox1.Controls.Add(this.newButton);
            this.oltGroupBox1.Controls.Add(this.editButton);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // DeviationAlertResponseForm
            // 
            this.AcceptButton = this.saveAndCloseButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.oltGroupBox1);
            this.Controls.Add(this.engineerCommentsLabel);
            this.Controls.Add(this.tagValuesGroupBox);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.periodGroupBox);
            this.Controls.Add(this.summaryAmountToBeAssignedLabel);
            this.Controls.Add(this.summaryTotalAssignedLabel);
            this.Controls.Add(this.summaryDeviationLabel);
            this.Controls.Add(this.summaryTotalAssignedTextBox);
            this.Controls.Add(this.summaryAmountRemainingToBeAssignedTextBox);
            this.Controls.Add(this.summaryDeviationTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.MaximizeBox = false;
            this.Name = "DeviationAlertResponseForm";
            this.tagValuesGroupBox.ResumeLayout(false);
            this.tagValuesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.periodGroupBox.ResumeLayout(false);
            this.periodGroupBox.PerformLayout();
            this.oltGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton cancelButton;
        private OltNumericBox targetTextBox;
        private OltNumericBox measuredTextBox;
        private System.Windows.Forms.Panel gridPanel;
        private OltButton newButton;
        private OltButton editButton;
        private OltButton deleteButton;
        private OltNumericBox summaryDeviationTextBox;
        private OltNumericBox summaryAmountRemainingToBeAssignedTextBox;
        private OltNumericBox summaryTotalAssignedTextBox;
        private OltLabel summaryDeviationLabel;
        private OltLabel summaryTotalAssignedLabel;
        private OltLabel summaryAmountToBeAssignedLabel;
        private OltButton saveAndCloseButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltButton copyLastResponseButton;
        private OltTextBox commentsTextBox;
        private OltLabel measuredTagLabel;
        private OltLabelData targetTagData;
        private OltLabel targetTagLabel;
        private OltLabelData endDateData;
        private OltLabelData startDateData;
        private OltLabel endDateLabel;
        private OltLabel startDateLabel;
        private OltGroupBox periodGroupBox;
        private OltGroupBox tagValuesGroupBox;
        private OltLabelData measuredTagData;
        private OltLabel engineerCommentsLabel;
        private OltGroupBox oltGroupBox1;
    }
}
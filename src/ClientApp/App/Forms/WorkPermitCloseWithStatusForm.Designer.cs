using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitCloseWithStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitCloseWithStatusForm));
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.buttonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.validToTimePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.validToDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.actionItemCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.cmtTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.dtClose = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabelLine2 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.oltLabelLine3 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.closeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.closeStatusComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.detailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.commentsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.commentTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lastModifiedData = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.shiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.closeGroupBox.SuspendLayout();
            this.commentsGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.shiftGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.buttonsPanel);
            this.mainPanel.Controls.Add(this.tableLayoutPanel2);
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Name = "mainPanel";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.validToTimePicker);
            this.buttonsPanel.Controls.Add(this.validToDatePicker);
            this.buttonsPanel.Controls.Add(this.actionItemCheckBox);
            this.buttonsPanel.Controls.Add(this.cmtTextBox);
            this.buttonsPanel.Controls.Add(this.dtClose);
            this.buttonsPanel.Controls.Add(this.oltLabelLine2);
            this.buttonsPanel.Controls.Add(this.oltLabelLine3);
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Controls.Add(this.submitButton);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // validToTimePicker
            // 
            this.validToTimePicker.Checked = true;
            this.validToTimePicker.CustomFormat = "HH:mm";
            resources.ApplyResources(this.validToTimePicker, "validToTimePicker");
            this.validToTimePicker.Name = "validToTimePicker";
            this.validToTimePicker.ShowCheckBox = false;
            // 
            // validToDatePicker
            // 
            this.validToDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.validToDatePicker, "validToDatePicker");
            this.validToDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.validToDatePicker.Name = "validToDatePicker";
            this.validToDatePicker.PickerEnabled = true;
            // 
            // actionItemCheckBox
            // 
            resources.ApplyResources(this.actionItemCheckBox, "actionItemCheckBox");
            this.actionItemCheckBox.Checked = true;
            this.actionItemCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.actionItemCheckBox.Name = "actionItemCheckBox";
            this.actionItemCheckBox.UseVisualStyleBackColor = true;
            this.actionItemCheckBox.Value = null;
            // 
            // cmtTextBox
            // 
            this.cmtTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.cmtTextBox, "cmtTextBox");
            this.cmtTextBox.Name = "cmtTextBox";
            this.cmtTextBox.OltAcceptsReturn = true;
            this.cmtTextBox.OltTrimWhitespace = true;
            // 
            // dtClose
            // 
            resources.ApplyResources(this.dtClose, "dtClose");
            this.dtClose.Name = "dtClose";
            // 
            // oltLabelLine2
            // 
            resources.ApplyResources(this.oltLabelLine2, "oltLabelLine2");
            this.oltLabelLine2.Name = "oltLabelLine2";
            this.oltLabelLine2.TabStop = false;
            // 
            // oltLabelLine3
            // 
            resources.ApplyResources(this.oltLabelLine3, "oltLabelLine3");
            this.oltLabelLine3.Name = "oltLabelLine3";
            this.oltLabelLine3.TabStop = false;
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
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.closeGroupBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.detailsLabelLine, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.commentsGroupBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.descriptionTextBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.oltLabelLine1, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // closeGroupBox
            // 
            this.closeGroupBox.Controls.Add(this.closeStatusComboBox);
            resources.ApplyResources(this.closeGroupBox, "closeGroupBox");
            this.closeGroupBox.Name = "closeGroupBox";
            this.closeGroupBox.TabStop = false;
            // 
            // closeStatusComboBox
            // 
            this.closeStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.closeStatusComboBox.FormattingEnabled = true;
            this.closeStatusComboBox.Items.AddRange(new object[] {
            resources.GetString("closeStatusComboBox.Items")});
            resources.ApplyResources(this.closeStatusComboBox, "closeStatusComboBox");
            this.closeStatusComboBox.Name = "closeStatusComboBox";
            // 
            // detailsLabelLine
            // 
            resources.ApplyResources(this.detailsLabelLine, "detailsLabelLine");
            this.detailsLabelLine.Name = "detailsLabelLine";
            this.detailsLabelLine.TabStop = false;
            // 
            // commentsGroupBox
            // 
            resources.ApplyResources(this.commentsGroupBox, "commentsGroupBox");
            this.commentsGroupBox.Controls.Add(this.commentTextBox);
            this.commentsGroupBox.Name = "commentsGroupBox";
            this.commentsGroupBox.TabStop = false;
            // 
            // commentTextBox
            // 
            resources.ApplyResources(this.commentTextBox, "commentTextBox");
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.OltAcceptsReturn = true;
            this.commentTextBox.OltTrimWhitespace = true;
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltAcceptsReturn = true;
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.ReadOnly = true;
            // 
            // oltLabelLine1
            // 
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lastModifiedData, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.shiftGroupBox, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // WorkPermitCloseWithStatusForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "WorkPermitCloseWithStatusForm";
            this.mainPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.closeGroupBox.ResumeLayout(false);
            this.commentsGroupBox.ResumeLayout(false);
            this.commentsGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.shiftGroupBox.ResumeLayout(false);
            this.shiftGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private OltButton submitButton;
        private OltLabel shiftLabel;
        private OltGroupBox commentsGroupBox;
        private OltTextBox commentTextBox;
        private OltGroupBox shiftGroupBox;
        private OltLastModifiedDateAuthorHeader lastModifiedData;
        private OltLabelLine detailsLabelLine;
        private OltLabelLine oltLabelLine1;
        private OltGroupBox closeGroupBox;
        private OltComboBox closeStatusComboBox;
        private OltTextBox descriptionTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltPanel buttonsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OltPanel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private OltTextBox cmtTextBox;
        private OltTimePicker validToTimePicker;
        private OltDatePicker validToDatePicker;
        private OltLabel dtClose;
        private OltLabelLine oltLabelLine3;
        private OltCheckBox actionItemCheckBox;
        private OltLabelLine oltLabelLine2;
    }
}
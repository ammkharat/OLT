using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class LogDefinitionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogDefinitionForm));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewEditHistoryButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.scrollingPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.tableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.flocsAndOptionsTableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.optionsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.IsOperatingEngineerLogCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.isInactiveCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocAndButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.flocButtonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.functionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeFLOCButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.commentsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.detailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.logDateTimeCreateUserAndShiftPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.lastModifiedDateAuthorHeader = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.advancedDetailsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.advancedDetailsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.followupGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.operationsFollowUpCheckbox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.supervisorFollowUpCheckbox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.processControlFollowUpCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.eHSFollowUpCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.inspectionFollowUpCheckbox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.otherFollowUpCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.linkGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.logDocumentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.multipleFunctionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createOneLogRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.createLogForEachFlocRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.customFieldsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.customFieldsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.customFieldControl = new Com.Suncor.Olt.Client.Controls.CustomFieldTableLayoutPanel();
            this.templateAndCommentsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logCommentControl = new Com.Suncor.Olt.Client.Controls.LogCommentControl();
            this.templatePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.insertTemplateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.templateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.logTemplateComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.schedulePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.schedulePicker = new Com.Suncor.Olt.Client.Controls.SchedulePicker();
            this.repeatingScheduleLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.additionalDetailsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.additionalDetailsToggleButton = new Com.Suncor.Olt.Client.OltControls.OltToggleButton();
            this.additionalDetailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel.SuspendLayout();
            this.scrollingPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.flocsAndOptionsTableLayoutPanel.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.flocAndButtonsTableLayoutPanel.SuspendLayout();
            this.flocButtonsPanel.SuspendLayout();
            this.logDateTimeCreateUserAndShiftPanel.SuspendLayout();
            this.advancedDetailsPanel.SuspendLayout();
            this.advancedDetailsTableLayoutPanel.SuspendLayout();
            this.followupGroupBox.SuspendLayout();
            this.linkGroupBox.SuspendLayout();
            this.multipleFunctionalLocationGroupBox.SuspendLayout();
            this.customFieldsPanel.SuspendLayout();
            this.templateAndCommentsTableLayoutPanel.SuspendLayout();
            this.templatePanel.SuspendLayout();
            this.schedulePanel.SuspendLayout();
            this.additionalDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // viewEditHistoryButton
            // 
            resources.ApplyResources(this.viewEditHistoryButton, "viewEditHistoryButton");
            this.viewEditHistoryButton.Name = "viewEditHistoryButton";
            this.toolTip.SetToolTip(this.viewEditHistoryButton, resources.GetString("viewEditHistoryButton.ToolTip"));
            this.viewEditHistoryButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveAndCloseButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.viewEditHistoryButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // saveAndCloseButton
            // 
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // scrollingPanel
            // 
            resources.ApplyResources(this.scrollingPanel, "scrollingPanel");
            this.scrollingPanel.Controls.Add(this.tableLayoutPanel);
            this.scrollingPanel.Name = "scrollingPanel";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.flocsAndOptionsTableLayoutPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.commentsLabelLine, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.detailsLabelLine, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.logDateTimeCreateUserAndShiftPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.advancedDetailsPanel, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.customFieldsPanel, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.templateAndCommentsTableLayoutPanel, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.schedulePanel, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.additionalDetailsPanel, 0, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // flocsAndOptionsTableLayoutPanel
            // 
            this.flocsAndOptionsTableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.flocsAndOptionsTableLayoutPanel, "flocsAndOptionsTableLayoutPanel");
            this.flocsAndOptionsTableLayoutPanel.Controls.Add(this.optionsGroupBox, 1, 0);
            this.flocsAndOptionsTableLayoutPanel.Controls.Add(this.functionalLocationGroupBox, 0, 0);
            this.flocsAndOptionsTableLayoutPanel.Name = "flocsAndOptionsTableLayoutPanel";
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.flowLayoutPanel);
            resources.ApplyResources(this.optionsGroupBox, "optionsGroupBox");
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.IsOperatingEngineerLogCheckBox);
            this.flowLayoutPanel.Controls.Add(this.isInactiveCheckBox);
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // IsOperatingEngineerLogCheckBox
            // 
            resources.ApplyResources(this.IsOperatingEngineerLogCheckBox, "IsOperatingEngineerLogCheckBox");
            this.IsOperatingEngineerLogCheckBox.Checked = true;
            this.IsOperatingEngineerLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsOperatingEngineerLogCheckBox.Name = "IsOperatingEngineerLogCheckBox";
            this.IsOperatingEngineerLogCheckBox.UseVisualStyleBackColor = true;
            this.IsOperatingEngineerLogCheckBox.Value = null;
            // 
            // isInactiveCheckBox
            // 
            resources.ApplyResources(this.isInactiveCheckBox, "isInactiveCheckBox");
            this.isInactiveCheckBox.Checked = true;
            this.isInactiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isInactiveCheckBox.Name = "isInactiveCheckBox";
            this.isInactiveCheckBox.UseVisualStyleBackColor = true;
            this.isInactiveCheckBox.Value = null;
            // 
            // functionalLocationGroupBox
            // 
            this.functionalLocationGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.functionalLocationGroupBox.Controls.Add(this.flocAndButtonsTableLayoutPanel);
            resources.ApplyResources(this.functionalLocationGroupBox, "functionalLocationGroupBox");
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.TabStop = false;
            // 
            // flocAndButtonsTableLayoutPanel
            // 
            resources.ApplyResources(this.flocAndButtonsTableLayoutPanel, "flocAndButtonsTableLayoutPanel");
            this.flocAndButtonsTableLayoutPanel.Controls.Add(this.functionalLocationListBox, 0, 0);
            this.flocAndButtonsTableLayoutPanel.Controls.Add(this.flocButtonsPanel, 1, 0);
            this.flocAndButtonsTableLayoutPanel.Name = "flocAndButtonsTableLayoutPanel";
            // 
            // functionalLocationListBox
            // 
            resources.ApplyResources(this.functionalLocationListBox, "functionalLocationListBox");
            this.functionalLocationListBox.Name = "functionalLocationListBox";
            this.functionalLocationListBox.ReadOnly = false;
            // 
            // flocButtonsPanel
            // 
            this.flocButtonsPanel.Controls.Add(this.functionalLocationButton);
            this.flocButtonsPanel.Controls.Add(this.removeFLOCButton);
            resources.ApplyResources(this.flocButtonsPanel, "flocButtonsPanel");
            this.flocButtonsPanel.Name = "flocButtonsPanel";
            // 
            // functionalLocationButton
            // 
            resources.ApplyResources(this.functionalLocationButton, "functionalLocationButton");
            this.functionalLocationButton.Name = "functionalLocationButton";
            this.functionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // removeFLOCButton
            // 
            resources.ApplyResources(this.removeFLOCButton, "removeFLOCButton");
            this.removeFLOCButton.Name = "removeFLOCButton";
            this.removeFLOCButton.UseVisualStyleBackColor = true;
            // 
            // commentsLabelLine
            // 
            resources.ApplyResources(this.commentsLabelLine, "commentsLabelLine");
            this.commentsLabelLine.Name = "commentsLabelLine";
            this.commentsLabelLine.TabStop = false;
            // 
            // detailsLabelLine
            // 
            resources.ApplyResources(this.detailsLabelLine, "detailsLabelLine");
            this.detailsLabelLine.Name = "detailsLabelLine";
            this.detailsLabelLine.TabStop = false;
            // 
            // logDateTimeCreateUserAndShiftPanel
            // 
            this.logDateTimeCreateUserAndShiftPanel.Controls.Add(this.lastModifiedDateAuthorHeader);
            resources.ApplyResources(this.logDateTimeCreateUserAndShiftPanel, "logDateTimeCreateUserAndShiftPanel");
            this.logDateTimeCreateUserAndShiftPanel.Name = "logDateTimeCreateUserAndShiftPanel";
            // 
            // lastModifiedDateAuthorHeader
            // 
            resources.ApplyResources(this.lastModifiedDateAuthorHeader, "lastModifiedDateAuthorHeader");
            this.lastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.lastModifiedDateAuthorHeader.Name = "lastModifiedDateAuthorHeader";
            // 
            // advancedDetailsPanel
            // 
            this.advancedDetailsPanel.Controls.Add(this.advancedDetailsTableLayoutPanel);
            resources.ApplyResources(this.advancedDetailsPanel, "advancedDetailsPanel");
            this.advancedDetailsPanel.MinimumSize = new System.Drawing.Size(0, 110);
            this.advancedDetailsPanel.Name = "advancedDetailsPanel";
            // 
            // advancedDetailsTableLayoutPanel
            // 
            resources.ApplyResources(this.advancedDetailsTableLayoutPanel, "advancedDetailsTableLayoutPanel");
            this.advancedDetailsTableLayoutPanel.Controls.Add(this.followupGroupBox, 2, 0);
            this.advancedDetailsTableLayoutPanel.Controls.Add(this.linkGroupBox, 0, 0);
            this.advancedDetailsTableLayoutPanel.Controls.Add(this.multipleFunctionalLocationGroupBox, 1, 0);
            this.advancedDetailsTableLayoutPanel.Name = "advancedDetailsTableLayoutPanel";
            // 
            // followupGroupBox
            // 
            this.followupGroupBox.Controls.Add(this.operationsFollowUpCheckbox);
            this.followupGroupBox.Controls.Add(this.supervisorFollowUpCheckbox);
            this.followupGroupBox.Controls.Add(this.processControlFollowUpCheckBox);
            this.followupGroupBox.Controls.Add(this.eHSFollowUpCheckBox);
            this.followupGroupBox.Controls.Add(this.inspectionFollowUpCheckbox);
            this.followupGroupBox.Controls.Add(this.otherFollowUpCheckBox);
            resources.ApplyResources(this.followupGroupBox, "followupGroupBox");
            this.followupGroupBox.MinimumSize = new System.Drawing.Size(207, 99);
            this.followupGroupBox.Name = "followupGroupBox";
            this.followupGroupBox.TabStop = false;
            // 
            // operationsFollowUpCheckbox
            // 
            resources.ApplyResources(this.operationsFollowUpCheckbox, "operationsFollowUpCheckbox");
            this.operationsFollowUpCheckbox.Name = "operationsFollowUpCheckbox";
            this.operationsFollowUpCheckbox.UseVisualStyleBackColor = true;
            this.operationsFollowUpCheckbox.Value = null;
            // 
            // supervisorFollowUpCheckbox
            // 
            resources.ApplyResources(this.supervisorFollowUpCheckbox, "supervisorFollowUpCheckbox");
            this.supervisorFollowUpCheckbox.Name = "supervisorFollowUpCheckbox";
            this.supervisorFollowUpCheckbox.UseVisualStyleBackColor = true;
            this.supervisorFollowUpCheckbox.Value = null;
            // 
            // processControlFollowUpCheckBox
            // 
            resources.ApplyResources(this.processControlFollowUpCheckBox, "processControlFollowUpCheckBox");
            this.processControlFollowUpCheckBox.Name = "processControlFollowUpCheckBox";
            this.processControlFollowUpCheckBox.UseVisualStyleBackColor = true;
            this.processControlFollowUpCheckBox.Value = null;
            // 
            // eHSFollowUpCheckBox
            // 
            resources.ApplyResources(this.eHSFollowUpCheckBox, "eHSFollowUpCheckBox");
            this.eHSFollowUpCheckBox.Name = "eHSFollowUpCheckBox";
            this.eHSFollowUpCheckBox.UseVisualStyleBackColor = true;
            this.eHSFollowUpCheckBox.Value = null;
            // 
            // inspectionFollowUpCheckbox
            // 
            resources.ApplyResources(this.inspectionFollowUpCheckbox, "inspectionFollowUpCheckbox");
            this.inspectionFollowUpCheckbox.Name = "inspectionFollowUpCheckbox";
            this.inspectionFollowUpCheckbox.UseVisualStyleBackColor = true;
            this.inspectionFollowUpCheckbox.Value = null;
            // 
            // otherFollowUpCheckBox
            // 
            resources.ApplyResources(this.otherFollowUpCheckBox, "otherFollowUpCheckBox");
            this.otherFollowUpCheckBox.Name = "otherFollowUpCheckBox";
            this.otherFollowUpCheckBox.UseVisualStyleBackColor = true;
            this.otherFollowUpCheckBox.Value = null;
            // 
            // linkGroupBox
            // 
            this.linkGroupBox.Controls.Add(this.logDocumentLinksControl);
            resources.ApplyResources(this.linkGroupBox, "linkGroupBox");
            this.linkGroupBox.Name = "linkGroupBox";
            this.linkGroupBox.TabStop = false;
            // 
            // logDocumentLinksControl
            // 
            resources.ApplyResources(this.logDocumentLinksControl, "logDocumentLinksControl");
            this.logDocumentLinksControl.DataSource = null;
            this.logDocumentLinksControl.Name = "logDocumentLinksControl";
            this.logDocumentLinksControl.ReadOnlyList = true;
            // 
            // multipleFunctionalLocationGroupBox
            // 
            this.multipleFunctionalLocationGroupBox.Controls.Add(this.createOneLogRadioButton);
            this.multipleFunctionalLocationGroupBox.Controls.Add(this.createLogForEachFlocRadioButton);
            resources.ApplyResources(this.multipleFunctionalLocationGroupBox, "multipleFunctionalLocationGroupBox");
            this.multipleFunctionalLocationGroupBox.MinimumSize = new System.Drawing.Size(162, 99);
            this.multipleFunctionalLocationGroupBox.Name = "multipleFunctionalLocationGroupBox";
            this.multipleFunctionalLocationGroupBox.TabStop = false;
            // 
            // createOneLogRadioButton
            // 
            this.createOneLogRadioButton.Checked = true;
            resources.ApplyResources(this.createOneLogRadioButton, "createOneLogRadioButton");
            this.createOneLogRadioButton.Name = "createOneLogRadioButton";
            this.createOneLogRadioButton.TabStop = true;
            this.createOneLogRadioButton.UseVisualStyleBackColor = true;
            // 
            // createLogForEachFlocRadioButton
            // 
            resources.ApplyResources(this.createLogForEachFlocRadioButton, "createLogForEachFlocRadioButton");
            this.createLogForEachFlocRadioButton.Name = "createLogForEachFlocRadioButton";
            this.createLogForEachFlocRadioButton.UseVisualStyleBackColor = true;
            // 
            // customFieldsPanel
            // 
            resources.ApplyResources(this.customFieldsPanel, "customFieldsPanel");
            this.customFieldsPanel.Controls.Add(this.customFieldsLabelLine);
            this.customFieldsPanel.Controls.Add(this.customFieldControl);
            this.customFieldsPanel.Name = "customFieldsPanel";
            // 
            // customFieldsLabelLine
            // 
            resources.ApplyResources(this.customFieldsLabelLine, "customFieldsLabelLine");
            this.customFieldsLabelLine.Name = "customFieldsLabelLine";
            this.customFieldsLabelLine.TabStop = false;
            // 
            // customFieldControl
            // 
            resources.ApplyResources(this.customFieldControl, "customFieldControl");
            this.customFieldControl.MinimumSize = new System.Drawing.Size(0, 30);
            this.customFieldControl.Name = "customFieldControl";
            // 
            // templateAndCommentsTableLayoutPanel
            // 
            resources.ApplyResources(this.templateAndCommentsTableLayoutPanel, "templateAndCommentsTableLayoutPanel");
            this.templateAndCommentsTableLayoutPanel.Controls.Add(this.logCommentControl, 0, 1);
            this.templateAndCommentsTableLayoutPanel.Controls.Add(this.templatePanel, 0, 0);
            this.templateAndCommentsTableLayoutPanel.MinimumSize = new System.Drawing.Size(0, 255);
            this.templateAndCommentsTableLayoutPanel.Name = "templateAndCommentsTableLayoutPanel";
            // 
            // logCommentControl
            // 
            resources.ApplyResources(this.logCommentControl, "logCommentControl");
            this.logCommentControl.Name = "logCommentControl";
            this.logCommentControl.TextBoxReadOnly = false;
            // 
            // templatePanel
            // 
            this.templatePanel.Controls.Add(this.insertTemplateButton);
            this.templatePanel.Controls.Add(this.templateLabel);
            this.templatePanel.Controls.Add(this.logTemplateComboBox);
            resources.ApplyResources(this.templatePanel, "templatePanel");
            this.templatePanel.MinimumSize = new System.Drawing.Size(0, 37);
            this.templatePanel.Name = "templatePanel";
            // 
            // insertTemplateButton
            // 
            resources.ApplyResources(this.insertTemplateButton, "insertTemplateButton");
            this.insertTemplateButton.Name = "insertTemplateButton";
            this.insertTemplateButton.UseVisualStyleBackColor = true;
            // 
            // templateLabel
            // 
            resources.ApplyResources(this.templateLabel, "templateLabel");
            this.templateLabel.Name = "templateLabel";
            // 
            // logTemplateComboBox
            // 
            resources.ApplyResources(this.logTemplateComboBox, "logTemplateComboBox");
            this.logTemplateComboBox.DisplayMember = "Name";
            this.logTemplateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logTemplateComboBox.FormattingEnabled = true;
            this.logTemplateComboBox.Name = "logTemplateComboBox";
            // 
            // schedulePanel
            // 
            this.schedulePanel.Controls.Add(this.schedulePicker);
            this.schedulePanel.Controls.Add(this.repeatingScheduleLine);
            resources.ApplyResources(this.schedulePanel, "schedulePanel");
            this.schedulePanel.Name = "schedulePanel";
            // 
            // schedulePicker
            // 
            this.schedulePicker.Frequency = 1;
            resources.ApplyResources(this.schedulePicker, "schedulePicker");
            this.schedulePicker.Mode = Com.Suncor.Olt.Client.Presenters.SchedulePresenterMode.Log;
            this.schedulePicker.Name = "schedulePicker";
            this.schedulePicker.NoEndDate = false;
            this.schedulePicker.WeeklyFrequency = 1;
            // 
            // repeatingScheduleLine
            // 
            resources.ApplyResources(this.repeatingScheduleLine, "repeatingScheduleLine");
            this.repeatingScheduleLine.Name = "repeatingScheduleLine";
            this.repeatingScheduleLine.TabStop = false;
            // 
            // additionalDetailsPanel
            // 
            this.additionalDetailsPanel.Controls.Add(this.additionalDetailsToggleButton);
            this.additionalDetailsPanel.Controls.Add(this.additionalDetailsLabelLine);
            resources.ApplyResources(this.additionalDetailsPanel, "additionalDetailsPanel");
            this.additionalDetailsPanel.Name = "additionalDetailsPanel";
            // 
            // additionalDetailsToggleButton
            // 
            this.additionalDetailsToggleButton.Expanded = true;
            resources.ApplyResources(this.additionalDetailsToggleButton, "additionalDetailsToggleButton");
            this.additionalDetailsToggleButton.Name = "additionalDetailsToggleButton";
            // 
            // additionalDetailsLabelLine
            // 
            resources.ApplyResources(this.additionalDetailsLabelLine, "additionalDetailsLabelLine");
            this.additionalDetailsLabelLine.MinimumSize = new System.Drawing.Size(0, 14);
            this.additionalDetailsLabelLine.Name = "additionalDetailsLabelLine";
            this.additionalDetailsLabelLine.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // LogDefinitionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollingPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "LogDefinitionForm";
            this.buttonPanel.ResumeLayout(false);
            this.scrollingPanel.ResumeLayout(false);
            this.scrollingPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flocsAndOptionsTableLayoutPanel.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.flocAndButtonsTableLayoutPanel.ResumeLayout(false);
            this.flocButtonsPanel.ResumeLayout(false);
            this.logDateTimeCreateUserAndShiftPanel.ResumeLayout(false);
            this.advancedDetailsPanel.ResumeLayout(false);
            this.advancedDetailsTableLayoutPanel.ResumeLayout(false);
            this.followupGroupBox.ResumeLayout(false);
            this.followupGroupBox.PerformLayout();
            this.linkGroupBox.ResumeLayout(false);
            this.multipleFunctionalLocationGroupBox.ResumeLayout(false);
            this.customFieldsPanel.ResumeLayout(false);
            this.customFieldsPanel.PerformLayout();
            this.templateAndCommentsTableLayoutPanel.ResumeLayout(false);
            this.templatePanel.ResumeLayout(false);
            this.templatePanel.PerformLayout();
            this.schedulePanel.ResumeLayout(false);
            this.additionalDetailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton saveAndCloseButton;
        private OltButton cancelButton;
        private System.Windows.Forms.Button viewEditHistoryButton;
        private System.Windows.Forms.ToolTip toolTip;
        private Panel buttonPanel;
        private ColumnHeader columnHeader1;
        private OltPanel scrollingPanel;
        private OltControls.OltTableLayoutPanel tableLayoutPanel;
        private OltLabelLine commentsLabelLine;
        private OltLabelLine detailsLabelLine;
        private OltPanel logDateTimeCreateUserAndShiftPanel;
        private OltGroupBox functionalLocationGroupBox;
        private TableLayoutPanel flocAndButtonsTableLayoutPanel;
        private Controls.FunctionalLocationListBox functionalLocationListBox;
        private OltPanel flocButtonsPanel;
        private OltButton functionalLocationButton;
        private OltButton removeFLOCButton;
        private OltGroupBox optionsGroupBox;
        private FlowLayoutPanel flowLayoutPanel;
        private OltCheckBox IsOperatingEngineerLogCheckBox;
        private OltPanel advancedDetailsPanel;
        private TableLayoutPanel advancedDetailsTableLayoutPanel;
        private OltGroupBox followupGroupBox;
        private OltCheckBox operationsFollowUpCheckbox;
        private OltCheckBox supervisorFollowUpCheckbox;
        private OltCheckBox processControlFollowUpCheckBox;
        private OltCheckBox eHSFollowUpCheckBox;
        private OltCheckBox inspectionFollowUpCheckbox;
        private OltCheckBox otherFollowUpCheckBox;
        private OltGroupBox linkGroupBox;
        private Controls.DocumentLinksControl logDocumentLinksControl;
        private OltGroupBox multipleFunctionalLocationGroupBox;
        private OltRadioButton createOneLogRadioButton;
        private OltRadioButton createLogForEachFlocRadioButton;
        private OltPanel customFieldsPanel;
        private OltLabelLine customFieldsLabelLine;
        private Controls.CustomFieldTableLayoutPanel customFieldControl;
        private TableLayoutPanel templateAndCommentsTableLayoutPanel;
        private Controls.LogCommentControl logCommentControl;
        private OltPanel templatePanel;
        private OltButton insertTemplateButton;
        private OltLabel templateLabel;
        private OltComboBox logTemplateComboBox;
        private OltPanel schedulePanel;
        private Controls.SchedulePicker schedulePicker;
        private OltLabelLine repeatingScheduleLine;
        private OltPanel additionalDetailsPanel;
        private OltControls.OltToggleButton additionalDetailsToggleButton;
        private OltLabelLine additionalDetailsLabelLine;
        private ErrorProvider errorProvider;
        private OltControls.OltTableLayoutPanel flocsAndOptionsTableLayoutPanel;
        private OltLastModifiedDateAuthorHeader lastModifiedDateAuthorHeader;
        private OltCheckBox isInactiveCheckBox;
    }
}

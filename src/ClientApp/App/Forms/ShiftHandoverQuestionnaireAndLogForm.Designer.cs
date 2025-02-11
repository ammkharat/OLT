using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ShiftHandoverQuestionnaireAndLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftHandoverQuestionnaireAndLogForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logValidationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.questionnaireValidationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProviderImage = new System.Windows.Forms.ErrorProvider(this.components);
            this.scrollingPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.tableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltLabelLogImagesTitle = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.richTextCommentDisplay = new Com.Suncor.Olt.Client.Controls.RichTextDisplay();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.advancedDetailsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.linkGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.logDocumentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.optionsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.isOperatingEngineerLogCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.recommendForShiftSummaryCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.commentsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.templateAndCommentsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logCommentControl = new Com.Suncor.Olt.Client.Controls.LogCommentControl();
            this.templatePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.insertTemplateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.logTemplateComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.detailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.logDateTimeCreateUserAndShiftPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.createdByGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createdByLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.logTimeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.logTimeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.logDateTimeLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.actualLoggedTime = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.ShiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.functionalLocationAndOptionsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltTableLayoutPanel1 = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.handoverTypeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.FlextShiftHandoverChkBox = new System.Windows.Forms.CheckBox();
            this.handoverTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.FlexiShiftHandoverGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocAndButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.flocButtonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.addFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeFunctionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.customFieldsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.customFieldPhTagLegendControl = new Com.Suncor.Olt.Client.Controls.CustomFieldPhTagLegendControl();
            this.customFieldsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.customFieldTableLayoutPanel = new Com.Suncor.Olt.Client.Controls.CustomFieldTableLayoutPanel();
            this.additionalDetailsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.additionalDetailsToggleButton = new Com.Suncor.Olt.Client.OltControls.OltToggleButton();
            this.additionalDetailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.questionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.oltTableLayoutLogImagesPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltTableLayoutPanel2 = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.txtName = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.txtDescription = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltbtnbrowse = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.txtFilePath = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltCmbImageType = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltbtnAdd = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltDGVImage = new Com.Suncor.Olt.Client.OltControls.OltDataGridView();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.chkActiveCsdLog = new System.Windows.Forms.CheckBox();
            this.selectShiftLogMessages = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.importCustomFieldsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.selectInfoForSummaryButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.templateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endDateTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startDateTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.ShiftEndDatePickerDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.ShiftStartDateDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.logValidationErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionnaireValidationErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderImage)).BeginInit();
            this.scrollingPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.advancedDetailsTableLayoutPanel.SuspendLayout();
            this.linkGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.templateAndCommentsTableLayoutPanel.SuspendLayout();
            this.templatePanel.SuspendLayout();
            this.logDateTimeCreateUserAndShiftPanel.SuspendLayout();
            this.createdByGroupBox.SuspendLayout();
            this.logTimeGroupBox.SuspendLayout();
            this.logTimeFlowLayoutPanel.SuspendLayout();
            this.ShiftGroupBox.SuspendLayout();
            this.functionalLocationAndOptionsPanel.SuspendLayout();
            this.oltTableLayoutPanel1.SuspendLayout();
            this.handoverTypeGroupBox.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.flocAndButtonsTableLayoutPanel.SuspendLayout();
            this.flocButtonsPanel.SuspendLayout();
            this.customFieldsPanel.SuspendLayout();
            this.additionalDetailsPanel.SuspendLayout();
            this.oltTableLayoutLogImagesPanel.SuspendLayout();
            this.oltTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVImage)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // logValidationErrorProvider
            // 
            this.logValidationErrorProvider.ContainerControl = this;
            // 
            // questionnaireValidationErrorProvider
            // 
            this.questionnaireValidationErrorProvider.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.Multiselect = true;
            // 
            // errorProviderImage
            // 
            this.errorProviderImage.ContainerControl = this;
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
            this.tableLayoutPanel.Controls.Add(this.oltLabelLogImagesTitle, 0, 12);
            this.tableLayoutPanel.Controls.Add(this.richTextCommentDisplay, 0, 11);
            this.tableLayoutPanel.Controls.Add(this.oltLabelLine1, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.advancedDetailsTableLayoutPanel, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.commentsLabelLine, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.templateAndCommentsTableLayoutPanel, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.detailsLabelLine, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.logDateTimeCreateUserAndShiftPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.functionalLocationAndOptionsPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.customFieldsPanel, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.additionalDetailsPanel, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.questionsTableLayoutPanel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.oltTableLayoutLogImagesPanel, 0, 13);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // oltLabelLogImagesTitle
            // 
            resources.ApplyResources(this.oltLabelLogImagesTitle, "oltLabelLogImagesTitle");
            this.oltLabelLogImagesTitle.Name = "oltLabelLogImagesTitle";
            this.oltLabelLogImagesTitle.TabStop = false;
            // 
            // richTextCommentDisplay
            // 
            this.richTextCommentDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.richTextCommentDisplay, "richTextCommentDisplay");
            this.richTextCommentDisplay.Name = "richTextCommentDisplay";
            // 
            // oltLabelLine1
            // 
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // advancedDetailsTableLayoutPanel
            // 
            resources.ApplyResources(this.advancedDetailsTableLayoutPanel, "advancedDetailsTableLayoutPanel");
            this.advancedDetailsTableLayoutPanel.Controls.Add(this.linkGroupBox, 0, 0);
            this.advancedDetailsTableLayoutPanel.Controls.Add(this.optionsGroupBox, 1, 0);
            this.advancedDetailsTableLayoutPanel.Name = "advancedDetailsTableLayoutPanel";
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
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.flowLayoutPanel);
            resources.ApplyResources(this.optionsGroupBox, "optionsGroupBox");
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.isOperatingEngineerLogCheckBox);
            this.flowLayoutPanel.Controls.Add(this.recommendForShiftSummaryCheckBox);
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // isOperatingEngineerLogCheckBox
            // 
            resources.ApplyResources(this.isOperatingEngineerLogCheckBox, "isOperatingEngineerLogCheckBox");
            this.isOperatingEngineerLogCheckBox.Checked = true;
            this.isOperatingEngineerLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isOperatingEngineerLogCheckBox.Name = "isOperatingEngineerLogCheckBox";
            this.isOperatingEngineerLogCheckBox.UseVisualStyleBackColor = true;
            this.isOperatingEngineerLogCheckBox.Value = null;
            // 
            // recommendForShiftSummaryCheckBox
            // 
            resources.ApplyResources(this.recommendForShiftSummaryCheckBox, "recommendForShiftSummaryCheckBox");
            this.recommendForShiftSummaryCheckBox.Name = "recommendForShiftSummaryCheckBox";
            this.recommendForShiftSummaryCheckBox.UseVisualStyleBackColor = true;
            this.recommendForShiftSummaryCheckBox.Value = null;
            // 
            // commentsLabelLine
            // 
            resources.ApplyResources(this.commentsLabelLine, "commentsLabelLine");
            this.commentsLabelLine.Name = "commentsLabelLine";
            this.commentsLabelLine.TabStop = false;
            // 
            // templateAndCommentsTableLayoutPanel
            // 
            resources.ApplyResources(this.templateAndCommentsTableLayoutPanel, "templateAndCommentsTableLayoutPanel");
            this.templateAndCommentsTableLayoutPanel.Controls.Add(this.logCommentControl, 0, 1);
            this.templateAndCommentsTableLayoutPanel.Controls.Add(this.templatePanel, 0, 0);
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
            this.templatePanel.Controls.Add(this.logTemplateComboBox);
            resources.ApplyResources(this.templatePanel, "templatePanel");
            this.templatePanel.Name = "templatePanel";
            // 
            // insertTemplateButton
            // 
            resources.ApplyResources(this.insertTemplateButton, "insertTemplateButton");
            this.insertTemplateButton.Name = "insertTemplateButton";
            this.insertTemplateButton.UseVisualStyleBackColor = true;
            // 
            // logTemplateComboBox
            // 
            resources.ApplyResources(this.logTemplateComboBox, "logTemplateComboBox");
            this.logTemplateComboBox.DisplayMember = "Name";
            this.logTemplateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logTemplateComboBox.FormattingEnabled = true;
            this.logTemplateComboBox.Name = "logTemplateComboBox";
            // 
            // detailsLabelLine
            // 
            resources.ApplyResources(this.detailsLabelLine, "detailsLabelLine");
            this.detailsLabelLine.Name = "detailsLabelLine";
            this.detailsLabelLine.TabStop = false;
            // 
            // logDateTimeCreateUserAndShiftPanel
            // 
            this.logDateTimeCreateUserAndShiftPanel.Controls.Add(this.createdByGroupBox);
            this.logDateTimeCreateUserAndShiftPanel.Controls.Add(this.logTimeGroupBox);
            this.logDateTimeCreateUserAndShiftPanel.Controls.Add(this.ShiftGroupBox);
            resources.ApplyResources(this.logDateTimeCreateUserAndShiftPanel, "logDateTimeCreateUserAndShiftPanel");
            this.logDateTimeCreateUserAndShiftPanel.Name = "logDateTimeCreateUserAndShiftPanel";
            // 
            // createdByGroupBox
            // 
            this.createdByGroupBox.Controls.Add(this.createdByLabelData);
            resources.ApplyResources(this.createdByGroupBox, "createdByGroupBox");
            this.createdByGroupBox.Name = "createdByGroupBox";
            this.createdByGroupBox.TabStop = false;
            // 
            // createdByLabelData
            // 
            resources.ApplyResources(this.createdByLabelData, "createdByLabelData");
            this.createdByLabelData.Name = "createdByLabelData";
            this.createdByLabelData.UseMnemonic = false;
            // 
            // logTimeGroupBox
            // 
            this.logTimeGroupBox.Controls.Add(this.logTimeFlowLayoutPanel);
            resources.ApplyResources(this.logTimeGroupBox, "logTimeGroupBox");
            this.logTimeGroupBox.Name = "logTimeGroupBox";
            this.logTimeGroupBox.TabStop = false;
            // 
            // logTimeFlowLayoutPanel
            // 
            this.logTimeFlowLayoutPanel.Controls.Add(this.logDateTimeLabelData);
            this.logTimeFlowLayoutPanel.Controls.Add(this.actualLoggedTime);
            resources.ApplyResources(this.logTimeFlowLayoutPanel, "logTimeFlowLayoutPanel");
            this.logTimeFlowLayoutPanel.Name = "logTimeFlowLayoutPanel";
            // 
            // logDateTimeLabelData
            // 
            resources.ApplyResources(this.logDateTimeLabelData, "logDateTimeLabelData");
            this.logDateTimeLabelData.Name = "logDateTimeLabelData";
            this.logDateTimeLabelData.UseMnemonic = false;
            // 
            // actualLoggedTime
            // 
            this.actualLoggedTime.Checked = true;
            this.actualLoggedTime.CustomFormat = "HH:mm";
            resources.ApplyResources(this.actualLoggedTime, "actualLoggedTime");
            this.actualLoggedTime.Name = "actualLoggedTime";
            this.actualLoggedTime.ShowCheckBox = false;
            // 
            // ShiftGroupBox
            // 
            resources.ApplyResources(this.ShiftGroupBox, "ShiftGroupBox");
            this.ShiftGroupBox.Controls.Add(this.shiftLabelData);
            this.ShiftGroupBox.Name = "ShiftGroupBox";
            this.ShiftGroupBox.TabStop = false;
            // 
            // shiftLabelData
            // 
            resources.ApplyResources(this.shiftLabelData, "shiftLabelData");
            this.shiftLabelData.Name = "shiftLabelData";
            this.shiftLabelData.UseMnemonic = false;
            // 
            // functionalLocationAndOptionsPanel
            // 
            this.functionalLocationAndOptionsPanel.Controls.Add(this.oltTableLayoutPanel1);
            resources.ApplyResources(this.functionalLocationAndOptionsPanel, "functionalLocationAndOptionsPanel");
            this.functionalLocationAndOptionsPanel.Name = "functionalLocationAndOptionsPanel";
            // 
            // oltTableLayoutPanel1
            // 
            resources.ApplyResources(this.oltTableLayoutPanel1, "oltTableLayoutPanel1");
            this.oltTableLayoutPanel1.Controls.Add(this.handoverTypeGroupBox, 0, 0);
            this.oltTableLayoutPanel1.Controls.Add(this.functionalLocationGroupBox, 1, 0);
            this.oltTableLayoutPanel1.Name = "oltTableLayoutPanel1";
            // 
            // handoverTypeGroupBox
            // 
            this.handoverTypeGroupBox.Controls.Add(this.FlextShiftHandoverChkBox);
            this.handoverTypeGroupBox.Controls.Add(this.handoverTypeComboBox);
            this.handoverTypeGroupBox.Controls.Add(this.FlexiShiftHandoverGroupBox);
            resources.ApplyResources(this.handoverTypeGroupBox, "handoverTypeGroupBox");
            this.handoverTypeGroupBox.Name = "handoverTypeGroupBox";
            this.handoverTypeGroupBox.TabStop = false;
            // 
            // FlextShiftHandoverChkBox
            // 
            resources.ApplyResources(this.FlextShiftHandoverChkBox, "FlextShiftHandoverChkBox");
            this.FlextShiftHandoverChkBox.Name = "FlextShiftHandoverChkBox";
            this.FlextShiftHandoverChkBox.UseVisualStyleBackColor = true;
            // 
            // handoverTypeComboBox
            // 
            this.handoverTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.handoverTypeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.handoverTypeComboBox, "handoverTypeComboBox");
            this.handoverTypeComboBox.Name = "handoverTypeComboBox";
            // 
            // FlexiShiftHandoverGroupBox
            // 
            resources.ApplyResources(this.FlexiShiftHandoverGroupBox, "FlexiShiftHandoverGroupBox");
            this.FlexiShiftHandoverGroupBox.Name = "FlexiShiftHandoverGroupBox";
            this.FlexiShiftHandoverGroupBox.TabStop = false;
            // 
            // functionalLocationGroupBox
            // 
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
            this.flocButtonsPanel.Controls.Add(this.addFunctionalLocationButton);
            this.flocButtonsPanel.Controls.Add(this.removeFunctionalLocationButton);
            resources.ApplyResources(this.flocButtonsPanel, "flocButtonsPanel");
            this.flocButtonsPanel.Name = "flocButtonsPanel";
            // 
            // addFunctionalLocationButton
            // 
            resources.ApplyResources(this.addFunctionalLocationButton, "addFunctionalLocationButton");
            this.addFunctionalLocationButton.Name = "addFunctionalLocationButton";
            this.addFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // removeFunctionalLocationButton
            // 
            resources.ApplyResources(this.removeFunctionalLocationButton, "removeFunctionalLocationButton");
            this.removeFunctionalLocationButton.Name = "removeFunctionalLocationButton";
            this.removeFunctionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // customFieldsPanel
            // 
            resources.ApplyResources(this.customFieldsPanel, "customFieldsPanel");
            this.customFieldsPanel.Controls.Add(this.customFieldPhTagLegendControl);
            this.customFieldsPanel.Controls.Add(this.customFieldsLabelLine);
            this.customFieldsPanel.Controls.Add(this.customFieldTableLayoutPanel);
            this.customFieldsPanel.Name = "customFieldsPanel";
            // 
            // customFieldPhTagLegendControl
            // 
            resources.ApplyResources(this.customFieldPhTagLegendControl, "customFieldPhTagLegendControl");
            this.customFieldPhTagLegendControl.Name = "customFieldPhTagLegendControl";
            // 
            // customFieldsLabelLine
            // 
            resources.ApplyResources(this.customFieldsLabelLine, "customFieldsLabelLine");
            this.customFieldsLabelLine.Name = "customFieldsLabelLine";
            this.customFieldsLabelLine.TabStop = false;
            // 
            // customFieldTableLayoutPanel
            // 
            resources.ApplyResources(this.customFieldTableLayoutPanel, "customFieldTableLayoutPanel");
            this.customFieldTableLayoutPanel.Name = "customFieldTableLayoutPanel";
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
            this.additionalDetailsLabelLine.Name = "additionalDetailsLabelLine";
            this.additionalDetailsLabelLine.TabStop = false;
            // 
            // questionsTableLayoutPanel
            // 
            resources.ApplyResources(this.questionsTableLayoutPanel, "questionsTableLayoutPanel");
            this.questionsTableLayoutPanel.Name = "questionsTableLayoutPanel";
            // 
            // oltTableLayoutLogImagesPanel
            // 
            resources.ApplyResources(this.oltTableLayoutLogImagesPanel, "oltTableLayoutLogImagesPanel");
            this.oltTableLayoutLogImagesPanel.Controls.Add(this.oltTableLayoutPanel2, 0, 0);
            this.oltTableLayoutLogImagesPanel.Controls.Add(this.oltDGVImage, 0, 1);
            this.oltTableLayoutLogImagesPanel.Name = "oltTableLayoutLogImagesPanel";
            // 
            // oltTableLayoutPanel2
            // 
            resources.ApplyResources(this.oltTableLayoutPanel2, "oltTableLayoutPanel2");
            this.oltTableLayoutPanel2.Controls.Add(this.txtName, 1, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.txtDescription, 1, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.oltbtnbrowse, 4, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.txtFilePath, 3, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.oltCmbImageType, 0, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.oltbtnAdd, 5, 1);
            this.oltTableLayoutPanel2.Name = "oltTableLayoutPanel2";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.OltAcceptsReturn = true;
            this.txtName.OltTrimWhitespace = true;
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.OltAcceptsReturn = true;
            this.txtDescription.OltTrimWhitespace = true;
            // 
            // oltbtnbrowse
            // 
            resources.ApplyResources(this.oltbtnbrowse, "oltbtnbrowse");
            this.oltbtnbrowse.Name = "oltbtnbrowse";
            this.oltbtnbrowse.UseVisualStyleBackColor = true;
            this.oltbtnbrowse.Click += new System.EventHandler(this.oltselectImage_Click);
            // 
            // txtFilePath
            // 
            resources.ApplyResources(this.txtFilePath, "txtFilePath");
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.OltAcceptsReturn = true;
            this.txtFilePath.OltTrimWhitespace = true;
            this.txtFilePath.ReadOnly = true;
            // 
            // oltCmbImageType
            // 
            resources.ApplyResources(this.oltCmbImageType, "oltCmbImageType");
            this.oltCmbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oltCmbImageType.FormattingEnabled = true;
            this.oltCmbImageType.Items.AddRange(new object[] {
            resources.GetString("oltCmbImageType.Items"),
            resources.GetString("oltCmbImageType.Items1")});
            this.oltCmbImageType.Name = "oltCmbImageType";
            this.oltCmbImageType.SelectedIndexChanged += new System.EventHandler(this.oltComboBox1_SelectedIndexChanged);
            // 
            // oltbtnAdd
            // 
            resources.ApplyResources(this.oltbtnAdd, "oltbtnAdd");
            this.oltbtnAdd.Name = "oltbtnAdd";
            this.oltbtnAdd.UseVisualStyleBackColor = true;
            this.oltbtnAdd.Click += new System.EventHandler(this.oltAddImage_Click);
            // 
            // oltDGVImage
            // 
            this.oltDGVImage.AllowUserToAddRows = false;
            this.oltDGVImage.AllowUserToDeleteRows = false;
            this.oltDGVImage.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.oltDGVImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oltDGVImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove,
            this.Type,
            this.ImageName,
            this.Description,
            this.Column3,
            this.ImageId,
            this.Action});
            resources.ApplyResources(this.oltDGVImage, "oltDGVImage");
            this.oltDGVImage.Name = "oltDGVImage";
            this.oltDGVImage.StandardTab = true;
            this.oltDGVImage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oltDataGridView1_CellClick);
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Remove, "Remove");
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "Remove";
            this.Remove.UseColumnTextForButtonValue = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.DataPropertyName = "Types";
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // ImageName
            // 
            this.ImageName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImageName.DataPropertyName = "Name";
            resources.ApplyResources(this.ImageName, "ImageName");
            this.ImageName.Name = "ImageName";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "ImagePath";
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ImageId
            // 
            this.ImageId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImageId.DataPropertyName = "Id";
            resources.ApplyResources(this.ImageId, "ImageId");
            this.ImageId.Name = "ImageId";
            this.ImageId.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.DataPropertyName = "Action";
            resources.ApplyResources(this.Action, "Action");
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
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
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.chkActiveCsdLog);
            this.buttonPanel.Controls.Add(this.selectShiftLogMessages);
            this.buttonPanel.Controls.Add(this.importCustomFieldsButton);
            this.buttonPanel.Controls.Add(this.selectInfoForSummaryButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.saveAndCloseButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // chkActiveCsdLog
            // 
            resources.ApplyResources(this.chkActiveCsdLog, "chkActiveCsdLog");
            this.chkActiveCsdLog.Name = "chkActiveCsdLog";
            this.chkActiveCsdLog.UseVisualStyleBackColor = true;
            // 
            // selectShiftLogMessages
            // 
            resources.ApplyResources(this.selectShiftLogMessages, "selectShiftLogMessages");
            this.selectShiftLogMessages.Name = "selectShiftLogMessages";
            this.selectShiftLogMessages.UseVisualStyleBackColor = true;
            this.selectShiftLogMessages.Click += new System.EventHandler(this.selectShiftLogMessages_Click);
            // 
            // importCustomFieldsButton
            // 
            resources.ApplyResources(this.importCustomFieldsButton, "importCustomFieldsButton");
            this.importCustomFieldsButton.Name = "importCustomFieldsButton";
            this.importCustomFieldsButton.UseVisualStyleBackColor = true;
            // 
            // selectInfoForSummaryButton
            // 
            resources.ApplyResources(this.selectInfoForSummaryButton, "selectInfoForSummaryButton");
            this.selectInfoForSummaryButton.Name = "selectInfoForSummaryButton";
            this.selectInfoForSummaryButton.UseVisualStyleBackColor = true;
            // 
            // templateLabel
            // 
            resources.ApplyResources(this.templateLabel, "templateLabel");
            this.templateLabel.Name = "templateLabel";
            // 
            // endDateTimeLabel
            // 
            resources.ApplyResources(this.endDateTimeLabel, "endDateTimeLabel");
            this.endDateTimeLabel.Name = "endDateTimeLabel";
            // 
            // startDateTimeLabel
            // 
            resources.ApplyResources(this.startDateTimeLabel, "startDateTimeLabel");
            this.startDateTimeLabel.Name = "startDateTimeLabel";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // oltLabel4
            // 
            resources.ApplyResources(this.oltLabel4, "oltLabel4");
            this.oltLabel4.Name = "oltLabel4";
            // 
            // ShiftEndDatePickerDatePicker
            // 
            this.ShiftEndDatePickerDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.ShiftEndDatePickerDatePicker, "ShiftEndDatePickerDatePicker");
            this.ShiftEndDatePickerDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ShiftEndDatePickerDatePicker.Name = "ShiftEndDatePickerDatePicker";
            this.ShiftEndDatePickerDatePicker.PickerEnabled = true;
            // 
            // ShiftStartDateDatePicker
            // 
            this.ShiftStartDateDatePicker.AllowDrop = true;
            this.ShiftStartDateDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.ShiftStartDateDatePicker, "ShiftStartDateDatePicker");
            this.ShiftStartDateDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ShiftStartDateDatePicker.Name = "ShiftStartDateDatePicker";
            this.ShiftStartDateDatePicker.PickerEnabled = true;
            // 
            // ShiftHandoverQuestionnaireAndLogForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollingPanel);
            this.Controls.Add(this.buttonPanel);
            this.DoubleBuffered = true;
            this.Name = "ShiftHandoverQuestionnaireAndLogForm";
            ((System.ComponentModel.ISupportInitialize)(this.logValidationErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionnaireValidationErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderImage)).EndInit();
            this.scrollingPanel.ResumeLayout(false);
            this.scrollingPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.advancedDetailsTableLayoutPanel.ResumeLayout(false);
            this.linkGroupBox.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.templateAndCommentsTableLayoutPanel.ResumeLayout(false);
            this.templatePanel.ResumeLayout(false);
            this.logDateTimeCreateUserAndShiftPanel.ResumeLayout(false);
            this.createdByGroupBox.ResumeLayout(false);
            this.createdByGroupBox.PerformLayout();
            this.logTimeGroupBox.ResumeLayout(false);
            this.logTimeFlowLayoutPanel.ResumeLayout(false);
            this.logTimeFlowLayoutPanel.PerformLayout();
            this.ShiftGroupBox.ResumeLayout(false);
            this.ShiftGroupBox.PerformLayout();
            this.functionalLocationAndOptionsPanel.ResumeLayout(false);
            this.oltTableLayoutPanel1.ResumeLayout(false);
            this.handoverTypeGroupBox.ResumeLayout(false);
            this.handoverTypeGroupBox.PerformLayout();
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.flocAndButtonsTableLayoutPanel.ResumeLayout(false);
            this.flocButtonsPanel.ResumeLayout(false);
            this.customFieldsPanel.ResumeLayout(false);
            this.customFieldsPanel.PerformLayout();
            this.additionalDetailsPanel.ResumeLayout(false);
            this.oltTableLayoutLogImagesPanel.ResumeLayout(false);
            this.oltTableLayoutLogImagesPanel.PerformLayout();
            this.oltTableLayoutPanel2.ResumeLayout(false);
            this.oltTableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVImage)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton saveAndCloseButton;
        private OltButton cancelButton;
        private OltButton addFunctionalLocationButton;
        private Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox functionalLocationListBox;
        private OltLabelData shiftLabelData;
        private OltGroupBox ShiftGroupBox;
        private OltGroupBox functionalLocationGroupBox;
        private OltButton removeFunctionalLocationButton;
        private OltPanel buttonPanel;
        private System.Windows.Forms.ToolTip toolTip;
        private OltTimePicker actualLoggedTime;
        private OltLabelLine detailsLabelLine;
        private OltButton selectInfoForSummaryButton;
        private OltGroupBox logTimeGroupBox;
        private OltGroupBox createdByGroupBox;
        private OltLabelData createdByLabelData;
        private FlowLayoutPanel logTimeFlowLayoutPanel;
        private OltLabelData logDateTimeLabelData;
        private OltTableLayoutPanel tableLayoutPanel;
        private OltPanel scrollingPanel;
        private OltPanel logDateTimeCreateUserAndShiftPanel;
        private OltPanel functionalLocationAndOptionsPanel;
        private TableLayoutPanel flocAndButtonsTableLayoutPanel;
        private OltPanel flocButtonsPanel;
        private OltLabelLine additionalDetailsLabelLine;
        private OltPanel additionalDetailsPanel;
        private OltToggleButton additionalDetailsToggleButton;
        private OltButton importCustomFieldsButton;
        private ErrorProvider logValidationErrorProvider;
        private OltTableLayoutPanel oltTableLayoutPanel1;
        private OltGroupBox handoverTypeGroupBox;
        private OltComboBox handoverTypeComboBox;
        private TableLayoutPanel advancedDetailsTableLayoutPanel;
        private OltGroupBox linkGroupBox;
        private Controls.DocumentLinksControl logDocumentLinksControl;
        private OltGroupBox optionsGroupBox;
        private FlowLayoutPanel flowLayoutPanel;
        private OltCheckBox isOperatingEngineerLogCheckBox;
        private OltCheckBox recommendForShiftSummaryCheckBox;
        private OltLabelLine commentsLabelLine;
        private TableLayoutPanel templateAndCommentsTableLayoutPanel;
        private Controls.LogCommentControl logCommentControl;
        private OltPanel templatePanel;
        private OltButton insertTemplateButton;
        private OltLabel templateLabel;
        private OltComboBox logTemplateComboBox;
        private OltPanel customFieldsPanel;
        private Controls.CustomFieldPhTagLegendControl customFieldPhTagLegendControl;
        private OltLabelLine customFieldsLabelLine;
        private Controls.CustomFieldTableLayoutPanel customFieldTableLayoutPanel;
        private TableLayoutPanel questionsTableLayoutPanel;
        private OltLabelLine oltLabelLine1;
        private Controls.RichTextDisplay richTextCommentDisplay;
        private ErrorProvider questionnaireValidationErrorProvider;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox FlextShiftHandoverChkBox;
        private OltLabel endDateTimeLabel;
        private OltDatePicker ShiftEndDatePickerDatePicker;
        private OltLabel startDateTimeLabel;
        private OltDatePicker ShiftStartDateDatePicker;
        private OltGroupBox FlexiShiftHandoverGroupBox;
        private OltLabelLine oltLabelLogImagesTitle;
        private OltTableLayoutPanel oltTableLayoutLogImagesPanel;
        private OltTableLayoutPanel oltTableLayoutPanel2;
        private OltTextBox txtName;
        private OltTextBox txtDescription;
        private OltLabel oltLabel1;
        private OltButton oltbtnbrowse;
        private OltTextBox txtFilePath;
        private OltLabel oltLabel2;
        private OltLabel oltLabel3;
        private OltComboBox oltCmbImageType;
        private OltLabel oltLabel4;
        private OltButton oltbtnAdd;
        private OltDataGridView oltDGVImage;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider errorProviderImage;
        private DataGridViewButtonColumn Remove;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn ImageName;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewLinkColumn Column3;
        private DataGridViewTextBoxColumn ImageId;
        private DataGridViewTextBoxColumn Action;
        private OltButton selectShiftLogMessages;
        private CheckBox chkActiveCsdLog;
    }
}
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.viewEditHistoryButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.scrollingPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.tableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltLabelLogImagesTitle = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.commentsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.detailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.logDateTimeCreateUserAndShiftPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.createdByGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createdByLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.logTimeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.logDateTimeLabelData = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.actualLoggedTime = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.ShiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.functionalLocationAndOptionsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocAndButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.functionalLocationListBox = new Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox();
            this.flocButtonsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.functionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeFLOCButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.optionsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.IsOperatingEngineerLogCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.recommendForShiftSummaryCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
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
            this.customFieldPhTagLegendControl = new Com.Suncor.Olt.Client.Controls.CustomFieldPhTagLegendControl();
            this.customFieldsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.customFieldControl = new Com.Suncor.Olt.Client.Controls.CustomFieldTableLayoutPanel();
            this.templateAndCommentsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logCommentControl = new Com.Suncor.Olt.Client.Controls.LogCommentControl();
            this.templatePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.insertTemplateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.templateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.logTemplateComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.additionalDetailsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.additionalDetailsToggleButton = new Com.Suncor.Olt.Client.OltControls.OltToggleButton();
            this.additionalDetailsLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.oltTableLayoutLogImagesPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.oltTableLayoutPanel2 = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.txtName = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.txtDescription = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltbtnbrowse = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.txtFilePath = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltCmbImageType = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltbtnAdd = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltDGVImage = new Com.Suncor.Olt.Client.OltControls.OltDataGridView();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.functionLocationBlankErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.actualLoggedDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderImage = new System.Windows.Forms.ErrorProvider(this.components);
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.selectLogsForSummaryButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.importCustomFieldsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.scrollingPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.logDateTimeCreateUserAndShiftPanel.SuspendLayout();
            this.createdByGroupBox.SuspendLayout();
            this.logTimeGroupBox.SuspendLayout();
            this.ShiftGroupBox.SuspendLayout();
            this.functionalLocationAndOptionsPanel.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.flocAndButtonsTableLayoutPanel.SuspendLayout();
            this.flocButtonsPanel.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.advancedDetailsPanel.SuspendLayout();
            this.advancedDetailsTableLayoutPanel.SuspendLayout();
            this.followupGroupBox.SuspendLayout();
            this.linkGroupBox.SuspendLayout();
            this.multipleFunctionalLocationGroupBox.SuspendLayout();
            this.customFieldsPanel.SuspendLayout();
            this.templateAndCommentsTableLayoutPanel.SuspendLayout();
            this.templatePanel.SuspendLayout();
            this.additionalDetailsPanel.SuspendLayout();
            this.oltTableLayoutLogImagesPanel.SuspendLayout();
            this.oltTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionLocationBlankErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualLoggedDateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderImage)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewEditHistoryButton
            // 
            resources.ApplyResources(this.viewEditHistoryButton, "viewEditHistoryButton");
            this.viewEditHistoryButton.Name = "viewEditHistoryButton";
            this.toolTip.SetToolTip(this.viewEditHistoryButton, resources.GetString("viewEditHistoryButton.ToolTip"));
            this.viewEditHistoryButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.Multiselect = true;
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
            this.tableLayoutPanel.Controls.Add(this.oltLabelLogImagesTitle, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.commentsLabelLine, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.detailsLabelLine, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.logDateTimeCreateUserAndShiftPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.functionalLocationAndOptionsPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.advancedDetailsPanel, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.customFieldsPanel, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.templateAndCommentsTableLayoutPanel, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.additionalDetailsPanel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.oltTableLayoutLogImagesPanel, 0, 10);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // oltLabelLogImagesTitle
            // 
            resources.ApplyResources(this.oltLabelLogImagesTitle, "oltLabelLogImagesTitle");
            this.oltLabelLogImagesTitle.Name = "oltLabelLogImagesTitle";
            this.oltLabelLogImagesTitle.TabStop = false;
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
            this.logTimeGroupBox.Controls.Add(this.logDateTimeLabelData);
            this.logTimeGroupBox.Controls.Add(this.actualLoggedTime);
            resources.ApplyResources(this.logTimeGroupBox, "logTimeGroupBox");
            this.logTimeGroupBox.Name = "logTimeGroupBox";
            this.logTimeGroupBox.TabStop = false;
            // 
            // logDateTimeLabelData
            // 
            resources.ApplyResources(this.logDateTimeLabelData, "logDateTimeLabelData");
            this.logDateTimeLabelData.CustomFormat = "ddd MM/dd/yyyy";
            this.logDateTimeLabelData.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.logDateTimeLabelData.Name = "logDateTimeLabelData";
            this.logDateTimeLabelData.PickerEnabled = true;
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
            this.functionalLocationAndOptionsPanel.Controls.Add(this.functionalLocationGroupBox);
            this.functionalLocationAndOptionsPanel.Controls.Add(this.optionsGroupBox);
            resources.ApplyResources(this.functionalLocationAndOptionsPanel, "functionalLocationAndOptionsPanel");
            this.functionalLocationAndOptionsPanel.Name = "functionalLocationAndOptionsPanel";
            // 
            // functionalLocationGroupBox
            // 
            resources.ApplyResources(this.functionalLocationGroupBox, "functionalLocationGroupBox");
            this.functionalLocationGroupBox.Controls.Add(this.flocAndButtonsTableLayoutPanel);
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
            // optionsGroupBox
            // 
            resources.ApplyResources(this.optionsGroupBox, "optionsGroupBox");
            this.optionsGroupBox.Controls.Add(this.flowLayoutPanel);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.IsOperatingEngineerLogCheckBox);
            this.flowLayoutPanel.Controls.Add(this.recommendForShiftSummaryCheckBox);
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
            // recommendForShiftSummaryCheckBox
            // 
            resources.ApplyResources(this.recommendForShiftSummaryCheckBox, "recommendForShiftSummaryCheckBox");
            this.recommendForShiftSummaryCheckBox.Name = "recommendForShiftSummaryCheckBox";
            this.recommendForShiftSummaryCheckBox.UseVisualStyleBackColor = true;
            this.recommendForShiftSummaryCheckBox.Value = null;
            // 
            // advancedDetailsPanel
            // 
            this.advancedDetailsPanel.Controls.Add(this.advancedDetailsTableLayoutPanel);
            resources.ApplyResources(this.advancedDetailsPanel, "advancedDetailsPanel");
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
            this.logDocumentLinksControl.DataSource = null;
            resources.ApplyResources(this.logDocumentLinksControl, "logDocumentLinksControl");
            this.logDocumentLinksControl.Name = "logDocumentLinksControl";
            this.logDocumentLinksControl.ReadOnlyList = true;
            // 
            // multipleFunctionalLocationGroupBox
            // 
            this.multipleFunctionalLocationGroupBox.Controls.Add(this.createOneLogRadioButton);
            this.multipleFunctionalLocationGroupBox.Controls.Add(this.createLogForEachFlocRadioButton);
            resources.ApplyResources(this.multipleFunctionalLocationGroupBox, "multipleFunctionalLocationGroupBox");
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
            this.customFieldsPanel.Controls.Add(this.customFieldPhTagLegendControl);
            this.customFieldsPanel.Controls.Add(this.customFieldsLabelLine);
            this.customFieldsPanel.Controls.Add(this.customFieldControl);
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
            // customFieldControl
            // 
            resources.ApplyResources(this.customFieldControl, "customFieldControl");
            this.customFieldControl.Name = "customFieldControl";
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
            this.templatePanel.Controls.Add(this.templateLabel);
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
            this.oltTableLayoutPanel2.Controls.Add(this.oltLabel1, 1, 0);
            this.oltTableLayoutPanel2.Controls.Add(this.oltbtnbrowse, 4, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.txtFilePath, 3, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.oltLabel2, 2, 0);
            this.oltTableLayoutPanel2.Controls.Add(this.oltLabel3, 3, 0);
            this.oltTableLayoutPanel2.Controls.Add(this.oltCmbImageType, 0, 1);
            this.oltTableLayoutPanel2.Controls.Add(this.oltLabel4, 0, 0);
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
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // oltbtnbrowse
            // 
            resources.ApplyResources(this.oltbtnbrowse, "oltbtnbrowse");
            this.oltbtnbrowse.Name = "oltbtnbrowse";
            this.oltbtnbrowse.UseVisualStyleBackColor = true;
            this.oltbtnbrowse.Click += new System.EventHandler(this.oltButton1_Click);
            // 
            // txtFilePath
            // 
            resources.ApplyResources(this.txtFilePath, "txtFilePath");
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.OltAcceptsReturn = true;
            this.txtFilePath.OltTrimWhitespace = true;
            this.txtFilePath.ReadOnly = true;
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
            // oltLabel4
            // 
            resources.ApplyResources(this.oltLabel4, "oltLabel4");
            this.oltLabel4.Name = "oltLabel4";
            // 
            // oltbtnAdd
            // 
            resources.ApplyResources(this.oltbtnAdd, "oltbtnAdd");
            this.oltbtnAdd.Name = "oltbtnAdd";
            this.oltbtnAdd.UseVisualStyleBackColor = true;
            this.oltbtnAdd.Click += new System.EventHandler(this.oltButton2_Click);
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
            this.oltDGVImage.RowHeadersVisible = false;
            this.oltDGVImage.StandardTab = true;
            this.oltDGVImage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oltDataGridView1_CellClick);
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
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // functionLocationBlankErrorProvider
            // 
            this.functionLocationBlankErrorProvider.ContainerControl = this;
            // 
            // actualLoggedDateErrorProvider
            // 
            this.actualLoggedDateErrorProvider.ContainerControl = this;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // errorProviderImage
            // 
            this.errorProviderImage.ContainerControl = this;
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
            // selectLogsForSummaryButton
            // 
            resources.ApplyResources(this.selectLogsForSummaryButton, "selectLogsForSummaryButton");
            this.selectLogsForSummaryButton.Name = "selectLogsForSummaryButton";
            this.selectLogsForSummaryButton.UseVisualStyleBackColor = true;
            // 
            // importCustomFieldsButton
            // 
            resources.ApplyResources(this.importCustomFieldsButton, "importCustomFieldsButton");
            this.importCustomFieldsButton.Name = "importCustomFieldsButton";
            this.importCustomFieldsButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.importCustomFieldsButton);
            this.buttonPanel.Controls.Add(this.selectLogsForSummaryButton);
            this.buttonPanel.Controls.Add(this.viewEditHistoryButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.saveAndCloseButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // LogForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollingPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "LogForm";
            this.scrollingPanel.ResumeLayout(false);
            this.scrollingPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.logDateTimeCreateUserAndShiftPanel.ResumeLayout(false);
            this.createdByGroupBox.ResumeLayout(false);
            this.createdByGroupBox.PerformLayout();
            this.logTimeGroupBox.ResumeLayout(false);
            this.logTimeGroupBox.PerformLayout();
            this.ShiftGroupBox.ResumeLayout(false);
            this.ShiftGroupBox.PerformLayout();
            this.functionalLocationAndOptionsPanel.ResumeLayout(false);
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.flocAndButtonsTableLayoutPanel.ResumeLayout(false);
            this.flocButtonsPanel.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
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
            this.additionalDetailsPanel.ResumeLayout(false);
            this.oltTableLayoutLogImagesPanel.ResumeLayout(false);
            this.oltTableLayoutLogImagesPanel.PerformLayout();
            this.oltTableLayoutPanel2.ResumeLayout(false);
            this.oltTableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionLocationBlankErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualLoggedDateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderImage)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton functionalLocationButton;
        private Com.Suncor.Olt.Client.Controls.FunctionalLocationListBox functionalLocationListBox;
        private OltCheckBox operationsFollowUpCheckbox;
        private OltCheckBox supervisorFollowUpCheckbox;
        private OltCheckBox processControlFollowUpCheckBox;
        private OltCheckBox eHSFollowUpCheckBox;
        private OltCheckBox inspectionFollowUpCheckbox;
        private ErrorProvider functionLocationBlankErrorProvider;
        private OltCheckBox otherFollowUpCheckBox;
        private OltLabelData shiftLabelData;
        private OltGroupBox ShiftGroupBox;
        private OltGroupBox functionalLocationGroupBox;
        private OltButton removeFLOCButton;
        private OltGroupBox followupGroupBox;
        private OltCheckBox IsOperatingEngineerLogCheckBox;
        private OltGroupBox linkGroupBox;
        private Com.Suncor.Olt.Client.Controls.DocumentLinksControl logDocumentLinksControl;
        private System.Windows.Forms.ToolTip toolTip;
        private ErrorProvider actualLoggedDateErrorProvider;
        private FlowLayoutPanel flowLayoutPanel;
        private OltCheckBox recommendForShiftSummaryCheckBox;
        private OltGroupBox optionsGroupBox;
        private OltLabelLine detailsLabelLine;
        private OltLabelLine commentsLabelLine;
        private OltButton insertTemplateButton;
        private OltComboBox logTemplateComboBox;
        private OltLabel templateLabel;
        private OltGroupBox multipleFunctionalLocationGroupBox;
        private OltRadioButton createOneLogRadioButton;
        private OltRadioButton createLogForEachFlocRadioButton;
        private Com.Suncor.Olt.Client.Controls.CustomFieldTableLayoutPanel customFieldControl;
        private OltLabelLine customFieldsLabelLine;
        private OltGroupBox logTimeGroupBox;
        private OltGroupBox createdByGroupBox;
        private OltLabelData createdByLabelData;
        private Com.Suncor.Olt.Client.Controls.LogCommentControl logCommentControl;
        private OltTableLayoutPanel tableLayoutPanel;
        private OltPanel scrollingPanel;
        private OltPanel logDateTimeCreateUserAndShiftPanel;
        private OltPanel functionalLocationAndOptionsPanel;
        private OltPanel advancedDetailsPanel;
        private TableLayoutPanel advancedDetailsTableLayoutPanel;
        private OltPanel customFieldsPanel;
        private TableLayoutPanel templateAndCommentsTableLayoutPanel;
        private OltPanel templatePanel;
        private TableLayoutPanel flocAndButtonsTableLayoutPanel;
        private OltPanel flocButtonsPanel;
        private OltLabelLine additionalDetailsLabelLine;
        private OltPanel additionalDetailsPanel;
        private OltToggleButton additionalDetailsToggleButton;
        private Controls.CustomFieldPhTagLegendControl customFieldPhTagLegendControl;
        private ErrorProvider errorProvider;
        private OltDatePicker logDateTimeLabelData;
        private OltTimePicker actualLoggedTime;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider errorProviderImage;
        private OltPanel buttonPanel;
        private OltButton importCustomFieldsButton;
        private OltButton selectLogsForSummaryButton;
        private Button viewEditHistoryButton;
        private OltButton cancelButton;
        private OltButton saveAndCloseButton;
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
        private DataGridViewButtonColumn Remove;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn ImageName;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewLinkColumn Column3;
        private DataGridViewTextBoxColumn ImageId;
        private DataGridViewTextBoxColumn Action;
    }
}
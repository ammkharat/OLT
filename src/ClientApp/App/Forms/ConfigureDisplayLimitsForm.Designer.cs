using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureDisplayLimitsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDisplayLimitsForm));
            this.siteDisplayLabel = new System.Windows.Forms.Label();
            this.actionItemPrefixLabel = new System.Windows.Forms.Label();
            this.actionItemSuffixLabel = new System.Windows.Forms.Label();
            this.shiftLogSuffixLabel = new System.Windows.Forms.Label();
            this.shiftLogPrefixLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.daysToDisplayActionItemsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.daysToDisplayShiftHandoversTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.itemCountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.displayLimitsGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.actionItemPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cokerCardPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cokerCardsPrefixLabel = new System.Windows.Forms.Label();
            this.cokerCardsSuffixLabel = new System.Windows.Forms.Label();
            this.daysToDisplayCokerCardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.deviationPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.daysToDisplayDeviationAlertsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.labAlertPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.daysToDisplayLabAlertsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.shiftHandoverPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.shiftLogsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.daysToDisplayShiftLogsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.sapNotificationsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.daysToDisplaySAPNotificationsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.eventsConfigurationPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.daysToDisplayEventsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.workPermitPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.daysToDisplayWorkPermitsForwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.daysToDisplayWorkPermitsBackwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.permitRequestPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.daysToDisplayPermitRequestsForwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.daysToDisplayPermitRequestsBackwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.documentSuggestionFormsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.directivesPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.daysToDisplayDirectivesForwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.daysToDisplayDirectivesBackwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.electronicFormsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.daysToDisplayElectronicFormsForwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.daysToDisplayElectronicFormsBackwardsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayActionItemsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayShiftHandoversTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCountErrorProvider)).BeginInit();
            this.siteGroupBox.SuspendLayout();
            this.displayLimitsGroupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.actionItemPanel.SuspendLayout();
            this.cokerCardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayCokerCardsTextBox)).BeginInit();
            this.deviationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDeviationAlertsTextBox)).BeginInit();
            this.labAlertPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayLabAlertsTextBox)).BeginInit();
            this.shiftHandoverPanel.SuspendLayout();
            this.shiftLogsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayShiftLogsTextBox)).BeginInit();
            this.sapNotificationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplaySAPNotificationsTextBox)).BeginInit();
            this.eventsConfigurationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayEventsTextBox)).BeginInit();
            this.workPermitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayWorkPermitsForwardsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayWorkPermitsBackwardsTextBox)).BeginInit();
            this.permitRequestPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayPermitRequestsForwardsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayPermitRequestsBackwardsTextBox)).BeginInit();
            this.documentSuggestionFormsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDocumentSuggestionFormsForwardsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox)).BeginInit();
            this.directivesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDirectivesForwardsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDirectivesBackwardsTextBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.electronicFormsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayElectronicFormsForwardsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayElectronicFormsBackwardsTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // siteDisplayLabel
            // 
            resources.ApplyResources(this.siteDisplayLabel, "siteDisplayLabel");
            this.siteDisplayLabel.Name = "siteDisplayLabel";
            // 
            // actionItemPrefixLabel
            // 
            resources.ApplyResources(this.actionItemPrefixLabel, "actionItemPrefixLabel");
            this.actionItemPrefixLabel.Name = "actionItemPrefixLabel";
            // 
            // actionItemSuffixLabel
            // 
            resources.ApplyResources(this.actionItemSuffixLabel, "actionItemSuffixLabel");
            this.actionItemSuffixLabel.Name = "actionItemSuffixLabel";
            // 
            // shiftLogSuffixLabel
            // 
            resources.ApplyResources(this.shiftLogSuffixLabel, "shiftLogSuffixLabel");
            this.shiftLogSuffixLabel.Name = "shiftLogSuffixLabel";
            // 
            // shiftLogPrefixLabel
            // 
            resources.ApplyResources(this.shiftLogPrefixLabel, "shiftLogPrefixLabel");
            this.shiftLogPrefixLabel.Name = "shiftLogPrefixLabel";
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
            // daysToDisplayActionItemsTextBox
            // 
            this.daysToDisplayActionItemsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayActionItemsTextBox, "daysToDisplayActionItemsTextBox");
            this.daysToDisplayActionItemsTextBox.MaskInput = "nnn";
            this.daysToDisplayActionItemsTextBox.Name = "daysToDisplayActionItemsTextBox";
            this.daysToDisplayActionItemsTextBox.Nullable = true;
            this.daysToDisplayActionItemsTextBox.NullText = "0";
            this.daysToDisplayActionItemsTextBox.PromptChar = ' ';
            // 
            // daysToDisplayShiftHandoversTextBox
            // 
            this.daysToDisplayShiftHandoversTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayShiftHandoversTextBox, "daysToDisplayShiftHandoversTextBox");
            this.daysToDisplayShiftHandoversTextBox.MaskInput = "nnn";
            this.daysToDisplayShiftHandoversTextBox.Name = "daysToDisplayShiftHandoversTextBox";
            this.daysToDisplayShiftHandoversTextBox.Nullable = true;
            this.daysToDisplayShiftHandoversTextBox.NullText = "0";
            this.daysToDisplayShiftHandoversTextBox.PromptChar = ' ';
            // 
            // itemCountErrorProvider
            // 
            this.itemCountErrorProvider.ContainerControl = this;
            // 
            // siteGroupBox
            // 
            this.siteGroupBox.Controls.Add(this.siteDisplayLabel);
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // displayLimitsGroupBox
            // 
            resources.ApplyResources(this.displayLimitsGroupBox, "displayLimitsGroupBox");
            this.displayLimitsGroupBox.Controls.Add(this.flowLayoutPanel);
            this.displayLimitsGroupBox.Name = "displayLimitsGroupBox";
            this.displayLimitsGroupBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.Controls.Add(this.actionItemPanel);
            this.flowLayoutPanel.Controls.Add(this.cokerCardPanel);
            this.flowLayoutPanel.Controls.Add(this.deviationPanel);
            this.flowLayoutPanel.Controls.Add(this.labAlertPanel);
            this.flowLayoutPanel.Controls.Add(this.shiftHandoverPanel);
            this.flowLayoutPanel.Controls.Add(this.shiftLogsPanel);
            this.flowLayoutPanel.Controls.Add(this.sapNotificationsPanel);
            this.flowLayoutPanel.Controls.Add(this.eventsConfigurationPanel);
            this.flowLayoutPanel.Controls.Add(this.workPermitPanel);
            this.flowLayoutPanel.Controls.Add(this.permitRequestPanel);
            this.flowLayoutPanel.Controls.Add(this.electronicFormsPanel);
            this.flowLayoutPanel.Controls.Add(this.documentSuggestionFormsPanel);
            this.flowLayoutPanel.Controls.Add(this.directivesPanel);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // actionItemPanel
            // 
            this.actionItemPanel.Controls.Add(this.actionItemPrefixLabel);
            this.actionItemPanel.Controls.Add(this.actionItemSuffixLabel);
            this.actionItemPanel.Controls.Add(this.daysToDisplayActionItemsTextBox);
            resources.ApplyResources(this.actionItemPanel, "actionItemPanel");
            this.actionItemPanel.Name = "actionItemPanel";
            // 
            // cokerCardPanel
            // 
            this.cokerCardPanel.Controls.Add(this.cokerCardsPrefixLabel);
            this.cokerCardPanel.Controls.Add(this.cokerCardsSuffixLabel);
            this.cokerCardPanel.Controls.Add(this.daysToDisplayCokerCardsTextBox);
            resources.ApplyResources(this.cokerCardPanel, "cokerCardPanel");
            this.cokerCardPanel.Name = "cokerCardPanel";
            // 
            // cokerCardsPrefixLabel
            // 
            resources.ApplyResources(this.cokerCardsPrefixLabel, "cokerCardsPrefixLabel");
            this.cokerCardsPrefixLabel.Name = "cokerCardsPrefixLabel";
            // 
            // cokerCardsSuffixLabel
            // 
            resources.ApplyResources(this.cokerCardsSuffixLabel, "cokerCardsSuffixLabel");
            this.cokerCardsSuffixLabel.Name = "cokerCardsSuffixLabel";
            // 
            // daysToDisplayCokerCardsTextBox
            // 
            this.daysToDisplayCokerCardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayCokerCardsTextBox, "daysToDisplayCokerCardsTextBox");
            this.daysToDisplayCokerCardsTextBox.MaskInput = "nnn";
            this.daysToDisplayCokerCardsTextBox.Name = "daysToDisplayCokerCardsTextBox";
            this.daysToDisplayCokerCardsTextBox.Nullable = true;
            this.daysToDisplayCokerCardsTextBox.NullText = "0";
            this.daysToDisplayCokerCardsTextBox.PromptChar = ' ';
            // 
            // deviationPanel
            // 
            this.deviationPanel.Controls.Add(this.label3);
            this.deviationPanel.Controls.Add(this.label4);
            this.deviationPanel.Controls.Add(this.daysToDisplayDeviationAlertsTextBox);
            resources.ApplyResources(this.deviationPanel, "deviationPanel");
            this.deviationPanel.Name = "deviationPanel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // daysToDisplayDeviationAlertsTextBox
            // 
            this.daysToDisplayDeviationAlertsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDeviationAlertsTextBox, "daysToDisplayDeviationAlertsTextBox");
            this.daysToDisplayDeviationAlertsTextBox.MaskInput = "nnn";
            this.daysToDisplayDeviationAlertsTextBox.Name = "daysToDisplayDeviationAlertsTextBox";
            this.daysToDisplayDeviationAlertsTextBox.Nullable = true;
            this.daysToDisplayDeviationAlertsTextBox.NullText = "0";
            this.daysToDisplayDeviationAlertsTextBox.PromptChar = ' ';
            // 
            // labAlertPanel
            // 
            this.labAlertPanel.Controls.Add(this.label7);
            this.labAlertPanel.Controls.Add(this.daysToDisplayLabAlertsTextBox);
            this.labAlertPanel.Controls.Add(this.label8);
            resources.ApplyResources(this.labAlertPanel, "labAlertPanel");
            this.labAlertPanel.Name = "labAlertPanel";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // daysToDisplayLabAlertsTextBox
            // 
            this.daysToDisplayLabAlertsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayLabAlertsTextBox, "daysToDisplayLabAlertsTextBox");
            this.daysToDisplayLabAlertsTextBox.MaskInput = "nnn";
            this.daysToDisplayLabAlertsTextBox.Name = "daysToDisplayLabAlertsTextBox";
            this.daysToDisplayLabAlertsTextBox.Nullable = true;
            this.daysToDisplayLabAlertsTextBox.NullText = "0";
            this.daysToDisplayLabAlertsTextBox.PromptChar = ' ';
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // shiftHandoverPanel
            // 
            this.shiftHandoverPanel.Controls.Add(this.shiftLogPrefixLabel);
            this.shiftHandoverPanel.Controls.Add(this.shiftLogSuffixLabel);
            this.shiftHandoverPanel.Controls.Add(this.daysToDisplayShiftHandoversTextBox);
            resources.ApplyResources(this.shiftHandoverPanel, "shiftHandoverPanel");
            this.shiftHandoverPanel.Name = "shiftHandoverPanel";
            // 
            // shiftLogsPanel
            // 
            this.shiftLogsPanel.Controls.Add(this.label1);
            this.shiftLogsPanel.Controls.Add(this.label2);
            this.shiftLogsPanel.Controls.Add(this.daysToDisplayShiftLogsTextBox);
            resources.ApplyResources(this.shiftLogsPanel, "shiftLogsPanel");
            this.shiftLogsPanel.Name = "shiftLogsPanel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // daysToDisplayShiftLogsTextBox
            // 
            this.daysToDisplayShiftLogsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayShiftLogsTextBox, "daysToDisplayShiftLogsTextBox");
            this.daysToDisplayShiftLogsTextBox.MaskInput = "nnn";
            this.daysToDisplayShiftLogsTextBox.Name = "daysToDisplayShiftLogsTextBox";
            this.daysToDisplayShiftLogsTextBox.Nullable = true;
            this.daysToDisplayShiftLogsTextBox.NullText = "0";
            this.daysToDisplayShiftLogsTextBox.PromptChar = ' ';
            // 
            // sapNotificationsPanel
            // 
            this.sapNotificationsPanel.Controls.Add(this.label17);
            this.sapNotificationsPanel.Controls.Add(this.label18);
            this.sapNotificationsPanel.Controls.Add(this.daysToDisplaySAPNotificationsTextBox);
            resources.ApplyResources(this.sapNotificationsPanel, "sapNotificationsPanel");
            this.sapNotificationsPanel.Name = "sapNotificationsPanel";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // daysToDisplaySAPNotificationsTextBox
            // 
            this.daysToDisplaySAPNotificationsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplaySAPNotificationsTextBox, "daysToDisplaySAPNotificationsTextBox");
            this.daysToDisplaySAPNotificationsTextBox.MaskInput = "nnn";
            this.daysToDisplaySAPNotificationsTextBox.Name = "daysToDisplaySAPNotificationsTextBox";
            this.daysToDisplaySAPNotificationsTextBox.Nullable = true;
            this.daysToDisplaySAPNotificationsTextBox.NullText = "0";
            this.daysToDisplaySAPNotificationsTextBox.PromptChar = ' ';
            // 
            // eventsConfigurationPanel
            // 
            this.eventsConfigurationPanel.Controls.Add(this.label23);
            this.eventsConfigurationPanel.Controls.Add(this.label24);
            this.eventsConfigurationPanel.Controls.Add(this.daysToDisplayEventsTextBox);
            resources.ApplyResources(this.eventsConfigurationPanel, "eventsConfigurationPanel");
            this.eventsConfigurationPanel.Name = "eventsConfigurationPanel";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // daysToDisplayEventsTextBox
            // 
            this.daysToDisplayEventsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayEventsTextBox, "daysToDisplayEventsTextBox");
            this.daysToDisplayEventsTextBox.MaskInput = "nnn";
            this.daysToDisplayEventsTextBox.Name = "daysToDisplayEventsTextBox";
            this.daysToDisplayEventsTextBox.Nullable = true;
            this.daysToDisplayEventsTextBox.NullText = "0";
            this.daysToDisplayEventsTextBox.PromptChar = ' ';
            // 
            // workPermitPanel
            // 
            this.workPermitPanel.Controls.Add(this.label12);
            this.workPermitPanel.Controls.Add(this.daysToDisplayWorkPermitsForwardsTextBox);
            this.workPermitPanel.Controls.Add(this.label5);
            this.workPermitPanel.Controls.Add(this.label6);
            this.workPermitPanel.Controls.Add(this.daysToDisplayWorkPermitsBackwardsTextBox);
            resources.ApplyResources(this.workPermitPanel, "workPermitPanel");
            this.workPermitPanel.Name = "workPermitPanel";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // daysToDisplayWorkPermitsForwardsTextBox
            // 
            this.daysToDisplayWorkPermitsForwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayWorkPermitsForwardsTextBox, "daysToDisplayWorkPermitsForwardsTextBox");
            this.daysToDisplayWorkPermitsForwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayWorkPermitsForwardsTextBox.Name = "daysToDisplayWorkPermitsForwardsTextBox";
            this.daysToDisplayWorkPermitsForwardsTextBox.Nullable = true;
            this.daysToDisplayWorkPermitsForwardsTextBox.NullText = "0";
            this.daysToDisplayWorkPermitsForwardsTextBox.PromptChar = ' ';
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // daysToDisplayWorkPermitsBackwardsTextBox
            // 
            this.daysToDisplayWorkPermitsBackwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayWorkPermitsBackwardsTextBox, "daysToDisplayWorkPermitsBackwardsTextBox");
            this.daysToDisplayWorkPermitsBackwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayWorkPermitsBackwardsTextBox.Name = "daysToDisplayWorkPermitsBackwardsTextBox";
            this.daysToDisplayWorkPermitsBackwardsTextBox.Nullable = true;
            this.daysToDisplayWorkPermitsBackwardsTextBox.NullText = "0";
            this.daysToDisplayWorkPermitsBackwardsTextBox.PromptChar = ' ';
            // 
            // permitRequestPanel
            // 
            this.permitRequestPanel.Controls.Add(this.label9);
            this.permitRequestPanel.Controls.Add(this.label11);
            this.permitRequestPanel.Controls.Add(this.label10);
            this.permitRequestPanel.Controls.Add(this.daysToDisplayPermitRequestsForwardsTextBox);
            this.permitRequestPanel.Controls.Add(this.daysToDisplayPermitRequestsBackwardsTextBox);
            resources.ApplyResources(this.permitRequestPanel, "permitRequestPanel");
            this.permitRequestPanel.Name = "permitRequestPanel";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // daysToDisplayPermitRequestsForwardsTextBox
            // 
            this.daysToDisplayPermitRequestsForwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayPermitRequestsForwardsTextBox, "daysToDisplayPermitRequestsForwardsTextBox");
            this.daysToDisplayPermitRequestsForwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayPermitRequestsForwardsTextBox.Name = "daysToDisplayPermitRequestsForwardsTextBox";
            this.daysToDisplayPermitRequestsForwardsTextBox.Nullable = true;
            this.daysToDisplayPermitRequestsForwardsTextBox.NullText = "0";
            this.daysToDisplayPermitRequestsForwardsTextBox.PromptChar = ' ';
            // 
            // daysToDisplayPermitRequestsBackwardsTextBox
            // 
            this.daysToDisplayPermitRequestsBackwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayPermitRequestsBackwardsTextBox, "daysToDisplayPermitRequestsBackwardsTextBox");
            this.daysToDisplayPermitRequestsBackwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayPermitRequestsBackwardsTextBox.Name = "daysToDisplayPermitRequestsBackwardsTextBox";
            this.daysToDisplayPermitRequestsBackwardsTextBox.Nullable = true;
            this.daysToDisplayPermitRequestsBackwardsTextBox.NullText = "0";
            this.daysToDisplayPermitRequestsBackwardsTextBox.PromptChar = ' ';
            // 
            // documentSuggestionFormsPanel
            // 
            this.documentSuggestionFormsPanel.Controls.Add(this.label16);
            this.documentSuggestionFormsPanel.Controls.Add(this.label13);
            this.documentSuggestionFormsPanel.Controls.Add(this.label14);
            this.documentSuggestionFormsPanel.Controls.Add(this.label15);
            this.documentSuggestionFormsPanel.Controls.Add(this.daysToDisplayDocumentSuggestionFormsForwardsTextBox);
            this.documentSuggestionFormsPanel.Controls.Add(this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox);
            resources.ApplyResources(this.documentSuggestionFormsPanel, "documentSuggestionFormsPanel");
            this.documentSuggestionFormsPanel.Name = "documentSuggestionFormsPanel";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // daysToDisplayDocumentSuggestionFormsForwardsTextBox
            // 
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDocumentSuggestionFormsForwardsTextBox, "daysToDisplayDocumentSuggestionFormsForwardsTextBox");
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox.Name = "daysToDisplayDocumentSuggestionFormsForwardsTextBox";
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox.Nullable = true;
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox.NullText = "0";
            this.daysToDisplayDocumentSuggestionFormsForwardsTextBox.PromptChar = ' ';
            // 
            // daysToDisplayDocumentSuggestionFormsBackwardsTextBox
            // 
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox, "daysToDisplayDocumentSuggestionFormsBackwardsTextBox");
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox.Name = "daysToDisplayDocumentSuggestionFormsBackwardsTextBox";
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox.Nullable = true;
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox.NullText = "0";
            this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox.PromptChar = ' ';
            // 
            // directivesPanel
            // 
            this.directivesPanel.Controls.Add(this.daysToDisplayDirectivesForwardsTextBox);
            this.directivesPanel.Controls.Add(this.label22);
            this.directivesPanel.Controls.Add(this.label21);
            this.directivesPanel.Controls.Add(this.label20);
            this.directivesPanel.Controls.Add(this.daysToDisplayDirectivesBackwardsTextBox);
            this.directivesPanel.Controls.Add(this.label19);
            resources.ApplyResources(this.directivesPanel, "directivesPanel");
            this.directivesPanel.Name = "directivesPanel";
            // 
            // daysToDisplayDirectivesForwardsTextBox
            // 
            this.daysToDisplayDirectivesForwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDirectivesForwardsTextBox, "daysToDisplayDirectivesForwardsTextBox");
            this.daysToDisplayDirectivesForwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayDirectivesForwardsTextBox.Name = "daysToDisplayDirectivesForwardsTextBox";
            this.daysToDisplayDirectivesForwardsTextBox.Nullable = true;
            this.daysToDisplayDirectivesForwardsTextBox.NullText = "0";
            this.daysToDisplayDirectivesForwardsTextBox.PromptChar = ' ';
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // daysToDisplayDirectivesBackwardsTextBox
            // 
            this.daysToDisplayDirectivesBackwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDirectivesBackwardsTextBox, "daysToDisplayDirectivesBackwardsTextBox");
            this.daysToDisplayDirectivesBackwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayDirectivesBackwardsTextBox.Name = "daysToDisplayDirectivesBackwardsTextBox";
            this.daysToDisplayDirectivesBackwardsTextBox.Nullable = true;
            this.daysToDisplayDirectivesBackwardsTextBox.NullText = "0";
            this.daysToDisplayDirectivesBackwardsTextBox.PromptChar = ' ';
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // electronicFormsPanel
            // 
            this.electronicFormsPanel.Controls.Add(this.label25);
            this.electronicFormsPanel.Controls.Add(this.label26);
            this.electronicFormsPanel.Controls.Add(this.label27);
            this.electronicFormsPanel.Controls.Add(this.label28);
            this.electronicFormsPanel.Controls.Add(this.daysToDisplayElectronicFormsForwardsTextBox);
            this.electronicFormsPanel.Controls.Add(this.daysToDisplayElectronicFormsBackwardsTextBox);
            resources.ApplyResources(this.electronicFormsPanel, "electronicFormsPanel");
            this.electronicFormsPanel.Name = "electronicFormsPanel";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // daysToDisplayElectronicFormsForwardsTextBox
            // 
            this.daysToDisplayElectronicFormsForwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayElectronicFormsForwardsTextBox, "daysToDisplayElectronicFormsForwardsTextBox");
            this.daysToDisplayElectronicFormsForwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayElectronicFormsForwardsTextBox.Name = "daysToDisplayElectronicFormsForwardsTextBox";
            this.daysToDisplayElectronicFormsForwardsTextBox.Nullable = true;
            this.daysToDisplayElectronicFormsForwardsTextBox.NullText = "0";
            this.daysToDisplayElectronicFormsForwardsTextBox.PromptChar = ' ';
            // 
            // daysToDisplayElectronicFormsBackwardsTextBox
            // 
            this.daysToDisplayElectronicFormsBackwardsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayElectronicFormsBackwardsTextBox, "daysToDisplayElectronicFormsBackwardsTextBox");
            this.daysToDisplayElectronicFormsBackwardsTextBox.MaskInput = "nnn";
            this.daysToDisplayElectronicFormsBackwardsTextBox.Name = "daysToDisplayElectronicFormsBackwardsTextBox";
            this.daysToDisplayElectronicFormsBackwardsTextBox.Nullable = true;
            this.daysToDisplayElectronicFormsBackwardsTextBox.NullText = "0";
            this.daysToDisplayElectronicFormsBackwardsTextBox.PromptChar = ' ';
            // 
            // ConfigureDisplayLimitsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.displayLimitsGroupBox);
            this.Controls.Add(this.siteGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigureDisplayLimitsForm";
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayActionItemsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayShiftHandoversTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCountErrorProvider)).EndInit();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.displayLimitsGroupBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.actionItemPanel.ResumeLayout(false);
            this.actionItemPanel.PerformLayout();
            this.cokerCardPanel.ResumeLayout(false);
            this.cokerCardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayCokerCardsTextBox)).EndInit();
            this.deviationPanel.ResumeLayout(false);
            this.deviationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDeviationAlertsTextBox)).EndInit();
            this.labAlertPanel.ResumeLayout(false);
            this.labAlertPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayLabAlertsTextBox)).EndInit();
            this.shiftHandoverPanel.ResumeLayout(false);
            this.shiftHandoverPanel.PerformLayout();
            this.shiftLogsPanel.ResumeLayout(false);
            this.shiftLogsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayShiftLogsTextBox)).EndInit();
            this.sapNotificationsPanel.ResumeLayout(false);
            this.sapNotificationsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplaySAPNotificationsTextBox)).EndInit();
            this.eventsConfigurationPanel.ResumeLayout(false);
            this.eventsConfigurationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayEventsTextBox)).EndInit();
            this.workPermitPanel.ResumeLayout(false);
            this.workPermitPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayWorkPermitsForwardsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayWorkPermitsBackwardsTextBox)).EndInit();
            this.permitRequestPanel.ResumeLayout(false);
            this.permitRequestPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayPermitRequestsForwardsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayPermitRequestsBackwardsTextBox)).EndInit();
            this.documentSuggestionFormsPanel.ResumeLayout(false);
            this.documentSuggestionFormsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDocumentSuggestionFormsForwardsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDocumentSuggestionFormsBackwardsTextBox)).EndInit();
            this.directivesPanel.ResumeLayout(false);
            this.directivesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDirectivesForwardsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDirectivesBackwardsTextBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.electronicFormsPanel.ResumeLayout(false);
            this.electronicFormsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayElectronicFormsForwardsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayElectronicFormsBackwardsTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label siteDisplayLabel;
        private System.Windows.Forms.Label actionItemPrefixLabel;
        private System.Windows.Forms.Label actionItemSuffixLabel;
        private System.Windows.Forms.Label shiftLogSuffixLabel;
        private System.Windows.Forms.Label shiftLogPrefixLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private OltUltraNumericEditor daysToDisplayActionItemsTextBox;
        private OltUltraNumericEditor daysToDisplayShiftHandoversTextBox;
        private System.Windows.Forms.ErrorProvider itemCountErrorProvider;
        private System.Windows.Forms.GroupBox displayLimitsGroupBox;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private OltUltraNumericEditor daysToDisplayShiftLogsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private OltUltraNumericEditor daysToDisplayDeviationAlertsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private OltUltraNumericEditor daysToDisplayWorkPermitsBackwardsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private OltUltraNumericEditor daysToDisplayLabAlertsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private OltUltraNumericEditor daysToDisplayCokerCardsTextBox;
        private System.Windows.Forms.Label cokerCardsPrefixLabel;
        private System.Windows.Forms.Label cokerCardsSuffixLabel;
        private System.Windows.Forms.Label label11;
        private OltUltraNumericEditor daysToDisplayPermitRequestsForwardsTextBox;
        private OltUltraNumericEditor daysToDisplayPermitRequestsBackwardsTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private OltPanel actionItemPanel;
        private OltPanel cokerCardPanel;
        private OltPanel deviationPanel;
        private OltPanel labAlertPanel;
        private OltPanel shiftHandoverPanel;
        private OltPanel shiftLogsPanel;
        private OltPanel workPermitPanel;
        private OltPanel permitRequestPanel;
        private OltUltraNumericEditor daysToDisplayWorkPermitsForwardsTextBox;
        private System.Windows.Forms.Label label12;
        private OltPanel documentSuggestionFormsPanel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private OltUltraNumericEditor daysToDisplayDocumentSuggestionFormsForwardsTextBox;
        private OltUltraNumericEditor daysToDisplayDocumentSuggestionFormsBackwardsTextBox;
        private OltPanel sapNotificationsPanel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private OltUltraNumericEditor daysToDisplaySAPNotificationsTextBox;
        private System.Windows.Forms.Panel panel1;
        private OltPanel directivesPanel;
        private System.Windows.Forms.Label label20;
        private OltUltraNumericEditor daysToDisplayDirectivesBackwardsTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private OltUltraNumericEditor daysToDisplayDirectivesForwardsTextBox;
        private OltPanel eventsConfigurationPanel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private OltUltraNumericEditor daysToDisplayEventsTextBox;
        private OltPanel electronicFormsPanel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private OltUltraNumericEditor daysToDisplayElectronicFormsForwardsTextBox;
        private OltUltraNumericEditor daysToDisplayElectronicFormsBackwardsTextBox;
    }
}
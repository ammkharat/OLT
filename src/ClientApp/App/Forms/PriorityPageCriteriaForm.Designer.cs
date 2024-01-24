using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class PriorityPageCriteriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriorityPageCriteriaForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.daysToDisplayIncompleteActionItemsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.displayIncompleteActionItemsFromXDaysAgoRadioButton = new System.Windows.Forms.RadioButton();
            this.displayIncompleteActionItemsFromPreviousShiftRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.actionItemByWorkAssignmentAndFlocRadioButton = new System.Windows.Forms.RadioButton();
            this.actionItemByFlocRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.displayActionItemWorkAssignmentCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.siteDisplayLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.daysToDisplayShiftHandoversTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.directivesPrefixLabel = new System.Windows.Forms.Label();
            this.daysOfRecentDirectivesLabel = new System.Windows.Forms.Label();
            this.daysToDisplayDirectivesTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.shiftHandoverPrefixLabel = new System.Windows.Forms.Label();
            this.daysOfRecentShiftHandoversLabel = new System.Windows.Forms.Label();
            this.directiveLogsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.handoverByWorkAssignmentAndFlocRadioButton = new System.Windows.Forms.RadioButton();
            this.handoverByFlocRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.itemCountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.invisibleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.electronicFormsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.daysToDisplayFormsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.excursionEventsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.maximumAllowableExcursionEventTimeframeMinsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.maximumAllowableExcursionEventDurationMinsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.documentSuggestionsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.daysToDisplayDocumentSuggestionsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayIncompleteActionItemsTextBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayShiftHandoversTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDirectivesTextBox)).BeginInit();
            this.directiveLogsGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemCountErrorProvider)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.electronicFormsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayFormsTextBox)).BeginInit();
            this.excursionEventsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumAllowableExcursionEventTimeframeMinsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumAllowableExcursionEventDurationMinsTextBox)).BeginInit();
            this.documentSuggestionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDocumentSuggestionsTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.displayActionItemWorkAssignmentCheckBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.daysToDisplayIncompleteActionItemsTextBox);
            this.panel3.Controls.Add(this.displayIncompleteActionItemsFromXDaysAgoRadioButton);
            this.panel3.Controls.Add(this.displayIncompleteActionItemsFromPreviousShiftRadioButton);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // daysToDisplayIncompleteActionItemsTextBox
            // 
            this.daysToDisplayIncompleteActionItemsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayIncompleteActionItemsTextBox, "daysToDisplayIncompleteActionItemsTextBox");
            this.daysToDisplayIncompleteActionItemsTextBox.MaskInput = "nnn";
            this.daysToDisplayIncompleteActionItemsTextBox.Name = "daysToDisplayIncompleteActionItemsTextBox";
            this.daysToDisplayIncompleteActionItemsTextBox.Nullable = true;
            this.daysToDisplayIncompleteActionItemsTextBox.NullText = "0";
            this.daysToDisplayIncompleteActionItemsTextBox.PromptChar = ' ';
            // 
            // displayIncompleteActionItemsFromXDaysAgoRadioButton
            // 
            resources.ApplyResources(this.displayIncompleteActionItemsFromXDaysAgoRadioButton, "displayIncompleteActionItemsFromXDaysAgoRadioButton");
            this.displayIncompleteActionItemsFromXDaysAgoRadioButton.Name = "displayIncompleteActionItemsFromXDaysAgoRadioButton";
            this.displayIncompleteActionItemsFromXDaysAgoRadioButton.UseVisualStyleBackColor = true;
            // 
            // displayIncompleteActionItemsFromPreviousShiftRadioButton
            // 
            resources.ApplyResources(this.displayIncompleteActionItemsFromPreviousShiftRadioButton, "displayIncompleteActionItemsFromPreviousShiftRadioButton");
            this.displayIncompleteActionItemsFromPreviousShiftRadioButton.Checked = true;
            this.displayIncompleteActionItemsFromPreviousShiftRadioButton.Name = "displayIncompleteActionItemsFromPreviousShiftRadioButton";
            this.displayIncompleteActionItemsFromPreviousShiftRadioButton.TabStop = true;
            this.displayIncompleteActionItemsFromPreviousShiftRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.actionItemByWorkAssignmentAndFlocRadioButton);
            this.panel1.Controls.Add(this.actionItemByFlocRadioButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // actionItemByWorkAssignmentAndFlocRadioButton
            // 
            resources.ApplyResources(this.actionItemByWorkAssignmentAndFlocRadioButton, "actionItemByWorkAssignmentAndFlocRadioButton");
            this.actionItemByWorkAssignmentAndFlocRadioButton.Name = "actionItemByWorkAssignmentAndFlocRadioButton";
            this.actionItemByWorkAssignmentAndFlocRadioButton.UseVisualStyleBackColor = true;
            // 
            // actionItemByFlocRadioButton
            // 
            resources.ApplyResources(this.actionItemByFlocRadioButton, "actionItemByFlocRadioButton");
            this.actionItemByFlocRadioButton.Checked = true;
            this.actionItemByFlocRadioButton.Name = "actionItemByFlocRadioButton";
            this.actionItemByFlocRadioButton.TabStop = true;
            this.actionItemByFlocRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // displayActionItemWorkAssignmentCheckBox
            // 
            resources.ApplyResources(this.displayActionItemWorkAssignmentCheckBox, "displayActionItemWorkAssignmentCheckBox");
            this.displayActionItemWorkAssignmentCheckBox.Name = "displayActionItemWorkAssignmentCheckBox";
            this.displayActionItemWorkAssignmentCheckBox.UseVisualStyleBackColor = true;
            this.displayActionItemWorkAssignmentCheckBox.Value = null;
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
            // directivesPrefixLabel
            // 
            resources.ApplyResources(this.directivesPrefixLabel, "directivesPrefixLabel");
            this.directivesPrefixLabel.Name = "directivesPrefixLabel";
            // 
            // daysOfRecentDirectivesLabel
            // 
            resources.ApplyResources(this.daysOfRecentDirectivesLabel, "daysOfRecentDirectivesLabel");
            this.daysOfRecentDirectivesLabel.Name = "daysOfRecentDirectivesLabel";
            // 
            // daysToDisplayDirectivesTextBox
            // 
            this.daysToDisplayDirectivesTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDirectivesTextBox, "daysToDisplayDirectivesTextBox");
            this.daysToDisplayDirectivesTextBox.MaskInput = "nnn";
            this.daysToDisplayDirectivesTextBox.Name = "daysToDisplayDirectivesTextBox";
            this.daysToDisplayDirectivesTextBox.Nullable = true;
            this.daysToDisplayDirectivesTextBox.NullText = "0";
            this.daysToDisplayDirectivesTextBox.PromptChar = ' ';
            // 
            // shiftHandoverPrefixLabel
            // 
            resources.ApplyResources(this.shiftHandoverPrefixLabel, "shiftHandoverPrefixLabel");
            this.shiftHandoverPrefixLabel.Name = "shiftHandoverPrefixLabel";
            // 
            // daysOfRecentShiftHandoversLabel
            // 
            resources.ApplyResources(this.daysOfRecentShiftHandoversLabel, "daysOfRecentShiftHandoversLabel");
            this.daysOfRecentShiftHandoversLabel.Name = "daysOfRecentShiftHandoversLabel";
            // 
            // directiveLogsGroupBox
            // 
            resources.ApplyResources(this.directiveLogsGroupBox, "directiveLogsGroupBox");
            this.directiveLogsGroupBox.Controls.Add(this.daysToDisplayDirectivesTextBox);
            this.directiveLogsGroupBox.Controls.Add(this.daysOfRecentDirectivesLabel);
            this.directiveLogsGroupBox.Controls.Add(this.directivesPrefixLabel);
            this.directiveLogsGroupBox.Name = "directiveLogsGroupBox";
            this.directiveLogsGroupBox.TabStop = false;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.daysToDisplayShiftHandoversTextBox);
            this.groupBox3.Controls.Add(this.daysOfRecentShiftHandoversLabel);
            this.groupBox3.Controls.Add(this.shiftHandoverPrefixLabel);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.handoverByWorkAssignmentAndFlocRadioButton);
            this.panel2.Controls.Add(this.handoverByFlocRadioButton);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // handoverByWorkAssignmentAndFlocRadioButton
            // 
            resources.ApplyResources(this.handoverByWorkAssignmentAndFlocRadioButton, "handoverByWorkAssignmentAndFlocRadioButton");
            this.handoverByWorkAssignmentAndFlocRadioButton.Name = "handoverByWorkAssignmentAndFlocRadioButton";
            this.handoverByWorkAssignmentAndFlocRadioButton.UseVisualStyleBackColor = true;
            // 
            // handoverByFlocRadioButton
            // 
            resources.ApplyResources(this.handoverByFlocRadioButton, "handoverByFlocRadioButton");
            this.handoverByFlocRadioButton.Checked = true;
            this.handoverByFlocRadioButton.Name = "handoverByFlocRadioButton";
            this.handoverByFlocRadioButton.TabStop = true;
            this.handoverByFlocRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // itemCountErrorProvider
            // 
            this.itemCountErrorProvider.ContainerControl = this;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.invisibleLabel);
            this.mainPanel.Controls.Add(this.siteGroupBox);
            this.mainPanel.Controls.Add(this.directiveLogsGroupBox);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.groupBox3);
            this.mainPanel.Controls.Add(this.electronicFormsGroupBox);
            this.mainPanel.Controls.Add(this.excursionEventsGroupBox);
            this.mainPanel.Controls.Add(this.documentSuggestionsGroupBox);
            this.mainPanel.Name = "mainPanel";
            // 
            // invisibleLabel
            // 
            resources.ApplyResources(this.invisibleLabel, "invisibleLabel");
            this.invisibleLabel.Name = "invisibleLabel";
            // 
            // electronicFormsGroupBox
            // 
            resources.ApplyResources(this.electronicFormsGroupBox, "electronicFormsGroupBox");
            this.electronicFormsGroupBox.Controls.Add(this.daysToDisplayFormsTextBox);
            this.electronicFormsGroupBox.Controls.Add(this.label6);
            this.electronicFormsGroupBox.Controls.Add(this.label7);
            this.electronicFormsGroupBox.Name = "electronicFormsGroupBox";
            this.electronicFormsGroupBox.TabStop = false;
            // 
            // daysToDisplayFormsTextBox
            // 
            this.daysToDisplayFormsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayFormsTextBox, "daysToDisplayFormsTextBox");
            this.daysToDisplayFormsTextBox.MaskInput = "nnn";
            this.daysToDisplayFormsTextBox.Name = "daysToDisplayFormsTextBox";
            this.daysToDisplayFormsTextBox.Nullable = true;
            this.daysToDisplayFormsTextBox.NullText = "0";
            this.daysToDisplayFormsTextBox.PromptChar = ' ';
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // excursionEventsGroupBox
            // 
            resources.ApplyResources(this.excursionEventsGroupBox, "excursionEventsGroupBox");
            this.excursionEventsGroupBox.Controls.Add(this.maximumAllowableExcursionEventTimeframeMinsTextBox);
            this.excursionEventsGroupBox.Controls.Add(this.label8);
            this.excursionEventsGroupBox.Controls.Add(this.label9);
            this.excursionEventsGroupBox.Controls.Add(this.maximumAllowableExcursionEventDurationMinsTextBox);
            this.excursionEventsGroupBox.Controls.Add(this.label3);
            this.excursionEventsGroupBox.Controls.Add(this.label4);
            this.excursionEventsGroupBox.Name = "excursionEventsGroupBox";
            this.excursionEventsGroupBox.TabStop = false;
            // 
            // maximumAllowableExcursionEventTimeframeMinsTextBox
            // 
            this.maximumAllowableExcursionEventTimeframeMinsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.maximumAllowableExcursionEventTimeframeMinsTextBox, "maximumAllowableExcursionEventTimeframeMinsTextBox");
            this.maximumAllowableExcursionEventTimeframeMinsTextBox.MaskInput = "nnnnn";
            this.maximumAllowableExcursionEventTimeframeMinsTextBox.Name = "maximumAllowableExcursionEventTimeframeMinsTextBox";
            this.maximumAllowableExcursionEventTimeframeMinsTextBox.Nullable = true;
            this.maximumAllowableExcursionEventTimeframeMinsTextBox.NullText = "0";
            this.maximumAllowableExcursionEventTimeframeMinsTextBox.PromptChar = ' ';
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // maximumAllowableExcursionEventDurationMinsTextBox
            // 
            this.maximumAllowableExcursionEventDurationMinsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.maximumAllowableExcursionEventDurationMinsTextBox, "maximumAllowableExcursionEventDurationMinsTextBox");
            this.maximumAllowableExcursionEventDurationMinsTextBox.MaskInput = "nnnnn";
            this.maximumAllowableExcursionEventDurationMinsTextBox.Name = "maximumAllowableExcursionEventDurationMinsTextBox";
            this.maximumAllowableExcursionEventDurationMinsTextBox.Nullable = true;
            this.maximumAllowableExcursionEventDurationMinsTextBox.NullText = "0";
            this.maximumAllowableExcursionEventDurationMinsTextBox.PromptChar = ' ';
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
            // documentSuggestionsGroupBox
            // 
            resources.ApplyResources(this.documentSuggestionsGroupBox, "documentSuggestionsGroupBox");
            this.documentSuggestionsGroupBox.Controls.Add(this.daysToDisplayDocumentSuggestionsTextBox);
            this.documentSuggestionsGroupBox.Controls.Add(this.label10);
            this.documentSuggestionsGroupBox.Controls.Add(this.label11);
            this.documentSuggestionsGroupBox.Name = "documentSuggestionsGroupBox";
            this.documentSuggestionsGroupBox.TabStop = false;
            // 
            // daysToDisplayDocumentSuggestionsTextBox
            // 
            this.daysToDisplayDocumentSuggestionsTextBox.AlwaysInEditMode = true;
            resources.ApplyResources(this.daysToDisplayDocumentSuggestionsTextBox, "daysToDisplayDocumentSuggestionsTextBox");
            this.daysToDisplayDocumentSuggestionsTextBox.MaskInput = "nnn";
            this.daysToDisplayDocumentSuggestionsTextBox.Name = "daysToDisplayDocumentSuggestionsTextBox";
            this.daysToDisplayDocumentSuggestionsTextBox.Nullable = true;
            this.daysToDisplayDocumentSuggestionsTextBox.NullText = "0";
            this.daysToDisplayDocumentSuggestionsTextBox.PromptChar = ' ';
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // PriorityPageCriteriaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "PriorityPageCriteriaForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayIncompleteActionItemsTextBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayShiftHandoversTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDirectivesTextBox)).EndInit();
            this.directiveLogsGroupBox.ResumeLayout(false);
            this.directiveLogsGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemCountErrorProvider)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.electronicFormsGroupBox.ResumeLayout(false);
            this.electronicFormsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayFormsTextBox)).EndInit();
            this.excursionEventsGroupBox.ResumeLayout(false);
            this.excursionEventsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumAllowableExcursionEventTimeframeMinsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumAllowableExcursionEventDurationMinsTextBox)).EndInit();
            this.documentSuggestionsGroupBox.ResumeLayout(false);
            this.documentSuggestionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysToDisplayDocumentSuggestionsTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private System.Windows.Forms.Label siteDisplayLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private OltUltraNumericEditor daysToDisplayShiftHandoversTextBox;
        private System.Windows.Forms.Label directivesPrefixLabel;
        private System.Windows.Forms.Label daysOfRecentDirectivesLabel;
        private OltUltraNumericEditor daysToDisplayDirectivesTextBox;
        private System.Windows.Forms.Label shiftHandoverPrefixLabel;
        private System.Windows.Forms.Label daysOfRecentShiftHandoversLabel;
        private System.Windows.Forms.GroupBox directiveLogsGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ErrorProvider itemCountErrorProvider;
        private OltCheckBox displayActionItemWorkAssignmentCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton actionItemByWorkAssignmentAndFlocRadioButton;
        private System.Windows.Forms.RadioButton actionItemByFlocRadioButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton handoverByWorkAssignmentAndFlocRadioButton;
        private System.Windows.Forms.RadioButton handoverByFlocRadioButton;
        private System.Windows.Forms.Label label2;
        private OltPanel buttonPanel;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private OltLabel invisibleLabel;
        private OltGroupBox excursionEventsGroupBox;
        private OltUltraNumericEditor maximumAllowableExcursionEventDurationMinsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton displayIncompleteActionItemsFromXDaysAgoRadioButton;
        private System.Windows.Forms.RadioButton displayIncompleteActionItemsFromPreviousShiftRadioButton;
        private System.Windows.Forms.Label label5;
        private OltUltraNumericEditor daysToDisplayIncompleteActionItemsTextBox;
        private OltGroupBox electronicFormsGroupBox;
        private OltUltraNumericEditor daysToDisplayFormsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private OltUltraNumericEditor maximumAllowableExcursionEventTimeframeMinsTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private OltGroupBox documentSuggestionsGroupBox;
        private OltUltraNumericEditor daysToDisplayDocumentSuggestionsTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
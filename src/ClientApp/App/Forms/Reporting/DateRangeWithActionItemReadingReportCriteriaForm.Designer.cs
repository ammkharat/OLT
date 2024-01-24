using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    partial class DateRangeWithActionItemReadingReportCriteriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangeWithActionItemReadingReportCriteriaForm));
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.runReportButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.actionItemsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.GrapgTypeCombo = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.oltRadioGraph = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.oltRadioExcel = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.ActionItemDefCombo = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.GetDefinitionsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.dateRangeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.buttonPanel.SuspendLayout();
            this.actionItemsGroupBox.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.dateRangeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.runReportButton);
            this.buttonPanel.Controls.Add(this.actionItemsGroupBox);
            this.buttonPanel.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // runReportButton
            // 
            resources.ApplyResources(this.runReportButton, "runReportButton");
            this.runReportButton.Name = "runReportButton";
            this.runReportButton.UseVisualStyleBackColor = true;
            // 
            // actionItemsGroupBox
            // 
            resources.ApplyResources(this.actionItemsGroupBox, "actionItemsGroupBox");
            this.actionItemsGroupBox.Controls.Add(this.oltGroupBox1);
            this.actionItemsGroupBox.Controls.Add(this.ActionItemDefCombo);
            this.actionItemsGroupBox.Name = "actionItemsGroupBox";
            this.actionItemsGroupBox.TabStop = false;
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.GrapgTypeCombo);
            this.oltGroupBox1.Controls.Add(this.oltRadioGraph);
            this.oltGroupBox1.Controls.Add(this.oltRadioExcel);
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // GrapgTypeCombo
            // 
            this.GrapgTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.GrapgTypeCombo, "GrapgTypeCombo");
            this.GrapgTypeCombo.FormattingEnabled = true;
            this.GrapgTypeCombo.Name = "GrapgTypeCombo";
            // 
            // oltRadioGraph
            // 
            resources.ApplyResources(this.oltRadioGraph, "oltRadioGraph");
            this.oltRadioGraph.Name = "oltRadioGraph";
            this.oltRadioGraph.UseVisualStyleBackColor = true;
            this.oltRadioGraph.CheckedChanged += new System.EventHandler(this.oltRadioGraph_CheckedChanged);
            // 
            // oltRadioExcel
            // 
            resources.ApplyResources(this.oltRadioExcel, "oltRadioExcel");
            this.oltRadioExcel.Checked = true;
            this.oltRadioExcel.Name = "oltRadioExcel";
            this.oltRadioExcel.TabStop = true;
            this.oltRadioExcel.UseVisualStyleBackColor = true;
            // 
            // ActionItemDefCombo
            // 
            this.ActionItemDefCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionItemDefCombo.FormattingEnabled = true;
            resources.ApplyResources(this.ActionItemDefCombo, "ActionItemDefCombo");
            this.ActionItemDefCombo.Name = "ActionItemDefCombo";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
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
            // startRangeDatePicker
            // 
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // endRangeDatePicker
            // 
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // GetDefinitionsButton
            // 
            resources.ApplyResources(this.GetDefinitionsButton, "GetDefinitionsButton");
            this.GetDefinitionsButton.Name = "GetDefinitionsButton";
            this.GetDefinitionsButton.UseVisualStyleBackColor = true;
            // 
            // dateRangeGroupBox
            // 
            this.dateRangeGroupBox.Controls.Add(this.GetDefinitionsButton);
            this.dateRangeGroupBox.Controls.Add(this.endRangeDatePicker);
            this.dateRangeGroupBox.Controls.Add(this.startRangeDatePicker);
            this.dateRangeGroupBox.Controls.Add(this.label2);
            this.dateRangeGroupBox.Controls.Add(this.label1);
            resources.ApplyResources(this.dateRangeGroupBox, "dateRangeGroupBox");
            this.dateRangeGroupBox.Name = "dateRangeGroupBox";
            this.dateRangeGroupBox.TabStop = false;
            // 
            // DateRangeWithActionItemReadingReportCriteriaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateRangeGroupBox);
            this.Controls.Add(this.buttonPanel);
            this.MaximizeBox = false;
            this.Name = "DateRangeWithActionItemReadingReportCriteriaForm";
            this.buttonPanel.ResumeLayout(false);
            this.actionItemsGroupBox.ResumeLayout(false);
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.dateRangeGroupBox.ResumeLayout(false);
            this.dateRangeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OltPanel buttonPanel;
        private OltButton runReportButton;
        private OltButton cancelButton;
        private OltGroupBox actionItemsGroupBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltComboBox ActionItemDefCombo;
        private OltGroupBox oltGroupBox1;
        private OltRadioButton oltRadioGraph;
        private OltRadioButton oltRadioExcel;
        private OltGroupBox dateRangeGroupBox;
        private OltButton GetDefinitionsButton;
        private OltDatePicker endRangeDatePicker;
        private OltDatePicker startRangeDatePicker;
        private OltLabel label2;
        private OltLabel label1;
        private OltComboBox GrapgTypeCombo;
    }
}
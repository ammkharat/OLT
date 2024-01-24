using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    partial class DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm));
            this.functionalLocationsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.runReportButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.dateRangeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endShiftComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.startShiftComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.label2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.workAssignmentGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.reportGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.dailyDirectiveCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.summaryLogCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.logCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateRangeAndReportTableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.functionalLocationsGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.dateRangeGroupBox.SuspendLayout();
            this.reportGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.dateRangeAndReportTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionalLocationsGroupBox
            // 
            resources.ApplyResources(this.functionalLocationsGroupBox, "functionalLocationsGroupBox");
            this.functionalLocationsGroupBox.Controls.Add(this.flocSelectionControl);
            this.functionalLocationsGroupBox.Name = "functionalLocationsGroupBox";
            this.functionalLocationsGroupBox.TabStop = false;
            // 
            // flocSelectionControl
            // 
            resources.ApplyResources(this.flocSelectionControl, "flocSelectionControl");
            this.flocSelectionControl.Name = "flocSelectionControl";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.runReportButton);
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
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // dateRangeGroupBox
            // 
            this.dateRangeGroupBox.Controls.Add(this.endShiftComboBox);
            this.dateRangeGroupBox.Controls.Add(this.startShiftComboBox);
            this.dateRangeGroupBox.Controls.Add(this.endRangeDatePicker);
            this.dateRangeGroupBox.Controls.Add(this.startRangeDatePicker);
            this.dateRangeGroupBox.Controls.Add(this.label2);
            this.dateRangeGroupBox.Controls.Add(this.label1);
            resources.ApplyResources(this.dateRangeGroupBox, "dateRangeGroupBox");
            this.dateRangeGroupBox.Name = "dateRangeGroupBox";
            this.dateRangeGroupBox.TabStop = false;
            // 
            // endShiftComboBox
            // 
            this.endShiftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endShiftComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.endShiftComboBox, "endShiftComboBox");
            this.endShiftComboBox.Name = "endShiftComboBox";
            // 
            // startShiftComboBox
            // 
            this.startShiftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startShiftComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.startShiftComboBox, "startShiftComboBox");
            this.startShiftComboBox.Name = "startShiftComboBox";
            // 
            // endRangeDatePicker
            // 
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // startRangeDatePicker
            // 
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // workAssignmentGroupBox
            // 
            resources.ApplyResources(this.workAssignmentGroupBox, "workAssignmentGroupBox");
            this.workAssignmentGroupBox.Name = "workAssignmentGroupBox";
            this.workAssignmentGroupBox.TabStop = false;
            // 
            // reportGroupBox
            // 
            this.reportGroupBox.Controls.Add(this.dailyDirectiveCheckBox);
            this.reportGroupBox.Controls.Add(this.summaryLogCheckBox);
            this.reportGroupBox.Controls.Add(this.logCheckBox);
            resources.ApplyResources(this.reportGroupBox, "reportGroupBox");
            this.reportGroupBox.Name = "reportGroupBox";
            this.reportGroupBox.TabStop = false;
            // 
            // dailyDirectiveCheckBox
            // 
            resources.ApplyResources(this.dailyDirectiveCheckBox, "dailyDirectiveCheckBox");
            this.dailyDirectiveCheckBox.Name = "dailyDirectiveCheckBox";
            this.dailyDirectiveCheckBox.UseVisualStyleBackColor = true;
            this.dailyDirectiveCheckBox.Value = null;
            // 
            // summaryLogCheckBox
            // 
            resources.ApplyResources(this.summaryLogCheckBox, "summaryLogCheckBox");
            this.summaryLogCheckBox.Name = "summaryLogCheckBox";
            this.summaryLogCheckBox.UseVisualStyleBackColor = true;
            this.summaryLogCheckBox.Value = null;
            // 
            // logCheckBox
            // 
            resources.ApplyResources(this.logCheckBox, "logCheckBox");
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.UseVisualStyleBackColor = true;
            this.logCheckBox.Value = null;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dateRangeAndReportTableLayoutPanel
            // 
            resources.ApplyResources(this.dateRangeAndReportTableLayoutPanel, "dateRangeAndReportTableLayoutPanel");
            this.dateRangeAndReportTableLayoutPanel.Controls.Add(this.dateRangeGroupBox, 0, 0);
            this.dateRangeAndReportTableLayoutPanel.Controls.Add(this.reportGroupBox, 1, 0);
            this.dateRangeAndReportTableLayoutPanel.Name = "dateRangeAndReportTableLayoutPanel";
            // 
            // DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateRangeAndReportTableLayoutPanel);
            this.Controls.Add(this.workAssignmentGroupBox);
            this.Controls.Add(this.functionalLocationsGroupBox);
            this.Controls.Add(this.buttonPanel);
            this.Name = "DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm";
            this.functionalLocationsGroupBox.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.dateRangeGroupBox.ResumeLayout(false);
            this.dateRangeGroupBox.PerformLayout();
            this.reportGroupBox.ResumeLayout(false);
            this.reportGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.dateRangeAndReportTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox functionalLocationsGroupBox;
        private Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltPanel buttonPanel;
        private OltButton runReportButton;
        private OltButton cancelButton;
        private OltGroupBox dateRangeGroupBox;
        private OltDatePicker endRangeDatePicker;
        private OltDatePicker startRangeDatePicker;
        private OltLabel label2;
        private OltLabel label1;
        private OltGroupBox workAssignmentGroupBox;
        private OltComboBox endShiftComboBox;
        private OltComboBox startShiftComboBox;
        private OltGroupBox reportGroupBox;
        private OltCheckBox dailyDirectiveCheckBox;
        private OltCheckBox summaryLogCheckBox;
        private OltCheckBox logCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltTableLayoutPanel dateRangeAndReportTableLayoutPanel;
    }
}
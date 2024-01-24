using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    partial class MarkedAsReadReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkedAsReadReportForm));
            this.runReportButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.groupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.label2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.groupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.reportGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flexishiftHandoverCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.directivesCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.summaryLogsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.shiftHandoverCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.logsCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.reportGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.endRangeDatePicker);
            this.groupBox1.Controls.Add(this.startRangeDatePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
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
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.runReportButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.flocSelectionControl);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // flocSelectionControl
            // 
            resources.ApplyResources(this.flocSelectionControl, "flocSelectionControl");
            this.flocSelectionControl.Name = "flocSelectionControl";
            // 
            // reportGroupBox
            // 
            resources.ApplyResources(this.reportGroupBox, "reportGroupBox");
            this.reportGroupBox.Controls.Add(this.flexishiftHandoverCheckBox);
            this.reportGroupBox.Controls.Add(this.directivesCheckBox);
            this.reportGroupBox.Controls.Add(this.summaryLogsCheckBox);
            this.reportGroupBox.Controls.Add(this.shiftHandoverCheckBox);
            this.reportGroupBox.Controls.Add(this.logsCheckBox);
            this.reportGroupBox.Name = "reportGroupBox";
            this.reportGroupBox.TabStop = false;
            // 
            // flexishiftHandoverCheckBox
            // 
            resources.ApplyResources(this.flexishiftHandoverCheckBox, "flexishiftHandoverCheckBox");
            this.flexishiftHandoverCheckBox.Name = "flexishiftHandoverCheckBox";
            this.flexishiftHandoverCheckBox.UseVisualStyleBackColor = true;
            this.flexishiftHandoverCheckBox.Value = null;
            // 
            // directivesCheckBox
            // 
            resources.ApplyResources(this.directivesCheckBox, "directivesCheckBox");
            this.directivesCheckBox.Name = "directivesCheckBox";
            this.directivesCheckBox.UseVisualStyleBackColor = true;
            this.directivesCheckBox.Value = null;
            // 
            // summaryLogsCheckBox
            // 
            resources.ApplyResources(this.summaryLogsCheckBox, "summaryLogsCheckBox");
            this.summaryLogsCheckBox.Name = "summaryLogsCheckBox";
            this.summaryLogsCheckBox.UseVisualStyleBackColor = true;
            this.summaryLogsCheckBox.Value = null;
            // 
            // shiftHandoverCheckBox
            // 
            resources.ApplyResources(this.shiftHandoverCheckBox, "shiftHandoverCheckBox");
            this.shiftHandoverCheckBox.Name = "shiftHandoverCheckBox";
            this.shiftHandoverCheckBox.UseVisualStyleBackColor = true;
            this.shiftHandoverCheckBox.Value = null;
            // 
            // logsCheckBox
            // 
            resources.ApplyResources(this.logsCheckBox, "logsCheckBox");
            this.logsCheckBox.Name = "logsCheckBox";
            this.logsCheckBox.UseVisualStyleBackColor = true;
            this.logsCheckBox.Value = null;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MarkedAsReadReportForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.reportGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.groupBox1);
            this.Name = "MarkedAsReadReportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.reportGroupBox.ResumeLayout(false);
            this.reportGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton runReportButton;
        private OltButton cancelButton;
        private OltGroupBox groupBox1;
        private OltLabel label1;
        private OltPanel buttonPanel;
        private OltLabel label2;
        private OltDatePicker startRangeDatePicker;
        private OltDatePicker endRangeDatePicker;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltGroupBox groupBox2;
        private Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltGroupBox reportGroupBox;
        private OltCheckBox shiftHandoverCheckBox;
        private OltCheckBox logsCheckBox;
        private OltCheckBox summaryLogsCheckBox;
        private OltCheckBox directivesCheckBox;
        private OltCheckBox flexishiftHandoverCheckBox;
    }
}
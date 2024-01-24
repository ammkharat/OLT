using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    partial class DailyShiftTargetAlertGapReasonReportParametersControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyShiftTargetAlertGapReasonReportParametersControl));
            this.startDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.endDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.shiftPatternListBox = new Com.Suncor.Olt.Client.OltControls.OltListBox();
            this.SuspendLayout();
            // 
            // startDatePicker
            // 
            resources.ApplyResources(this.startDatePicker, "startDatePicker");
            this.startDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.startDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.PickerEnabled = true;
            // 
            // endDatePicker
            // 
            resources.ApplyResources(this.endDatePicker, "endDatePicker");
            this.endDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.endDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.PickerEnabled = true;
            // 
            // startDateLabel
            // 
            resources.ApplyResources(this.startDateLabel, "startDateLabel");
            this.startDateLabel.Name = "startDateLabel";
            // 
            // endDateLabel
            // 
            resources.ApplyResources(this.endDateLabel, "endDateLabel");
            this.endDateLabel.Name = "endDateLabel";
            // 
            // shiftPatternListBox
            // 
            resources.ApplyResources(this.shiftPatternListBox, "shiftPatternListBox");
            this.shiftPatternListBox.BackColor = System.Drawing.Color.White;
            this.shiftPatternListBox.MultiColumn = true;
            this.shiftPatternListBox.Name = "shiftPatternListBox";
            this.shiftPatternListBox.ReadOnly = false;
            this.shiftPatternListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // DailyShiftTargetAlertGapReasonReportParametersControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shiftPatternListBox);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Name = "DailyShiftTargetAlertGapReasonReportParametersControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltDatePicker startDatePicker;
        private OltDatePicker endDatePicker;
        private OltLabel startDateLabel;
        private OltLabel endDateLabel;
        private OltListBox shiftPatternListBox;
    }
}

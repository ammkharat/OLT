using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    partial class DailyShiftLogReportParametersControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyShiftLogReportParametersControl));
            this.tagGroupListComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.includeProcessDataCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.shiftSelectionControl = new Com.Suncor.Olt.Client.Controls.Reporting.DailyShiftTargetAlertReportParametersControl();
            this.SuspendLayout();
            // 
            // tagGroupListComboBox
            // 
            this.tagGroupListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagGroupListComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.tagGroupListComboBox, "tagGroupListComboBox");
            this.tagGroupListComboBox.Name = "tagGroupListComboBox";
            // 
            // includeProcessDataCheckBox
            // 
            resources.ApplyResources(this.includeProcessDataCheckBox, "includeProcessDataCheckBox");
            this.includeProcessDataCheckBox.Name = "includeProcessDataCheckBox";
            this.includeProcessDataCheckBox.UseVisualStyleBackColor = true;
            this.includeProcessDataCheckBox.Value = null;
            // 
            // shiftSelectionControl
            // 
            resources.ApplyResources(this.shiftSelectionControl, "shiftSelectionControl");
            this.shiftSelectionControl.Name = "shiftSelectionControl";
            // 
            // DailyShiftLogReportParametersControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shiftSelectionControl);
            this.Controls.Add(this.tagGroupListComboBox);
            this.Controls.Add(this.includeProcessDataCheckBox);
            this.Name = "DailyShiftLogReportParametersControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltCheckBox includeProcessDataCheckBox;
        private OltComboBox tagGroupListComboBox;
        private DailyShiftTargetAlertReportParametersControl shiftSelectionControl;
    }
}

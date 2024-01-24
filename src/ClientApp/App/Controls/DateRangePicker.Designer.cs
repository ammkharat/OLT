using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class DateRangePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangePicker));
            this.startDateTimeLabel = new OltLabel();
            this.startDatePicker = new OltDatePicker();
            this.endDateTimeLabel = new OltLabel();
            this.endDatePicker = new OltDatePicker();
            this.noEndDateCheckBox = new OltCheckBox();
            this.SuspendLayout();
            // 
            // startDateTimeLabel
            // 
            this.startDateTimeLabel.AccessibleDescription = null;
            this.startDateTimeLabel.AccessibleName = null;
            resources.ApplyResources(this.startDateTimeLabel, "startDateTimeLabel");
            this.startDateTimeLabel.Font = null;
            this.startDateTimeLabel.Name = "startDateTimeLabel";
            // 
            // startDatePicker
            // 
            this.startDatePicker.AccessibleDescription = null;
            this.startDatePicker.AccessibleName = null;
            this.startDatePicker.AllowDrop = true;
            resources.ApplyResources(this.startDatePicker, "startDatePicker");
            this.startDatePicker.BackgroundImage = null;
            this.startDatePicker.Font = null;
            this.startDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            // 
            // endDateTimeLabel
            // 
            this.endDateTimeLabel.AccessibleDescription = null;
            this.endDateTimeLabel.AccessibleName = null;
            resources.ApplyResources(this.endDateTimeLabel, "endDateTimeLabel");
            this.endDateTimeLabel.Font = null;
            this.endDateTimeLabel.Name = "endDateTimeLabel";
            // 
            // endDatePicker
            // 
            this.endDatePicker.AccessibleDescription = null;
            this.endDatePicker.AccessibleName = null;
            resources.ApplyResources(this.endDatePicker, "endDatePicker");
            this.endDatePicker.BackgroundImage = null;
            this.endDatePicker.Font = null;
            this.endDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            // 
            // noEndDateCheckBox
            // 
            this.noEndDateCheckBox.AccessibleDescription = null;
            this.noEndDateCheckBox.AccessibleName = null;
            resources.ApplyResources(this.noEndDateCheckBox, "noEndDateCheckBox");
            this.noEndDateCheckBox.BackgroundImage = null;
            this.noEndDateCheckBox.Font = null;
            this.noEndDateCheckBox.Name = "noEndDateCheckBox";
            this.noEndDateCheckBox.UseVisualStyleBackColor = true;
            this.noEndDateCheckBox.Value = null;
            // 
            // DateRangePicker
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.noEndDateCheckBox);
            this.Controls.Add(this.endDateTimeLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDateTimeLabel);
            this.Controls.Add(this.startDatePicker);
            this.Font = null;
            this.Name = "DateRangePicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabel startDateTimeLabel;
        private OltDatePicker startDatePicker;
        private OltLabel endDateTimeLabel;
        private OltDatePicker endDatePicker;
        private OltCheckBox noEndDateCheckBox;
    }
}

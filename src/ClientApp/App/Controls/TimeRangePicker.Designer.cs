using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class TimeRangePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeRangePicker));
            this.endTimePicker = new OltTimePicker();
            this.startTimePicker = new OltTimePicker();
            this.endDateTimeLabel = new OltLabel();
            this.startDateTimeLabel = new OltLabel();
            this.SuspendLayout();
            // 
            // endTimePicker
            // 
            resources.ApplyResources(this.endTimePicker, "endTimePicker");
            this.endTimePicker.Name = "endTimePicker";
            // 
            // startTimePicker
            // 
            resources.ApplyResources(this.startTimePicker, "startTimePicker");
            this.startTimePicker.Name = "startTimePicker";
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
            // TimeRangePicker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.endDateTimeLabel);
            this.Controls.Add(this.startDateTimeLabel);
            this.Name = "TimeRangePicker";
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabel startDateTimeLabel;
        private OltLabel endDateTimeLabel;
        private OltTimePicker startTimePicker;
        private OltTimePicker endTimePicker;
    }
}

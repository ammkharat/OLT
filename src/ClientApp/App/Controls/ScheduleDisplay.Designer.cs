using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class ScheduleDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleDisplay));
            this.RangeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endDateData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.startDateData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.endDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.TimeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endTimeData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.startTimeData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.endTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.PatternGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.occursData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.RangeGroupBox.SuspendLayout();
            this.TimeGroupBox.SuspendLayout();
            this.PatternGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RangeGroupBox
            // 
            resources.ApplyResources(this.RangeGroupBox, "RangeGroupBox");
            this.RangeGroupBox.Controls.Add(this.endDateData);
            this.RangeGroupBox.Controls.Add(this.startDateData);
            this.RangeGroupBox.Controls.Add(this.endDateLabel);
            this.RangeGroupBox.Controls.Add(this.startDateLabel);
            this.RangeGroupBox.Name = "RangeGroupBox";
            this.RangeGroupBox.TabStop = false;
            // 
            // endDateData
            // 
            resources.ApplyResources(this.endDateData, "endDateData");
            this.endDateData.Name = "endDateData";
            this.endDateData.UseMnemonic = false;
            // 
            // startDateData
            // 
            resources.ApplyResources(this.startDateData, "startDateData");
            this.startDateData.Name = "startDateData";
            this.startDateData.UseMnemonic = false;
            // 
            // endDateLabel
            // 
            resources.ApplyResources(this.endDateLabel, "endDateLabel");
            this.endDateLabel.Name = "endDateLabel";
            // 
            // startDateLabel
            // 
            resources.ApplyResources(this.startDateLabel, "startDateLabel");
            this.startDateLabel.Name = "startDateLabel";
            // 
            // TimeGroupBox
            // 
            resources.ApplyResources(this.TimeGroupBox, "TimeGroupBox");
            this.TimeGroupBox.Controls.Add(this.endTimeData);
            this.TimeGroupBox.Controls.Add(this.startTimeData);
            this.TimeGroupBox.Controls.Add(this.endTimeLabel);
            this.TimeGroupBox.Controls.Add(this.startTimeLabel);
            this.TimeGroupBox.Name = "TimeGroupBox";
            this.TimeGroupBox.TabStop = false;
            // 
            // endTimeData
            // 
            resources.ApplyResources(this.endTimeData, "endTimeData");
            this.endTimeData.Name = "endTimeData";
            this.endTimeData.UseMnemonic = false;
            // 
            // startTimeData
            // 
            resources.ApplyResources(this.startTimeData, "startTimeData");
            this.startTimeData.Name = "startTimeData";
            this.startTimeData.UseMnemonic = false;
            // 
            // endTimeLabel
            // 
            resources.ApplyResources(this.endTimeLabel, "endTimeLabel");
            this.endTimeLabel.Name = "endTimeLabel";
            // 
            // startTimeLabel
            // 
            resources.ApplyResources(this.startTimeLabel, "startTimeLabel");
            this.startTimeLabel.Name = "startTimeLabel";
            // 
            // PatternGroupBox
            // 
            resources.ApplyResources(this.PatternGroupBox, "PatternGroupBox");
            this.PatternGroupBox.Controls.Add(this.occursData);
            this.PatternGroupBox.Controls.Add(this.oltLabel1);
            this.PatternGroupBox.Name = "PatternGroupBox";
            this.PatternGroupBox.TabStop = false;
            // 
            // occursData
            // 
            resources.ApplyResources(this.occursData, "occursData");
            this.occursData.Name = "occursData";
            this.occursData.UseMnemonic = false;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // ScheduleDisplay
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PatternGroupBox);
            this.Controls.Add(this.TimeGroupBox);
            this.Controls.Add(this.RangeGroupBox);
            this.Name = "ScheduleDisplay";
            this.RangeGroupBox.ResumeLayout(false);
            this.RangeGroupBox.PerformLayout();
            this.TimeGroupBox.ResumeLayout(false);
            this.TimeGroupBox.PerformLayout();
            this.PatternGroupBox.ResumeLayout(false);
            this.PatternGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox RangeGroupBox;
        private OltGroupBox TimeGroupBox;
        private OltGroupBox PatternGroupBox;
        private OltLabel endDateLabel;
        private OltLabel startDateLabel;
        private OltLabel endTimeLabel;
        private OltLabel startTimeLabel;
        private OltLabel oltLabel1;
        private OltLabelData endDateData;
        private OltLabelData startDateData;
        private OltLabelData endTimeData;
        private OltLabelData startTimeData;
        private OltLabelData occursData;
    }
}

using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class LabAlertTagQueryMonthlyDayOfMonthRangeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertTagQueryMonthlyDayOfMonthRangeControl));
            this.oltLabel3 = new OltLabel();
            this.oltLabel2 = new OltLabel();
            this.fromTimePicker = new OltTimePicker();
            this.toTimePicker = new OltTimePicker();
            this.fromDayOfMonthComboBox = new OltComboBox();
            this.toDayOfMonthComboBox = new OltComboBox();
            this.oltLabel1 = new OltLabel();
            this.oltLabel4 = new OltLabel();
            this.SuspendLayout();
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // fromTimePicker
            // 
            resources.ApplyResources(this.fromTimePicker, "fromTimePicker");
            this.fromTimePicker.Name = "fromTimePicker";
            // 
            // toTimePicker
            // 
            resources.ApplyResources(this.toTimePicker, "toTimePicker");
            this.toTimePicker.Name = "toTimePicker";
            // 
            // fromDayOfMonthComboBox
            // 
            this.fromDayOfMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromDayOfMonthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.fromDayOfMonthComboBox, "fromDayOfMonthComboBox");
            this.fromDayOfMonthComboBox.Name = "fromDayOfMonthComboBox";
            // 
            // toDayOfMonthComboBox
            // 
            this.toDayOfMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toDayOfMonthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.toDayOfMonthComboBox, "toDayOfMonthComboBox");
            this.toDayOfMonthComboBox.Name = "toDayOfMonthComboBox";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // oltLabel4
            // 
            resources.ApplyResources(this.oltLabel4, "oltLabel4");
            this.oltLabel4.Name = "oltLabel4";
            // 
            // LabAlertTagQueryMonthlyDayOfMonthRangeControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltLabel4);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.toDayOfMonthComboBox);
            this.Controls.Add(this.fromDayOfMonthComboBox);
            this.Controls.Add(this.toTimePicker);
            this.Controls.Add(this.fromTimePicker);
            this.Controls.Add(this.oltLabel3);
            this.Controls.Add(this.oltLabel2);
            this.Name = "LabAlertTagQueryMonthlyDayOfMonthRangeControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabel oltLabel3;
        private OltLabel oltLabel2;
        private OltTimePicker fromTimePicker;
        private OltTimePicker toTimePicker;
        private OltComboBox fromDayOfMonthComboBox;
        private OltComboBox toDayOfMonthComboBox;
        private OltLabel oltLabel1;
        private OltLabel oltLabel4;
    }
}

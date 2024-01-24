using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class LabAlertTagQueryMonthlyDayOfWeekRangeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertTagQueryMonthlyDayOfWeekRangeControl));
            this.oltLabel3 = new OltLabel();
            this.oltLabel2 = new OltLabel();
            this.fromDayOfWeekComboBox = new OltComboBox();
            this.toDayOfWeekComboBox = new OltComboBox();
            this.oltLabel1 = new OltLabel();
            this.oltLabel4 = new OltLabel();
            this.toTimePicker = new OltTimePicker();
            this.fromTimePicker = new OltTimePicker();
            this.fromWeekOfMonthComboBox = new OltComboBox();
            this.toWeekOfMonthComboBox = new OltComboBox();
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
            // fromDayOfWeekComboBox
            // 
            this.fromDayOfWeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromDayOfWeekComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.fromDayOfWeekComboBox, "fromDayOfWeekComboBox");
            this.fromDayOfWeekComboBox.Name = "fromDayOfWeekComboBox";
            // 
            // toDayOfWeekComboBox
            // 
            this.toDayOfWeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toDayOfWeekComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.toDayOfWeekComboBox, "toDayOfWeekComboBox");
            this.toDayOfWeekComboBox.Name = "toDayOfWeekComboBox";
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
            // toTimePicker
            // 
            resources.ApplyResources(this.toTimePicker, "toTimePicker");
            this.toTimePicker.Name = "toTimePicker";
            // 
            // fromTimePicker
            // 
            resources.ApplyResources(this.fromTimePicker, "fromTimePicker");
            this.fromTimePicker.Name = "fromTimePicker";
            // 
            // fromWeekOfMonthComboBox
            // 
            this.fromWeekOfMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromWeekOfMonthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.fromWeekOfMonthComboBox, "fromWeekOfMonthComboBox");
            this.fromWeekOfMonthComboBox.Name = "fromWeekOfMonthComboBox";
            // 
            // toWeekOfMonthComboBox
            // 
            this.toWeekOfMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toWeekOfMonthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.toWeekOfMonthComboBox, "toWeekOfMonthComboBox");
            this.toWeekOfMonthComboBox.Name = "toWeekOfMonthComboBox";
            // 
            // LabAlertTagQueryMonthlyDayOfWeekRangeControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toWeekOfMonthComboBox);
            this.Controls.Add(this.fromWeekOfMonthComboBox);
            this.Controls.Add(this.oltLabel4);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.toDayOfWeekComboBox);
            this.Controls.Add(this.fromDayOfWeekComboBox);
            this.Controls.Add(this.toTimePicker);
            this.Controls.Add(this.fromTimePicker);
            this.Controls.Add(this.oltLabel3);
            this.Controls.Add(this.oltLabel2);
            this.Name = "LabAlertTagQueryMonthlyDayOfWeekRangeControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabel oltLabel3;
        private OltLabel oltLabel2;
        private OltTimePicker fromTimePicker;
        private OltTimePicker toTimePicker;
        private OltComboBox fromDayOfWeekComboBox;
        private OltComboBox toDayOfWeekComboBox;
        private OltLabel oltLabel1;
        private OltLabel oltLabel4;
        private OltComboBox fromWeekOfMonthComboBox;
        private OltComboBox toWeekOfMonthComboBox;
    }
}

using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class SimpleSchedulePicker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleSchedulePicker));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.recurrenceGroupBox = new OltGroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dailyGroupBox = new OltPanel();
            this.oltLabel3 = new OltLabel();
            this.daily_TimePicker = new OltTimePicker();
            this.weeklyGroupBox = new OltPanel();
            this.oltLabel5 = new OltLabel();
            this.weekly_DayOfWeekComboBox = new OltComboBox();
            this.weekly_TimePicker = new OltTimePicker();
            this.monthlyByDayOfWeekGroupBox = new OltPanel();
            this.monthlyByDayOfWeek_WeekOfMonthComboBox = new OltComboBox();
            this.oltLabel1 = new OltLabel();
            this.monthlyByDayOfWeek_DayOfWeekComboBox = new OltComboBox();
            this.monthlyByDayOfWeek_TimePicker = new OltTimePicker();
            this.monthlyByDayOfMonthGroupBox = new OltPanel();
            this.oltLabel2 = new OltLabel();
            this.monthlyByDayOfMonth_DayOfMonthComboBox = new OltComboBox();
            this.monthlyByDayOfMonth_TimePicker = new OltTimePicker();
            this.typeGroupBox = new OltGroupBox();
            this.scheduleTypesComboBox = new OltComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.recurrenceGroupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.dailyGroupBox.SuspendLayout();
            this.weeklyGroupBox.SuspendLayout();
            this.monthlyByDayOfWeekGroupBox.SuspendLayout();
            this.monthlyByDayOfMonthGroupBox.SuspendLayout();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // recurrenceGroupBox
            // 
            resources.ApplyResources(this.recurrenceGroupBox, "recurrenceGroupBox");
            this.recurrenceGroupBox.Controls.Add(this.flowLayoutPanel);
            this.recurrenceGroupBox.Name = "recurrenceGroupBox";
            this.recurrenceGroupBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.Controls.Add(this.dailyGroupBox);
            this.flowLayoutPanel.Controls.Add(this.weeklyGroupBox);
            this.flowLayoutPanel.Controls.Add(this.monthlyByDayOfWeekGroupBox);
            this.flowLayoutPanel.Controls.Add(this.monthlyByDayOfMonthGroupBox);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // dailyGroupBox
            // 
            this.dailyGroupBox.Controls.Add(this.oltLabel3);
            this.dailyGroupBox.Controls.Add(this.daily_TimePicker);
            resources.ApplyResources(this.dailyGroupBox, "dailyGroupBox");
            this.dailyGroupBox.Name = "dailyGroupBox";
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // daily_TimePicker
            // 
            resources.ApplyResources(this.daily_TimePicker, "daily_TimePicker");
            this.daily_TimePicker.Name = "daily_TimePicker";
            // 
            // weeklyGroupBox
            // 
            this.weeklyGroupBox.Controls.Add(this.oltLabel5);
            this.weeklyGroupBox.Controls.Add(this.weekly_DayOfWeekComboBox);
            this.weeklyGroupBox.Controls.Add(this.weekly_TimePicker);
            resources.ApplyResources(this.weeklyGroupBox, "weeklyGroupBox");
            this.weeklyGroupBox.Name = "weeklyGroupBox";
            // 
            // oltLabel5
            // 
            resources.ApplyResources(this.oltLabel5, "oltLabel5");
            this.oltLabel5.Name = "oltLabel5";
            // 
            // weekly_DayOfWeekComboBox
            // 
            this.weekly_DayOfWeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weekly_DayOfWeekComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.weekly_DayOfWeekComboBox, "weekly_DayOfWeekComboBox");
            this.weekly_DayOfWeekComboBox.Name = "weekly_DayOfWeekComboBox";
            // 
            // weekly_TimePicker
            // 
            resources.ApplyResources(this.weekly_TimePicker, "weekly_TimePicker");
            this.weekly_TimePicker.Name = "weekly_TimePicker";
            // 
            // monthlyByDayOfWeekGroupBox
            // 
            this.monthlyByDayOfWeekGroupBox.Controls.Add(this.monthlyByDayOfWeek_WeekOfMonthComboBox);
            this.monthlyByDayOfWeekGroupBox.Controls.Add(this.oltLabel1);
            this.monthlyByDayOfWeekGroupBox.Controls.Add(this.monthlyByDayOfWeek_DayOfWeekComboBox);
            this.monthlyByDayOfWeekGroupBox.Controls.Add(this.monthlyByDayOfWeek_TimePicker);
            resources.ApplyResources(this.monthlyByDayOfWeekGroupBox, "monthlyByDayOfWeekGroupBox");
            this.monthlyByDayOfWeekGroupBox.Name = "monthlyByDayOfWeekGroupBox";
            // 
            // monthlyByDayOfWeek_WeekOfMonthComboBox
            // 
            this.monthlyByDayOfWeek_WeekOfMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthlyByDayOfWeek_WeekOfMonthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.monthlyByDayOfWeek_WeekOfMonthComboBox, "monthlyByDayOfWeek_WeekOfMonthComboBox");
            this.monthlyByDayOfWeek_WeekOfMonthComboBox.Name = "monthlyByDayOfWeek_WeekOfMonthComboBox";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // monthlyByDayOfWeek_DayOfWeekComboBox
            // 
            this.monthlyByDayOfWeek_DayOfWeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthlyByDayOfWeek_DayOfWeekComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.monthlyByDayOfWeek_DayOfWeekComboBox, "monthlyByDayOfWeek_DayOfWeekComboBox");
            this.monthlyByDayOfWeek_DayOfWeekComboBox.Name = "monthlyByDayOfWeek_DayOfWeekComboBox";
            // 
            // monthlyByDayOfWeek_TimePicker
            // 
            resources.ApplyResources(this.monthlyByDayOfWeek_TimePicker, "monthlyByDayOfWeek_TimePicker");
            this.monthlyByDayOfWeek_TimePicker.Name = "monthlyByDayOfWeek_TimePicker";
            // 
            // monthlyByDayOfMonthGroupBox
            // 
            this.monthlyByDayOfMonthGroupBox.Controls.Add(this.oltLabel2);
            this.monthlyByDayOfMonthGroupBox.Controls.Add(this.monthlyByDayOfMonth_DayOfMonthComboBox);
            this.monthlyByDayOfMonthGroupBox.Controls.Add(this.monthlyByDayOfMonth_TimePicker);
            resources.ApplyResources(this.monthlyByDayOfMonthGroupBox, "monthlyByDayOfMonthGroupBox");
            this.monthlyByDayOfMonthGroupBox.Name = "monthlyByDayOfMonthGroupBox";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // monthlyByDayOfMonth_DayOfMonthComboBox
            // 
            this.monthlyByDayOfMonth_DayOfMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthlyByDayOfMonth_DayOfMonthComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.monthlyByDayOfMonth_DayOfMonthComboBox, "monthlyByDayOfMonth_DayOfMonthComboBox");
            this.monthlyByDayOfMonth_DayOfMonthComboBox.Name = "monthlyByDayOfMonth_DayOfMonthComboBox";
            // 
            // monthlyByDayOfMonth_TimePicker
            // 
            resources.ApplyResources(this.monthlyByDayOfMonth_TimePicker, "monthlyByDayOfMonth_TimePicker");
            this.monthlyByDayOfMonth_TimePicker.Name = "monthlyByDayOfMonth_TimePicker";
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.scheduleTypesComboBox);
            resources.ApplyResources(this.typeGroupBox, "typeGroupBox");
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.TabStop = false;
            // 
            // scheduleTypesComboBox
            // 
            this.scheduleTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scheduleTypesComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.scheduleTypesComboBox, "scheduleTypesComboBox");
            this.scheduleTypesComboBox.Name = "scheduleTypesComboBox";
            // 
            // SimpleSchedulePicker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recurrenceGroupBox);
            this.Controls.Add(this.typeGroupBox);
            this.Name = "SimpleSchedulePicker";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.recurrenceGroupBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.dailyGroupBox.ResumeLayout(false);
            this.dailyGroupBox.PerformLayout();
            this.weeklyGroupBox.ResumeLayout(false);
            this.weeklyGroupBox.PerformLayout();
            this.monthlyByDayOfWeekGroupBox.ResumeLayout(false);
            this.monthlyByDayOfWeekGroupBox.PerformLayout();
            this.monthlyByDayOfMonthGroupBox.ResumeLayout(false);
            this.monthlyByDayOfMonthGroupBox.PerformLayout();
            this.typeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltComboBox scheduleTypesComboBox;
        private OltPanel monthlyByDayOfWeekGroupBox;
        private OltPanel weeklyGroupBox;
        private OltGroupBox typeGroupBox;
        private ErrorProvider errorProvider;
        private OltPanel dailyGroupBox;
        private OltTimePicker daily_TimePicker;
        private OltLabel oltLabel5;
        private OltComboBox weekly_DayOfWeekComboBox;
        private OltTimePicker weekly_TimePicker;
        private OltPanel monthlyByDayOfMonthGroupBox;
        private OltComboBox monthlyByDayOfWeek_WeekOfMonthComboBox;
        private OltLabel oltLabel1;
        private OltComboBox monthlyByDayOfWeek_DayOfWeekComboBox;
        private OltTimePicker monthlyByDayOfWeek_TimePicker;
        private OltLabel oltLabel2;
        private OltComboBox monthlyByDayOfMonth_DayOfMonthComboBox;
        private OltTimePicker monthlyByDayOfMonth_TimePicker;
        private FlowLayoutPanel flowLayoutPanel;
        private OltLabel oltLabel3;
        private OltGroupBox recurrenceGroupBox;
    }
}

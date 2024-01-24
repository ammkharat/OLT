namespace Com.Suncor.Olt.Client.OltControls
{
    partial class OltOptionalDateTimePicker
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
            this.oltTimePicker = new OltTimePicker();
            this.oltDatePicker = new OltDatePicker();
            this.oltCheckBox = new OltCheckBox();
            this.SuspendLayout();
            // 
            // oltTimePicker
            // 
            this.oltTimePicker.Checked = true;
            this.oltTimePicker.Location = new System.Drawing.Point(147, 0);
            this.oltTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.oltTimePicker.Name = "oltTimePicker";
            this.oltTimePicker.ShowCheckBox = false;
            this.oltTimePicker.Size = new System.Drawing.Size(60, 21);
            this.oltTimePicker.TabIndex = 2;
            // 
            // oltDatePicker
            // 
            this.oltDatePicker.Location = new System.Drawing.Point(20, 0);
            this.oltDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.oltDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.oltDatePicker.Name = "oltDatePicker";
            this.oltDatePicker.Size = new System.Drawing.Size(121, 21);
            this.oltDatePicker.TabIndex = 1;
            // 
            // oltCheckBox
            // 
            this.oltCheckBox.AutoSize = true;
            this.oltCheckBox.Location = new System.Drawing.Point(0, 4);
            this.oltCheckBox.Name = "oltCheckBox";
            this.oltCheckBox.Size = new System.Drawing.Size(15, 14);
            this.oltCheckBox.TabIndex = 0;
            this.oltCheckBox.UseVisualStyleBackColor = true;
            this.oltCheckBox.Value = null;
            this.oltCheckBox.CheckedChanged += new System.EventHandler(this.oltCheckBox_CheckedChanged);
            // 
            // OltOptionalDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltCheckBox);
            this.Controls.Add(this.oltTimePicker);
            this.Controls.Add(this.oltDatePicker);
            this.Name = "OltOptionalDateTimePicker";
            this.Size = new System.Drawing.Size(209, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltDatePicker oltDatePicker;
        private OltTimePicker oltTimePicker;
        private OltCheckBox oltCheckBox;
    }
}

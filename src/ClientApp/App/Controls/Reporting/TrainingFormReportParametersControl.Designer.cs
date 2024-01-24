namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    partial class TrainingFormReportParametersControl
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
            this.usersGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.userPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.workAssignmentGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.startLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.endDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.usersGroupBox.SuspendLayout();
            this.workAssignmentGroupBox.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersGroupBox
            // 
            this.usersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.usersGroupBox.Controls.Add(this.userPanel);
            this.usersGroupBox.Location = new System.Drawing.Point(3, 57);
            this.usersGroupBox.Name = "usersGroupBox";
            this.usersGroupBox.Size = new System.Drawing.Size(407, 413);
            this.usersGroupBox.TabIndex = 3;
            this.usersGroupBox.TabStop = false;
            this.usersGroupBox.Text = "Users";
            // 
            // userPanel
            // 
            this.userPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPanel.Location = new System.Drawing.Point(9, 18);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(392, 389);
            this.userPanel.TabIndex = 0;
            // 
            // workAssignmentGroupBox
            // 
            this.workAssignmentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workAssignmentGroupBox.Controls.Add(this.gridPanel);
            this.workAssignmentGroupBox.Location = new System.Drawing.Point(416, 57);
            this.workAssignmentGroupBox.Name = "workAssignmentGroupBox";
            this.workAssignmentGroupBox.Size = new System.Drawing.Size(593, 413);
            this.workAssignmentGroupBox.TabIndex = 2;
            this.workAssignmentGroupBox.TabStop = false;
            this.workAssignmentGroupBox.Text = "Work Assignments";
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.Location = new System.Drawing.Point(6, 18);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(581, 389);
            this.gridPanel.TabIndex = 0;
            // 
            // oltGroupBox2
            // 
            this.oltGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltGroupBox2.Controls.Add(this.startLabel);
            this.oltGroupBox2.Controls.Add(this.startDatePicker);
            this.oltGroupBox2.Controls.Add(this.endDateLabel);
            this.oltGroupBox2.Controls.Add(this.endDatePicker);
            this.oltGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.Size = new System.Drawing.Size(1006, 48);
            this.oltGroupBox2.TabIndex = 1;
            this.oltGroupBox2.TabStop = false;
            this.oltGroupBox2.Text = "Date Range";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.startLabel.Location = new System.Drawing.Point(6, 22);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(35, 13);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "From:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.startDatePicker.Location = new System.Drawing.Point(47, 18);
            this.startDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.startDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.PickerEnabled = true;
            this.startDatePicker.Size = new System.Drawing.Size(133, 21);
            this.startDatePicker.TabIndex = 1;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.endDateLabel.Location = new System.Drawing.Point(195, 22);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(23, 13);
            this.endDateLabel.TabIndex = 3;
            this.endDateLabel.Text = "To:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.endDatePicker.Location = new System.Drawing.Point(224, 18);
            this.endDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.endDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.PickerEnabled = true;
            this.endDatePicker.Size = new System.Drawing.Size(133, 21);
            this.endDatePicker.TabIndex = 4;
            // 
            // TrainingFormReportParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usersGroupBox);
            this.Controls.Add(this.workAssignmentGroupBox);
            this.Controls.Add(this.oltGroupBox2);
            this.Name = "TrainingFormReportParametersControl";
            this.Size = new System.Drawing.Size(1012, 481);
            this.usersGroupBox.ResumeLayout(false);
            this.workAssignmentGroupBox.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.oltGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltGroupBox oltGroupBox2;
        private OltControls.OltLabel startLabel;
        private OltControls.OltDatePicker startDatePicker;
        private OltControls.OltLabel endDateLabel;
        private OltControls.OltDatePicker endDatePicker;
        private OltControls.OltGroupBox workAssignmentGroupBox;
        private OltControls.OltPanel gridPanel;
        private OltControls.OltGroupBox usersGroupBox;
        private OltControls.OltPanel userPanel;
    }
}

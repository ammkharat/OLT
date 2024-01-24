namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    partial class MarkedAsNotReadReportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.directivesCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.shiftHandoverCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.reportGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.groupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.label2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.label1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.groupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.runReportButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.reportGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // directivesCheckBox
            // 
            this.directivesCheckBox.AutoSize = true;
            this.directivesCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.directivesCheckBox.Location = new System.Drawing.Point(6, 24);
            this.directivesCheckBox.Name = "directivesCheckBox";
            this.directivesCheckBox.Size = new System.Drawing.Size(73, 17);
            this.directivesCheckBox.TabIndex = 2;
            this.directivesCheckBox.Text = "Directives";
            this.directivesCheckBox.UseVisualStyleBackColor = true;
            this.directivesCheckBox.Value = null;
            // 
            // shiftHandoverCheckBox
            // 
            this.shiftHandoverCheckBox.AutoSize = true;
            this.shiftHandoverCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.shiftHandoverCheckBox.Location = new System.Drawing.Point(166, 24);
            this.shiftHandoverCheckBox.Name = "shiftHandoverCheckBox";
            this.shiftHandoverCheckBox.Size = new System.Drawing.Size(98, 17);
            this.shiftHandoverCheckBox.TabIndex = 3;
            this.shiftHandoverCheckBox.Text = "Shift Handover";
            this.shiftHandoverCheckBox.UseVisualStyleBackColor = true;
            this.shiftHandoverCheckBox.Value = null;
            // 
            // reportGroupBox
            // 
            this.reportGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportGroupBox.Controls.Add(this.directivesCheckBox);
            this.reportGroupBox.Controls.Add(this.shiftHandoverCheckBox);
            this.reportGroupBox.Location = new System.Drawing.Point(247, 6);
            this.reportGroupBox.Name = "reportGroupBox";
            this.reportGroupBox.Size = new System.Drawing.Size(315, 77);
            this.reportGroupBox.TabIndex = 5;
            this.reportGroupBox.TabStop = false;
            this.reportGroupBox.Text = "Report";
            // 
            // flocSelectionControl
            // 
            this.flocSelectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flocSelectionControl.Location = new System.Drawing.Point(3, 16);
            this.flocSelectionControl.Name = "flocSelectionControl";
            this.flocSelectionControl.Size = new System.Drawing.Size(544, 284);
            this.flocSelectionControl.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flocSelectionControl);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 303);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Functional Locations";
            // 
            // endRangeDatePicker
            // 
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.endRangeDatePicker.Location = new System.Drawing.Point(49, 47);
            this.endRangeDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            this.endRangeDatePicker.Size = new System.Drawing.Size(127, 21);
            this.endRangeDatePicker.TabIndex = 3;
            // 
            // startRangeDatePicker
            // 
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.startRangeDatePicker.Location = new System.Drawing.Point(49, 20);
            this.startRangeDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            this.startRangeDatePicker.Size = new System.Drawing.Size(127, 21);
            this.startRangeDatePicker.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.endRangeDatePicker);
            this.groupBox1.Controls.Add(this.startRangeDatePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(487, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.runReportButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 404);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(574, 42);
            this.buttonPanel.TabIndex = 7;
            // 
            // runReportButton
            // 
            this.runReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runReportButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.runReportButton.Location = new System.Drawing.Point(406, 10);
            this.runReportButton.Name = "runReportButton";
            this.runReportButton.Size = new System.Drawing.Size(75, 23);
            this.runReportButton.TabIndex = 0;
            this.runReportButton.Text = "&Run Report";
            this.runReportButton.UseVisualStyleBackColor = true;
            // 
            // MarkedAsNotReadReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 446);
            this.Controls.Add(this.reportGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPanel);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(582, 473);
            this.Name = "MarkedAsNotReadReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MarkedAsNotReadReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.reportGroupBox.ResumeLayout(false);
            this.reportGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltControls.OltGroupBox reportGroupBox;
        private OltControls.OltCheckBox directivesCheckBox;
        private OltControls.OltCheckBox shiftHandoverCheckBox;
        private OltControls.OltGroupBox groupBox2;
        private Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltControls.OltGroupBox groupBox1;
        private OltControls.OltDatePicker endRangeDatePicker;
        private OltControls.OltDatePicker startRangeDatePicker;
        private OltControls.OltLabel label2;
        private OltControls.OltLabel label1;
        private OltControls.OltPanel buttonPanel;
        private OltControls.OltButton runReportButton;
        private OltControls.OltButton cancelButton;
    }
}
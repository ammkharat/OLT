namespace Com.Suncor.Olt.Client.Forms
{
    partial class AnalyticsExcelExportForm
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
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.runButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.eventListBox = new Com.Suncor.Olt.Client.OltControls.OltCheckedListBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.toDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.fromDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.runButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 269);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(389, 51);
            this.buttonPanel.TabIndex = 0;
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Location = new System.Drawing.Point(221, 16);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(302, 16);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.eventListBox);
            this.mainPanel.Controls.Add(this.oltLabel2);
            this.mainPanel.Controls.Add(this.oltLabel1);
            this.mainPanel.Controls.Add(this.toDatePicker);
            this.mainPanel.Controls.Add(this.fromDatePicker);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(389, 269);
            this.mainPanel.TabIndex = 1;
            // 
            // eventListBox
            // 
            this.eventListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventListBox.CheckOnClick = true;
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.Location = new System.Drawing.Point(15, 71);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(343, 180);
            this.eventListBox.TabIndex = 4;
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(12, 39);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(49, 13);
            this.oltLabel2.TabIndex = 3;
            this.oltLabel2.Text = "To Date:";
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(12, 9);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(61, 13);
            this.oltLabel1.TabIndex = 2;
            this.oltLabel1.Text = "From Date:";
            // 
            // toDatePicker
            // 
            this.toDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.toDatePicker.Location = new System.Drawing.Point(77, 35);
            this.toDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.toDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.PickerEnabled = true;
            this.toDatePicker.Size = new System.Drawing.Size(151, 21);
            this.toDatePicker.TabIndex = 1;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.fromDatePicker.Location = new System.Drawing.Point(77, 5);
            this.fromDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.fromDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.PickerEnabled = true;
            this.fromDatePicker.Size = new System.Drawing.Size(151, 21);
            this.fromDatePicker.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AnalyticsExcelExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 320);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.MinimumSize = new System.Drawing.Size(397, 347);
            this.Name = "AnalyticsExcelExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analytics Excel Export";
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonPanel;
        private OltControls.OltPanel mainPanel;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltDatePicker toDatePicker;
        private OltControls.OltDatePicker fromDatePicker;
        private OltControls.OltButton cancelButton;
        private OltControls.OltButton runButton;
        private OltControls.OltCheckedListBox eventListBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
namespace Com.Suncor.Olt.Client.Forms
{
    partial class EnableSecurityForNewDirectivesForm
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
            this.acceptCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.continueButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.explanationLabel = new DevExpress.XtraEditors.LabelControl();
            this.buttonPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // acceptCheckBox
            // 
            this.acceptCheckBox.AutoSize = true;
            this.acceptCheckBox.Location = new System.Drawing.Point(261, 61);
            this.acceptCheckBox.Name = "acceptCheckBox";
            this.acceptCheckBox.Size = new System.Drawing.Size(87, 17);
            this.acceptCheckBox.TabIndex = 1;
            this.acceptCheckBox.Text = "Let\'s do this.";
            this.acceptCheckBox.UseVisualStyleBackColor = true;
            this.acceptCheckBox.Value = null;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.continueButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 96);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(584, 46);
            this.buttonPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(497, 11);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // continueButton
            // 
            this.continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.Location = new System.Drawing.Point(416, 11);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.explanationLabel);
            this.oltPanel1.Controls.Add(this.acceptCheckBox);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oltPanel1.Location = new System.Drawing.Point(0, 0);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(584, 96);
            this.oltPanel1.TabIndex = 0;
            // 
            // explanationLabel
            // 
            this.explanationLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.explanationLabel.Location = new System.Drawing.Point(12, 18);
            this.explanationLabel.Name = "explanationLabel";
            this.explanationLabel.Size = new System.Drawing.Size(560, 26);
            this.explanationLabel.TabIndex = 2;
            this.explanationLabel.Text = "If you check the following box and click Continue, log-based directives [security" +
    " only] in {0} will be converted to the newer directives infrastructure.";
            // 
            // EnableSecurityForNewDirectivesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(584, 142);
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.buttonPanel);
            this.MaximumSize = new System.Drawing.Size(600, 180);
            this.MinimumSize = new System.Drawing.Size(600, 180);
            this.Name = "EnableSecurityForNewDirectivesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enable Security for New Directives";
            this.buttonPanel.ResumeLayout(false);
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltCheckBox acceptCheckBox;
        private OltControls.OltPanel buttonPanel;
        private OltControls.OltButton cancelButton;
        private OltControls.OltButton continueButton;
        private OltControls.OltPanel oltPanel1;
        private DevExpress.XtraEditors.LabelControl explanationLabel;
    }
}
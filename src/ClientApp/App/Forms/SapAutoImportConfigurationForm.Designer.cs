namespace Com.Suncor.Olt.Client.Forms
{
    partial class SapAutoImportConfigurationForm
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
            this.enabledCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.timePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableLubesCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Location = new System.Drawing.Point(6, 20);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(150, 17);
            this.enabledCheckBox.TabIndex = 0;
            this.enabledCheckBox.Text = "Enable Daily Auto Imports";
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            this.enabledCheckBox.Value = null;
            // 
            // lubesTimePicker
            // 
            this.timePicker.Checked = true;
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Location = new System.Drawing.Point(296, 16);
            this.timePicker.Margin = new System.Windows.Forms.Padding(0);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowCheckBox = false;
            this.timePicker.Size = new System.Drawing.Size(60, 21);
            this.timePicker.TabIndex = 2;
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(212, 21);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(81, 13);
            this.oltLabel2.TabIndex = 3;
            this.oltLabel2.Text = "Time of Import:";
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.enabledCheckBox);
            this.oltGroupBox1.Controls.Add(this.timePicker);
            this.oltGroupBox1.Controls.Add(this.oltLabel2);
            this.oltGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.Size = new System.Drawing.Size(372, 52);
            this.oltGroupBox1.TabIndex = 4;
            this.oltGroupBox1.TabStop = false;
            this.oltGroupBox1.Text = "Auto Import";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(227, 82);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(308, 82);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SapAutoImportConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 117);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.oltGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SapAutoImportConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAP Auto Import Configuration";
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltCheckBox enabledCheckBox;
        private OltControls.OltTimePicker timePicker;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltGroupBox oltGroupBox1;
        private OltControls.OltButton saveButton;
        private OltControls.OltButton cancelButton;
    }
}
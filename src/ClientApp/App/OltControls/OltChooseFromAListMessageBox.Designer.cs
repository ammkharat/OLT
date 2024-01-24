using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    partial class OltChooseFromAListMessageBox
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
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.shiftComboBox = new System.Windows.Forms.ComboBox();
            this.messageLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.panelIcon = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.shiftComboBox);
            this.mainPanel.Controls.Add(this.messageLabel);
            this.mainPanel.Controls.Add(this.panelIcon);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(392, 67);
            this.mainPanel.TabIndex = 3;
            // 
            // shiftComboBox
            // 
            this.shiftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftComboBox.FormattingEnabled = true;
            this.shiftComboBox.Items.AddRange(new object[] {
            "1234567890 1234567890 1234567890 1234567890 "});
            this.shiftComboBox.Location = new System.Drawing.Point(66, 37);
            this.shiftComboBox.Name = "shiftComboBox";
            this.shiftComboBox.Size = new System.Drawing.Size(281, 21);
            this.shiftComboBox.TabIndex = 4;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(63, 21);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(49, 13);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "Message";
            // 
            // panelIcon
            // 
            this.panelIcon.BackColor = System.Drawing.Color.Transparent;
            this.panelIcon.Location = new System.Drawing.Point(12, 12);
            this.panelIcon.Name = "panelIcon";
            this.panelIcon.Size = new System.Drawing.Size(32, 32);
            this.panelIcon.TabIndex = 3;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.cancelButton);
            this.oltPanel1.Controls.Add(this.okButton);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel1.Location = new System.Drawing.Point(0, 67);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(392, 42);
            this.oltPanel1.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(296, 7);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(215, 7);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // OltChooseFromAListMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(392, 109);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.oltPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OltChooseFromAListMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Title";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.oltPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltPanel mainPanel;
        private OltLabel messageLabel;
        private OltPanel panelIcon;
        private OltPanel oltPanel1;
        private OltButton okButton;
        private ErrorProvider errorProvider;
        private OltButton cancelButton;
        private ComboBox shiftComboBox;

    }
}
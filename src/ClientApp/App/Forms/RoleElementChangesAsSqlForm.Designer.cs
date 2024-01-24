namespace Com.Suncor.Olt.Client.Forms
{
    partial class RoleElementChangesAsSqlForm
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
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.sqlTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 498);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(855, 45);
            this.buttonPanel.TabIndex = 0;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.sqlTextBox);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oltPanel1.Location = new System.Drawing.Point(0, 0);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(855, 498);
            this.oltPanel1.TabIndex = 1;
            // 
            // sqlTextBox
            // 
            this.sqlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlTextBox.BackColor = System.Drawing.Color.White;
            this.sqlTextBox.Location = new System.Drawing.Point(8, 8);
            this.sqlTextBox.Multiline = true;
            this.sqlTextBox.Name = "sqlTextBox";
            this.sqlTextBox.OltAcceptsReturn = true;
            this.sqlTextBox.OltTrimWhitespace = true;
            this.sqlTextBox.ReadOnly = true;
            this.sqlTextBox.Size = new System.Drawing.Size(835, 472);
            this.sqlTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(768, 10);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // RoleElementChangesAsSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 543);
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.buttonPanel);
            this.Name = "RoleElementChangesAsSqlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Role Element Changes as SQL";
            this.buttonPanel.ResumeLayout(false);
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonPanel;
        private OltControls.OltPanel oltPanel1;
        private OltControls.OltButton okButton;
        private OltControls.OltTextBox sqlTextBox;
    }
}
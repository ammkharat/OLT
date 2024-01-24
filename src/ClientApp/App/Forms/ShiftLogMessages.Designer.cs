namespace Com.Suncor.Olt.Client.Forms
{
    partial class ShiftLogMessages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftLogMessages));
            this.pageTitle = new Com.Suncor.Olt.Client.OltControls.OltLabelTitle();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.appendToCommentsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.grpboxGrid = new System.Windows.Forms.GroupBox();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageTitle
            // 
            resources.ApplyResources(this.pageTitle, "pageTitle");
            this.pageTitle.BackColor = System.Drawing.Color.Gray;
            this.pageTitle.ForeColor = System.Drawing.Color.White;
            this.pageTitle.Name = "pageTitle";
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.appendToCommentsButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Name = "buttonPanel";
            // 
            // appendToCommentsButton
            // 
            resources.ApplyResources(this.appendToCommentsButton, "appendToCommentsButton");
            this.appendToCommentsButton.Name = "appendToCommentsButton";
            this.appendToCommentsButton.UseVisualStyleBackColor = true;
            this.appendToCommentsButton.Click += new System.EventHandler(this.appendToCommentsButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // grpboxGrid
            // 
            resources.ApplyResources(this.grpboxGrid, "grpboxGrid");
            this.grpboxGrid.Name = "grpboxGrid";
            this.grpboxGrid.TabStop = false;
            // 
            // ShiftLogMessages
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpboxGrid);
            this.Controls.Add(this.pageTitle);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ShiftLogMessages";
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private OltControls.OltButton appendToCommentsButton;
        private OltControls.OltButton cancelButton;
        private OltControls.OltLabelTitle pageTitle;
        private System.Windows.Forms.GroupBox grpboxGrid;
    }
}
namespace Com.Suncor.Olt.Client.Forms
{
    partial class GasTestMudsForm
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
            this.gasTestTestResultsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.gasTestElementInfoTableLayoutPanel = new Com.Suncor.Olt.Client.Controls.GasTestElementLayoutPanelMuds();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.btnHistory = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltBtnshowDetails = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.btnCancel = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.btnSave = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gasTestTestResultsGroupBox.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gasTestTestResultsGroupBox
            // 
            this.gasTestTestResultsGroupBox.AutoSize = true;
            this.gasTestTestResultsGroupBox.Controls.Add(this.gasTestElementInfoTableLayoutPanel);
            this.gasTestTestResultsGroupBox.Location = new System.Drawing.Point(9, 14);
            this.gasTestTestResultsGroupBox.Name = "gasTestTestResultsGroupBox";
            this.gasTestTestResultsGroupBox.Size = new System.Drawing.Size(991, 398);
            this.gasTestTestResultsGroupBox.TabIndex = 78;
            this.gasTestTestResultsGroupBox.TabStop = false;
            this.gasTestTestResultsGroupBox.Text = "Résultats test de gaz";
            // 
            // gasTestElementInfoTableLayoutPanel
            // 
            this.gasTestElementInfoTableLayoutPanel.AutoSize = true;
            this.gasTestElementInfoTableLayoutPanel.ConfinedSpaceTime = null;
            this.gasTestElementInfoTableLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gasTestElementInfoTableLayoutPanel.FourthResultTime = null;
            this.gasTestElementInfoTableLayoutPanel.ImmediateAreaTime = null;
            this.gasTestElementInfoTableLayoutPanel.Location = new System.Drawing.Point(7, 22);
            this.gasTestElementInfoTableLayoutPanel.Name = "gasTestElementInfoTableLayoutPanel";
            this.gasTestElementInfoTableLayoutPanel.ResultTime = null;
            this.gasTestElementInfoTableLayoutPanel.Size = new System.Drawing.Size(847, 357);
            this.gasTestElementInfoTableLayoutPanel.TabIndex = 0;
            this.gasTestElementInfoTableLayoutPanel.ThirdResultTime = null;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.btnHistory);
            this.oltPanel1.Controls.Add(this.oltBtnshowDetails);
            this.oltPanel1.Controls.Add(this.btnCancel);
            this.oltPanel1.Controls.Add(this.btnSave);
            this.oltPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oltPanel1.Location = new System.Drawing.Point(0, 691);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(1012, 39);
            this.oltPanel1.TabIndex = 79;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHistory.Location = new System.Drawing.Point(165, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(129, 24);
            this.btnHistory.TabIndex = 27;
            this.btnHistory.Text = "Historique";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // oltBtnshowDetails
            // 
            this.oltBtnshowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.oltBtnshowDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oltBtnshowDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.oltBtnshowDetails.Location = new System.Drawing.Point(15, 7);
            this.oltBtnshowDetails.Name = "oltBtnshowDetails";
            this.oltBtnshowDetails.Size = new System.Drawing.Size(129, 24);
            this.oltBtnshowDetails.TabIndex = 26;
            this.oltBtnshowDetails.Text = "afficher les détails";
            this.oltBtnshowDetails.UseVisualStyleBackColor = true;
            this.oltBtnshowDetails.Click += new System.EventHandler(this.oltBtnshowDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(886, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(759, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save && Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GasTestMudsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 730);
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.gasTestTestResultsGroupBox);
            this.Name = "GasTestMudsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Résultats test de gaz";
            this.gasTestTestResultsGroupBox.ResumeLayout(false);
            this.gasTestTestResultsGroupBox.PerformLayout();
            this.oltPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltControls.OltGroupBox gasTestTestResultsGroupBox;
        private Controls.GasTestElementLayoutPanelMuds gasTestElementInfoTableLayoutPanel;
        private OltControls.OltPanel oltPanel1;
        private OltControls.OltButton btnCancel;
        private OltControls.OltButton btnSave;
        private OltControls.OltButton btnHistory;
        private OltControls.OltButton oltBtnshowDetails;
    }
}
namespace TestTool
{
    partial class SapHandlerControl
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbDestination = new System.Windows.Forms.ComboBox();
            this.tbSourceData = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultsGroup = new System.Windows.Forms.GroupBox();
            this.DirSel = new System.Windows.Forms.Button();
            this.UseropenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PostGroup = new System.Windows.Forms.GroupBox();
            this.uniqueFieldTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.repeatsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.UserTestFile = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.ResultsGroup.SuspendLayout();
            this.PostGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(688, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(39, 17);
            this.tsStatus.Text = "Ready";
            // 
            // lbDestination
            // 
            this.lbDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDestination.FormattingEnabled = true;
            this.lbDestination.Items.AddRange(new object[] {
            "Functional Location",
            "Notification",
            "Work Order"});
            this.lbDestination.Location = new System.Drawing.Point(61, 69);
            this.lbDestination.Name = "lbDestination";
            this.lbDestination.Size = new System.Drawing.Size(595, 21);
            this.lbDestination.TabIndex = 11;
            // 
            // tbSourceData
            // 
            this.tbSourceData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourceData.Location = new System.Drawing.Point(9, 19);
            this.tbSourceData.Multiline = true;
            this.tbSourceData.Name = "tbSourceData";
            this.tbSourceData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSourceData.Size = new System.Drawing.Size(647, 252);
            this.tbSourceData.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(283, 140);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // gbSource
            // 
            this.gbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSource.Controls.Add(this.tbSourceData);
            this.gbSource.Location = new System.Drawing.Point(12, 182);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(665, 274);
            this.gbSource.TabIndex = 10;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source Data";
            // 
            // tbResults
            // 
            this.tbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResults.Location = new System.Drawing.Point(9, 19);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResults.Size = new System.Drawing.Size(647, 37);
            this.tbResults.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type";
            // 
            // ResultsGroup
            // 
            this.ResultsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsGroup.Controls.Add(this.tbResults);
            this.ResultsGroup.Location = new System.Drawing.Point(12, 463);
            this.ResultsGroup.Name = "ResultsGroup";
            this.ResultsGroup.Size = new System.Drawing.Size(665, 68);
            this.ResultsGroup.TabIndex = 8;
            this.ResultsGroup.TabStop = false;
            this.ResultsGroup.Text = "Results";
            // 
            // DirSel
            // 
            this.DirSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DirSel.Location = new System.Drawing.Point(627, 40);
            this.DirSel.Name = "DirSel";
            this.DirSel.Size = new System.Drawing.Size(29, 23);
            this.DirSel.TabIndex = 2;
            this.DirSel.Text = "...";
            this.DirSel.UseVisualStyleBackColor = true;
            // 
            // PostGroup
            // 
            this.PostGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PostGroup.Controls.Add(this.uniqueFieldTextBox);
            this.PostGroup.Controls.Add(this.label4);
            this.PostGroup.Controls.Add(this.repeatsTextBox);
            this.PostGroup.Controls.Add(this.label3);
            this.PostGroup.Controls.Add(this.urlTextBox);
            this.PostGroup.Controls.Add(this.label2);
            this.PostGroup.Controls.Add(this.lbDestination);
            this.PostGroup.Controls.Add(this.btnSubmit);
            this.PostGroup.Controls.Add(this.label1);
            this.PostGroup.Controls.Add(this.lblFileName);
            this.PostGroup.Controls.Add(this.DirSel);
            this.PostGroup.Controls.Add(this.UserTestFile);
            this.PostGroup.Location = new System.Drawing.Point(12, 7);
            this.PostGroup.Name = "PostGroup";
            this.PostGroup.Size = new System.Drawing.Size(665, 169);
            this.PostGroup.TabIndex = 7;
            this.PostGroup.TabStop = false;
            this.PostGroup.Text = "Post Data";
            // 
            // uniqueFieldTextBox
            // 
            this.uniqueFieldTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueFieldTextBox.Location = new System.Drawing.Point(283, 96);
            this.uniqueFieldTextBox.Name = "uniqueFieldTextBox";
            this.uniqueFieldTextBox.Size = new System.Drawing.Size(373, 20);
            this.uniqueFieldTextBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Unique Field to Increment";
            // 
            // repeatsTextBox
            // 
            this.repeatsTextBox.Location = new System.Drawing.Point(61, 96);
            this.repeatsTextBox.Name = "repeatsTextBox";
            this.repeatsTextBox.Size = new System.Drawing.Size(68, 20);
            this.repeatsTextBox.TabIndex = 15;
            this.repeatsTextBox.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Repeats";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.Location = new System.Drawing.Point(61, 16);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(595, 20);
            this.urlTextBox.TabIndex = 13;
            this.urlTextBox.Text = "http://localhost/SAPHandlers/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "URL";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 46);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(49, 13);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "Filename";
            // 
            // UserTestFile
            // 
            this.UserTestFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserTestFile.Location = new System.Drawing.Point(61, 42);
            this.UserTestFile.Name = "UserTestFile";
            this.UserTestFile.ReadOnly = true;
            this.UserTestFile.Size = new System.Drawing.Size(560, 20);
            this.UserTestFile.TabIndex = 1;
            // 
            // SapHandlerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbSource);
            this.Controls.Add(this.ResultsGroup);
            this.Controls.Add(this.PostGroup);
            this.Name = "SapHandlerControl";
            this.Size = new System.Drawing.Size(688, 561);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.ResultsGroup.ResumeLayout(false);
            this.ResultsGroup.PerformLayout();
            this.PostGroup.ResumeLayout(false);
            this.PostGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.ComboBox lbDestination;
        private System.Windows.Forms.TextBox tbSourceData;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ResultsGroup;
        private System.Windows.Forms.Button DirSel;
        private System.Windows.Forms.OpenFileDialog UseropenFileDialog;
        private System.Windows.Forms.GroupBox PostGroup;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox UserTestFile;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uniqueFieldTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox repeatsTextBox;
        private System.Windows.Forms.Label label3;
    }
}

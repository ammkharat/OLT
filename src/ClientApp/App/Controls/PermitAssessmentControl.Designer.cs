namespace Com.Suncor.Olt.Client.Controls
{
    partial class PermitAssessmentControl
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
            this.components = new System.ComponentModel.Container();
            this.permitAssessmentAnswerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sectionsPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.commentsMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.commentsLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.totalScorePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.totalScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.permitAssessmentAnswerBindingSource)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentsMemoEdit.Properties)).BeginInit();
            this.totalScorePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // permitAssessmentAnswerBindingSource
            // 
            this.permitAssessmentAnswerBindingSource.DataSource = typeof(Com.Suncor.Olt.Common.Domain.Form.PermitAssessmentAnswer);
            // 
            // sectionsPanel
            // 
            this.sectionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionsPanel.Location = new System.Drawing.Point(0, 0);
            this.sectionsPanel.Name = "sectionsPanel";
            this.sectionsPanel.Size = new System.Drawing.Size(760, 197);
            this.sectionsPanel.TabIndex = 8;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.commentsMemoEdit);
            this.footerPanel.Controls.Add(this.commentsLabel);
            this.footerPanel.Controls.Add(this.totalScorePanel);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 197);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(760, 122);
            this.footerPanel.TabIndex = 8;
            // 
            // commentsMemoEdit
            // 
            this.commentsMemoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsMemoEdit.Location = new System.Drawing.Point(107, 63);
            this.commentsMemoEdit.Name = "commentsMemoEdit";
            this.commentsMemoEdit.Properties.MaxLength = 255;
            this.commentsMemoEdit.Size = new System.Drawing.Size(653, 55);
            this.commentsMemoEdit.TabIndex = 10;
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.commentsLabel.Location = new System.Drawing.Point(7, 66);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(94, 13);
            this.commentsLabel.TabIndex = 8;
            this.commentsLabel.Text = "Overall Feedback:";
            this.commentsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totalScorePanel
            // 
            this.totalScorePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalScorePanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.totalScorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalScorePanel.Controls.Add(this.totalScoreLabel);
            this.totalScorePanel.Location = new System.Drawing.Point(0, 15);
            this.totalScorePanel.Name = "totalScorePanel";
            this.totalScorePanel.Size = new System.Drawing.Size(760, 40);
            this.totalScorePanel.TabIndex = 7;
            // 
            // totalScoreLabel
            // 
            this.totalScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalScoreLabel.AutoSize = true;
            this.totalScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalScoreLabel.ForeColor = System.Drawing.Color.Blue;
            this.totalScoreLabel.Location = new System.Drawing.Point(635, 11);
            this.totalScoreLabel.Name = "totalScoreLabel";
            this.totalScoreLabel.Size = new System.Drawing.Size(112, 13);
            this.totalScoreLabel.TabIndex = 0;
            this.totalScoreLabel.Text = "[Total Score: 25%]";
            // 
            // PermitAssessmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sectionsPanel);
            this.Controls.Add(this.footerPanel);
            this.Name = "PermitAssessmentControl";
            this.Size = new System.Drawing.Size(760, 319);
            ((System.ComponentModel.ISupportInitialize)(this.permitAssessmentAnswerBindingSource)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentsMemoEdit.Properties)).EndInit();
            this.totalScorePanel.ResumeLayout(false);
            this.totalScorePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource permitAssessmentAnswerBindingSource;
        private OltControls.OltPanel totalScorePanel;
        private System.Windows.Forms.Label totalScoreLabel;
        private System.Windows.Forms.Panel sectionsPanel;
        private System.Windows.Forms.Panel footerPanel;
        private OltControls.OltLabel commentsLabel;
        private DevExpress.XtraEditors.MemoEdit commentsMemoEdit;
    }
}

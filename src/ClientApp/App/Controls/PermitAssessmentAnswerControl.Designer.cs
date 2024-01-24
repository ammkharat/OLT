namespace Com.Suncor.Olt.Client.Controls
{
    partial class PermitAssessmentAnswerControl
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.headerLabelPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.answerQuestionLabel = new DevExpress.XtraEditors.LabelControl();
            this.weightTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.answerNumberLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.scoreComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.commentsTextEditor = new Com.Suncor.Olt.Client.OltControls.OltTextEditor();
            this.headerLabelPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsTextEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabelPanel
            // 
            this.headerLabelPanel.Controls.Add(this.label3);
            this.headerLabelPanel.Controls.Add(this.label2);
            this.headerLabelPanel.Controls.Add(this.label1);
            this.headerLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabelPanel.Location = new System.Drawing.Point(0, 0);
            this.headerLabelPanel.Name = "headerLabelPanel";
            this.headerLabelPanel.Size = new System.Drawing.Size(760, 25);
            this.headerLabelPanel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(503, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Observations/Corrective Feedback";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(410, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Weight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.answerQuestionLabel);
            this.mainPanel.Controls.Add(this.weightTextEdit);
            this.mainPanel.Controls.Add(this.commentsTextEditor);
            this.mainPanel.Controls.Add(this.answerNumberLabel);
            this.mainPanel.Controls.Add(this.scoreComboBoxEdit);
            this.mainPanel.Location = new System.Drawing.Point(0, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(760, 38);
            this.mainPanel.TabIndex = 5;
            // 
            // answerQuestionLabel
            // 
            this.answerQuestionLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.answerQuestionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.answerQuestionLabel.Location = new System.Drawing.Point(43, 11);
            this.answerQuestionLabel.Name = "answerQuestionLabel";
            this.answerQuestionLabel.Size = new System.Drawing.Size(306, 13);
            this.answerQuestionLabel.TabIndex = 1;
            this.answerQuestionLabel.Text = "Question?";
            // 
            // weightTextEdit
            // 
            this.weightTextEdit.EditValue = "10";
            this.weightTextEdit.Enabled = false;
            this.weightTextEdit.Location = new System.Drawing.Point(416, 9);
            this.weightTextEdit.Name = "weightTextEdit";
            this.weightTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.weightTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.weightTextEdit.Size = new System.Drawing.Size(35, 20);
            this.weightTextEdit.TabIndex = 9;
            // 
            // answerNumberLabel
            // 
            this.answerNumberLabel.Location = new System.Drawing.Point(12, 11);
            this.answerNumberLabel.Name = "answerNumberLabel";
            this.answerNumberLabel.Size = new System.Drawing.Size(25, 16);
            this.answerNumberLabel.TabIndex = 6;
            this.answerNumberLabel.Text = "1.";
            // 
            // scoreComboBoxEdit
            // 
            this.scoreComboBoxEdit.EditValue = "3";
            this.scoreComboBoxEdit.Location = new System.Drawing.Point(364, 9);
            this.scoreComboBoxEdit.Name = "scoreComboBoxEdit";
            this.scoreComboBoxEdit.Properties.AllowMouseWheel = false;
            this.scoreComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.scoreComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.scoreComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.scoreComboBoxEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.scoreComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.scoreComboBoxEdit.Size = new System.Drawing.Size(42, 20);
            toolTipItem2.Text = "Scores can range between 0 and 5.\r\nScores defined for all questions as:\r\n0-1 = Im" +
    "provement Required (Red)\r\n2-3 = Room for Improvement (Yellow)\r\n4-5= Expectations" +
    " Met (Green)\r\n";
            superToolTip2.Items.Add(toolTipItem2);
            this.scoreComboBoxEdit.SuperTip = superToolTip2;
            this.scoreComboBoxEdit.TabIndex = 7;
            // 
            // commentsTextEditor
            // 
            this.commentsTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsTextEditor.Location = new System.Drawing.Point(461, 9);
            this.commentsTextEditor.MaxLength = 100;
            this.commentsTextEditor.Name = "commentsTextEditor";
            this.commentsTextEditor.Size = new System.Drawing.Size(288, 21);
            this.commentsTextEditor.TabIndex = 8;
            this.commentsTextEditor.Text = "Comments";
            // 
            // PermitAssessmentAnswerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerLabelPanel);
            this.Name = "PermitAssessmentAnswerControl";
            this.Size = new System.Drawing.Size(760, 63);
            this.headerLabelPanel.ResumeLayout(false);
            this.headerLabelPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsTextEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerLabelPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainPanel;
        private DevExpress.XtraEditors.TextEdit weightTextEdit;
        private OltControls.OltTextEditor commentsTextEditor;
        private DevExpress.XtraEditors.ComboBoxEdit scoreComboBoxEdit;
        private OltControls.OltLabel answerNumberLabel;
        private DevExpress.XtraEditors.LabelControl answerQuestionLabel;
    }
}

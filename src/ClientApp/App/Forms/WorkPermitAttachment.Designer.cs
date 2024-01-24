namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitAttachment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltDGVAttachment = new Com.Suncor.Olt.Client.OltControls.OltDataGridView();
            this.WorkPermitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentPath = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Uploadedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVAttachment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(14, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 22);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // oltDGVAttachment
            // 
            this.oltDGVAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oltDGVAttachment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oltDGVAttachment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.oltDGVAttachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oltDGVAttachment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkPermitId,
            this.DocumentPath,
            this.Uploadedby,
            this.UploadedDate,
            this.DocumentTypes,
            this.Comment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oltDGVAttachment.DefaultCellStyle = dataGridViewCellStyle2;
            this.oltDGVAttachment.Location = new System.Drawing.Point(12, 12);
            this.oltDGVAttachment.Name = "oltDGVAttachment";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oltDGVAttachment.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.oltDGVAttachment.RowHeadersVisible = false;
            this.oltDGVAttachment.Size = new System.Drawing.Size(706, 205);
            this.oltDGVAttachment.TabIndex = 0;
            this.oltDGVAttachment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oltDGVAttachment_CellContentClick);
            // 
            // WorkPermitId
            // 
            this.WorkPermitId.DataPropertyName = "WorkPermitId";
            this.WorkPermitId.HeaderText = "Work Permit Number";
            this.WorkPermitId.Name = "WorkPermitId";
            this.WorkPermitId.ReadOnly = true;
            // 
            // DocumentPath
            // 
            this.DocumentPath.DataPropertyName = "DocumentPath";
            this.DocumentPath.HeaderText = "DocumentPath";
            this.DocumentPath.Name = "DocumentPath";
            this.DocumentPath.ReadOnly = true;
            this.DocumentPath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DocumentPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Uploadedby
            // 
            this.Uploadedby.DataPropertyName = "Username";
            this.Uploadedby.HeaderText = "Uploaded By";
            this.Uploadedby.Name = "Uploadedby";
            this.Uploadedby.ReadOnly = true;
            // 
            // UploadedDate
            // 
            this.UploadedDate.DataPropertyName = "CreatedDate";
            this.UploadedDate.HeaderText = "Uploaded Date";
            this.UploadedDate.Name = "UploadedDate";
            this.UploadedDate.ReadOnly = true;
            // 
            // DocumentTypes
            // 
            this.DocumentTypes.DataPropertyName = "UploadedDocumentType";
            this.DocumentTypes.HeaderText = "Document Types";
            this.DocumentTypes.Name = "DocumentTypes";
            this.DocumentTypes.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // WorkPermitAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 240);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.oltDGVAttachment);
            this.Name = "WorkPermitAttachment";
            this.Text = "WorkPermitAttachment";
            ((System.ComponentModel.ISupportInitialize)(this.oltDGVAttachment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltDataGridView oltDGVAttachment;
        private OltControls.OltButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkPermitId;
        private System.Windows.Forms.DataGridViewLinkColumn DocumentPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uploadedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}
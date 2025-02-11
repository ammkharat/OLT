namespace Com.Suncor.Olt.Client.Controls
{
    partial class RichTextDisplay
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
            this.richEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.SuspendLayout();
            // 
            // richEditControl
            // 
            this.richEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.richEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl.Location = new System.Drawing.Point(0, 0);
            this.richEditControl.Name = "richEditControl";
            this.richEditControl.ReadOnly = true;
            this.richEditControl.Size = new System.Drawing.Size(488, 321);
            this.richEditControl.TabIndex = 0;
            this.richEditControl.Views.SimpleView.BackColor = System.Drawing.SystemColors.Control;
            this.richEditControl.Views.SimpleView.Padding = new System.Windows.Forms.Padding(1, 2, 4, 0);
            // 
            // RichTextDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richEditControl);
            this.Name = "RichTextDisplay";
            this.Size = new System.Drawing.Size(488, 321);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl;
    }
}

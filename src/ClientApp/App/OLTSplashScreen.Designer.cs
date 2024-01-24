namespace Com.Suncor.Olt.Client
{
    partial class OLTSplashScreen
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
            this.marqueeProgressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl
            // 
            this.marqueeProgressBarControl.EditValue = 0;
            this.marqueeProgressBarControl.Location = new System.Drawing.Point(91, 21);
            this.marqueeProgressBarControl.Name = "marqueeProgressBarControl";
            this.marqueeProgressBarControl.Properties.LookAndFeel.SkinName = "Foggy";
            this.marqueeProgressBarControl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.marqueeProgressBarControl.Size = new System.Drawing.Size(335, 12);
            this.marqueeProgressBarControl.TabIndex = 5;
            // 
            // labelControl
            // 
            this.labelControl.Location = new System.Drawing.Point(91, 39);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(219, 13);
            this.labelControl.TabIndex = 7;
            this.labelControl.Text = "Starting OLT... [replaced by string resources]";
            // 
            // pictureEdit
            // 
            this.pictureEdit.EditValue = global::Com.Suncor.Olt.Client.Properties.Resources.OLT_icon_48;
            this.pictureEdit.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.AllowFocused = false;
            this.pictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit.Properties.ShowMenu = false;
            this.pictureEdit.Size = new System.Drawing.Size(73, 48);
            this.pictureEdit.TabIndex = 8;
            // 
            // OLTSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 80);
            this.Controls.Add(this.pictureEdit);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.marqueeProgressBarControl);
            this.Name = "OLTSplashScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
    }
}

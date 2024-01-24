namespace Com.Suncor.Olt.Client.Forms
{
    partial class SarniaMessagePopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SarniaMessagePopupForm));
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.commentsRequiredForEquipmentInServiceImageLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltButton1 = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.commentsRequiredForEquipmentInServiceImageLabel);
            this.oltPanel1.Controls.Add(this.oltLabel4);
            this.oltPanel1.Controls.Add(this.oltLabel3);
            this.oltPanel1.Controls.Add(this.oltLabel2);
            this.oltPanel1.Controls.Add(this.oltLabel1);
            this.oltPanel1.Location = new System.Drawing.Point(5, 6);
            this.oltPanel1.Name = "oltPanel1";
            this.oltPanel1.Size = new System.Drawing.Size(398, 95);
            this.oltPanel1.TabIndex = 0;
            // 
            // commentsRequiredForEquipmentInServiceImageLabel
            // 
            this.commentsRequiredForEquipmentInServiceImageLabel.Image = global::Com.Suncor.Olt.Client.Properties.Resources.warningCommentsRequired;
            this.commentsRequiredForEquipmentInServiceImageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.commentsRequiredForEquipmentInServiceImageLabel.Location = new System.Drawing.Point(16, 33);
            this.commentsRequiredForEquipmentInServiceImageLabel.Name = "commentsRequiredForEquipmentInServiceImageLabel";
            this.commentsRequiredForEquipmentInServiceImageLabel.Size = new System.Drawing.Size(36, 34);
            this.commentsRequiredForEquipmentInServiceImageLabel.TabIndex = 4;
            // 
            // oltLabel4
            // 
            this.oltLabel4.AutoSize = true;
            this.oltLabel4.Location = new System.Drawing.Point(54, 73);
            this.oltLabel4.Name = "oltLabel4";
            this.oltLabel4.Size = new System.Drawing.Size(125, 13);
            this.oltLabel4.TabIndex = 3;
            this.oltLabel4.Text = "Authorization Required).";
            // 
            // oltLabel3
            // 
            this.oltLabel3.AutoSize = true;
            this.oltLabel3.Location = new System.Drawing.Point(53, 55);
            this.oltLabel3.Name = "oltLabel3";
            this.oltLabel3.Size = new System.Drawing.Size(325, 13);
            this.oltLabel3.TabIndex = 2;
            this.oltLabel3.Text = "Electrical Hazard Assessment, Type 3 Asbestos Work, Cross Zone ";
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(53, 38);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(322, 13);
            this.oltLabel2.TabIndex = 1;
            this.oltLabel2.Text = "be required (i.e. Confined Space Entry, Open Flame and Welding,";
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(52, 21);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(342, 13);
            this.oltLabel1.TabIndex = 0;
            this.oltLabel1.Text = "Based on selection(s) made within the SWP, additional signatures may";
            // 
            // oltButton1
            // 
            this.oltButton1.Location = new System.Drawing.Point(150, 107);
            this.oltButton1.Name = "oltButton1";
            this.oltButton1.Size = new System.Drawing.Size(87, 32);
            this.oltButton1.TabIndex = 1;
            this.oltButton1.Text = "Continue";
            this.oltButton1.UseVisualStyleBackColor = true;
            this.oltButton1.Click += new System.EventHandler(this.oltButton1_Click);
            // 
            // SarniaMessagePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 145);
            this.Controls.Add(this.oltButton1);
            this.Controls.Add(this.oltPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SarniaMessagePopupForm";
            this.Text = "Alert";
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel oltPanel1;
        private OltControls.OltLabel oltLabel4;
        private OltControls.OltLabel oltLabel3;
        private OltControls.OltLabel oltLabel2;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltLabel commentsRequiredForEquipmentInServiceImageLabel;
        private OltControls.OltButton oltButton1;

    }
}
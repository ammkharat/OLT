namespace Com.Suncor.Olt.Client.Forms
{
    partial class ActionItemDefinationView
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
            this.actionItemDefinitionDetails1 = new Com.Suncor.Olt.Client.Controls.Details.ActionItemDefinitionDetails();
            this.SuspendLayout();
            // 
            // actionItemDefinitionDetails1
            // 
            this.actionItemDefinitionDetails1.AssociatedGn75BFormNumber = null;
            this.actionItemDefinitionDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionItemDefinitionDetails1.Location = new System.Drawing.Point(0, 0);
            this.actionItemDefinitionDetails1.Name = "actionItemDefinitionDetails1";
            this.actionItemDefinitionDetails1.ShowButtonAppearance = null;
            this.actionItemDefinitionDetails1.Size = new System.Drawing.Size(833, 609);
            this.actionItemDefinitionDetails1.TabIndex = 0;
            // 
            // ActionItemDefinationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 609);
            this.Controls.Add(this.actionItemDefinitionDetails1);
            this.Name = "ActionItemDefinationView";
            this.Text = "ActionItemDefinationView";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Details.ActionItemDefinitionDetails actionItemDefinitionDetails1;
    }
}
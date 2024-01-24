namespace Com.Suncor.Olt.Client.Forms
{
    partial class GridLayoutActionSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridLayoutActionSelectionForm));
            this.saveLayoutRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.revertLayoutRadioButton = new System.Windows.Forms.RadioButton();
            this.resetLayoutRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveLayoutRadioButton
            // 
            resources.ApplyResources(this.saveLayoutRadioButton, "saveLayoutRadioButton");
            this.saveLayoutRadioButton.Checked = true;
            this.saveLayoutRadioButton.Name = "saveLayoutRadioButton";
            this.saveLayoutRadioButton.TabStop = true;
            this.saveLayoutRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.revertLayoutRadioButton);
            this.groupBox1.Controls.Add(this.resetLayoutRadioButton);
            this.groupBox1.Controls.Add(this.saveLayoutRadioButton);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // revertLayoutRadioButton
            // 
            resources.ApplyResources(this.revertLayoutRadioButton, "revertLayoutRadioButton");
            this.revertLayoutRadioButton.Name = "revertLayoutRadioButton";
            this.revertLayoutRadioButton.UseVisualStyleBackColor = true;
            // 
            // resetLayoutRadioButton
            // 
            resources.ApplyResources(this.resetLayoutRadioButton, "resetLayoutRadioButton");
            this.resetLayoutRadioButton.Name = "resetLayoutRadioButton";
            this.resetLayoutRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // GridLayoutActionSelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GridLayoutActionSelectionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton saveLayoutRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton revertLayoutRadioButton;
        private System.Windows.Forms.RadioButton resetLayoutRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}
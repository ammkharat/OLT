using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class OtherCheckBoxTextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherCheckBoxTextBox));
            this.otherCheckBox = new OltCheckBox();
            this.otherDescriptionTextBox = new OltTextBox();
            this.SuspendLayout();
            // 
            // otherCheckBox
            // 
            resources.ApplyResources(this.otherCheckBox, "otherCheckBox");
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.UseVisualStyleBackColor = true;
            this.otherCheckBox.Value = null;
            // 
            // otherDescriptionTextBox
            // 
            resources.ApplyResources(this.otherDescriptionTextBox, "otherDescriptionTextBox");
            this.otherDescriptionTextBox.Name = "otherDescriptionTextBox";
            this.otherDescriptionTextBox.OltAcceptsReturn = true;
            this.otherDescriptionTextBox.OltTrimWhitespace = true;
            // 
            // OtherCheckBoxTextBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.otherCheckBox);
            this.Controls.Add(this.otherDescriptionTextBox);
            this.Name = "OtherCheckBoxTextBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltCheckBox otherCheckBox;
        private OltTextBox otherDescriptionTextBox;

    }
}

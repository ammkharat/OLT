using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class EditRestrictionReasonCodeLimitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRestrictionReasonCodeLimitForm));
            this.submitButton = new OltButton();
            this.cancelButton = new OltButton();
            this.limitTextBox = new OltIntegerBox();
            this.limitLabel = new OltLabel();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // limitTextBox
            // 
            this.limitTextBox.DecimalValue = null;
            this.limitTextBox.IntegerValue = null;
            resources.ApplyResources(this.limitTextBox, "limitTextBox");
            this.limitTextBox.Name = "limitTextBox";
            this.limitTextBox.NumericValue = null;
            // 
            // limitLabel
            // 
            resources.ApplyResources(this.limitLabel, "limitLabel");
            this.limitLabel.Name = "limitLabel";
            // 
            // EditRestrictionReasonCodeLimitForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.limitLabel);
            this.Controls.Add(this.limitTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRestrictionReasonCodeLimitForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton submitButton;
        private OltButton cancelButton;
        private OltIntegerBox limitTextBox;
        private OltLabel limitLabel;
    }
}
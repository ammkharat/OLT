using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditRestrictionReasonCodeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditRestrictionReasonCodeForm));
            this.reasonCodeTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.reasonCodeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.reasonCodeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reasonCodeErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // reasonCodeTextBox
            // 
            resources.ApplyResources(this.reasonCodeTextBox, "reasonCodeTextBox");
            this.reasonCodeTextBox.Name = "reasonCodeTextBox";
            this.reasonCodeTextBox.OltAcceptsReturn = true;
            this.reasonCodeTextBox.OltTrimWhitespace = true;
            // 
            // reasonCodeLabel
            // 
            resources.ApplyResources(this.reasonCodeLabel, "reasonCodeLabel");
            this.reasonCodeLabel.Name = "reasonCodeLabel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // reasonCodeErrorProvider
            // 
            this.reasonCodeErrorProvider.ContainerControl = this;
            // 
            // AddEditRestrictionReasonCodeForm
            // 
            this.AcceptButton = this.submitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.reasonCodeLabel);
            this.Controls.Add(this.reasonCodeTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddEditRestrictionReasonCodeForm";
            ((System.ComponentModel.ISupportInitialize)(this.reasonCodeErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltTextBox reasonCodeTextBox;
        private OltLabel reasonCodeLabel;
        private OltButton cancelButton;
        private OltButton submitButton;
        private System.Windows.Forms.ErrorProvider reasonCodeErrorProvider;
    }
}
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class LogGuidelineConfigurationEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogGuidelineConfigurationEditForm));
            this.saveAndCloseButton = new OltButton();
            this.cancelButton = new OltButton();
            this.guidelineTextBox = new OltTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.AccessibleDescription = null;
            this.saveAndCloseButton.AccessibleName = null;
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.saveAndCloseButton.BackgroundImage = null;
            this.errorProvider.SetError(this.saveAndCloseButton, resources.GetString("saveAndCloseButton.Error"));
            this.saveAndCloseButton.Font = null;
            this.errorProvider.SetIconAlignment(this.saveAndCloseButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("saveAndCloseButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.saveAndCloseButton, ((int)(resources.GetObject("saveAndCloseButton.IconPadding"))));
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleDescription = null;
            this.cancelButton.AccessibleName = null;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.BackgroundImage = null;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.cancelButton.Font = null;
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // guidelineTextBox
            // 
            this.guidelineTextBox.AcceptsReturn = true;
            this.guidelineTextBox.AcceptsTab = true;
            this.guidelineTextBox.AccessibleDescription = null;
            this.guidelineTextBox.AccessibleName = null;
            resources.ApplyResources(this.guidelineTextBox, "guidelineTextBox");
            this.guidelineTextBox.BackgroundImage = null;
            this.errorProvider.SetError(this.guidelineTextBox, resources.GetString("guidelineTextBox.Error"));
            this.guidelineTextBox.Font = null;
            this.errorProvider.SetIconAlignment(this.guidelineTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("guidelineTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.guidelineTextBox, ((int)(resources.GetObject("guidelineTextBox.IconPadding"))));
            this.guidelineTextBox.Name = "guidelineTextBox";
            this.guidelineTextBox.OltAcceptsReturn = true;
            this.guidelineTextBox.OltTrimWhitespace = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // LogGuidelineConfigurationEditForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.guidelineTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.Font = null;
            this.Name = "LogGuidelineConfigurationEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton saveAndCloseButton;
        private OltButton cancelButton;
        private OltTextBox guidelineTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
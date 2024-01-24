using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditBusinessCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditBusinessCategoryForm));
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.nameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.shortNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.shortNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.defaultSAPWorkOrderCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.defaultSAPNotificationCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = true;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // shortNameTextBox
            // 
            resources.ApplyResources(this.shortNameTextBox, "shortNameTextBox");
            this.shortNameTextBox.Name = "shortNameTextBox";
            this.shortNameTextBox.OltAcceptsReturn = true;
            this.shortNameTextBox.OltTrimWhitespace = true;
            // 
            // shortNameLabel
            // 
            resources.ApplyResources(this.shortNameLabel, "shortNameLabel");
            this.shortNameLabel.Name = "shortNameLabel";
            // 
            // defaultSAPWorkOrderCheckBox
            // 
            resources.ApplyResources(this.defaultSAPWorkOrderCheckBox, "defaultSAPWorkOrderCheckBox");
            this.defaultSAPWorkOrderCheckBox.Name = "defaultSAPWorkOrderCheckBox";
            this.defaultSAPWorkOrderCheckBox.UseVisualStyleBackColor = true;
            this.defaultSAPWorkOrderCheckBox.Value = null;
            // 
            // defaultSAPNotificationCheckBox
            // 
            resources.ApplyResources(this.defaultSAPNotificationCheckBox, "defaultSAPNotificationCheckBox");
            this.defaultSAPNotificationCheckBox.Name = "defaultSAPNotificationCheckBox";
            this.defaultSAPNotificationCheckBox.UseVisualStyleBackColor = true;
            this.defaultSAPNotificationCheckBox.Value = null;
            // 
            // AddEditBusinessCategoryForm
            // 
            this.AcceptButton = this.submitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.defaultSAPNotificationCheckBox);
            this.Controls.Add(this.defaultSAPWorkOrderCheckBox);
            this.Controls.Add(this.shortNameLabel);
            this.Controls.Add(this.shortNameTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddEditBusinessCategoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton submitButton;
        private OltButton cancelButton;
        private OltLabel nameLabel;
        private OltTextBox nameTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltLabel shortNameLabel;
        private OltTextBox shortNameTextBox;
        private OltCheckBox defaultSAPNotificationCheckBox;
        private OltCheckBox defaultSAPWorkOrderCheckBox;
    }
}
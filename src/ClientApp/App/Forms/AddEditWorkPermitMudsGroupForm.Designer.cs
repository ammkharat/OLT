namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditWorkPermitMudsGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditWorkPermitMontrealGroupForm));
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.errorProvider.SetError(this.nameTextBox, resources.GetString("nameTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.nameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nameTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.nameTextBox, ((int)(resources.GetObject("nameTextBox.IconPadding"))));
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = true;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.errorProvider.SetError(this.oltLabel1, resources.GetString("oltLabel1.Error"));
            this.errorProvider.SetIconAlignment(this.oltLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.oltLabel1, ((int)(resources.GetObject("oltLabel1.IconPadding"))));
            this.oltLabel1.Name = "oltLabel1";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.errorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.errorProvider.SetError(this.okButton, resources.GetString("okButton.Error"));
            this.errorProvider.SetIconAlignment(this.okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("okButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.okButton, ((int)(resources.GetObject("okButton.IconPadding"))));
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // AddEditWorkPermitMontrealGroupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddEditWorkPermitMontrealGroupForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltControls.OltTextBox nameTextBox;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltButton cancelButton;
        private OltControls.OltButton okButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
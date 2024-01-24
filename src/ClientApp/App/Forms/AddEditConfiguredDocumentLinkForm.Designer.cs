using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditConfiguredDocumentLinkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditConfiguredDocumentLinkForm));
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.titleTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.linkTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.errorProvider.SetError(this.oltLabel2, resources.GetString("oltLabel2.Error"));
            this.errorProvider.SetIconAlignment(this.oltLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.oltLabel2, ((int)(resources.GetObject("oltLabel2.IconPadding"))));
            this.oltLabel2.Name = "oltLabel2";
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.errorProvider.SetError(this.oltLabel3, resources.GetString("oltLabel3.Error"));
            this.errorProvider.SetIconAlignment(this.oltLabel3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.oltLabel3, ((int)(resources.GetObject("oltLabel3.IconPadding"))));
            this.oltLabel3.Name = "oltLabel3";
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.errorProvider.SetError(this.titleTextBox, resources.GetString("titleTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.titleTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("titleTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.titleTextBox, ((int)(resources.GetObject("titleTextBox.IconPadding"))));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.OltAcceptsReturn = true;
            this.titleTextBox.OltTrimWhitespace = true;
            // 
            // linkTextBox
            // 
            resources.ApplyResources(this.linkTextBox, "linkTextBox");
            this.errorProvider.SetError(this.linkTextBox, resources.GetString("linkTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.linkTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("linkTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.linkTextBox, ((int)(resources.GetObject("linkTextBox.IconPadding"))));
            this.linkTextBox.Name = "linkTextBox";
            this.linkTextBox.OltAcceptsReturn = true;
            this.linkTextBox.OltTrimWhitespace = true;
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
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // AddEditConfiguredDocumentLinkForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.linkTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.oltLabel3);
            this.Controls.Add(this.oltLabel2);
            this.Name = "AddEditConfiguredDocumentLinkForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabel oltLabel2;
        private OltLabel oltLabel3;
        private OltTextBox titleTextBox;
        private OltTextBox linkTextBox;
        private OltButton okButton;
        private OltButton cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
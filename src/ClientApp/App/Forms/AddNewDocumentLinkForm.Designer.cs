using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddNewDocumentLinkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewDocumentLinkForm));
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.titleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.linkLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.titleDocumentTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.linkDocumentTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.titleErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.browseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.titleErrorProvider)).BeginInit();
            this.oltPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // linkLabel
            // 
            resources.ApplyResources(this.linkLabel, "linkLabel");
            this.linkLabel.Name = "linkLabel";
            // 
            // titleDocumentTextBox
            // 
            resources.ApplyResources(this.titleDocumentTextBox, "titleDocumentTextBox");
            this.titleDocumentTextBox.Name = "titleDocumentTextBox";
            this.titleDocumentTextBox.OltAcceptsReturn = true;
            this.titleDocumentTextBox.OltTrimWhitespace = true;
            // 
            // linkDocumentTextBox
            // 
            resources.ApplyResources(this.linkDocumentTextBox, "linkDocumentTextBox");
            this.linkDocumentTextBox.Name = "linkDocumentTextBox";
            this.linkDocumentTextBox.OltAcceptsReturn = true;
            this.linkDocumentTextBox.OltTrimWhitespace = true;
            // 
            // titleErrorProvider
            // 
            this.titleErrorProvider.ContainerControl = this;
            // 
            // browseButton
            // 
            resources.ApplyResources(this.browseButton, "browseButton");
            this.browseButton.Name = "browseButton";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.browseButton);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Name = "oltPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // linkErrorProvider
            // 
            this.linkErrorProvider.ContainerControl = this;
            // 
            // AddNewDocumentLinkForm
            // 
            this.AcceptButton = this.addButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkDocumentTextBox);
            this.Controls.Add(this.titleDocumentTextBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.titleLabel);
            this.MaximizeBox = false;
            this.Name = "AddNewDocumentLinkForm";
            ((System.ComponentModel.ISupportInitialize)(this.titleErrorProvider)).EndInit();
            this.oltPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.linkErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton cancelButton;
        private OltButton addButton;
        private OltLabel titleLabel;
        private OltLabel linkLabel;
        private OltTextBox titleDocumentTextBox;
        private OltTextBox linkDocumentTextBox;
        private ErrorProvider titleErrorProvider;
        private ErrorProvider linkErrorProvider;
        private OltButton browseButton;
        private OltPanel oltPanel1;
        private Panel panel1;
    }
}
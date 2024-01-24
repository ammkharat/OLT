using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class TargetAssociationSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetAssociationSelectionForm));
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeTargetBtn = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addTargetBtn = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.searchPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.SearchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.nameGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.TargetNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.associationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.searchResultGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.AssociatedGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.searchPanel.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.associationErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // removeTargetBtn
            // 
            resources.ApplyResources(this.removeTargetBtn, "removeTargetBtn");
            this.removeTargetBtn.Name = "removeTargetBtn";
            this.removeTargetBtn.UseVisualStyleBackColor = true;
            // 
            // addTargetBtn
            // 
            resources.ApplyResources(this.addTargetBtn, "addTargetBtn");
            this.addTargetBtn.Name = "addTargetBtn";
            this.addTargetBtn.UseVisualStyleBackColor = true;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.SearchButton);
            this.searchPanel.Controls.Add(this.nameGroupBox);
            resources.ApplyResources(this.searchPanel, "searchPanel");
            this.searchPanel.Name = "searchPanel";
            // 
            // SearchButton
            // 
            resources.ApplyResources(this.SearchButton, "SearchButton");
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.TargetNameTextBox);
            resources.ApplyResources(this.nameGroupBox, "nameGroupBox");
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.TabStop = false;
            // 
            // TargetNameTextBox
            // 
            resources.ApplyResources(this.TargetNameTextBox, "TargetNameTextBox");
            this.TargetNameTextBox.Name = "TargetNameTextBox";
            this.TargetNameTextBox.OltAcceptsReturn = true;
            this.TargetNameTextBox.OltTrimWhitespace = true;
            // 
            // associationErrorProvider
            // 
            this.associationErrorProvider.ContainerControl = this;
            // 
            // searchResultGroupBox
            // 
            resources.ApplyResources(this.searchResultGroupBox, "searchResultGroupBox");
            this.searchResultGroupBox.Name = "searchResultGroupBox";
            this.searchResultGroupBox.TabStop = false;
            // 
            // AssociatedGroupBox
            // 
            resources.ApplyResources(this.AssociatedGroupBox, "AssociatedGroupBox");
            this.AssociatedGroupBox.Name = "AssociatedGroupBox";
            this.AssociatedGroupBox.TabStop = false;
            // 
            // TargetAssociationSelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AssociatedGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeTargetBtn);
            this.Controls.Add(this.addTargetBtn);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.searchResultGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TargetAssociationSelectionForm";
            this.searchPanel.ResumeLayout(false);
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.associationErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltTextBox TargetNameTextBox;
        private OltButton SearchButton;
        private OltPanel searchPanel;
        private OltButton addTargetBtn;
        private OltButton removeTargetBtn;
        private OltButton cancelButton;
        private OltButton saveButton;
        private System.Windows.Forms.ErrorProvider associationErrorProvider;
        private OltGroupBox nameGroupBox;
        private OltGroupBox searchResultGroupBox;
        private OltGroupBox AssociatedGroupBox;

    }
}
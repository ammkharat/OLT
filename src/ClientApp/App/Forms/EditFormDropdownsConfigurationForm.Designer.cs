using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class EditFormDropdownsConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWorkPermitDropdownsConfigurationForm));
            this.saveAndCloseButton = new OltButton();
            this.cancelButton = new OltButton();
            this.contentPanel = new OltPanel();
            this.deleteValueButton = new OltButton();
            this.editValueButton = new OltButton();
            this.addValueButton = new OltButton();
            this.oltLabel2 = new OltLabel();
            this.oltLabel1 = new OltLabel();
            this.dropdownNameLabel = new OltLabel();
            this.gridPanel = new OltPanel();
            this.moveQuestionDownButton = new OltButton();
            this.moveQuestionUpButton = new OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // saveAndCloseButton
            // 
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.errorProvider.SetError(this.saveAndCloseButton, resources.GetString("saveAndCloseButton.Error"));
            this.errorProvider.SetIconAlignment(this.saveAndCloseButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("saveAndCloseButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.saveAndCloseButton, ((int)(resources.GetObject("saveAndCloseButton.IconPadding"))));
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
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
            // contentPanel
            // 
            resources.ApplyResources(this.contentPanel, "contentPanel");
            this.contentPanel.Controls.Add(this.cancelButton);
            this.contentPanel.Controls.Add(this.saveAndCloseButton);
            this.contentPanel.Controls.Add(this.deleteValueButton);
            this.contentPanel.Controls.Add(this.editValueButton);
            this.contentPanel.Controls.Add(this.addValueButton);
            this.contentPanel.Controls.Add(this.oltLabel2);
            this.contentPanel.Controls.Add(this.oltLabel1);
            this.contentPanel.Controls.Add(this.dropdownNameLabel);
            this.contentPanel.Controls.Add(this.gridPanel);
            this.contentPanel.Controls.Add(this.moveQuestionDownButton);
            this.contentPanel.Controls.Add(this.moveQuestionUpButton);
            this.errorProvider.SetError(this.contentPanel, resources.GetString("contentPanel.Error"));
            this.errorProvider.SetIconAlignment(this.contentPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("contentPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.contentPanel, ((int)(resources.GetObject("contentPanel.IconPadding"))));
            this.contentPanel.Name = "contentPanel";
            // 
            // deleteValueButton
            // 
            resources.ApplyResources(this.deleteValueButton, "deleteValueButton");
            this.errorProvider.SetError(this.deleteValueButton, resources.GetString("deleteValueButton.Error"));
            this.errorProvider.SetIconAlignment(this.deleteValueButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("deleteValueButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.deleteValueButton, ((int)(resources.GetObject("deleteValueButton.IconPadding"))));
            this.deleteValueButton.Name = "deleteValueButton";
            this.deleteValueButton.UseVisualStyleBackColor = true;
            // 
            // editValueButton
            // 
            resources.ApplyResources(this.editValueButton, "editValueButton");
            this.errorProvider.SetError(this.editValueButton, resources.GetString("editValueButton.Error"));
            this.errorProvider.SetIconAlignment(this.editValueButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("editValueButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.editValueButton, ((int)(resources.GetObject("editValueButton.IconPadding"))));
            this.editValueButton.Name = "editValueButton";
            this.editValueButton.UseVisualStyleBackColor = true;
            // 
            // addValueButton
            // 
            resources.ApplyResources(this.addValueButton, "addValueButton");
            this.errorProvider.SetError(this.addValueButton, resources.GetString("addValueButton.Error"));
            this.errorProvider.SetIconAlignment(this.addValueButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("addValueButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.addValueButton, ((int)(resources.GetObject("addValueButton.IconPadding"))));
            this.addValueButton.Name = "addValueButton";
            this.addValueButton.UseVisualStyleBackColor = true;
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.errorProvider.SetError(this.oltLabel2, resources.GetString("oltLabel2.Error"));
            this.errorProvider.SetIconAlignment(this.oltLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.oltLabel2, ((int)(resources.GetObject("oltLabel2.IconPadding"))));
            this.oltLabel2.Name = "oltLabel2";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.errorProvider.SetError(this.oltLabel1, resources.GetString("oltLabel1.Error"));
            this.errorProvider.SetIconAlignment(this.oltLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.oltLabel1, ((int)(resources.GetObject("oltLabel1.IconPadding"))));
            this.oltLabel1.Name = "oltLabel1";
            // 
            // dropdownNameLabel
            // 
            resources.ApplyResources(this.dropdownNameLabel, "dropdownNameLabel");
            this.errorProvider.SetError(this.dropdownNameLabel, resources.GetString("dropdownNameLabel.Error"));
            this.errorProvider.SetIconAlignment(this.dropdownNameLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dropdownNameLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.dropdownNameLabel, ((int)(resources.GetObject("dropdownNameLabel.IconPadding"))));
            this.dropdownNameLabel.Name = "dropdownNameLabel";
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.errorProvider.SetError(this.gridPanel, resources.GetString("gridPanel.Error"));
            this.errorProvider.SetIconAlignment(this.gridPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gridPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.gridPanel, ((int)(resources.GetObject("gridPanel.IconPadding"))));
            this.gridPanel.Name = "gridPanel";
            // 
            // moveQuestionDownButton
            // 
            resources.ApplyResources(this.moveQuestionDownButton, "moveQuestionDownButton");
            this.errorProvider.SetError(this.moveQuestionDownButton, resources.GetString("moveQuestionDownButton.Error"));
            this.errorProvider.SetIconAlignment(this.moveQuestionDownButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("moveQuestionDownButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.moveQuestionDownButton, ((int)(resources.GetObject("moveQuestionDownButton.IconPadding"))));
            this.moveQuestionDownButton.Name = "moveQuestionDownButton";
            this.moveQuestionDownButton.UseVisualStyleBackColor = true;
            // 
            // moveQuestionUpButton
            // 
            resources.ApplyResources(this.moveQuestionUpButton, "moveQuestionUpButton");
            this.errorProvider.SetError(this.moveQuestionUpButton, resources.GetString("moveQuestionUpButton.Error"));
            this.errorProvider.SetIconAlignment(this.moveQuestionUpButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("moveQuestionUpButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.moveQuestionUpButton, ((int)(resources.GetObject("moveQuestionUpButton.IconPadding"))));
            this.moveQuestionUpButton.Name = "moveQuestionUpButton";
            this.moveQuestionUpButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // EditWorkPermitMontrealDropdownsConfigurationForm
            // 
            this.AcceptButton = this.saveAndCloseButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.contentPanel);
            this.Name = "EditWorkPermitMontrealDropdownsConfigurationForm";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltPanel contentPanel;
        private OltButton moveQuestionUpButton;
        private OltButton moveQuestionDownButton;
        private OltPanel gridPanel;
        private OltLabel dropdownNameLabel;
        private OltLabel oltLabel1;
        private OltLabel oltLabel2;
        private OltButton addValueButton;
        private OltButton editValueButton;
        private OltButton deleteValueButton;
        private OltButton saveAndCloseButton;
        private OltButton cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
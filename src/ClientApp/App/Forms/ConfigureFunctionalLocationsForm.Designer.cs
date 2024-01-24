using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureFunctionalLocationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureFunctionalLocationsForm));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.functionalLocationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.flocControl = new Com.Suncor.Olt.Client.Controls.SingleSelectFunctionalLocationControl();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.functionalLocationErrorProvider)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Controls.Add(this.deleteButton);
            this.panelBottom.Controls.Add(this.editButton);
            this.panelBottom.Controls.Add(this.addButton);
            this.panelBottom.Controls.Add(this.cancelButton);
            this.functionalLocationErrorProvider.SetError(this.panelBottom, resources.GetString("panelBottom.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.panelBottom, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panelBottom.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.panelBottom, ((int)(resources.GetObject("panelBottom.IconPadding"))));
            this.panelBottom.Name = "panelBottom";
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.functionalLocationErrorProvider.SetError(this.deleteButton, resources.GetString("deleteButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.deleteButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("deleteButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.deleteButton, ((int)(resources.GetObject("deleteButton.IconPadding"))));
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.functionalLocationErrorProvider.SetError(this.editButton, resources.GetString("editButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.editButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("editButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.editButton, ((int)(resources.GetObject("editButton.IconPadding"))));
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.functionalLocationErrorProvider.SetError(this.addButton, resources.GetString("addButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.addButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("addButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.addButton, ((int)(resources.GetObject("addButton.IconPadding"))));
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.functionalLocationErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // functionalLocationErrorProvider
            // 
            this.functionalLocationErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.functionalLocationErrorProvider, "functionalLocationErrorProvider");
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.flocControl);
            this.functionalLocationErrorProvider.SetError(this.mainPanel, resources.GetString("mainPanel.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.mainPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("mainPanel.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.mainPanel, ((int)(resources.GetObject("mainPanel.IconPadding"))));
            this.mainPanel.Name = "mainPanel";
            // 
            // flocControl
            // 
            resources.ApplyResources(this.flocControl, "flocControl");
            this.functionalLocationErrorProvider.SetError(this.flocControl, resources.GetString("flocControl.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.flocControl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flocControl.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.flocControl, ((int)(resources.GetObject("flocControl.IconPadding"))));
            this.flocControl.Name = "flocControl";
            // 
            // ConfigureFunctionalLocationsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelBottom);
            this.MaximizeBox = false;
            this.Name = "ConfigureFunctionalLocationsForm";
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.functionalLocationErrorProvider)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private OltButton cancelButton; 
        private System.Windows.Forms.ErrorProvider functionalLocationErrorProvider;
        private System.Windows.Forms.Panel mainPanel;
        private Com.Suncor.Olt.Client.Controls.SingleSelectFunctionalLocationControl flocControl;
        private OltButton addButton;
        private OltButton deleteButton;
        private OltButton editButton;
    }
}
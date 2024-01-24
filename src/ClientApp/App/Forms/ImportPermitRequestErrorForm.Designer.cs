using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ImportPermitRequestErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPermitRequestErrorForm));
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.startDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.mainDisplayTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.descriptionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.copyRecommendationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.startDateErrorProvider)).BeginInit();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.startDateErrorProvider.SetError(this.okButton, resources.GetString("okButton.Error"));
            this.endDateErrorProvider.SetError(this.okButton, resources.GetString("okButton.Error1"));
            this.endDateErrorProvider.SetIconAlignment(this.okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("okButton.IconAlignment"))));
            this.startDateErrorProvider.SetIconAlignment(this.okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("okButton.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.okButton, ((int)(resources.GetObject("okButton.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.okButton, ((int)(resources.GetObject("okButton.IconPadding1"))));
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // startDateErrorProvider
            // 
            this.startDateErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.startDateErrorProvider, "startDateErrorProvider");
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.okButton);
            this.endDateErrorProvider.SetError(this.buttonPanel, resources.GetString("buttonPanel.Error"));
            this.startDateErrorProvider.SetError(this.buttonPanel, resources.GetString("buttonPanel.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.buttonPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonPanel.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.buttonPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonPanel.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.buttonPanel, ((int)(resources.GetObject("buttonPanel.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.buttonPanel, ((int)(resources.GetObject("buttonPanel.IconPadding1"))));
            this.buttonPanel.Name = "buttonPanel";
            // 
            // mainDisplayTextBox
            // 
            resources.ApplyResources(this.mainDisplayTextBox, "mainDisplayTextBox");
            this.startDateErrorProvider.SetError(this.mainDisplayTextBox, resources.GetString("mainDisplayTextBox.Error"));
            this.endDateErrorProvider.SetError(this.mainDisplayTextBox, resources.GetString("mainDisplayTextBox.Error1"));
            this.endDateErrorProvider.SetIconAlignment(this.mainDisplayTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("mainDisplayTextBox.IconAlignment"))));
            this.startDateErrorProvider.SetIconAlignment(this.mainDisplayTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("mainDisplayTextBox.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.mainDisplayTextBox, ((int)(resources.GetObject("mainDisplayTextBox.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.mainDisplayTextBox, ((int)(resources.GetObject("mainDisplayTextBox.IconPadding1"))));
            this.mainDisplayTextBox.Name = "mainDisplayTextBox";
            this.mainDisplayTextBox.OltAcceptsReturn = true;
            this.mainDisplayTextBox.OltTrimWhitespace = true;
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.startDateErrorProvider.SetError(this.descriptionLabel, resources.GetString("descriptionLabel.Error"));
            this.endDateErrorProvider.SetError(this.descriptionLabel, resources.GetString("descriptionLabel.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.descriptionLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("descriptionLabel.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.descriptionLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("descriptionLabel.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.descriptionLabel, ((int)(resources.GetObject("descriptionLabel.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.descriptionLabel, ((int)(resources.GetObject("descriptionLabel.IconPadding1"))));
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // copyRecommendationLabel
            // 
            resources.ApplyResources(this.copyRecommendationLabel, "copyRecommendationLabel");
            this.startDateErrorProvider.SetError(this.copyRecommendationLabel, resources.GetString("copyRecommendationLabel.Error"));
            this.endDateErrorProvider.SetError(this.copyRecommendationLabel, resources.GetString("copyRecommendationLabel.Error1"));
            this.startDateErrorProvider.SetIconAlignment(this.copyRecommendationLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("copyRecommendationLabel.IconAlignment"))));
            this.endDateErrorProvider.SetIconAlignment(this.copyRecommendationLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("copyRecommendationLabel.IconAlignment1"))));
            this.endDateErrorProvider.SetIconPadding(this.copyRecommendationLabel, ((int)(resources.GetObject("copyRecommendationLabel.IconPadding"))));
            this.startDateErrorProvider.SetIconPadding(this.copyRecommendationLabel, ((int)(resources.GetObject("copyRecommendationLabel.IconPadding1"))));
            this.copyRecommendationLabel.Name = "copyRecommendationLabel";
            // 
            // endDateErrorProvider
            // 
            this.endDateErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.endDateErrorProvider, "endDateErrorProvider");
            // 
            // ImportPermitRequestErrorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.Controls.Add(this.copyRecommendationLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.mainDisplayTextBox);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ImportPermitRequestErrorForm";
            ((System.ComponentModel.ISupportInitialize)(this.startDateErrorProvider)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.endDateErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton okButton;
        private System.Windows.Forms.ErrorProvider startDateErrorProvider;
        private OltPanel buttonPanel;
        private System.Windows.Forms.ErrorProvider endDateErrorProvider;
        private OltLabel descriptionLabel;
        private OltTextBox mainDisplayTextBox;
        private OltLabel copyRecommendationLabel;
    }
}
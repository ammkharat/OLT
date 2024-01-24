using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureRestrictionReportingLimitsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureRestrictionReportingLimitsForm));
            this.siteDisplayLabel = new System.Windows.Forms.Label();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.suffixLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.daysToEditDeviationAlertsTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.limitsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.daysToEditDeviationAlertsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.siteGroupBox.SuspendLayout();
            this.limitsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // siteDisplayLabel
            // 
            resources.ApplyResources(this.siteDisplayLabel, "siteDisplayLabel");
            this.errorProvider.SetError(this.siteDisplayLabel, resources.GetString("siteDisplayLabel.Error"));
            this.errorProvider.SetIconAlignment(this.siteDisplayLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("siteDisplayLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.siteDisplayLabel, ((int)(resources.GetObject("siteDisplayLabel.IconPadding"))));
            this.siteDisplayLabel.Name = "siteDisplayLabel";
            // 
            // prefixLabel
            // 
            resources.ApplyResources(this.prefixLabel, "prefixLabel");
            this.errorProvider.SetError(this.prefixLabel, resources.GetString("prefixLabel.Error"));
            this.errorProvider.SetIconAlignment(this.prefixLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("prefixLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.prefixLabel, ((int)(resources.GetObject("prefixLabel.IconPadding"))));
            this.prefixLabel.Name = "prefixLabel";
            // 
            // suffixLabel
            // 
            resources.ApplyResources(this.suffixLabel, "suffixLabel");
            this.errorProvider.SetError(this.suffixLabel, resources.GetString("suffixLabel.Error"));
            this.errorProvider.SetIconAlignment(this.suffixLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("suffixLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.suffixLabel, ((int)(resources.GetObject("suffixLabel.IconPadding"))));
            this.suffixLabel.Name = "suffixLabel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.errorProvider.SetError(this.saveButton, resources.GetString("saveButton.Error"));
            this.errorProvider.SetIconAlignment(this.saveButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("saveButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.saveButton, ((int)(resources.GetObject("saveButton.IconPadding"))));
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
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
            // daysToEditDeviationAlertsTextBox
            // 
            resources.ApplyResources(this.daysToEditDeviationAlertsTextBox, "daysToEditDeviationAlertsTextBox");
            this.daysToEditDeviationAlertsTextBox.AlwaysInEditMode = true;
            this.errorProvider.SetError(this.daysToEditDeviationAlertsTextBox, resources.GetString("daysToEditDeviationAlertsTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.daysToEditDeviationAlertsTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("daysToEditDeviationAlertsTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.daysToEditDeviationAlertsTextBox, ((int)(resources.GetObject("daysToEditDeviationAlertsTextBox.IconPadding"))));
            this.daysToEditDeviationAlertsTextBox.MaskInput = "nnn";
            this.daysToEditDeviationAlertsTextBox.Name = "daysToEditDeviationAlertsTextBox";
            this.daysToEditDeviationAlertsTextBox.Nullable = true;
            this.daysToEditDeviationAlertsTextBox.NullText = "0";
            this.daysToEditDeviationAlertsTextBox.PromptChar = ' ';
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // siteGroupBox
            // 
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteDisplayLabel);
            this.errorProvider.SetError(this.siteGroupBox, resources.GetString("siteGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.siteGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("siteGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.siteGroupBox, ((int)(resources.GetObject("siteGroupBox.IconPadding"))));
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // limitsGroupBox
            // 
            resources.ApplyResources(this.limitsGroupBox, "limitsGroupBox");
            this.limitsGroupBox.Controls.Add(this.label1);
            this.limitsGroupBox.Controls.Add(this.daysToEditDeviationAlertsTextBox);
            this.limitsGroupBox.Controls.Add(this.prefixLabel);
            this.limitsGroupBox.Controls.Add(this.suffixLabel);
            this.errorProvider.SetError(this.limitsGroupBox, resources.GetString("limitsGroupBox.Error"));
            this.errorProvider.SetIconAlignment(this.limitsGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("limitsGroupBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.limitsGroupBox, ((int)(resources.GetObject("limitsGroupBox.IconPadding"))));
            this.limitsGroupBox.Name = "limitsGroupBox";
            this.limitsGroupBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // ConfigureRestrictionReportingLimitsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.limitsGroupBox);
            this.Controls.Add(this.siteGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigureRestrictionReportingLimitsForm";
            ((System.ComponentModel.ISupportInitialize)(this.daysToEditDeviationAlertsTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.limitsGroupBox.ResumeLayout(false);
            this.limitsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label siteDisplayLabel;
        private System.Windows.Forms.Label prefixLabel;
        private System.Windows.Forms.Label suffixLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private OltUltraNumericEditor daysToEditDeviationAlertsTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox limitsGroupBox;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private System.Windows.Forms.Label label1;
    }
}
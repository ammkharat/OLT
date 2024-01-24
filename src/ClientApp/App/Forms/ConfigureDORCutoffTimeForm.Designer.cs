using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureDORCutoffTimeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDORCutoffTimeForm));
            this.siteDisplayLabel = new System.Windows.Forms.Label();
            this.prefixLabel = new System.Windows.Forms.Label();
            this.suffixLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.limitsGroupBox = new System.Windows.Forms.GroupBox();
            this.timePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.siteGroupBox.SuspendLayout();
            this.limitsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // siteDisplayLabel
            // 
            resources.ApplyResources(this.siteDisplayLabel, "siteDisplayLabel");
            this.siteDisplayLabel.Name = "siteDisplayLabel";
            // 
            // prefixLabel
            // 
            resources.ApplyResources(this.prefixLabel, "prefixLabel");
            this.prefixLabel.Name = "prefixLabel";
            // 
            // suffixLabel
            // 
            resources.ApplyResources(this.suffixLabel, "suffixLabel");
            this.suffixLabel.Name = "suffixLabel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // siteGroupBox
            // 
            this.siteGroupBox.Controls.Add(this.siteDisplayLabel);
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // limitsGroupBox
            // 
            this.limitsGroupBox.Controls.Add(this.timePicker);
            this.limitsGroupBox.Controls.Add(this.prefixLabel);
            this.limitsGroupBox.Controls.Add(this.suffixLabel);
            resources.ApplyResources(this.limitsGroupBox, "limitsGroupBox");
            this.limitsGroupBox.Name = "limitsGroupBox";
            this.limitsGroupBox.TabStop = false;
            // 
            // timePicker
            // 
            this.timePicker.Checked = true;
            this.timePicker.CustomFormat = "HH:mm";
            resources.ApplyResources(this.timePicker, "timePicker");
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowCheckBox = false;
            // 
            // ConfigureDORCutoffTimeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.limitsGroupBox);
            this.Controls.Add(this.siteGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigureDORCutoffTimeForm";
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
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox limitsGroupBox;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private OltTimePicker timePicker;
    }
}
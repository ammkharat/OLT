using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigurePreApprovedTargetRangesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurePreApprovedTargetRangesForm));
            this.targetDefinitionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.descriptionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.targetDefinitionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.thresholdsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.nteMinUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.maxUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nteMaxUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nteMinTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.minTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.maxTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.nteMaxTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.nteMinLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.maxLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nteMaxLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nteMaxCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.maxCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.nteMinCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.minCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.ThresholdValuesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.targetDefintionGroupBox = new System.Windows.Forms.GroupBox();
            this.thresholdsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValuesErrorProvider)).BeginInit();
            this.targetDefintionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetDefinitionLabel
            // 
            resources.ApplyResources(this.targetDefinitionLabel, "targetDefinitionLabel");
            this.ThresholdValuesErrorProvider.SetError(this.targetDefinitionLabel, resources.GetString("targetDefinitionLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.targetDefinitionLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefinitionLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.targetDefinitionLabel, ((int)(resources.GetObject("targetDefinitionLabel.IconPadding"))));
            this.targetDefinitionLabel.Name = "targetDefinitionLabel";
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.ThresholdValuesErrorProvider.SetError(this.descriptionLabel, resources.GetString("descriptionLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.descriptionLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("descriptionLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.descriptionLabel, ((int)(resources.GetObject("descriptionLabel.IconPadding"))));
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // targetDefinitionTextBox
            // 
            resources.ApplyResources(this.targetDefinitionTextBox, "targetDefinitionTextBox");
            this.ThresholdValuesErrorProvider.SetError(this.targetDefinitionTextBox, resources.GetString("targetDefinitionTextBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.targetDefinitionTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefinitionTextBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.targetDefinitionTextBox, ((int)(resources.GetObject("targetDefinitionTextBox.IconPadding"))));
            this.targetDefinitionTextBox.Name = "targetDefinitionTextBox";
            this.targetDefinitionTextBox.OltAcceptsReturn = true;
            this.targetDefinitionTextBox.OltTrimWhitespace = true;
            // 
            // thresholdsGroupBox
            // 
            resources.ApplyResources(this.thresholdsGroupBox, "thresholdsGroupBox");
            this.thresholdsGroupBox.Controls.Add(this.nteMinUnitLabel);
            this.thresholdsGroupBox.Controls.Add(this.minUnitLabel);
            this.thresholdsGroupBox.Controls.Add(this.maxUnitLabel);
            this.thresholdsGroupBox.Controls.Add(this.nteMaxUnitLabel);
            this.thresholdsGroupBox.Controls.Add(this.nteMinTextBox);
            this.thresholdsGroupBox.Controls.Add(this.minTextBox);
            this.thresholdsGroupBox.Controls.Add(this.maxTextBox);
            this.thresholdsGroupBox.Controls.Add(this.nteMaxTextBox);
            this.thresholdsGroupBox.Controls.Add(this.nteMinLabel);
            this.thresholdsGroupBox.Controls.Add(this.minLabel);
            this.thresholdsGroupBox.Controls.Add(this.maxLabel);
            this.thresholdsGroupBox.Controls.Add(this.nteMaxLabel);
            this.thresholdsGroupBox.Controls.Add(this.nteMaxCheckBox);
            this.thresholdsGroupBox.Controls.Add(this.maxCheckBox);
            this.thresholdsGroupBox.Controls.Add(this.nteMinCheckBox);
            this.thresholdsGroupBox.Controls.Add(this.minCheckBox);
            this.ThresholdValuesErrorProvider.SetError(this.thresholdsGroupBox, resources.GetString("thresholdsGroupBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.thresholdsGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("thresholdsGroupBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.thresholdsGroupBox, ((int)(resources.GetObject("thresholdsGroupBox.IconPadding"))));
            this.thresholdsGroupBox.Name = "thresholdsGroupBox";
            this.thresholdsGroupBox.TabStop = false;
            // 
            // nteMinUnitLabel
            // 
            resources.ApplyResources(this.nteMinUnitLabel, "nteMinUnitLabel");
            this.ThresholdValuesErrorProvider.SetError(this.nteMinUnitLabel, resources.GetString("nteMinUnitLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMinUnitLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMinUnitLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMinUnitLabel, ((int)(resources.GetObject("nteMinUnitLabel.IconPadding"))));
            this.nteMinUnitLabel.Name = "nteMinUnitLabel";
            // 
            // minUnitLabel
            // 
            resources.ApplyResources(this.minUnitLabel, "minUnitLabel");
            this.ThresholdValuesErrorProvider.SetError(this.minUnitLabel, resources.GetString("minUnitLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.minUnitLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minUnitLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.minUnitLabel, ((int)(resources.GetObject("minUnitLabel.IconPadding"))));
            this.minUnitLabel.Name = "minUnitLabel";
            // 
            // maxUnitLabel
            // 
            resources.ApplyResources(this.maxUnitLabel, "maxUnitLabel");
            this.ThresholdValuesErrorProvider.SetError(this.maxUnitLabel, resources.GetString("maxUnitLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.maxUnitLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxUnitLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.maxUnitLabel, ((int)(resources.GetObject("maxUnitLabel.IconPadding"))));
            this.maxUnitLabel.Name = "maxUnitLabel";
            // 
            // nteMaxUnitLabel
            // 
            resources.ApplyResources(this.nteMaxUnitLabel, "nteMaxUnitLabel");
            this.ThresholdValuesErrorProvider.SetError(this.nteMaxUnitLabel, resources.GetString("nteMaxUnitLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMaxUnitLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMaxUnitLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMaxUnitLabel, ((int)(resources.GetObject("nteMaxUnitLabel.IconPadding"))));
            this.nteMaxUnitLabel.Name = "nteMaxUnitLabel";
            // 
            // nteMinTextBox
            // 
            resources.ApplyResources(this.nteMinTextBox, "nteMinTextBox");
            this.ThresholdValuesErrorProvider.SetError(this.nteMinTextBox, resources.GetString("nteMinTextBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMinTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMinTextBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMinTextBox, ((int)(resources.GetObject("nteMinTextBox.IconPadding"))));
            this.nteMinTextBox.Name = "nteMinTextBox";
            this.nteMinTextBox.OltAcceptsReturn = true;
            this.nteMinTextBox.OltTrimWhitespace = true;
            // 
            // minTextBox
            // 
            resources.ApplyResources(this.minTextBox, "minTextBox");
            this.ThresholdValuesErrorProvider.SetError(this.minTextBox, resources.GetString("minTextBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.minTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minTextBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.minTextBox, ((int)(resources.GetObject("minTextBox.IconPadding"))));
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.OltAcceptsReturn = true;
            this.minTextBox.OltTrimWhitespace = true;
            // 
            // maxTextBox
            // 
            resources.ApplyResources(this.maxTextBox, "maxTextBox");
            this.ThresholdValuesErrorProvider.SetError(this.maxTextBox, resources.GetString("maxTextBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.maxTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxTextBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.maxTextBox, ((int)(resources.GetObject("maxTextBox.IconPadding"))));
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.OltAcceptsReturn = true;
            this.maxTextBox.OltTrimWhitespace = true;
            // 
            // nteMaxTextBox
            // 
            resources.ApplyResources(this.nteMaxTextBox, "nteMaxTextBox");
            this.ThresholdValuesErrorProvider.SetError(this.nteMaxTextBox, resources.GetString("nteMaxTextBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMaxTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMaxTextBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMaxTextBox, ((int)(resources.GetObject("nteMaxTextBox.IconPadding"))));
            this.nteMaxTextBox.Name = "nteMaxTextBox";
            this.nteMaxTextBox.OltAcceptsReturn = true;
            this.nteMaxTextBox.OltTrimWhitespace = true;
            // 
            // nteMinLabel
            // 
            resources.ApplyResources(this.nteMinLabel, "nteMinLabel");
            this.ThresholdValuesErrorProvider.SetError(this.nteMinLabel, resources.GetString("nteMinLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMinLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMinLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMinLabel, ((int)(resources.GetObject("nteMinLabel.IconPadding"))));
            this.nteMinLabel.Name = "nteMinLabel";
            // 
            // minLabel
            // 
            resources.ApplyResources(this.minLabel, "minLabel");
            this.ThresholdValuesErrorProvider.SetError(this.minLabel, resources.GetString("minLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.minLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.minLabel, ((int)(resources.GetObject("minLabel.IconPadding"))));
            this.minLabel.Name = "minLabel";
            // 
            // maxLabel
            // 
            resources.ApplyResources(this.maxLabel, "maxLabel");
            this.ThresholdValuesErrorProvider.SetError(this.maxLabel, resources.GetString("maxLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.maxLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.maxLabel, ((int)(resources.GetObject("maxLabel.IconPadding"))));
            this.maxLabel.Name = "maxLabel";
            // 
            // nteMaxLabel
            // 
            resources.ApplyResources(this.nteMaxLabel, "nteMaxLabel");
            this.ThresholdValuesErrorProvider.SetError(this.nteMaxLabel, resources.GetString("nteMaxLabel.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMaxLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMaxLabel.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMaxLabel, ((int)(resources.GetObject("nteMaxLabel.IconPadding"))));
            this.nteMaxLabel.Name = "nteMaxLabel";
            // 
            // nteMaxCheckBox
            // 
            resources.ApplyResources(this.nteMaxCheckBox, "nteMaxCheckBox");
            this.ThresholdValuesErrorProvider.SetError(this.nteMaxCheckBox, resources.GetString("nteMaxCheckBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMaxCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMaxCheckBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMaxCheckBox, ((int)(resources.GetObject("nteMaxCheckBox.IconPadding"))));
            this.nteMaxCheckBox.Name = "nteMaxCheckBox";
            this.nteMaxCheckBox.UseVisualStyleBackColor = true;
            this.nteMaxCheckBox.Value = null;
            this.nteMaxCheckBox.CheckedChanged += new System.EventHandler(this.nteMaxCheckBox_CheckedChanged);
            // 
            // maxCheckBox
            // 
            resources.ApplyResources(this.maxCheckBox, "maxCheckBox");
            this.ThresholdValuesErrorProvider.SetError(this.maxCheckBox, resources.GetString("maxCheckBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.maxCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxCheckBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.maxCheckBox, ((int)(resources.GetObject("maxCheckBox.IconPadding"))));
            this.maxCheckBox.Name = "maxCheckBox";
            this.maxCheckBox.UseVisualStyleBackColor = true;
            this.maxCheckBox.Value = null;
            this.maxCheckBox.CheckedChanged += new System.EventHandler(this.maxCheckBox_CheckedChanged);
            // 
            // nteMinCheckBox
            // 
            resources.ApplyResources(this.nteMinCheckBox, "nteMinCheckBox");
            this.ThresholdValuesErrorProvider.SetError(this.nteMinCheckBox, resources.GetString("nteMinCheckBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.nteMinCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nteMinCheckBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.nteMinCheckBox, ((int)(resources.GetObject("nteMinCheckBox.IconPadding"))));
            this.nteMinCheckBox.Name = "nteMinCheckBox";
            this.nteMinCheckBox.UseVisualStyleBackColor = true;
            this.nteMinCheckBox.Value = null;
            this.nteMinCheckBox.CheckedChanged += new System.EventHandler(this.nteMinCheckBox_CheckedChanged);
            // 
            // minCheckBox
            // 
            resources.ApplyResources(this.minCheckBox, "minCheckBox");
            this.ThresholdValuesErrorProvider.SetError(this.minCheckBox, resources.GetString("minCheckBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.minCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minCheckBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.minCheckBox, ((int)(resources.GetObject("minCheckBox.IconPadding"))));
            this.minCheckBox.Name = "minCheckBox";
            this.minCheckBox.UseVisualStyleBackColor = true;
            this.minCheckBox.Value = null;
            this.minCheckBox.CheckedChanged += new System.EventHandler(this.minCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.ThresholdValuesErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.ThresholdValuesErrorProvider.SetError(this.saveButton, resources.GetString("saveButton.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.saveButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("saveButton.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.saveButton, ((int)(resources.GetObject("saveButton.IconPadding"))));
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ThresholdValuesErrorProvider
            // 
            this.ThresholdValuesErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.ThresholdValuesErrorProvider, "ThresholdValuesErrorProvider");
            // 
            // targetDefintionGroupBox
            // 
            resources.ApplyResources(this.targetDefintionGroupBox, "targetDefintionGroupBox");
            this.targetDefintionGroupBox.Controls.Add(this.targetDefinitionLabel);
            this.targetDefintionGroupBox.Controls.Add(this.targetDefinitionTextBox);
            this.ThresholdValuesErrorProvider.SetError(this.targetDefintionGroupBox, resources.GetString("targetDefintionGroupBox.Error"));
            this.ThresholdValuesErrorProvider.SetIconAlignment(this.targetDefintionGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefintionGroupBox.IconAlignment"))));
            this.ThresholdValuesErrorProvider.SetIconPadding(this.targetDefintionGroupBox, ((int)(resources.GetObject("targetDefintionGroupBox.IconPadding"))));
            this.targetDefintionGroupBox.Name = "targetDefintionGroupBox";
            this.targetDefintionGroupBox.TabStop = false;
            // 
            // ConfigurePreApprovedTargetRangesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.targetDefintionGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.thresholdsGroupBox);
            this.Controls.Add(this.descriptionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConfigurePreApprovedTargetRangesForm";
            this.Load += new System.EventHandler(this.ConfigurePreApprovedTargetRangesForm_Load);
            this.thresholdsGroupBox.ResumeLayout(false);
            this.thresholdsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValuesErrorProvider)).EndInit();
            this.targetDefintionGroupBox.ResumeLayout(false);
            this.targetDefintionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabel targetDefinitionLabel;
        private OltLabel descriptionLabel;
        private OltTextBox targetDefinitionTextBox;
        private OltGroupBox thresholdsGroupBox;
        private OltCheckBox maxCheckBox;
        private OltCheckBox minCheckBox;
        private OltCheckBox nteMinCheckBox;
        private OltCheckBox nteMaxCheckBox;
        private OltTextBox nteMinTextBox;
        private OltTextBox minTextBox;
        private OltTextBox maxTextBox;
        private OltTextBox nteMaxTextBox;
        private OltLabel nteMinLabel;
        private OltLabel minLabel;
        private OltLabel maxLabel;
        private OltLabel nteMaxLabel;
        private OltLabel nteMinUnitLabel;
        private OltLabel minUnitLabel;
        private OltLabel maxUnitLabel;
        private OltLabel nteMaxUnitLabel;
        private OltButton cancelButton;
        private OltButton saveButton;
        private ErrorProvider ThresholdValuesErrorProvider;
        private System.Windows.Forms.GroupBox targetDefintionGroupBox;
    }
}
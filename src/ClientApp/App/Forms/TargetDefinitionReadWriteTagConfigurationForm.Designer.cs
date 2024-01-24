using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class TargetDefinitionReadWriteTagConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetDefinitionReadWriteTagConfigurationForm));
            this.targetDefinitionNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.targetDefinitionNameTextbox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.clearButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.acceptButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.directionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.maxThresholdGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.maxThresholdComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.maxThresholdTagSearchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.maxThresholdTagNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.maxThresholdDirectionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minThresholdGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.minThresholdComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.minThresholdTagSearchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.minThresholdTagNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.targetThresholdGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.gapUnitValueComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.gapUnitValueTagNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.gapUnitValueTagSearchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.targetThresholdComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.targetThresholdTagSearchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.targetThresholdTagNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.gapUnitValueGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltPanel3 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.tagErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.oltPanel1.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directionErrorProvider)).BeginInit();
            this.maxThresholdGroupBox.SuspendLayout();
            this.minThresholdGroupBox.SuspendLayout();
            this.targetThresholdGroupBox.SuspendLayout();
            this.gapUnitValueGroupBox.SuspendLayout();
            this.oltPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // targetDefinitionNameLabel
            // 
            resources.ApplyResources(this.targetDefinitionNameLabel, "targetDefinitionNameLabel");
            this.directionErrorProvider.SetError(this.targetDefinitionNameLabel, resources.GetString("targetDefinitionNameLabel.Error"));
            this.tagErrorProvider.SetError(this.targetDefinitionNameLabel, resources.GetString("targetDefinitionNameLabel.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.targetDefinitionNameLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefinitionNameLabel.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.targetDefinitionNameLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefinitionNameLabel.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.targetDefinitionNameLabel, ((int)(resources.GetObject("targetDefinitionNameLabel.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.targetDefinitionNameLabel, ((int)(resources.GetObject("targetDefinitionNameLabel.IconPadding1"))));
            this.targetDefinitionNameLabel.Name = "targetDefinitionNameLabel";
            // 
            // oltPanel1
            // 
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Controls.Add(this.targetDefinitionNameTextbox);
            this.oltPanel1.Controls.Add(this.targetDefinitionNameLabel);
            this.tagErrorProvider.SetError(this.oltPanel1, resources.GetString("oltPanel1.Error"));
            this.directionErrorProvider.SetError(this.oltPanel1, resources.GetString("oltPanel1.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.oltPanel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel1.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.oltPanel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel1.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.oltPanel1, ((int)(resources.GetObject("oltPanel1.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.oltPanel1, ((int)(resources.GetObject("oltPanel1.IconPadding1"))));
            this.oltPanel1.Name = "oltPanel1";
            // 
            // targetDefinitionNameTextbox
            // 
            resources.ApplyResources(this.targetDefinitionNameTextbox, "targetDefinitionNameTextbox");
            this.directionErrorProvider.SetError(this.targetDefinitionNameTextbox, resources.GetString("targetDefinitionNameTextbox.Error"));
            this.tagErrorProvider.SetError(this.targetDefinitionNameTextbox, resources.GetString("targetDefinitionNameTextbox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.targetDefinitionNameTextbox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefinitionNameTextbox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.targetDefinitionNameTextbox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetDefinitionNameTextbox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.targetDefinitionNameTextbox, ((int)(resources.GetObject("targetDefinitionNameTextbox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.targetDefinitionNameTextbox, ((int)(resources.GetObject("targetDefinitionNameTextbox.IconPadding1"))));
            this.targetDefinitionNameTextbox.Name = "targetDefinitionNameTextbox";
            this.targetDefinitionNameTextbox.OltAcceptsReturn = true;
            this.targetDefinitionNameTextbox.OltTrimWhitespace = true;
            // 
            // oltPanel2
            // 
            resources.ApplyResources(this.oltPanel2, "oltPanel2");
            this.oltPanel2.Controls.Add(this.cancelButton);
            this.oltPanel2.Controls.Add(this.clearButton);
            this.oltPanel2.Controls.Add(this.acceptButton);
            this.tagErrorProvider.SetError(this.oltPanel2, resources.GetString("oltPanel2.Error"));
            this.directionErrorProvider.SetError(this.oltPanel2, resources.GetString("oltPanel2.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.oltPanel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel2.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.oltPanel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel2.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.oltPanel2, ((int)(resources.GetObject("oltPanel2.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.oltPanel2, ((int)(resources.GetObject("oltPanel2.IconPadding1"))));
            this.oltPanel2.Name = "oltPanel2";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.directionErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.tagErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding1"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.directionErrorProvider.SetError(this.clearButton, resources.GetString("clearButton.Error"));
            this.tagErrorProvider.SetError(this.clearButton, resources.GetString("clearButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.clearButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("clearButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.clearButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("clearButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.clearButton, ((int)(resources.GetObject("clearButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.clearButton, ((int)(resources.GetObject("clearButton.IconPadding1"))));
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            resources.ApplyResources(this.acceptButton, "acceptButton");
            this.directionErrorProvider.SetError(this.acceptButton, resources.GetString("acceptButton.Error"));
            this.tagErrorProvider.SetError(this.acceptButton, resources.GetString("acceptButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.acceptButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("acceptButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.acceptButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("acceptButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.acceptButton, ((int)(resources.GetObject("acceptButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.acceptButton, ((int)(resources.GetObject("acceptButton.IconPadding1"))));
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // directionErrorProvider
            // 
            this.directionErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.directionErrorProvider, "directionErrorProvider");
            // 
            // maxThresholdGroupBox
            // 
            resources.ApplyResources(this.maxThresholdGroupBox, "maxThresholdGroupBox");
            this.maxThresholdGroupBox.Controls.Add(this.maxThresholdComboBox);
            this.maxThresholdGroupBox.Controls.Add(this.maxThresholdTagSearchButton);
            this.maxThresholdGroupBox.Controls.Add(this.maxThresholdTagNameTextBox);
            this.maxThresholdGroupBox.Controls.Add(this.maxThresholdDirectionLabel);
            this.tagErrorProvider.SetError(this.maxThresholdGroupBox, resources.GetString("maxThresholdGroupBox.Error"));
            this.directionErrorProvider.SetError(this.maxThresholdGroupBox, resources.GetString("maxThresholdGroupBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.maxThresholdGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdGroupBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.maxThresholdGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdGroupBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.maxThresholdGroupBox, ((int)(resources.GetObject("maxThresholdGroupBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.maxThresholdGroupBox, ((int)(resources.GetObject("maxThresholdGroupBox.IconPadding1"))));
            this.maxThresholdGroupBox.Name = "maxThresholdGroupBox";
            this.maxThresholdGroupBox.TabStop = false;
            // 
            // maxThresholdComboBox
            // 
            resources.ApplyResources(this.maxThresholdComboBox, "maxThresholdComboBox");
            this.maxThresholdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagErrorProvider.SetError(this.maxThresholdComboBox, resources.GetString("maxThresholdComboBox.Error"));
            this.directionErrorProvider.SetError(this.maxThresholdComboBox, resources.GetString("maxThresholdComboBox.Error1"));
            this.maxThresholdComboBox.FormattingEnabled = true;
            this.directionErrorProvider.SetIconAlignment(this.maxThresholdComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdComboBox.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.maxThresholdComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdComboBox.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.maxThresholdComboBox, ((int)(resources.GetObject("maxThresholdComboBox.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.maxThresholdComboBox, ((int)(resources.GetObject("maxThresholdComboBox.IconPadding1"))));
            this.maxThresholdComboBox.Name = "maxThresholdComboBox";
            // 
            // maxThresholdTagSearchButton
            // 
            resources.ApplyResources(this.maxThresholdTagSearchButton, "maxThresholdTagSearchButton");
            this.directionErrorProvider.SetError(this.maxThresholdTagSearchButton, resources.GetString("maxThresholdTagSearchButton.Error"));
            this.tagErrorProvider.SetError(this.maxThresholdTagSearchButton, resources.GetString("maxThresholdTagSearchButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.maxThresholdTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdTagSearchButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.maxThresholdTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdTagSearchButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.maxThresholdTagSearchButton, ((int)(resources.GetObject("maxThresholdTagSearchButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.maxThresholdTagSearchButton, ((int)(resources.GetObject("maxThresholdTagSearchButton.IconPadding1"))));
            this.maxThresholdTagSearchButton.Name = "maxThresholdTagSearchButton";
            this.maxThresholdTagSearchButton.UseVisualStyleBackColor = true;
            // 
            // maxThresholdTagNameTextBox
            // 
            resources.ApplyResources(this.maxThresholdTagNameTextBox, "maxThresholdTagNameTextBox");
            this.maxThresholdTagNameTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.directionErrorProvider.SetError(this.maxThresholdTagNameTextBox, resources.GetString("maxThresholdTagNameTextBox.Error"));
            this.tagErrorProvider.SetError(this.maxThresholdTagNameTextBox, resources.GetString("maxThresholdTagNameTextBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.maxThresholdTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdTagNameTextBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.maxThresholdTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdTagNameTextBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.maxThresholdTagNameTextBox, ((int)(resources.GetObject("maxThresholdTagNameTextBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.maxThresholdTagNameTextBox, ((int)(resources.GetObject("maxThresholdTagNameTextBox.IconPadding1"))));
            this.maxThresholdTagNameTextBox.Name = "maxThresholdTagNameTextBox";
            this.maxThresholdTagNameTextBox.OltAcceptsReturn = true;
            this.maxThresholdTagNameTextBox.OltTrimWhitespace = true;
            // 
            // maxThresholdDirectionLabel
            // 
            resources.ApplyResources(this.maxThresholdDirectionLabel, "maxThresholdDirectionLabel");
            this.directionErrorProvider.SetError(this.maxThresholdDirectionLabel, resources.GetString("maxThresholdDirectionLabel.Error"));
            this.tagErrorProvider.SetError(this.maxThresholdDirectionLabel, resources.GetString("maxThresholdDirectionLabel.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.maxThresholdDirectionLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdDirectionLabel.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.maxThresholdDirectionLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("maxThresholdDirectionLabel.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.maxThresholdDirectionLabel, ((int)(resources.GetObject("maxThresholdDirectionLabel.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.maxThresholdDirectionLabel, ((int)(resources.GetObject("maxThresholdDirectionLabel.IconPadding1"))));
            this.maxThresholdDirectionLabel.Name = "maxThresholdDirectionLabel";
            // 
            // minThresholdGroupBox
            // 
            resources.ApplyResources(this.minThresholdGroupBox, "minThresholdGroupBox");
            this.minThresholdGroupBox.Controls.Add(this.minThresholdComboBox);
            this.minThresholdGroupBox.Controls.Add(this.minThresholdTagSearchButton);
            this.minThresholdGroupBox.Controls.Add(this.minThresholdTagNameTextBox);
            this.minThresholdGroupBox.Controls.Add(this.oltLabel1);
            this.tagErrorProvider.SetError(this.minThresholdGroupBox, resources.GetString("minThresholdGroupBox.Error"));
            this.directionErrorProvider.SetError(this.minThresholdGroupBox, resources.GetString("minThresholdGroupBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.minThresholdGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdGroupBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.minThresholdGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdGroupBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.minThresholdGroupBox, ((int)(resources.GetObject("minThresholdGroupBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.minThresholdGroupBox, ((int)(resources.GetObject("minThresholdGroupBox.IconPadding1"))));
            this.minThresholdGroupBox.Name = "minThresholdGroupBox";
            this.minThresholdGroupBox.TabStop = false;
            // 
            // minThresholdComboBox
            // 
            resources.ApplyResources(this.minThresholdComboBox, "minThresholdComboBox");
            this.minThresholdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagErrorProvider.SetError(this.minThresholdComboBox, resources.GetString("minThresholdComboBox.Error"));
            this.directionErrorProvider.SetError(this.minThresholdComboBox, resources.GetString("minThresholdComboBox.Error1"));
            this.minThresholdComboBox.FormattingEnabled = true;
            this.directionErrorProvider.SetIconAlignment(this.minThresholdComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdComboBox.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.minThresholdComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdComboBox.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.minThresholdComboBox, ((int)(resources.GetObject("minThresholdComboBox.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.minThresholdComboBox, ((int)(resources.GetObject("minThresholdComboBox.IconPadding1"))));
            this.minThresholdComboBox.Name = "minThresholdComboBox";
            // 
            // minThresholdTagSearchButton
            // 
            resources.ApplyResources(this.minThresholdTagSearchButton, "minThresholdTagSearchButton");
            this.directionErrorProvider.SetError(this.minThresholdTagSearchButton, resources.GetString("minThresholdTagSearchButton.Error"));
            this.tagErrorProvider.SetError(this.minThresholdTagSearchButton, resources.GetString("minThresholdTagSearchButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.minThresholdTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdTagSearchButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.minThresholdTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdTagSearchButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.minThresholdTagSearchButton, ((int)(resources.GetObject("minThresholdTagSearchButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.minThresholdTagSearchButton, ((int)(resources.GetObject("minThresholdTagSearchButton.IconPadding1"))));
            this.minThresholdTagSearchButton.Name = "minThresholdTagSearchButton";
            this.minThresholdTagSearchButton.UseVisualStyleBackColor = true;
            // 
            // minThresholdTagNameTextBox
            // 
            resources.ApplyResources(this.minThresholdTagNameTextBox, "minThresholdTagNameTextBox");
            this.directionErrorProvider.SetError(this.minThresholdTagNameTextBox, resources.GetString("minThresholdTagNameTextBox.Error"));
            this.tagErrorProvider.SetError(this.minThresholdTagNameTextBox, resources.GetString("minThresholdTagNameTextBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.minThresholdTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdTagNameTextBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.minThresholdTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("minThresholdTagNameTextBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.minThresholdTagNameTextBox, ((int)(resources.GetObject("minThresholdTagNameTextBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.minThresholdTagNameTextBox, ((int)(resources.GetObject("minThresholdTagNameTextBox.IconPadding1"))));
            this.minThresholdTagNameTextBox.Name = "minThresholdTagNameTextBox";
            this.minThresholdTagNameTextBox.OltAcceptsReturn = true;
            this.minThresholdTagNameTextBox.OltTrimWhitespace = true;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.directionErrorProvider.SetError(this.oltLabel1, resources.GetString("oltLabel1.Error"));
            this.tagErrorProvider.SetError(this.oltLabel1, resources.GetString("oltLabel1.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.oltLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel1.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.oltLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel1.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.oltLabel1, ((int)(resources.GetObject("oltLabel1.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.oltLabel1, ((int)(resources.GetObject("oltLabel1.IconPadding1"))));
            this.oltLabel1.Name = "oltLabel1";
            // 
            // targetThresholdGroupBox
            // 
            resources.ApplyResources(this.targetThresholdGroupBox, "targetThresholdGroupBox");
            this.targetThresholdGroupBox.Controls.Add(this.gapUnitValueComboBox);
            this.targetThresholdGroupBox.Controls.Add(this.gapUnitValueTagNameTextBox);
            this.targetThresholdGroupBox.Controls.Add(this.gapUnitValueTagSearchButton);
            this.targetThresholdGroupBox.Controls.Add(this.oltLabel3);
            this.tagErrorProvider.SetError(this.targetThresholdGroupBox, resources.GetString("targetThresholdGroupBox.Error"));
            this.directionErrorProvider.SetError(this.targetThresholdGroupBox, resources.GetString("targetThresholdGroupBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.targetThresholdGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdGroupBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.targetThresholdGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdGroupBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.targetThresholdGroupBox, ((int)(resources.GetObject("targetThresholdGroupBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.targetThresholdGroupBox, ((int)(resources.GetObject("targetThresholdGroupBox.IconPadding1"))));
            this.targetThresholdGroupBox.Name = "targetThresholdGroupBox";
            this.targetThresholdGroupBox.TabStop = false;
            // 
            // gapUnitValueComboBox
            // 
            resources.ApplyResources(this.gapUnitValueComboBox, "gapUnitValueComboBox");
            this.gapUnitValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagErrorProvider.SetError(this.gapUnitValueComboBox, resources.GetString("gapUnitValueComboBox.Error"));
            this.directionErrorProvider.SetError(this.gapUnitValueComboBox, resources.GetString("gapUnitValueComboBox.Error1"));
            this.gapUnitValueComboBox.FormattingEnabled = true;
            this.directionErrorProvider.SetIconAlignment(this.gapUnitValueComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueComboBox.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.gapUnitValueComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueComboBox.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.gapUnitValueComboBox, ((int)(resources.GetObject("gapUnitValueComboBox.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.gapUnitValueComboBox, ((int)(resources.GetObject("gapUnitValueComboBox.IconPadding1"))));
            this.gapUnitValueComboBox.Name = "gapUnitValueComboBox";
            // 
            // gapUnitValueTagNameTextBox
            // 
            resources.ApplyResources(this.gapUnitValueTagNameTextBox, "gapUnitValueTagNameTextBox");
            this.directionErrorProvider.SetError(this.gapUnitValueTagNameTextBox, resources.GetString("gapUnitValueTagNameTextBox.Error"));
            this.tagErrorProvider.SetError(this.gapUnitValueTagNameTextBox, resources.GetString("gapUnitValueTagNameTextBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.gapUnitValueTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueTagNameTextBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.gapUnitValueTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueTagNameTextBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.gapUnitValueTagNameTextBox, ((int)(resources.GetObject("gapUnitValueTagNameTextBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.gapUnitValueTagNameTextBox, ((int)(resources.GetObject("gapUnitValueTagNameTextBox.IconPadding1"))));
            this.gapUnitValueTagNameTextBox.Name = "gapUnitValueTagNameTextBox";
            this.gapUnitValueTagNameTextBox.OltAcceptsReturn = true;
            this.gapUnitValueTagNameTextBox.OltTrimWhitespace = true;
            // 
            // gapUnitValueTagSearchButton
            // 
            resources.ApplyResources(this.gapUnitValueTagSearchButton, "gapUnitValueTagSearchButton");
            this.directionErrorProvider.SetError(this.gapUnitValueTagSearchButton, resources.GetString("gapUnitValueTagSearchButton.Error"));
            this.tagErrorProvider.SetError(this.gapUnitValueTagSearchButton, resources.GetString("gapUnitValueTagSearchButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.gapUnitValueTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueTagSearchButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.gapUnitValueTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueTagSearchButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.gapUnitValueTagSearchButton, ((int)(resources.GetObject("gapUnitValueTagSearchButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.gapUnitValueTagSearchButton, ((int)(resources.GetObject("gapUnitValueTagSearchButton.IconPadding1"))));
            this.gapUnitValueTagSearchButton.Name = "gapUnitValueTagSearchButton";
            this.gapUnitValueTagSearchButton.UseVisualStyleBackColor = true;
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.directionErrorProvider.SetError(this.oltLabel3, resources.GetString("oltLabel3.Error"));
            this.tagErrorProvider.SetError(this.oltLabel3, resources.GetString("oltLabel3.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.oltLabel3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel3.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.oltLabel3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel3.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.oltLabel3, ((int)(resources.GetObject("oltLabel3.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.oltLabel3, ((int)(resources.GetObject("oltLabel3.IconPadding1"))));
            this.oltLabel3.Name = "oltLabel3";
            // 
            // targetThresholdComboBox
            // 
            resources.ApplyResources(this.targetThresholdComboBox, "targetThresholdComboBox");
            this.targetThresholdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagErrorProvider.SetError(this.targetThresholdComboBox, resources.GetString("targetThresholdComboBox.Error"));
            this.directionErrorProvider.SetError(this.targetThresholdComboBox, resources.GetString("targetThresholdComboBox.Error1"));
            this.targetThresholdComboBox.FormattingEnabled = true;
            this.directionErrorProvider.SetIconAlignment(this.targetThresholdComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdComboBox.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.targetThresholdComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdComboBox.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.targetThresholdComboBox, ((int)(resources.GetObject("targetThresholdComboBox.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.targetThresholdComboBox, ((int)(resources.GetObject("targetThresholdComboBox.IconPadding1"))));
            this.targetThresholdComboBox.Name = "targetThresholdComboBox";
            // 
            // targetThresholdTagSearchButton
            // 
            resources.ApplyResources(this.targetThresholdTagSearchButton, "targetThresholdTagSearchButton");
            this.directionErrorProvider.SetError(this.targetThresholdTagSearchButton, resources.GetString("targetThresholdTagSearchButton.Error"));
            this.tagErrorProvider.SetError(this.targetThresholdTagSearchButton, resources.GetString("targetThresholdTagSearchButton.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.targetThresholdTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdTagSearchButton.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.targetThresholdTagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdTagSearchButton.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.targetThresholdTagSearchButton, ((int)(resources.GetObject("targetThresholdTagSearchButton.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.targetThresholdTagSearchButton, ((int)(resources.GetObject("targetThresholdTagSearchButton.IconPadding1"))));
            this.targetThresholdTagSearchButton.Name = "targetThresholdTagSearchButton";
            this.targetThresholdTagSearchButton.UseVisualStyleBackColor = true;
            // 
            // targetThresholdTagNameTextBox
            // 
            resources.ApplyResources(this.targetThresholdTagNameTextBox, "targetThresholdTagNameTextBox");
            this.directionErrorProvider.SetError(this.targetThresholdTagNameTextBox, resources.GetString("targetThresholdTagNameTextBox.Error"));
            this.tagErrorProvider.SetError(this.targetThresholdTagNameTextBox, resources.GetString("targetThresholdTagNameTextBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.targetThresholdTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdTagNameTextBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.targetThresholdTagNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("targetThresholdTagNameTextBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.targetThresholdTagNameTextBox, ((int)(resources.GetObject("targetThresholdTagNameTextBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.targetThresholdTagNameTextBox, ((int)(resources.GetObject("targetThresholdTagNameTextBox.IconPadding1"))));
            this.targetThresholdTagNameTextBox.Name = "targetThresholdTagNameTextBox";
            this.targetThresholdTagNameTextBox.OltAcceptsReturn = true;
            this.targetThresholdTagNameTextBox.OltTrimWhitespace = true;
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.directionErrorProvider.SetError(this.oltLabel2, resources.GetString("oltLabel2.Error"));
            this.tagErrorProvider.SetError(this.oltLabel2, resources.GetString("oltLabel2.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.oltLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel2.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.oltLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel2.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.oltLabel2, ((int)(resources.GetObject("oltLabel2.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.oltLabel2, ((int)(resources.GetObject("oltLabel2.IconPadding1"))));
            this.oltLabel2.Name = "oltLabel2";
            // 
            // gapUnitValueGroupBox
            // 
            resources.ApplyResources(this.gapUnitValueGroupBox, "gapUnitValueGroupBox");
            this.gapUnitValueGroupBox.Controls.Add(this.targetThresholdComboBox);
            this.gapUnitValueGroupBox.Controls.Add(this.targetThresholdTagSearchButton);
            this.gapUnitValueGroupBox.Controls.Add(this.oltLabel2);
            this.gapUnitValueGroupBox.Controls.Add(this.targetThresholdTagNameTextBox);
            this.tagErrorProvider.SetError(this.gapUnitValueGroupBox, resources.GetString("gapUnitValueGroupBox.Error"));
            this.directionErrorProvider.SetError(this.gapUnitValueGroupBox, resources.GetString("gapUnitValueGroupBox.Error1"));
            this.tagErrorProvider.SetIconAlignment(this.gapUnitValueGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueGroupBox.IconAlignment"))));
            this.directionErrorProvider.SetIconAlignment(this.gapUnitValueGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gapUnitValueGroupBox.IconAlignment1"))));
            this.directionErrorProvider.SetIconPadding(this.gapUnitValueGroupBox, ((int)(resources.GetObject("gapUnitValueGroupBox.IconPadding"))));
            this.tagErrorProvider.SetIconPadding(this.gapUnitValueGroupBox, ((int)(resources.GetObject("gapUnitValueGroupBox.IconPadding1"))));
            this.gapUnitValueGroupBox.Name = "gapUnitValueGroupBox";
            this.gapUnitValueGroupBox.TabStop = false;
            // 
            // oltPanel3
            // 
            resources.ApplyResources(this.oltPanel3, "oltPanel3");
            this.oltPanel3.Controls.Add(this.gapUnitValueGroupBox);
            this.oltPanel3.Controls.Add(this.targetThresholdGroupBox);
            this.oltPanel3.Controls.Add(this.minThresholdGroupBox);
            this.oltPanel3.Controls.Add(this.maxThresholdGroupBox);
            this.tagErrorProvider.SetError(this.oltPanel3, resources.GetString("oltPanel3.Error"));
            this.directionErrorProvider.SetError(this.oltPanel3, resources.GetString("oltPanel3.Error1"));
            this.directionErrorProvider.SetIconAlignment(this.oltPanel3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel3.IconAlignment"))));
            this.tagErrorProvider.SetIconAlignment(this.oltPanel3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel3.IconAlignment1"))));
            this.tagErrorProvider.SetIconPadding(this.oltPanel3, ((int)(resources.GetObject("oltPanel3.IconPadding"))));
            this.directionErrorProvider.SetIconPadding(this.oltPanel3, ((int)(resources.GetObject("oltPanel3.IconPadding1"))));
            this.oltPanel3.Name = "oltPanel3";
            // 
            // tagErrorProvider
            // 
            this.tagErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.tagErrorProvider, "tagErrorProvider");
            // 
            // TargetDefinitionReadWriteTagConfigurationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltPanel3);
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.MaximizeBox = false;
            this.Name = "TargetDefinitionReadWriteTagConfigurationForm";
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.oltPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.directionErrorProvider)).EndInit();
            this.maxThresholdGroupBox.ResumeLayout(false);
            this.maxThresholdGroupBox.PerformLayout();
            this.minThresholdGroupBox.ResumeLayout(false);
            this.minThresholdGroupBox.PerformLayout();
            this.targetThresholdGroupBox.ResumeLayout(false);
            this.targetThresholdGroupBox.PerformLayout();
            this.gapUnitValueGroupBox.ResumeLayout(false);
            this.gapUnitValueGroupBox.PerformLayout();
            this.oltPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabel targetDefinitionNameLabel;
        private OltPanel oltPanel1;
        private OltTextBox targetDefinitionNameTextbox;
        private OltPanel oltPanel2;
        private OltButton cancelButton;
        private OltButton clearButton;
        private OltButton acceptButton;
        private ErrorProvider directionErrorProvider;
        private ErrorProvider tagErrorProvider;
        private OltPanel oltPanel3;
        private OltGroupBox gapUnitValueGroupBox;
        private OltComboBox gapUnitValueComboBox;
        private OltButton gapUnitValueTagSearchButton;
        private OltTextBox gapUnitValueTagNameTextBox;
        private OltLabel oltLabel3;
        private OltGroupBox targetThresholdGroupBox;
        private OltComboBox targetThresholdComboBox;
        private OltButton targetThresholdTagSearchButton;
        private OltTextBox targetThresholdTagNameTextBox;
        private OltLabel oltLabel2;
        private OltGroupBox minThresholdGroupBox;
        private OltComboBox minThresholdComboBox;
        private OltButton minThresholdTagSearchButton;
        private OltTextBox minThresholdTagNameTextBox;
        private OltLabel oltLabel1;
        private OltGroupBox maxThresholdGroupBox;
        private OltComboBox maxThresholdComboBox;
        private OltButton maxThresholdTagSearchButton;
        private OltTextBox maxThresholdTagNameTextBox;
        private OltLabel maxThresholdDirectionLabel;
    }
}
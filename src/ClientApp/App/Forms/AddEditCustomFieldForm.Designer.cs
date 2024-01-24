using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditCustomFieldForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditCustomFieldForm));
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.nameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tagGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.rangeCheckBox = new System.Windows.Forms.CheckBox();
            this.rangeGroupBox = new System.Windows.Forms.GroupBox();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.maxvalueTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.minvalueTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.lessthanTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.greaterthanTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.RangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.LessThanRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.GreaterThanRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.tagDeletedLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagRemoveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tagValueLabel = new System.Windows.Forms.Label();
            this.tagRefreshButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tagValueTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.tagInfoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.tagSearchButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.fieldTypeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.customFieldTypeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.dropDownListGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.dropDownValueListBox = new Com.Suncor.Olt.Client.OltControls.OltListBox();
            this.deleteDropDownValueButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editDropDownValueButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addDropDownValueButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.phdLinkTypePanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.phdLinkTypeWriteRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.phdLinkTypeReadRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.phdLinkTypeOffRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tagGroupBox.SuspendLayout();
            this.rangeGroupBox.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.dropDownListGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.phdLinkTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.errorProvider.SetIconAlignment(this.nameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nameTextBox.IconAlignment"))));
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = false;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.errorProvider.SetIconAlignment(this.nameLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nameLabel.IconAlignment"))));
            this.nameLabel.Name = "nameLabel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.errorProvider.SetIconAlignment(this.okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("okButton.IconAlignment"))));
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // tagGroupBox
            // 
            resources.ApplyResources(this.tagGroupBox, "tagGroupBox");
            this.tagGroupBox.Controls.Add(this.rangeCheckBox);
            this.tagGroupBox.Controls.Add(this.rangeGroupBox);
            this.tagGroupBox.Controls.Add(this.tagDeletedLabel);
            this.tagGroupBox.Controls.Add(this.tagRemoveButton);
            this.tagGroupBox.Controls.Add(this.tagValueLabel);
            this.tagGroupBox.Controls.Add(this.tagRefreshButton);
            this.tagGroupBox.Controls.Add(this.tagValueTextBox);
            this.tagGroupBox.Controls.Add(this.tagInfoTextBox);
            this.tagGroupBox.Controls.Add(this.tagSearchButton);
            this.errorProvider.SetIconAlignment(this.tagGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagGroupBox.IconAlignment"))));
            this.tagGroupBox.Name = "tagGroupBox";
            this.tagGroupBox.TabStop = false;
            // 
            // rangeCheckBox
            // 
            resources.ApplyResources(this.rangeCheckBox, "rangeCheckBox");
            this.rangeCheckBox.Name = "rangeCheckBox";
            this.rangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // rangeGroupBox
            // 
            this.rangeGroupBox.Controls.Add(this.oltPanel1);
            resources.ApplyResources(this.rangeGroupBox, "rangeGroupBox");
            this.rangeGroupBox.Name = "rangeGroupBox";
            this.rangeGroupBox.TabStop = false;
            // 
            // oltPanel1
            // 
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Controls.Add(this.oltLabel2);
            this.oltPanel1.Controls.Add(this.maxvalueTextBox);
            this.oltPanel1.Controls.Add(this.minvalueTextBox);
            this.oltPanel1.Controls.Add(this.lessthanTextBox);
            this.oltPanel1.Controls.Add(this.greaterthanTextBox);
            this.oltPanel1.Controls.Add(this.RangeRadioButton);
            this.oltPanel1.Controls.Add(this.LessThanRadioButton);
            this.oltPanel1.Controls.Add(this.GreaterThanRadioButton);
            this.errorProvider.SetIconAlignment(this.oltPanel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltPanel1.IconAlignment"))));
            this.oltPanel1.Name = "oltPanel1";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // maxvalueTextBox
            // 
            this.maxvalueTextBox.DecimalValue = null;
            this.maxvalueTextBox.IntegerValue = null;
            resources.ApplyResources(this.maxvalueTextBox, "maxvalueTextBox");
            this.maxvalueTextBox.Name = "maxvalueTextBox";
            this.maxvalueTextBox.NumericValue = null;
            // 
            // minvalueTextBox
            // 
            this.minvalueTextBox.DecimalValue = null;
            this.minvalueTextBox.IntegerValue = null;
            resources.ApplyResources(this.minvalueTextBox, "minvalueTextBox");
            this.minvalueTextBox.Name = "minvalueTextBox";
            this.minvalueTextBox.NumericValue = null;
            // 
            // lessthanTextBox
            // 
            this.lessthanTextBox.DecimalValue = null;
            this.lessthanTextBox.IntegerValue = null;
            resources.ApplyResources(this.lessthanTextBox, "lessthanTextBox");
            this.lessthanTextBox.Name = "lessthanTextBox";
            this.lessthanTextBox.NumericValue = null;
            // 
            // greaterthanTextBox
            // 
            this.greaterthanTextBox.DecimalValue = null;
            this.greaterthanTextBox.IntegerValue = null;
            resources.ApplyResources(this.greaterthanTextBox, "greaterthanTextBox");
            this.greaterthanTextBox.Name = "greaterthanTextBox";
            this.greaterthanTextBox.NumericValue = null;
            // 
            // RangeRadioButton
            // 
            resources.ApplyResources(this.RangeRadioButton, "RangeRadioButton");
            this.errorProvider.SetIconAlignment(this.RangeRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("RangeRadioButton.IconAlignment"))));
            this.RangeRadioButton.Name = "RangeRadioButton";
            this.RangeRadioButton.TabStop = true;
            this.RangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // LessThanRadioButton
            // 
            resources.ApplyResources(this.LessThanRadioButton, "LessThanRadioButton");
            this.errorProvider.SetIconAlignment(this.LessThanRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("LessThanRadioButton.IconAlignment"))));
            this.LessThanRadioButton.Name = "LessThanRadioButton";
            this.LessThanRadioButton.TabStop = true;
            this.LessThanRadioButton.UseVisualStyleBackColor = true;
            // 
            // GreaterThanRadioButton
            // 
            resources.ApplyResources(this.GreaterThanRadioButton, "GreaterThanRadioButton");
            this.errorProvider.SetIconAlignment(this.GreaterThanRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("GreaterThanRadioButton.IconAlignment"))));
            this.GreaterThanRadioButton.Name = "GreaterThanRadioButton";
            this.GreaterThanRadioButton.TabStop = true;
            this.GreaterThanRadioButton.UseVisualStyleBackColor = true;
            // 
            // tagDeletedLabel
            // 
            resources.ApplyResources(this.tagDeletedLabel, "tagDeletedLabel");
            this.tagDeletedLabel.ForeColor = System.Drawing.Color.Red;
            this.errorProvider.SetIconAlignment(this.tagDeletedLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagDeletedLabel.IconAlignment"))));
            this.tagDeletedLabel.Name = "tagDeletedLabel";
            // 
            // tagRemoveButton
            // 
            resources.ApplyResources(this.tagRemoveButton, "tagRemoveButton");
            this.errorProvider.SetIconAlignment(this.tagRemoveButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagRemoveButton.IconAlignment"))));
            this.tagRemoveButton.Name = "tagRemoveButton";
            this.tagRemoveButton.UseVisualStyleBackColor = true;
            // 
            // tagValueLabel
            // 
            resources.ApplyResources(this.tagValueLabel, "tagValueLabel");
            this.errorProvider.SetIconAlignment(this.tagValueLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagValueLabel.IconAlignment"))));
            this.tagValueLabel.Name = "tagValueLabel";
            // 
            // tagRefreshButton
            // 
            resources.ApplyResources(this.tagRefreshButton, "tagRefreshButton");
            this.errorProvider.SetIconAlignment(this.tagRefreshButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagRefreshButton.IconAlignment"))));
            this.tagRefreshButton.Name = "tagRefreshButton";
            this.tagRefreshButton.UseVisualStyleBackColor = true;
            // 
            // tagValueTextBox
            // 
            resources.ApplyResources(this.tagValueTextBox, "tagValueTextBox");
            this.tagValueTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.errorProvider.SetIconAlignment(this.tagValueTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagValueTextBox.IconAlignment"))));
            this.tagValueTextBox.Name = "tagValueTextBox";
            this.tagValueTextBox.OltAcceptsReturn = true;
            this.tagValueTextBox.OltTrimWhitespace = true;
            this.tagValueTextBox.ReadOnly = true;
            // 
            // tagInfoTextBox
            // 
            resources.ApplyResources(this.tagInfoTextBox, "tagInfoTextBox");
            this.errorProvider.SetIconAlignment(this.tagInfoTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagInfoTextBox.IconAlignment"))));
            this.tagInfoTextBox.Name = "tagInfoTextBox";
            this.tagInfoTextBox.OltAcceptsReturn = true;
            this.tagInfoTextBox.OltTrimWhitespace = true;
            this.tagInfoTextBox.ReadOnly = true;
            // 
            // tagSearchButton
            // 
            resources.ApplyResources(this.tagSearchButton, "tagSearchButton");
            this.errorProvider.SetIconAlignment(this.tagSearchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tagSearchButton.IconAlignment"))));
            this.tagSearchButton.Name = "tagSearchButton";
            this.tagSearchButton.UseVisualStyleBackColor = true;
            // 
            // fieldTypeLabel
            // 
            resources.ApplyResources(this.fieldTypeLabel, "fieldTypeLabel");
            this.errorProvider.SetIconAlignment(this.fieldTypeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("fieldTypeLabel.IconAlignment"))));
            this.fieldTypeLabel.Name = "fieldTypeLabel";
            // 
            // customFieldTypeComboBox
            // 
            resources.ApplyResources(this.customFieldTypeComboBox, "customFieldTypeComboBox");
            this.customFieldTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customFieldTypeComboBox.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.customFieldTypeComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("customFieldTypeComboBox.IconAlignment"))));
            this.customFieldTypeComboBox.Name = "customFieldTypeComboBox";
            // 
            // dropDownListGroupBox
            // 
            this.dropDownListGroupBox.Controls.Add(this.dropDownValueListBox);
            this.dropDownListGroupBox.Controls.Add(this.deleteDropDownValueButton);
            this.dropDownListGroupBox.Controls.Add(this.editDropDownValueButton);
            this.dropDownListGroupBox.Controls.Add(this.addDropDownValueButton);
            this.errorProvider.SetIconAlignment(this.dropDownListGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dropDownListGroupBox.IconAlignment"))));
            resources.ApplyResources(this.dropDownListGroupBox, "dropDownListGroupBox");
            this.dropDownListGroupBox.Name = "dropDownListGroupBox";
            this.dropDownListGroupBox.TabStop = false;
            // 
            // dropDownValueListBox
            // 
            this.dropDownValueListBox.BackColor = System.Drawing.SystemColors.Control;
            this.dropDownValueListBox.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.dropDownValueListBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dropDownValueListBox.IconAlignment"))));
            resources.ApplyResources(this.dropDownValueListBox, "dropDownValueListBox");
            this.dropDownValueListBox.Name = "dropDownValueListBox";
            this.dropDownValueListBox.ReadOnly = true;
            // 
            // deleteDropDownValueButton
            // 
            resources.ApplyResources(this.deleteDropDownValueButton, "deleteDropDownValueButton");
            this.errorProvider.SetIconAlignment(this.deleteDropDownValueButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("deleteDropDownValueButton.IconAlignment"))));
            this.deleteDropDownValueButton.Name = "deleteDropDownValueButton";
            this.deleteDropDownValueButton.UseVisualStyleBackColor = true;
            // 
            // editDropDownValueButton
            // 
            resources.ApplyResources(this.editDropDownValueButton, "editDropDownValueButton");
            this.errorProvider.SetIconAlignment(this.editDropDownValueButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("editDropDownValueButton.IconAlignment"))));
            this.editDropDownValueButton.Name = "editDropDownValueButton";
            this.editDropDownValueButton.UseVisualStyleBackColor = true;
            // 
            // addDropDownValueButton
            // 
            resources.ApplyResources(this.addDropDownValueButton, "addDropDownValueButton");
            this.errorProvider.SetIconAlignment(this.addDropDownValueButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("addDropDownValueButton.IconAlignment"))));
            this.addDropDownValueButton.Name = "addDropDownValueButton";
            this.addDropDownValueButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.okButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.errorProvider.SetIconAlignment(this.panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panel1.IconAlignment"))));
            this.panel1.Name = "panel1";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.errorProvider.SetIconAlignment(this.oltLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("oltLabel1.IconAlignment"))));
            this.oltLabel1.Name = "oltLabel1";
            // 
            // phdLinkTypePanel
            // 
            resources.ApplyResources(this.phdLinkTypePanel, "phdLinkTypePanel");
            this.phdLinkTypePanel.Controls.Add(this.phdLinkTypeWriteRadioButton);
            this.phdLinkTypePanel.Controls.Add(this.phdLinkTypeReadRadioButton);
            this.phdLinkTypePanel.Controls.Add(this.phdLinkTypeOffRadioButton);
            this.errorProvider.SetIconAlignment(this.phdLinkTypePanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("phdLinkTypePanel.IconAlignment"))));
            this.phdLinkTypePanel.Name = "phdLinkTypePanel";
            // 
            // phdLinkTypeWriteRadioButton
            // 
            resources.ApplyResources(this.phdLinkTypeWriteRadioButton, "phdLinkTypeWriteRadioButton");
            this.errorProvider.SetIconAlignment(this.phdLinkTypeWriteRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("phdLinkTypeWriteRadioButton.IconAlignment"))));
            this.phdLinkTypeWriteRadioButton.Name = "phdLinkTypeWriteRadioButton";
            this.phdLinkTypeWriteRadioButton.TabStop = true;
            this.phdLinkTypeWriteRadioButton.UseVisualStyleBackColor = true;
            // 
            // phdLinkTypeReadRadioButton
            // 
            resources.ApplyResources(this.phdLinkTypeReadRadioButton, "phdLinkTypeReadRadioButton");
            this.errorProvider.SetIconAlignment(this.phdLinkTypeReadRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("phdLinkTypeReadRadioButton.IconAlignment"))));
            this.phdLinkTypeReadRadioButton.Name = "phdLinkTypeReadRadioButton";
            this.phdLinkTypeReadRadioButton.TabStop = true;
            this.phdLinkTypeReadRadioButton.UseVisualStyleBackColor = true;
            // 
            // phdLinkTypeOffRadioButton
            // 
            resources.ApplyResources(this.phdLinkTypeOffRadioButton, "phdLinkTypeOffRadioButton");
            this.errorProvider.SetIconAlignment(this.phdLinkTypeOffRadioButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("phdLinkTypeOffRadioButton.IconAlignment"))));
            this.phdLinkTypeOffRadioButton.Name = "phdLinkTypeOffRadioButton";
            this.phdLinkTypeOffRadioButton.TabStop = true;
            this.phdLinkTypeOffRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddEditCustomFieldForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.phdLinkTypePanel);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dropDownListGroupBox);
            this.Controls.Add(this.customFieldTypeComboBox);
            this.Controls.Add(this.fieldTypeLabel);
            this.Controls.Add(this.tagGroupBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "AddEditCustomFieldForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tagGroupBox.ResumeLayout(false);
            this.tagGroupBox.PerformLayout();
            this.rangeGroupBox.ResumeLayout(false);
            this.oltPanel1.ResumeLayout(false);
            this.oltPanel1.PerformLayout();
            this.dropDownListGroupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.phdLinkTypePanel.ResumeLayout(false);
            this.phdLinkTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton cancelButton;
        private OltTextBox nameTextBox;
        private OltLabel nameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltButton okButton;
        private OltGroupBox tagGroupBox;
        private OltButton tagRemoveButton;
        private System.Windows.Forms.Label tagValueLabel;
        private OltButton tagRefreshButton;
        private OltTextBox tagValueTextBox;
        private OltTextBox tagInfoTextBox;
        private OltButton tagSearchButton;
        private OltLabel tagDeletedLabel;
        private OltLabel fieldTypeLabel;
        private OltComboBox customFieldTypeComboBox;
        private OltGroupBox dropDownListGroupBox;
        private OltButton deleteDropDownValueButton;
        private OltButton editDropDownValueButton;
        private OltButton addDropDownValueButton;
        private OltListBox dropDownValueListBox;
        private System.Windows.Forms.Panel panel1;
        private OltPanel phdLinkTypePanel;
        private OltRadioButton phdLinkTypeWriteRadioButton;
        private OltRadioButton phdLinkTypeReadRadioButton;
        private OltRadioButton phdLinkTypeOffRadioButton;
        private OltLabel oltLabel1;
        private System.Windows.Forms.CheckBox rangeCheckBox;
        private System.Windows.Forms.GroupBox rangeGroupBox;
        private OltPanel oltPanel1;
        private OltLabel oltLabel2;
        private OltNumericBox maxvalueTextBox;
        private OltNumericBox minvalueTextBox;
        private OltNumericBox lessthanTextBox;
        private OltNumericBox greaterthanTextBox;
        private OltRadioButton RangeRadioButton;
        private OltRadioButton LessThanRadioButton;
        private OltRadioButton GreaterThanRadioButton;
    }
}
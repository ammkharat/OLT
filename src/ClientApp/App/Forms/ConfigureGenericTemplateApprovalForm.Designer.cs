using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureGenericTemplateApprovalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureGenericTemplateApprovalForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contractorInfoGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.ShowNeverendCheckbox = new System.Windows.Forms.CheckBox();
            this.eFormComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.occupationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.clearButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addOrUpdateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.contractorNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.contractorNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.contractorsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.siteNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contractorInfoGroupBox.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.contractorInfoGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.contractorsGroupBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.siteGroupBox, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // contractorInfoGroupBox
            // 
            this.contractorInfoGroupBox.Controls.Add(this.ShowNeverendCheckbox);
            this.contractorInfoGroupBox.Controls.Add(this.eFormComboBox);
            this.contractorInfoGroupBox.Controls.Add(this.occupationLabel);
            this.contractorInfoGroupBox.Controls.Add(this.clearButton);
            this.contractorInfoGroupBox.Controls.Add(this.deleteButton);
            this.contractorInfoGroupBox.Controls.Add(this.addOrUpdateButton);
            this.contractorInfoGroupBox.Controls.Add(this.contractorNameTextBox);
            this.contractorInfoGroupBox.Controls.Add(this.contractorNameLabel);
            resources.ApplyResources(this.contractorInfoGroupBox, "contractorInfoGroupBox");
            this.contractorInfoGroupBox.Name = "contractorInfoGroupBox";
            this.contractorInfoGroupBox.TabStop = false;
            // 
            // ShowNeverendCheckbox
            // 
            resources.ApplyResources(this.ShowNeverendCheckbox, "ShowNeverendCheckbox");
            this.ShowNeverendCheckbox.Name = "ShowNeverendCheckbox";
            this.ShowNeverendCheckbox.UseVisualStyleBackColor = true;
            // 
            // eFormComboBox
            // 
            this.eFormComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.eFormComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.eFormComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eFormComboBox.DropDownWidth = 250;
            this.eFormComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.eFormComboBox, "eFormComboBox");
            this.eFormComboBox.Name = "eFormComboBox";
            // 
            // occupationLabel
            // 
            resources.ApplyResources(this.occupationLabel, "occupationLabel");
            this.occupationLabel.Name = "occupationLabel";
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.OnClear);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnDelete);
            // 
            // addOrUpdateButton
            // 
            resources.ApplyResources(this.addOrUpdateButton, "addOrUpdateButton");
            this.addOrUpdateButton.Name = "addOrUpdateButton";
            this.addOrUpdateButton.UseVisualStyleBackColor = true;
            this.addOrUpdateButton.Click += new System.EventHandler(this.OnAddOrUpdate);
            // 
            // contractorNameTextBox
            // 
            resources.ApplyResources(this.contractorNameTextBox, "contractorNameTextBox");
            this.contractorNameTextBox.Name = "contractorNameTextBox";
            this.contractorNameTextBox.OltAcceptsReturn = true;
            this.contractorNameTextBox.OltTrimWhitespace = true;
            this.contractorNameTextBox.TextChanged += new System.EventHandler(this.OnContractorInformationChanged);
            // 
            // contractorNameLabel
            // 
            resources.ApplyResources(this.contractorNameLabel, "contractorNameLabel");
            this.contractorNameLabel.Name = "contractorNameLabel";
            // 
            // contractorsGroupBox
            // 
            resources.ApplyResources(this.contractorsGroupBox, "contractorsGroupBox");
            this.contractorsGroupBox.Name = "contractorsGroupBox";
            this.contractorsGroupBox.TabStop = false;
            // 
            // siteGroupBox
            // 
            this.siteGroupBox.Controls.Add(this.siteNameLabel);
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // siteNameLabel
            // 
            resources.ApplyResources(this.siteNameLabel, "siteNameLabel");
            this.siteNameLabel.Name = "siteNameLabel";
            this.siteNameLabel.UseMnemonic = false;
            // 
            // ConfigureGenericTemplateApprovalForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigureGenericTemplateApprovalForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contractorInfoGroupBox.ResumeLayout(false);
            this.contractorInfoGroupBox.PerformLayout();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private OltButton saveButton;
        private OltButton cancelButton;
        private OltGroupBox contractorInfoGroupBox;
        private OltGroupBox contractorsGroupBox;
        private OltTextBox contractorNameTextBox;
        private OltLabel contractorNameLabel;
        private OltButton clearButton;
        private OltButton deleteButton;
        private OltButton addOrUpdateButton;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private OltLabelData siteNameLabel;
        private OltEditableComboBox eFormComboBox;
        private OltLabel occupationLabel;
        private System.Windows.Forms.CheckBox ShowNeverendCheckbox;
    }
}
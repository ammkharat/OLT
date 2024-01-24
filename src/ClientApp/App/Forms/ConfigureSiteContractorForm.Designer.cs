using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureSiteContractorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureSiteContractorForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contractorInfoGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.clearButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addOrUpdateButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.contractorNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.contractorNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.contractorsGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.siteNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.contractorInfoGroupBox.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            resources.ApplyResources(this.contractorInfoGroupBox, "contractorInfoGroupBox");
            this.contractorInfoGroupBox.Controls.Add(this.clearButton);
            this.contractorInfoGroupBox.Controls.Add(this.deleteButton);
            this.contractorInfoGroupBox.Controls.Add(this.addOrUpdateButton);
            this.contractorInfoGroupBox.Controls.Add(this.contractorNameTextBox);
            this.contractorInfoGroupBox.Controls.Add(this.contractorNameLabel);
            this.contractorInfoGroupBox.Name = "contractorInfoGroupBox";
            this.contractorInfoGroupBox.TabStop = false;
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
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Controls.Add(this.siteNameLabel);
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // siteNameLabel
            // 
            resources.ApplyResources(this.siteNameLabel, "siteNameLabel");
            this.siteNameLabel.Name = "siteNameLabel";
            this.siteNameLabel.UseMnemonic = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
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
            // ConfigureSiteContractorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigureSiteContractorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contractorInfoGroupBox.ResumeLayout(false);
            this.contractorInfoGroupBox.PerformLayout();
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}
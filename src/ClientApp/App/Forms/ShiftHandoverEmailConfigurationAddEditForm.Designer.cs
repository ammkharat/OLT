namespace Com.Suncor.Olt.Client.Forms
{
    partial class ShiftHandoverEmailConfigurationAddEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftHandoverEmailConfigurationAddEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.shiftComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timePicker = new Com.Suncor.Olt.Client.OltControls.OltTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.emailAddressTextBox = new System.Windows.Forms.TextBox();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // shiftComboBox
            // 
            resources.ApplyResources(this.shiftComboBox, "shiftComboBox");
            this.shiftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorProvider.SetError(this.shiftComboBox, resources.GetString("shiftComboBox.Error"));
            this.shiftComboBox.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.shiftComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("shiftComboBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.shiftComboBox, ((int)(resources.GetObject("shiftComboBox.IconPadding"))));
            this.shiftComboBox.Name = "shiftComboBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // timePicker
            // 
            resources.ApplyResources(this.timePicker, "timePicker");
            this.timePicker.Checked = true;
            this.timePicker.CustomFormat = "HH:mm";
            this.errorProvider.SetError(this.timePicker, resources.GetString("timePicker.Error"));
            this.errorProvider.SetIconAlignment(this.timePicker, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("timePicker.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.timePicker, ((int)(resources.GetObject("timePicker.IconPadding"))));
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowCheckBox = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            // 
            // emailAddressTextBox
            // 
            resources.ApplyResources(this.emailAddressTextBox, "emailAddressTextBox");
            this.errorProvider.SetError(this.emailAddressTextBox, resources.GetString("emailAddressTextBox.Error"));
            this.errorProvider.SetIconAlignment(this.emailAddressTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("emailAddressTextBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.emailAddressTextBox, ((int)(resources.GetObject("emailAddressTextBox.IconPadding"))));
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.errorProvider.SetError(this.gridPanel, resources.GetString("gridPanel.Error"));
            this.errorProvider.SetIconAlignment(this.gridPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gridPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.gridPanel, ((int)(resources.GetObject("gridPanel.IconPadding"))));
            this.gridPanel.Name = "gridPanel";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
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
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.errorProvider.SetError(this.saveButton, resources.GetString("saveButton.Error"));
            this.errorProvider.SetIconAlignment(this.saveButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("saveButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.saveButton, ((int)(resources.GetObject("saveButton.IconPadding"))));
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // ShiftHandoverEmailConfigurationAddEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.emailAddressTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shiftComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ShiftHandoverEmailConfigurationAddEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox shiftComboBox;
        private System.Windows.Forms.Label label2;
        private OltControls.OltTimePicker timePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailAddressTextBox;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
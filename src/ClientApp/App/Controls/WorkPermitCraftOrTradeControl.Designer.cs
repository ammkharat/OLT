using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class WorkPermitCraftOrTradeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitCraftOrTradeControl));
            this.craftOrTradeGroupBox = new OltGroupBox();
            this.userSpecifiedCraftOrTradeTextBox = new OltTextBox();
            this.userSpecifiedTypeRadioButton = new OltRadioButton();
            this.systemTypeRadioButton = new OltRadioButton();
            this.systemCraftOrTradeComboBox = new OltComboBox();
            this.craftOrTradeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // craftOrTradeGroupBox
            // 
            this.craftOrTradeGroupBox.Controls.Add(this.userSpecifiedCraftOrTradeTextBox);
            this.craftOrTradeGroupBox.Controls.Add(this.userSpecifiedTypeRadioButton);
            this.craftOrTradeGroupBox.Controls.Add(this.systemTypeRadioButton);
            this.craftOrTradeGroupBox.Controls.Add(this.systemCraftOrTradeComboBox);
            resources.ApplyResources(this.craftOrTradeGroupBox, "craftOrTradeGroupBox");
            this.craftOrTradeGroupBox.Name = "craftOrTradeGroupBox";
            this.craftOrTradeGroupBox.TabStop = false;
            // 
            // userSpecifiedCraftOrTradeTextBox
            // 
            resources.ApplyResources(this.userSpecifiedCraftOrTradeTextBox, "userSpecifiedCraftOrTradeTextBox");
            this.userSpecifiedCraftOrTradeTextBox.Name = "userSpecifiedCraftOrTradeTextBox";
            this.userSpecifiedCraftOrTradeTextBox.OltAcceptsReturn = true;
            this.userSpecifiedCraftOrTradeTextBox.OltTrimWhitespace = true;
            // 
            // userSpecifiedTypeRadioButton
            // 
            resources.ApplyResources(this.userSpecifiedTypeRadioButton, "userSpecifiedTypeRadioButton");
            this.userSpecifiedTypeRadioButton.Name = "userSpecifiedTypeRadioButton";
            this.userSpecifiedTypeRadioButton.UseVisualStyleBackColor = true;
            this.userSpecifiedTypeRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // systemTypeRadioButton
            // 
            resources.ApplyResources(this.systemTypeRadioButton, "systemTypeRadioButton");
            this.systemTypeRadioButton.Checked = true;
            this.systemTypeRadioButton.Name = "systemTypeRadioButton";
            this.systemTypeRadioButton.TabStop = true;
            this.systemTypeRadioButton.UseVisualStyleBackColor = true;
            this.systemTypeRadioButton.CheckedChanged += new System.EventHandler(this.typeRadioButton_CheckedChanged);
            // 
            // systemCraftOrTradeComboBox
            // 
            this.systemCraftOrTradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.systemCraftOrTradeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.systemCraftOrTradeComboBox, "systemCraftOrTradeComboBox");
            this.systemCraftOrTradeComboBox.Name = "systemCraftOrTradeComboBox";
            // 
            // WorkPermitCraftOrTradeControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.craftOrTradeGroupBox);
            this.Name = "WorkPermitCraftOrTradeControl";
            this.craftOrTradeGroupBox.ResumeLayout(false);
            this.craftOrTradeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltGroupBox craftOrTradeGroupBox;
        private OltComboBox systemCraftOrTradeComboBox;
        private OltRadioButton userSpecifiedTypeRadioButton;
        private OltRadioButton systemTypeRadioButton;
        private OltTextBox userSpecifiedCraftOrTradeTextBox;
    }
}

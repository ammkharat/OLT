using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class WorkPermitContractorNameControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitContractorNameControl));
            this.contractorNameGroupBox = new System.Windows.Forms.GroupBox();
            this.otherLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.contractorNameComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.contractorNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.contractorTextFieldRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.contractorListRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.contractorNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // contractorNameGroupBox
            // 
            this.contractorNameGroupBox.Controls.Add(this.otherLabel);
            this.contractorNameGroupBox.Controls.Add(this.contractorNameComboBox);
            this.contractorNameGroupBox.Controls.Add(this.contractorNameTextBox);
            this.contractorNameGroupBox.Controls.Add(this.contractorTextFieldRadioButton);
            this.contractorNameGroupBox.Controls.Add(this.contractorListRadioButton);
            resources.ApplyResources(this.contractorNameGroupBox, "contractorNameGroupBox");
            this.contractorNameGroupBox.Name = "contractorNameGroupBox";
            this.contractorNameGroupBox.TabStop = false;
            // 
            // otherLabel
            // 
            resources.ApplyResources(this.otherLabel, "otherLabel");
            this.otherLabel.Name = "otherLabel";
            // 
            // contractorNameComboBox
            // 
            this.contractorNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contractorNameComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.contractorNameComboBox, "contractorNameComboBox");
            this.contractorNameComboBox.Name = "contractorNameComboBox";
            // 
            // contractorNameTextBox
            // 
            resources.ApplyResources(this.contractorNameTextBox, "contractorNameTextBox");
            this.contractorNameTextBox.Name = "contractorNameTextBox";
            this.contractorNameTextBox.OltAcceptsReturn = true;
            this.contractorNameTextBox.OltTrimWhitespace = true;
            // 
            // contractorTextFieldRadioButton
            // 
            resources.ApplyResources(this.contractorTextFieldRadioButton, "contractorTextFieldRadioButton");
            this.contractorTextFieldRadioButton.Name = "contractorTextFieldRadioButton";
            this.contractorTextFieldRadioButton.UseVisualStyleBackColor = true;
            // 
            // contractorListRadioButton
            // 
            resources.ApplyResources(this.contractorListRadioButton, "contractorListRadioButton");
            this.contractorListRadioButton.Checked = true;
            this.contractorListRadioButton.Name = "contractorListRadioButton";
            this.contractorListRadioButton.TabStop = true;
            this.contractorListRadioButton.UseVisualStyleBackColor = true;
            // 
            // WorkPermitContractorNameControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contractorNameGroupBox);
            this.Name = "WorkPermitContractorNameControl";
            this.contractorNameGroupBox.ResumeLayout(false);
            this.contractorNameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox contractorNameGroupBox;
        private OltRadioButton contractorListRadioButton;
        private OltTextBox contractorNameTextBox;
        private OltRadioButton contractorTextFieldRadioButton;
        private OltComboBox contractorNameComboBox;
        private OltLabel otherLabel;
    }
}

using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class ShiftHandoverAnswerReadonlyControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftHandoverAnswerReadonlyControl));
            this.questionNumberLabel = new OltLabel();
            this.questionTextLabel = new OltLabel();
            this.radioPanel = new OltPanel();
            this.noRadioButton = new OltRadioButton();
            this.yesRadioButton = new OltRadioButton();
            this.commentsTextBox = new OltTextBox();
            this.commentsLabel = new OltLabel();
            this.radioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AccessibleDescription = null;
            this.questionNumberLabel.AccessibleName = null;
            resources.ApplyResources(this.questionNumberLabel, "questionNumberLabel");
            this.questionNumberLabel.Font = null;
            this.questionNumberLabel.Name = "questionNumberLabel";
            // 
            // questionTextLabel
            // 
            this.questionTextLabel.AccessibleDescription = null;
            this.questionTextLabel.AccessibleName = null;
            resources.ApplyResources(this.questionTextLabel, "questionTextLabel");
            this.questionTextLabel.Font = null;
            this.questionTextLabel.Name = "questionTextLabel";
            this.questionTextLabel.UseMnemonic = false;
            // 
            // radioPanel
            // 
            this.radioPanel.AccessibleDescription = null;
            this.radioPanel.AccessibleName = null;
            resources.ApplyResources(this.radioPanel, "radioPanel");
            this.radioPanel.BackgroundImage = null;
            this.radioPanel.Controls.Add(this.noRadioButton);
            this.radioPanel.Controls.Add(this.yesRadioButton);
            this.radioPanel.Font = null;
            this.radioPanel.Name = "radioPanel";
            // 
            // noRadioButton
            // 
            this.noRadioButton.AccessibleDescription = null;
            this.noRadioButton.AccessibleName = null;
            resources.ApplyResources(this.noRadioButton, "noRadioButton");
            this.noRadioButton.BackgroundImage = null;
            this.noRadioButton.Font = null;
            this.noRadioButton.Name = "noRadioButton";
            this.noRadioButton.TabStop = true;
            this.noRadioButton.UseVisualStyleBackColor = true;
            // 
            // yesRadioButton
            // 
            this.yesRadioButton.AccessibleDescription = null;
            this.yesRadioButton.AccessibleName = null;
            resources.ApplyResources(this.yesRadioButton, "yesRadioButton");
            this.yesRadioButton.BackgroundImage = null;
            this.yesRadioButton.Font = null;
            this.yesRadioButton.Name = "yesRadioButton";
            this.yesRadioButton.TabStop = true;
            this.yesRadioButton.UseVisualStyleBackColor = true;
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.AccessibleDescription = null;
            this.commentsTextBox.AccessibleName = null;
            resources.ApplyResources(this.commentsTextBox, "commentsTextBox");
            this.commentsTextBox.BackColor = System.Drawing.Color.White;
            this.commentsTextBox.BackgroundImage = null;
            this.commentsTextBox.Font = null;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.OltAcceptsReturn = true;
            this.commentsTextBox.OltTrimWhitespace = true;
            this.commentsTextBox.ReadOnly = true;
            // 
            // commentsLabel
            // 
            this.commentsLabel.AccessibleDescription = null;
            this.commentsLabel.AccessibleName = null;
            resources.ApplyResources(this.commentsLabel, "commentsLabel");
            this.commentsLabel.Font = null;
            this.commentsLabel.Name = "commentsLabel";
            // 
            // ShiftHandoverAnswerReadonlyControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.radioPanel);
            this.Controls.Add(this.questionTextLabel);
            this.Controls.Add(this.questionNumberLabel);
            this.Font = null;
            this.Name = "ShiftHandoverAnswerReadonlyControl";
            this.radioPanel.ResumeLayout(false);
            this.radioPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabel questionNumberLabel;
        private OltLabel questionTextLabel;
        private OltPanel radioPanel;
        private OltRadioButton noRadioButton;
        private OltRadioButton yesRadioButton;
        private OltTextBox commentsTextBox;
        private OltLabel commentsLabel;
    }
}

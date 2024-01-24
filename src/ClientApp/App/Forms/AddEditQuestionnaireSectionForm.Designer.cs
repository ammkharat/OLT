using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditQuestionnaireSectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditQuestionnaireSectionForm));
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.questionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.deleteQuestionButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editQuestionButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addQuestionButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.moveQuestionDownButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.moveQuestionUpButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.questionsGridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.percentageWeightingLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            resources.ApplyResources(this.submitButton, "submitButton");
            this.submitButton.Name = "submitButton";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // questionLabel
            // 
            resources.ApplyResources(this.questionLabel, "questionLabel");
            this.questionLabel.Name = "questionLabel";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = true;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // deleteQuestionButton
            // 
            resources.ApplyResources(this.deleteQuestionButton, "deleteQuestionButton");
            this.deleteQuestionButton.Name = "deleteQuestionButton";
            this.deleteQuestionButton.UseVisualStyleBackColor = true;
            // 
            // editQuestionButton
            // 
            resources.ApplyResources(this.editQuestionButton, "editQuestionButton");
            this.editQuestionButton.Name = "editQuestionButton";
            this.editQuestionButton.UseVisualStyleBackColor = true;
            // 
            // addQuestionButton
            // 
            resources.ApplyResources(this.addQuestionButton, "addQuestionButton");
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            // 
            // moveQuestionDownButton
            // 
            resources.ApplyResources(this.moveQuestionDownButton, "moveQuestionDownButton");
            this.moveQuestionDownButton.Name = "moveQuestionDownButton";
            this.moveQuestionDownButton.UseVisualStyleBackColor = true;
            // 
            // moveQuestionUpButton
            // 
            resources.ApplyResources(this.moveQuestionUpButton, "moveQuestionUpButton");
            this.moveQuestionUpButton.Name = "moveQuestionUpButton";
            this.moveQuestionUpButton.UseVisualStyleBackColor = true;
            // 
            // questionsGridPanel
            // 
            resources.ApplyResources(this.questionsGridPanel, "questionsGridPanel");
            this.questionsGridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.questionsGridPanel.Name = "questionsGridPanel";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // percentageWeightingLabel
            // 
            resources.ApplyResources(this.percentageWeightingLabel, "percentageWeightingLabel");
            this.percentageWeightingLabel.Name = "percentageWeightingLabel";
            // 
            // AddEditQuestionnaireSectionForm
            // 
            this.AcceptButton = this.submitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteQuestionButton);
            this.Controls.Add(this.editQuestionButton);
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.moveQuestionDownButton);
            this.Controls.Add(this.moveQuestionUpButton);
            this.Controls.Add(this.questionsGridPanel);
            this.Controls.Add(this.percentageWeightingLabel);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddEditQuestionnaireSectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton submitButton;
        private OltButton cancelButton;
        private OltLabel questionLabel;
        private OltTextBox nameTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltButton deleteQuestionButton;
        private OltButton editQuestionButton;
        private OltButton addQuestionButton;
        private OltButton moveQuestionDownButton;
        private OltButton moveQuestionUpButton;
        private OltPanel questionsGridPanel;
        private OltLabel percentageWeightingLabel;
        private OltLabel oltLabel1;
    }
}
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class AddEditQuestionnaireQuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditQuestionnaireQuestionForm));
            this.submitButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.questionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.questionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.weightTextLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.weightTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
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
            // questionTextBox
            // 
            resources.ApplyResources(this.questionTextBox, "questionTextBox");
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.OltAcceptsReturn = true;
            this.questionTextBox.OltTrimWhitespace = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // weightTextLabel
            // 
            resources.ApplyResources(this.weightTextLabel, "weightTextLabel");
            this.weightTextLabel.Name = "weightTextLabel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.submitButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // weightTextBox
            // 
            resources.ApplyResources(this.weightTextBox, "weightTextBox");
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.OltAcceptsReturn = true;
            this.weightTextBox.OltTrimWhitespace = true;
            // 
            // AddEditQuestionnaireQuestionForm
            // 
            this.AcceptButton = this.submitButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.weightTextLabel);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.questionTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddEditQuestionnaireQuestionForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton submitButton;
        private OltButton cancelButton;
        private OltLabel questionLabel;
        private OltTextBox questionTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltLabel weightTextLabel;
        private System.Windows.Forms.Panel panel1;
        private OltTextBox weightTextBox;
    }
}
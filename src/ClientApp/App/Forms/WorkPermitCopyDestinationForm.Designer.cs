using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class WorkPermitCopyDestinationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPermitCopyDestinationForm));
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.copyButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.candidateWorkPermitsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // copyButton
            // 
            resources.ApplyResources(this.copyButton, "copyButton");
            this.copyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.copyButton.Name = "copyButton";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // candidateWorkPermitsPanel
            // 
            resources.ApplyResources(this.candidateWorkPermitsPanel, "candidateWorkPermitsPanel");
            this.candidateWorkPermitsPanel.Name = "candidateWorkPermitsPanel";
            // 
            // WorkPermitCopyDestinationForm
            // 
            this.AcceptButton = this.copyButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.candidateWorkPermitsPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.copyButton);
            this.MaximizeBox = false;
            this.Name = "WorkPermitCopyDestinationForm";
            this.Load += new System.EventHandler(this.WorkPermitCopyDestinationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private OltButton copyButton;
        private OltPanel candidateWorkPermitsPanel;
    }
}
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class DeviationAlertCopyLastResponseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviationAlertCopyLastResponseForm));
            this.gridPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.copyLastResponseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.oltGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridPanel.Name = "gridPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveAndCloseButton
            // 
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // copyLastResponseButton
            // 
            resources.ApplyResources(this.copyLastResponseButton, "copyLastResponseButton");
            this.copyLastResponseButton.Name = "copyLastResponseButton";
            this.copyLastResponseButton.UseVisualStyleBackColor = true;
            // 
            // oltGroupBox1
            // 
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Controls.Add(this.gridPanel);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // DeviationAlertCopyLastResponseForm
            // 
            this.AcceptButton = this.saveAndCloseButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.oltGroupBox1);
            this.Controls.Add(this.copyLastResponseButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.MaximizeBox = false;
            this.Name = "DeviationAlertCopyLastResponseForm";
            this.Load += new System.EventHandler(this.DeviationAlertCopyLastResponseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.oltGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private System.Windows.Forms.Panel gridPanel;
        private OltButton saveAndCloseButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltButton copyLastResponseButton;
        private OltGroupBox oltGroupBox1;
    }
}
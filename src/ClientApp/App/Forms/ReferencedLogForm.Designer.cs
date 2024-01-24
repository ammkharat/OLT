using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ReferencedLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferencedLogForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.logsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.logDetails = new Com.Suncor.Olt.Client.Controls.Details.LogDetails();
            this.logBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.goToLogButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.okButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.logsPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logDetails);
            // 
            // logsPanel
            // 
            this.logsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.logsPanel, "logsPanel");
            this.logsPanel.Name = "logsPanel";
            // 
            // logDetails
            // 
            resources.ApplyResources(this.logDetails, "logDetails");
            this.logDetails.Name = "logDetails";
            this.logDetails.ShowButtonAppearance = null;
            this.logDetails.ShowTreePanel = true;
            // 
            // logBindingSource
            // 
            this.logBindingSource.DataSource = typeof(Com.Suncor.Olt.Client.Presenters.LogDTOSummaryItemGridDisplayAdapter);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.goToLogButton);
            this.buttonPanel.Controls.Add(this.okButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // goToLogButton
            // 
            resources.ApplyResources(this.goToLogButton, "goToLogButton");
            this.goToLogButton.Name = "goToLogButton";
            this.goToLogButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // ReferencedLogForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ReferencedLogForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource logBindingSource;
        private System.Windows.Forms.Panel buttonPanel;
        private OltButton okButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private OltPanel logsPanel;
        private LogDetails logDetails;
        private OltButton goToLogButton;
    }
}
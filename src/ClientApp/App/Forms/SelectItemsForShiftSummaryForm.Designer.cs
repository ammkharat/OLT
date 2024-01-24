using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class SelectItemsForShiftSummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectItemsForShiftSummaryForm));
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.appendToCommentsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.pageTitle = new Com.Suncor.Olt.Client.OltControls.OltLabelTitle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.errorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // appendToCommentsButton
            // 
            resources.ApplyResources(this.appendToCommentsButton, "appendToCommentsButton");
            this.errorProvider.SetError(this.appendToCommentsButton, resources.GetString("appendToCommentsButton.Error"));
            this.errorProvider.SetIconAlignment(this.appendToCommentsButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("appendToCommentsButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.appendToCommentsButton, ((int)(resources.GetObject("appendToCommentsButton.IconPadding"))));
            this.appendToCommentsButton.Name = "appendToCommentsButton";
            this.appendToCommentsButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.appendToCommentsButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.errorProvider.SetError(this.buttonPanel, resources.GetString("buttonPanel.Error"));
            this.errorProvider.SetIconAlignment(this.buttonPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonPanel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.buttonPanel, ((int)(resources.GetObject("buttonPanel.IconPadding"))));
            this.buttonPanel.Name = "buttonPanel";
            // 
            // pageTitle
            // 
            resources.ApplyResources(this.pageTitle, "pageTitle");
            this.pageTitle.BackColor = System.Drawing.Color.Gray;
            this.errorProvider.SetError(this.pageTitle, resources.GetString("pageTitle.Error"));
            this.pageTitle.ForeColor = System.Drawing.Color.White;
            this.errorProvider.SetIconAlignment(this.pageTitle, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pageTitle.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.pageTitle, ((int)(resources.GetObject("pageTitle.IconPadding"))));
            this.pageTitle.Name = "pageTitle";
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.errorProvider.SetError(this.splitContainer, resources.GetString("splitContainer.Error"));
            this.errorProvider.SetIconAlignment(this.splitContainer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitContainer, ((int)(resources.GetObject("splitContainer.IconPadding"))));
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.errorProvider.SetError(this.splitContainer.Panel1, resources.GetString("splitContainer.Panel1.Error"));
            this.errorProvider.SetIconAlignment(this.splitContainer.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer.Panel1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitContainer.Panel1, ((int)(resources.GetObject("splitContainer.Panel1.IconPadding"))));
            // 
            // splitContainer.Panel2
            // 
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.errorProvider.SetError(this.splitContainer.Panel2, resources.GetString("splitContainer.Panel2.Error"));
            this.errorProvider.SetIconAlignment(this.splitContainer.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer.Panel2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.splitContainer.Panel2, ((int)(resources.GetObject("splitContainer.Panel2.IconPadding"))));
            // 
            // SelectItemsForShiftSummaryForm
            // 
            this.AcceptButton = this.appendToCommentsButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pageTitle);
            this.Controls.Add(this.buttonPanel);
            this.Name = "SelectItemsForShiftSummaryForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private OltButton appendToCommentsButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel buttonPanel;
        private OltLabelTitle pageTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

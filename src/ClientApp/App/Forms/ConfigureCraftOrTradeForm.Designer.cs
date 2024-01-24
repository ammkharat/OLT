using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureCraftOrTradeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureCraftOrTradeForm));
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.deleteButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.editButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.newButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.siteNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.craftOrTradeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.siteGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            resources.ApplyResources(this.newButton, "newButton");
            this.newButton.Name = "newButton";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // siteNameLabel
            // 
            resources.ApplyResources(this.siteNameLabel, "siteNameLabel");
            this.siteNameLabel.Name = "siteNameLabel";
            this.siteNameLabel.UseMnemonic = false;
            // 
            // craftOrTradeGroupBox
            // 
            resources.ApplyResources(this.craftOrTradeGroupBox, "craftOrTradeGroupBox");
            this.craftOrTradeGroupBox.Name = "craftOrTradeGroupBox";
            this.craftOrTradeGroupBox.TabStop = false;
            // 
            // siteGroupBox
            // 
            this.siteGroupBox.Controls.Add(this.siteNameLabel);
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // ConfigureCraftOrTradeForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.siteGroupBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.craftOrTradeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigureCraftOrTradeForm";
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton closeButton;
        private OltButton deleteButton;
        private OltButton editButton;
        private OltButton newButton;
        private OltLabelData siteNameLabel;
        private OltGroupBox craftOrTradeGroupBox;
        private System.Windows.Forms.GroupBox siteGroupBox;
    }
}

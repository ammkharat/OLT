using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class CraftOrTradeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CraftOrTradeForm));
            this.siteNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.craftOrTradeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.oltPanel1 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.siteGroupBox = new System.Windows.Forms.GroupBox();
            this.oltPanel2 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltPanel3 = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.craftOrTradeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.workCentreTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.workCentreLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.nameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.duplicateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.craftOrTradeTableLayoutPanel.SuspendLayout();
            this.oltPanel1.SuspendLayout();
            this.siteGroupBox.SuspendLayout();
            this.oltPanel2.SuspendLayout();
            this.oltPanel3.SuspendLayout();
            this.craftOrTradeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // siteNameLabel
            // 
            resources.ApplyResources(this.siteNameLabel, "siteNameLabel");
            this.siteNameLabel.Name = "siteNameLabel";
            this.siteNameLabel.UseMnemonic = false;
            // 
            // craftOrTradeTableLayoutPanel
            // 
            resources.ApplyResources(this.craftOrTradeTableLayoutPanel, "craftOrTradeTableLayoutPanel");
            this.craftOrTradeTableLayoutPanel.Controls.Add(this.oltPanel3, 0, 1);
            this.craftOrTradeTableLayoutPanel.Name = "craftOrTradeTableLayoutPanel";
            // 
            // oltPanel1
            // 
            this.oltPanel1.Controls.Add(this.siteGroupBox);
            resources.ApplyResources(this.oltPanel1, "oltPanel1");
            this.oltPanel1.Name = "oltPanel1";
            // 
            // siteGroupBox
            // 
            this.siteGroupBox.Controls.Add(this.siteNameLabel);
            resources.ApplyResources(this.siteGroupBox, "siteGroupBox");
            this.siteGroupBox.Name = "siteGroupBox";
            this.siteGroupBox.TabStop = false;
            // 
            // oltPanel2
            // 
            this.oltPanel2.Controls.Add(this.cancelButton);
            this.oltPanel2.Controls.Add(this.saveButton);
            resources.ApplyResources(this.oltPanel2, "oltPanel2");
            this.oltPanel2.Name = "oltPanel2";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // oltPanel3
            // 
            this.oltPanel3.Controls.Add(this.craftOrTradeGroupBox);
            resources.ApplyResources(this.oltPanel3, "oltPanel3");
            this.oltPanel3.Name = "oltPanel3";
            // 
            // craftOrTradeGroupBox
            // 
            this.craftOrTradeGroupBox.Controls.Add(this.workCentreTextBox);
            this.craftOrTradeGroupBox.Controls.Add(this.workCentreLabel);
            this.craftOrTradeGroupBox.Controls.Add(this.nameTextBox);
            this.craftOrTradeGroupBox.Controls.Add(this.nameLabel);
            resources.ApplyResources(this.craftOrTradeGroupBox, "craftOrTradeGroupBox");
            this.craftOrTradeGroupBox.Name = "craftOrTradeGroupBox";
            this.craftOrTradeGroupBox.TabStop = false;
            // 
            // workCentreTextBox
            // 
            resources.ApplyResources(this.workCentreTextBox, "workCentreTextBox");
            this.workCentreTextBox.Name = "workCentreTextBox";
            this.workCentreTextBox.OltAcceptsReturn = true;
            this.workCentreTextBox.OltTrimWhitespace = true;
            // 
            // workCentreLabel
            // 
            resources.ApplyResources(this.workCentreLabel, "workCentreLabel");
            this.workCentreLabel.Name = "workCentreLabel";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = true;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // nameErrorProvider
            // 
            this.nameErrorProvider.ContainerControl = this;
            // 
            // duplicateErrorProvider
            // 
            this.duplicateErrorProvider.ContainerControl = this;
            // 
            // CraftOrTradeForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.oltPanel2);
            this.Controls.Add(this.oltPanel1);
            this.Controls.Add(this.craftOrTradeTableLayoutPanel);
            this.MaximizeBox = false;
            this.Name = "CraftOrTradeForm";
            this.craftOrTradeTableLayoutPanel.ResumeLayout(false);
            this.oltPanel1.ResumeLayout(false);
            this.siteGroupBox.ResumeLayout(false);
            this.siteGroupBox.PerformLayout();
            this.oltPanel2.ResumeLayout(false);
            this.oltPanel3.ResumeLayout(false);
            this.craftOrTradeGroupBox.ResumeLayout(false);
            this.craftOrTradeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabelData siteNameLabel;
        private System.Windows.Forms.TableLayoutPanel craftOrTradeTableLayoutPanel;
        private OltPanel oltPanel1;
        private OltPanel oltPanel2;
        private OltButton cancelButton;
        private OltButton saveButton;
        private OltPanel oltPanel3;
        private OltGroupBox craftOrTradeGroupBox;
        private OltTextBox nameTextBox;
        private OltLabel nameLabel;
        private ErrorProvider nameErrorProvider;
        private ErrorProvider duplicateErrorProvider;
        private System.Windows.Forms.GroupBox siteGroupBox;
        private OltTextBox workCentreTextBox;
        private OltLabel workCentreLabel;

    }
}

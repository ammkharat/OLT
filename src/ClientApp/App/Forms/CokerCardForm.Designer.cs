using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Forms
{
    partial class CokerCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CokerCardForm));
            this.shiftGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.shiftLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.lastModifiedDateAuthorHeader = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.configurationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.cokerCardConfigurationName = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.viewEditHistoryButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.shiftGroupBox.SuspendLayout();
            this.configurationGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shiftGroupBox
            // 
            resources.ApplyResources(this.shiftGroupBox, "shiftGroupBox");
            this.shiftGroupBox.Controls.Add(this.shiftLabelData);
            this.shiftGroupBox.Name = "shiftGroupBox";
            this.shiftGroupBox.TabStop = false;
            // 
            // shiftLabelData
            // 
            resources.ApplyResources(this.shiftLabelData, "shiftLabelData");
            this.shiftLabelData.Name = "shiftLabelData";
            this.shiftLabelData.UseMnemonic = false;
            // 
            // lastModifiedDateAuthorHeader
            // 
            resources.ApplyResources(this.lastModifiedDateAuthorHeader, "lastModifiedDateAuthorHeader");
            this.lastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.lastModifiedDateAuthorHeader.Name = "lastModifiedDateAuthorHeader";
            this.lastModifiedDateAuthorHeader.TabStop = false;
            // 
            // configurationGroupBox
            // 
            this.configurationGroupBox.Controls.Add(this.cokerCardConfigurationName);
            resources.ApplyResources(this.configurationGroupBox, "configurationGroupBox");
            this.configurationGroupBox.Name = "configurationGroupBox";
            this.configurationGroupBox.TabStop = false;
            // 
            // cokerCardConfigurationName
            // 
            resources.ApplyResources(this.cokerCardConfigurationName, "cokerCardConfigurationName");
            this.cokerCardConfigurationName.Name = "cokerCardConfigurationName";
            this.cokerCardConfigurationName.UseMnemonic = false;
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
            // viewEditHistoryButton
            // 
            resources.ApplyResources(this.viewEditHistoryButton, "viewEditHistoryButton");
            this.viewEditHistoryButton.Name = "viewEditHistoryButton";
            this.viewEditHistoryButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.viewEditHistoryButton);
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Name = "buttonPanel";
            // 
            // oltLabelLine1
            // 
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.Name = "gridPanel";
            // 
            // CokerCardForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.configurationGroupBox);
            this.Controls.Add(this.oltLabelLine1);
            this.Controls.Add(this.shiftGroupBox);
            this.Controls.Add(this.lastModifiedDateAuthorHeader);
            this.Controls.Add(this.buttonPanel);
            this.Name = "CokerCardForm";
            this.shiftGroupBox.ResumeLayout(false);
            this.shiftGroupBox.PerformLayout();
            this.configurationGroupBox.ResumeLayout(false);
            this.configurationGroupBox.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltButton cancelButton;
        private OltButton saveButton;
        private OltButton viewEditHistoryButton;
        private OltGroupBox configurationGroupBox;
        private Panel buttonPanel;
        private OltLastModifiedDateAuthorHeader lastModifiedDateAuthorHeader;
        private OltGroupBox shiftGroupBox;
        private OltLabelData shiftLabelData;
        private OltLabelLine oltLabelLine1;
        private OltPanel gridPanel;
        private OltLabelData cokerCardConfigurationName;

    }
}

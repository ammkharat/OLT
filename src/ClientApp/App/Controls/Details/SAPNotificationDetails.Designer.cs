using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class SAPNotificationDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAPNotificationDetails));
            this.typeData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.dateGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createTimeData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.startByLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.createDateData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.startDateLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.commentsLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.incidentIDLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.notificationNumberLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.shortTextLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.userCommentsLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.longTextLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionalLocationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.descriptionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.creationDateTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.typeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.descriptionLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.functionalLocationLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.submitToLogButton = new System.Windows.Forms.ToolStripButton();
            this.submitToLogButtonAsOperatingEngineerLog = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.exportAllButton = new System.Windows.Forms.ToolStripButton();
            this.dateRangeToggleButton = new System.Windows.Forms.ToolStripButton();
            this.saveGridLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.dateGroupBox.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeData
            // 
            resources.ApplyResources(this.typeData, "typeData");
            this.typeData.BackColor = System.Drawing.SystemColors.Control;
            this.typeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.typeData.Name = "typeData";
            this.typeData.UseMnemonic = false;
            // 
            // dateGroupBox
            // 
            resources.ApplyResources(this.dateGroupBox, "dateGroupBox");
            this.dateGroupBox.Controls.Add(this.createTimeData);
            this.dateGroupBox.Controls.Add(this.startByLabel);
            this.dateGroupBox.Controls.Add(this.createDateData);
            this.dateGroupBox.Controls.Add(this.startDateLabelData);
            this.dateGroupBox.Name = "dateGroupBox";
            this.dateGroupBox.TabStop = false;
            // 
            // createTimeData
            // 
            resources.ApplyResources(this.createTimeData, "createTimeData");
            this.createTimeData.Name = "createTimeData";
            this.createTimeData.UseMnemonic = false;
            // 
            // startByLabel
            // 
            resources.ApplyResources(this.startByLabel, "startByLabel");
            this.startByLabel.Name = "startByLabel";
            this.startByLabel.UseMnemonic = false;
            // 
            // createDateData
            // 
            resources.ApplyResources(this.createDateData, "createDateData");
            this.createDateData.Name = "createDateData";
            this.createDateData.UseMnemonic = false;
            // 
            // startDateLabelData
            // 
            resources.ApplyResources(this.startDateLabelData, "startDateLabelData");
            this.startDateLabelData.Name = "startDateLabelData";
            this.startDateLabelData.UseMnemonic = false;
            // 
            // detailsPanel
            // 
            resources.ApplyResources(this.detailsPanel, "detailsPanel");
            this.detailsPanel.BackColor = System.Drawing.Color.White;
            this.detailsPanel.Controls.Add(this.commentsLabelData);
            this.detailsPanel.Controls.Add(this.incidentIDLabelData);
            this.detailsPanel.Controls.Add(this.notificationNumberLabelData);
            this.detailsPanel.Controls.Add(this.shortTextLabelData);
            this.detailsPanel.Controls.Add(this.dateGroupBox);
            this.detailsPanel.Controls.Add(this.typeData);
            this.detailsPanel.Controls.Add(this.leftPanel);
            this.detailsPanel.Controls.Add(this.descriptionLabelData);
            this.detailsPanel.Controls.Add(this.functionalLocationLabelData);
            this.detailsPanel.Name = "detailsPanel";
            // 
            // commentsLabelData
            // 
            resources.ApplyResources(this.commentsLabelData, "commentsLabelData");
            this.commentsLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.commentsLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commentsLabelData.Name = "commentsLabelData";
            this.commentsLabelData.UseMnemonic = false;
            // 
            // incidentIDLabelData
            // 
            resources.ApplyResources(this.incidentIDLabelData, "incidentIDLabelData");
            this.incidentIDLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.incidentIDLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.incidentIDLabelData.Name = "incidentIDLabelData";
            this.incidentIDLabelData.UseMnemonic = false;
            // 
            // notificationNumberLabelData
            // 
            resources.ApplyResources(this.notificationNumberLabelData, "notificationNumberLabelData");
            this.notificationNumberLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.notificationNumberLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationNumberLabelData.Name = "notificationNumberLabelData";
            this.notificationNumberLabelData.UseMnemonic = false;
            // 
            // shortTextLabelData
            // 
            resources.ApplyResources(this.shortTextLabelData, "shortTextLabelData");
            this.shortTextLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.shortTextLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shortTextLabelData.Name = "shortTextLabelData";
            this.shortTextLabelData.UseMnemonic = false;
            // 
            // leftPanel
            // 
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.leftPanel.Controls.Add(this.userCommentsLabel);
            this.leftPanel.Controls.Add(this.oltLabel2);
            this.leftPanel.Controls.Add(this.longTextLabel);
            this.leftPanel.Controls.Add(this.oltLabel1);
            this.leftPanel.Controls.Add(this.functionalLocationLabel);
            this.leftPanel.Controls.Add(this.descriptionLabel);
            this.leftPanel.Controls.Add(this.creationDateTimeLabel);
            this.leftPanel.Controls.Add(this.typeLabel);
            this.leftPanel.Name = "leftPanel";
            // 
            // userCommentsLabel
            // 
            resources.ApplyResources(this.userCommentsLabel, "userCommentsLabel");
            this.userCommentsLabel.Name = "userCommentsLabel";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // longTextLabel
            // 
            resources.ApplyResources(this.longTextLabel, "longTextLabel");
            this.longTextLabel.Name = "longTextLabel";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // functionalLocationLabel
            // 
            resources.ApplyResources(this.functionalLocationLabel, "functionalLocationLabel");
            this.functionalLocationLabel.Name = "functionalLocationLabel";
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // creationDateTimeLabel
            // 
            resources.ApplyResources(this.creationDateTimeLabel, "creationDateTimeLabel");
            this.creationDateTimeLabel.Name = "creationDateTimeLabel";
            // 
            // typeLabel
            // 
            resources.ApplyResources(this.typeLabel, "typeLabel");
            this.typeLabel.Name = "typeLabel";
            // 
            // descriptionLabelData
            // 
            resources.ApplyResources(this.descriptionLabelData, "descriptionLabelData");
            this.descriptionLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.descriptionLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabelData.Name = "descriptionLabelData";
            this.descriptionLabelData.UseMnemonic = false;
            // 
            // functionalLocationLabelData
            // 
            resources.ApplyResources(this.functionalLocationLabelData, "functionalLocationLabelData");
            this.functionalLocationLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.functionalLocationLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalLocationLabelData.Name = "functionalLocationLabelData";
            this.functionalLocationLabelData.UseMnemonic = false;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submitToLogButton,
            this.submitToLogButtonAsOperatingEngineerLog,
            this.editButton,
            this.exportAllButton,
            this.dateRangeToggleButton,
            this.saveGridLayoutButton});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // submitToLogButton
            // 
            resources.ApplyResources(this.submitToLogButton, "submitToLogButton");
            this.submitToLogButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.submit_to_log;
            this.submitToLogButton.Name = "submitToLogButton";
            // 
            // submitToLogButtonAsOperatingEngineerLog
            // 
            resources.ApplyResources(this.submitToLogButtonAsOperatingEngineerLog, "submitToLogButtonAsOperatingEngineerLog");
            this.submitToLogButtonAsOperatingEngineerLog.Image = global::Com.Suncor.Olt.Client.Properties.Resources.submit_to_log;
            this.submitToLogButtonAsOperatingEngineerLog.Name = "submitToLogButtonAsOperatingEngineerLog";
            // 
            // editButton
            // 
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.edit_16;
            this.editButton.Name = "editButton";
            // 
            // exportAllButton
            // 
            resources.ApplyResources(this.exportAllButton, "exportAllButton");
            this.exportAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportAllButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.export_all;
            this.exportAllButton.Name = "exportAllButton";
            // 
            // dateRangeToggleButton
            // 
            resources.ApplyResources(this.dateRangeToggleButton, "dateRangeToggleButton");
            this.dateRangeToggleButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dateRangeToggleButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.show_date_range;
            this.dateRangeToggleButton.Name = "dateRangeToggleButton";
            // 
            // saveGridLayoutButton
            // 
            resources.ApplyResources(this.saveGridLayoutButton, "saveGridLayoutButton");
            this.saveGridLayoutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveGridLayoutButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.grid_16;
            this.saveGridLayoutButton.Name = "saveGridLayoutButton";
            // 
            // SAPNotificationDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SAPNotificationDetails";
            this.dateGroupBox.ResumeLayout(false);
            this.dateGroupBox.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltLabelData typeData;
        private OltGroupBox dateGroupBox;
        private OltLabelData createDateData;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Panel leftPanel;
        private OltLabel descriptionLabel;
        private OltLabel creationDateTimeLabel;
        private OltLabel typeLabel;
        private OltLabelData descriptionLabelData;
        private OltLabelData functionalLocationLabelData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton editButton;
        private OltLabelData notificationNumberLabelData;
        private OltLabel oltLabel1;
        private OltLabel functionalLocationLabel;
        private OltLabelData createTimeData;
        private OltLabelData startByLabel;
        private OltLabelData startDateLabelData;
        private System.Windows.Forms.ToolStripButton submitToLogButton;
        private OltLabelData incidentIDLabelData;
        private OltLabelData shortTextLabelData;
        private OltLabel oltLabel2;
        private OltLabel longTextLabel;
        private OltLabelData commentsLabelData;
        private OltLabel userCommentsLabel;
        private System.Windows.Forms.ToolStripButton submitToLogButtonAsOperatingEngineerLog;
        private System.Windows.Forms.ToolStripButton exportAllButton;
        private System.Windows.Forms.ToolStripButton dateRangeToggleButton;
        private System.Windows.Forms.ToolStripButton saveGridLayoutButton;
    }
}

using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class LabAlertDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertDetails));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.respondButton = new System.Windows.Forms.ToolStripButton();
            this.goToDefinitionButton = new System.Windows.Forms.ToolStripButton();
            this.exportAllButton = new System.Windows.Forms.ToolStripButton();
            this.toggleShowButton = new System.Windows.Forms.ToolStripButton();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.scheduleLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.descriptionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.actualNumberOfSamplesLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.responsePanel = new System.Windows.Forms.Panel();
            this.createdDateTimeLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.timeRangeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltLabel5 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minimumNumberOfSamplesLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.timeRangeToLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.timeRangeFromLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.functionalLocationData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.nameData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.scheduleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.responsesLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionLocationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.saveGridLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            this.timeRangeGroupBox.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.respondButton,
            this.goToDefinitionButton,
            this.exportAllButton,
            this.toggleShowButton,
            this.saveGridLayoutButton});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // respondButton
            // 
            this.respondButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.replyRespond_16;
            resources.ApplyResources(this.respondButton, "respondButton");
            this.respondButton.Name = "respondButton";
            // 
            // goToDefinitionButton
            // 
            this.goToDefinitionButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.goto_definition;
            resources.ApplyResources(this.goToDefinitionButton, "goToDefinitionButton");
            this.goToDefinitionButton.Name = "goToDefinitionButton";
            // 
            // exportAllButton
            // 
            this.exportAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportAllButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.export_all;
            resources.ApplyResources(this.exportAllButton, "exportAllButton");
            this.exportAllButton.Name = "exportAllButton";
            // 
            // toggleShowButton
            // 
            this.toggleShowButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toggleShowButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.show_date_range;
            resources.ApplyResources(this.toggleShowButton, "toggleShowButton");
            this.toggleShowButton.Name = "toggleShowButton";
            // 
            // detailsPanel
            // 
            resources.ApplyResources(this.detailsPanel, "detailsPanel");
            this.detailsPanel.BackColor = System.Drawing.Color.White;
            this.detailsPanel.Controls.Add(this.descriptionTextBox);
            this.detailsPanel.Controls.Add(this.scheduleLabelData);
            this.detailsPanel.Controls.Add(this.descriptionLabel);
            this.detailsPanel.Controls.Add(this.actualNumberOfSamplesLabelData);
            this.detailsPanel.Controls.Add(this.responsePanel);
            this.detailsPanel.Controls.Add(this.createdDateTimeLabelData);
            this.detailsPanel.Controls.Add(this.timeRangeGroupBox);
            this.detailsPanel.Controls.Add(this.tagData);
            this.detailsPanel.Controls.Add(this.functionalLocationData);
            this.detailsPanel.Controls.Add(this.nameData);
            this.detailsPanel.Controls.Add(this.leftPanel);
            this.detailsPanel.Name = "detailsPanel";
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltAcceptsReturn = true;
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.ReadOnly = true;
            // 
            // scheduleLabelData
            // 
            resources.ApplyResources(this.scheduleLabelData, "scheduleLabelData");
            this.scheduleLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.scheduleLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheduleLabelData.Name = "scheduleLabelData";
            this.scheduleLabelData.UseMnemonic = false;
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.descriptionLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // actualNumberOfSamplesLabelData
            // 
            this.actualNumberOfSamplesLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.actualNumberOfSamplesLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.actualNumberOfSamplesLabelData, "actualNumberOfSamplesLabelData");
            this.actualNumberOfSamplesLabelData.Name = "actualNumberOfSamplesLabelData";
            this.actualNumberOfSamplesLabelData.UseMnemonic = false;
            // 
            // responsePanel
            // 
            resources.ApplyResources(this.responsePanel, "responsePanel");
            this.responsePanel.Name = "responsePanel";
            // 
            // createdDateTimeLabelData
            // 
            this.createdDateTimeLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.createdDateTimeLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.createdDateTimeLabelData, "createdDateTimeLabelData");
            this.createdDateTimeLabelData.Name = "createdDateTimeLabelData";
            this.createdDateTimeLabelData.UseMnemonic = false;
            // 
            // timeRangeGroupBox
            // 
            resources.ApplyResources(this.timeRangeGroupBox, "timeRangeGroupBox");
            this.timeRangeGroupBox.Controls.Add(this.oltLabel5);
            this.timeRangeGroupBox.Controls.Add(this.oltLabel3);
            this.timeRangeGroupBox.Controls.Add(this.minimumNumberOfSamplesLabel);
            this.timeRangeGroupBox.Controls.Add(this.timeRangeToLabel);
            this.timeRangeGroupBox.Controls.Add(this.timeRangeFromLabel);
            this.timeRangeGroupBox.Name = "timeRangeGroupBox";
            this.timeRangeGroupBox.TabStop = false;
            // 
            // oltLabel5
            // 
            resources.ApplyResources(this.oltLabel5, "oltLabel5");
            this.oltLabel5.Name = "oltLabel5";
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // minimumNumberOfSamplesLabel
            // 
            resources.ApplyResources(this.minimumNumberOfSamplesLabel, "minimumNumberOfSamplesLabel");
            this.minimumNumberOfSamplesLabel.Name = "minimumNumberOfSamplesLabel";
            // 
            // timeRangeToLabel
            // 
            resources.ApplyResources(this.timeRangeToLabel, "timeRangeToLabel");
            this.timeRangeToLabel.Name = "timeRangeToLabel";
            // 
            // timeRangeFromLabel
            // 
            resources.ApplyResources(this.timeRangeFromLabel, "timeRangeFromLabel");
            this.timeRangeFromLabel.Name = "timeRangeFromLabel";
            // 
            // tagData
            // 
            resources.ApplyResources(this.tagData, "tagData");
            this.tagData.BackColor = System.Drawing.SystemColors.Control;
            this.tagData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagData.Name = "tagData";
            this.tagData.UseMnemonic = false;
            // 
            // functionalLocationData
            // 
            resources.ApplyResources(this.functionalLocationData, "functionalLocationData");
            this.functionalLocationData.BackColor = System.Drawing.SystemColors.Control;
            this.functionalLocationData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalLocationData.Name = "functionalLocationData";
            this.functionalLocationData.UseMnemonic = false;
            // 
            // nameData
            // 
            resources.ApplyResources(this.nameData, "nameData");
            this.nameData.BackColor = System.Drawing.SystemColors.Control;
            this.nameData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameData.Name = "nameData";
            this.nameData.UseMnemonic = false;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.leftPanel.Controls.Add(this.oltLabel4);
            this.leftPanel.Controls.Add(this.oltLabel2);
            this.leftPanel.Controls.Add(this.oltLabel1);
            this.leftPanel.Controls.Add(this.scheduleLabel);
            this.leftPanel.Controls.Add(this.responsesLabel);
            this.leftPanel.Controls.Add(this.nameLabel);
            this.leftPanel.Controls.Add(this.tagLabel);
            this.leftPanel.Controls.Add(this.functionLocationLabel);
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.Name = "leftPanel";
            // 
            // oltLabel4
            // 
            resources.ApplyResources(this.oltLabel4, "oltLabel4");
            this.oltLabel4.Name = "oltLabel4";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // scheduleLabel
            // 
            resources.ApplyResources(this.scheduleLabel, "scheduleLabel");
            this.scheduleLabel.Name = "scheduleLabel";
            // 
            // responsesLabel
            // 
            resources.ApplyResources(this.responsesLabel, "responsesLabel");
            this.responsesLabel.Name = "responsesLabel";
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // tagLabel
            // 
            resources.ApplyResources(this.tagLabel, "tagLabel");
            this.tagLabel.Name = "tagLabel";
            // 
            // functionLocationLabel
            // 
            resources.ApplyResources(this.functionLocationLabel, "functionLocationLabel");
            this.functionLocationLabel.Name = "functionLocationLabel";
            // 
            // saveGridLayoutButton
            // 
            this.saveGridLayoutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveGridLayoutButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.grid_16;
            resources.ApplyResources(this.saveGridLayoutButton, "saveGridLayoutButton");
            this.saveGridLayoutButton.Name = "saveGridLayoutButton";
            // 
            // LabAlertDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LabAlertDetails";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            this.timeRangeGroupBox.ResumeLayout(false);
            this.timeRangeGroupBox.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton goToDefinitionButton;
        private System.Windows.Forms.ToolStripButton respondButton;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Panel leftPanel;
        private OltLabel nameLabel;
        private OltLabel functionLocationLabel;
        private OltLabelData nameData;
        private OltLabelData functionalLocationData;
        private OltLabel tagLabel;
        private OltLabelData tagData;
        private System.Windows.Forms.ToolStripButton exportAllButton;
        private OltLabel responsesLabel;
        private System.Windows.Forms.Panel responsePanel;
        private System.Windows.Forms.ToolStripButton toggleShowButton;
        private OltLabel scheduleLabel;
        private OltGroupBox timeRangeGroupBox;
        private OltLabel oltLabel1;
        private OltLabel timeRangeToLabel;
        private OltLabel timeRangeFromLabel;
        private OltLabel minimumNumberOfSamplesLabel;
        private OltLabelData actualNumberOfSamplesLabelData;
        private OltLabelData createdDateTimeLabelData;
        private OltLabel oltLabel4;
        private OltLabel oltLabel2;
        private OltLabelData scheduleLabelData;
        private OltLabel oltLabel5;
        private OltLabel oltLabel3;
        private OltTextBox descriptionTextBox;
        private OltLabel descriptionLabel;
        private System.Windows.Forms.ToolStripButton saveGridLayoutButton;
    }
}

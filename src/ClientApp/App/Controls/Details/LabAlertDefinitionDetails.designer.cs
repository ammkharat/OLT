using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class LabAlertDefinitionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertDefinitionDetails));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.exportAllButton = new System.Windows.Forms.ToolStripButton();
            this.editHistoryButton = new System.Windows.Forms.ToolStripButton();
            this.toggleShowButton = new System.Windows.Forms.ToolStripButton();
            this.saveGridLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.scheduleLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.timeRangeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.toLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.fromLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minimumNumberOfSamplesLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.timeRangeToLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.timeRangeFromLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.createdByDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.createdByLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.functionalLocationData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.editedByDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.nameData = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.temporarilyInactiveCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.scheduleLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.editedByLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionLocationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.descriptionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
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
            this.deleteButton,
            this.editButton,
            this.exportAllButton,
            this.editHistoryButton,
            this.toggleShowButton,
            this.saveGridLayoutButton});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.Delete;
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            // 
            // editButton
            // 
            this.editButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.edit_16;
            resources.ApplyResources(this.editButton, "editButton");
            this.editButton.Name = "editButton";
            // 
            // exportAllButton
            // 
            this.exportAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportAllButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.export_all;
            resources.ApplyResources(this.exportAllButton, "exportAllButton");
            this.exportAllButton.Name = "exportAllButton";
            // 
            // editHistoryButton
            // 
            this.editHistoryButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.view_edit_history;
            resources.ApplyResources(this.editHistoryButton, "editHistoryButton");
            this.editHistoryButton.Name = "editHistoryButton";
            // 
            // toggleShowButton
            // 
            this.toggleShowButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toggleShowButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.show_date_range;
            resources.ApplyResources(this.toggleShowButton, "toggleShowButton");
            this.toggleShowButton.Name = "toggleShowButton";
            // 
            // saveGridLayoutButton
            // 
            this.saveGridLayoutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveGridLayoutButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.grid_16;
            resources.ApplyResources(this.saveGridLayoutButton, "saveGridLayoutButton");
            this.saveGridLayoutButton.Name = "saveGridLayoutButton";
            // 
            // detailsPanel
            // 
            resources.ApplyResources(this.detailsPanel, "detailsPanel");
            this.detailsPanel.BackColor = System.Drawing.Color.White;
            this.detailsPanel.Controls.Add(this.scheduleLabelData);
            this.detailsPanel.Controls.Add(this.timeRangeGroupBox);
            this.detailsPanel.Controls.Add(this.createdByDataLabel);
            this.detailsPanel.Controls.Add(this.createdByLabel);
            this.detailsPanel.Controls.Add(this.tagData);
            this.detailsPanel.Controls.Add(this.functionalLocationData);
            this.detailsPanel.Controls.Add(this.descriptionTextBox);
            this.detailsPanel.Controls.Add(this.editedByDataLabel);
            this.detailsPanel.Controls.Add(this.nameData);
            this.detailsPanel.Controls.Add(this.temporarilyInactiveCheckBox);
            this.detailsPanel.Controls.Add(this.leftPanel);
            this.detailsPanel.Name = "detailsPanel";
            // 
            // scheduleLabelData
            // 
            resources.ApplyResources(this.scheduleLabelData, "scheduleLabelData");
            this.scheduleLabelData.BackColor = System.Drawing.SystemColors.Control;
            this.scheduleLabelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheduleLabelData.Name = "scheduleLabelData";
            this.scheduleLabelData.UseMnemonic = false;
            // 
            // timeRangeGroupBox
            // 
            resources.ApplyResources(this.timeRangeGroupBox, "timeRangeGroupBox");
            this.timeRangeGroupBox.Controls.Add(this.toLabel);
            this.timeRangeGroupBox.Controls.Add(this.fromLabel);
            this.timeRangeGroupBox.Controls.Add(this.minimumNumberOfSamplesLabel);
            this.timeRangeGroupBox.Controls.Add(this.timeRangeToLabel);
            this.timeRangeGroupBox.Controls.Add(this.timeRangeFromLabel);
            this.timeRangeGroupBox.Name = "timeRangeGroupBox";
            this.timeRangeGroupBox.TabStop = false;
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // fromLabel
            // 
            resources.ApplyResources(this.fromLabel, "fromLabel");
            this.fromLabel.Name = "fromLabel";
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
            // createdByDataLabel
            // 
            this.createdByDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.createdByDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.createdByDataLabel, "createdByDataLabel");
            this.createdByDataLabel.Name = "createdByDataLabel";
            this.createdByDataLabel.UseMnemonic = false;
            // 
            // createdByLabel
            // 
            resources.ApplyResources(this.createdByLabel, "createdByLabel");
            this.createdByLabel.Name = "createdByLabel";
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
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltAcceptsReturn = true;
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.ReadOnly = true;
            // 
            // editedByDataLabel
            // 
            this.editedByDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.editedByDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.editedByDataLabel, "editedByDataLabel");
            this.editedByDataLabel.Name = "editedByDataLabel";
            this.editedByDataLabel.UseMnemonic = false;
            // 
            // nameData
            // 
            resources.ApplyResources(this.nameData, "nameData");
            this.nameData.BackColor = System.Drawing.SystemColors.Control;
            this.nameData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameData.Name = "nameData";
            this.nameData.UseMnemonic = false;
            // 
            // temporarilyInactiveCheckBox
            // 
            resources.ApplyResources(this.temporarilyInactiveCheckBox, "temporarilyInactiveCheckBox");
            this.temporarilyInactiveCheckBox.Name = "temporarilyInactiveCheckBox";
            this.temporarilyInactiveCheckBox.UseVisualStyleBackColor = true;
            this.temporarilyInactiveCheckBox.Value = null;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.leftPanel.Controls.Add(this.oltLabel1);
            this.leftPanel.Controls.Add(this.scheduleLabel);
            this.leftPanel.Controls.Add(this.editedByLabel);
            this.leftPanel.Controls.Add(this.nameLabel);
            this.leftPanel.Controls.Add(this.tagLabel);
            this.leftPanel.Controls.Add(this.functionLocationLabel);
            this.leftPanel.Controls.Add(this.descriptionLabel);
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.Name = "leftPanel";
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
            // editedByLabel
            // 
            resources.ApplyResources(this.editedByLabel, "editedByLabel");
            this.editedByLabel.Name = "editedByLabel";
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
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // LabAlertDefinitionDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LabAlertDefinitionDetails";
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
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Panel leftPanel;
        private OltLabel nameLabel;
        private OltLabel functionLocationLabel;
        private OltLabel descriptionLabel;
        private OltCheckBox temporarilyInactiveCheckBox;
        private OltLabelData nameData;
        private OltTextBox descriptionTextBox;
        private OltLabelData functionalLocationData;
        private OltLabel tagLabel;
        private OltLabelData tagData;
        private OltLabelData editedByDataLabel;
        private OltLabel editedByLabel;
        private System.Windows.Forms.ToolStripButton exportAllButton;
        private System.Windows.Forms.ToolStripButton editHistoryButton;
        private System.Windows.Forms.ToolStripButton toggleShowButton;
        private OltLabelData createdByDataLabel;
        private OltLabel createdByLabel;
        private OltLabel scheduleLabel;
        private OltGroupBox timeRangeGroupBox;
        private OltLabel oltLabel1;
        private OltLabel timeRangeToLabel;
        private OltLabel timeRangeFromLabel;
        private OltLabel minimumNumberOfSamplesLabel;
        private OltLabelData scheduleLabelData;
        private OltLabel toLabel;
        private OltLabel fromLabel;
        private System.Windows.Forms.ToolStripButton saveGridLayoutButton;
    }
}

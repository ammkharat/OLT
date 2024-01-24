using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    partial class DeviationAlertDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviationAlertDetails));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.respondButton = new System.Windows.Forms.ToolStripButton();
            this.exportAllButton = new System.Windows.Forms.ToolStripButton();
            this.goToTargetDefinitionButton = new System.Windows.Forms.ToolStripButton();
            this.responseHistoryButton = new System.Windows.Forms.ToolStripButton();
            this.toggleShowButton = new System.Windows.Forms.ToolStripButton();
            this.saveGridLayoutButton = new System.Windows.Forms.ToolStripButton();
            this.copyLastResponseButton = new System.Windows.Forms.ToolStripButton();
            this.detailsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.engineerCommentTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.responsePanel = new System.Windows.Forms.Panel();
            this.deviationValueDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.endTimeDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.startTimeDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.productionTargetValueDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.productionTargetTagNameDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.measurementValueDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.measurementTagNameDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.functionalLocationDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.restrictionNameDataLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.leftPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.engineerCommentsLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.deviationValueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.endTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startTimeLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.productionTagLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.measurementValueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.descriptionLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionalLocationLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.restrictionNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.toolStrip.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.respondButton,
            this.exportAllButton,
            this.goToTargetDefinitionButton,
            this.responseHistoryButton,
            this.toggleShowButton,
            this.saveGridLayoutButton,
            this.copyLastResponseButton});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // respondButton
            // 
            this.respondButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.replyRespond_16;
            resources.ApplyResources(this.respondButton, "respondButton");
            this.respondButton.Name = "respondButton";
            this.respondButton.Click += new System.EventHandler(this.respondButton_Click);
            // 
            // exportAllButton
            // 
            this.exportAllButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportAllButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.export_all;
            resources.ApplyResources(this.exportAllButton, "exportAllButton");
            this.exportAllButton.Name = "exportAllButton";
            // 
            // goToTargetDefinitionButton
            // 
            this.goToTargetDefinitionButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.goto_definition;
            resources.ApplyResources(this.goToTargetDefinitionButton, "goToTargetDefinitionButton");
            this.goToTargetDefinitionButton.Name = "goToTargetDefinitionButton";
            // 
            // responseHistoryButton
            // 
            this.responseHistoryButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.view_edit_history;
            resources.ApplyResources(this.responseHistoryButton, "responseHistoryButton");
            this.responseHistoryButton.Name = "responseHistoryButton";
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
            // copyLastResponseButton
            // 
            this.copyLastResponseButton.Image = global::Com.Suncor.Olt.Client.Properties.Resources.protection;
            resources.ApplyResources(this.copyLastResponseButton, "copyLastResponseButton");
            this.copyLastResponseButton.Name = "copyLastResponseButton";
            // 
            // detailsPanel
            // 
            resources.ApplyResources(this.detailsPanel, "detailsPanel");
            this.detailsPanel.BackColor = System.Drawing.Color.White;
            this.detailsPanel.Controls.Add(this.engineerCommentTextBox);
            this.detailsPanel.Controls.Add(this.responsePanel);
            this.detailsPanel.Controls.Add(this.deviationValueDataLabel);
            this.detailsPanel.Controls.Add(this.endTimeDataLabel);
            this.detailsPanel.Controls.Add(this.startTimeDataLabel);
            this.detailsPanel.Controls.Add(this.productionTargetValueDataLabel);
            this.detailsPanel.Controls.Add(this.productionTargetTagNameDataLabel);
            this.detailsPanel.Controls.Add(this.measurementValueDataLabel);
            this.detailsPanel.Controls.Add(this.measurementTagNameDataLabel);
            this.detailsPanel.Controls.Add(this.descriptionTextBox);
            this.detailsPanel.Controls.Add(this.functionalLocationDataLabel);
            this.detailsPanel.Controls.Add(this.restrictionNameDataLabel);
            this.detailsPanel.Controls.Add(this.leftPanel);
            this.detailsPanel.Name = "detailsPanel";
            // 
            // engineerCommentTextBox
            // 
            resources.ApplyResources(this.engineerCommentTextBox, "engineerCommentTextBox");
            this.engineerCommentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.engineerCommentTextBox.Name = "engineerCommentTextBox";
            this.engineerCommentTextBox.OltAcceptsReturn = true;
            this.engineerCommentTextBox.OltTrimWhitespace = true;
            this.engineerCommentTextBox.ReadOnly = true;
            // 
            // responsePanel
            // 
            resources.ApplyResources(this.responsePanel, "responsePanel");
            this.responsePanel.Name = "responsePanel";
            // 
            // deviationValueDataLabel
            // 
            resources.ApplyResources(this.deviationValueDataLabel, "deviationValueDataLabel");
            this.deviationValueDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.deviationValueDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deviationValueDataLabel.Name = "deviationValueDataLabel";
            this.deviationValueDataLabel.UseMnemonic = false;
            // 
            // endTimeDataLabel
            // 
            resources.ApplyResources(this.endTimeDataLabel, "endTimeDataLabel");
            this.endTimeDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.endTimeDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endTimeDataLabel.Name = "endTimeDataLabel";
            this.endTimeDataLabel.UseMnemonic = false;
            // 
            // startTimeDataLabel
            // 
            resources.ApplyResources(this.startTimeDataLabel, "startTimeDataLabel");
            this.startTimeDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.startTimeDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startTimeDataLabel.Name = "startTimeDataLabel";
            this.startTimeDataLabel.UseMnemonic = false;
            // 
            // productionTargetValueDataLabel
            // 
            resources.ApplyResources(this.productionTargetValueDataLabel, "productionTargetValueDataLabel");
            this.productionTargetValueDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.productionTargetValueDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productionTargetValueDataLabel.Name = "productionTargetValueDataLabel";
            this.productionTargetValueDataLabel.UseMnemonic = false;
            // 
            // productionTargetTagNameDataLabel
            // 
            resources.ApplyResources(this.productionTargetTagNameDataLabel, "productionTargetTagNameDataLabel");
            this.productionTargetTagNameDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.productionTargetTagNameDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productionTargetTagNameDataLabel.Name = "productionTargetTagNameDataLabel";
            this.productionTargetTagNameDataLabel.UseMnemonic = false;
            // 
            // measurementValueDataLabel
            // 
            resources.ApplyResources(this.measurementValueDataLabel, "measurementValueDataLabel");
            this.measurementValueDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.measurementValueDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.measurementValueDataLabel.Name = "measurementValueDataLabel";
            this.measurementValueDataLabel.UseMnemonic = false;
            // 
            // measurementTagNameDataLabel
            // 
            resources.ApplyResources(this.measurementTagNameDataLabel, "measurementTagNameDataLabel");
            this.measurementTagNameDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.measurementTagNameDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.measurementTagNameDataLabel.Name = "measurementTagNameDataLabel";
            this.measurementTagNameDataLabel.UseMnemonic = false;
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
            // functionalLocationDataLabel
            // 
            resources.ApplyResources(this.functionalLocationDataLabel, "functionalLocationDataLabel");
            this.functionalLocationDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.functionalLocationDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalLocationDataLabel.Name = "functionalLocationDataLabel";
            this.functionalLocationDataLabel.UseMnemonic = false;
            // 
            // restrictionNameDataLabel
            // 
            resources.ApplyResources(this.restrictionNameDataLabel, "restrictionNameDataLabel");
            this.restrictionNameDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.restrictionNameDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.restrictionNameDataLabel.Name = "restrictionNameDataLabel";
            this.restrictionNameDataLabel.UseMnemonic = false;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.leftPanel.Controls.Add(this.engineerCommentsLabel);
            this.leftPanel.Controls.Add(this.oltLabel1);
            this.leftPanel.Controls.Add(this.deviationValueLabel);
            this.leftPanel.Controls.Add(this.endTimeLabel);
            this.leftPanel.Controls.Add(this.startTimeLabel);
            this.leftPanel.Controls.Add(this.oltLabel2);
            this.leftPanel.Controls.Add(this.productionTagLabel);
            this.leftPanel.Controls.Add(this.measurementValueLabel);
            this.leftPanel.Controls.Add(this.tagLabel);
            this.leftPanel.Controls.Add(this.descriptionLabel);
            this.leftPanel.Controls.Add(this.functionalLocationLabel);
            this.leftPanel.Controls.Add(this.restrictionNameLabel);
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.Name = "leftPanel";
            // 
            // engineerCommentsLabel
            // 
            resources.ApplyResources(this.engineerCommentsLabel, "engineerCommentsLabel");
            this.engineerCommentsLabel.Name = "engineerCommentsLabel";
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // deviationValueLabel
            // 
            resources.ApplyResources(this.deviationValueLabel, "deviationValueLabel");
            this.deviationValueLabel.Name = "deviationValueLabel";
            // 
            // endTimeLabel
            // 
            resources.ApplyResources(this.endTimeLabel, "endTimeLabel");
            this.endTimeLabel.Name = "endTimeLabel";
            // 
            // startTimeLabel
            // 
            resources.ApplyResources(this.startTimeLabel, "startTimeLabel");
            this.startTimeLabel.Name = "startTimeLabel";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // productionTagLabel
            // 
            resources.ApplyResources(this.productionTagLabel, "productionTagLabel");
            this.productionTagLabel.Name = "productionTagLabel";
            // 
            // measurementValueLabel
            // 
            resources.ApplyResources(this.measurementValueLabel, "measurementValueLabel");
            this.measurementValueLabel.Name = "measurementValueLabel";
            // 
            // tagLabel
            // 
            resources.ApplyResources(this.tagLabel, "tagLabel");
            this.tagLabel.Name = "tagLabel";
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
            this.descriptionLabel.Name = "descriptionLabel";
            // 
            // functionalLocationLabel
            // 
            resources.ApplyResources(this.functionalLocationLabel, "functionalLocationLabel");
            this.functionalLocationLabel.Name = "functionalLocationLabel";
            // 
            // restrictionNameLabel
            // 
            resources.ApplyResources(this.restrictionNameLabel, "restrictionNameLabel");
            this.restrictionNameLabel.Name = "restrictionNameLabel";
            // 
            // DeviationAlertDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "DeviationAlertDetails";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private OltPanel detailsPanel;
        private OltPanel leftPanel;
        private OltLabel restrictionNameLabel;
        private OltLabel functionalLocationLabel;
        private OltLabel descriptionLabel;
        private OltLabelData restrictionNameDataLabel;
        private OltLabelData functionalLocationDataLabel;
        private OltTextBox descriptionTextBox;
        private OltLabel tagLabel;
        private OltLabelData measurementTagNameDataLabel;
        private System.Windows.Forms.ToolStripButton respondButton;
        private System.Windows.Forms.ToolStripButton exportAllButton;
        private System.Windows.Forms.ToolStripButton goToTargetDefinitionButton;
        private System.Windows.Forms.ToolStripButton responseHistoryButton;
        private OltLabelData productionTargetTagNameDataLabel;
        private OltLabelData measurementValueDataLabel;
        private OltLabel measurementValueLabel;
        private OltLabel productionTagLabel;
        private OltLabelData productionTargetValueDataLabel;
        private OltLabel oltLabel2;
        private OltLabelData startTimeDataLabel;
        private OltLabel startTimeLabel;
        private OltLabelData endTimeDataLabel;
        private OltLabel endTimeLabel;
        private OltLabelData deviationValueDataLabel;
        private OltLabel deviationValueLabel;
        private System.Windows.Forms.Panel responsePanel;
        private OltLabel oltLabel1;
        private OltTextBox engineerCommentTextBox;
        private OltLabel engineerCommentsLabel;
        private System.Windows.Forms.ToolStripButton toggleShowButton;
        private System.Windows.Forms.ToolStripButton saveGridLayoutButton;
        private System.Windows.Forms.ToolStripButton copyLastResponseButton;

    }
}

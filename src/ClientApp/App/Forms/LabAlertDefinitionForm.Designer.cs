using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Client.Forms
{
    partial class LabAlertDefinitionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabAlertDefinitionForm));
            this.functionalLocationTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.functionalLocationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.searchTagButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.temporarilyInactiveCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.nameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.functionalLocationButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tagInfoTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.detailsLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.nameGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.tagGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minimumNumberOfSamplesTextBox = new Com.Suncor.Olt.Client.OltControls.OltNumericUpDown();
            this.descriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.viewEditHistoryButton = new System.Windows.Forms.Button();
            this.lastModifiedDateAuthorHeader = new Com.Suncor.Olt.Client.OltControls.OltLastModifiedDateAuthorHeader();
            this.schedulingLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.schedulePicker = new Com.Suncor.Olt.Client.Controls.SimpleSchedulePicker();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.timeRangeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labAlertTagQueryDailyRangeControl = new Com.Suncor.Olt.Client.Controls.LabAlertTagQueryDailyRangeControl();
            this.labAlertTagQueryWeeklyRangeControl = new Com.Suncor.Olt.Client.Controls.LabAlertTagQueryWeeklyRangeControl();
            this.labAlertTagQueryMonthlyDayOfWeekRangeControl = new Com.Suncor.Olt.Client.Controls.LabAlertTagQueryMonthlyDayOfWeekRangeControl();
            this.labAlertTagQueryMonthlyDayOfMonthRangeControl = new Com.Suncor.Olt.Client.Controls.LabAlertTagQueryMonthlyDayOfMonthRangeControl();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.tagInfoErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.nameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.functionalLocationErrorProvider)).BeginInit();
            this.nameGroupBox.SuspendLayout();
            this.flocGroupBox.SuspendLayout();
            this.tagGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumNumberOfSamplesTextBox)).BeginInit();
            this.descriptionGroupBox.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.timeRangeFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagInfoErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // functionalLocationTextBox
            // 
            resources.ApplyResources(this.functionalLocationTextBox, "functionalLocationTextBox");
            this.functionalLocationTextBox.Name = "functionalLocationTextBox";
            this.functionalLocationTextBox.OltAcceptsReturn = true;
            this.functionalLocationTextBox.OltTrimWhitespace = true;
            this.functionalLocationTextBox.ReadOnly = true;
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltAcceptsReturn = true;
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.Tag = "h";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // functionalLocationErrorProvider
            // 
            this.functionalLocationErrorProvider.ContainerControl = this;
            // 
            // saveAndCloseButton
            // 
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // searchTagButton
            // 
            resources.ApplyResources(this.searchTagButton, "searchTagButton");
            this.searchTagButton.Name = "searchTagButton";
            this.searchTagButton.UseVisualStyleBackColor = true;
            // 
            // temporarilyInactiveCheckBox
            // 
            resources.ApplyResources(this.temporarilyInactiveCheckBox, "temporarilyInactiveCheckBox");
            this.temporarilyInactiveCheckBox.Name = "temporarilyInactiveCheckBox";
            this.temporarilyInactiveCheckBox.UseVisualStyleBackColor = true;
            this.temporarilyInactiveCheckBox.Value = null;
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.OltAcceptsReturn = true;
            this.nameTextBox.OltTrimWhitespace = true;
            // 
            // functionalLocationButton
            // 
            resources.ApplyResources(this.functionalLocationButton, "functionalLocationButton");
            this.functionalLocationButton.Name = "functionalLocationButton";
            this.functionalLocationButton.UseVisualStyleBackColor = true;
            // 
            // tagInfoTextBox
            // 
            resources.ApplyResources(this.tagInfoTextBox, "tagInfoTextBox");
            this.tagInfoTextBox.Name = "tagInfoTextBox";
            this.tagInfoTextBox.OltAcceptsReturn = true;
            this.tagInfoTextBox.OltTrimWhitespace = true;
            this.tagInfoTextBox.ReadOnly = true;
            // 
            // detailsLine
            // 
            resources.ApplyResources(this.detailsLine, "detailsLine");
            this.detailsLine.Name = "detailsLine";
            this.detailsLine.TabStop = false;
            // 
            // nameGroupBox
            // 
            resources.ApplyResources(this.nameGroupBox, "nameGroupBox");
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.TabStop = false;
            // 
            // flocGroupBox
            // 
            resources.ApplyResources(this.flocGroupBox, "flocGroupBox");
            this.flocGroupBox.Controls.Add(this.functionalLocationTextBox);
            this.flocGroupBox.Controls.Add(this.functionalLocationButton);
            this.flocGroupBox.Name = "flocGroupBox";
            this.flocGroupBox.TabStop = false;
            // 
            // tagGroupBox
            // 
            resources.ApplyResources(this.tagGroupBox, "tagGroupBox");
            this.tagGroupBox.Controls.Add(this.tagInfoTextBox);
            this.tagGroupBox.Controls.Add(this.searchTagButton);
            this.tagGroupBox.Name = "tagGroupBox";
            this.tagGroupBox.TabStop = false;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // minimumNumberOfSamplesTextBox
            // 
            resources.ApplyResources(this.minimumNumberOfSamplesTextBox, "minimumNumberOfSamplesTextBox");
            this.minimumNumberOfSamplesTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minimumNumberOfSamplesTextBox.Name = "minimumNumberOfSamplesTextBox";
            this.minimumNumberOfSamplesTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // descriptionGroupBox
            // 
            resources.ApplyResources(this.descriptionGroupBox, "descriptionGroupBox");
            this.descriptionGroupBox.Controls.Add(this.descriptionTextBox);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.TabStop = false;
            // 
            // viewEditHistoryButton
            // 
            resources.ApplyResources(this.viewEditHistoryButton, "viewEditHistoryButton");
            this.viewEditHistoryButton.Name = "viewEditHistoryButton";
            this.toolTip.SetToolTip(this.viewEditHistoryButton, resources.GetString("viewEditHistoryButton.ToolTip"));
            this.viewEditHistoryButton.UseVisualStyleBackColor = true;
            // 
            // lastModifiedDateAuthorHeader
            // 
            resources.ApplyResources(this.lastModifiedDateAuthorHeader, "lastModifiedDateAuthorHeader");
            this.lastModifiedDateAuthorHeader.LastModifiedDate = new System.DateTime(((long)(0)));
            this.lastModifiedDateAuthorHeader.Name = "lastModifiedDateAuthorHeader";
            // 
            // schedulingLine
            // 
            resources.ApplyResources(this.schedulingLine, "schedulingLine");
            this.schedulingLine.Name = "schedulingLine";
            this.schedulingLine.TabStop = false;
            // 
            // schedulePicker
            // 
            resources.ApplyResources(this.schedulePicker, "schedulePicker");
            this.schedulePicker.Name = "schedulePicker";
            // 
            // oltGroupBox1
            // 
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Controls.Add(this.oltLabel2);
            this.oltGroupBox1.Controls.Add(this.oltLabel1);
            this.oltGroupBox1.Controls.Add(this.minimumNumberOfSamplesTextBox);
            this.oltGroupBox1.Controls.Add(this.timeRangeFlowLayoutPanel);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // timeRangeFlowLayoutPanel
            // 
            this.timeRangeFlowLayoutPanel.Controls.Add(this.labAlertTagQueryDailyRangeControl);
            this.timeRangeFlowLayoutPanel.Controls.Add(this.labAlertTagQueryWeeklyRangeControl);
            this.timeRangeFlowLayoutPanel.Controls.Add(this.labAlertTagQueryMonthlyDayOfWeekRangeControl);
            this.timeRangeFlowLayoutPanel.Controls.Add(this.labAlertTagQueryMonthlyDayOfMonthRangeControl);
            resources.ApplyResources(this.timeRangeFlowLayoutPanel, "timeRangeFlowLayoutPanel");
            this.timeRangeFlowLayoutPanel.Name = "timeRangeFlowLayoutPanel";
            // 
            // labAlertTagQueryDailyRangeControl
            // 
            resources.ApplyResources(this.labAlertTagQueryDailyRangeControl, "labAlertTagQueryDailyRangeControl");
            this.labAlertTagQueryDailyRangeControl.Name = "labAlertTagQueryDailyRangeControl";
            // 
            // labAlertTagQueryWeeklyRangeControl
            // 
            resources.ApplyResources(this.labAlertTagQueryWeeklyRangeControl, "labAlertTagQueryWeeklyRangeControl");
            this.labAlertTagQueryWeeklyRangeControl.Name = "labAlertTagQueryWeeklyRangeControl";
            // 
            // labAlertTagQueryMonthlyDayOfWeekRangeControl
            // 
            resources.ApplyResources(this.labAlertTagQueryMonthlyDayOfWeekRangeControl, "labAlertTagQueryMonthlyDayOfWeekRangeControl");
            this.labAlertTagQueryMonthlyDayOfWeekRangeControl.Name = "labAlertTagQueryMonthlyDayOfWeekRangeControl";
            // 
            // labAlertTagQueryMonthlyDayOfMonthRangeControl
            // 
            resources.ApplyResources(this.labAlertTagQueryMonthlyDayOfMonthRangeControl, "labAlertTagQueryMonthlyDayOfMonthRangeControl");
            this.labAlertTagQueryMonthlyDayOfMonthRangeControl.Name = "labAlertTagQueryMonthlyDayOfMonthRangeControl";
            // 
            // oltLabelLine1
            // 
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // tagInfoErrorProvider
            // 
            this.tagInfoErrorProvider.ContainerControl = this;
            // 
            // nameErrorProvider
            // 
            this.nameErrorProvider.ContainerControl = this;
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // LabAlertDefinitionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltGroupBox1);
            this.Controls.Add(this.schedulePicker);
            this.Controls.Add(this.oltLabelLine1);
            this.Controls.Add(this.schedulingLine);
            this.Controls.Add(this.lastModifiedDateAuthorHeader);
            this.Controls.Add(this.viewEditHistoryButton);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.temporarilyInactiveCheckBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.flocGroupBox);
            this.Controls.Add(this.detailsLine);
            this.Controls.Add(this.tagGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LabAlertDefinitionForm";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.functionalLocationErrorProvider)).EndInit();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.flocGroupBox.ResumeLayout(false);
            this.flocGroupBox.PerformLayout();
            this.tagGroupBox.ResumeLayout(false);
            this.tagGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumNumberOfSamplesTextBox)).EndInit();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.timeRangeFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tagInfoErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltButton cancelButton;
        private OltTextBox descriptionTextBox;
        private OltTextBox functionalLocationTextBox;
        private ErrorProvider functionalLocationErrorProvider;
        private ErrorProvider tagInfoErrorProvider;
        private OltButton saveAndCloseButton;
        private OltButton searchTagButton;
        private OltCheckBox temporarilyInactiveCheckBox;
        private OltButton functionalLocationButton;
        private OltTextBox nameTextBox;
        private ErrorProvider nameErrorProvider;
        private OltTextBox tagInfoTextBox;
        private ErrorProvider descriptionErrorProvider;
        private OltLabelLine detailsLine;
        private OltGroupBox nameGroupBox;
        private OltGroupBox flocGroupBox;
        private OltGroupBox tagGroupBox;
        private OltGroupBox descriptionGroupBox;
        private System.Windows.Forms.ToolTip toolTip;
        private OltLastModifiedDateAuthorHeader lastModifiedDateAuthorHeader;
        private System.Windows.Forms.Button viewEditHistoryButton;
        private OltLabelLine schedulingLine;
        private Com.Suncor.Olt.Client.Controls.SimpleSchedulePicker schedulePicker;
        private OltNumericUpDown minimumNumberOfSamplesTextBox;
        private OltLabel oltLabel1;
        private OltGroupBox oltGroupBox1;
        private OltLabel oltLabel2;
        private OltLabelLine oltLabelLine1;
        private FlowLayoutPanel timeRangeFlowLayoutPanel;
        private Com.Suncor.Olt.Client.Controls.LabAlertTagQueryWeeklyRangeControl labAlertTagQueryWeeklyRangeControl;
        private Com.Suncor.Olt.Client.Controls.LabAlertTagQueryDailyRangeControl labAlertTagQueryDailyRangeControl;
        private Com.Suncor.Olt.Client.Controls.LabAlertTagQueryMonthlyDayOfWeekRangeControl labAlertTagQueryMonthlyDayOfWeekRangeControl;
        private Com.Suncor.Olt.Client.Controls.LabAlertTagQueryMonthlyDayOfMonthRangeControl labAlertTagQueryMonthlyDayOfMonthRangeControl;
    }
}

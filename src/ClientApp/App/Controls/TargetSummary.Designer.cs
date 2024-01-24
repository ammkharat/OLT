using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class TargetSummary
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetSummary));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.summaryLabelLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.thresholdValuesGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.targetValue = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.targetUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.targetLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.neverToExceedMinUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minimumUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.neverToExceedMinValue = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.minValue = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.neverToExceedMinLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.minLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.maximumUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.neverToExceedMaxUnitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.maxValue = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.neverToExceedMaxValue = new Com.Suncor.Olt.Client.OltControls.OltNumericBox();
            this.maxLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.neverToExceedMaxLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.tagNameGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.tagNameLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.categoryGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.categoryLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.functionalLocationLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.nameGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.nameLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.descriptionGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.descriptionTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.definitionAuthorGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.authorLabelData = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.thresholdValuesGroupBox.SuspendLayout();
            this.tagNameGroupBox.SuspendLayout();
            this.categoryGroupBox.SuspendLayout();
            this.functionalLocationGroupBox.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.descriptionGroupBox.SuspendLayout();
            this.definitionAuthorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // summaryLabelLine
            // 
            resources.ApplyResources(this.summaryLabelLine, "summaryLabelLine");
            this.summaryLabelLine.Name = "summaryLabelLine";
            this.summaryLabelLine.TabStop = false;
            this.toolTip.SetToolTip(this.summaryLabelLine, resources.GetString("summaryLabelLine.ToolTip"));
            // 
            // thresholdValuesGroupBox
            // 
            resources.ApplyResources(this.thresholdValuesGroupBox, "thresholdValuesGroupBox");
            this.thresholdValuesGroupBox.Controls.Add(this.targetValue);
            this.thresholdValuesGroupBox.Controls.Add(this.targetUnitLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.targetLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.neverToExceedMinUnitLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.minimumUnitLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.neverToExceedMinValue);
            this.thresholdValuesGroupBox.Controls.Add(this.minValue);
            this.thresholdValuesGroupBox.Controls.Add(this.neverToExceedMinLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.minLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.maximumUnitLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.neverToExceedMaxUnitLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.maxValue);
            this.thresholdValuesGroupBox.Controls.Add(this.neverToExceedMaxValue);
            this.thresholdValuesGroupBox.Controls.Add(this.maxLabel);
            this.thresholdValuesGroupBox.Controls.Add(this.neverToExceedMaxLabel);
            this.thresholdValuesGroupBox.Name = "thresholdValuesGroupBox";
            this.thresholdValuesGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.thresholdValuesGroupBox, resources.GetString("thresholdValuesGroupBox.ToolTip"));
            // 
            // targetValue
            // 
            resources.ApplyResources(this.targetValue, "targetValue");
            this.targetValue.Name = "targetValue";
            this.targetValue.OltAcceptsReturn = true;
            this.targetValue.OltTrimWhitespace = true;
            this.targetValue.ReadOnly = true;
            this.toolTip.SetToolTip(this.targetValue, resources.GetString("targetValue.ToolTip"));
            // 
            // targetUnitLabel
            // 
            resources.ApplyResources(this.targetUnitLabel, "targetUnitLabel");
            this.targetUnitLabel.Name = "targetUnitLabel";
            this.toolTip.SetToolTip(this.targetUnitLabel, resources.GetString("targetUnitLabel.ToolTip"));
            // 
            // targetLabel
            // 
            resources.ApplyResources(this.targetLabel, "targetLabel");
            this.targetLabel.Name = "targetLabel";
            this.toolTip.SetToolTip(this.targetLabel, resources.GetString("targetLabel.ToolTip"));
            // 
            // neverToExceedMinUnitLabel
            // 
            resources.ApplyResources(this.neverToExceedMinUnitLabel, "neverToExceedMinUnitLabel");
            this.neverToExceedMinUnitLabel.Name = "neverToExceedMinUnitLabel";
            this.toolTip.SetToolTip(this.neverToExceedMinUnitLabel, resources.GetString("neverToExceedMinUnitLabel.ToolTip"));
            // 
            // minimumUnitLabel
            // 
            resources.ApplyResources(this.minimumUnitLabel, "minimumUnitLabel");
            this.minimumUnitLabel.Name = "minimumUnitLabel";
            this.toolTip.SetToolTip(this.minimumUnitLabel, resources.GetString("minimumUnitLabel.ToolTip"));
            // 
            // neverToExceedMinValue
            // 
            resources.ApplyResources(this.neverToExceedMinValue, "neverToExceedMinValue");
            this.neverToExceedMinValue.DecimalValue = null;
            this.neverToExceedMinValue.IntegerValue = null;
            this.neverToExceedMinValue.Name = "neverToExceedMinValue";
            this.neverToExceedMinValue.NumericValue = null;
            this.neverToExceedMinValue.ReadOnly = true;
            this.toolTip.SetToolTip(this.neverToExceedMinValue, resources.GetString("neverToExceedMinValue.ToolTip"));
            // 
            // minValue
            // 
            resources.ApplyResources(this.minValue, "minValue");
            this.minValue.DecimalValue = null;
            this.minValue.IntegerValue = null;
            this.minValue.Name = "minValue";
            this.minValue.NumericValue = null;
            this.minValue.ReadOnly = true;
            this.toolTip.SetToolTip(this.minValue, resources.GetString("minValue.ToolTip"));
            // 
            // neverToExceedMinLabel
            // 
            resources.ApplyResources(this.neverToExceedMinLabel, "neverToExceedMinLabel");
            this.neverToExceedMinLabel.Name = "neverToExceedMinLabel";
            this.toolTip.SetToolTip(this.neverToExceedMinLabel, resources.GetString("neverToExceedMinLabel.ToolTip"));
            // 
            // minLabel
            // 
            resources.ApplyResources(this.minLabel, "minLabel");
            this.minLabel.Name = "minLabel";
            this.toolTip.SetToolTip(this.minLabel, resources.GetString("minLabel.ToolTip"));
            // 
            // maximumUnitLabel
            // 
            resources.ApplyResources(this.maximumUnitLabel, "maximumUnitLabel");
            this.maximumUnitLabel.Name = "maximumUnitLabel";
            this.toolTip.SetToolTip(this.maximumUnitLabel, resources.GetString("maximumUnitLabel.ToolTip"));
            // 
            // neverToExceedMaxUnitLabel
            // 
            resources.ApplyResources(this.neverToExceedMaxUnitLabel, "neverToExceedMaxUnitLabel");
            this.neverToExceedMaxUnitLabel.Name = "neverToExceedMaxUnitLabel";
            this.toolTip.SetToolTip(this.neverToExceedMaxUnitLabel, resources.GetString("neverToExceedMaxUnitLabel.ToolTip"));
            // 
            // maxValue
            // 
            resources.ApplyResources(this.maxValue, "maxValue");
            this.maxValue.DecimalValue = null;
            this.maxValue.IntegerValue = null;
            this.maxValue.Name = "maxValue";
            this.maxValue.NumericValue = null;
            this.maxValue.ReadOnly = true;
            this.toolTip.SetToolTip(this.maxValue, resources.GetString("maxValue.ToolTip"));
            // 
            // neverToExceedMaxValue
            // 
            resources.ApplyResources(this.neverToExceedMaxValue, "neverToExceedMaxValue");
            this.neverToExceedMaxValue.DecimalValue = null;
            this.neverToExceedMaxValue.IntegerValue = null;
            this.neverToExceedMaxValue.Name = "neverToExceedMaxValue";
            this.neverToExceedMaxValue.NumericValue = null;
            this.neverToExceedMaxValue.ReadOnly = true;
            this.toolTip.SetToolTip(this.neverToExceedMaxValue, resources.GetString("neverToExceedMaxValue.ToolTip"));
            // 
            // maxLabel
            // 
            resources.ApplyResources(this.maxLabel, "maxLabel");
            this.maxLabel.Name = "maxLabel";
            this.toolTip.SetToolTip(this.maxLabel, resources.GetString("maxLabel.ToolTip"));
            // 
            // neverToExceedMaxLabel
            // 
            resources.ApplyResources(this.neverToExceedMaxLabel, "neverToExceedMaxLabel");
            this.neverToExceedMaxLabel.Name = "neverToExceedMaxLabel";
            this.toolTip.SetToolTip(this.neverToExceedMaxLabel, resources.GetString("neverToExceedMaxLabel.ToolTip"));
            // 
            // tagNameGroupBox
            // 
            resources.ApplyResources(this.tagNameGroupBox, "tagNameGroupBox");
            this.tagNameGroupBox.Controls.Add(this.tagNameLabelData);
            this.tagNameGroupBox.Name = "tagNameGroupBox";
            this.tagNameGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.tagNameGroupBox, resources.GetString("tagNameGroupBox.ToolTip"));
            // 
            // tagNameLabelData
            // 
            resources.ApplyResources(this.tagNameLabelData, "tagNameLabelData");
            this.tagNameLabelData.Name = "tagNameLabelData";
            this.toolTip.SetToolTip(this.tagNameLabelData, resources.GetString("tagNameLabelData.ToolTip"));
            // 
            // categoryGroupBox
            // 
            resources.ApplyResources(this.categoryGroupBox, "categoryGroupBox");
            this.categoryGroupBox.Controls.Add(this.categoryLabelData);
            this.categoryGroupBox.Name = "categoryGroupBox";
            this.categoryGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.categoryGroupBox, resources.GetString("categoryGroupBox.ToolTip"));
            // 
            // categoryLabelData
            // 
            resources.ApplyResources(this.categoryLabelData, "categoryLabelData");
            this.categoryLabelData.Name = "categoryLabelData";
            this.toolTip.SetToolTip(this.categoryLabelData, resources.GetString("categoryLabelData.ToolTip"));
            // 
            // functionalLocationGroupBox
            // 
            resources.ApplyResources(this.functionalLocationGroupBox, "functionalLocationGroupBox");
            this.functionalLocationGroupBox.Controls.Add(this.functionalLocationLabelData);
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.functionalLocationGroupBox, resources.GetString("functionalLocationGroupBox.ToolTip"));
            // 
            // functionalLocationLabelData
            // 
            resources.ApplyResources(this.functionalLocationLabelData, "functionalLocationLabelData");
            this.functionalLocationLabelData.Name = "functionalLocationLabelData";
            this.toolTip.SetToolTip(this.functionalLocationLabelData, resources.GetString("functionalLocationLabelData.ToolTip"));
            // 
            // nameGroupBox
            // 
            resources.ApplyResources(this.nameGroupBox, "nameGroupBox");
            this.nameGroupBox.Controls.Add(this.nameLabelData);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.nameGroupBox, resources.GetString("nameGroupBox.ToolTip"));
            // 
            // nameLabelData
            // 
            resources.ApplyResources(this.nameLabelData, "nameLabelData");
            this.nameLabelData.Name = "nameLabelData";
            this.toolTip.SetToolTip(this.nameLabelData, resources.GetString("nameLabelData.ToolTip"));
            // 
            // descriptionGroupBox
            // 
            resources.ApplyResources(this.descriptionGroupBox, "descriptionGroupBox");
            this.descriptionGroupBox.Controls.Add(this.descriptionTextBox);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.descriptionGroupBox, resources.GetString("descriptionGroupBox.ToolTip"));
            // 
            // descriptionTextBox
            // 
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.OltAcceptsReturn = true;
            this.descriptionTextBox.OltTrimWhitespace = true;
            this.descriptionTextBox.ReadOnly = true;
            this.toolTip.SetToolTip(this.descriptionTextBox, resources.GetString("descriptionTextBox.ToolTip"));
            // 
            // definitionAuthorGroupBox
            // 
            resources.ApplyResources(this.definitionAuthorGroupBox, "definitionAuthorGroupBox");
            this.definitionAuthorGroupBox.Controls.Add(this.authorLabelData);
            this.definitionAuthorGroupBox.Name = "definitionAuthorGroupBox";
            this.definitionAuthorGroupBox.TabStop = false;
            this.toolTip.SetToolTip(this.definitionAuthorGroupBox, resources.GetString("definitionAuthorGroupBox.ToolTip"));
            // 
            // authorLabelData
            // 
            resources.ApplyResources(this.authorLabelData, "authorLabelData");
            this.authorLabelData.Name = "authorLabelData";
            this.toolTip.SetToolTip(this.authorLabelData, resources.GetString("authorLabelData.ToolTip"));
            // 
            // TargetSummary
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.summaryLabelLine);
            this.Controls.Add(this.thresholdValuesGroupBox);
            this.Controls.Add(this.tagNameGroupBox);
            this.Controls.Add(this.categoryGroupBox);
            this.Controls.Add(this.functionalLocationGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.definitionAuthorGroupBox);
            this.Name = "TargetSummary";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.TargetDefinitionSummary_Load);
            this.thresholdValuesGroupBox.ResumeLayout(false);
            this.thresholdValuesGroupBox.PerformLayout();
            this.tagNameGroupBox.ResumeLayout(false);
            this.tagNameGroupBox.PerformLayout();
            this.categoryGroupBox.ResumeLayout(false);
            this.categoryGroupBox.PerformLayout();
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.functionalLocationGroupBox.PerformLayout();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.definitionAuthorGroupBox.ResumeLayout(false);
            this.definitionAuthorGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OltLabelLine summaryLabelLine;
        private OltGroupBox thresholdValuesGroupBox;
        private OltGroupBox tagNameGroupBox;
        private OltLabel tagNameLabelData;
        private OltGroupBox categoryGroupBox;
        private OltLabel categoryLabelData;
        private OltGroupBox functionalLocationGroupBox;
        private OltLabel functionalLocationLabelData;
        private OltGroupBox nameGroupBox;
        private OltLabel nameLabelData;
        private OltGroupBox descriptionGroupBox;
        private OltTextBox descriptionTextBox;
        private OltGroupBox definitionAuthorGroupBox;
        private OltLabel authorLabelData;
        private System.Windows.Forms.ToolTip toolTip;
        private OltLabel neverToExceedMaxLabel;
        private OltNumericBox neverToExceedMaxValue;
        private OltLabel neverToExceedMaxUnitLabel;
        private OltLabel targetUnitLabel;
        private OltLabel targetLabel;
        private OltLabel neverToExceedMinUnitLabel;
        private OltLabel minimumUnitLabel;
        private OltNumericBox neverToExceedMinValue;
        private OltNumericBox minValue;
        private OltLabel neverToExceedMinLabel;
        private OltLabel minLabel;
        private OltLabel maximumUnitLabel;
        private OltNumericBox maxValue;
        private OltLabel maxLabel;
        private OltTextBox targetValue;

    }
}

using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class ExcursionResponseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcursionResponseForm));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ExcursionResponseEditingGridRowDTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OpmExcursionId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HistorianTag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ToeName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ToeType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StartDateTime");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Peak");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Average");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Duration");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OpmTrendUrl");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IlpNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ToeLimitValue");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Answered");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Assest");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Code");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ExcursionResponseComment");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsDirty");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ResponseLastUpdated");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OltExcursionResponseId");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.copyResponseToLogCheckBox = new System.Windows.Forms.CheckBox();
            this.copyLastResponseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.recentExcursionsLine = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.excursionToeNameLabelValue = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.currentTagValueLabelValue = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.excursionUnitValueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.excursionHistorianTagValueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel6 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.overtimeItemsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.excursionsToUpdateOltGrid = new Com.Suncor.Olt.Client.OltControls.OltGrid();
            this.excursionResponseEditingGridRowDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewTrendButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.oltLabel4 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.toeCauseOfDeviationOltTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.documentLinksGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.oltGroupBox2 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.toeConsequencesOfDeviationOltTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.oltGroupBox9 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.toeDefinitionCorrectiveActionOltTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.blindsRequiredPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.toeDefinitionOltCommentsForEngineerTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.toeEngineerCommentNo = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.toeEngineerCommentYes = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.toePublishDateValueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel7 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.toeFunctionalLocationValueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel10 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabelLine1 = new Com.Suncor.Olt.Client.OltControls.OltLabelLine();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toeDefinitionHistoryButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.saveAndCloseButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.overtimeItemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excursionsToUpdateOltGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excursionResponseEditingGridRowDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel3.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.documentLinksGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.oltGroupBox2.SuspendLayout();
            this.oltGroupBox9.SuspendLayout();
            this.blindsRequiredPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyResponseToLogCheckBox
            // 
            resources.ApplyResources(this.copyResponseToLogCheckBox, "copyResponseToLogCheckBox");
            this.copyResponseToLogCheckBox.Name = "copyResponseToLogCheckBox";
            this.copyResponseToLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyLastResponseButton
            // 
            resources.ApplyResources(this.copyLastResponseButton, "copyLastResponseButton");
            this.copyLastResponseButton.Name = "copyLastResponseButton";
            this.copyLastResponseButton.UseVisualStyleBackColor = true;
            // 
            // recentExcursionsLine
            // 
            resources.ApplyResources(this.recentExcursionsLine, "recentExcursionsLine");
            this.recentExcursionsLine.Name = "recentExcursionsLine";
            this.recentExcursionsLine.TabStop = false;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // excursionToeNameLabelValue
            // 
            resources.ApplyResources(this.excursionToeNameLabelValue, "excursionToeNameLabelValue");
            this.excursionToeNameLabelValue.Name = "excursionToeNameLabelValue";
            // 
            // currentTagValueLabelValue
            // 
            resources.ApplyResources(this.currentTagValueLabelValue, "currentTagValueLabelValue");
            this.currentTagValueLabelValue.Name = "currentTagValueLabelValue";
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // excursionUnitValueLabel
            // 
            resources.ApplyResources(this.excursionUnitValueLabel, "excursionUnitValueLabel");
            this.excursionUnitValueLabel.Name = "excursionUnitValueLabel";
            // 
            // excursionHistorianTagValueLabel
            // 
            resources.ApplyResources(this.excursionHistorianTagValueLabel, "excursionHistorianTagValueLabel");
            this.excursionHistorianTagValueLabel.Name = "excursionHistorianTagValueLabel";
            // 
            // oltLabel6
            // 
            resources.ApplyResources(this.oltLabel6, "oltLabel6");
            this.oltLabel6.Name = "oltLabel6";
            // 
            // overtimeItemsPanel
            // 
            resources.ApplyResources(this.overtimeItemsPanel, "overtimeItemsPanel");
            this.overtimeItemsPanel.Controls.Add(this.excursionsToUpdateOltGrid);
            this.overtimeItemsPanel.Controls.Add(this.copyLastResponseButton);
            this.overtimeItemsPanel.Controls.Add(this.viewTrendButton);
            this.overtimeItemsPanel.Controls.Add(this.copyResponseToLogCheckBox);
            this.overtimeItemsPanel.Name = "overtimeItemsPanel";
            // 
            // excursionsToUpdateOltGrid
            // 
            resources.ApplyResources(this.excursionsToUpdateOltGrid, "excursionsToUpdateOltGrid");
            this.excursionsToUpdateOltGrid.DataMember = null;
            this.excursionsToUpdateOltGrid.DataSource = this.excursionResponseEditingGridRowDTOBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(appearance1.FontData, "appearance1.FontData");
            resources.ApplyResources(appearance1, "appearance1");
            appearance1.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Appearance = appearance1;
            this.excursionsToUpdateOltGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 55;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 61;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.LockedWidth = true;
            ultraGridColumn6.Width = 100;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn12.Header.VisiblePosition = 6;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            resources.ApplyResources(ultraGridColumn14.Header, "ultraGridColumn14.Header");
            ultraGridColumn14.Header.VisiblePosition = 17;
            ultraGridColumn14.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn14.ForceApplyResources = "Header";
            ultraGridColumn15.Header.VisiblePosition = 18;
            ultraGridColumn15.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn16.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            ultraGridColumn16.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn16.Header.VisiblePosition = 13;
            ultraGridColumn16.MaxLength = 4000;
            ultraGridColumn16.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn17.Header.VisiblePosition = 14;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 15;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.Header.VisiblePosition = 16;
            ultraGridColumn19.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            this.excursionsToUpdateOltGrid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.excursionsToUpdateOltGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.excursionsToUpdateOltGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(appearance2.FontData, "appearance2.FontData");
            resources.ApplyResources(appearance2, "appearance2");
            appearance2.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(appearance3.FontData, "appearance3.FontData");
            resources.ApplyResources(appearance3, "appearance3");
            appearance3.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.excursionsToUpdateOltGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(appearance4.FontData, "appearance4.FontData");
            resources.ApplyResources(appearance4, "appearance4");
            appearance4.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.excursionsToUpdateOltGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.excursionsToUpdateOltGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(appearance5.FontData, "appearance5.FontData");
            resources.ApplyResources(appearance5, "appearance5");
            appearance5.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(appearance6.FontData, "appearance6.FontData");
            resources.ApplyResources(appearance6, "appearance6");
            appearance6.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(appearance7.FontData, "appearance7.FontData");
            resources.ApplyResources(appearance7, "appearance7");
            appearance7.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            resources.ApplyResources(appearance8.FontData, "appearance8.FontData");
            resources.ApplyResources(appearance8, "appearance8");
            appearance8.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.CellAppearance = appearance8;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(appearance9.FontData, "appearance9.FontData");
            resources.ApplyResources(appearance9, "appearance9");
            appearance9.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            resources.ApplyResources(appearance10, "appearance10");
            resources.ApplyResources(appearance10.FontData, "appearance10.FontData");
            appearance10.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            resources.ApplyResources(appearance11.FontData, "appearance11.FontData");
            resources.ApplyResources(appearance11, "appearance11");
            appearance11.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.RowAppearance = appearance11;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.RowSizingArea = Infragistics.Win.UltraWinGrid.RowSizingArea.RowBordersOnly;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None;
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.None;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(appearance12.FontData, "appearance12.FontData");
            resources.ApplyResources(appearance12, "appearance12");
            appearance12.ForceApplyResources = "FontData|";
            this.excursionsToUpdateOltGrid.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.excursionsToUpdateOltGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.excursionsToUpdateOltGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.excursionsToUpdateOltGrid.Name = "excursionsToUpdateOltGrid";
            this.excursionsToUpdateOltGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.excursionsToUpdateOltGrid_InitializeLayout);
            // 
            // excursionResponseEditingGridRowDTOBindingSource
            // 
            this.excursionResponseEditingGridRowDTOBindingSource.DataSource = typeof(Com.Suncor.Olt.Common.DTO.Excursions.ExcursionResponseEditingGridRowDTO);
            // 
            // viewTrendButton
            // 
            resources.ApplyResources(this.viewTrendButton, "viewTrendButton");
            this.viewTrendButton.Name = "viewTrendButton";
            this.viewTrendButton.UseVisualStyleBackColor = true;
            // 
            // oltLabel4
            // 
            resources.ApplyResources(this.oltLabel4, "oltLabel4");
            this.oltLabel4.Name = "oltLabel4";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.oltGroupBox1);
            this.panel3.Controls.Add(this.documentLinksGroupBox);
            this.panel3.Name = "panel3";
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.toeCauseOfDeviationOltTextBox);
            resources.ApplyResources(this.oltGroupBox1, "oltGroupBox1");
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.TabStop = false;
            // 
            // toeCauseOfDeviationOltTextBox
            // 
            resources.ApplyResources(this.toeCauseOfDeviationOltTextBox, "toeCauseOfDeviationOltTextBox");
            this.toeCauseOfDeviationOltTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.toeCauseOfDeviationOltTextBox.Name = "toeCauseOfDeviationOltTextBox";
            this.toeCauseOfDeviationOltTextBox.OltAcceptsReturn = true;
            this.toeCauseOfDeviationOltTextBox.OltTrimWhitespace = true;
            this.toeCauseOfDeviationOltTextBox.ReadOnly = true;
            // 
            // documentLinksGroupBox
            // 
            this.documentLinksGroupBox.Controls.Add(this.documentLinksControl);
            resources.ApplyResources(this.documentLinksGroupBox, "documentLinksGroupBox");
            this.documentLinksGroupBox.Name = "documentLinksGroupBox";
            this.documentLinksGroupBox.TabStop = false;
            // 
            // documentLinksControl
            // 
            this.documentLinksControl.BackColor = System.Drawing.SystemColors.Control;
            this.documentLinksControl.DataSource = null;
            resources.ApplyResources(this.documentLinksControl, "documentLinksControl");
            this.documentLinksControl.Name = "documentLinksControl";
            this.documentLinksControl.ReadOnlyList = false;
            this.documentLinksControl.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.oltGroupBox2);
            this.panel2.Controls.Add(this.oltGroupBox9);
            this.panel2.Name = "panel2";
            // 
            // oltGroupBox2
            // 
            this.oltGroupBox2.Controls.Add(this.toeConsequencesOfDeviationOltTextBox);
            resources.ApplyResources(this.oltGroupBox2, "oltGroupBox2");
            this.oltGroupBox2.Name = "oltGroupBox2";
            this.oltGroupBox2.TabStop = false;
            // 
            // toeConsequencesOfDeviationOltTextBox
            // 
            resources.ApplyResources(this.toeConsequencesOfDeviationOltTextBox, "toeConsequencesOfDeviationOltTextBox");
            this.toeConsequencesOfDeviationOltTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.toeConsequencesOfDeviationOltTextBox.Name = "toeConsequencesOfDeviationOltTextBox";
            this.toeConsequencesOfDeviationOltTextBox.OltAcceptsReturn = true;
            this.toeConsequencesOfDeviationOltTextBox.OltTrimWhitespace = true;
            this.toeConsequencesOfDeviationOltTextBox.ReadOnly = true;
            // 
            // oltGroupBox9
            // 
            this.oltGroupBox9.Controls.Add(this.toeDefinitionCorrectiveActionOltTextBox);
            resources.ApplyResources(this.oltGroupBox9, "oltGroupBox9");
            this.oltGroupBox9.Name = "oltGroupBox9";
            this.oltGroupBox9.TabStop = false;
            // 
            // toeDefinitionCorrectiveActionOltTextBox
            // 
            resources.ApplyResources(this.toeDefinitionCorrectiveActionOltTextBox, "toeDefinitionCorrectiveActionOltTextBox");
            this.toeDefinitionCorrectiveActionOltTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.toeDefinitionCorrectiveActionOltTextBox.Name = "toeDefinitionCorrectiveActionOltTextBox";
            this.toeDefinitionCorrectiveActionOltTextBox.OltAcceptsReturn = true;
            this.toeDefinitionCorrectiveActionOltTextBox.OltTrimWhitespace = true;
            this.toeDefinitionCorrectiveActionOltTextBox.ReadOnly = true;
            // 
            // blindsRequiredPanel
            // 
            this.blindsRequiredPanel.Controls.Add(this.toeDefinitionOltCommentsForEngineerTextBox);
            this.blindsRequiredPanel.Controls.Add(this.toeEngineerCommentNo);
            this.blindsRequiredPanel.Controls.Add(this.toeEngineerCommentYes);
            this.blindsRequiredPanel.Controls.Add(this.oltLabel2);
            resources.ApplyResources(this.blindsRequiredPanel, "blindsRequiredPanel");
            this.blindsRequiredPanel.Name = "blindsRequiredPanel";
            // 
            // toeDefinitionOltCommentsForEngineerTextBox
            // 
            resources.ApplyResources(this.toeDefinitionOltCommentsForEngineerTextBox, "toeDefinitionOltCommentsForEngineerTextBox");
            this.toeDefinitionOltCommentsForEngineerTextBox.Name = "toeDefinitionOltCommentsForEngineerTextBox";
            this.toeDefinitionOltCommentsForEngineerTextBox.OltAcceptsReturn = true;
            this.toeDefinitionOltCommentsForEngineerTextBox.OltTrimWhitespace = true;
            // 
            // toeEngineerCommentNo
            // 
            resources.ApplyResources(this.toeEngineerCommentNo, "toeEngineerCommentNo");
            this.toeEngineerCommentNo.Name = "toeEngineerCommentNo";
            this.toeEngineerCommentNo.TabStop = true;
            this.toeEngineerCommentNo.UseVisualStyleBackColor = true;
            // 
            // toeEngineerCommentYes
            // 
            resources.ApplyResources(this.toeEngineerCommentYes, "toeEngineerCommentYes");
            this.toeEngineerCommentYes.Name = "toeEngineerCommentYes";
            this.toeEngineerCommentYes.TabStop = true;
            this.toeEngineerCommentYes.UseVisualStyleBackColor = true;
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // toePublishDateValueLabel
            // 
            resources.ApplyResources(this.toePublishDateValueLabel, "toePublishDateValueLabel");
            this.toePublishDateValueLabel.Name = "toePublishDateValueLabel";
            // 
            // oltLabel7
            // 
            resources.ApplyResources(this.oltLabel7, "oltLabel7");
            this.oltLabel7.Name = "oltLabel7";
            // 
            // toeFunctionalLocationValueLabel
            // 
            resources.ApplyResources(this.toeFunctionalLocationValueLabel, "toeFunctionalLocationValueLabel");
            this.toeFunctionalLocationValueLabel.Name = "toeFunctionalLocationValueLabel";
            // 
            // oltLabel10
            // 
            resources.ApplyResources(this.oltLabel10, "oltLabel10");
            this.oltLabel10.Name = "oltLabel10";
            // 
            // oltLabelLine1
            // 
            resources.ApplyResources(this.oltLabelLine1, "oltLabelLine1");
            this.oltLabelLine1.Name = "oltLabelLine1";
            this.oltLabelLine1.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.toeDefinitionHistoryButton);
            this.panel1.Controls.Add(this.saveAndCloseButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Name = "panel1";
            // 
            // toeDefinitionHistoryButton
            // 
            resources.ApplyResources(this.toeDefinitionHistoryButton, "toeDefinitionHistoryButton");
            this.toeDefinitionHistoryButton.Name = "toeDefinitionHistoryButton";
            this.toeDefinitionHistoryButton.UseVisualStyleBackColor = true;
            // 
            // saveAndCloseButton
            // 
            resources.ApplyResources(this.saveAndCloseButton, "saveAndCloseButton");
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ExcursionResponseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.blindsRequiredPanel);
            this.Controls.Add(this.toePublishDateValueLabel);
            this.Controls.Add(this.oltLabel7);
            this.Controls.Add(this.toeFunctionalLocationValueLabel);
            this.Controls.Add(this.oltLabel10);
            this.Controls.Add(this.oltLabelLine1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.oltLabel4);
            this.Controls.Add(this.overtimeItemsPanel);
            this.Controls.Add(this.excursionUnitValueLabel);
            this.Controls.Add(this.excursionHistorianTagValueLabel);
            this.Controls.Add(this.oltLabel6);
            this.Controls.Add(this.currentTagValueLabelValue);
            this.Controls.Add(this.oltLabel3);
            this.Controls.Add(this.excursionToeNameLabelValue);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.recentExcursionsLine);
            this.MaximizeBox = false;
            this.Name = "ExcursionResponseForm";
            this.overtimeItemsPanel.ResumeLayout(false);
            this.overtimeItemsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excursionsToUpdateOltGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excursionResponseEditingGridRowDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel3.ResumeLayout(false);
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.documentLinksGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.oltGroupBox2.ResumeLayout(false);
            this.oltGroupBox2.PerformLayout();
            this.oltGroupBox9.ResumeLayout(false);
            this.oltGroupBox9.PerformLayout();
            this.blindsRequiredPanel.ResumeLayout(false);
            this.blindsRequiredPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox copyResponseToLogCheckBox;
        private OltLabelLine recentExcursionsLine;
        private OltLabel currentTagValueLabelValue;
        private OltLabel oltLabel3;
        private OltLabel excursionToeNameLabelValue;
        private OltLabel oltLabel1;
        private OltLabel excursionUnitValueLabel;
        private OltLabel excursionHistorianTagValueLabel;
        private OltLabel oltLabel6;
        private OltPanel overtimeItemsPanel;
        private OltButton copyLastResponseButton;
        private OltButton viewTrendButton;
        private OltGrid excursionsToUpdateOltGrid;
        private BindingSource excursionResponseEditingGridRowDTOBindingSource;
        private OltLabel oltLabel4;
        private ErrorProvider errorProvider;
        private Panel panel3;
        private OltGroupBox oltGroupBox1;
        private OltTextBox toeCauseOfDeviationOltTextBox;
        private OltGroupBox documentLinksGroupBox;
        private Controls.DocumentLinksControl documentLinksControl;
        private Panel panel2;
        private OltGroupBox oltGroupBox2;
        private OltTextBox toeConsequencesOfDeviationOltTextBox;
        private OltGroupBox oltGroupBox9;
        private OltTextBox toeDefinitionCorrectiveActionOltTextBox;
        private OltPanel blindsRequiredPanel;
        private OltRadioButton toeEngineerCommentNo;
        private OltRadioButton toeEngineerCommentYes;
        private OltLabel oltLabel2;
        private OltLabel toePublishDateValueLabel;
        private OltLabel oltLabel7;
        private OltLabel toeFunctionalLocationValueLabel;
        private OltLabel oltLabel10;
        private OltLabelLine oltLabelLine1;
        private Panel panel1;
        private OltButton toeDefinitionHistoryButton;
        private OltButton saveAndCloseButton;
        private OltButton cancelButton;
        private OltTextBox toeDefinitionOltCommentsForEngineerTextBox;

    }
}

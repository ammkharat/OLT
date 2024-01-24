using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class FormOvertimeForm
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OvertimeContractorDisplayAdapter", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StartDate", -1, null, 538356690, 0, 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StartTime", -1, null, 538356690, 1, 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EndDate", -1, null, 538357064, 0, 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EndTime", -1, null, 538357064, 1, 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DayShift", -1, null, 538357438, 0, 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NightShift", -1, null, 538357438, 1, 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhoneNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Radio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Contractor");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WorkOrderNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ExpectedHours");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PersonnelName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PrimaryLocation");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Start", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("End", 1);
            Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup1 = new Infragistics.Win.UltraWinGrid.UltraGridGroup("Start", 538356690);
            Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup2 = new Infragistics.Win.UltraWinGrid.UltraGridGroup("End", 538357064);
            Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup3 = new Infragistics.Win.UltraWinGrid.UltraGridGroup("Shifts", 538357438);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.mainTableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.approvalsGridControl = new Com.Suncor.Olt.Client.Controls.OvertimeApprovalsGridControl();
            this.overtimeItemsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.cloneButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.removeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.addButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.overtimeGrid = new Com.Suncor.Olt.Client.OltControls.OltGrid();
            this.overtimeFormOnPremisePersonDisplayAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.createdAndModifiedByTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.overtimePeriodGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.endOvertimeDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startOvertimeDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel6 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel7 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.createdByGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.createdByUserLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.createdDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel1 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.dateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lastModifiedGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.lastModifiedUserLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.lastModifiedDateLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel3 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.oltLabel2 = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.flocTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tradeGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.occupationComboBox = new Com.Suncor.Olt.Client.OltControls.OltEditableComboBox();
            this.documentLinksGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.documentLinksControl = new Com.Suncor.Olt.Client.Controls.DocumentLinksControl();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.saveAndEmailButton = new System.Windows.Forms.Button();
            this.historyButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainPanel.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.overtimeItemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overtimeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overtimeFormOnPremisePersonDisplayAdapterBindingSource)).BeginInit();
            this.createdAndModifiedByTableLayoutPanel.SuspendLayout();
            this.overtimePeriodGroupBox.SuspendLayout();
            this.createdByGroupBox.SuspendLayout();
            this.lastModifiedGroupBox.SuspendLayout();
            this.flocTableLayoutPanel.SuspendLayout();
            this.tradeGroupBox.SuspendLayout();
            this.documentLinksGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.mainTableLayoutPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1008, 672);
            this.mainPanel.TabIndex = 0;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTableLayoutPanel.Controls.Add(this.approvalsGridControl, 0, 3);
            this.mainTableLayoutPanel.Controls.Add(this.overtimeItemsPanel, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.createdAndModifiedByTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.flocTableLayoutPanel, 0, 1);
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 4;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(995, 650);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // approvalsGridControl
            // 
            this.approvalsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.approvalsGridControl.GroupBoxLabel = "Approvals";
            this.approvalsGridControl.Location = new System.Drawing.Point(11, 512);
            this.approvalsGridControl.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.approvalsGridControl.Name = "approvalsGridControl";
            this.approvalsGridControl.Size = new System.Drawing.Size(981, 135);
            this.approvalsGridControl.TabIndex = 5;
            // 
            // overtimeItemsPanel
            // 
            this.overtimeItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overtimeItemsPanel.Controls.Add(this.cloneButton);
            this.overtimeItemsPanel.Controls.Add(this.removeButton);
            this.overtimeItemsPanel.Controls.Add(this.addButton);
            this.overtimeItemsPanel.Controls.Add(this.overtimeGrid);
            this.overtimeItemsPanel.Location = new System.Drawing.Point(3, 212);
            this.overtimeItemsPanel.Name = "overtimeItemsPanel";
            this.overtimeItemsPanel.Size = new System.Drawing.Size(989, 294);
            this.overtimeItemsPanel.TabIndex = 3;
            // 
            // cloneButton
            // 
            this.cloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cloneButton.Location = new System.Drawing.Point(813, 264);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(75, 23);
            this.cloneButton.TabIndex = 2;
            this.cloneButton.Text = "Clone";
            this.toolTip.SetToolTip(this.cloneButton, "Create a copy of the currently selected item");
            this.cloneButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(896, 264);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(730, 264);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // overtimeGrid
            // 
            this.overtimeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overtimeGrid.DataMember = null;
            this.overtimeGrid.DataSource = this.overtimeFormOnPremisePersonDisplayAdapterBindingSource;
            this.overtimeGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.ColHeaderLines = 2;
            ultraGridColumn17.Format = "MM/dd/yyyy";
            ultraGridColumn17.Header.Caption = "Date";
            ultraGridColumn17.MaskInput = "{date}";
            ultraGridColumn17.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Disallow;
            ultraGridColumn17.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(65, 0);
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn17.RowLayoutColumnInfo.ParentGroupKey = "Start";
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(65, 27);
            ultraGridColumn17.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 20);
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            ultraGridColumn17.Width = 691;
            ultraGridColumn18.Format = "HH:mm";
            ultraGridColumn18.Header.Caption = "Time";
            ultraGridColumn18.MaskInput = "{time}";
            ultraGridColumn18.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Disallow;
            ultraGridColumn18.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.ParentGroupIndex = 0;
            ultraGridColumn18.RowLayoutColumnInfo.ParentGroupKey = "Start";
            ultraGridColumn18.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn18.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 20);
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TimeWithSpin;
            ultraGridColumn18.Width = 53;
            ultraGridColumn19.Format = "MM/dd/yyyy";
            ultraGridColumn19.Header.Caption = "Date";
            ultraGridColumn19.MaskInput = "{date}";
            ultraGridColumn19.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Disallow;
            ultraGridColumn19.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(65, 0);
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.ParentGroupIndex = 1;
            ultraGridColumn19.RowLayoutColumnInfo.ParentGroupKey = "End";
            ultraGridColumn19.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(65, 0);
            ultraGridColumn19.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 20);
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            ultraGridColumn19.Width = 58;
            ultraGridColumn20.Format = "HH:mm";
            ultraGridColumn20.Header.Caption = "Time";
            ultraGridColumn20.MaskInput = "{time}";
            ultraGridColumn20.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Disallow;
            ultraGridColumn20.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn20.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn20.RowLayoutColumnInfo.ParentGroupIndex = 1;
            ultraGridColumn20.RowLayoutColumnInfo.ParentGroupKey = "End";
            ultraGridColumn20.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn20.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 20);
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.TimeWithSpin;
            ultraGridColumn20.Width = 63;
            ultraGridColumn21.Header.Caption = "Day\r\n";
            ultraGridColumn21.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(29, 0);
            ultraGridColumn21.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn21.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn21.RowLayoutColumnInfo.ParentGroupIndex = 2;
            ultraGridColumn21.RowLayoutColumnInfo.ParentGroupKey = "Shifts";
            ultraGridColumn21.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(29, 0);
            ultraGridColumn21.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn21.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn21.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn21.Width = 26;
            ultraGridColumn22.Header.Caption = "Night\r\n";
            ultraGridColumn22.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(35, 0);
            ultraGridColumn22.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn22.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn22.RowLayoutColumnInfo.ParentGroupIndex = 2;
            ultraGridColumn22.RowLayoutColumnInfo.ParentGroupKey = "Shifts";
            ultraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(35, 0);
            ultraGridColumn22.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn22.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn22.Width = 25;
            ultraGridColumn23.Header.Caption = "Phone\r\nNumber";
            ultraGridColumn23.Header.VisiblePosition = 11;
            ultraGridColumn23.MaxLength = 25;
            ultraGridColumn23.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn23.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn23.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn23.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn23.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(80, 0);
            ultraGridColumn23.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn23.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn23.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn23.Width = 62;
            ultraGridColumn24.Header.VisiblePosition = 12;
            ultraGridColumn24.MaxLength = 15;
            ultraGridColumn24.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn24.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(35, 0);
            ultraGridColumn24.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn24.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn24.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(35, 0);
            ultraGridColumn24.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn24.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn24.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn24.Width = 30;
            ultraGridColumn25.Header.VisiblePosition = 13;
            ultraGridColumn25.MaxLength = 100;
            ultraGridColumn25.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn25.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn25.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn25.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(90, 0);
            ultraGridColumn25.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn25.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn25.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn25.Width = 79;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            ultraGridColumn26.Header.Caption = "Company";
            ultraGridColumn26.Header.VisiblePosition = 9;
            ultraGridColumn26.MaxLength = 50;
            ultraGridColumn26.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn26.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn26.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn26.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn26.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn27.Header.Caption = "WO# / \r\nPO#";
            ultraGridColumn27.Header.VisiblePosition = 14;
            ultraGridColumn27.MaxLength = 15;
            ultraGridColumn27.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn27.RowLayoutColumnInfo.OriginX = 24;
            ultraGridColumn27.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn27.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(50, 0);
            ultraGridColumn27.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn27.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn27.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn27.Width = 43;
            ultraGridColumn28.Header.Caption = "OT\r\nHrs";
            ultraGridColumn28.Header.VisiblePosition = 15;
            ultraGridColumn28.MaskInput = "{double:4.2}";
            ultraGridColumn28.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn28.RowLayoutColumnInfo.MinimumCellSize = new System.Drawing.Size(35, 0);
            ultraGridColumn28.RowLayoutColumnInfo.OriginX = 26;
            ultraGridColumn28.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn28.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(35, 0);
            ultraGridColumn28.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn28.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn28.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;
            ultraGridColumn28.Width = 35;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            ultraGridColumn29.Header.Caption = "Personnel\r\nName";
            ultraGridColumn29.Header.VisiblePosition = 6;
            ultraGridColumn29.MaxLength = 50;
            ultraGridColumn29.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn29.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn29.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn29.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(90, 0);
            ultraGridColumn29.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn29.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn29.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn29.Width = 89;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            ultraGridColumn30.Header.Caption = "Primary\r\nLocation";
            ultraGridColumn30.Header.VisiblePosition = 7;
            ultraGridColumn30.MaxLength = 20;
            ultraGridColumn30.Nullable = Infragistics.Win.UltraWinGrid.Nullable.Nothing;
            ultraGridColumn30.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn30.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn30.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(90, 0);
            ultraGridColumn30.RowLayoutColumnInfo.PreferredLabelSize = new System.Drawing.Size(0, 53);
            ultraGridColumn30.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn30.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn30.Width = 20;
            ultraGridColumn31.Header.VisiblePosition = 8;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn31.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn31.Width = 50;
            ultraGridColumn32.Format = "";
            ultraGridColumn32.Header.VisiblePosition = 10;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn32.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn32.Width = 46;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32});
            ultraGridGroup1.Key = "Start";
            ultraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1;
            ultraGridGroup1.RowLayoutGroupInfo.OriginX = 4;
            ultraGridGroup1.RowLayoutGroupInfo.OriginY = 0;
            ultraGridGroup1.RowLayoutGroupInfo.PreferredLabelSize = new System.Drawing.Size(0, 33);
            ultraGridGroup1.RowLayoutGroupInfo.SpanX = 4;
            ultraGridGroup1.RowLayoutGroupInfo.SpanY = 3;
            ultraGridGroup2.Key = "End";
            ultraGridGroup2.RowLayoutGroupInfo.LabelSpan = 1;
            ultraGridGroup2.RowLayoutGroupInfo.OriginX = 8;
            ultraGridGroup2.RowLayoutGroupInfo.OriginY = 0;
            ultraGridGroup2.RowLayoutGroupInfo.PreferredLabelSize = new System.Drawing.Size(0, 33);
            ultraGridGroup2.RowLayoutGroupInfo.SpanX = 4;
            ultraGridGroup2.RowLayoutGroupInfo.SpanY = 3;
            ultraGridGroup3.Key = "Shifts";
            ultraGridGroup3.RowLayoutGroupInfo.LabelSpan = 1;
            ultraGridGroup3.RowLayoutGroupInfo.OriginX = 12;
            ultraGridGroup3.RowLayoutGroupInfo.OriginY = 0;
            ultraGridGroup3.RowLayoutGroupInfo.PreferredLabelSize = new System.Drawing.Size(0, 33);
            ultraGridGroup3.RowLayoutGroupInfo.SpanX = 4;
            ultraGridGroup3.RowLayoutGroupInfo.SpanY = 3;
            ultraGridBand1.Groups.AddRange(new Infragistics.Win.UltraWinGrid.UltraGridGroup[] {
            ultraGridGroup1,
            ultraGridGroup2,
            ultraGridGroup3});
            ultraGridBand1.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;
            this.overtimeGrid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.overtimeGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.overtimeGrid.DisplayLayout.MaxRowScrollRegions = 1;
            this.overtimeGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.overtimeGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.overtimeGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.overtimeGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.overtimeGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.overtimeGrid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.overtimeGrid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord;
            this.overtimeGrid.DisplayLayout.Override.CellAppearance = appearance2;
            this.overtimeGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.overtimeGrid.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            this.overtimeGrid.DisplayLayout.Override.CellSpacing = 0;
            this.overtimeGrid.DisplayLayout.Override.DefaultRowHeight = 35;
            this.overtimeGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            this.overtimeGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.overtimeGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.overtimeGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.overtimeGrid.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.overtimeGrid.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.overtimeGrid.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.RowsOnly;
            this.overtimeGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical;
            this.overtimeGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.overtimeGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.overtimeGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overtimeGrid.Location = new System.Drawing.Point(0, 0);
            this.overtimeGrid.Name = "overtimeGrid";
            this.overtimeGrid.Size = new System.Drawing.Size(966, 258);
            this.overtimeGrid.TabIndex = 0;
            // 
            // overtimeFormOnPremisePersonDisplayAdapterBindingSource
            // 
            this.overtimeFormOnPremisePersonDisplayAdapterBindingSource.DataSource = typeof(Com.Suncor.Olt.Client.Domain.OvertimeContractorDisplayAdapter);
            // 
            // createdAndModifiedByTableLayoutPanel
            // 
            this.createdAndModifiedByTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createdAndModifiedByTableLayoutPanel.ColumnCount = 3;
            this.createdAndModifiedByTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.createdAndModifiedByTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.createdAndModifiedByTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.createdAndModifiedByTableLayoutPanel.Controls.Add(this.overtimePeriodGroupBox, 2, 0);
            this.createdAndModifiedByTableLayoutPanel.Controls.Add(this.createdByGroupBox, 0, 0);
            this.createdAndModifiedByTableLayoutPanel.Controls.Add(this.lastModifiedGroupBox, 1, 0);
            this.createdAndModifiedByTableLayoutPanel.Location = new System.Drawing.Point(8, 3);
            this.createdAndModifiedByTableLayoutPanel.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.createdAndModifiedByTableLayoutPanel.Name = "createdAndModifiedByTableLayoutPanel";
            this.createdAndModifiedByTableLayoutPanel.RowCount = 1;
            this.createdAndModifiedByTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.createdAndModifiedByTableLayoutPanel.Size = new System.Drawing.Size(984, 83);
            this.createdAndModifiedByTableLayoutPanel.TabIndex = 0;
            // 
            // overtimePeriodGroupBox
            // 
            this.overtimePeriodGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overtimePeriodGroupBox.Controls.Add(this.endOvertimeDateLabel);
            this.overtimePeriodGroupBox.Controls.Add(this.startOvertimeDateLabel);
            this.overtimePeriodGroupBox.Controls.Add(this.oltLabel6);
            this.overtimePeriodGroupBox.Controls.Add(this.oltLabel7);
            this.overtimePeriodGroupBox.Location = new System.Drawing.Point(651, 3);
            this.overtimePeriodGroupBox.Name = "overtimePeriodGroupBox";
            this.overtimePeriodGroupBox.Size = new System.Drawing.Size(330, 75);
            this.overtimePeriodGroupBox.TabIndex = 2;
            this.overtimePeriodGroupBox.TabStop = false;
            this.overtimePeriodGroupBox.Text = "Overall Overtime Period";
            // 
            // endOvertimeDateLabel
            // 
            this.endOvertimeDateLabel.AutoSize = true;
            this.endOvertimeDateLabel.Location = new System.Drawing.Point(46, 48);
            this.endOvertimeDateLabel.Name = "endOvertimeDateLabel";
            this.endOvertimeDateLabel.Size = new System.Drawing.Size(103, 13);
            this.endOvertimeDateLabel.TabIndex = 3;
            this.endOvertimeDateLabel.Text = "[end overtime date]";
            // 
            // startOvertimeDateLabel
            // 
            this.startOvertimeDateLabel.AutoSize = true;
            this.startOvertimeDateLabel.Location = new System.Drawing.Point(46, 23);
            this.startOvertimeDateLabel.Name = "startOvertimeDateLabel";
            this.startOvertimeDateLabel.Size = new System.Drawing.Size(108, 13);
            this.startOvertimeDateLabel.TabIndex = 1;
            this.startOvertimeDateLabel.Text = "[start overtime date]";
            // 
            // oltLabel6
            // 
            this.oltLabel6.AutoSize = true;
            this.oltLabel6.Location = new System.Drawing.Point(6, 48);
            this.oltLabel6.Name = "oltLabel6";
            this.oltLabel6.Size = new System.Drawing.Size(29, 13);
            this.oltLabel6.TabIndex = 2;
            this.oltLabel6.Text = "End:";
            // 
            // oltLabel7
            // 
            this.oltLabel7.AutoSize = true;
            this.oltLabel7.Location = new System.Drawing.Point(6, 23);
            this.oltLabel7.Name = "oltLabel7";
            this.oltLabel7.Size = new System.Drawing.Size(35, 13);
            this.oltLabel7.TabIndex = 0;
            this.oltLabel7.Text = "Start:";
            // 
            // createdByGroupBox
            // 
            this.createdByGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createdByGroupBox.Controls.Add(this.createdByUserLabel);
            this.createdByGroupBox.Controls.Add(this.createdDateLabel);
            this.createdByGroupBox.Controls.Add(this.oltLabel1);
            this.createdByGroupBox.Controls.Add(this.dateLabel);
            this.createdByGroupBox.Location = new System.Drawing.Point(3, 3);
            this.createdByGroupBox.Name = "createdByGroupBox";
            this.createdByGroupBox.Size = new System.Drawing.Size(318, 75);
            this.createdByGroupBox.TabIndex = 0;
            this.createdByGroupBox.TabStop = false;
            this.createdByGroupBox.Text = "Created By";
            // 
            // createdByUserLabel
            // 
            this.createdByUserLabel.AutoSize = true;
            this.createdByUserLabel.Location = new System.Drawing.Point(45, 48);
            this.createdByUserLabel.Name = "createdByUserLabel";
            this.createdByUserLabel.Size = new System.Drawing.Size(91, 13);
            this.createdByUserLabel.TabIndex = 3;
            this.createdByUserLabel.Text = "[created by user]";
            // 
            // createdDateLabel
            // 
            this.createdDateLabel.AutoSize = true;
            this.createdDateLabel.Location = new System.Drawing.Point(46, 23);
            this.createdDateLabel.Name = "createdDateLabel";
            this.createdDateLabel.Size = new System.Drawing.Size(77, 13);
            this.createdDateLabel.TabIndex = 1;
            this.createdDateLabel.Text = "[created date]";
            // 
            // oltLabel1
            // 
            this.oltLabel1.AutoSize = true;
            this.oltLabel1.Location = new System.Drawing.Point(6, 48);
            this.oltLabel1.Name = "oltLabel1";
            this.oltLabel1.Size = new System.Drawing.Size(33, 13);
            this.oltLabel1.TabIndex = 2;
            this.oltLabel1.Text = "User:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(6, 23);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(34, 13);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date:";
            // 
            // lastModifiedGroupBox
            // 
            this.lastModifiedGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastModifiedGroupBox.Controls.Add(this.lastModifiedUserLabel);
            this.lastModifiedGroupBox.Controls.Add(this.lastModifiedDateLabel);
            this.lastModifiedGroupBox.Controls.Add(this.oltLabel3);
            this.lastModifiedGroupBox.Controls.Add(this.oltLabel2);
            this.lastModifiedGroupBox.Location = new System.Drawing.Point(327, 3);
            this.lastModifiedGroupBox.Name = "lastModifiedGroupBox";
            this.lastModifiedGroupBox.Size = new System.Drawing.Size(318, 75);
            this.lastModifiedGroupBox.TabIndex = 1;
            this.lastModifiedGroupBox.TabStop = false;
            this.lastModifiedGroupBox.Text = "Last Modified";
            // 
            // lastModifiedUserLabel
            // 
            this.lastModifiedUserLabel.AutoSize = true;
            this.lastModifiedUserLabel.Location = new System.Drawing.Point(46, 48);
            this.lastModifiedUserLabel.Name = "lastModifiedUserLabel";
            this.lastModifiedUserLabel.Size = new System.Drawing.Size(99, 13);
            this.lastModifiedUserLabel.TabIndex = 3;
            this.lastModifiedUserLabel.Text = "[last modified user]";
            // 
            // lastModifiedDateLabel
            // 
            this.lastModifiedDateLabel.AutoSize = true;
            this.lastModifiedDateLabel.Location = new System.Drawing.Point(46, 23);
            this.lastModifiedDateLabel.Name = "lastModifiedDateLabel";
            this.lastModifiedDateLabel.Size = new System.Drawing.Size(100, 13);
            this.lastModifiedDateLabel.TabIndex = 1;
            this.lastModifiedDateLabel.Text = "[last modified date]";
            // 
            // oltLabel3
            // 
            this.oltLabel3.AutoSize = true;
            this.oltLabel3.Location = new System.Drawing.Point(6, 48);
            this.oltLabel3.Name = "oltLabel3";
            this.oltLabel3.Size = new System.Drawing.Size(33, 13);
            this.oltLabel3.TabIndex = 2;
            this.oltLabel3.Text = "User:";
            // 
            // oltLabel2
            // 
            this.oltLabel2.AutoSize = true;
            this.oltLabel2.Location = new System.Drawing.Point(6, 23);
            this.oltLabel2.Name = "oltLabel2";
            this.oltLabel2.Size = new System.Drawing.Size(34, 13);
            this.oltLabel2.TabIndex = 0;
            this.oltLabel2.Text = "Date:";
            // 
            // flocTableLayoutPanel
            // 
            this.flocTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flocTableLayoutPanel.ColumnCount = 2;
            this.flocTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.flocTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.flocTableLayoutPanel.Controls.Add(this.tradeGroupBox, 0, 0);
            this.flocTableLayoutPanel.Controls.Add(this.documentLinksGroupBox, 1, 0);
            this.flocTableLayoutPanel.Location = new System.Drawing.Point(8, 92);
            this.flocTableLayoutPanel.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.flocTableLayoutPanel.Name = "flocTableLayoutPanel";
            this.flocTableLayoutPanel.RowCount = 1;
            this.flocTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flocTableLayoutPanel.Size = new System.Drawing.Size(984, 114);
            this.flocTableLayoutPanel.TabIndex = 1;
            // 
            // tradeGroupBox
            // 
            this.tradeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tradeGroupBox.Controls.Add(this.occupationComboBox);
            this.tradeGroupBox.Location = new System.Drawing.Point(3, 3);
            this.tradeGroupBox.Name = "tradeGroupBox";
            this.tradeGroupBox.Size = new System.Drawing.Size(535, 59);
            this.tradeGroupBox.TabIndex = 0;
            this.tradeGroupBox.TabStop = false;
            this.tradeGroupBox.Text = "Trade / Occupation";
            // 
            // occupationComboBox
            // 
            this.occupationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.occupationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.occupationComboBox.DropDownWidth = 250;
            this.occupationComboBox.FormattingEnabled = true;
            this.occupationComboBox.Location = new System.Drawing.Point(9, 20);
            this.occupationComboBox.MaxDropDownItems = 16;
            this.occupationComboBox.MaxLength = 35;
            this.occupationComboBox.Name = "occupationComboBox";
            this.occupationComboBox.Size = new System.Drawing.Size(274, 21);
            this.occupationComboBox.TabIndex = 3;
            // 
            // documentLinksGroupBox
            // 
            this.documentLinksGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentLinksGroupBox.Controls.Add(this.documentLinksControl);
            this.documentLinksGroupBox.Location = new System.Drawing.Point(544, 3);
            this.documentLinksGroupBox.Name = "documentLinksGroupBox";
            this.documentLinksGroupBox.Size = new System.Drawing.Size(437, 103);
            this.documentLinksGroupBox.TabIndex = 1;
            this.documentLinksGroupBox.TabStop = false;
            this.documentLinksGroupBox.Text = "Document Links";
            // 
            // documentLinksControl
            // 
            this.documentLinksControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentLinksControl.DataSource = null;
            this.documentLinksControl.Location = new System.Drawing.Point(11, 20);
            this.documentLinksControl.Name = "documentLinksControl";
            this.documentLinksControl.ReadOnlyList = true;
            this.documentLinksControl.Size = new System.Drawing.Size(411, 74);
            this.documentLinksControl.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.saveAndEmailButton);
            this.buttonPanel.Controls.Add(this.historyButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 672);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(1008, 44);
            this.buttonPanel.TabIndex = 1;
            // 
            // saveAndEmailButton
            // 
            this.saveAndEmailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAndEmailButton.Location = new System.Drawing.Point(673, 12);
            this.saveAndEmailButton.Name = "saveAndEmailButton";
            this.saveAndEmailButton.Size = new System.Drawing.Size(99, 23);
            this.saveAndEmailButton.TabIndex = 3;
            this.saveAndEmailButton.Text = "Save && Email";
            this.saveAndEmailButton.UseVisualStyleBackColor = true;
            // 
            // historyButton
            // 
            this.historyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.historyButton.Location = new System.Drawing.Point(14, 12);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(75, 23);
            this.historyButton.TabIndex = 0;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(897, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(785, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save && Close";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormOvertimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 716);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.MinimumSize = new System.Drawing.Size(977, 722);
            this.Name = "FormOvertimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Overtime Request";
            this.mainPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.overtimeItemsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overtimeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overtimeFormOnPremisePersonDisplayAdapterBindingSource)).EndInit();
            this.createdAndModifiedByTableLayoutPanel.ResumeLayout(false);
            this.overtimePeriodGroupBox.ResumeLayout(false);
            this.overtimePeriodGroupBox.PerformLayout();
            this.createdByGroupBox.ResumeLayout(false);
            this.createdByGroupBox.PerformLayout();
            this.lastModifiedGroupBox.ResumeLayout(false);
            this.lastModifiedGroupBox.PerformLayout();
            this.flocTableLayoutPanel.ResumeLayout(false);
            this.tradeGroupBox.ResumeLayout(false);
            this.documentLinksGroupBox.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltPanel buttonPanel;
        private OltControls.OltPanel mainPanel;
        private System.Windows.Forms.TableLayoutPanel createdAndModifiedByTableLayoutPanel;
        private OltControls.OltGroupBox createdByGroupBox;
        private OltControls.OltLabel createdByUserLabel;
        private OltControls.OltLabel createdDateLabel;
        private OltControls.OltLabel oltLabel1;
        private OltControls.OltLabel dateLabel;
        private OltControls.OltGroupBox lastModifiedGroupBox;
        private OltControls.OltLabel lastModifiedUserLabel;
        private OltControls.OltLabel lastModifiedDateLabel;
        private OltControls.OltLabel oltLabel3;
        private OltControls.OltLabel oltLabel2;
        private System.Windows.Forms.TableLayoutPanel flocTableLayoutPanel;
        private OltControls.OltGroupBox tradeGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private OltControls.OltTableLayoutPanel mainTableLayoutPanel;
        private OltControls.OltButton historyButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.BindingSource overtimeFormOnPremisePersonDisplayAdapterBindingSource;
        private OltControls.OltGroupBox documentLinksGroupBox;
        private Controls.DocumentLinksControl documentLinksControl;
        private OltControls.OltPanel overtimeItemsPanel;
        private OltControls.OltButton cloneButton;
        private OltControls.OltButton removeButton;
        private OltControls.OltButton addButton;
        private OltControls.OltGrid overtimeGrid;
        private OltControls.OltGroupBox overtimePeriodGroupBox;
        private OltControls.OltLabel endOvertimeDateLabel;
        private OltControls.OltLabel startOvertimeDateLabel;
        private OltControls.OltLabel oltLabel6;
        private OltControls.OltLabel oltLabel7;
        private Controls.OvertimeApprovalsGridControl approvalsGridControl;
        private OltControls.OltEditableComboBox occupationComboBox;
        private System.Windows.Forms.Button saveAndEmailButton;       
    }
}
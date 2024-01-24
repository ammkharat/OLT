namespace Com.Suncor.Olt.Client.Forms
{
    partial class CustomFieldTrendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFieldTrendForm));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.RegressionLine regressionLine1 = new DevExpress.XtraCharts.RegressionLine();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.SplashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Com.Suncor.Olt.Client.WaitForm), true, true);
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.numericCustomFieldEntryDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.fixedRangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.refreshButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.customRangeRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.fixedRangeComboBox = new Com.Suncor.Olt.Client.OltControls.OltComboBox();
            this.endRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.fixedRangeTextLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.toLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.startRangeDatePicker = new Com.Suncor.Olt.Client.OltControls.OltDatePicker();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.printButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.closeButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(regressionLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCustomFieldEntryDTOBindingSource)).BeginInit();
            this.dateSelectGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControl
            // 
            resources.ApplyResources(this.chartControl, "chartControl");
            this.chartControl.DataSource = this.numericCustomFieldEntryDTOBindingSource;
            xyDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Minute;
            xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Minute;
            xyDiagram1.AxisX.GridLines.Color = System.Drawing.Color.LightGray;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Label.DateTimeOptions.AutoFormat = ((bool)(resources.GetObject("resource.AutoFormat")));
            xyDiagram1.AxisX.Label.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.Custom;
            xyDiagram1.AxisX.Label.DateTimeOptions.FormatString = resources.GetString("resource.FormatString");
            xyDiagram1.AxisX.Title.Text = resources.GetString("resource.Text");
            xyDiagram1.AxisX.Title.Visible = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = true;
            xyDiagram1.AxisY.Title.Text = resources.GetString("resource.Text1");
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = true;
            xyDiagram1.DefaultPane.SizeInPixels = 403;
            xyDiagram1.DefaultPane.SizeMode = DevExpress.XtraCharts.PaneSizeMode.UseSizeInPixels;
            this.chartControl.Diagram = xyDiagram1;
            this.chartControl.EmptyChartText.Text = resources.GetString("chartControl.EmptyChartText.Text");
            this.chartControl.EmptyChartText.TextColor = System.Drawing.Color.Red;
            this.chartControl.Name = "chartControl";
            this.chartControl.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch;
            series1.ArgumentDataMember = "DateTime";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.CrosshairLabelPattern = "{A:yyyy-MM-dd HH:mm} : {V}";
            pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            series1.LegendPointOptions = pointOptions1;
            resources.ApplyResources(series1, "series1");
            series1.SynchronizePointOptions = false;
            series1.ToolTipHintDataMember = "DateTime";
            series1.ValueDataMembersSerializable = "NumericValue";
            resources.ApplyResources(regressionLine1, "regressionLine1");
            regressionLine1.ShowInLegend = true;
            lineSeriesView1.Indicators.AddRange(new DevExpress.XtraCharts.Indicator[] {
            regressionLine1});
            lineSeriesView1.LineMarkerOptions.Size = 5;
            series1.View = lineSeriesView1;
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl.SeriesTemplate.View = lineSeriesView2;
            chartTitle1.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            resources.ApplyResources(chartTitle1, "chartTitle1");
            this.chartControl.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // numericCustomFieldEntryDTOBindingSource
            // 
            this.numericCustomFieldEntryDTOBindingSource.DataSource = typeof(Com.Suncor.Olt.Common.DTO.NumericCustomFieldEntryDTO);
            // 
            // dateSelectGroupBox
            // 
            resources.ApplyResources(this.dateSelectGroupBox, "dateSelectGroupBox");
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeRadioButton);
            this.dateSelectGroupBox.Controls.Add(this.refreshButton);
            this.dateSelectGroupBox.Controls.Add(this.customRangeRadioButton);
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeComboBox);
            this.dateSelectGroupBox.Controls.Add(this.endRangeDatePicker);
            this.dateSelectGroupBox.Controls.Add(this.fixedRangeTextLabel);
            this.dateSelectGroupBox.Controls.Add(this.toLabel);
            this.dateSelectGroupBox.Controls.Add(this.startRangeDatePicker);
            this.dateSelectGroupBox.Name = "dateSelectGroupBox";
            this.dateSelectGroupBox.TabStop = false;
            // 
            // fixedRangeRadioButton
            // 
            resources.ApplyResources(this.fixedRangeRadioButton, "fixedRangeRadioButton");
            this.fixedRangeRadioButton.Name = "fixedRangeRadioButton";
            this.fixedRangeRadioButton.TabStop = true;
            this.fixedRangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // customRangeRadioButton
            // 
            resources.ApplyResources(this.customRangeRadioButton, "customRangeRadioButton");
            this.customRangeRadioButton.Name = "customRangeRadioButton";
            this.customRangeRadioButton.TabStop = true;
            this.customRangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // fixedRangeComboBox
            // 
            resources.ApplyResources(this.fixedRangeComboBox, "fixedRangeComboBox");
            this.fixedRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fixedRangeComboBox.FormattingEnabled = true;
            this.fixedRangeComboBox.Name = "fixedRangeComboBox";
            // 
            // endRangeDatePicker
            // 
            resources.ApplyResources(this.endRangeDatePicker, "endRangeDatePicker");
            this.endRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.endRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.endRangeDatePicker.Name = "endRangeDatePicker";
            this.endRangeDatePicker.PickerEnabled = true;
            // 
            // fixedRangeTextLabel
            // 
            resources.ApplyResources(this.fixedRangeTextLabel, "fixedRangeTextLabel");
            this.fixedRangeTextLabel.Name = "fixedRangeTextLabel";
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // startRangeDatePicker
            // 
            resources.ApplyResources(this.startRangeDatePicker, "startRangeDatePicker");
            this.startRangeDatePicker.CustomFormat = "ddd MM/dd/yyyy";
            this.startRangeDatePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.startRangeDatePicker.Name = "startRangeDatePicker";
            this.startRangeDatePicker.PickerEnabled = true;
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.printButton);
            this.panelControl1.Controls.Add(this.dateSelectGroupBox);
            this.panelControl1.Controls.Add(this.closeButton);
            this.panelControl1.Name = "panelControl1";
            // 
            // printButton
            // 
            resources.ApplyResources(this.printButton, "printButton");
            this.printButton.Name = "printButton";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // panelControl2
            // 
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Controls.Add(this.chartControl);
            this.panelControl2.Name = "panelControl2";
            // 
            // CustomFieldTrendForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "CustomFieldTrendForm";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(regressionLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCustomFieldEntryDTOBindingSource)).EndInit();
            this.dateSelectGroupBox.ResumeLayout(false);
            this.dateSelectGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource numericCustomFieldEntryDTOBindingSource;
        private DevExpress.XtraCharts.ChartControl chartControl;
        private System.Windows.Forms.GroupBox dateSelectGroupBox;
        private OltControls.OltRadioButton fixedRangeRadioButton;
        private OltControls.OltRadioButton customRangeRadioButton;
        private OltControls.OltComboBox fixedRangeComboBox;
        private OltControls.OltDatePicker endRangeDatePicker;
        private OltControls.OltLabel fixedRangeTextLabel;
        private OltControls.OltLabel toLabel;
        private OltControls.OltDatePicker startRangeDatePicker;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private OltControls.OltButton refreshButton;
        private OltControls.OltButton closeButton;
        private OltControls.OltButton printButton;
        private DevExpress.XtraSplashScreen.SplashScreenManager SplashScreenManager;
    }
}
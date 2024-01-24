using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraPrinting;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CustomFieldTrendForm : BaseForm
    {
        public event Action RefreshButtonClicked;
        private ChartPrinter cp;
        private readonly PrintingSystem printingSystem;

        public CustomFieldTrendForm()
        {
            InitializeComponent();
            printingSystem = new PrintingSystem();
        }

        public CustomFieldTrendForm(string customFieldName) : this()
        {
            chartControl.Series[0].LegendText = customFieldName;

            fixedRangeRadioButton.CheckedChanged += HandleFixedRangeSelected;
            customRangeRadioButton.CheckedChanged += HandleCustomRangeSelected;

            refreshButton.Click += RefreshButtonClick;
            closeButton.Click += CloseButtonClick;
            printButton.Click += PrintButtonClick;
        }

        public string FormTitle
        {
            set { Text = value; }
        }

        
        private void PrintButtonClick(object sender, EventArgs e)
        {
            Link link = new Link(printingSystem) { Landscape = true };
            link.CreateDetailArea += CreateDetailArea;

            cp = new ChartPrinter(chartControl) { SizeMode = PrintSizeMode.Stretch };
            cp.Initialize(link.PrintingSystem, link);

            link.ShowPreviewDialog();
            cp.Release();
        }

        private void CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            cp.CreateDetail(e.Graph);
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void HandleFixedRangeSelected(object sender, EventArgs e)
        {
            fixedRangeComboBox.Enabled = true;
            startRangeDatePicker.Enabled = false;
            endRangeDatePicker.Enabled = false;
        }

        private void HandleCustomRangeSelected(object sender, EventArgs e)
        {
            fixedRangeComboBox.Enabled = false;
            startRangeDatePicker.Enabled = true;
            endRangeDatePicker.Enabled = true;
        }

        void RefreshButtonClick(object sender, EventArgs e)
        {
            if (RefreshButtonClicked != null)
            {
                RefreshButtonClicked();
            }
        }

        public bool FixedRangeChecked
        {
            get { return fixedRangeRadioButton.Checked; }            
            set
            {
                fixedRangeRadioButton.Checked = value;
            }            
        }

        public bool CustomRangeChecked
        {
            get { return customRangeRadioButton.Checked; }
        }

        public void AddFixedRangeDuration(Duration duration)
        {
            fixedRangeComboBox.Items.Add(duration);
        }

        public Duration SelectedFixedRangeDuration
        {
            get { return (Duration)fixedRangeComboBox.SelectedItem; }
            set { fixedRangeComboBox.SelectedItem = value; }
        }

        public Date StartDate
        {
            get { return startRangeDatePicker.Value; }
            set { startRangeDatePicker.Value = value; }
        }

        public Date EndDate
        {
            get { return endRangeDatePicker.Value; }
            set { endRangeDatePicker.Value = value; }
        }


        public void ShowWait()
        {
            SplashScreenManager.ShowWaitForm();
        }

        public void CloseWait()
        {
            SplashScreenManager.CloseWaitForm();    
            SplashScreenManager.WaitForSplashFormClose();
        }


        public void UpdateChart(List<NumericCustomFieldEntryDTO> numericCustomFieldEntryDtos, DateRange dateRange)
        {
            var seriesCrosshairLabelPattern = StringResources.ChartControlSeriesCrosshairLabelPattern;
            var axisXDateTimeFormatString = StringResources.ChartControlAxisXDateTimeFormatString;

            chartControl.DataSource = numericCustomFieldEntryDtos;
            chartControl.EmptyChartText.Visible = numericCustomFieldEntryDtos.Count == 0;

            chartControl.Series[0].Visible = numericCustomFieldEntryDtos.Count != 0;
            chartControl.Series[0].CrosshairLabelPattern = seriesCrosshairLabelPattern;
            
            XYDiagram xyDiagram = chartControl.Diagram as XYDiagram;
            if (xyDiagram != null && dateRange != null)
            {
                var axisRange = xyDiagram.AxisX.Range;
                axisRange.Auto = false;
                axisRange.SetMinMaxValues(dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd);

                // Setting default values is required since upgrade to v13.2
                xyDiagram.DefaultPane.BackColor = Color.White;
                xyDiagram.AxisX.NumericScaleOptions.AutoGrid = true;
                xyDiagram.AxisX.DateTimeScaleOptions.AutoGrid = true;
                xyDiagram.AxisX.Label.Angle = 0;
                xyDiagram.AxisX.Label.DateTimeOptions.FormatString = axisXDateTimeFormatString;
            }
            
            chartControl.RefreshData();
            
        }
    }
}
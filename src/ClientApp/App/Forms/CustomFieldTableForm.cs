using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CustomFieldTableForm : BaseForm, ICustomFieldTableView
    {
        public event Action CloseButtonClick;
        public event Action ViewLoad;
        public event Action ViewShown;
        public event Action RefreshClick;
        public event Action ExportClick;

        private readonly SummaryGrid<NonnumericCustomFieldEntryDTO> grid;

        public string Title
        {
            set { Text = value; }
        }

        public CustomFieldTableForm()
        {
            InitializeComponent();

            closeButton.Click += HandleCloseButtonClick;
            fixedRangeRadioButton.CheckedChanged += HandleFixedRangeSelected;
            customRangeRadioButton.CheckedChanged += HandleCustomRangeSelected;
            refreshButton.Click += HandleRefreshButtonClick;
            exportButton.Click += HandleExportButtonClick;

            grid = new SummaryGrid<NonnumericCustomFieldEntryDTO>(new NonnumericCustomFieldEntryGridRenderer(), OltGridAppearance.SINGLE_SELECT);
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);
        }

        private void HandleExportButtonClick(object sender, EventArgs e)
        {
            if (ExportClick != null)
            {
                ExportClick();
            }
        }

        private void HandleRefreshButtonClick(object sender, EventArgs e)
        {
            if (RefreshClick != null)
            {
                RefreshClick();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (ViewLoad != null)
            {
                ViewLoad();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (ViewShown != null)
            {
                ViewShown();
            }
        }

        private void HandleCloseButtonClick(object sender, EventArgs eventArgs)
        {
            if (CloseButtonClick != null)
            {
                CloseButtonClick();
            }
        }

        public bool FixedRangeChecked
        {
            get { return fixedRangeRadioButton.Checked; }
            set { fixedRangeRadioButton.Checked = value; }
        }

        public bool CustomRangeChecked
        {
            get { return customRangeRadioButton.Checked; }
        }

        public List<NonnumericCustomFieldEntryDTO> CustomFieldEntries
        {
            set { grid.Items = value; }
        }

        public void AddFixedRangeDuration(Duration duration)
        {
            fixedRangeComboBox.Items.Add(duration);
        }

        public void ExportToExcel()
        {
            new OltExcelExporter().Export(grid);
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

        public string DisclaimerLabel
        {
            set { disclaimerLabel.Text = value; }
        }
    }
}

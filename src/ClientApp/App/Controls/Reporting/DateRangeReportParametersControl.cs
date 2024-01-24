using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters.Reporting;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class DateRangeReportParametersControl : UserControl, IDateRangeReportParametersControl
    {
        private readonly DateRangeReportParametersControlValidator validator;

        public DateRangeReportParametersControl()
        {
            InitializeComponent();

            validator = new DateRangeReportParametersControlValidator(this);
        }

        public bool IsValid { get { return validator.IsValid; } }

        public string ErrorMessage { get { return validator.ErrorMessage; } }

        public Date SelectedStartDate { get { return startDatePicker.Value; } set { startDatePicker.Value = value; } }

        public Date SelectedEndDate { get { return endDatePicker.Value; } set { endDatePicker.Value = value; } }
    }
}
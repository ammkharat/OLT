using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class DailyShiftTargetAlertReportParametersControl : UserControl, IDailyShiftTargetAlertReportParametersControl
    {
        private string errorMessage;

        public DailyShiftTargetAlertReportParametersControl()
        {
            InitializeComponent();
        }

        public List<ShiftPattern> AvailableShiftPatterns
        {
            set
            {
                shiftPatternListBox.DisplayMember = "Name";
                shiftPatternListBox.DataSource = value;
            }
        }

        public Date SelectedDate
        {
            get { return selectedDateDatePicker.Value; }
        }

        public List<ShiftPattern> SelectedShiftPatterns
        {
            get
            {
                ArrayList list = new ArrayList(shiftPatternListBox.SelectedItems);
                return new List<ShiftPattern>((ShiftPattern[])list.ToArray(typeof(ShiftPattern)));
            }
        }

        public bool IsValid
        {
            get
            {
                if (SelectedShiftPatterns.Count == 0)
                {
                    errorMessage = StringResources.ShiftSelectionControl_PleaseSelectAtLeastOneShift;
                    return false;
                }
                return true;
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }
}

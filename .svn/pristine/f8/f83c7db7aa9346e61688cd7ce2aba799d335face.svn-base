using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class DailyShiftTargetAlertGapReasonReportParametersControl : UserControl, IDailyShiftTargetAlertGapReasonReportParametersControl
    {
        private List<ShiftPattern> availableShiftPatterns;
        private string errorMessage;
        
        public DailyShiftTargetAlertGapReasonReportParametersControl()
        {
            InitializeComponent();
        }

        public List<ShiftPattern> AvailableShiftPatterns
        {
            get { return availableShiftPatterns; }
            set
            {
                availableShiftPatterns = value;
                shiftPatternListBox.DataSource = availableShiftPatterns;
                shiftPatternListBox.DisplayMember = "Name";
            }
        }

        public List<ShiftPattern> SelectedShiftPatterns
        {
            get
            {
                ArrayList untypedList = new ArrayList(shiftPatternListBox.SelectedItems);
                return new List<ShiftPattern>((ShiftPattern[])untypedList.ToArray(typeof(ShiftPattern)));
            }
            set
            {
                foreach(ShiftPattern currentPattern in value)
                {
                    shiftPatternListBox.SelectedItems.Add(currentPattern);    
                }                
            }
        }

        public Date SelectedStartDate
        {
            get { return startDatePicker.Value; }
            set { startDatePicker.Value = value; }
        }

        public Date SelectedEndDate
        {
            get { return endDatePicker.Value; }
            set { endDatePicker.Value = value; }
        }

        public bool IsValid
        {
            get
            {
                if (SelectedShiftPatterns.Count == 0)
                {
                    errorMessage = StringResources.ShiftGapReasonReportNoShiftSelectedError;
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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class DailyShiftLogReportParametersControl : UserControl, IDailyShiftLogReportParametersControl
    {
        public DailyShiftLogReportParametersControl()
        {
            InitializeComponent();
            includeProcessDataCheckBox.Checked = false;
            tagGroupListComboBox.Enabled = false;
            includeProcessDataCheckBox.CheckedChanged += includeProcessDataCheckBox_CheckedChanged;
        }

        public List<ShiftPattern> AvailableShiftPatterns
        {
            set { shiftSelectionControl.AvailableShiftPatterns = value; }
        }

        public List<TagInfoGroup> AvailableTagInfoGroups
        {
            set
            {
                tagGroupListComboBox.DisplayMember = "Name";
                tagGroupListComboBox.DataSource = value;
            }
        }

        public TagInfoGroup SelectedTagInfoGroup
        {
            get
            {
                if(includeProcessDataCheckBox.Checked)
                {
                    return tagGroupListComboBox.SelectedItem as TagInfoGroup;
                }
                return null;
            }
        }

        public Date SelectedDate
        {
            get { return shiftSelectionControl.SelectedDate; }
        }

        public List<ShiftPattern> SelectedShiftPatterns
        {
            get { return shiftSelectionControl.SelectedShiftPatterns; }
        }

        public bool IsValid
        {
            get { return shiftSelectionControl.IsValid; }
        }

        public string ErrorMessage
        {
            get { return shiftSelectionControl.ErrorMessage; }
        }

        private void includeProcessDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            tagGroupListComboBox.Enabled = includeProcessDataCheckBox.Checked;
        }
    }
}
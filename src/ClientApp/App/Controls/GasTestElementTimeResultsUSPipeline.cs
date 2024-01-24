using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementTimeResultsUSPipeline : UserControl
    {
        public GasTestElementTimeResultsUSPipeline()
        {
            InitializeComponent();
        }

        public Time ImmediateAreaTime
        {
            get { return immediateAreaTimePicker.Value; }
            set { immediateAreaTimePicker.Value = value; }
        }

        public bool ImmediateAreaTimePickerEnabled
        {
            get { return immediateAreaTimePicker.Enabled; }
            set { immediateAreaTimePicker.Enabled = value; }
        }
        
        public bool ImmediateAreaTimePickerChecked
        {
            get { return immediateAreaTimePicker.Checked; }
            set { immediateAreaTimePicker.Checked = value; }
        }
        
        public Time ConfinedSpaceTime
        {
            get { return confinedSpaceTimePicker.Value; }
            set { confinedSpaceTimePicker.Value = value; }
        }

        public bool ConfinedSpaceTimePickerEnabled
        {
            get { return confinedSpaceTimePicker.Enabled; }
            set { confinedSpaceTimePicker.Enabled = value; }
        }
        
        public bool ConfinedSpaceTimePickerChecked
        {
            get { return confinedSpaceTimePicker.Checked; }
            set { confinedSpaceTimePicker.Checked = value; }
        }

        public Time SystemEntryTime
        {
            get { return systemEntryTimePicker.Value; }
            set { systemEntryTimePicker.Value = value; }
        }

        public bool SystemEntryTimePickerEnabled
        {
            get { return systemEntryTimePicker.Enabled; }
            set { systemEntryTimePicker.Enabled = value; }
        }

        public bool SystemEntryTimePickerChecked
        {
            get { return systemEntryTimePicker.Checked; }
            set { systemEntryTimePicker.Checked = value; }
        }


    }
}
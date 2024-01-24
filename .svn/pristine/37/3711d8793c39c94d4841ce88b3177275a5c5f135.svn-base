using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementTimeResultsMuds : UserControl
    {
        public GasTestElementTimeResultsMuds()
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


        //new

        public Time ThirdTime
        {
            get { return ThirdTimePicker.Value; }
            set { ThirdTimePicker.Value = value; }
        }

        public bool ThirdTimePickerEnabled
        {
            get { return ThirdTimePicker.Enabled; }
            set { ThirdTimePicker.Enabled = value; }
        }

        public bool ThirdTimePickerChecked
        {
            get { return ThirdTimePicker.Checked; }
            set { ThirdTimePicker.Checked = value; }
        }

        public Time FourthTime
        {
            get { return FourthTimePicker.Value; }
            set { FourthTimePicker.Value = value; }
        }

        public bool FourthTimePickerEnabled
        {
            get { return FourthTimePicker.Enabled; }
            set { FourthTimePicker.Enabled = value; }
        }

        public bool FourthTimePickerChecked
        {
            get { return FourthTimePicker.Checked; }
            set { FourthTimePicker.Checked = value; }
        }
         public bool showonlyFirstColum
        {
            set {
                confinedSpaceTestTimeLabel.Visible = !value;
                confinedSpaceTimePicker.Visible = !value;
                ThirdTimeLable.Visible = !value;
                ThirdTimePicker.Visible = !value;
                FourthTimeLable.Visible = !value;
                FourthTimePicker.Visible = !value;
            
            }
            

        }

         public bool DisableFirstReading
         {
             set { immediateAreaTimePicker.Visible = !value; immediateAreaTimeLabel.Text += immediateAreaTimePicker.Value; }
         }

       
    }
}

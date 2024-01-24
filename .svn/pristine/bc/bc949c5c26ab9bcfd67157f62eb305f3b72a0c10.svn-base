using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class TargetValueControl : UserControl
    {
        public TargetValueControl()
        {
            InitializeComponent();
        }
        
        public bool MinimizeTarget
        {
            get { return minimizeRadioButton.Checked; }   
        }

        public void SetTargetToMinimize()
        {
            minimizeRadioButton.Checked = true;
        }

        public bool MaximizeTarget
        {
            get { return maximizeRadioButton.Checked; }   
        }

        public void SetTargetToMaximize()
        {
            maximizeRadioButton.Checked = true;
        }

        public decimal? TargetValue
        {
            get
            {
                return targetValueNumericBox.DecimalValueOrNull;
            }
            set
            {
                targetValueNumericBox.Value = value == null ? (object) null : (double) value.Value;
            }
        }

        private void HandleTypeChange(object sender, EventArgs e)
        {
            if (MinimizeTarget || MaximizeTarget)
            {
                TargetValue = null;  // Clear the number.
                targetValueNumericBox.Enabled = false;
            }
            else
            {
                targetValueNumericBox.Enabled = true;
            }
        }
    }
}

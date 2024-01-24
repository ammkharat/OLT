using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ValueFrequencyBox : UserControl
    {
        public ValueFrequencyBox()
        {
            InitializeComponent();
            frequencyNumericUpDown.Enabled = false;
            valueNumericBox.ValueChanged += OnNumericTextChanged;
        }

        public string UnitLabelText
        {
            get { return unitLabel.Text; }
            set { unitLabel.Text = value; }
        }
        public string ValueLabelText
        {
            get { return valueLabel.Text; }
            set { valueLabel.Text = value; }
        }

        public string FrequencyLabelText
        {
            get { return frequencyLabel.Text; }
            set { frequencyLabel.Text = value; }
        }

        public decimal? Value
        {
            get
            {
                return valueNumericBox.DecimalValueOrNull;
            }
            set
            {
                valueNumericBox.Value = value == null ? (object) null : (double) value.Value;
            }
        }
       
        public int Frequency
        {
            get { return Convert.ToInt32(frequencyNumericUpDown.Value); }
            set { frequencyNumericUpDown.Value = value; }
        }

        public bool ValueEnabled
        {
            set { valueNumericBox.Enabled = value; }
        }

        private void OnNumericTextChanged(object sender, EventArgs e)
        {
            frequencyNumericUpDown.Enabled = Value != null;
        }
    }
}

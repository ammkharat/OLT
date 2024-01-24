using System.ComponentModel;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class StringValueWithUnitTextBox : UserControl
    {
        private const string LABEL_POSTFIX = ":";

        public StringValueWithUnitTextBox()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public string Label
        {
            get { return RemovePostfix(LABEL_POSTFIX); }
            set { label.Text = AddPostfix(value, LABEL_POSTFIX); }
        }

        [Browsable(true)]
        public string TextValue
        {
            get { return valueTextBox.Text; }
            set { valueTextBox.Text = value; }
        }

        [Browsable(true)]
        public string Units
        {
            get { return unitLabel.Text; }
            set { unitLabel.Text = value; }
        }

        private string AddPostfix(string value, string postfix)
        {
            return value + postfix;
        }

        private string RemovePostfix(string postfix)
        {
            return label.Text.Substring(0, label.Text.Length - postfix.Length);
        }
    }
}

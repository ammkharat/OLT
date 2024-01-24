using System.ComponentModel;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltLabelLine : UserControl
    {
        public OltLabelLine()
        {
            InitializeComponent();
            TabStop = false;
        }

        [Localizable(true)]
        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
    }
}
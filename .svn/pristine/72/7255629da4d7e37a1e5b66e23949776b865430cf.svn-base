using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class CustomFieldPhTagLegendControl : UserControl
    {
        public CustomFieldPhTagLegendControl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        [Localizable(true)]
        public string ReadText
        {
            get { return readLabel.Text; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Color ReadColour
        {
            get { return readColourPanel.BackColor; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        [Localizable(true)]
        public string WriteText
        {
            get { return writeLabel.Text; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Color WriteColour
        {
            get { return writeColourPanel.BackColor; }
        }

    }
}

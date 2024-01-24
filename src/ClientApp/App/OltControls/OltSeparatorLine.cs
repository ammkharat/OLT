using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltSeparatorLine : UserControl
    {
        private Color penColor = Color.DarkGray;
        private float penWidth = 1;

        public OltSeparatorLine()
        {
            DashedLine = false;
            InitializeComponent();
        }

        [Browsable(true)]
        public Color LineColor
        {
            get { return penColor; }
            set { penColor = value; }
        }

        [Browsable(true)]
        public float LineWidth
        {
            get { return penWidth; }
            set { penWidth = value; }
        }

        [Browsable(true)]
        public bool DashedLine { get; set; }

        private void OltSeparatorLine_Paint(object sender, PaintEventArgs e)
        {
            var dashStyle = DashedLine ? DashStyle.Dash : DashStyle.Solid;

            var blackPen = new Pen(LineColor, LineWidth) {DashStyle = dashStyle};
            e.Graphics.DrawLine(blackPen, new Point(1, Height-2), new Point(Width-1, Height-2));
        }
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Olt specific NumericUpDown
    /// </summary>
    public class OltNumericUpDown : NumericUpDown
    {
        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }
    }
}
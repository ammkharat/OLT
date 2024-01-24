using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Olt specific Label
    /// </summary>
    public class OltLabelData : Label
    {
        public OltLabelData()
        {
            UseMnemonic = false;
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }       
    }
}
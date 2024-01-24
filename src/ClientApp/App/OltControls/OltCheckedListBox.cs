using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltCheckedListBox : CheckedListBox
    {
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }
    }
}

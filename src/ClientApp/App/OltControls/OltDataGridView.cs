using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltDataGridView : DataGridView
    {
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }
    }
}

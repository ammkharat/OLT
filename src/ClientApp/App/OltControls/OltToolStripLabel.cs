using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltToolStripLabel : ToolStripLabel
    {
        private readonly Font font = new Font(UIConstants.FONT_FAMILY_NAME, 8.25F, FontStyle.Bold, GraphicsUnit.Point, (0));

        public override Font Font
        {
            get
            {
                return font;
            }
        }
    }
}
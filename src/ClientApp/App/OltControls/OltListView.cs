using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Olt specific list view
    /// </summary>
    public class OltListView : ListView
    {
        private const int POTENTIAL_SCROLL_BAR_WIDTH = 60;

        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public void FitFirstColumn()
        {
            if (Columns.Count > 0)
            {
                Columns[0].Width = Width - POTENTIAL_SCROLL_BAR_WIDTH;
            }
        }
    }
}
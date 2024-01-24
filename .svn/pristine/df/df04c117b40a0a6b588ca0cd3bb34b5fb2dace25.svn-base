using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Olt specific ListBox
    /// </summary>
    public class OltListBox : ListBox
    {
        private bool readOnly;

        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public virtual bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                if (readOnly)
                {
                    BackColor = SystemColors.Control;
                }
                else
                {
                    BackColor = Color.White;
                }
            }
        }
    }
}
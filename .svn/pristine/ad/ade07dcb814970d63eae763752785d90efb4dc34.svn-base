using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltPanel : Panel
    {
        public event Func<bool> MouseWheeling;

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            bool shouldAllowMouseWheel = true;
            if (MouseWheeling != null)
            {
                shouldAllowMouseWheel = MouseWheeling();
            }
            if (shouldAllowMouseWheel)
            {
                base.OnMouseWheel(e);
            }
        }
    }
}
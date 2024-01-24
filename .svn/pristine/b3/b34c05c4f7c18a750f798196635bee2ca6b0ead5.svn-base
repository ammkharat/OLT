using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;
using log4net;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltExplorerBar : UltraExplorerBar
    {
        public event Func<bool> MouseWheeling;

        private static readonly ILog logger = LogManager.GetLogger(typeof(OltExplorerBar));

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // NOTE: UltraExplorerBar will only scroll if the control itself has focus.
            //       That is, if I'm typing in a textbox within the explorer bar, and scroll the mouse,
            //       UltraExplorerBar will not do scrolling.
            //
            //       Using Reflector, we see this in UltraExplorerBar.OnMouseWheel():
            //       if (this.Focused && (this.Groups.Count != 0))
            //
            //       So, given that we have TFS Bug #295 that wants scrolling to work, we force
            //       UltraExplorerBar to gain focus before handling the mouse wheel scroll.
            try
            {
                bool shouldAllowMouseWheel = true;
                if (MouseWheeling != null)
                {
                    shouldAllowMouseWheel = MouseWheeling();
                }
                if (shouldAllowMouseWheel)
                {
                    Focus();
                    base.OnMouseWheel(e);
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error in OnMouseWheel", exception);
                base.OnMouseWheel(e);
            }
        }
    }
}
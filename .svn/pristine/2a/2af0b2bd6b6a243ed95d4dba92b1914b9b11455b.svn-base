using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Utilities
{
    public static class WinFormsExtensions
    {
        public static void SetEnableOnAllChildControls(this Control control, bool isEnabled)
        {
            control.Enabled = isEnabled;
            if(control.Controls.Count > 0)
            {
                foreach (Control childControl in control.Controls)
                {
                    childControl.SetEnableOnAllChildControls(isEnabled);
                }
            }
        }

        public static void SetEnableOnAllChildControls(this Control.ControlCollection controls, bool isEnabled)
        {
            foreach (Control control in controls)
            {
                control.SetEnableOnAllChildControls(isEnabled);
            }
        }

        public static Point GetCenterParentLocation(this IForm parentForm, IForm childForm)
        {
            return new Point(parentForm.Location.X + (parentForm.Width - childForm.Width) / 2, parentForm.Location.Y + (parentForm.Height - childForm.Height) / 2);    
        }

        public static bool IsNotDisposed(this IPage control)
        {
            return control != null && !control.IsDisposed;
        }

        public static bool IsOnNonUiThread(this IPage control)
        {
            return control.IsNotDisposed() && control.InvokeRequired;
        }
    }
}
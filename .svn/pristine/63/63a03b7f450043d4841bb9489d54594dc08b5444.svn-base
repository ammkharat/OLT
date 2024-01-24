using System.Diagnostics;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client
{
    public class UIUtils
    {
        public static bool ConfirmDeleteDialog()
        {
            return (OltMessageBox.Show(Form.ActiveForm, StringResources.AreYouSureDeleteDialogMessage,
                                       StringResources.AreYouSureDeleteDialogTitle, MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question) == DialogResult.Yes);
        }

        public static void LaunchURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }            
        }
    }
}
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class DirectiveUtility
    {
        public static void ShowConvertingDirectivesToNewSystemMessage()
        {
            string message = StringResources.ConvertingDirectivesMessage;
            OltMessageBox.Show(Form.ActiveForm, message, StringResources.ConvertingDirectivesTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShouldShowConvertingDirectivesToNewSystemMessage(ISiteConfigurationService siteConfigurationService, long siteId)
        {
            return !siteConfigurationService.SiteIsUsingLogBasedDirectives(siteId);
        }

    }
}

using System.Configuration;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Remote.Services
{
    public class ApplicationService : IApplicationService
    {
        public string GetHelpURL()
        {
            return ConfigurationManager.AppSettings["HelpURL"];
        }

        public string GetReleaseNotesURL()
        {
            return ConfigurationManager.AppSettings["ReleaseNotesURL"];
        }

        public string GetBuildConfiguration()
        {
            return ConfigurationManager.AppSettings["BuildConfiguration"];
        }       
    }
}

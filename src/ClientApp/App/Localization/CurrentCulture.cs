using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Client.Localization
{
    public class CurrentCulture
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CurrentCulture));

        public static void SetUpCulture()
        {
            string cultureName = GetConfiguredCultureName();
            Culture.SetSpecificCultureOnThread(cultureName);
            SetupInfragisticsResourceStrings();
        }

        private static string GetConfiguredCultureName()
        {
            string path = Path.Combine(Application.StartupPath, "LocalizationData");
            
            if (!Directory.Exists(path))
            {
                logger.Debug("uiculture directory does not exist: " + path);
                return null;
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] fileInfos = directoryInfo.GetFiles("uiculture.*");

                if (fileInfos.Length == 1)
                {
                    FileInfo fileInfo = fileInfos[0];

                    string fileName = fileInfo.Name;
                    logger.Debug("uiculture file found: " + fileName);
                    
                    string uiCultureName = fileName.Replace("uiculture.", string.Empty);
                    logger.Debug("uiculture: " + fileName);

                    return uiCultureName;
                }
                else
                {
                    logger.Debug("# of uiculture files found: " + fileInfos.Length + ".  Using default.");
                    return null;
                }
            }

        }

        private static void SetupInfragisticsResourceStrings()
        {
            InfragisticsLocalizer localizer = new InfragisticsLocalizer();
            localizer.Localize();
        }
    }
}

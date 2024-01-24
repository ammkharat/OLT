using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class GuidelineUtilities
    {
        public static List<LogGuideline> GetGuidelines(List<FunctionalLocation> userSelectedFlocs, ILogService logService)
        {            
            if (userSelectedFlocs.IsEmpty())
            {
                return new List<LogGuideline>(0);
            }

            List<string> divisionList = userSelectedFlocs.DivisionFullHierarchies();
            List<LogGuideline> guidelines = logService.QueryLogGuidelinesByDivisions(divisionList, userSelectedFlocs[0].Site.IdValue);

            return guidelines;           
        }

        public static string BuildGuidelineText(List<LogGuideline> guidelines)
        {
            string guidelineText;

            if (guidelines.Count == 0)
            {
                guidelineText = StringResources.NoGuidelinesAvailable;
            }
            else if (guidelines.Count == 1)
            {
                guidelineText = guidelines[0].Text;
            }
            else
            {
                StringBuilder text = new StringBuilder();

                foreach (LogGuideline logGuideline in guidelines)
                {
                    text.AppendLine(logGuideline.FunctionalLocation.FullHierarchy);
                    text.AppendLine("-------------------------------------------------------------------");
                    text.AppendLine(logGuideline.Text);
                    text.AppendLine();
                }

                guidelineText = text.ToString();
            }

            return guidelineText;
        }
    }
}

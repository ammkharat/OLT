using System.Reflection;
using Com.Suncor.Olt.Client.Localization;
using Infragistics.Shared;

namespace Com.Suncor.Olt.Client.Localization
{
    public class InfragisticsLocalizer
    {
        public void Localize()
        {
            ResourceCustomizer winGridRC = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            winGridRC.ResetAllCustomizedStrings();

            LocalizeRefectively(winGridRC, "GroupBy", true);
            LocalizeRefectively(winGridRC, "SpecialFilterOperand", true);
            LocalizeRefectively(winGridRC, "FilterDialog", true);
            LocalizeRefectively(winGridRC, "RowFilterDropDown", true);
            LocalizeRefectively(winGridRC, "RowFilterDialog", true);
            LocalizeRefectively(winGridRC, "LDR_Layout_mask", true);

            ResourceCustomizer supportDialogsRC = Infragistics.Win.SupportDialogs.Resources.Customizer;
            supportDialogsRC.ResetAllCustomizedStrings();
            LocalizeRefectively(supportDialogsRC, "FilterUIProvider_", true);
            LocalizeRefectively(supportDialogsRC, "UltraGridFilterUIProvider_", true);

        }

        private void LocalizeRefectively(ResourceCustomizer rc, string propertyPrefix, bool leavePropertyPrefix)
        {
            InfragisticsStringResources resources = new InfragisticsStringResources();

            PropertyInfo[] propertyInfos = typeof(InfragisticsStringResources).GetProperties(
                BindingFlags.Public | BindingFlags.Static);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                string name = propertyInfo.Name;
                if (name.StartsWith(propertyPrefix))
                {
                    string infragisticsResourceKey = leavePropertyPrefix ? name : name.Replace(propertyPrefix, string.Empty);
                    object localizedString = propertyInfo.GetValue(resources, BindingFlags.Static, null, null, InfragisticsStringResources.Culture);
                    rc.SetCustomizedString(infragisticsResourceKey, (string) localizedString);
                }
            }
        }

    }
}

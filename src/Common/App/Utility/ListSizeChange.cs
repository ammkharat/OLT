using System;
using System.Collections;
using System.Globalization;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class ListSizeChange : PropertyChange
    {
        public ListSizeChange(string propertyName, IList originalList, IList changedList)
            : base(propertyName, originalList.Count, changedList.Count)
        {
        }

        public override string Label
        {
            get
            {
                var resourceLookupKey = GetInternationalizationPropertyKey(PropertyName);

                var localizedLabel = StringResources.ResourceManager.GetString(resourceLookupKey,
                    CultureInfo.CurrentUICulture) ??
                                     PropertyName.ConvertCamelCaseFieldName();

                var localizedCount = string.Empty;


                return string.Concat(localizedLabel, " ", localizedCount);
            }
        }

        private static string GetInternationalizationPropertyKey(string propertyName)
        {
            return string.Format("{0}ClassProperty{1}Key", string.Empty, propertyName);
        }
    }
}
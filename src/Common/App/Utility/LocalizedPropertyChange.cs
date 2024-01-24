using System;
using System.Globalization;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class LocalizedPropertyChange : PropertyChange
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<LocalizedPropertyChange>();
        private readonly string propertyLabel;

        public LocalizedPropertyChange(Type historyType, string propertyName, string propertyLabel, object originalValue,
            object changedValue)
            : base(propertyName, originalValue, changedValue)
        {
            this.propertyLabel = propertyLabel;
            HistoryType = historyType;
        }

        private Type HistoryType { get; set; }

        public override string Label
        {
            get
            {
                var localizedLabel = GetLocalizedLabel();
                if (localizedLabel.IsNullOrEmptyOrWhitespace())
                {
                    logger.WarnFormat("Localized string {0} not found for {1}",
                        GetInternationalizationPropertyKey(),
                        CultureInfo.CurrentUICulture);
                    localizedLabel = PropertyName.ConvertCamelCaseFieldName();
                }

                return propertyLabel.HasValue()
                    ? string.Format("{0} - {1}", propertyLabel, localizedLabel)
                    : localizedLabel;
            }
        }

        public string GetLocalizedLabel()
        {
            var resourceLookupKey = GetInternationalizationPropertyKey();
            return StringResources.ResourceManager.GetString(resourceLookupKey, CultureInfo.CurrentUICulture);
        }

        private string GetInternationalizationPropertyKey()
        {
            // This does not need to be internationalized.  It's the key for looking up History fields in the String Resources.
            return string.Format("{0}Class{1}PropertyKey", HistoryType.Name, PropertyName);
        }
    }
}
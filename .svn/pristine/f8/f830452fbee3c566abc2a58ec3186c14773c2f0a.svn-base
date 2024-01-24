using System;
using Com.Suncor.Olt.Common.Annotations;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public abstract class PropertyChange : DomainObject
    {
        protected PropertyChange(string propertyName, object originalValue, object changedValue)
        {
            OriginalValue = originalValue;
            ChangedValue = changedValue;
            PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
        public object OriginalValue { get; private set; }
        public object ChangedValue { get; private set; }

        // Used by the grid Renderer
        [UsedImplicitly]
        public abstract string Label { get; }

        public override string ToString()
        {
            return string.Format("{0} ( {1}: {2} -> {3} )", StringResources.PropertyChangeToStringPrefix, Label,
                OriginalValue, ChangedValue);
        }
    }
}
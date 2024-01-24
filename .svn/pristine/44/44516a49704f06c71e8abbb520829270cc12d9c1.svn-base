using System;

namespace Com.Suncor.Olt.Common.Domain.Analytics
{
    [Serializable]
    public class Property : DomainObject
    {
        private readonly DateTime? dateTimeValue;
        private readonly long? eventId;
        private readonly string key;
        private readonly decimal? numberValue;
        private readonly string textValue;
        private readonly PropertyType type;

        private Property(long? id, long? eventId, string key, PropertyType type, string textValue,
            DateTime? dateTimeValue, decimal? numberValue)
        {
            this.id = id;
            this.eventId = eventId;
            this.key = key;
            this.type = type;
            this.textValue = textValue;
            this.dateTimeValue = dateTimeValue;
            this.numberValue = numberValue;
        }

        public Property(string key, string value) : this(null, null, key, PropertyType.Text, value, null, null)
        {
        }

        public Property(string key, DateTime? value)
            : this(null, null, key, PropertyType.DateTime, null, value, null)
        {
        }

        public Property(string key, decimal? value)
            : this(null, null, key, PropertyType.Number, null, null, value)
        {
        }

        public long? EventId
        {
            get { return eventId; }
        }

        public string Key
        {
            get { return key; }
        }

        public PropertyType Type
        {
            get { return type; }
        }

        public string TextValue
        {
            get { return textValue; }
        }

        public DateTime? DateTimeValue
        {
            get { return dateTimeValue; }
        }

        public decimal? NumberValue
        {
            get { return numberValue; }
        }

        public static Property CreateFullProperty(long? id, long? eventId, string key, PropertyType type,
            string textValue, DateTime? dateTimeValue, decimal? numberValue)
        {
            return new Property(id, eventId, key, type, textValue, dateTimeValue, numberValue);
        }
    }
}
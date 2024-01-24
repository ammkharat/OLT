using System;
using System.Xml.Serialization;

namespace Com.Suncor.Olt.Common.Domain.UserPreference
{
    [Serializable]
    public class Column
    {
        [XmlAttribute("Format")] public string format;
        [XmlAttribute("Key")] public string key;
        [XmlAttribute("TextAlign")] public string textAlign;

        [XmlText] public string title;
        [XmlAttribute("VisiblePosition")] public int visiblePosition;
        [XmlAttribute("Width")] public int width;


        public Column()
        {
        }

        public Column(string key, int visiblePosition, int width, string title, string format, string textAlign)
        {
            this.key = key;
            this.visiblePosition = visiblePosition;
            this.width = width;
            this.title = title;
            this.format = format;
            this.textAlign = textAlign;
        }

        public bool Equals(Column obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.key, key) && obj.visiblePosition == visiblePosition && obj.width == width &&
                   Equals(obj.title, title) && Equals(obj.textAlign, textAlign) && Equals(obj.format, format);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Column)) return false;
            return Equals((Column) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = (key != null ? key.GetHashCode() : 0);
                result = (result*397) ^ visiblePosition;
                result = (result*397) ^ (format != null ? format.GetHashCode() : 0);
                result = (result*397) ^ (textAlign != null ? textAlign.GetHashCode() : 0);
                result = (result*397) ^ width;
                result = (result*397) ^ (title != null ? title.GetHashCode() : 0);
                return result;
            }
        }
    }
}
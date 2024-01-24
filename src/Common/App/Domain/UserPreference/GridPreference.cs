using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Com.Suncor.Olt.Common.Domain.UserPreference
{
    [Serializable]
    public class GridPreference
    {
        private readonly List<Column> columns = new List<Column>();
        [XmlAttribute("Name")] public string name;

        public GridPreference()
        {
        }

        public GridPreference(string name)
        {
            this.name = name;
        }

        [XmlElement("Column")]
        public List<Column> Columns
        {
            get
            {
                columns.Sort((c1, c2) => c1.visiblePosition.CompareTo(c2.visiblePosition));
                return columns;
            }
        }

        public void AddColumn(Column c)
        {
            columns.Add(c);
        }

        public Column UpdateColumn(string key, int visiblePosition, int width, string title, string format,
            string textAlign)
        {
            var column = columns.Find(c => c.key == key);
            if (column == null)
            {
                column = new Column();
                AddColumn(column);
            }
            column.key = key;
            column.visiblePosition = visiblePosition;
            column.width = width;
            column.title = title;
            column.format = format;
            column.textAlign = textAlign;

            return column;
        }

        # region Equality

        public bool Equals(GridPreference obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.name, name) && Equals(obj.columns, columns);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (GridPreference)) return false;
            return Equals((GridPreference) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((name != null ? name.GetHashCode() : 0)*397) ^ (columns != null ? columns.GetHashCode() : 0);
            }
        }

        # endregion
    }
}
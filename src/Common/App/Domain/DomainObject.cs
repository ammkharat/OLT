using System;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Base class for a domain object
    /// </summary>
    [Serializable]
    public abstract class DomainObject : ComparableObject, IComparable<DomainObject>, IComparable
    {
        private static long? UNITIALIZED_ID;
        public long? id = UNITIALIZED_ID;

        protected DomainObject()
        {
        }

        protected DomainObject(long id)
        {
            this.id = id;
        }

        // Marked as XmlIgnore for XML Serialization on UserLayoutPreference
        [XmlIgnore]
        [IgnoreDifference]
        [Browsable(false)]
        public virtual long? Id
        {
            get { return id; }
            set { id = value; }
        }

        [IgnoreDifference]
        [IgnoreToString]
        [Browsable(false)]
        public long IdValue
        {
            get { return Id.Value; }
        }

        [IgnoreDifference]
        [IgnoreToString]
        [Browsable(false)]
        public string ObjectIdentifier
        {
            get { return GetType() + "-" + IdValue; }
        }

        public virtual int CompareTo(object obj)
        {
            return CompareTo((DomainObject) obj);
        }

        public virtual int CompareTo(DomainObject other)
        {
            if (other == null)
                return 1;

            return Nullable.Compare(Id, other.Id);
        }

        public DomainObject Clone()
        {
            return (DomainObject) MemberwiseClone();
        }

        public static int CompareByIds(DomainObject x, DomainObject y)
        {
            if (x == null)
            {
                return y != null ? -1 : 0;
            }

            return x.CompareTo(y);
        }

        public override string ToString()
        {
            return this.ReflectionToString();
        }

        public bool IsInDatabase()
        {
            return (Id != null);
        }

        public static bool AreDifferentBasedOnId(DomainObject x, DomainObject y)
        {
            if (x == null)
            {
                return y != null;
            }
            if (y == null)
            {
                return true;
            }
            return x.Id != y.Id;
        }

        public bool IsSame(DomainObject other)
        {
            return other != null && Id == other.Id;
        }

        public bool ContainsSearchTerm(string searchTerm)
        {
            if (searchTerm.IsNullOrEmptyOrWhitespace())
            {
                return false;
            }

            var strings = searchTerm.Split(' ');

            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var s in strings)
            {
                var aPropertyContainsTheString = false;

                foreach (var propertyInfo in properties)
                {
                    var isBool = propertyInfo.PropertyType == typeof (bool);

                    if (Attribute.IsDefined(propertyInfo, typeof (IncludeInSearchAttribute)) && !isBool)
                    {
                        var value = propertyInfo.GetValue(this, null);

                        if (value != null)
                        {
                            var stringValue = value.ToString();

                            if (stringValue.ToUpper().Contains(s.ToUpper()))
                            {
                                aPropertyContainsTheString = true;
                            }
                        }
                    }
                }

                if (!aPropertyContainsTheString)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
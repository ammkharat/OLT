using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Used to hold DomainObjects that only have an Id and a Name property.  This is useful for a lot of status-type
    ///     objects.
    /// </summary>
    [Serializable]
    public abstract class SimpleDomainObject : DomainObject
    {
        protected SimpleDomainObject(long id)
        {
            Id = id;
        }

        public long Value
        {
            get { return IdValue; }
        }

        public string Name
        {
            get { return GetName(); }
        }

        public override string ToString()
        {
            return GetName();
        }

        public abstract string GetName();

        protected static T GetById<T>(long? id, List<T> valueArray) where T : SimpleDomainObject
        {
            return id.HasNoValue() ? default(T) : valueArray.FindById(id);
        }

        protected static T GetById<T>(long? id, T[] valueArray) where T : SimpleDomainObject
        {
            return id.HasNoValue() ? default(T) : valueArray.FindById(id);
        }

        public static bool operator ==(SimpleDomainObject x, SimpleDomainObject y)
        {
            var xnull = ReferenceEquals(x, null);
            var ynull = ReferenceEquals(y, null);
            if (xnull && ynull) return true;
            if (xnull || ynull) return false;
            return x.Id.Equals(y.Id);
        }

        public static bool operator !=(SimpleDomainObject x, SimpleDomainObject y)
        {
            var xnull = ReferenceEquals(x, null);
            var ynull = ReferenceEquals(y, null);
            if (xnull && ynull) return false;
            if (xnull || ynull) return true;
            return !x.Id.Equals(y.Id);
        }

        public bool Equals(SimpleDomainObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.id.Equals(id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SimpleDomainObject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return id.HasValue ? id.Value.GetHashCode() : 0;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Utility.Comparer
{
    public class DomainObjectIdEqualityComparer<T> : IEqualityComparer<T> where T : DomainObject
    {
        public bool Equals(T x, T y)
        {
            if (x == null)
            {
                return y == null;
            }
            if (y == null)
            {
                return false;
            }

            return Nullable.Equals(x.Id, y.Id);
        }

        public int GetHashCode(T obj)
        {
            return obj.Id.GetValueOrDefault(-1).GetHashCode();
        }
    }
}
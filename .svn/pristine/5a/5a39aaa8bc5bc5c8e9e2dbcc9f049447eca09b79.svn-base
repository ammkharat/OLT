using System;
using System.Collections;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    /// <summary>
    ///     The HashSet
    ///     <T>
    ///         class does not have a good Equals method.
    ///         So we are making our own class that is using the HashSet internally so that our own Equals and
    ///         DifferenceBuilders work properly.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Set<T> : ICollection<T> //, ICollection
    {
        private readonly HashSet<T> data;

        public Set()
        {
            data = new HashSet<T>();
        }

        private Set(HashSet<T> original)
        {
            data = original;
        }

        public Set(IEnumerable<T> original)
        {
            data = new HashSet<T>(original);
        }

        public int Count
        {
            get { return data.Count; }
        }

        public void Add(T a)
        {
            data.Add(a);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(T a)
        {
            return data.Contains(a);
        }

        public void CopyTo(T[] array, int index)
        {
            data.CopyTo(array, index);
        }

        public bool Remove(T a)
        {
            return data.Remove(a);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        ///     Modify current Set to contain all elements in both this set and set passed in.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public Set<T> Union(IEnumerable<T> b)
        {
            var hashSet = new HashSet<T>(data);
            hashSet.UnionWith(b);
            return new Set<T>(hashSet);
        }

        public Set<T> Intersection(IEnumerable<T> b)
        {
            var hashSet = new HashSet<T>(data);
            hashSet.IntersectWith(b);
            return new Set<T>(hashSet);
        }

        public override bool Equals(object obj)
        {
            var a = this;
            var b = obj as Set<T>;
            if (b == null)
                return false;
            return a.data.SetEquals(b.data);
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            data.ForEach(d => hashCode ^= d.GetHashCode());
            return hashCode;
        }
    }
}
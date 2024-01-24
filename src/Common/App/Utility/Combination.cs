using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    /// <summary>
    ///     Represents a combination of elements (this is combination like "combinations and permutations").
    /// </summary>
    public class Combination<T>
    {
        private readonly List<T> elements;

        public Combination() : this(new T[0])
        {
        }

        public Combination(IEnumerable<T> elements)
        {
            this.elements = new List<T>(elements);
        }

        public List<T> Elements
        {
            get { return elements; }
        }

        public int Size
        {
            get { return Elements.Count; }
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public Combination<T> ShallowClone()
        {
            return new Combination<T>(elements);
        }

        public override int GetHashCode()
        {
            return elements.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ReflectionEquals(obj);
        }
    }
}
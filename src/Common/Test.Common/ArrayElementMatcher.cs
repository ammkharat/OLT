using System;
using System.IO;
using NMock2;

namespace Com.Suncor.Olt.Common
{
    /// <summary>
    /// Matches an array on one of its elements.
    /// </summary>
    public class ArrayElementMatcher : Matcher
    {
        private readonly int arrayIndex;
        private readonly Matcher elementMatcher;

        public ArrayElementMatcher(int arrayIndex, Matcher elementMatcher)
        {
            this.arrayIndex = arrayIndex;
            this.elementMatcher = elementMatcher;
        }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("array with element:<");
            writer.Write(arrayIndex);
            writer.Write("> matching:<");
            elementMatcher.DescribeTo(writer);
            writer.Write(">");
        }

        public override bool Matches(object o)
        {
            Array array = (Array) o;
            if (arrayIndex > array.Length - 1)
            {
                return false;
            }

            return elementMatcher.Matches(array.GetValue(arrayIndex));
        }
    }
}
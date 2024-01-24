using System.Collections.Generic;
using System.IO;
using NMock2;

namespace Com.Suncor.Olt.Common
{
    public class ListElementMatcher<T> : Matcher
    {
        private readonly int elementIndex;
        private readonly Matcher elementMatcher;

        public ListElementMatcher(int elementIndex, Matcher elementMatcher)
        {
            this.elementIndex = elementIndex;
            this.elementMatcher = elementMatcher;
        }

        public override bool Matches(object o)
        {
            List<T> list = (List<T>)o;

            if (list == null)
            {
                return false;
            }

            if (elementIndex >= list.Count)
            {
                return false;
            }

            return elementMatcher.Matches(list[elementIndex]);
        }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("a list with element[{0}]:", elementIndex);
            elementMatcher.DescribeTo(writer);
        }
    }
}

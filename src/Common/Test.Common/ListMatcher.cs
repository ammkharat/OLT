using System.Collections.Generic;
using NMock2;

namespace Com.Suncor.Olt.Common
{
    public class ListMatcher<T> : Matcher
    {
        readonly IList<T> expectedList;

        public ListMatcher(IList<T> expectedList)
        {
            this.expectedList = expectedList;
        }

        public override void DescribeTo(System.IO.TextWriter writer)
        {
            writer.Write(expectedList.ToString());
        }

        public override bool Matches(object o)
        {
            IList<T> incomingList = (IList<T>)o;

            if (expectedList == null && incomingList == null)
            {
                return true;
            }

            if (expectedList == null || incomingList == null)
            {
                return false;
            }

            if (expectedList.Count != incomingList.Count)
            {
                return false;
            }

            for (int i = 0; i < expectedList.Count; i++)
            {
                if (!expectedList[i].Equals(incomingList[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class IsList
    {
        public static Matcher Equal<T>(List<T> list)
        {
            return new ListMatcher<T>(list);
        }
    }
}

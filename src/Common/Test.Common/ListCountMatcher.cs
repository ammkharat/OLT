using System.Collections;
using System.IO;
using NMock2;

namespace Com.Suncor.Olt.Common
{
    public class ListCountMatcher : Matcher
    {
        private readonly Matcher matcher;

        public ListCountMatcher(int expectedCount)
        {
            matcher = new OltPropertyMatcher<ICollection>("Count", expectedCount);
        }

        public override bool Matches(object o)
        {
            return matcher.Matches(o);
        }

        public override void DescribeTo(TextWriter writer)
        {
            matcher.DescribeTo(writer);
        }
    }
}

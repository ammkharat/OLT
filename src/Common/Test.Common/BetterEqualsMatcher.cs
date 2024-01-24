using System.IO;
using Com.Suncor.Olt.Common.Extension;
using NMock2;

namespace Com.Suncor.Olt.Common
{
    public class BetterEqualsMatcher<T> : Matcher
    {
        private readonly T expected;

        public BetterEqualsMatcher(T expected)
        {
            this.expected = expected;
        }

        public override bool Matches(object o)
        {
            T actual = (T)o;

            return actual.ReflectionEquals(expected);
       }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write(expected.ToString());
        }
    }

    public class Izz
    {
        public static Matcher Equals<T>(T expected)
        {
            return new BetterEqualsMatcher<T>(expected);
        }
    }
}

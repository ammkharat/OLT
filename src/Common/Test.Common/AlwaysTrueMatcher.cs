using NMock2.Matchers;

namespace Com.Suncor.Olt.Common
{
    public class AlwaysTrueMatcher : AlwaysMatcher
    {
        public AlwaysTrueMatcher() : base(true, "True Matcher")
        {
        }

    }

//    public class Is
//    {
//        public static Matcher Any
//        {
//            get { return new AlwaysTrueMatcher(); }
//        }
//    }
}
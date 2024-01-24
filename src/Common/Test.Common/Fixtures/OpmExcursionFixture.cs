using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class OpmExcursionFixture
    {
        public static OpmExcursion CreateForInsert()
        {
            return new OpmExcursion(100, 13332, 32, "HISTTAG", "DDD-ODD-DDD", 123, "TOENAME", ToeType.HighSl,
                ExcursionStatus.Open, Clock.Now, null, "mm", 33m, 22m, 32, "http://someurl.com", 1322,
                "Engineer comments eh", "reasoncode", Clock.Now, 23m);
        }
    }
}
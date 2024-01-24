using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class EventSinkFixture
    {
        public static EventSink CreateNewEventSinkWithoutId()
        {
            return new EventSink( "asdf", new List<string>{"1", "1-2", "1-2-3"}, new List<string> { "A", "B" },new List<string> { "C", "D" }, new List<long> { 1, 2 },  2);
        }
        
        public static EventSink CreateNewEventSink(string clientUri)
        {
            return new EventSink(clientUri, new List<string> { "1", "1-2", "1-2-3" }, null,null, new List<long> { 1, 2 }, 2);
        }

        public static EventSink CreateNewEventSinkWithSiteIdNullAndWithoutId()
        {
            return new EventSink("asdf", new List<string> { "1", "1-2", "1-2-3" }, new List<string> { "A", "B" },new List<string> { "C", "D" }, new List<long> { 1, 2 }, null);
        }
    }
}

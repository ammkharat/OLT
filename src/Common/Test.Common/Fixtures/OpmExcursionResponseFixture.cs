using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class OpmExcursionResponseFixture
    {
        public static OpmExcursionResponse CreateForInsert()
        {
            return new OpmExcursionResponse(100, 121, 13332, 32, "HISTTAG",UserFixture.CreateSupervisor(),
                "tis the response", Clock.Now, "Asset", "Code"); //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        }
    }
}
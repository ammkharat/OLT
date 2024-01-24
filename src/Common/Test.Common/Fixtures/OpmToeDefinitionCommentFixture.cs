using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class OpmToeDefinitionCommentFixture
    {
        public static OpmToeDefinitionComment CreateForInsert()
        {
            return new OpmToeDefinitionComment(100, 13332,"ToeName", "HISTTAG",UserFixture.CreateSupervisor(),"tis the comment", Clock.Now,135);
        }
    }
}
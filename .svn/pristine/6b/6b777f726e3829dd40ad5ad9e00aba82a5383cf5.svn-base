using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [TestFixture]
    public class OpmExcursionEditPackageTest
    {
        [Test]
        public void ShouldAssignToeDefinitionCommentToMostRecentToeDefinition()
        {
            var excursion = OpmExcursionFixture.CreateForInsert();
            excursion.OpmExcursionResponse = new OpmExcursionResponse(excursion);
            var excursion2 = OpmExcursionFixture.CreateForInsert();
            excursion2.OpmExcursionResponse = new OpmExcursionResponse(excursion2);
            excursion2.OpmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            excursion2.OpmToeDefinition.OpmToeDefinitionComment = OpmToeDefinitionCommentFixture.CreateForInsert();
            excursion2.StartDateTime = Clock.Now.AddMinutes(3);
            
            var excursion3 = OpmExcursionFixture.CreateForInsert();
            excursion3.StartDateTime = Clock.Now.AddMinutes(1);
            excursion3.OpmExcursionResponse = new OpmExcursionResponse(excursion3)
            {
                LastModifiedDateTime = Clock.Now.AddMinutes(1),
                Response = "is one commnet"
            };
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            opmToeDefinition.ToeVersion = 332;
            excursion3.OpmToeDefinition = opmToeDefinition;
            var opmExcursionEditPackage =
                new OpmExcursionEditPackage(new List<OpmExcursion> {excursion, excursion2, excursion3});

            var toeCommentLastModifiedBy = UserFixture.CreateOperator(-1, "user@sucor.com");
            opmExcursionEditPackage.ToeCommentLastModifiedBy = toeCommentLastModifiedBy;

            Assert.AreEqual(
                opmExcursionEditPackage.Excursions.OrderBy(curs => curs.StartDateTime)
                    .Last()
                    .OpmToeDefinition.OpmToeDefinitionComment.LastModifiedBy.IdValue, toeCommentLastModifiedBy.IdValue);

        }

        [Test]
        public void ShouldReturnMostRecentComment()
        {
            var excursion = OpmExcursionFixture.CreateForInsert();
            excursion.OpmExcursionResponse = new OpmExcursionResponse(excursion);
            var excursion2 = OpmExcursionFixture.CreateForInsert();
            excursion2.OpmExcursionResponse = new OpmExcursionResponse(excursion2)
            {
                LastModifiedDateTime = Clock.Now.AddMinutes(2),
                Response = "most recent comment"
            };
            var excursion3 = OpmExcursionFixture.CreateForInsert();
            excursion3.StartDateTime = Clock.Now.AddMinutes(1);
            excursion3.OpmExcursionResponse = new OpmExcursionResponse(excursion3)
            {
                LastModifiedDateTime = Clock.Now.AddMinutes(1),
                Response = "is one commnet"
            };
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            opmToeDefinition.ToeVersion = 332;
            excursion3.OpmToeDefinition = opmToeDefinition;

            var opmExcursionEditPackage =
                new OpmExcursionEditPackage(new List<OpmExcursion> {excursion, excursion2, excursion3});

            Assert.AreEqual(opmExcursionEditPackage.MostRecentExcursionResponseComment, "most recent comment");
        }

        [Test]
        public void ShouldShowMostRecentToeDefinition()
        {
            var excursion = OpmExcursionFixture.CreateForInsert();
            excursion.OpmExcursionResponse = new OpmExcursionResponse(excursion);
            var excursion2 = OpmExcursionFixture.CreateForInsert();
            excursion2.OpmExcursionResponse = new OpmExcursionResponse(excursion2);
            var excursion3 = OpmExcursionFixture.CreateForInsert();
            excursion3.OpmExcursionResponse = new OpmExcursionResponse(excursion3);
            excursion3.StartDateTime = Clock.Now.AddMinutes(1);
            excursion3.OpmExcursionResponse.Response = "this should be first in the list";
            var opmToeDefinition = OpmToeDefinitionFixture.CreateForInsert();
            opmToeDefinition.ToeVersion = 332;
            excursion3.OpmToeDefinition = opmToeDefinition;

            var opmExcursionEditPackage =
                new OpmExcursionEditPackage(new List<OpmExcursion> {excursion, excursion2, excursion3});

            Assert.IsNotNull(opmExcursionEditPackage.OpmToeDefinition);
            Assert.AreEqual(opmExcursionEditPackage.OpmToeDefinition.ToeVersion, opmToeDefinition.ToeVersion);
            Assert.AreEqual(opmExcursionEditPackage.ExcursionsForGridEditing[0].ExcursionResponseComment,
                excursion3.OpmExcursionResponse.Response);
        }
    }
}
using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class GasTestElementInfoTest
    {
        private const long NON_STANDARD_ELEMENT_INFO_ID = -237894;

        GasLimitRange coldLimit;
        GasLimitRange hotLimit;
        GasLimitRange cseLimit;
        GasLimitRange inertCSELimit;
        GasTestElementInfo gasTestElementInfoForGasLimitRangeTest;

        [SetUp]
        public void SetUp()
        {
            coldLimit = new GasLimitRange(0, 150);
            hotLimit = new GasLimitRange(0, 250);
            cseLimit = new GasLimitRange(0, 125);
            inertCSELimit = new GasLimitRange(0, 100);

            gasTestElementInfoForGasLimitRangeTest = new GasTestElementInfo(null,
                                                                            "For Testing GasTestLimit",
                                                                            SiteFixture.Sarnia(),
                                                                            true,
                                                                            1,
                                                                            coldLimit,
                                                                            hotLimit,
                                                                            cseLimit,
                                                                            inertCSELimit,
                                                                            string.Empty,
                                                                            GasLimitUnit.PARTS_PER_BILLION,
                                                                            true,
                                                                            2);
        }
    
        [Test]
        public void ShouldEvaluateIfElementInfoIsStandard()
        {
            GasTestElementInfo standardInfo = GasTestElementInfoFixture.GetStandardInfoForSite(SiteFixture.Sarnia());
            Assert.IsTrue(standardInfo.IsStandard);
            Assert.IsFalse(GasTestElementInfoWithId(NON_STANDARD_ELEMENT_INFO_ID).IsStandard);
            Assert.IsFalse(GasTestElementInfoWithId(null).IsStandard);
        }

        [Test]
        public void ShouldReturnReferenceToSelfIfCopyingStandardElementInfo()
        {
            GasTestElementInfo standardInfo = GasTestElementInfoFixture.GetStandardInfoForSite(SiteFixture.Sarnia());
            Assert.AreSame(standardInfo, standardInfo.Copy());
        }

        [Test]
        public void ShouldMakeCopyOfElementInfoIfNotStandard()
        {
            GasTestElementInfo elementInfo = GasTestElementInfoWithId(NON_STANDARD_ELEMENT_INFO_ID);
            GasTestElementInfo copy = elementInfo.Copy();

            Assert.AreNotSame(elementInfo, copy);
            Assert.IsNull(copy.Id);

            Assert.AreEqual(elementInfo.Name, copy.Name);
            Assert.AreEqual(elementInfo.OtherLimits, copy.OtherLimits);
        }

        [Test]
        public void ShouldDetermineIfHasData()
        {
            GasTestElementInfo elementInfo = GasTestElementInfoWithNoData();
            elementInfo.Name = TestUtil.RandomString();
            Assert.IsTrue(elementInfo.HasData());
        }

        private static GasTestElementInfo GasTestElementInfoWithNoData()
        {
            Site site = SiteFixture.Sarnia();
            GasTestElementInfo elementInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
            Assert.IsFalse(elementInfo.HasData());
            return elementInfo;
        }

        private GasTestElementInfo GasTestElementInfoWithId(Nullable<long> id)
        {
            Site site = SiteFixture.Sarnia();
            GasTestElementInfo elementInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
            elementInfo.Id = id;
            return elementInfo;
        }

        #region GetLimitRange Tests

        [Test]
        public void ShouldReturnColdLimit()
        {
            WorkPermitType permitType = WorkPermitType.COLD;
            WorkPermitAttributes attributes = new WorkPermitAttributes();

            GasLimitRange expectedLimitRange = coldLimit;
            GasLimitRange actualLimitRange = gasTestElementInfoForGasLimitRangeTest.GetLimitRange(permitType, attributes);
            Assert.AreEqual(expectedLimitRange, actualLimitRange);
        }

        [Test]
        public void ShouldReturnHotLimit()
        {
            WorkPermitType permitType = WorkPermitType.HOT;
            WorkPermitAttributes attributes = new WorkPermitAttributes();

            GasLimitRange expectedLimitRange = hotLimit;
            GasLimitRange actualLimitRange = gasTestElementInfoForGasLimitRangeTest.GetLimitRange(permitType, attributes);

            Assert.AreEqual(expectedLimitRange, actualLimitRange);
        }

        [Test]
        public void ShouldReturnCSELimit()
        {
            WorkPermitType permitType = WorkPermitType.COLD;
            WorkPermitAttributes attributes = new WorkPermitAttributes();
            attributes.IsConfinedSpaceEntry = true;

            GasLimitRange expectedLimitRange = cseLimit;
            GasLimitRange actualLimitRange = gasTestElementInfoForGasLimitRangeTest.GetLimitRange(permitType, attributes);

            Assert.AreEqual(expectedLimitRange, actualLimitRange);
        }

        [Test]
        public void ShouldReturnInsertCSELimit()
        {
            WorkPermitType permitType = WorkPermitType.COLD;
            WorkPermitAttributes attributes = new WorkPermitAttributes();
            attributes.IsConfinedSpaceEntry = true;
            attributes.IsInertConfinedSpaceEntry = true;

            GasLimitRange expectedLimitRange = inertCSELimit;
            GasLimitRange actualLimitRange = gasTestElementInfoForGasLimitRangeTest.GetLimitRange(permitType, attributes);

            Assert.AreEqual(expectedLimitRange, actualLimitRange);
        }

        #endregion
    }
}

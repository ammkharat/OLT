using Com.Suncor.Olt.Common.Domain;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class GasTestElementFixture
    {
        private static GasTestElement CreateBaseGasTestElement()
        {
            GasTestElement ret = new GasTestElement {ImmediateAreaTestResult = 789, ImmediateAreaTestRequired = true};
            return ret;
        }

        private static double RandomDoubleNumber()
        {
            return DateTimeFixture.DateTimeNow.Ticks % 1000;
        }

        public static GasTestElement CreateGasTestElementWithData(GasTestElementInfo info)
        {
            GasTestElement ret = new GasTestElement
                                     {
                                         ElementInfo = info,
                                         ImmediateAreaTestResult = RandomDoubleNumber(),
                                         ImmediateAreaTestRequired = true,
                                         Id = null
                                     };
            return ret;
        }

        public static GasTestElement CreateGasTestElementWithImmediateConfinedAndSystemEntryData()
        {
            GasTestElement ret = new GasTestElement
                                     {
                                         ImmediateAreaTestResult = RandomDoubleNumber(),
                                         ImmediateAreaTestRequired = true,
                                         ConfinedSpaceTestRequired = true,
                                         ConfinedSpaceTestResult = RandomDoubleNumber(),
                                         SystemEntryTestNotApplicable = false,
                                         SystemEntryTestResult = RandomDoubleNumber(),
                                         Id = null
                                     };
            return ret;
        }


        public static GasTestElement CreateGasTestElementWithGivenId(int id)
        {
            GasTestElement ret = CreateGasTestElementWithOtherElementInfo();
            ret.Id = id;
            return ret;
        }

        public static GasTestElement CreateGasTestElementWithOtherElementInfo()
        {
            GasTestElement ret = CreateBaseGasTestElement();
            ret.ElementInfo = GasTestElementInfoFixture.CreateOtherElementInfoNoId();
            return ret;
        }

        public static GasTestElement CreateGasTestElementWithStandardElementInfo()
        {
            GasTestElement ret = CreateGasTestElementWithOtherElementInfo();
            ret.ElementInfo = GasTestElementInfoFixture.GetStandardInfoForSite(SiteFixture.Sarnia());
            return ret;
        }

        public static List<GasTestElement> ElementListInTheOrderAppearedAsOnTheWorkSheet(Site site)
        {
            List<GasTestElement> ret = new List<GasTestElement>();
            List<GasTestElementInfo> standardInfoList = GasTestElementInfoFixture.CreateSampleStandardGasTestElementInfoList(site);

            foreach (GasTestElementInfo info in standardInfoList)
            {
                GasTestElement element = CreateBaseGasTestElement();
                element.ElementInfo = info;
                ret.Add(element);
            }
            GasTestElement other = CreateBaseGasTestElement();
            other.ElementInfo = GasTestElementInfoFixture.CreateOtherElementInfoNoId();
            ret.Add(other);

            return ret;
        }
    }
}
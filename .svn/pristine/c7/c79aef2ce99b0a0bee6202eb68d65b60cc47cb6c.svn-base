using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class GasTestElementInfoFixture
    {
        public static List<GasTestElementInfoDTO> SarniaStandardDTOs
        {
            get { return GasTestElementInfoDTO.CreateDTOList(SarniaStandardGasTestElementInfos); }
        }

        public static List<GasTestElementInfo> SarniaStandardGasTestElementInfos
        {
            get
            {
                List<GasTestElementInfo> ret = new List<GasTestElementInfo>
                                                   {
                                                       new GasTestElementInfo
                                                           (
                                                           1,
                                                           "Oxygen",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           1,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           true,
                                                           GasTestElementInfo.OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           2,
                                                           "LEL",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           2,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           3,
                                                           "H2S",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           3,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           4,
                                                           "SO2",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           4,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           5,
                                                           "CO",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           5,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           6,
                                                           "Benzene",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           6,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           7,
                                                           "Toluene",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           7,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           8,
                                                           "Xylene",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           8,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           ),
                                                       new GasTestElementInfo
                                                           (
                                                           9,
                                                           "Ammonia",
                                                           SiteFixture.Sarnia(),
                                                           true,
                                                           9,
                                                           new GasLimitRange(50, 75),
                                                           new GasLimitRange(100),
                                                           new GasLimitRange(200),
                                                           new GasLimitRange(300),
                                                           string.Empty,
                                                           GasLimitUnit.PARTS_PER_MILLION,
                                                           false,
                                                           GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                           )
                                                   };
                return ret;
            }
        }

        private static GasTestElementInfo CreateBaseOtherGasTestElementInfo()
        {
            var ret = new GasTestElementInfo
                (
                null,
                string.Empty,
                SiteFixture.Sarnia(),
                false,
                -1,
                new GasLimitRange(50, 100),
                new GasLimitRange(100),
                new GasLimitRange(200),
                new GasLimitRange(300),
                string.Empty,
                GasLimitUnit.PERCENTAGE,
                false,
                GasTestElementInfo.DECIMAL_PLACE_COUNT_NOT_APPLICABLE
                );
            return ret;
        }

        public static GasTestElementInfo CreateOtherElementInfo(long? id, Site site)
        {
            var ret = new GasTestElementInfo(
                id,
                "Other Info Name" + id,
                site,
                false,
                -1,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                "Sample Other Limit " + id,
                GasLimitUnit.UNKNOWN,
                false,
                GasTestElementInfo.DECIMAL_PLACE_COUNT_NOT_APPLICABLE
                );

            return ret;
        }

        public static GasTestElementInfo CreateOtherElementInfoNoId()
        {
            GasTestElementInfo ret = CreateBaseOtherGasTestElementInfo();
            ret.Id = null;
            ret.Name = "Other H2O";
            ret.ColdLimit = GasLimitRange.EmptyLimitRange;
            ret.HotLimit = GasLimitRange.EmptyLimitRange;
            ret.CSELimit = GasLimitRange.EmptyLimitRange;
            ret.InertCSELimit = GasLimitRange.EmptyLimitRange;
            ret.OtherLimits = "Sample Other Limit";
            ret.Site = SiteFixture.Sarnia();

            ret.Unit = GasLimitUnit.UNKNOWN;
            return ret;
        }

        public static GasTestElementInfoDTO CreateRangedLimitStandardDTO()
        {
            return SarniaStandardDTOs[0];
        }

        public static GasTestElementInfoDTO CreateNonRangedLimitStandardDTO()
        {
            return SarniaStandardDTOs[1];
        }

        public static List<GasTestElementInfo> CreateSampleStandardGasTestElementInfoList(Site site)
        {
            List<GasTestElementInfo> ret = site.Id == SiteFixture.Sarnia().Id
                                               ? SarniaStandardGasTestElementInfos
                                               : new List<GasTestElementInfo>
                                                     {
                                                         new GasTestElementInfo
                                                             (
                                                             1,
                                                             "Oxygen",
                                                             site,
                                                             true,
                                                             1,
                                                             new GasLimitRange(1, 1),
                                                             new GasLimitRange(2, 2),
                                                             new GasLimitRange(3, 3),
                                                             new GasLimitRange(4, 4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             true,
                                                             GasTestElementInfo.OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             2,
                                                             "LEL",
                                                             site,
                                                             true,
                                                             2,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             3,
                                                             "H2S",
                                                             site,
                                                             true,
                                                             3,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             4,
                                                             "SO2",
                                                             site,
                                                             true,
                                                             4,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             5,
                                                             "CO",
                                                             site,
                                                             true,
                                                             5,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             6,
                                                             "Benzene",
                                                             site,
                                                             true,
                                                             6,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             7,
                                                             "Toluene",
                                                             site,
                                                             true,
                                                             7,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             8,
                                                             "Xylene",
                                                             site,
                                                             true,
                                                             8,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             ),
                                                         new GasTestElementInfo
                                                             (
                                                             9,
                                                             "Ammonia",
                                                             site,
                                                             true,
                                                             9,
                                                             new GasLimitRange(1),
                                                             new GasLimitRange(2),
                                                             new GasLimitRange(3),
                                                             new GasLimitRange(4),
                                                             string.Empty,
                                                             GasLimitUnit.PERCENTAGE,
                                                             false,
                                                             GasTestElementInfo.NON_OXYGEN_DECIMAL_PLACE_COUNT
                                                             )
                                                     };
            return ret;
        }

        public static GasTestElementInfo GetStandardInfoForSite(Site site)
        {
            if (site == SiteFixture.Sarnia())
            {
                return SarniaStandardGasTestElementInfos[0];
            }
            throw new Exception("Only Sarnia Is supported");
        }
    }
}
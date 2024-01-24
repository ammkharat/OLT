using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class FunctionalLocationFixture
    {
        private static IFunctionalLocationFixtureDataProvider dataProvider = new MadeUpFunctionalLocationFixtureDataProvider();

        public static void SetDataProvider(IFunctionalLocationFixtureDataProvider provider)
        {
            dataProvider = provider;
        }

        public static void UseFakeDataProvider()
        {
            dataProvider = new MadeUpFunctionalLocationFixtureDataProvider();
        }

        public static FunctionalLocation CreateNew(Site site)
        {
            FunctionalLocation floc = CreateNew(
                site, "Division-Section-Unit", PlantFixture.SarniaPlant.IdValue);

            floc.Description = "Test Site";
            return floc;
        }

        public static FunctionalLocation CreateNew(Site site, long id)
        {
            FunctionalLocation floc = CreateNew(
                site, "Division-Section-Unit", PlantFixture.SarniaPlant.IdValue);
                                          
            floc.Description = "Test Site";
            floc.Id = id;

            return floc;
        }

        public static FunctionalLocation CreateNew(Site site, string fullHierarchy)
        {
            return CreateNew(-1, site, fullHierarchy);
        }

        private static readonly Random random = new Random((int) DateTime.Now.Ticks);

        public static FunctionalLocation CreateNew(string fullHierarchy)
        {
            long id = random.Next();
            return CreateNew(id, fullHierarchy);
        }

        public static FunctionalLocation CreateNew(long flocId, string fullHierarchy)
        {
            FunctionalLocation floc = 
                new FunctionalLocation(SiteFixture.Sarnia(), fullHierarchy, PlantFixture.SarniaPlant.IdValue, string.Empty, Culture.DEFAULT_CULTURE_NAME) { Id = flocId };
            return floc;
        }

        private static FunctionalLocation CreateNew(long flocId, Site site, string fullHierarchy)
        {
            FunctionalLocation floc = new FunctionalLocation(
                site, fullHierarchy, PlantFixture.SarniaPlant.IdValue, string.Empty, Culture.DEFAULT_CULTURE_NAME) { Id = flocId };
            return floc;
        }

        public static FunctionalLocation CreateNew(long id)
        {
            FunctionalLocation location = CreateNew("ABCDEFG");
            location.Id = id;
            return location;
        }

        public static FunctionalLocation CreateNew(Site site, string fullHierarchy, long plantId)
        {
            return new FunctionalLocation(
                null,
                site,
                fullHierarchy,
                null,
                false,
                false,
                plantId,
                Culture.DEFAULT_CULTURE_NAME, FunctionalLocationSource.SAP);
        }

        public static List<FunctionalLocation> CreateNewListOfNewItems(long numberOfItems)
        {
            List<FunctionalLocation> list = new List<FunctionalLocation>();
            for (int i = 1; i <= numberOfItems; i++)
            {
                list.Add(CreateNew(-100 + i, "a-b-c" + i));
            }
            return list;
        }

        public static FunctionalLocation CreateNewSectionUnderGivenDivision(FunctionalLocation divisionFloc,
                                                                            string sectionSegment)
        {
            FunctionalLocation floc = new FunctionalLocation(divisionFloc.Site,
                                                             divisionFloc.FullHierarchy + '-' + sectionSegment,
                                                             divisionFloc.PlantId, divisionFloc.Description,
                                                             divisionFloc.Culture);

            return floc;
        }

        public static FunctionalLocation CreateNewUnitUnderGivenSection(FunctionalLocation sectionFloc,
                                                                            string unitSegment)
        {
            FunctionalLocation floc = new FunctionalLocation(sectionFloc.Site,
                                                             sectionFloc.FullHierarchy + '-' + unitSegment,
                                                             sectionFloc.PlantId, sectionFloc.Description,
                                                             sectionFloc.Culture);

            return floc;
        }

        public static FunctionalLocation CreateNewEquipment1UnderAGivenUnit(FunctionalLocation unitLevelFloc,
                                                                            string equipment1Segment)
        {
            FunctionalLocation floc = new FunctionalLocation(unitLevelFloc.Site,
                                                             unitLevelFloc.FullHierarchy + '-' + equipment1Segment,
                                                             unitLevelFloc.PlantId, unitLevelFloc.Description,
                                                             unitLevelFloc.Culture);
            return floc;
        }

        public static FunctionalLocation CreateNewEquipment2UnderGivenEquipment1Unit(FunctionalLocation equipment1Floc,
                                                                                     string equipment2Segment)
        {
            FunctionalLocation floc = new FunctionalLocation(equipment1Floc.Site,
                                                             equipment1Floc.FullHierarchy + '-' + equipment2Segment,
                                                             equipment1Floc.PlantId, equipment1Floc.Description,
                                                             equipment1Floc.Culture);
            return floc;
        }

        public static FunctionalLocation CreateNewWithPlantId(long id, long plantId, string fullHierarchy)
        {
            return new FunctionalLocation(SiteFixture.Sarnia(), fullHierarchy, plantId, null, Culture.DEFAULT_CULTURE_NAME) {Id = id};
        }

        public static FunctionalLocation CreateNewWithPlantId(long plantId)
        {
            return CreateNew(SiteFixture.Sarnia(), "SR1", plantId);
        }

        public static FunctionalLocation CreateNewWithPlantId(long id, long plantId)
        {
            FunctionalLocation floc = CreateNew(SiteFixture.Sarnia(), "SR1", plantId);
            floc.Id = id;
            return floc;
        }


        public static List<FunctionalLocation> GetListWith2Units()
        {
            return new List<FunctionalLocation>
                       {
                           GetReal_SR1_OFFS_BDOF(),
                           GetReal_SR1_OFFS_TKFM()
                       };
        }

        public static List<FunctionalLocation> GetListWith3Units()
        {
            return new List<FunctionalLocation>
                       {
                           GetReal_SR1_OFFS_BDOF(),
                           GetReal_SR1_OFFS_TKFM(),
                           GetReal_SR1_PLT3_BDP3()
                       };
        }

        public static FunctionalLocation GetAny_Division()
        {
            return GetReal_SR1();
        }

        public static FunctionalLocation GetAny_Section()
        {
            return GetReal_SR1_OFFS();
        }

        public static FunctionalLocation GetAny_Unit1()
        {
            return GetReal_SR1_OFFS_BDOF();
        }

        public static FunctionalLocation GetAny_Unit1(long id)
        {
            FunctionalLocation realSr1OffsBdof = GetReal_SR1_OFFS_BDOF();
            realSr1OffsBdof.Id = id;
            return realSr1OffsBdof;
        }

        public static FunctionalLocation GetAny_Unit2()
        {
            return GetReal_SR1_OFFS_TKFM();
        }

        public static FunctionalLocation GetAny_Unit2(long id)
        {
            FunctionalLocation realSr1OffsTkfm = GetReal_SR1_OFFS_TKFM();
            realSr1OffsTkfm.Id = id;
            return realSr1OffsTkfm;
        }

        public static FunctionalLocation GetAny_Equip1()
        {
            return GetReal_SR1_PLT3_HYDU_SMF();
        }

        public static FunctionalLocation GetAny_Equip2()
        {
            return GetReal_SR1_PLT3_HYDU_SCH_33CR001();
        }
        
        public static FunctionalLocation GetReal(string fullhierarchy)
        {
            return dataProvider.GetByFullHierarchy(fullhierarchy);
        }

        public static FunctionalLocation GetReal_FB1_FBOP_0300()
        {
            return GetReal("FB1-FBOP-0300");
        }

        public static FunctionalLocation GetReal_EX1_OPLT_TOOL()
        {
            return dataProvider.GetByFullHierarchy("EX1-OPLT-TOOL");
        }

        public static FunctionalLocation GetReal_EX1_OPLT_BLDI()
        {
            return dataProvider.GetByFullHierarchy("EX1-OPLT-BLDI");
        }

        public static FunctionalLocation GetReal_EX1_OPLT_TOOL_SWM()
        {
            return dataProvider.GetByFullHierarchy("EX1-OPLT-TOOL-SWM");
        }

        public static FunctionalLocation GetReal_SR1_PLT3_HYDU()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3-HYDU");
        }

        public static FunctionalLocation GetReal_SR1_PLT3_HYDU_SCH()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3-HYDU-SCH");
        }

        public static FunctionalLocation GetReal_SR1_PLT3_HYDU_SCH_33CR001()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3-HYDU-SCH-33CR001");
        }

        public static FunctionalLocation GetReal_SR1()
        {
            return dataProvider.GetByFullHierarchy("SR1");
        }

        public static FunctionalLocation GetReal_SR1_OFFS()
        {
            return dataProvider.GetByFullHierarchy("SR1-OFFS");
        }

        public static FunctionalLocation GetReal_SR1_OFFS_BDOF()
        {
            return dataProvider.GetByFullHierarchy("SR1-OFFS-BDOF");
        }

        public static FunctionalLocation GetReal_SR1_OFFS_BDOF_SAB()
        {
            return dataProvider.GetByFullHierarchy("SR1-OFFS-BDOF-SAB");
        }

        public static FunctionalLocation GetReal_SR1_OFFS_BDOF_SAB_02AC009()
        {
            return dataProvider.GetByFullHierarchy("SR1-OFFS-BDOF-SAB-02AC009");
        }

        public static FunctionalLocation GetReal_SR1_PLT1_AFTU_SIC()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT1-AFTU-SIC");
        }

        public static FunctionalLocation GetReal_SR1_PLT3()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3");
        }

        public static FunctionalLocation GetReal_MT1_A003_U120()
        {
            return dataProvider.GetByFullHierarchy("MT1-A003-U120");
        }

        public static FunctionalLocation GetReal_MT1()
        {
            return dataProvider.GetByFullHierarchy("MT1");
        }

        public static FunctionalLocation GetReal_MT1_A001()
        {
            return dataProvider.GetByFullHierarchy("MT1-A001");
        }

        public static FunctionalLocation GetReal_MT1_A001_U010()
        {
            return dataProvider.GetByFullHierarchy("MT1-A001-U010");
        }

        public static FunctionalLocation GetReal_MT1_A001_U010_SEG()
        {
            return dataProvider.GetByFullHierarchy("MT1-A001-U010-SEG");
        }

        public static FunctionalLocation GetReal_MT1_A001_U010_SEG_BPM0115()
        {
            return dataProvider.GetByFullHierarchy("MT1-A001-U010-SEG-BPM0115");
        }

        public static FunctionalLocation GetReal_MT1_A001_IFST_SAB_K00162()
        {
            return dataProvider.GetByFullHierarchy("MT1-A001-IFST-SAB-K00162");
        }

        public static FunctionalLocation GetReal_MT1_A002_U430()
        {
            return dataProvider.GetByFullHierarchy("MT1-A002-U430");
        }

        public static FunctionalLocation GetReal_SR1_PLT3_BDP3()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3-BDP3");
        }

        public static FunctionalLocation GetReal_SR1_PLT3_GEN3()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3-GEN3");
        }

        public static FunctionalLocation GetReal_SR1_OFFS_TKFM()
        {
            return dataProvider.GetByFullHierarchy("SR1-OFFS-TKFM");
        }

        public static FunctionalLocation GetReal_SR1_PLT3_HYDU_SMF()
        {
            return dataProvider.GetByFullHierarchy("SR1-PLT3-HYDU-SMF");
        }

        public static FunctionalLocation GetReal_DN1()
        {
            return dataProvider.GetByFullHierarchy("DN1");
        }

        public static FunctionalLocation GetReal_DN1_3003_0000()
        {
            return dataProvider.GetByFullHierarchy("DN1-3003-0000");
        }

        public static FunctionalLocation GetReal_ED1_A001_U007_SCC()
        {
            return dataProvider.GetByFullHierarchy("ED1-A001-U007-SCC");
        }

        public static FunctionalLocation GetReal_ED1_A001_U008()
        {
            return dataProvider.GetByFullHierarchy("ED1-A001-U008");
        }

        public static FunctionalLocation GetReal_ED1_A001_U007_SEG_IN0001()
        {
            return dataProvider.GetByFullHierarchy("ED1-A001-U007-SEG-IN0001");
        }

        public static FunctionalLocation GetReal_ED1_A001_U007_SEG_LP0001()
        {
            return dataProvider.GetByFullHierarchy("ED1-A001-U007-SEG-LP0001");
        }

        public static FunctionalLocation GetReal_ED1_A001_U007()
        {
            return dataProvider.GetByFullHierarchy("ED1-A001-U007");
        }

        public static FunctionalLocation GetReal_DN1_3003_0001()
        {
            return dataProvider.GetByFullHierarchy("DN1-3003-0001");
        }

        public static FunctionalLocation GetReal_UP1()
        {
            return dataProvider.GetByFullHierarchy("UP1");
        }

        public static FunctionalLocation GetReal_UP2()
        {
            return dataProvider.GetByFullHierarchy("UP2");
        }

        public static FunctionalLocation GetReal_MI1_A001_IFST()
        {
            return dataProvider.GetByFullHierarchy("MI1-A001-IFST");
        }

        public static FunctionalLocation GetReal_MI1_A001_LVFL()
        {
            return dataProvider.GetByFullHierarchy("MI1-A001-LVFL");
        }

        public interface IFunctionalLocationFixtureDataProvider
        {
            FunctionalLocation GetByFullHierarchy(string fullHierarchy);
        }

        private class MadeUpFunctionalLocationFixtureDataProvider : IFunctionalLocationFixtureDataProvider
        {
            public FunctionalLocation GetByFullHierarchy(string fullHierarchy)
            {
                string division = new FunctionalLocationHierarchy(fullHierarchy).Division;

                Site site = SiteFixture.Unknown;

                if (division == "SR1")
                {
                    site = SiteFixture.Sarnia();
                }
                else if (division == "DN1")
                {
                    site = SiteFixture.Denver();
                }
                else if (division == "FB1")
                {
                    site = SiteFixture.Firebag();
                }
                else if (division == "EX1" || division == "MN1" || division == "UP1" || division == "UP2")
                {
                    site = SiteFixture.Oilsands();
                }
                else if (division == "ED1")
                {
                    site = SiteFixture.Edmonton();
                }
                else if (division == "MT1")
                {
                    site = SiteFixture.Montreal();
                }

                FunctionalLocation floc =
                    new FunctionalLocation(site, fullHierarchy, PlantFixture.SarniaPlant.IdValue, null,
                                           Culture.DEFAULT_CULTURE_NAME)
                        {Id = -123};
                return floc;
            }
        }
    }
}
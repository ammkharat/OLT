using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class DeviationAlertDTODaoTest : AbstractDaoTest
    {
        private IDeviationAlertDTODao deviationAlertDtoDao;
        private IDeviationAlertDao deviationAlertDao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            deviationAlertDtoDao = DaoRegistry.GetDao<IDeviationAlertDTODao>();
            deviationAlertDao = DaoRegistry.GetDao<IDeviationAlertDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryByFLOCs()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("SR1-PLT3-BDP3");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("SR1-PLT3-ELP3");
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("SR1-PLT3-FSP3");

            List<FunctionalLocation> flocList = new List<FunctionalLocation> {floc1, floc2, floc3};

            List<DeviationAlertDTO> deviations = 
                deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(new RootFlocSet(flocList), new DateTime(2010, 1, 14), new DateTime(2010, 5, 16));
            
            Assert.IsTrue(deviations.Count >= 3);

            DeviationAlertDTO deviationAlertDto = deviations.Find(dto => dto.Id == 3);
            bool deviation3ExistsAndTargetTagIsNull = deviationAlertDto != null &&
                                                      deviationAlertDto.ProductionTargetTagName == null;

            // NOTE: this is just to test that the outer join works (that a row will still come back when the target tag id is null)
            Assert.IsTrue(deviation3ExistsAndTargetTagIsNull);
        }
      
        [Ignore] [Test]
        public void ShouldQueryByFLOCsForLastNDays()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("SR1-PLT3-BDP3");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("SR1-PLT3-ELP3");
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("SR1-PLT3-FSP3");

            List<FunctionalLocation> flocList = new List<FunctionalLocation> {floc1, floc2, floc3};
            RootFlocSet flocSet = new RootFlocSet(flocList);

            //1. 2010-10-15 10:15:32.000
            //2. 2010-05-18 14:19:07.820
            //3. 2010-05-18 14:19:07.820

            // Sanity check
            DateTime someDateTime = new DateTime(2010, 4, 15);
            Assert.IsTrue(someDateTime.Hour == 0 && someDateTime.Minute == 0 && someDateTime.Second == 0);

            // This time is in the database as a CreatedDateTime. It shouldn't show up.
            List<DeviationAlertDTO> deviations =
                deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    flocSet, new DateTime(2010, 10, 14), new DateTime(2010, 10, 16));

            Assert.IsEmpty(deviations);

            // This time is in the database as a StartDateTime. It should show up.
            deviations =
                deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    flocSet, new DateTime(2010, 1, 14), new DateTime(2010, 1, 16));

            Assert.IsTrue(deviations.Exists(alertDto => alertDto.Id == 1));
            Assert.IsFalse(deviations.Exists(obj => obj.Id == 2 || obj.Id == 3));

            deviations = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    flocSet, new DateTime(2010, 3, 15, 10, 15, 31), new DateTime(2010, 5, 15, 10, 15, 33));
            Assert.IsTrue(deviations.Exists(alertDto => alertDto.Id == 2));
            Assert.IsTrue(deviations.Exists(alertDto => alertDto.Id == 3));
            Assert.IsFalse(deviations.Exists(obj => obj.Id == 1));           
        }

        [Ignore] [Test]
        public void ShouldPopulateFields()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("SR1-PLT3-BDP3");
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("SR1-PLT3-FSP3");

            List<FunctionalLocation> flocList = new List<FunctionalLocation> { floc1, floc3 };

            List<DeviationAlertDTO> deviations =
                deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(new RootFlocSet(flocList), new DateTime(2010, 1, 14), new DateTime(2010, 5, 16));

            DeviationAlertDTO dto1 = deviations.Find(dto => dto.Id == 1);
            Assert.IsNotNull(dto1);

            Assert.AreEqual("Test Dev. Alert 1", dto1.RestrictionDefinitionName);
            Assert.AreEqual("Test Def. Desc. 1", dto1.RestrictionDefinitionDescription);
            
            Assert.AreEqual(100, dto1.ProductionTargetValue);
            Assert.AreEqual(50, dto1.MeasurementValue);          

            Assert.AreEqual(1, dto1.StartDateTime.Month);
            Assert.AreEqual(2, dto1.EndDateTime.Month);

            Assert.IsTrue(dto1.FunctionalLocationName.Contains("SR1-PLT3-BDP3"));

            Assert.AreEqual(1, dto1.RestrictionDefinitionId);

            Assert.AreEqual("B2", dto1.ProductionTargetTagName);
            Assert.AreEqual("KPH", dto1.ProductionTargetValueTagUnit);            

            Assert.AreEqual("A1", dto1.MeasurementTagName);
            Assert.AreEqual("MPH", dto1.MeasurementValueTagUnit);

            DeviationAlertDTO dto2 = deviations.Find(dto => dto.Id == 3);
            Assert.IsNotNull(dto2);

            Assert.IsNull(dto2.ProductionTargetTagName);
            Assert.IsNull(dto2.ProductionTargetValueTagUnit); 
            Assert.IsNull(dto2.RestrictionDefinitionDescription);
        }

        [Ignore] [Test]
        public void ShouldQueryByOverlapInDateRange()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc1 };
            RootFlocSet flocSet = new RootFlocSet(flocs);

            DateTime from = new DateTime(2010, 3, 5, 11, 20, 30);
            DateTime to = new DateTime(2010, 3, 6, 4, 15, 45);
            DeviationAlert alert1 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc1, from, to));

            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from, to);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(-1), to);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from, to.AddSeconds(1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(1), to);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from, to.AddSeconds(-1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(1), to.AddSeconds(-1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(-1), to.AddSeconds(1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(-1), to.AddSeconds(-1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(1), to.AddSeconds(1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from, from);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(-1), from);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, from.AddSeconds(-1), from.AddSeconds(-1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, to, to);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, to, to.AddSeconds(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    flocSet, to.AddSeconds(1), to.AddSeconds(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocUnitId()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            FunctionalLocation unitFloc = FunctionalLocationFixture.GetReal_DN1_3003_0000();

            DateTime from = new DateTime(2010, 1, 2);
            DateTime to = new DateTime(2010, 1, 3);
            DeviationAlert alert1 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc1, from, to));
            DeviationAlert alert2 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc2, from, to));
            DeviationAlert alert3 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc2, from, to));

            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(new List<FunctionalLocation> { floc1, unitFloc }), from, to);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(new List<FunctionalLocation> { floc1 }), from, to);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(new List<FunctionalLocation> { unitFloc }), from, to);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocsAndTimePeriod_FourthAndFifthLevels()
        {
            // I know Montreal doesn't have deviation alerts, but I don't care
            FunctionalLocation unitFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010();
            FunctionalLocation equipment1Floc = FunctionalLocationFixture.GetReal_MT1_A001_U010_SEG();
            FunctionalLocation equipment2Floc = FunctionalLocationFixture.GetReal_MT1_A001_U010_SEG_BPM0115();
            
            DateTime from = new DateTime(2010, 1, 2);
            DateTime to = new DateTime(2010, 1, 3);
            DeviationAlert alert1 = deviationAlertDao.Insert(DeviationAlertFixture.Create(unitFloc, from, to));
            DeviationAlert alert2 = deviationAlertDao.Insert(DeviationAlertFixture.Create(equipment1Floc, from, to));
            DeviationAlert alert3 = deviationAlertDao.Insert(DeviationAlertFixture.Create(equipment2Floc, from, to));

            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(unitFloc), from, to);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(equipment1Floc), from, to);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(equipment2Floc), from, to);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldPopulateStatus()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal("SR1-PLT3-BDP3");
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal("SR1-PLT3-ELP3");
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("SR1-PLT3-FSP3");

            List<FunctionalLocation> flocList = new List<FunctionalLocation> { floc1, floc2, floc3 };

            List<DeviationAlertDTO> alerts = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(new RootFlocSet(flocList), new DateTime(2010, 1, 14), new DateTime(2010, 5, 16));

            {
                DeviationAlertDTO deviationAlert = alerts.Find(dto => dto.Id == 1);
                Assert.AreEqual(DeviationAlertStatus.Responded, deviationAlert.Status);
            }
            {
                DeviationAlertDTO deviationAlert = alerts.Find(dto => dto.Id == 2);
                Assert.AreEqual(DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation, deviationAlert.Status);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDivisionOrSection()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.CreateNew("a");
            flocDao.Insert(floc1);

            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("a-b");
            flocDao.Insert(floc2);

            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("a-b-c");
            flocDao.Insert(floc3);

            FunctionalLocation floc4 = FunctionalLocationFixture.CreateNew("a-b-c-d");
            flocDao.Insert(floc4);

            FunctionalLocation floc5 = FunctionalLocationFixture.CreateNew("a-b-c-d-e");
            flocDao.Insert(floc5);

            DateTime from = new DateTime(2001, 1, 1, 10, 00, 00);
            DateTime to = new DateTime(2001, 1, 1, 11, 00, 00);

            DeviationAlert alert1 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc1, from, to, to));
            DeviationAlert alert2 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc2, from, to, to));
            DeviationAlert alert3 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc3, from, to, to));
            DeviationAlert alert4 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc4, from, to, to));
            DeviationAlert alert5 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc5, from, to, to));

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc4 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc5 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndTimePeriod(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDivisionOrSectionWithOverlapInDateRange()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.CreateNew("a");
            flocDao.Insert(floc1);

            FunctionalLocation floc2 = FunctionalLocationFixture.CreateNew("a-b");
            flocDao.Insert(floc2);

            FunctionalLocation floc3 = FunctionalLocationFixture.CreateNew("a-b-c");
            flocDao.Insert(floc3);

            FunctionalLocation floc4 = FunctionalLocationFixture.CreateNew("a-b-c-d");
            flocDao.Insert(floc4);

            FunctionalLocation floc5 = FunctionalLocationFixture.CreateNew("a-b-c-d-e");
            flocDao.Insert(floc5);

            DateTime from = new DateTime(2001, 1, 1, 10, 00, 00);
            DateTime to = new DateTime(2001, 1, 1, 11, 00, 00);

            DeviationAlert alert1 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc1, from, to, to));
            DeviationAlert alert2 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc2, from, to, to));
            DeviationAlert alert3 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc3, from, to, to));
            DeviationAlert alert4 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc4, from, to, to));
            DeviationAlert alert5 = deviationAlertDao.Insert(DeviationAlertFixture.Create(floc5, from, to, to));

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc4 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc5 };
                List<DeviationAlertDTO> results = deviationAlertDtoDao.QueryByFunctionalLocationsAndOverlapInDateRange(
                    new RootFlocSet(functionalLocations), from.SubtractDays(1), to.AddDays(1));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
        }

    }
}
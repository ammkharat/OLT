using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class LabAlertDTODaoTest : AbstractDaoTest
    {
        private ILabAlertDao labAlertDao;
        private ILabAlertDefinitionDao definitionDao;
        private ILabAlertDTODao dtoDao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            labAlertDao = DaoRegistry.GetDao<ILabAlertDao>();
            definitionDao = DaoRegistry.GetDao<ILabAlertDefinitionDao>();
            dtoDao = DaoRegistry.GetDao<ILabAlertDTODao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }


        [Ignore] [Test]
        public void ShouldQueryByDateRange()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            LabAlert alert1 = Insert(floc1, new DateTime(2020, 1, 1), new DateTime(2010, 1, 1));
            LabAlert alert2 = Insert(floc1, new DateTime(2020, 1, 1), new DateTime(2010, 2, 1));
            
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 1, 1), null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 1), null), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 2), null), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, new Date(2010, 2, 1)), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, new Date(2010, 1, 1)), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, new Date(2009, 12, 31)), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 1, 1), new Date(2010, 2, 1)), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 2), new Date(2010, 2, 2)), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocAndReturnMatchesInSameFLocTree()
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

            FunctionalLocation floc6 = FunctionalLocationFixture.CreateNew("Z");
            flocDao.Insert(floc6);
            FunctionalLocation floc7 = FunctionalLocationFixture.CreateNew("a-Z");
            flocDao.Insert(floc7);
            FunctionalLocation floc8 = FunctionalLocationFixture.CreateNew("a-b-Z");
            flocDao.Insert(floc8);
            FunctionalLocation floc9 = FunctionalLocationFixture.CreateNew("a-b-c-Z");
            flocDao.Insert(floc9);
            FunctionalLocation floc10 = FunctionalLocationFixture.CreateNew("a-b-c-d-Z");
            flocDao.Insert(floc10);

            LabAlert alert1 = Insert(floc1);
            LabAlert alert2 = Insert(floc2);
            LabAlert alert3 = Insert(floc3);
            LabAlert alert4 = Insert(floc4);
            LabAlert alert5 = Insert(floc5);

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc4 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc5 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc6 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc7 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc8 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc9 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc10 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert5.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByStatus()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            LabAlert alert1 = Insert(floc1, LabAlertStatus.DataUnavailable);
            LabAlert alert2 = Insert(floc1, LabAlertStatus.NotResponded);
            LabAlert alert3 = Insert(floc1, LabAlertStatus.Responded);

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null),
                    null);
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null),
                    new List<LabAlertStatus>(LabAlertStatus.All));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null),
                    new List<LabAlertStatus>{LabAlertStatus.DataUnavailable, LabAlertStatus.NotResponded, LabAlertStatus.Responded});
                Assert.IsTrue(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null),
                    new List<LabAlertStatus> { LabAlertStatus.NotResponded, LabAlertStatus.Responded });
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null),
                    new List<LabAlertStatus> { LabAlertStatus.Responded });
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDTO> results = dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null),
                    new List<LabAlertStatus>());
                Assert.IsFalse(results.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == alert3.Id));
            }
        }

        private LabAlert Insert(FunctionalLocation floc)
        {
            return Insert(floc, new DateTime(2011, 1, 2), new DateTime(2011, 1, 2));
        }

        private LabAlert Insert(FunctionalLocation floc, LabAlertStatus status)
        {
            return Insert(floc, new DateTime(2011, 1, 2), new DateTime(2011, 1, 2), status);
        }

        private LabAlert Insert(FunctionalLocation floc, DateTime lastModifiedDateTime, DateTime createdDateTime)
        {
            return Insert(floc, lastModifiedDateTime, createdDateTime, LabAlertStatus.NotResponded);
        }

        private LabAlert Insert(FunctionalLocation floc, DateTime lastModifiedDateTime, DateTime createdDateTime, LabAlertStatus status)
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            LabAlertDefinition insertedLabAlertDefinition = definitionDao.Insert(definition);

            LabAlert alert = LabAlertFixture.CreateAlert(new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), lastModifiedDateTime, createdDateTime);
            alert.LabAlertDefinitionId = insertedLabAlertDefinition.IdValue;
            alert.FunctionalLocation = floc;
            alert.Status = status;
            alert = labAlertDao.Insert(alert);

            return alert;
        }
    }
}

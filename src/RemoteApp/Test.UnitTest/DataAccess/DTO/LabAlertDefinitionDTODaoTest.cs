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
    public class LabAlertDefinitionDTODaoTest : AbstractDaoTest
    {
        private ILabAlertDefinitionDao domainObjectDao;
        private ILabAlertDefinitionDTODao dao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            domainObjectDao = DaoRegistry.GetDao<ILabAlertDefinitionDao>();
            dao = DaoRegistry.GetDao<ILabAlertDefinitionDTODao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeletedWhenQueryingByFlocId()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            LabAlertDefinition definition1 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc1));
            LabAlertDefinition definition2 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc1));

            domainObjectDao.Remove(definition1);

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRange()
        { 
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            LabAlertDefinition definition1 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition("a", floc1, new DateTime(2020, 1, 1), new DateTime(2010, 1, 1)));
            LabAlertDefinition definition2 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition("b", floc1, new DateTime(2020, 1, 1), new DateTime(2010, 2, 1)));
            
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 1, 1), null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 1), null));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 2), null));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, new Date(2010, 2, 1)));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, new Date(2010, 1, 1)));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, new Date(2009, 12, 31)));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 1, 1), new Date(2010, 2, 1)));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 2), new Date(2010, 2, 2)));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
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

            LabAlertDefinition definition1 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc1));
            LabAlertDefinition definition2 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc2));
            LabAlertDefinition definition3 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc3));
            LabAlertDefinition definition4 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc4));
            LabAlertDefinition definition5 = domainObjectDao.Insert(LabAlertDefinitionFixture.CreateDefinition(floc5));

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc4 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc5 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc6 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc7 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc8 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc9 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition5.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc10 };
                List<LabAlertDefinitionDTO> results = dao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition3.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == definition4.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == definition5.Id));
            }
        }
    }
}

using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class FunctionalLocationDaoTest : AbstractDaoTest
    {
        private IFunctionalLocationDao dao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup() {}
        
        [Ignore] [Test]
        public void ShouldReturnAPopulatedFunctionalLocation()
        {
            FunctionalLocation expected = FunctionalLocationFixture.GetReal_SR1();
            FunctionalLocation actual = dao.QueryById(expected.IdValue);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Site);
            Assert.IsNotNull(actual.Id);
        }
        
        [Ignore] [Test]
        public void AddNewShouldHandle50UnicodeCharacters()
        {
            string unicode50CharString = "testing-àÀâäæçéèêëîïôœùûü«€ÂÄÆÇÉÈÊËÎÏÔŒÙÛÜ»123456A";

            FunctionalLocation functionalLocation = FunctionalLocationFixture.CreateNew("NEW-FLOC");
            functionalLocation.Description = unicode50CharString;
            FunctionalLocation insertedFloc = dao.Insert(functionalLocation);

            FunctionalLocation queriedFloc = dao.QueryById(insertedFloc.IdValue);
            Assert.AreEqual(unicode50CharString, queriedFloc.Description);
        }

        [Ignore] [Test]
        public void RemoveShouldRemoveTheFunctionalLocation()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.CreateNew("SR1-PLT3-HYDU-SCH-NEW");
            dao.Insert(functionalLocation);
            Assert.IsNotNull(functionalLocation.Id);
            FunctionalLocation insertedFunctionalLocation = dao.QueryById(functionalLocation.IdValue);
            Assert.IsFalse(insertedFunctionalLocation.Deleted);
            dao.RemoveAndAllDescendants(insertedFunctionalLocation);
            FunctionalLocation newFunctionalLocation = dao.QueryById(functionalLocation.IdValue);
            Assert.IsTrue(newFunctionalLocation.Deleted);
        }

        [Ignore] [Test]
        public void UndoRemoveShouldUndoTheRemovalOfTheFunctionalLocation()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.CreateNew("SR1-OFFS-BDOF-ABCDE");
            dao.Insert(functionalLocation);
            dao.RemoveAndAllDescendants(functionalLocation);
            functionalLocation = dao.QueryById(functionalLocation.IdValue);
            Assert.IsTrue(functionalLocation.Deleted);
            dao.UndoRemove(functionalLocation);
            functionalLocation = dao.QueryById(functionalLocation.IdValue);
            Assert.IsFalse(functionalLocation.Deleted);
        }

        [Ignore] [Test]
        public void AddNewShouldReturnTheSameFunctionalLocation()
        {
            FunctionalLocation toInsertfunctionalLocation = FunctionalLocationFixture.CreateNew("SR1-OFFS-BDOF-ABCDE");
            dao.Insert(toInsertfunctionalLocation);
            Assert.IsNotNull(toInsertfunctionalLocation.Id);
            FunctionalLocation insertedFunctionalLocation = dao.QueryById(toInsertfunctionalLocation.IdValue);
            Assert.AreEqual(insertedFunctionalLocation.Description, toInsertfunctionalLocation.Description);
            Assert.AreEqual(insertedFunctionalLocation.Section, toInsertfunctionalLocation.Section);
            Assert.AreEqual(insertedFunctionalLocation.Equipment1, toInsertfunctionalLocation.Equipment1);
            Assert.AreEqual(insertedFunctionalLocation.Equipment2, toInsertfunctionalLocation.Equipment2);
            Assert.AreEqual(insertedFunctionalLocation.Division, toInsertfunctionalLocation.Division);
            Assert.AreEqual(insertedFunctionalLocation.Site, toInsertfunctionalLocation.Site);
            Assert.AreEqual(insertedFunctionalLocation.Unit, toInsertfunctionalLocation.Unit);
            Assert.AreEqual(insertedFunctionalLocation.Id, toInsertfunctionalLocation.Id);
            Assert.AreEqual(insertedFunctionalLocation.FullHierarchy, toInsertfunctionalLocation.FullHierarchy);
        }

        [Ignore] [Test]
        public void UpdateShouldSaveUpdatedFunctionalLocation()
        {
            FunctionalLocation toUpdatefunctionalLocation = FunctionalLocationFixture.CreateNew("SR1-OFFS-BDOF-ABCDE");
            //insert a functionallocation
            dao.Insert(toUpdatefunctionalLocation);
            //grab it again
            toUpdatefunctionalLocation = dao.QueryById(toUpdatefunctionalLocation.IdValue);
            toUpdatefunctionalLocation.Description = "Updated Description";
            dao.Update(toUpdatefunctionalLocation);
            Assert.AreEqual(toUpdatefunctionalLocation.Description, "Updated Description");
            FunctionalLocation updatedFunctionalLocation = dao.QueryById(toUpdatefunctionalLocation.IdValue);
            Assert.AreEqual(toUpdatefunctionalLocation.Description, updatedFunctionalLocation.Description);
        }

        [Ignore] [Test]
        public void UpdateShouldHandle50UnicodeCharacters()
        {
            const string unicode50CharString = "testing-àÀâäæçéèêëîïôœùûü«€ÂÄÆÇÉÈÊËÎÏÔŒÙÛÜ»123456A";

            FunctionalLocation originalFloc = FunctionalLocationFixture.CreateNew("SR1-OFFS-BDOF-ABCDE");           
            dao.Insert(originalFloc);
            
            {
                FunctionalLocation insertedFloc = dao.QueryById(originalFloc.IdValue);
                insertedFloc.Description = unicode50CharString;
                dao.Update(insertedFloc);                
            }

            {
                FunctionalLocation updatedFloc = dao.QueryById(originalFloc.IdValue);
                Assert.AreEqual(unicode50CharString, updatedFloc.Description);                
            }
        }
        
        [Ignore] [Test]
        public void ShouldBeAbleToGetTheSectionStringForAUnitFunctionalLocation()
        {
            const string expectedSectionFromDatabase = "PLT3";
            FunctionalLocation unitFunctionalLocation = dao.QueryByFullHierarchy("SR1-PLT3-BDP3", Site.SARNIA_ID);
            // test is invalid unless the FLOC is of type unit
            Assert.AreEqual(FunctionalLocationType.Level3, unitFunctionalLocation.Type);
            Assert.AreEqual(expectedSectionFromDatabase, unitFunctionalLocation.Section);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToGetTheSectionStringForAnEquipment1FunctionalLocation()
        {
            const string expectedSectionFromDatabase = "PLT3";
            FunctionalLocation unitFunctionalLocation = dao.QueryByFullHierarchy("SR1-PLT3-HYDU-SCH", Site.SARNIA_ID);
            // test is invalid unless the FLOC is of type equipment1
            Assert.AreEqual(FunctionalLocationType.Level4, unitFunctionalLocation.Type);
            Assert.AreEqual(expectedSectionFromDatabase, unitFunctionalLocation.Section);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToGetTheSectionStringForAnEquipment2FunctionalLocation()
        {
            const string expectedSectionFromDatabase = "PLT3";
            FunctionalLocation unitFunctionalLocation = dao.QueryByFullHierarchy("SR1-PLT3-HYDU-SMP-33P001A", Site.SARNIA_ID);
            // test is invalid unless the FLOC is of type equipment2
            Assert.AreEqual(FunctionalLocationType.Level5, unitFunctionalLocation.Type);
            Assert.AreEqual(expectedSectionFromDatabase, unitFunctionalLocation.Section);
        }

        [Ignore] [Test]
        public void ShouldGetCorrespondingSectionFunctionalLocationFromUnitFunctionalLocation()
        {
            FunctionalLocation unitFunctionalLocation = dao.QueryByFullHierarchy("SR1-PLT3-BDP3", Site.SARNIA_ID);
            Assert.AreEqual(FunctionalLocationType.Level3, unitFunctionalLocation.Type);
            FunctionalLocation sectionFunctionalLocation =
                dao.QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(unitFunctionalLocation);
            Assert.AreEqual(unitFunctionalLocation.Section, sectionFunctionalLocation.Section);
            Assert.AreEqual(FunctionalLocationType.Level2, sectionFunctionalLocation.Type);
        }

        [Ignore] [Test]
        public void ShouldGetCorrespondingSectionFunctionalLocationFromEquipment1FunctionalLocation()
        {
            FunctionalLocation unitFunctionalLocation = dao.QueryByFullHierarchy("SR1-PLT3-HYDU-SCH", Site.SARNIA_ID);
            Assert.AreEqual(FunctionalLocationType.Level4, unitFunctionalLocation.Type);
            FunctionalLocation sectionFunctionalLocation =
                dao.QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(unitFunctionalLocation);
            Assert.AreEqual(unitFunctionalLocation.Section, sectionFunctionalLocation.Section);
            Assert.AreEqual(FunctionalLocationType.Level2, sectionFunctionalLocation.Type);
        }

        [Ignore] [Test]
        public void ShouldGetCorrespondingSectionFunctionalLocationFromEquipment2FunctionalLocation()
        {
            FunctionalLocation unitFunctionalLocation = dao.QueryByFullHierarchy("SR1-PLT3-HYDU-SMP-33P001A", Site.SARNIA_ID);
            Assert.AreEqual(FunctionalLocationType.Level5, unitFunctionalLocation.Type);
            FunctionalLocation sectionFunctionalLocation =
                dao.QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(unitFunctionalLocation);
            Assert.AreEqual(unitFunctionalLocation.Section, sectionFunctionalLocation.Section);
            Assert.AreEqual(FunctionalLocationType.Level2, sectionFunctionalLocation.Type);
        }

        [Ignore] [Test]
        public void ShouldNotGetDeletedSectionWhenQueryingByChildFloc()
        {
            FunctionalLocation child = dao.QueryByFullHierarchy("MR1-MOBL-FORK", Site.MACKAY_ID);
            Assert.IsNotNull(child);
            FunctionalLocation parentSection = dao.QueryByFullHierarchy("MR1-MOBL", Site.MACKAY_ID);
            Assert.IsNotNull(parentSection);

            {
                FunctionalLocation queryResult = dao.QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(child);
                Assert.IsNotNull(queryResult);
            }

            dao.RemoveAndAllDescendants(parentSection);

            {
                FunctionalLocation queryResult = dao.QueryParentSectionFunctionalLocationByChildLevelFunctionalLocation(child);
                Assert.IsNull(queryResult);
            }
        }

        [Ignore] [Test]
        public void ShouldGetCorrespondingSectionFunctionalLocationFromDivisionFunctionalLocation()
        {
            FunctionalLocation divisionFunctionalLocation = dao.QueryByFullHierarchy("SR1", Site.SARNIA_ID);
            Assert.AreEqual(FunctionalLocationType.Level1, divisionFunctionalLocation.Type);
            Assert.AreEqual(FunctionalLocationType.Level1, divisionFunctionalLocation.Type);
            List<FunctionalLocation> sectionFunctionLocations =
                dao.QueryChildSectionFunctionalLocationByParentDivisionFunctionalLocations(divisionFunctionalLocation);
            Assert.AreEqual(5, sectionFunctionLocations.Count);
            foreach (FunctionalLocation functionalLocation in sectionFunctionLocations)
            {
                Assert.AreEqual(FunctionalLocationType.Level2, functionalLocation.Type);
            }
        }

        [Ignore] [Test]
        public void QueryByFullHierarchyShouldReturnFunctionalLocation()
        {
            FunctionalLocation functionalLocation =
                FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();
            string fullHierarchy = functionalLocation.FullHierarchy;
            FunctionalLocation returnedFunctionalLocation = dao.QueryByFullHierarchy(fullHierarchy, Site.SARNIA_ID);
            Assert.AreEqual(functionalLocation.Id, returnedFunctionalLocation.Id);
        }

        [Ignore] [Test]
        public void QueryByFullHierarchySiteIdShouldReturnFunctionalLocation()
        {
            FunctionalLocation functionalLocation =
                FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();
            string fullHierarchy = functionalLocation.FullHierarchy;
            FunctionalLocation returnedFunctionalLocation = dao.QueryByFullHierarchy(fullHierarchy, functionalLocation.Site.IdValue);
            Assert.AreEqual(functionalLocation.Id, returnedFunctionalLocation.Id);
        }

        [Ignore] [Test]
        public void QueryByFullHierarchyShouldReturnNullForNonExistantRecord()
        {
            const string fullHierarchy = "xx-xx-xx-xx";
            FunctionalLocation returnedFunctionalLocation = dao.QueryByFullHierarchy(fullHierarchy, Site.SARNIA_ID);
            Assert.IsNull(returnedFunctionalLocation);
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeletedWhenQueryingByFullHierarchy()
        {
            const string fullHierarchy = "MR1-MOBL-FORK";
            FunctionalLocation floc;

            {
                FunctionalLocation result = dao.QueryByFullHierarchy(fullHierarchy, Site.MACKAY_ID);
                Assert.IsNotNull(result);
                floc = result;
            }
            {
                FunctionalLocation result = dao.QueryByFullHierarchy(fullHierarchy, SiteFixture.MacKayRiver().IdValue);
                Assert.IsNotNull(result);
            }
            {
                FunctionalLocation result = dao.QueryByFullHierarchyIncludeDeleted(fullHierarchy, SiteFixture.MacKayRiver().IdValue);
                Assert.IsNotNull(result);
            }

            dao.RemoveAndAllDescendants(floc);

            {
                FunctionalLocation result = dao.QueryByFullHierarchy(fullHierarchy, Site.MACKAY_ID);
                Assert.IsNull(result);
            }
            {
                FunctionalLocation result = dao.QueryByFullHierarchy(fullHierarchy, SiteFixture.MacKayRiver().IdValue);
                Assert.IsNull(result);
            }
            {
                FunctionalLocation result = dao.QueryByFullHierarchyIncludeDeleted(fullHierarchy, SiteFixture.MacKayRiver().IdValue);
                Assert.IsNotNull(result);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryFunctionalLocationsByWorkAssignmentIdAndNotReturnDeleted()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            workAssignment.FunctionalLocations.Clear();
            workAssignment = workAssignmentDao.Insert(workAssignment);

            workAssignment.FunctionalLocations.Add(floc1);
            workAssignment.FunctionalLocations.Add(floc2);
            workAssignmentDao.UpdateFunctionalLocations(workAssignment);

            List<FunctionalLocation> originalList = dao.QueryByWorkAssignmentId(workAssignment.IdValue);
            Assert.AreEqual(2, originalList.Count);
            Assert.IsTrue(originalList.Exists(obj => obj.Id == floc1.Id));
            Assert.IsTrue(originalList.Exists(obj => obj.Id == floc2.Id));

            dao.RemoveAndAllDescendants(originalList.Find(obj => obj.Id == floc1.Id));

            List<FunctionalLocation> afterDeleteList = dao.QueryByWorkAssignmentId(workAssignment.IdValue);
            Assert.AreEqual(1, afterDeleteList.Count);
            Assert.IsFalse(afterDeleteList.Exists(obj => obj.Id == floc1.Id));
            Assert.IsTrue(afterDeleteList.Exists(obj => obj.Id == floc2.Id));
        }

        [Ignore] [Test]
        public void InsertShouldUpdateTheIdByReference()
        {
            FunctionalLocation floc = FunctionalLocationFixture.CreateNew(SiteFixture.Sarnia(), "XXX-YYYY-ZZZZ", 4000);
            dao.Insert(floc);
            
            Assert.IsNotNull(floc.Id);
            Assert.IsTrue(floc.IdValue > 0);
        }
    }
}

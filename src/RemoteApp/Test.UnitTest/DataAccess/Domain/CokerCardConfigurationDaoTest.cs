using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class CokerCardConfigurationDaoTest : AbstractDaoTest
    {
        private ICokerCardConfigurationDao configurationDao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            configurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_UP1();
            long idOfInsertedConfiguration;

            {                
                CokerCardConfiguration cardConfiguration = CokerCardConfigurationFixture.CreateForInsert(floc);
                idOfInsertedConfiguration = configurationDao.Insert(cardConfiguration).IdValue;                
            }

            {
                CokerCardConfiguration cardConfigurationFromFixture = CokerCardConfigurationFixture.CreateForInsert(floc);
                CokerCardConfiguration cokerCardConfigurationFromDB = configurationDao.QueryById(idOfInsertedConfiguration);
                Assert.IsNotNull(cokerCardConfigurationFromDB);

                Assert.AreEqual(cardConfigurationFromFixture.Name, cokerCardConfigurationFromDB.Name);

                foreach (CokerCardConfigurationDrum drumFromFixture in cardConfigurationFromFixture.Drums)
                {
                    CokerCardConfigurationDrum drumFromDB = 
                        cokerCardConfigurationFromDB.Drums.Find(d => d.Name.Equals(drumFromFixture.Name));

                    Assert.IsNotNull(drumFromDB);
                    Assert.AreEqual(drumFromFixture.DisplayOrder, drumFromDB.DisplayOrder);
                }

                foreach (CokerCardConfigurationCycleStep stepFromFixture in cardConfigurationFromFixture.Steps)
                {
                    CokerCardConfigurationCycleStep stepFromDB = 
                        cokerCardConfigurationFromDB.Steps.Find(d => d.Name.Equals(stepFromFixture.Name));

                    Assert.IsNotNull(stepFromDB);
                    Assert.AreEqual(stepFromFixture.DisplayOrder, stepFromDB.DisplayOrder);
                }
            }
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_UP1();
            long idOfInsertedConfiguration;
            CokerCardConfiguration insertedCokerCardConfiguration = null;
            // Put it in
            {
                CokerCardConfiguration cardConfiguration = CokerCardConfigurationFixture.CreateForInsert(floc);
                insertedCokerCardConfiguration = configurationDao.Insert(cardConfiguration);
                idOfInsertedConfiguration = insertedCokerCardConfiguration.IdValue;
            }

            // Sanity check - make sure it's there
            {
                List<CokerCardConfiguration> configurationsForSite = configurationDao.QueryCokerCardConfigurationsBySite(floc.Site.IdValue);
                Assert.IsTrue(configurationsForSite.Exists(c => c.IdValue == idOfInsertedConfiguration));
            }

            // Shouldn't be in the list now
            {
                configurationDao.Remove(insertedCokerCardConfiguration);
                List<CokerCardConfiguration> configurationsForSite = configurationDao.QueryCokerCardConfigurationsBySite(floc.Site.IdValue);
                Assert.IsFalse(configurationsForSite.Exists(c => c.IdValue == idOfInsertedConfiguration));
            }
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_UP1();
            FunctionalLocation newFloc = FunctionalLocationFixture.GetReal_UP2();
            long idOfInsertedConfiguration;

            {
                CokerCardConfiguration cardConfiguration = CokerCardConfigurationFixture.CreateForInsert(floc);
                idOfInsertedConfiguration = configurationDao.Insert(cardConfiguration).IdValue;
            }

            const string newName = "Zzyzx";

            {               
                CokerCardConfiguration cokerCardConfigurationFromDB = configurationDao.QueryById(idOfInsertedConfiguration);                
                
                cokerCardConfigurationFromDB.Name = newName;
                cokerCardConfigurationFromDB.FunctionalLocation = newFloc;

                cokerCardConfigurationFromDB.Drums.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.CurrentCulture));
                Assert.AreEqual("DR1", cokerCardConfigurationFromDB.Drums[0].Name); // Just checking.
                cokerCardConfigurationFromDB.Drums[0].Name = "DR1-Changed";
                cokerCardConfigurationFromDB.Drums[1].Name = "DR2-Changed";
                cokerCardConfigurationFromDB.Drums[2].Name = "DR3-Changed";

                configurationDao.Update(cokerCardConfigurationFromDB);               
            }

            {
                CokerCardConfiguration cokerCardConfigurationFromDBPostUpdate = configurationDao.QueryById(idOfInsertedConfiguration);

                Assert.AreEqual(newName, cokerCardConfigurationFromDBPostUpdate.Name);
                Assert.AreEqual(newFloc.IdValue, cokerCardConfigurationFromDBPostUpdate.FunctionalLocation.IdValue);

                cokerCardConfigurationFromDBPostUpdate.Drums.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.CurrentCulture));
                Assert.AreEqual("DR1-Changed", cokerCardConfigurationFromDBPostUpdate.Drums[0].Name);
                Assert.AreEqual("DR2-Changed", cokerCardConfigurationFromDBPostUpdate.Drums[1].Name);
                Assert.AreEqual("DR3-Changed", cokerCardConfigurationFromDBPostUpdate.Drums[2].Name);
            }
        }
      
        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {            
            List<CokerCardConfiguration> configurations = configurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue);
            
            Assert.IsTrue(configurations.Count > 0);

            foreach (CokerCardConfiguration configuration in configurations)
            {
                Assert.AreEqual(SiteFixture.Oilsands().IdValue, configuration.FunctionalLocation.Site.IdValue);
            }                                    
        }

        [Ignore] [Test]
        public void ShouldQueryDistinctCokerCardConfigurationNamesBySite()
        {
            // For Oilsands make 3 configs in DB. Two with same name and one marked as deleted.
            CokerCardConfiguration up1Config = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(new ExactFlocSet(FunctionalLocationFixture.GetReal_UP1()))[0];
            CokerCardConfiguration up2Config = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(new ExactFlocSet(FunctionalLocationFixture.GetReal_UP2()))[0];

            string up1ConfigurationName = up1Config.Name;
            string up2ConfigurationName = up2Config.Name;

            // Mark existing config as deleted. Deleted configuration names should be shown to the users.
            configurationDao.Remove(up1Config);

            // Insert a config for Oilsands with the same name as one already in the DB.
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_UP1();
            CokerCardConfiguration cardConfiguration = CokerCardConfigurationFixture.CreateForInsert(floc);
            cardConfiguration.Name = up1ConfigurationName;
            configurationDao.Insert(cardConfiguration);

            // Insert one for Sarnia (should not come back)
            floc = FunctionalLocationFixture.GetReal_SR1();
            cardConfiguration = CokerCardConfigurationFixture.CreateForInsert(floc);
            configurationDao.Insert(cardConfiguration);

            List<string> distinctNames = configurationDao.QueryDistinctCokerCardConfigurationNamesBySite(SiteFixture.Oilsands());

            Assert.IsTrue(distinctNames.Count == 2);
            Assert.Contains(up1ConfigurationName, distinctNames);
            Assert.Contains(up2ConfigurationName, distinctNames);
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateWorkAssignment()
        {
            WorkAssignment assignment1 = CreateWorkAssignment();
            WorkAssignment assignment2 = CreateWorkAssignment();
            WorkAssignment assignment3 = CreateWorkAssignment();

            CokerCardConfiguration configuration = CokerCardConfigurationFixture.CreateForInsert(
                FunctionalLocationFixture.GetReal_UP1());

            configuration.WorkAssignments.Clear();
            configuration.WorkAssignments.Add(assignment1);
            configuration.WorkAssignments.Add(assignment2);

            configuration = configurationDao.Insert(configuration);

            {
                CokerCardConfiguration requeried = configurationDao.QueryById(configuration.IdValue);
                Assert.AreEqual(2, requeried.WorkAssignments.Count);
                Assert.IsTrue(requeried.WorkAssignments.Exists(obj => obj.Id == assignment1.Id));
                Assert.IsTrue(requeried.WorkAssignments.Exists(obj => obj.Id == assignment2.Id));
            }

            configuration.WorkAssignments.RemoveAt(0);
            configuration.WorkAssignments.Add(assignment3);

            configurationDao.Update(configuration);

            {
                CokerCardConfiguration requeried = configurationDao.QueryById(configuration.IdValue);
                Assert.AreEqual(2, requeried.WorkAssignments.Count);
                Assert.IsTrue(requeried.WorkAssignments.Exists(obj => obj.Id == assignment2.Id));
                Assert.IsTrue(requeried.WorkAssignments.Exists(obj => obj.Id == assignment3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeletedWorkAssignment()
        {
            WorkAssignment assignment = CreateWorkAssignment();

            CokerCardConfiguration configuration = CokerCardConfigurationFixture.CreateForInsert(
                FunctionalLocationFixture.GetReal_UP1());

            configuration.WorkAssignments.Clear();
            configuration.WorkAssignments.Add(assignment);

            configuration = configurationDao.Insert(configuration);

            {
                CokerCardConfiguration requeried = configurationDao.QueryById(configuration.IdValue);
                Assert.AreEqual(1, requeried.WorkAssignments.Count);
                Assert.IsTrue(requeried.WorkAssignments.Exists(obj => obj.Id == assignment.Id));
            }

            workAssignmentDao.Remove(assignment);

            {
                CokerCardConfiguration requeried = configurationDao.QueryById(configuration.IdValue);
                Assert.AreEqual(0, requeried.WorkAssignments.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignment()
        {
            WorkAssignment assignment1 = CreateWorkAssignment();
            WorkAssignment assignment2 = CreateWorkAssignment();
            WorkAssignment assignment3 = CreateWorkAssignment();

            CokerCardConfiguration configuration1 = CokerCardConfigurationFixture.CreateForInsert(FunctionalLocationFixture.GetReal_DN1());
            configuration1.WorkAssignments.Clear();
            configuration1.WorkAssignments.Add(assignment1);
            configuration1.WorkAssignments.Add(assignment2);
            configuration1 = configurationDao.Insert(configuration1);

            CokerCardConfiguration configuration2 = CokerCardConfigurationFixture.CreateForInsert(FunctionalLocationFixture.GetReal_SR1());
            configuration2.WorkAssignments.Clear();
            configuration2.WorkAssignments.Add(assignment2);
            configuration2.WorkAssignments.Add(assignment3);
            configuration2 = configurationDao.Insert(configuration2);

            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment1);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(obj => obj == configuration1.IdValue));
            }
            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment2);
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(obj => obj == configuration1.IdValue));
                Assert.IsTrue(results.Exists(obj => obj == configuration2.IdValue));
            }
            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment3);
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(obj => obj == configuration2.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignment_NotReturnDeletedConfiguration()
        {
            WorkAssignment assignment = CreateWorkAssignment();

            CokerCardConfiguration configuration = CokerCardConfigurationFixture.CreateForInsert(
                FunctionalLocationFixture.GetReal_UP1());

            configuration.WorkAssignments.Clear();
            configuration.WorkAssignments.Add(assignment);

            configuration = configurationDao.Insert(configuration);

            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment);
                Assert.AreEqual(1, results.Count);
                Assert.AreEqual(configuration.IdValue, results[0]);
            }

            configurationDao.Remove(configuration);

            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment);
                Assert.AreEqual(0, results.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignment_NotReturnDeletedWorkAssignment()
        {
            WorkAssignment assignment = CreateWorkAssignment();

            CokerCardConfiguration configuration = CokerCardConfigurationFixture.CreateForInsert(
                FunctionalLocationFixture.GetReal_UP1());

            configuration.WorkAssignments.Clear();
            configuration.WorkAssignments.Add(assignment);

            configuration = configurationDao.Insert(configuration);

            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment);
                Assert.AreEqual(1, results.Count);
                Assert.AreEqual(configuration.IdValue, results[0]);
            }

            workAssignmentDao.Remove(assignment);

            {
                List<long> results = configurationDao.QueryCokerCardConfigurationByWorkAssignment(assignment);
                Assert.AreEqual(0, results.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_DN1();

            CokerCardConfiguration configuration1 = CokerCardConfigurationFixture.CreateForInsert(floc1);
            configuration1 = configurationDao.Insert(configuration1);

            CokerCardConfiguration configuration2 = CokerCardConfigurationFixture.CreateForInsert(floc2);
            configuration2 = configurationDao.Insert(configuration2);

            {
                List<CokerCardConfiguration> results = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(
                    new ExactFlocSet(floc1));
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(obj => obj.Id == configuration1.Id));
            }
            {
                List<CokerCardConfiguration> results = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(
                    new ExactFlocSet(new List<FunctionalLocation> { floc1, floc2 }));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(obj => obj.Id == configuration2.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == configuration1.Id));
            }
            {
                List<CokerCardConfiguration> results = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(
                    new ExactFlocSet(new List<FunctionalLocation> { floc2 }));
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(obj => obj.Id == configuration2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFloc_NotReturnDeletedConfiguration()
        {
            CokerCardConfiguration configuration = CokerCardConfigurationFixture.CreateForInsert(
                FunctionalLocationFixture.GetReal_SR1());
            configuration = configurationDao.Insert(configuration);

            {
                List<CokerCardConfiguration> results = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(
                    new ExactFlocSet(new List<FunctionalLocation> {configuration.FunctionalLocation}));
                Assert.AreEqual(1, results.Count);
                Assert.IsTrue(results.Exists(obj => obj.Id == configuration.Id));
            }

            configurationDao.Remove(configuration);

            {
                List<CokerCardConfiguration> results = configurationDao.QueryCokerCardConfigurationsByExactFlocMatch(
                    new ExactFlocSet(new List<FunctionalLocation> { configuration.FunctionalLocation }));
                Assert.AreEqual(0, results.Count);
            }
        }

        private WorkAssignment CreateWorkAssignment()
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            return workAssignmentDao.Insert(workAssignment);
        }

    }
}

using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class TrainingBlockDaoTest : AbstractDaoTest
    {
        private ITrainingBlockDao trainingBlockDao;

        protected override void TestInitialize()
        {
            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void QueryByIdShouldWorkYo()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            TrainingBlock trainingBlock = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> { floc1, floc2 });    //ayman training
            trainingBlockDao.Insert(trainingBlock);

            TrainingBlock requeriedBlock = trainingBlockDao.QueryById(trainingBlock.IdValue);

            Assert.AreEqual(trainingBlock.Name, requeriedBlock.Name);
            Assert.AreEqual(trainingBlock.Code, requeriedBlock.Code);
            Assert.AreEqual(trainingBlock.FunctionalLocations.Count, requeriedBlock.FunctionalLocations.Count);
            Assert.IsTrue(requeriedBlock.FunctionalLocations.Exists(floc => floc.Id == floc1.Id));
            Assert.IsTrue(requeriedBlock.FunctionalLocations.Exists(floc => floc.Id == floc2.Id));
        }

        [Ignore] [Test]
        public void QueryAllShouldWorkYo()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            TrainingBlock trainingBlock = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> { floc1, floc2 });     //ayman training block
            trainingBlockDao.Insert(trainingBlock);

            List<TrainingBlock> trainingBlocks = trainingBlockDao.QueryAll(6);
            Assert.IsTrue(trainingBlocks.Count > 1);  // because there's the one we just inserted plus at least one in test data

            Assert.IsTrue(trainingBlocks.Exists(tb => tb.IdValue == trainingBlock.IdValue));
        }

        [Ignore] [Test]
        public void UpdateShouldWork()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();

            TrainingBlock trainingBlock = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> { floc1, floc2 });    // ayman training block
            trainingBlockDao.Insert(trainingBlock);

            trainingBlock.Name = "tb1-new";
            trainingBlock.Code = "tb1code-new";
            trainingBlock.FunctionalLocations.Clear();
            trainingBlock.FunctionalLocations.Add(floc1);
            trainingBlock.FunctionalLocations.Add(floc3);

            trainingBlockDao.Update(trainingBlock);
            TrainingBlock requeriedBlock = trainingBlockDao.QueryById(trainingBlock.IdValue);

            Assert.AreEqual(trainingBlock.Name, requeriedBlock.Name);
            Assert.AreEqual(trainingBlock.Code, requeriedBlock.Code);
            Assert.AreEqual(trainingBlock.FunctionalLocations.Count, requeriedBlock.FunctionalLocations.Count);
            Assert.IsTrue(requeriedBlock.FunctionalLocations.Exists(floc => floc.IdValue == floc1.IdValue));
            Assert.IsTrue(requeriedBlock.FunctionalLocations.Exists(floc => floc.IdValue == floc3.IdValue));
        }

        [Ignore] [Test]
        public void RemoveShouldWork()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            TrainingBlock trainingBlock = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> { floc1 });    //ayman training block
            trainingBlockDao.Insert(trainingBlock);

            {
                List<TrainingBlock> trainingBlocks = trainingBlockDao.QueryAll(6);
                Assert.IsTrue(trainingBlocks.Exists(tb => tb.IdValue == trainingBlock.IdValue));
            }
            {
                List<TrainingBlock> trainingBlocks = trainingBlockDao.QueryByFunctionalLocations(new RootFlocSet(floc1));
                Assert.IsTrue(trainingBlocks.Exists(tb => tb.IdValue == trainingBlock.IdValue));
            }

            trainingBlockDao.Remove(trainingBlock);

            {
                List<TrainingBlock> trainingBlocks = trainingBlockDao.QueryAll(6);
                Assert.IsFalse(trainingBlocks.Exists(tb => tb.IdValue == trainingBlock.IdValue));
            }
            {
                List<TrainingBlock> trainingBlocks = trainingBlockDao.QueryByFunctionalLocations(new RootFlocSet(floc1));
                Assert.IsFalse(trainingBlocks.Exists(tb => tb.IdValue == trainingBlock.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldCountTrainingBlocksWithSameNameExceptForThoseWithProvidedId()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            TrainingBlock trainingBlock = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> { floc1 });    //ayman training block
            trainingBlockDao.Insert(trainingBlock);

            Assert.AreEqual(1, trainingBlockDao.CountOfTrainingBlocksWithName("TB1", null,0));
            Assert.AreEqual(1, trainingBlockDao.CountOfTrainingBlocksWithName("tb1", null,0));
            Assert.AreEqual(1, trainingBlockDao.CountOfTrainingBlocksWithName("TB1", -1,0));
            Assert.AreEqual(1, trainingBlockDao.CountOfTrainingBlocksWithName("tb1", -1,0));
                        
            Assert.AreEqual(0, trainingBlockDao.CountOfTrainingBlocksWithName("TB1", trainingBlock.IdValue,0));
            Assert.AreEqual(0, trainingBlockDao.CountOfTrainingBlocksWithName("tb1", trainingBlock.IdValue,0));
        }

        [Ignore] [Test]
        public void QueryFunctionalLocationsShouldOnlyBringBackBlocksThatFallUnderOrAboveOrAreEqualToTheSpecifiedFLOC()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            TrainingBlock tb1 = new TrainingBlock(null, "tb1", "tb1code",0, new List<FunctionalLocation> { floc1 });    //ayman training block
            trainingBlockDao.Insert(tb1);

            TrainingBlock tb2 = new TrainingBlock(null, "tb2", "tb2code",0, new List<FunctionalLocation> { floc2 });     //ayman training block
            trainingBlockDao.Insert(tb2);

            TrainingBlock tb3 = new TrainingBlock(null, "tb3", "tb3code",0, new List<FunctionalLocation> { floc3 });     //ayman training block
            trainingBlockDao.Insert(tb3);

            TrainingBlock tb4 = new TrainingBlock(null, "tb4", "tb4code",0, new List<FunctionalLocation> { floc2, floc3 });   //ayman training block
            trainingBlockDao.Insert(tb4);

            {
                List<TrainingBlock> results = trainingBlockDao.QueryByFunctionalLocations(new RootFlocSet(floc1));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb1.Id));
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb2.Id));
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb4.Id));
            }

            {
                List<TrainingBlock> results = trainingBlockDao.QueryByFunctionalLocations(new RootFlocSet(floc2));
                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb1.Id));
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb2.Id));
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb4.Id));
            }

            {
                List<TrainingBlock> results = trainingBlockDao.QueryByFunctionalLocations(new RootFlocSet(floc3));
                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb3.Id));
                Assert.IsTrue(results.Exists(trainingBlock => trainingBlock.Id == tb4.Id));
            }

        }
    }
}

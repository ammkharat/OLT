using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Bootstrap
{
    [TestFixture]
    public class BootstrapperTest
    {
        [SetUp]
        public void SetUp()
        {
            Bootstrapper.Reset();
            Bootstrapper.Bootstrap();
        }

        [TearDown]
        public void TearDown()
        {
            Bootstrapper.Reset();
        }

        [Ignore] [Test]
        public void CallingTheBootstrapperShouldInitializeTheDaoRegistryWithDaos()
        {
            var dao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            Assert.IsNotNull(dao);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToCallTheBootstrapperTwiceAndHaveItSimplyIgnoreTheSecondBootstrapCall()
        {
            var firstDao =
                DaoRegistry.GetDao<IActionItemDefinitionDao>();
            Bootstrapper.Bootstrap();
            var secondDao =
                DaoRegistry.GetDao<IActionItemDefinitionDao>();
            Assert.AreSame(firstDao, secondDao);
        }

        [Ignore] [Test]
        public void ResettingTheBootstrapperShouldAllowReBootstrapping()
        {
            var firstDao =
                DaoRegistry.GetDao<IActionItemDefinitionDao>();
            Bootstrapper.Reset();
            Bootstrapper.Bootstrap();
            var secondDao =
                DaoRegistry.GetDao<IActionItemDefinitionDao>();
            Assert.AreNotSame(firstDao, secondDao);
        }
    }
}
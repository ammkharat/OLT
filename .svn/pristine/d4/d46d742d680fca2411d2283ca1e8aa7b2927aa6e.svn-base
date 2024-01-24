using System;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Remote.Bootstrap;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetDefinitionStateDaoTest : AbstractDaoTest
    {
        private ITargetDefinitionStateDao dao;


        protected override void TestInitialize()
        {

            // Create a new TargetDefinitionDao to allow mocking of the Plant Historian Gateway & Time Service Dao.
            dao = Bootstrapper.CreateManagedDao<ITargetDefinitionStateDao>(Bootstrapper.ConnectionString, new TargetDefinitionStateDao());

        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldReturnState()
        {
            TargetDefinitionState originalTarget = dao.QueryById(1);
            Assert.That(originalTarget, Is.Not.Null);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            DateTime lastSuccessfulTagAccess = new DateTime(2010, 1, 1, 12, 0, 5);
            TargetDefinitionState state = new TargetDefinitionState(1, true, lastSuccessfulTagAccess);
            dao.Update(state);
            TargetDefinitionState expectedTarget = dao.QueryById(1);
            Assert.That(expectedTarget.LastSuccessfulTagAccess, Is.EqualTo(lastSuccessfulTagAccess));
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            int count = TestDataAccessUtil.ExecuteExpression("DELETE TargetDefinitionState where TargetDefinitionId = 1");
            Assert.That(count, Is.EqualTo(1));
            DateTime lastSuccessfulTagAccess = new DateTime(2010, 1, 1, 12, 0, 5);

            dao.Insert(new TargetDefinitionState(1, true, lastSuccessfulTagAccess));
            int result = TestDataAccessUtil.ExecuteScalarExpression<int>(
                "SELECT count(*) FROM TargetDefinitionState where TargetDefinitionId = 1");
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
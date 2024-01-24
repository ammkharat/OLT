using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverQuestionDaoTest : AbstractDaoTest
    {
        private IShiftHandoverQuestionDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverQuestionDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            ShiftHandoverQuestion question = dao.QueryById(3);
            Assert.AreEqual("What is the capital of Bhutan?", question.Text);
            Assert.AreEqual(3, question.Id.Value);
        }

        [Ignore] [Test]
        public void ShouldQueryByIdEvenIfDeleted()
        {
            int id = 3;

            ShiftHandoverQuestion question = dao.QueryById(id);
            long configurationId = question.ConfigurationId.Value;

            {
                List<ShiftHandoverQuestion> queriedByConfigurationId = dao.QueryByConfigurationId(configurationId);
                Assert.IsTrue(queriedByConfigurationId.Exists(obj => obj.Id == id));
            }

            dao.Delete(question);

            {
                List<ShiftHandoverQuestion> queriedByConfigurationId = dao.QueryByConfigurationId(configurationId);
                Assert.IsFalse(queriedByConfigurationId.Exists(obj => obj.Id == id));
            }
            {
                ShiftHandoverQuestion queriedById = dao.QueryById(id);
                Assert.IsNotNull(queriedById);
            }
        }
    }
}

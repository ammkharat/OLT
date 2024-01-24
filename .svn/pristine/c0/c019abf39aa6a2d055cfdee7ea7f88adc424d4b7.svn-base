using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class PermitAttributeDaoTest : AbstractDaoTest
    {
        private IPermitAttributeDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitAttributeDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            List<PermitAttribute> attributes = dao.QueryBySiteId(Site.MONTREAL_ID);
            Assert.IsNotEmpty(attributes);
            foreach (PermitAttribute attribute in attributes)
            {
                Assert.IsNotNull(attribute.Id);
                Assert.IsNotNull(attribute.Name);
            }
        }
    }
}

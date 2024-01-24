using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class DirectiveHistoryDaoTest : AbstractDaoTest
    {
        IDirectiveHistoryDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IDirectiveHistoryDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShoudInsert()
        {
            Directive directive = DirectiveFixture.CreateForInsert();
            directive.Id = 1;
            directive.LastModifiedBy = UserFixture.CreateSupervisor();
            directive.LastModifiedDateTime = new DateTime(2013, 12, 5);

            DirectiveHistory directiveHistory = directive.TakeSnapshot();

            dao.Insert(directiveHistory);

            List<DirectiveHistory> directiveHistories = dao.GetById(1);

            Assert.IsTrue(directiveHistories.Count > 0);
        }
    }
}

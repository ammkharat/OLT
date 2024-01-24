using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class SapAutoImportConfigurationDaoTest : AbstractDaoTest
    {
        private ISapAutoImportConfigurationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISapAutoImportConfigurationDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            SapAutoImportConfiguration configuration = dao.QueryBySiteId(Site.LUBES_ID);
            Assert.IsNotNull(configuration);
            Assert.AreEqual(Site.LUBES_ID, configuration.SiteId);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            {
                SapAutoImportConfiguration configuration = dao.QueryBySiteId(Site.LUBES_ID);

                Date date = new Date(2013, 4, 12);
                Time startTime = new Time(14, 0);
                Time endTime = startTime.AddHours(4);

                configuration.Schedule = new RecurringDailySchedule(date, null, startTime, endTime, 1, SiteFixture.Lubes());
                dao.Update(configuration);
            }

            {
                SapAutoImportConfiguration configuration = dao.QueryBySiteId(Site.LUBES_ID);
                Assert.IsNotNull(configuration.Schedule);
                Assert.IsNotNull(configuration.Schedule.Id);
            }            
        }
    }
}

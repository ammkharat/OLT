using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class AreaLabelDaoTest : AbstractDaoTest
    {
        private IAreaLabelDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {  // arrange 
            AreaLabel areaLabel1 = dao.Insert(new AreaLabel(null, "Jimbo's Territory", Site.SARNIA_ID, 1, true, null));
            AreaLabel areaLabel2 = dao.Insert(new AreaLabel(null, "Johnnyville", Site.SARNIA_ID, 2, true, null));
            AreaLabel areaLabel3 = dao.Insert(new AreaLabel(null, "Not Sarnia", Site.FIREBAG_ID, 1, true, null));

            // act
            List<AreaLabel> sarniaAreaLabels = dao.QueryBySiteId(Site.SARNIA_ID);
         
            // assert
            Assert.AreEqual(2, sarniaAreaLabels.Count);
            Assert.IsTrue(sarniaAreaLabels.Exists(label => label.IdValue == areaLabel1.IdValue));
            Assert.IsTrue(sarniaAreaLabels.Contains(areaLabel2));
            List<AreaLabel> firebagAreaLabels = dao.QueryBySiteId(Site.FIREBAG_ID);
            Assert.AreEqual(1, firebagAreaLabels.Count);
            Assert.IsTrue(firebagAreaLabels.Contains(areaLabel3));
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteAndPlannerGroup()
        {
            AreaLabel areaLabel1 = dao.Insert(new AreaLabel(null, "Jimbo's Territory", Site.SARNIA_ID, 1, true, "pg1"));
            AreaLabel areaLabel2 = dao.Insert(new AreaLabel(null, "Johnnyville", Site.SARNIA_ID, 2, true, "pg2"));

            {
                AreaLabel result = dao.QueryBySiteIdAndPlannerGroup(Site.SARNIA_ID, "pg1");
                Assert.AreEqual(areaLabel1.IdValue, result.IdValue);
            }

            {
                AreaLabel result = dao.QueryBySiteIdAndPlannerGroup(Site.SARNIA_ID, "PG2");
                Assert.AreEqual(areaLabel2.IdValue, result.IdValue);
            }

            {
                AreaLabel result = dao.QueryBySiteIdAndPlannerGroup(Site.EDMONTON_ID, "pg1");
                Assert.IsNull(result);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateAddAndRemove()
        {
            const long siteId = Site.SARNIA_ID;

            AreaLabel areaLabel1 = dao.Insert(new AreaLabel(null, "Johnnyville", siteId, 1, true, "jv"));
            AreaLabel areaLabel2 = dao.Insert(new AreaLabel(null, "Kindersley", siteId, 2, false, "k"));
            AreaLabel uninsertedAreaLabel = new AreaLabel(null, "Jimbo's Territory", siteId, 3, true, "jt");

            areaLabel1.Name = "Updated Johnnyville";
            areaLabel1.AllowManualSelection = false;
            areaLabel1.SapPlannerGroup = "uj";

            dao.Insert(uninsertedAreaLabel);
            dao.Update(areaLabel1);
            dao.Remove(areaLabel2);

            List<AreaLabel> labels = dao.QueryBySiteId(siteId);

            AreaLabel updatedAreaLabel1 = labels.Find(label => label.Id == uninsertedAreaLabel.Id);
            Assert.AreEqual("Jimbo's Territory", updatedAreaLabel1.Name);

            AreaLabel updatedAreaLabel2 = labels.Find(label => label.Id == areaLabel1.Id);
            Assert.AreEqual("Updated Johnnyville", updatedAreaLabel2.Name);
            Assert.AreEqual(false, updatedAreaLabel2.AllowManualSelection);
            Assert.AreEqual("uj", updatedAreaLabel2.SapPlannerGroup);

            AreaLabel updatedAreaLabel3 = labels.Find(label => label.Id == areaLabel2.Id);
            Assert.IsNull(updatedAreaLabel3);
        }
    }
}


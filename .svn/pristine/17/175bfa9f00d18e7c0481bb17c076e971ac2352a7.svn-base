using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class LogGuidelineDaoTest : AbstractDaoTest
    {
        private ILogGuidelineDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogGuidelineDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertLogGuidelineAndQueryBySite()
        {
            {
                FunctionalLocation up1 = FunctionalLocationFixture.GetReal_UP1();
                LogGuideline guidelineUP1 = new LogGuideline(up1, "Guideline UP1");
                dao.Insert(guidelineUP1);
                LogGuideline up1Guidelines = dao.QueryByDivision(up1);
                Assert.AreEqual(up1Guidelines.Text, guidelineUP1.Text);
            }

            {
                FunctionalLocation up2 = FunctionalLocationFixture.GetReal_UP2();
                LogGuideline guidelineUP2 = new LogGuideline(up2, "Guideline UP2");
                dao.Insert(guidelineUP2);
                LogGuideline up2Guidelines = dao.QueryByDivision(up2);
                Assert.AreEqual(up2Guidelines.Text, guidelineUP2.Text);
            }
            {
                FunctionalLocation sr1 = FunctionalLocationFixture.GetReal_SR1();
                LogGuideline guidelineSR1 = new LogGuideline(sr1, "Guideline SR1");
                dao.Insert(guidelineSR1);
                LogGuideline sr1Guidelines = dao.QueryByDivision(sr1);
                Assert.AreEqual(sr1Guidelines.Text, guidelineSR1.Text);
            }

        } 
       
        [Ignore] [Test]
        public void ShouldInsertAndUpdateLogGuidelineWithNullGuidelineText()
        {
            FunctionalLocation up1 = FunctionalLocationFixture.GetReal_UP1();

            {
                LogGuideline guidelineUP1 = new LogGuideline(up1, null);                       
                dao.Insert(guidelineUP1);                
            }

            {
                LogGuideline guideline = dao.QueryByDivision(up1);
                Assert.IsNull(guideline.Text);
                guideline.Text = "Guideline Text";
                dao.Update(guideline);                
            }

            {
                LogGuideline guideline = dao.QueryByDivision(up1);
                guideline.Text = null;
                dao.Update(guideline);
            }

            {
                LogGuideline guideline = dao.QueryByDivision(up1);
                Assert.IsNull(guideline.Text);                
            }
        } 
       

    }
}

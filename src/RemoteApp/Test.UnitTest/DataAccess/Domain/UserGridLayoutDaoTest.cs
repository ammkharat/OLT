using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class UserGridLayoutDaoTest : AbstractDaoTest
    {
        private IUserGridLayoutDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IUserGridLayoutDao>();
        }

        protected override void Cleanup() { }

        [Ignore] [Test]
        public void ShouldSaveAndLoadLayoutAndThenDeleteIt()
        {
            const long sapUserId = 0;
            const string xml = @"<xml>This is xml, obviously.</xml>";
            dao.SaveGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests, xml);

            {
                string gridLayoutXml = dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonTurnaroundPermitRequests);
                Assert.IsNull(gridLayoutXml);                
            }

            {
                string gridLayoutXml = dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests);
                Assert.IsNotNull(gridLayoutXml);                
                Assert.AreEqual(xml, gridLayoutXml);
            }

            {
                dao.DeleteGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonTurnaroundPermitRequests);
                string gridLayoutXml = dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests);                
                Assert.AreEqual(xml, gridLayoutXml);
            }

            {
                dao.DeleteGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests);
                string gridLayoutXml = dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests);                
                Assert.IsNull(gridLayoutXml);
            }
        }

        [Ignore] [Test]
        public void ShouldRemoveAllLayoutsForUser()
        {
            const long sapUserId = 0;
            const string xml = @"<xml>This is xml, obviously.</xml>";
            {
                dao.SaveGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests, xml);
                dao.SaveGridLayout(sapUserId, UserGridLayoutIdentifier.LogDefinitions, xml);
                dao.SaveGridLayout(sapUserId, UserGridLayoutIdentifier.Forms, xml);                
            }

            const long otherUserId = 1;
            {
                dao.SaveGridLayout(otherUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests, xml);
                dao.SaveGridLayout(otherUserId, UserGridLayoutIdentifier.LogDefinitions, xml);
                dao.SaveGridLayout(otherUserId, UserGridLayoutIdentifier.Forms, xml);                
            }

            // Check that they are all there for the sap user id
            {
                Assert.IsNotNull(dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests));
                Assert.IsNotNull(dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.LogDefinitions));
                Assert.IsNotNull(dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.Forms));                
            }            
            
            // Check that they are all there for the other user id
            {
                Assert.IsNotNull(dao.GetGridLayout(otherUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests));
                Assert.IsNotNull(dao.GetGridLayout(otherUserId, UserGridLayoutIdentifier.LogDefinitions));
                Assert.IsNotNull(dao.GetGridLayout(otherUserId, UserGridLayoutIdentifier.Forms));                
            }            
            
            dao.DeleteAllGridLayoutsForUser(otherUserId);

            // Check that they are still all there for the sap user id
            {
                Assert.IsNotNull(dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests));
                Assert.IsNotNull(dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.LogDefinitions));
                Assert.IsNotNull(dao.GetGridLayout(sapUserId, UserGridLayoutIdentifier.Forms));
            }

            // Check that they are gone for the other user id
            {
                Assert.IsNull(dao.GetGridLayout(otherUserId, UserGridLayoutIdentifier.EdmontonRunningUnitPermitRequests));
                Assert.IsNull(dao.GetGridLayout(otherUserId, UserGridLayoutIdentifier.LogDefinitions));
                Assert.IsNull(dao.GetGridLayout(otherUserId, UserGridLayoutIdentifier.Forms));
            }            
        }
    }
}

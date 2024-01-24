using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class OpmExcursionImportStatusDTODaoTest : AbstractDaoTest
    {
        private IOpmExcursionImportStatusDTODao dao;

        [Ignore] [Test]
        public void ShouldUpdateAvailableImportStatus()
        {
            var opmExcursionImportStatusDto = OpmExcursionImportStatusDTOFixture.CreateAvailable();

            dao.UpdateAvailableImportStatus(opmExcursionImportStatusDto.LastSuccessfulExcursionImportDateTime);
            var requeried = dao.QueryLastSuccessfulImport();

            Assert.IsNotNull(requeried);
            Assert.AreEqual(opmExcursionImportStatusDto.Status, requeried.Status);
            Assert.IsNotNull(requeried.LastSuccessfulExcursionImportDateTime);
            Assert.AreEqual(opmExcursionImportStatusDto.LastSuccessfulExcursionImportDateTime.Value.Date,
                requeried.LastSuccessfulExcursionImportDateTime.Value.Date);
            Assert.AreEqual(opmExcursionImportStatusDto.LastSuccessfulExcursionImportDateTime.Value.Hour,
                requeried.LastSuccessfulExcursionImportDateTime.Value.Hour);
            Assert.AreEqual(opmExcursionImportStatusDto.LastSuccessfulExcursionImportDateTime.Value.Minute,
                requeried.LastSuccessfulExcursionImportDateTime.Value.Minute);
            Assert.AreEqual(opmExcursionImportStatusDto.LastSuccessfulExcursionImportDateTime.Value.Second,
                requeried.LastSuccessfulExcursionImportDateTime.Value.Second);
        }

        [Ignore] [Test]
        public void ShouldUpdateUnavailableImportStatus()
        {
            var opmExcursionImportStatusDto = OpmExcursionImportStatusDTOFixture.CreateUnavailable();

            dao.UpdateUnavailableImportStatus(opmExcursionImportStatusDto.LastSuccessfulExcursionImportDateTime);
            var requeried = dao.QueryLastSuccessfulImport();

            Assert.IsNotNull(requeried);
            Assert.AreNotEqual(opmExcursionImportStatusDto.Status, requeried.Status);
            Assert.IsNull(requeried.LastSuccessfulExcursionImportDateTime);
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IOpmExcursionImportStatusDTODao>();
        }

        protected override void Cleanup()
        {
        }
    }
}
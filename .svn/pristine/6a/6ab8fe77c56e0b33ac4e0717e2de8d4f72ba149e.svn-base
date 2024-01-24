using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class WorkPermitLubesDTODaoTest : AbstractDaoTest
    {
        private IWorkPermitLubesDTODao dtoDao;
        private IWorkPermitLubesDao dao;
        private IWorkPermitLubesGroupDao groupDao;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IWorkPermitLubesDTODao>();
            dao = DaoRegistry.GetDao<IWorkPermitLubesDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRangeAndFlocs()
        {                        
            List<WorkPermitLubesGroup> workPermitLubesGroups = groupDao.QueryAll();
            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(workPermitLubesGroups[0]);
            dao.Insert(permit, null);

            permit.IssuedDateTime = permit.CreatedDateTime.AddHours(2);
            permit.IssuedBy = UserFixture.CreateUserWithGivenId(1);
            dao.Update(permit);
            
            IFlocSet flocs = new RootFlocSet(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            Range<Date> theRange = new Range<Date>(new Date(2012, 1, 1), new Date(2012, 2, 28));
            List<WorkPermitLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(theRange, flocs);

            Assert.IsTrue(results.Count > 0);
            WorkPermitLubesDTO dto = results.Find(r => r.IdValue == permit.IdValue);
            Assert.IsNotNull(dto);

            Assert.AreEqual(permit.DataSource, dto.DataSource);
            Assert.AreEqual(permit.Version, dto.Version);
            Assert.AreEqual(permit.WorkPermitStatus, dto.Status);
            Assert.AreEqual(permit.AdditionalFollowupRequired, dto.AdditionalFollowupRequired);
            Assert.AreEqual(permit.PermitNumberDisplayValue, dto.PermitNumber);
            Assert.AreEqual(permit.FunctionalLocation.FullHierarchy, dto.FunctionalLocation);
            Assert.AreEqual(permit.StartDateTime, dto.StartDateTime);
            Assert.AreEqual(permit.ExpireDateTime, dto.ExpireDateTime);
            Assert.AreEqual(permit.IssuedDateTime, dto.IssuedDateTime);
            Assert.AreEqual(permit.Trade, dto.Trade);
            Assert.AreEqual(permit.RequestedByGroup.GetName(), dto.RequestedByGroup);
            Assert.AreEqual(permit.TaskDescription, dto.Description);
            Assert.AreEqual(permit.WorkOrderNumber, dto.WorkOrderNumber);
            Assert.IsNotNull(dto.LastEditorFullNameWithUserName);
            Assert.AreEqual("Oltuser1, John [oltuser1]", dto.IssuedByUserFullNameWithUserName);
            Assert.AreEqual(permit.Company, dto.Company);
        }
    }
}

using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class WorkPermitEdmontonHazardDTODaoTest : AbstractDaoTest
    {
        private IWorkPermitEdmontonHazardDTODao dtoDao;
        private IWorkPermitEdmontonDao dao;

        private DateTime NOW;
        private DateTime NOW_PLUS_8_HOURS;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IWorkPermitEdmontonHazardDTODao>();
            dao = DaoRegistry.GetDao<IWorkPermitEdmontonDao>();

            NOW = DateTimeFixture.DateTimeNow;
            NOW_PLUS_8_HOURS = NOW.AddHours(8);
        }

        protected override void Cleanup()
        {
        }
        
        [Ignore] [Test]
        public void ShouldOnlyBringBackPermitsThatFallUnderTheSpecifiedFLOC()
        {
            // Insert a Permit that starts today in Area 1 at level 3
            FunctionalLocation areaOneFloc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            WorkPermitEdmonton areaOneWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, areaOneFloc);
            areaOneWorkPermit.TaskDescription = "Area One";
            dao.Insert(areaOneWorkPermit, null);

            // Insert a Permit that starts today in Area 2 at level 3
            WorkPermitEdmonton areaTwoWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, FunctionalLocationFixture.GetReal("ED1-A002-U005"));
            areaTwoWorkPermit.TaskDescription = "Area Two";
            dao.Insert(areaTwoWorkPermit, null);
            
            // Query area one
            List<WorkPermitEdmontonHazardDTO> dtos = dtoDao.QueryByFlocsAndStatus(new RootFlocSet(areaOneFloc), new List<PermitRequestBasedWorkPermitStatus> { PermitRequestBasedWorkPermitStatus.Pending });

            // Assert that only the Area 1 Permit comes back
            Assert.AreEqual(1, dtos.Count);
            Assert.AreEqual("Area One", dtos[0].Description);
        }
        
        [Ignore] [Test]
        public void ShouldOnlyBringBackPermitsWithTheAppropriateStatuses()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");

            WorkPermitEdmonton pendingWorkPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            pendingWorkPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;
            pendingWorkPermit.TaskDescription = "Pending";
            dao.Insert(pendingWorkPermit, null);

            WorkPermitEdmonton issuedPermit = WorkPermitEdmontonFixture.CreateForInsert(NOW, NOW, NOW_PLUS_8_HOURS, floc);
            issuedPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
            issuedPermit.TaskDescription = "Issued";
            dao.Insert(issuedPermit, null);

            {
                List<WorkPermitEdmontonHazardDTO> dtos = dtoDao.QueryByFlocsAndStatus(new RootFlocSet(floc), new List<PermitRequestBasedWorkPermitStatus> { PermitRequestBasedWorkPermitStatus.Pending });
                Assert.AreEqual(1, dtos.Count);
                Assert.AreEqual("Pending", dtos[0].Description);
            }

            {
                List<WorkPermitEdmontonHazardDTO> dtos = dtoDao.QueryByFlocsAndStatus(new RootFlocSet(floc), new List<PermitRequestBasedWorkPermitStatus> { PermitRequestBasedWorkPermitStatus.Issued });
                Assert.AreEqual(1, dtos.Count);
                Assert.AreEqual("Issued", dtos[0].Description);
            }
        }


    }
}

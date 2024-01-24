using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class WorkPermitAssignmentConfigurationServiceTest
    {
        [Ignore] [Test]
        public void ShouldQueryBySite()
        {
            const int assignment1Id = 1;
            const int assignment2Id = 2;

            IWorkAssignmentDao workAssignmentDao = MockRepository.GenerateMock<IWorkAssignmentDao>();
            IWorkAssignmentDTODao workAssignmentDtoDao = MockRepository.GenerateMock<IWorkAssignmentDTODao>();
            IFunctionalLocationDao functionalLocationDao = MockRepository.GenerateMock<IFunctionalLocationDao>();

            WorkPermitAssignmentConfigurationService service = new WorkPermitAssignmentConfigurationService(workAssignmentDao, workAssignmentDtoDao, functionalLocationDao);

            // setup data
            List<WorkAssignmentDTO> workAssignmentDtos = new List<WorkAssignmentDTO>();
            WorkAssignmentDTO workAssignmentDto1 = new WorkAssignmentDTO(assignment1Id, "wa name 1", "wa desc 1", "wa category", "wa role", "Edmo");
            WorkAssignmentDTO workAssignmentDto2 = new WorkAssignmentDTO(assignment2Id, "wa name 2", "wa desc 2", "wa category", "wa role", "Edmo");
            workAssignmentDtos.Add(workAssignmentDto1);
            workAssignmentDtos.Add(workAssignmentDto2);

            List<FunctionalLocation> flocsForPermitsForAssignment1 = new List<FunctionalLocation> { FunctionalLocationFixture.CreateNew(1, "ED1" )};
            List<FunctionalLocation> flocsForPermitsForAssignment2 = new List<FunctionalLocation> { FunctionalLocationFixture.CreateNew(2, "ED1-A001"), FunctionalLocationFixture.CreateNew(3, "ED1-A001-WHAT")};

            // setup expectations
            workAssignmentDtoDao.Expect(dao => dao.QueryBySiteId(SiteFixture.Edmonton().IdValue)).Return(workAssignmentDtos);
            functionalLocationDao.Expect(dao => dao.QueryByWorkAssignmentIdForWorkPermits(assignment1Id)).Return(flocsForPermitsForAssignment1);
            functionalLocationDao.Expect(dao => dao.QueryByWorkAssignmentIdForWorkPermits(assignment2Id)).Return(flocsForPermitsForAssignment2);

            // run it!
            List<AssignmentFlocConfiguration> configs = service.QueryBySite(SiteFixture.Edmonton());

            Assert.AreEqual(2, configs.Count);

            AssignmentFlocConfiguration configForAssignment1 = configs.Find(config => config.WorkAssignmentId == assignment1Id);
            Assert.AreEqual(1, configForAssignment1.FunctionalLocations.Count);
            Assert.AreEqual("ED1", configForAssignment1.FunctionalLocations[0].FullHierarchy);

            AssignmentFlocConfiguration configForAssignment2 = configs.Find(config => config.WorkAssignmentId == assignment2Id);
            Assert.AreEqual(2, configForAssignment2.FunctionalLocations.Count);
            Assert.AreEqual("ED1-A001", configForAssignment2.FunctionalLocations[0].FullHierarchy);
            Assert.AreEqual("ED1-A001-WHAT", configForAssignment2.FunctionalLocations[1].FullHierarchy);
        }

    }
}

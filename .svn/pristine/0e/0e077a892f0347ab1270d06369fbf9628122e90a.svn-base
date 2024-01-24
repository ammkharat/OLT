using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class TargetDefinitionDTODaoTest : AbstractDaoTest
    {
        private ITargetDefinitionDTODao dao;
        private ITargetDefinitionDao targetDefinitionDao;
        private IActionItemDefinitionDao actionItemDefinitionDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ITargetDefinitionDTODao>();
            targetDefinitionDao = DaoRegistry.GetDao<ITargetDefinitionDao>();
            actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void QueryTargetsByFunctionLocationShouldReturnMoreThanZeroRowsForASuccessfulQuery()
        {
            List<TargetDefinitionDTO> targetDTOList 
                    = dao.QueryByFunctionalLocations(new RootFlocSet(FunctionalLocationFixture.GetListWith2Units()), new DateRange(null, null));
            Assert.IsNotNull(targetDTOList);
            Assert.IsTrue(targetDTOList.Count > 0);
        }

        [Ignore] [Test]
        public void QueryTargetsByFunctionLocationShouldPopulateAllFieldsCorrectly()
        {
            var listWithSingleFunctionalLocation = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            List<TargetDefinitionDTO> targetDTOList =
                    dao.QueryByFunctionalLocations(new RootFlocSet(listWithSingleFunctionalLocation), new DateRange(null, null));
            Assert.IsNotNull(targetDTOList);
            Assert.IsTrue(targetDTOList.Count > 0);

            foreach(TargetDefinitionDTO dto in targetDTOList)
            {
                // We will test the one we know about
                if(dto.Id == TargetDefinitionFixture.TARGET_DEFINITION_WITH_2_COMMENTS_ID)
                {
                    Assert.AreEqual("TestData Target Id = 7", dto.Name);
                    Assert.AreEqual(1, dto.CategoryId);
                    Assert.IsTrue(TargetCategory.IsValidFullCategoryName(dto.CategoryName));
                    Assert.AreEqual("Has 2 comments and has audit trail record", dto.Description);
                    Assert.AreEqual("SR1-OFFS-BDOF", dto.FunctionalLocationName);
                    Assert.IsNotNull(dto.StartDate);
//                    Assert.IsNotNull(dto.EndDate);
                    Assert.IsNotNull(dto.StartTime);
                    Assert.IsNotNull(dto.EndTime);
                    Assert.AreEqual("50.00", dto.TargetValue);
                    Assert.AreEqual(2, dto.StatusId);
                    Assert.IsNotNull(dto.StatusName);
                    Assert.AreEqual(Priority.Normal, dto.Priority);
                    Assert.AreEqual("B2", dto.TagName);
                    Assert.AreEqual(false, dto.RequiresApproval);
                    User expectedLastEditedBy = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
                    Assert.IsTrue(dto.LastModifiedFullNameWithUserName.Contains(expectedLastEditedBy.Username));
                    return;
                }
            }
            Assert.Fail("Expected a target definition with id:<" + TargetDefinitionFixture.TARGET_DEFINITION_WITH_2_COMMENTS_ID + ">");
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldReturnTargetValue()
        {
            QueryByFunctionalLocationsShouldReturnCorrespondingTargetValue(TargetValue.CreateMinimizeTarget());
            QueryByFunctionalLocationsShouldReturnCorrespondingTargetValue(TargetValue.CreateMaximizeTarget());
            QueryByFunctionalLocationsShouldReturnCorrespondingTargetValue(TargetValue.CreateEmptyTarget());
            QueryByFunctionalLocationsShouldReturnCorrespondingTargetValue(TargetValue.CreateSpecifiedTarget(2.00m));
        }

        [Ignore] [Test]
        public void QueryAssociatedTargetsByParentShouldReturnAssociatedTargets()
        {
            TargetDefinition expected = TargetDefinitionFixture.TargetDefinitionWithTwoChildrenInDb();
            List<TargetDefinitionDTO> actualChildrenDtos = dao.QueryAssociatedTargets(8);
            Assert.AreEqual(expected.AssociatedTargetDTOs.Count, actualChildrenDtos.Count);
            Assert.AreEqual(expected.AssociatedTargetDTOs[0].Id, actualChildrenDtos[0].Id);
            Assert.AreEqual(expected.AssociatedTargetDTOs[1].Id, actualChildrenDtos[1].Id);
        }

        [Ignore] [Test]
        public void QueryByActionItemDefinitionShouldReturnTargetDefinitionsLinkedToActionItemDefinition()
        {
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateWithLinkedTargetDefinition();

            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            actionItemDefinitionDao.Insert(actionItemDefinition);
            
            List<TargetDefinitionDTO> targetDefinitionDtos =
                    dao.QueryByActionItemDefinitionId(actionItemDefinition.IdValue);
            
            Assert.AreEqual(1, targetDefinitionDtos.Count);
            TargetDefinitionDTO dto = targetDefinitionDtos[0];

            Assert.AreEqual(Priority.Normal, dto.Priority);            
        }

        private void QueryByFunctionalLocationsShouldReturnCorrespondingTargetValue(TargetValue targetValue)
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.Assignment = null;
            targetDefinition.Schedule.StartTime = new Time(3, 33);
            targetDefinition.Schedule.EndTime = new Time(4, 44);

            targetDefinition.TargetValue = targetValue;
            targetDefinition = targetDefinitionDao.Insert(targetDefinition);
            List<TargetDefinitionDTO> dtos =
                    dao.QueryByFunctionalLocations(new RootFlocSet(targetDefinition.FunctionalLocation), new DateRange(null, null));
            Assert.IsTrue(dtos.Count > 0);
            TargetDefinitionDTO retrievedDto =
                    dtos.Find(dto => dto.Id == targetDefinition.Id);
            Assert.AreEqual(targetValue.Title, retrievedDto.TargetValue);

            Time startTime = retrievedDto.StartTime;
            Assert.AreEqual(3, startTime.Hour);
            Assert.AreEqual(33, startTime.Minute);
        }
    }
}
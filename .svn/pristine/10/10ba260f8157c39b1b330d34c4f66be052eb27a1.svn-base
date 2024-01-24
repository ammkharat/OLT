using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.Utilities;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class FunctionalLocationOperationalModeServiceTest
    {
        private Mockery mock;
        private FunctionalLocationOperationalModeService service;
        private IFunctionalLocationOperationalModeDTODao opModeDTODaoMock;
        private IFunctionalLocationOperationalModeDao opModeDaoMock;
        private IFunctionalLocationService mockFLOCService;
        private ITargetAlertService mockTargetAlertService;
        private ITargetDefinitionService mockTargetDefinitionService;
        private IActionItemService mockActionItemService;
        private IEditHistoryService mockEditHistoryService;
        private ITimeService mockTimeService;
        private EventQueueTestWrapper eventQueue;
        
        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            opModeDTODaoMock = mock.NewMock<IFunctionalLocationOperationalModeDTODao>();
            opModeDaoMock = mock.NewMock<IFunctionalLocationOperationalModeDao>();
            mockFLOCService = mock.NewMock<IFunctionalLocationService>();
            mockTargetAlertService = mock.NewMock<ITargetAlertService>();
            mockTargetDefinitionService = mock.NewMock<ITargetDefinitionService>();
            mockActionItemService = mock.NewMock<IActionItemService>();
            mockEditHistoryService = mock.NewMock<IEditHistoryService>();
            mockTimeService = mock.NewMock<ITimeService>();
            eventQueue = new EventQueueTestWrapper();
            
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( opModeDTODaoMock);
            DaoRegistry.RegisterDaoFor( opModeDaoMock);
            
            service = new FunctionalLocationOperationalModeService(
                mockFLOCService, 
                mockTargetAlertService, 
                mockTargetDefinitionService, 
                mockActionItemService, 
                mockEditHistoryService, 
                mockTimeService);
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateAListOfOpModeDTOs()
        {
            const int numberOfTimes = 3;
            
            Expect.Exactly(numberOfTimes).On(opModeDaoMock).Method("Update");
            Expect.Exactly(numberOfTimes).On(mockFLOCService).Method("QueryById");

            Expect.Exactly(numberOfTimes).On(mockEditHistoryService).Method("TakeSnapshot");

            Expect.Once.On(mockTargetAlertService).Method("ClearAllTargetAlertsAtOrBelowFlocs").WithAnyArguments();
            Expect.Once.On(mockActionItemService).Method("ClearActionItemsAtOrBelowFlocs").WithAnyArguments();
            Expect.Once.On(mockTargetDefinitionService).Method("UpdateBoundaryExceededByUnitId").WithAnyArguments();
            User lastModifiedUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            service.Update(FunctionalLocationOperationalModeDTOFixture.GetList(numberOfTimes), lastModifiedUser);        
        }

        [Ignore] [Test]
        public void UpdateShouldRaiseFunctionalLocationOperationalModeUpdateEventForEachUnit()
        {
            User lastModifiedUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            List<FunctionalLocationOperationalModeDTO> functionalLocationDTOs = 
                FunctionalLocationOperationalModeDTOFixture.GetList(2);

            FunctionalLocation functionalLocation1 = FunctionalLocationFixture.CreateNew(100);
            FunctionalLocation functionalLocation2 = FunctionalLocationFixture.CreateNew(101);
            
            Expect.Once.On(mockFLOCService).Method("QueryById").With(functionalLocationDTOs[0].FunctionalLocationId).Will(Return.Value(functionalLocation1));
            Expect.Once.On(mockFLOCService).Method("QueryById").With(functionalLocationDTOs[1].FunctionalLocationId).Will(Return.Value(functionalLocation2));
            OltStub.On(opModeDaoMock, mockEditHistoryService, mockTargetAlertService, 
                       mockActionItemService, mockTargetDefinitionService);
            
            service.Update(functionalLocationDTOs, lastModifiedUser);
            AssertUpdateEventRaised(new List<FunctionalLocation>(new[] { functionalLocation1, functionalLocation2 }));
        }

        private void AssertUpdateEventRaised(IList<FunctionalLocation> functionalLocations)
        {
            List<EventQueueItem> queueItems = eventQueue.EventQueue;
            Assert.AreEqual(functionalLocations.Count, queueItems.Count);
            for (int i = 0; i < queueItems.Count; i++)
            {
                Assert.AreEqual(ApplicationEvent.FunctionalLocationOperationalModeUpdate, queueItems[i].ApplicationEvent);
                Assert.AreEqual(functionalLocations[i], queueItems[i].DomainObject);                
            }
        }
        
        [Ignore] [Test]
        public void ShouldGetFunctionalLocationOperationalModeDTOForUnitLevelFLOC()
        {
            FunctionalLocation unitFLOC = FunctionalLocationFixture.GetAny_Unit1();
            FunctionalLocationOperationalModeDTO expectedOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto(unitFLOC.IdValue);

            Expect.Once.On(mockFLOCService).Method("QueryById").With(unitFLOC.IdValue).Will(Return.Value(unitFLOC));
            Expect.Once.On(opModeDTODaoMock).Method("GetForLevel3AndBelowFloc").With(unitFLOC.IdValue).Will(Return.Value(expectedOperationalMode));

            FunctionalLocationOperationalModeDTO actualMode = service.GetByFunctionalLocationId(expectedOperationalMode.IdValue);
            Assert.AreEqual(expectedOperationalMode, actualMode);
        }

        [Ignore] [Test]
        public void ShouldGetFunctionalLocationOperationalModeDTOForBelowUnitLevelFLOC()
        {
            FunctionalLocation equipmentFLOC = FunctionalLocationFixture.GetAny_Equip1();

            FunctionalLocationOperationalModeDTO expectedOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto(equipmentFLOC.IdValue);

            Expect.Once.On(mockFLOCService).Method("QueryById").With(equipmentFLOC.IdValue).Will(Return.Value(equipmentFLOC));
            Expect.Once.On(opModeDTODaoMock).Method("GetForLevel3AndBelowFloc").With(equipmentFLOC.IdValue).Will(Return.Value(expectedOperationalMode));

            FunctionalLocationOperationalModeDTO actualMode = service.GetByFunctionalLocationId(equipmentFLOC.IdValue);
            Assert.AreEqual(expectedOperationalMode, actualMode);
        }
        
        [Test, ExpectedException(typeof (ApplicationException))][Ignore]
        public void ShouldNotBeableToGetFunctionalLocationOperationalModeDTOSectionLevelFLOC()
        {
            FunctionalLocation sectionFLOC = FunctionalLocationFixture.GetAny_Section();
            Expect.Once.On(mockFLOCService).Method("QueryById").With(sectionFLOC.IdValue).Will(Return.Value(sectionFLOC));

            service.GetByFunctionalLocationId(sectionFLOC.IdValue);
        }

        [Test, ExpectedException(typeof (ApplicationException))][Ignore]
        public void ShouldNotBeAbleToGetFunctionalLocationOperationalModeDTODivisionLevelFLOC()
        {
            FunctionalLocation divisionFLOC = FunctionalLocationFixture.GetAny_Division();
            divisionFLOC.Id = 1;
            Expect.Once.On(mockFLOCService).Method("QueryById").With(divisionFLOC.IdValue).Will(Return.Value(divisionFLOC));

            service.GetByFunctionalLocationId(divisionFLOC.Id.Value);
        }
    }
}
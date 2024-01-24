using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Integration;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class EdmontonWorkOrderToWorkPermitRequestDataConverterTest
    {
        private ITimeService timeService;
        private IFunctionalLocationDao functionalLocationDao;
        private IPermitAttributeDao permitAttributeDao;
        private ICraftOrTradeDao craftOrTradeDao;
        private IWorkPermitEdmontonGroupDao groupDao;
        private IAreaLabelDao areaLabelDao;

        [SetUp]
        public void Setup()
        {
            timeService = MockRepository.GenerateStub<ITimeService>();
            functionalLocationDao = MockRepository.GenerateStub<IFunctionalLocationDao>();
            permitAttributeDao = MockRepository.GenerateStub<IPermitAttributeDao>();
            craftOrTradeDao = MockRepository.GenerateStub<ICraftOrTradeDao>();
            groupDao = MockRepository.GenerateStub<IWorkPermitEdmontonGroupDao>();
            areaLabelDao = MockRepository.GenerateStub<IAreaLabelDao>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Ignore] [Test]
        public void ShouldConvertGoodMessageToPermitRequest()
        {
            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            groupDao.Stub(x => x.QueryAll()).Return(new List<WorkPermitEdmontonGroup> { new WorkPermitEdmontonGroup(1, "G1", new List<long> { 4 }, 0, true), new WorkPermitEdmontonGroup(2, "G2", new List<long> { 1 }, 1, false) });
                
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            floc.Site = SiteFixture.Edmonton();
            floc.Description = "Edmonton IFST";

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("ED1-A001-IFST", Site.EDMONTON_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());
            
            CraftOrTrade expectedCraftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(string.Empty, 0)).IgnoreArguments().Return(expectedCraftOrTrade);            

            List<PermitRequestImportRejection> rejects;

            List<PermitRequestEdmonton> permitRequests = 
                converter.ConvertToPermitRequests(GetAFakeWorkOrderRecordList(), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            Assert.IsEmpty(rejects);            

            PermitRequestEdmonton permitRequest = permitRequests[0];
            Assert.IsNotNull(permitRequest);
           
            Assert.AreEqual(expectedCraftOrTrade.ListDisplayText, permitRequest.Occupation);
            Assert.AreEqual(floc.Description, permitRequest.Location);
            Assert.AreEqual("G1", permitRequest.Group.Name);
        }

        [Ignore] [Test]
        public void ShouldSetStartTimeTo7AmIfGroupIsMaintenance()
        {
            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            groupDao.Stub(x => x.QueryAll()).Return(new List<WorkPermitEdmontonGroup> { new WorkPermitEdmontonGroup(1, "G1", new List<long> { 4 }, 0, true), new WorkPermitEdmontonGroup(2, "G2", new List<long> { 1 }, 1, false) });

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            floc.Site = SiteFixture.Edmonton();
            floc.Description = "Edmonton IFST";

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("ED1-A001-IFST", Site.EDMONTON_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());

            CraftOrTrade expectedCraftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(string.Empty, 0)).IgnoreArguments().Return(expectedCraftOrTrade);

            List<PermitRequestImportRejection> rejects;

            List<PermitRequestEdmonton> permitRequests =
                converter.ConvertToPermitRequests(GetAFakeWorkOrderRecordList(), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            Assert.IsEmpty(rejects);

            PermitRequestEdmonton permitRequest = permitRequests[0];
            Assert.IsNotNull(permitRequest);

            Assert.AreEqual(expectedCraftOrTrade.ListDisplayText, permitRequest.Occupation);
            Assert.AreEqual(floc.Description, permitRequest.Location);
            Assert.AreEqual("G1", permitRequest.Group.Name);
            Assert.That(permitRequest.RequestedStartTimeDay, Is.EqualTo(new Time(7, 0, 0)));
        }

        [Ignore] [Test]
        public void ShouldSetAreaLabelBasedOnPlannerGroup()
        {
            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            AreaLabel areaLabel = AreaLabelFixture.CreateWithExistingId();
            areaLabelDao.Stub(x => x.QueryBySiteIdAndPlannerGroup(Arg<long>.Is.Anything, Arg<string>.Is.Anything)).Return(areaLabel);
            
            groupDao.Stub(x => x.QueryAll()).Return(new List<WorkPermitEdmontonGroup> { new WorkPermitEdmontonGroup(1, "G1", new List<long> { 4 }, 0, true), new WorkPermitEdmontonGroup(2, "G2", new List<long> { 1 }, 1, false) });

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            floc.Site = SiteFixture.Edmonton();
            floc.Description = "Edmonton IFST";

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("ED1-A001-IFST", Site.EDMONTON_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());

            CraftOrTrade expectedCraftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(string.Empty, 0)).IgnoreArguments().Return(expectedCraftOrTrade);

            List<PermitRequestImportRejection> rejects;

            List<WorkOrderRecordList> fakeWorkOrderRecordList = GetAFakeWorkOrderRecordList();
            fakeWorkOrderRecordList[0].WorkOrderDetails[0].PlannerGroup = "pg";
            List<PermitRequestEdmonton> permitRequests =
                converter.ConvertToPermitRequests(fakeWorkOrderRecordList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            Assert.IsEmpty(rejects);

            PermitRequestEdmonton permitRequest = permitRequests[0];
            Assert.IsNotNull(permitRequest);

            Assert.AreEqual(areaLabel, permitRequest.AreaLabel);
        }

        [Ignore] [Test]
        public void ShouldSetStartTimeToTimeInRequestIfGroupIsNotSupposeToUseStartOfDayShift()
        {
            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            groupDao.Stub(x => x.QueryAll()).Return(new List<WorkPermitEdmontonGroup> { new WorkPermitEdmontonGroup(3, "G3", new List<long> { 4 }, 0, false), new WorkPermitEdmontonGroup(2, "G2", new List<long> { 1 }, 1, false) });

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            floc.Site = SiteFixture.Edmonton();
            floc.Description = "Edmonton IFST";

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("ED1-A001-IFST", Site.EDMONTON_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());

            CraftOrTrade expectedCraftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(string.Empty, 0)).IgnoreArguments().Return(expectedCraftOrTrade);

            List<PermitRequestImportRejection> rejects;

            List<PermitRequestEdmonton> permitRequests =
                converter.ConvertToPermitRequests(GetAFakeWorkOrderRecordList(), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            Assert.IsEmpty(rejects);

            PermitRequestEdmonton permitRequest = permitRequests[0];
            Assert.IsNotNull(permitRequest);

            Assert.AreEqual(expectedCraftOrTrade.ListDisplayText, permitRequest.Occupation);
            Assert.AreEqual(floc.Description, permitRequest.Location);
            Assert.AreEqual("G3", permitRequest.Group.Name);
            Assert.That(permitRequest.RequestedStartTimeDay, Is.EqualTo(new Time(7, 40, 0)));
        }       

        [Ignore] [Test]
        public void ShouldHandleNullValues()
        {
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId("who cares", 1)).Throw(new Exception("Oh darn."));

            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();
            fakeWorkOrderRecordListList[0].WorkOrderDetails[0].FunctionalLocation = null;

            List<PermitRequestImportRejection> rejects;

            List<PermitRequestEdmonton> permitRequests = converter.ConvertToPermitRequests(fakeWorkOrderRecordListList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            Assert.AreEqual(1, rejects.Count);
            Assert.AreEqual(0, permitRequests.Count);
        }

        [Ignore] [Test]        
        public void ShouldHandleCraftOrTradeThatDoesntExistInOLT()
        {
            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            groupDao.Stub(x => x.QueryAll()).Return(new List<WorkPermitEdmontonGroup> { new WorkPermitEdmontonGroup(1, "G1", new List<long> { 4 }, 0, false) });

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            floc.Site = SiteFixture.Edmonton();
            floc.Description = "Edmonton IFST";

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("ED1-A001-IFST", Site.EDMONTON_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());

            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(string.Empty, 0)).IgnoreArguments().Return(null);

            List<PermitRequestImportRejection> rejects;

            List<PermitRequestEdmonton> permitRequests =
                converter.ConvertToPermitRequests(GetAFakeWorkOrderRecordList(), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            Assert.IsEmpty(rejects);

            PermitRequestEdmonton permitRequest = permitRequests[0];
            Assert.IsNotNull(permitRequest);

            // It should take the info from the message, format it like we do on the dropdown, and save it in the request.
            Assert.AreEqual("Boilermaker, Contrac", permitRequest.Occupation);
        }

        [Ignore] [Test]
        public void ShouldCheckOffGN59IfPermitTypeIsHighEnergyHotWork()
        {
            EdmontonWorkOrderToWorkPermitRequestDataConverter converter
                = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, craftOrTradeDao, groupDao, areaLabelDao);

            groupDao.Stub(x => x.QueryAll()).Return(new List<WorkPermitEdmontonGroup> { new WorkPermitEdmontonGroup(1, "G1", new List<long> { 4 }, 0, false), new WorkPermitEdmontonGroup(2, "G2", new List<long> { 1 }, 1, false) });

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-IFST");
            floc.Site = SiteFixture.Edmonton();
            floc.Description = "Edmonton IFST";

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("ED1-A001-IFST", Site.EDMONTON_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());

            CraftOrTrade expectedCraftOrTrade = CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter();
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(string.Empty, 0)).IgnoreArguments().Return(expectedCraftOrTrade);

            List<PermitRequestImportRejection> rejects;

            // No reason for GN59 to be true
            {
                List<WorkOrderRecordList> fakeWorkOrderRecordList = GetAFakeWorkOrderRecordList();
                fakeWorkOrderRecordList[0].WorkOrderDetails[0].Operations[0].WorkPermitType = WorkOrderWorkPermitEdmontonTypeConverter.ROUTINE_MAINTENANCE;

                List<PermitRequestEdmonton> permitRequests =
                    converter.ConvertToPermitRequests(fakeWorkOrderRecordList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

                Assert.IsEmpty(rejects);

                PermitRequestEdmonton permitRequest = permitRequests[0];
                Assert.IsNotNull(permitRequest);

                Assert.IsFalse(permitRequest.GN59);                          
            }

            // When High Energy Hot Work GN59 is true
            {
                List<WorkOrderRecordList> fakeWorkOrderRecordList = GetAFakeWorkOrderRecordList();
                fakeWorkOrderRecordList[0].WorkOrderDetails[0].Operations[0].WorkPermitType = WorkOrderWorkPermitEdmontonTypeConverter.HIGH_ENERGY_HOT_WORK;

                List<PermitRequestEdmonton> permitRequests =
                    converter.ConvertToPermitRequests(fakeWorkOrderRecordList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

                Assert.IsEmpty(rejects);

                PermitRequestEdmonton permitRequest = permitRequests[0];
                Assert.IsNotNull(permitRequest);

                Assert.IsTrue(!permitRequest.Group.Name.Contains("turnaround") || permitRequest.GN59);                          
            }
        }

        [Ignore] [Test]
       
        public void ShouldHandleAFlocThatDoesntExist()
        {
            Assert.Fail("Dustin - see if Edmonton has rules for this");
            // Dustin: confirm

            //const string flocString = "THIS-DOES-NOT-EXIST-IN-OUR-SYSTEM";

            //WorkOrderToWorkPermitRequestDataConverter converter
            //    = new EdmontonWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            //List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();
            //fakeWorkOrderRecordListList[0].WorkOrderDetails[0].FunctionalLocation = flocString;

            //timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            //functionalLocationDao.Stub(x => x.QueryByFullHierarchy(flocString, Site.EDMONTON_ID)).Return(null);
            //permitAttributeDao.Stub(x => x.QueryBySiteId(Site.EDMONTON_ID)).Return(new List<PermitAttribute>());
            //craftOrTradeDao.Stub(x => x.QueryByWorkCentreNameAndSiteId("BM1P-C", Site.EDMONTON_ID)).Return(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());

            //List<PermitRequestImportRejection> rejects;
            //List<BasePermitRequest> permitRequests = converter.ConvertToPermitRequests(fakeWorkOrderRecordListList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Edmonton(), out rejects);

            //Assert.AreEqual(1, rejects.Count);
            //string errorText = string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationNotFound, flocString);

            //Assert.That(rejects[0].Reason, Contains.Substring(errorText), string.Format("Expected error message '{0}' to contain '{1}'", rejects[0].Reason, errorText));
        }


        private static List<WorkOrderRecordList> GetAFakeWorkOrderRecordList()
        {            
            WorkOrderRecordList workOrderRecordList = new WorkOrderRecordList();
            workOrderRecordList.processStatus = "SUCCESS";
            workOrderRecordList.processMsg = "Parsed WO Complete";
            workOrderRecordList.WorkOrderDetails = new WorkOrderDetails[1];
            workOrderRecordList.WorkOrderDetails[0] = new WorkOrderDetails();
            workOrderRecordList.WorkOrderDetails[0].WONumber = "000030008111";
            workOrderRecordList.WorkOrderDetails[0].ShortText = "Pipeline Transfer to P3E-SAP-100+";
            workOrderRecordList.WorkOrderDetails[0].FunctionalLocation = "ED1-A001-IFST";
            workOrderRecordList.WorkOrderDetails[0].EquipmentNumber = null;
            workOrderRecordList.WorkOrderDetails[0].PlantID = "1300";
            workOrderRecordList.WorkOrderDetails[0].LanguageCode = null;
            workOrderRecordList.WorkOrderDetails[0].Priority = "4";
            workOrderRecordList.WorkOrderDetails[0].Operations = new Operations[1];
            workOrderRecordList.WorkOrderDetails[0].Operations[0] = new Operations();
            workOrderRecordList.WorkOrderDetails[0].Operations[0].OperationKeyNo = "1000027249";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].OperationNumber = "1130";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].Suboperation = "0001";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].EarliestStartDate = "2011-08-14";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].EarliestStartTime = "07:40:00";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].EarliestFinishDate = "2011-08-14";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].EarliestFinishTime = "16:10:00";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].LongText = "setup tools/hoses/compressor";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].WorkPermitType = "7";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].WorkPermitAttrib = @"A\B\C\";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].WorkCenterID = "10001031";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].WorkCenterName = "BM1P-C";
            workOrderRecordList.WorkOrderDetails[0].Operations[0].WorkCenterText = "Boilermaker, Contrac";            

            return new List<WorkOrderRecordList> {workOrderRecordList};            
        }


        /* This XML came from a serialized WorkOrderRecordlistObject. I pasted it in here as an example.
        <?xml version="1.0"?>
        <WorkOrderRecordList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
          <header />
          <processStatus>SUCCESS</processStatus>
          <processMsg>Parsed WO Complete</processMsg>
          <WorkOrderDetails>
            <ArrayOfWorkOrderDetailsItem>
              <WONumber>000030008111</WONumber>
              <ShortText>Pipeline Transfer to P3E-SAP-100+</ShortText>
              <FunctionalLocation>UP1-P007-COMS-SIL-V0064A</FunctionalLocation>
              <EquipmentNumber />
              <PlantID>1300</PlantID>
              <LanguageCode />
              <Operations>
                <ArrayOfOperationsItem>
                  <OperationKeyNo>1000027249</OperationKeyNo>
                  <OperationNumber>1130</OperationNumber>
                  <Suboperation xsi:nil="true" />
                  <EarliestStartDate>2011-08-14</EarliestStartDate>
                  <EarliestStartTime>07:40:00</EarliestStartTime>
                  <EarliestFinishDate>2011-08-14</EarliestFinishDate>
                  <EarliestFinishTime>16:10:00</EarliestFinishTime>
                  <LongText>setup tools/hoses/compressor</LongText>
                  <WorkPermitType />
                  <WorkPermitAttrib />
                  <WorkCenterID>10001031</WorkCenterID>
                  <WorkCenterName>BM1P-C</WorkCenterName>
                  <WorkCenterText>Boilermaker, Contrac</WorkCenterText>
                </ArrayOfOperationsItem>
              </Operations>
            </ArrayOfWorkOrderDetailsItem>
          </WorkOrderDetails>
        </WorkOrderRecordList>
         */
    }
}

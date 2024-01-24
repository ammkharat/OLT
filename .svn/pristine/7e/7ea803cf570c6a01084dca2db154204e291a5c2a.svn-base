using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
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
    public class MontrealWorkOrderToWorkPermitRequestDataConverterTest
    {
        private ITimeService timeService;
        private IFunctionalLocationDao functionalLocationDao;
        private IPermitAttributeDao permitAttributeDao;
        private ICraftOrTradeDao craftOrTradeDao;
        
        [SetUp]
        public void Setup()
        {
            timeService = MockRepository.GenerateStub<ITimeService>();
            functionalLocationDao = MockRepository.GenerateStub<IFunctionalLocationDao>();
            permitAttributeDao = MockRepository.GenerateStub<IPermitAttributeDao>();
            craftOrTradeDao = MockRepository.GenerateStub<ICraftOrTradeDao>();            
        }

        [Ignore] [Test]
        public void ShouldConvertGoodMessageToPermitRequest()
        {
            MontrealWorkOrderToWorkPermitRequestDataConverter converter 
                = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("MT1-A001-U010");

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("MT1-A001-U010", Site.MONTREAL_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId("BM1P-C", Site.MONTREAL_ID)).Return(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter(SiteFixture.Montreal()));

            List<PermitRequestImportRejection> rejects;

            List<WorkOrderImportData> incomingWorkOrderDataList = Convert(GetAFakeWorkOrderRecordList());

            List<PermitRequestMontreal> permitRequests = 
                converter.ConvertToPermitRequests(incomingWorkOrderDataList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);

            Assert.IsEmpty(rejects);
            Assert.IsInstanceOf<PermitRequestMontreal>(permitRequests[0]);


        }

        private List<WorkOrderImportData> Convert(List<WorkOrderRecordList> list)
        {
            SAPWorkOrderToPersistableDataConverter converter = new SAPWorkOrderToPersistableDataConverter();
            return converter.Convert(list, UserFixture.CreateSAPUser(), 1, Clock.Now, Clock.DateNow);
            
        }

        [Ignore] [Test]
        public void ShouldConvertEmptyStringInSubOperationToNull()
        {
            MontrealWorkOrderToWorkPermitRequestDataConverter converter
                = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal("MT1-A001-U010");

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("MT1-A001-U010", Site.MONTREAL_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId("BM1P-C", Site.MONTREAL_ID)).Return(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());

            List<PermitRequestImportRejection> rejects;

            List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();

            fakeWorkOrderRecordListList[0].WorkOrderDetails[0].Operations[0].Suboperation = string.Empty;

            List<PermitRequestMontreal> permitRequests =
                converter.ConvertToPermitRequests(Convert(fakeWorkOrderRecordListList), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);            

            Assert.IsNull(permitRequests[0].SubOperationNumber);
        }

        [Ignore] [Test]
        public void ShouldValidate_FLOCMustBeUnitOrLower_NoDivisionsNorSections()
        {
            MontrealWorkOrderToWorkPermitRequestDataConverter converter 
                = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            const string flocString = "MT1-A001";

            FunctionalLocation floc = FunctionalLocationFixture.GetReal(flocString);

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));
            
            functionalLocationDao.Stub(x => x.QueryByFullHierarchy(flocString, Site.MONTREAL_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId(null, Site.MONTREAL_ID)).IgnoreArguments().Return(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());

            List<PermitRequestImportRejection> rejects;

            List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();
            fakeWorkOrderRecordListList[0].WorkOrderDetails[0].FunctionalLocation = flocString;

            List<PermitRequestMontreal> permitRequests =
                converter.ConvertToPermitRequests(Convert(fakeWorkOrderRecordListList), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);

            Assert.IsEmpty(permitRequests);
            Assert.IsTrue(rejects.Count == 1);

            string errorText =
                string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationCannotBeLevel1Or2, flocString);

            Assert.That(rejects[0].Reason, Contains.Substring(errorText));
        }

        [Ignore] [Test]
        public void ShouldHandleNullValues()
        {
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId("who cares", 1)).Throw(new Exception("Oh darn."));

            MontrealWorkOrderToWorkPermitRequestDataConverter converter
                = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();
            fakeWorkOrderRecordListList[0].WorkOrderDetails[0].Operations[0].WorkCenterName = null;

            List<PermitRequestImportRejection> rejects;

            List<WorkOrderImportData> incomingWorkOrderDataList = Convert(fakeWorkOrderRecordListList);

            List<PermitRequestMontreal> permitRequests = converter.ConvertToPermitRequests(incomingWorkOrderDataList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);

            Assert.AreEqual(1, rejects.Count);
            Assert.AreEqual(0, permitRequests.Count);
        }

        [Ignore] [Test]
        public void ShouldCreateRejectionForTradeNotFound()
        {
            
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("MT1-A001-U010");
            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("MT1-A001-U010", Site.MONTREAL_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());

            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId("CODE_NOT_IN_DB", floc.Site.IdValue)).Return(null);

            MontrealWorkOrderToWorkPermitRequestDataConverter converter
                = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();
            fakeWorkOrderRecordListList[0].WorkOrderDetails[0].Operations[0].WorkCenterName = null;

            List<PermitRequestImportRejection> rejects;

            List<WorkOrderImportData> incomingWorkOrderDataList = Convert(fakeWorkOrderRecordListList);

            List<PermitRequestMontreal> permitRequests = converter.ConvertToPermitRequests(incomingWorkOrderDataList, UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);

            Assert.AreEqual(1, rejects.Count);
            Assert.AreEqual(0, permitRequests.Count);

        }

        [Ignore] [Test]
        public void ShouldHandleAFlocThatDoesntExist()
        {
            const string flocString = "THIS-DOES-NOT-EXIST-IN-OUR-SYSTEM";

            MontrealWorkOrderToWorkPermitRequestDataConverter converter
                = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);

            List<WorkOrderRecordList> fakeWorkOrderRecordListList = GetAFakeWorkOrderRecordList();
            fakeWorkOrderRecordListList[0].WorkOrderDetails[0].FunctionalLocation = flocString;

            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy(flocString, Site.MONTREAL_ID)).Return(null);
            permitAttributeDao.Stub(x => x.QueryBySiteId(Site.MONTREAL_ID)).Return(new List<PermitAttribute>());
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreNameAndSiteId("BM1P-C", Site.MONTREAL_ID)).Return(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter(SiteFixture.Montreal()));

            List<PermitRequestImportRejection> rejects;
            List<PermitRequestMontreal> permitRequests = converter.ConvertToPermitRequests(Convert(fakeWorkOrderRecordListList), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);

            Assert.AreEqual(1, rejects.Count);
            string errorText = string.Format(StringResources.PermitRequestImportValidationError_FunctionalLocationNotFound, flocString);

            Assert.That(rejects[0].Reason, Contains.Substring(errorText), string.Format("Expected error message '{0}' to contain '{1}'", rejects[0].Reason, errorText));
        }


        [Ignore] [Test]
        public void Montreal_ShouldNotUseStartTimeParameter()
        {
            MontrealWorkOrderToWorkPermitRequestDataConverter converter = new MontrealWorkOrderToWorkPermitRequestDataConverter(timeService, functionalLocationDao, permitAttributeDao, craftOrTradeDao);
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("MT1-A001-U010");
            timeService.Stub(x => x.GetTime(Arg<OltTimeZoneInfo>.Is.Anything)).Return(new DateTime(2012, 1, 5));

            functionalLocationDao.Stub(x => x.QueryByFullHierarchy("MT1-A001-U010", Site.MONTREAL_ID)).Return(floc);
            permitAttributeDao.Stub(x => x.QueryBySiteId(floc.Site.IdValue)).Return(new List<PermitAttribute>());
            craftOrTradeDao.Stub(x => x.QueryByWorkCentreCodeAndSiteId("BM1P-C", Site.MONTREAL_ID)).Return(CraftOrTradeFixture.CreateNewCraftOrTradeHoleCutter());

            List<WorkOrderRecordList> aFakeWorkOrderRecordList = GetAFakeWorkOrderRecordList();
            List<PermitRequestImportRejection> rejects;

            {
                aFakeWorkOrderRecordList[0].WorkOrderDetails[0].Operations[0].EarliestStartDate = "2011-08-14";
                aFakeWorkOrderRecordList[0].WorkOrderDetails[0].Operations[0].EarliestStartTime = "07:40:00";

                List<PermitRequestMontreal> permitRequests = converter.ConvertToPermitRequests(Convert(aFakeWorkOrderRecordList), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);
                Assert.AreEqual(new Date(2011, 8, 14), permitRequests[0].StartDate);
            }

            {
                aFakeWorkOrderRecordList[0].WorkOrderDetails[0].Operations[0].EarliestStartDate = "2011-08-14";
                aFakeWorkOrderRecordList[0].WorkOrderDetails[0].Operations[0].EarliestStartTime = "";

                List<PermitRequestMontreal> permitRequests = converter.ConvertToPermitRequests(Convert(aFakeWorkOrderRecordList), UserFixture.CreateOperator(-1, "Nuno"), SiteFixture.Montreal(), out rejects);
                Assert.AreEqual(new Date(2011, 8, 14), permitRequests[0].StartDate);
            }
        }

        public static List<WorkOrderRecordList> GetAFakeWorkOrderRecordList()
        {
            WorkOrderRecordList workOrderRecordList = new WorkOrderRecordList
                {
                    processStatus = "SUCCESS",
                    processMsg = "Parsed WO Complete",
                    WorkOrderDetails = new WorkOrderDetails[1]
                };
            workOrderRecordList.WorkOrderDetails[0] = new WorkOrderDetails
                {
                    WONumber = "000030008111",
                    ShortText = "Pipeline Transfer to P3E-SAP-100+",
                    FunctionalLocation = "MT1-A001-U010",
                    EquipmentNumber = null,
                    PlantID = "302",
                    LanguageCode = null,
                    Operations = new Operations[1]
                };
            workOrderRecordList.WorkOrderDetails[0].Operations[0] = new Operations
                {
                    OperationKeyNo = "1000027249",
                    OperationNumber = "1130",
                    Suboperation = "0001",
                    EarliestStartDate = "2011-08-14",
                    EarliestStartTime = "07:40:00",
                    EarliestFinishDate = "2011-08-14",
                    EarliestFinishTime = "16:10:00",
                    LongText = "setup tools/hoses/compressor",
                    WorkPermitType = "1",
                    WorkPermitAttrib = @"A\B\C\",
                    WorkCenterID = "10001031",
                    WorkCenterName = "BM1P-C",
                    WorkCenterText = "Boilermaker, Contrac"
                };

            List<WorkOrderRecordList> aFakeWorkOrderRecordList = new List<WorkOrderRecordList> { workOrderRecordList };
            return aFakeWorkOrderRecordList;
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

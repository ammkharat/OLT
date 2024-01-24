using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Integration.Handlers.Validators
{
    [TestFixture]
    public class WorkOrderValidatorTest
    {
        private WorkOrderDetails[] details;

        private ILog mockLogger;
        private WorkOrderValidator validator;

        [SetUp]
        public void SetUp()
        {
            mockLogger = MockRepository.GenerateStub<ILog>();

            validator = new WorkOrderValidator(mockLogger);

            details = new WorkOrderDetails[1];
            details[0] = new WorkOrderDetails
            {
                WorkOrderNumber = Constants.WORK_ORDER_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits(),
                ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits(),
                FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits(),
                EquipmentNumber = Constants.EQUIPMENT_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits(),
                PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits()
            };

            var operations = new Operations[1];
            operations[0] = new Operations();
            details[0].Operations = operations;
            details[0].Operations[0].OperationNumber =
                Constants.WORK_ORDER_OPERATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].Suboperation = Constants.SUBOPERATION_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].EarliestStartDate = Constants.DATE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].EarliestStartTime = Constants.TIME_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].EarliestFinishDate = Constants.DATE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].EarliestFinishTime = Constants.TIME_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].LongText = Constants.LONG_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].WorkPermitType =
                Constants.WORK_ORDER_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].WorkPermitAttrib = 6.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].WorkCenterID =
                Constants.WORK_ORDER_WORK_CENTRE_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].WorkCenterName =
                Constants.WORK_ORDER_WORK_CENTRE_NAME_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].Operations[0].WorkCenterText =
                Constants.WORK_ORDER_WORK_CENTRE_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldParseUserSecurityFromXML()
        {
            const string testXml = @"<WorkOrderOLTdata>
                  <WorkOrderRecord>
                      <WorkOrderDetails>
                          <WONumber>wow no.</WONumber>                          
                          <ShortText>short text</ShortText>                          
                          <FunctionalLocation>floc</FunctionalLocation>
                          <EquipmentNumber>equip no</EquipmentNumber>
                          <PlantID>plant id</PlantID>
                          <Operations>
                              <OperationNumber>op no.</OperationNumber>
                              <OperationKeyNo>op key no.</OperationKeyNo>
                              <SubOperation>supop</SubOperation>
                              <EarliestStartDate>2001-01-01</EarliestStartDate>
                              <EarliestStartTime>11:59:59</EarliestStartTime>
                              <EarliestFinishDate>2002-01-01</EarliestFinishDate>
                              <EarliestFinishTime>11:58:58</EarliestFinishTime>
                              <LongText>long text</LongText>
                              <WorkPermitType>type</WorkPermitType>
                              <WorkPermitAttrib>attribute</WorkPermitAttrib>
                                <WorkCenterID>work centre id no</WorkCenterID>
                                <WorkCenterName>work centre name</WorkCenterName>
                                <WorkCenterText>work centre text</WorkCenterText>
                          </Operations>
                      </WorkOrderDetails>
                  </WorkOrderRecord>
              </WorkOrderOLTdata>";

            using (var stream = testXml.CreateMemoryStream())
            {
                var detail = validator.Parse(stream).WorkOrderRecord.WorkOrderDetails[0];
                Assert.AreEqual("wow no.", detail.WorkOrderNumber);
                Assert.AreEqual("short text", detail.ShortText);
                Assert.AreEqual("floc", detail.FunctionalLocation);
                Assert.AreEqual("equip no", detail.EquipmentNumber);
                Assert.AreEqual("plant id", detail.PlantID);
                Assert.AreEqual("op no.", detail.Operations[0].OperationNumber);
                Assert.AreEqual("op key no.", detail.Operations[0].OperationKeyNumber);
                Assert.AreEqual("supop", detail.Operations[0].Suboperation);
                Assert.AreEqual("2001-01-01", detail.Operations[0].EarliestStartDate);
                Assert.AreEqual("11:59:59", detail.Operations[0].EarliestStartTime);
                Assert.AreEqual("2002-01-01", detail.Operations[0].EarliestFinishDate);
                Assert.AreEqual("11:58:58", detail.Operations[0].EarliestFinishTime);
                Assert.AreEqual("long text", detail.Operations[0].LongText);
                Assert.AreEqual("type", detail.Operations[0].WorkPermitType);
                Assert.AreEqual("attribute", detail.Operations[0].WorkPermitAttrib);
                Assert.AreEqual("work centre id no", detail.Operations[0].WorkCenterID);
                Assert.AreEqual("work centre name", detail.Operations[0].WorkCenterName);
                Assert.AreEqual("work centre text", detail.Operations[0].WorkCenterText);
            }
        }

        [Test]
        public void ShouldReturnFalseIfWorkOrderNumberIsInvalid()
        {
            details[0].WorkOrderNumber = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].WorkOrderNumber = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].WorkOrderNumber = (Constants.WORK_ORDER_NUMBER_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }
    }
}
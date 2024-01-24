using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Integration.Handlers;
using Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures;
using Com.Suncor.Olt.Integration.HTTPHandlers.Utilities;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.HTTPHandlers
{
    [TestFixture]
    [Category("Integration")]
    public class WorkOrderHandlerFunctionalTest
    {
        [Test][Ignore]
        public void AddValidWorkOrder()
        {
            var msg = SAPFixture.GetFileData("AddValidWorkOrder.xml");
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void FirstWorkOrderSend()
        {
            var msg = SAPFixture.GetFileData("FirstWorkOrderSend.xml");
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test, Ignore]
        public void FloodTest()
        {
            var autoNumber = GetAutoNumber();

            var addMsg = SAPFixture.GetFileData("WorkPermit-Flood.xml", "GENERATE_IN_TEST", autoNumber);
            var i = 0;
            do
            {
                var sender = new MessageSender();

//                string response = sender.SyncSubmit(addMsg, "http://oltqutcgy001:8091/WorkOrder.ashx");
                var response = sender.SyncSubmit(addMsg, "http://oltsbxcgy002.network.sbx:8091/WorkOrder.ashx");
                Assert.That(response, Is.EqualTo("<OK/>"));

                i++;
                if (i%5 == 0)
                {
                    var previousAutoNumber = autoNumber;
                    autoNumber = GetAutoNumber();
                    addMsg = addMsg.Replace(previousAutoNumber, autoNumber);
                }
            } while (i < 1000);
        }

        [Test][Ignore]
        public void InsertAndUpdateShouldNotUpdateForSameWorkPermit()
        {
            var autoNumber = GetAutoNumber();

            //string addMsg = SAPFixture.GetFileData("WorkPermit-Add-Update-Only-Once.xml", "GENERATE_IN_TEST", autoNumber);
            var addMsg = SAPFixture.GetFileData("WorkPermit-Add-Update-Only-Once.xml", "GENERATE_IN_TEST", autoNumber);

            var sender = new MessageSender();

            var response = sender.SyncSubmit(addMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var count =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM WorkPermitHistory WHERE [WorkOrderNumber] like '{0}%' and WorkOrderDescription like '%{1}%'",
                        autoNumber, "Add-Test2"));
            Assert.AreEqual(1, count);

            // resend, shouldn't cause an update if nothing changes.
            response = sender.SyncSubmit(addMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            count =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM WorkPermitHistory WHERE [WorkOrderNumber] like '{0}%' and WorkOrderDescription like '%{1}%'",
                        autoNumber, "Add-Test2"));
            Assert.AreEqual(1, count);
        }

        [Test][Ignore]
        public void InsertAndUpdateWorkPermit()
        {
            var autoNumber = GetAutoNumber();

            var addMsg = SAPFixture.GetFileData("WorkPermit-Add.xml", "GENERATE_IN_TEST", autoNumber);
            var updateMsg = SAPFixture.GetFileData("WorkPermit-Update.xml", "GENERATE_IN_TEST", autoNumber);

            var sender = new MessageSender();

            var response = sender.SyncSubmit(addMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var addCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM WorkPermit WHERE [WorkOrderNumber] like '{0}%' and WorkOrderDescription like '%{1}%'",
                        autoNumber, "Add-Test"));
            Assert.AreEqual(3, addCount);


            response = sender.SyncSubmit(updateMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var updateCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM WorkPermit WHERE [WorkOrderNumber] like '{0}%' and WorkOrderDescription like '%{1}%'",
                        autoNumber, "Update-Test"));

            Assert.AreEqual(3, updateCount);

            updateCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM WorkPermit WHERE [WorkOrderNumber] like '{0}%' and WorkOrderDescription like '%{1}%'",
                        autoNumber, "Add-Test"));

            Assert.AreEqual(0, updateCount);
        }

        [Test][Ignore]
        public void InsertWithLowerCaseType()
        {
            var msg = SAPFixture.GetFileData("WorkOrderWithTypeAllLowerCase.xml", "GENERATE_IN_TEST", GetAutoNumber());
            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);

            Assert.AreEqual("<OK/>", response);
        }

        [Test]
        [Ignore]
        public void ProdAI()
        {
            var msg = SAPFixture.GetFileData("DuplicatingWorkOrderAsActionItem.xml");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);

            Assert.AreEqual("<OK/>", response);
        }

        [Test]
        [Ignore]
        public void SecondWorkOrderSend()
        {
            var msg = SAPFixture.GetFileData("SecondWorkOrderSend.xml");
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test]
        [Ignore]
        public void ShouldNotUpdateWorkOrderAsAnActionItemDefinitionIfNothingChanged()
        {
            var autoNumber = GetAutoNumber();

            var message = SAPFixture.GetFileData("WorkOrder-Add-Update-Only-Once.xml", "GENERATE_IN_TEST", autoNumber);

            var sender = new MessageSender();
            var response = sender.SyncSubmit(message, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var count =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinitionHistory WHERE [Name] like '{0}%' and Description like '%{1}%'",
                        autoNumber, "Add-Test2"));
            Assert.AreEqual(1, count);

            response = sender.SyncSubmit(message, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            count =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinitionHistory WHERE [Name] like '{0}%' and Description like '%{1}%'",
                        autoNumber, "Add-Test2"));

            Assert.AreEqual(1, count);
        }

        [Test]
        [Ignore]
        public void UpdateActionItemThatCameThroughAsWorkOrder()
        {
            var autoNumber = GetAutoNumber();

            var addMsg = SAPFixture.GetFileData("WorkOrder-Add.xml", "GENERATE_IN_TEST", autoNumber);
            var updateMsg = SAPFixture.GetFileData("WorkOrder-Update.xml", "GENERATE_IN_TEST", autoNumber);

            var sender = new MessageSender();
            var response = sender.SyncSubmit(addMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var addCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinition WHERE [Name] like '{0}%' and Description like '%{1}%'",
                        autoNumber, "Add-Test"));
            Assert.AreEqual(1, addCount);

            response = sender.SyncSubmit(updateMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var updateCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinition WHERE [Name] like '{0}%' and Description like '%{1}%'",
                        autoNumber, "Update-Test"));

            Assert.AreEqual(1, updateCount);

            updateCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinition WHERE [Name] like '{0}%' and Description like '%{1}%'",
                        autoNumber, "Add-Test"));

            Assert.AreEqual(0, updateCount);
        }

        [Test]
        [Ignore]
        public void UpdateApprovedActionItemShouldStayAsApproved()
        {
            var autoNumber = GetAutoNumber();

            var addMsg = SAPFixture.GetFileData("AutoApprovedActionItem.xml", "GENERATE_IN_TEST", autoNumber);
            var updateMsg = SAPFixture.GetFileData("AutoApprovedActionItemUpdated.xml", "GENERATE_IN_TEST", autoNumber);

            var sender = new MessageSender();
            var response = sender.SyncSubmit(addMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            TestDataAccessUtil.ExecuteExpression(string.Format(
                "update ActionItemDefinition set ActionItemDefinitionStatusId = 1, Active = 1, RequiresApproval = 0 WHERE [Name] like '{0}%' and Description like '%{1}%' ",
                autoNumber, "AutoApprove Add"));

            var addCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinition WHERE [Name] like '{0}%' and Description like '%{1}%' and ActionItemDefinitionStatusId = 1",
                        autoNumber, "AutoApprove Add"));
            Assert.AreEqual(1, addCount);


            response = sender.SyncSubmit(updateMsg, Constants.WORK_ORDER_URL);
            Assert.AreEqual("<OK/>", response);

            var updateCount =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM ActionItemDefinition WHERE [Name] like '{0}%' and Description like '%{1}%' and ActionItemDefinitionStatusId = 1",
                        autoNumber, "AutoApprove Update"));

            // should not update an auto-approved action item definition
            Assert.AreEqual(0, updateCount);
        }

        [Test]
        [Ignore]
        public void WorkOrderActionItemDefinitionSend()
        {
            var msg = SAPFixture.GetFileData("WorkOrderActionItemDefinitionSend.xml");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);

            Assert.AreEqual("<OK/>", response);
        }

        [Test]
        [Ignore]
        public void WorkOrderActionItemDefinitionSendAtLevelOneFloc()
        {
            var msg = SAPFixture.GetFileData("WorkOrderActionItemDefinitionSendLevelOneFloc.xml");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);

            Assert.AreEqual("<OK/>", response);
        }

        [Test]
        [Ignore]
        public void WorkOrderActionItemDefinitionSendAtLevelTwoFloc()
        {
            var msg = SAPFixture.GetFileData("WorkOrderActionItemDefinitionSendLevelTwoFloc.xml");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);

            Assert.AreEqual("<OK/>", response);
        }

        [Test]
        [Ignore]
        public void WorkOrderToTestLastModifiedUserIdSend()
        {
            var msg = SAPFixture.GetFileData("WorkOrderWithNullLastModifiedUser.xml");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.WORK_ORDER_URL);

            Assert.AreEqual("<OK/>", response);
        }

        private static string GetAutoNumber()
        {
            var ticks = DateTimeFixture.DateTimeNow.Ticks.ToString();

            return ticks.Substring(ticks.Length - Common.Utility.Constants.WORK_ORDER_NUMBER_MAX_LENGTH,
                Common.Utility.Constants.WORK_ORDER_NUMBER_MAX_LENGTH);
        }
    }
}
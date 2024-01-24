using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Bootstrap;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SapWorkOrderOperationDaoTest : AbstractDaoTest
    {
        private static ISapWorkOrderOperationDao dao;

        protected override void TestInitialize() {}
        protected override void Cleanup() {}

        [TestFixtureSetUp]
        public void SetUpClass()
        {
            Bootstrapper.BootstrapDaos();
            dao = DaoRegistry.GetDao<ISapWorkOrderOperationDao>();
        }

        [Ignore] [Test]
        public void ShouldFindInsertedActionItemSapWorkOrderOperation()
        {
            const string workOrderNumber = "12345";
            const string operationNumber = "2222";
            const string subOperation = "3333";
            
            SapOperationType operationType = SapOperationType.ActionItemDefinition;
            SapWorkOrderOperation operation = new SapWorkOrderOperation(null, workOrderNumber, operationNumber, subOperation, operationType);

            SapWorkOrderOperation newlyInsertedOperation = dao.Insert(operation);

            Assert.IsNotNull(newlyInsertedOperation);
            Assert.IsNotNull(newlyInsertedOperation.Id);
            
            SapWorkOrderOperation foundOperation = dao.FindByKeys(workOrderNumber, operationNumber, subOperation, operationType);

            Assert.IsNotNull(foundOperation);
            Assert.IsNotNull(foundOperation.Id);
            Assert.AreEqual(workOrderNumber, foundOperation.WorkOrderNumber);
            Assert.AreEqual(operationNumber, foundOperation.OperationNumber);
            Assert.AreEqual(subOperation, foundOperation.SubOperation);
            Assert.AreEqual(operationType, foundOperation.SapOperationType);
        }

        [Ignore] [Test]
        public void ShouldQuerySapWorkOrderOperationBasedOnSapOperationType()
        {
            const string workOrderNumber = "12345";
            const string operationNumber = "2222";
            const string subOperation = "3333";

            SapWorkOrderOperation operationOfTypeWorkPermit = new SapWorkOrderOperation(null, workOrderNumber, operationNumber, subOperation, SapOperationType.WorkPermit);
            dao.Insert(operationOfTypeWorkPermit);

            SapWorkOrderOperation foundOperation = dao.FindByKeys(workOrderNumber, operationNumber, subOperation, SapOperationType.ActionItemDefinition);
            Assert.IsNull(foundOperation);
        }
        
        [Ignore] [Test]
        public void ShouldQueryByKeysWhenSubOperationIsNull()
        {
            const string workOrderNumber = "00007000342";
            const string operationNumber = "0010";

            SapWorkOrderOperation operationWithoutNull = 
                Insert(workOrderNumber, operationNumber, "XXXX", SapOperationType.ActionItemDefinition);
            SapWorkOrderOperation operationWithNull = 
                Insert(workOrderNumber, operationNumber, null, SapOperationType.WorkPermit);

            SapWorkOrderOperation foundOperation = dao.FindByKeys(workOrderNumber, operationNumber, null, SapOperationType.WorkPermit);
            AssertSapWorkOrderOperation(operationWithNull, foundOperation);
            Assert.IsTrue(foundOperation.Id.HasValue);
        }

        private SapWorkOrderOperation Insert(string workOrderNumber, string operationNumber, string subOperation,
            SapOperationType sapOperationType)
        {
            return dao.Insert(new SapWorkOrderOperation(null, workOrderNumber, operationNumber, subOperation, sapOperationType));
        }

        private void AssertSapWorkOrderOperation(SapWorkOrderOperation expected, SapWorkOrderOperation actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.WorkOrderNumber, actual.WorkOrderNumber);
            Assert.AreEqual(expected.OperationNumber, actual.OperationNumber);
            Assert.AreEqual(expected.SubOperation, actual.SubOperation);
            Assert.AreEqual(expected.SapOperationType, actual.SapOperationType);
        }
    }
}

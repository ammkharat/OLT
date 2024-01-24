using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [TestFixture]
    public class WorkOrderImportDataTest
    {
        [Test]
        public void ShouldRemoveDuplicates()
        {
            WorkOrderImportData data1 = CreateWorkOrderImportData("1", "22", null);
            WorkOrderImportData data2 = CreateWorkOrderImportData("1", "22", "33");
            WorkOrderImportData data3 = CreateWorkOrderImportData("1", "22", "44");

            List<WorkOrderImportData> data = new List<WorkOrderImportData>() { data1, data2, data3 };

            List<WorkOrderImportData> workOrderImportDatas = WorkOrderImportData.RemoveDuplicates(data);
            Assert.AreEqual(3, workOrderImportDatas.Count);

            data.Add(CreateWorkOrderImportData("1", "22", null));
            workOrderImportDatas = WorkOrderImportData.RemoveDuplicates(data);
            Assert.AreEqual(3, workOrderImportDatas.Count);
            
            data.Add(CreateWorkOrderImportData("1", "22", "33"));
            workOrderImportDatas = WorkOrderImportData.RemoveDuplicates(data);
            Assert.AreEqual(3, workOrderImportDatas.Count);            
        }

        private WorkOrderImportData CreateWorkOrderImportData(string workOrderNumber, string operation, string suboperation)
        {
            WorkOrderImportData data1 = new WorkOrderImportData(1, Clock.Now, null);
            data1.WONumber = workOrderNumber;
            data1.OperationNumber = operation;
            data1.Suboperation = suboperation;

            return data1;
        }
    }
}

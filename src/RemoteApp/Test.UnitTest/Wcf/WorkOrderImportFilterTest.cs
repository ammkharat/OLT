using System.Collections.Generic;
using Com.Suncor.Olt.Remote.Integration;
using Com.Suncor.Olt.Remote.Utilities;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Wcf
{
    [TestFixture]
    public class WorkOrderImportFilterTest
    {
        [Ignore] [Test]
        public void ShouldFilterByWorkOrderNumber()
        {
            List<WorkOrderRecordList> details = MontrealWorkOrderToWorkPermitRequestDataConverterTest.GetAFakeWorkOrderRecordList();
            details.AddRange(MontrealWorkOrderToWorkPermitRequestDataConverterTest.GetAFakeWorkOrderRecordList());

            details[0].WorkOrderDetails[0].WONumber = "abc123";
            details[1].WorkOrderDetails[0].WONumber = "456xyz123";

            WorkOrderImportFilter filter = new WorkOrderImportFilter();

            {
                List<WorkOrderRecordList> workOrderRecordLists = filter.FilterResults(details, "zzyzzxy");
                Assert.IsEmpty(workOrderRecordLists);                
            }

            {
                List<WorkOrderRecordList> workOrderDetailses = filter.FilterResults(details, null);
                Assert.AreEqual(2, workOrderDetailses.Count);           
            }    
        
            {
                List<WorkOrderRecordList> workOrderDetailses = filter.FilterResults(details, "abc123");
                Assert.AreEqual(1, workOrderDetailses.Count);           
            }   
         
            {
                List<WorkOrderRecordList> workOrderDetailses = filter.FilterResults(details, "456xyz123");
                Assert.AreEqual(1, workOrderDetailses.Count);           
            }

            // ends with
            {
                List<WorkOrderRecordList> workOrderDetailses = filter.FilterResults(details, "c123");
                Assert.AreEqual(1, workOrderDetailses.Count);
            } 
           
            // ends with
            {
                List<WorkOrderRecordList> workOrderDetailses = filter.FilterResults(details, "123");
                Assert.AreEqual(2, workOrderDetailses.Count);
            }            
        }
        
    }
}

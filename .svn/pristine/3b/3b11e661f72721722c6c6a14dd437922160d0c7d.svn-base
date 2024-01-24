using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class LubesMergingPermitRequestPersistenceProcessorTest
    {
        [Ignore] [Test]
        public void ExistingMergedRequestIsUnmodified_OneIncomingWorkorderHasChanged_Scenario1()
        {
            List<IMergeablePermitRequest> existingPermitRequests;
            List<ISAPImportData> incomingPermitRequests;
            List<WorkOrderImportData> allWorkOrderImportData;

            const bool existingHazardHydrocarbonGasValue = false;
            const bool incomingHazardHydrocarbonGasValue = true;

            // existing requests
            {

                PermitRequestLubes existingPermitRequest = GetExistingPermitRequestWith3Sources();              
                existingPermitRequest.HazardHydrocarbonGas = existingHazardHydrocarbonGasValue;
                existingPermitRequests = new List<IMergeablePermitRequest> { existingPermitRequest };                
            }            

            // incoming requests
            {
                // This will have a change, causing it to merge
                PermitRequestLubes incomingPermitRequest1 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest1.ClearWorkOrderSources();
                incomingPermitRequest1.AddWorkOrderSource("1111", "0001", null);                
                incomingPermitRequest1.HazardHydrocarbonGas = incomingHazardHydrocarbonGasValue;

                // No change here.
                PermitRequestLubes incomingPermitRequest2 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest2.ClearWorkOrderSources();
                incomingPermitRequest2.AddWorkOrderSource("1111", "0002", null);            
            
                // No third incoming permit request                

                incomingPermitRequests = new List<ISAPImportData> { incomingPermitRequest1, incomingPermitRequest2 };
            }

            {                
                WorkOrderImportData data1 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data1.WONumber = "1111";
                data1.OperationNumber = "0001";                

                WorkOrderImportData data2 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data2.WONumber = "1111";
                data2.OperationNumber = "0002";                
               
                allWorkOrderImportData = new List<WorkOrderImportData> { data1, data2 };
            }

            LubesMergingPermitRequestPersistenceProcessor processor = new LubesMergingPermitRequestPersistenceProcessor(existingPermitRequests, incomingPermitRequests, allWorkOrderImportData, Clock.Now, UserFixture.CreateUserWithGivenId(1));

            processor.Process();

            Assert.AreEqual(1, processor.UpdateList.Count);
            PermitRequestLubes result = (PermitRequestLubes) processor.UpdateList[0];
            Assert.AreEqual(2, result.WorkOrderSourceList.Count);
            Assert.IsTrue(result.WorkOrderSourceList.Exists(wos => wos.Matches("1111", "0001", null)));
            Assert.IsTrue(result.WorkOrderSourceList.Exists(wos => wos.Matches("1111", "0002", null)));
            Assert.AreEqual(incomingHazardHydrocarbonGasValue, result.HazardHydrocarbonGas);
        }

        [Ignore] [Test]
        public void OnlyDateValuesHaveChanged_ExistingRequestHasNotBeenSubmitted_Scenario3()
        {
            List<IMergeablePermitRequest> existingPermitRequests;
            List<ISAPImportData> incomingPermitRequests;
            List<WorkOrderImportData> allWorkOrderImportData;

            Date existingStartDate = new Date(2014, 1, 1);
            Date incomingStartDate = new Date(2014, 2, 2);
            Date incomingStartDate2 = new Date(2014, 1, 15);

            Date endDate = new Date(2014, 3, 1);

            // existing requests
            {
                PermitRequestLubes existingPermitRequest = GetExistingPermitRequestWith3Sources();
                existingPermitRequest.RequestedStartDate = existingStartDate;
                existingPermitRequest.EndDate = endDate;
                existingPermitRequest.LastSubmittedDateTime = null; // not submitted
                existingPermitRequests = new List<IMergeablePermitRequest> { existingPermitRequest };
            }

            // incoming requests
            {
                // change the date
                PermitRequestLubes incomingPermitRequest1 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest1.ClearWorkOrderSources();
                incomingPermitRequest1.AddWorkOrderSource("1111", "0001", null);
                incomingPermitRequest1.RequestedStartDate = incomingStartDate;
                incomingPermitRequest1.EndDate = endDate;

                // No change here.
                PermitRequestLubes incomingPermitRequest2 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest2.RequestedStartDate = incomingStartDate2;
                incomingPermitRequest2.EndDate = endDate;

                incomingPermitRequest2.ClearWorkOrderSources();
                incomingPermitRequest2.AddWorkOrderSource("1111", "0002", null);

                // No third incoming permit request                

                incomingPermitRequests = new List<ISAPImportData> { incomingPermitRequest1, incomingPermitRequest2 };
            }
            
            {
                WorkOrderImportData data1 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data1.WONumber = "1111";
                data1.OperationNumber = "0001";

                WorkOrderImportData data2 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data2.WONumber = "1111";
                data2.OperationNumber = "0002";

                allWorkOrderImportData = new List<WorkOrderImportData> { data1, data2 };
            }

            LubesMergingPermitRequestPersistenceProcessor processor = new LubesMergingPermitRequestPersistenceProcessor(existingPermitRequests, incomingPermitRequests, allWorkOrderImportData, Clock.Now, UserFixture.CreateUserWithGivenId(1));

            processor.Process();

            Assert.AreEqual(1, processor.UpdateList.Count);
            PermitRequestLubes result = (PermitRequestLubes)processor.UpdateList[0];
            Assert.AreEqual(2, result.WorkOrderSourceList.Count);
            Assert.IsTrue(result.WorkOrderSourceList.Exists(wos => wos.Matches("1111", "0001", null)));
            Assert.IsTrue(result.WorkOrderSourceList.Exists(wos => wos.Matches("1111", "0002", null)));
            Assert.AreEqual(incomingStartDate2, result.RequestedStartDate); // The merging code will take the earliest date
           // Assert.IsTrue(result.OnlyDatesAreDifferent((PermitRequestLubes) existingPermitRequests[0])); This assertion fails because the descriptions are different.
        }

        [Ignore] [Test]
        public void ExistingRequest_2Incoming_OrderShouldntMatter()
        {
            // This is a test for a defect where the order of the incoming operation lines matters. If the first one doesn't match the existing, then it won't merge with it.
            PermitRequestLubes existing = GetExistingPermitRequestWith1Source();
            existing.ClearWorkOrderSources();
            existing.AddWorkOrderSource("1111", "0002", null);            
            List<IMergeablePermitRequest> existingPermitRequests = new List<PermitRequestLubes> { existing }.ConvertAll(prl => (IMergeablePermitRequest) prl);
            List<ISAPImportData> incomingPermitRequests;
            List<WorkOrderImportData> allWorkOrderImportData;

            // all work order data (for descriptions)
            {
                WorkOrderImportData data1 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data1.WONumber = "1111";
                data1.OperationNumber = "0001";

                WorkOrderImportData data2 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data2.WONumber = "1111";
                data2.OperationNumber = "0002";

                allWorkOrderImportData = new List<WorkOrderImportData> { data1, data2 };
            }

            // incoming requests
            {                
                PermitRequestLubes incomingPermitRequest1 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));                
                incomingPermitRequest1.ClearWorkOrderSources();
                incomingPermitRequest1.AddWorkOrderSource("1111", "0002", null);                                
              
                PermitRequestLubes incomingPermitRequest2 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest2.ClearWorkOrderSources();
                incomingPermitRequest2.AddWorkOrderSource("1111", "0001", null);
                
                incomingPermitRequests = new List<ISAPImportData> { incomingPermitRequest1, incomingPermitRequest2 };
            }

            LubesMergingPermitRequestPersistenceProcessor processor =
                new LubesMergingPermitRequestPersistenceProcessor(existingPermitRequests, incomingPermitRequests, allWorkOrderImportData, Clock.Now, UserFixture.CreateUserWithGivenId(1));
            processor.Process();

            Assert.AreEqual(1, processor.UpdateList.Count);
            Assert.AreEqual(0, processor.InsertList.Count);
            Assert.AreEqual(0, processor.DeleteList.Count);          
        }

        [Ignore] [Test]
        public void OneDoNotMergeAndOneMergeInSameWorkOrder()
        {           
            List<IMergeablePermitRequest> existingPermitRequests = new List<PermitRequestLubes>().ConvertAll(prl => (IMergeablePermitRequest)prl);
            List<ISAPImportData> incomingPermitRequests;
            List<WorkOrderImportData> allWorkOrderImportData;

            // all work order data (for descriptions)
            {
                WorkOrderImportData data1 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data1.WONumber = "1111";
                data1.OperationNumber = "0001";

                WorkOrderImportData data2 = new WorkOrderImportData(1, Clock.Now, UserFixture.CreateUserWithGivenId(1));
                data2.WONumber = "1111";
                data2.OperationNumber = "0002";

                allWorkOrderImportData = new List<WorkOrderImportData> { data1, data2 };
            }

            // incoming requests
            {
                PermitRequestLubes incomingPermitRequest1 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest1.ClearWorkOrderSources();
                incomingPermitRequest1.AddWorkOrderSource("1111", "0001", null);
                incomingPermitRequest1.DoNotMerge = true;
                
                PermitRequestLubes incomingPermitRequest2 = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1));
                incomingPermitRequest2.ClearWorkOrderSources();
                incomingPermitRequest2.AddWorkOrderSource("1111", "0002", null);

                incomingPermitRequests = new List<ISAPImportData> { incomingPermitRequest1, incomingPermitRequest2 };
            }

            LubesMergingPermitRequestPersistenceProcessor processor =
                new LubesMergingPermitRequestPersistenceProcessor(existingPermitRequests, incomingPermitRequests, allWorkOrderImportData, Clock.Now, UserFixture.CreateUserWithGivenId(1));
            processor.Process();

            Assert.AreEqual(0, processor.UpdateList.Count);
            Assert.AreEqual(2, processor.InsertList.Count);
            Assert.AreEqual(0, processor.DeleteList.Count);
            
        }

        private void ClearOutSomeHazardFieldsForTesting(PermitRequestLubes permitRequest)
        {
            permitRequest.HazardHydrocarbonGas = false;
            permitRequest.HazardHydrocarbonLiquid = false;
            permitRequest.HazardHydrogenSulphide = false;
        }

        private PermitRequestLubes GetExistingPermitRequestWith3Sources()
        {
            PermitRequestLubes existingPermitRequest = GetExistingPermitRequestWith1Source();
            existingPermitRequest.AddWorkOrderSource("1111", "0002", null);
            existingPermitRequest.AddWorkOrderSource("1111", "0003", null);

            return existingPermitRequest;
        }

        private PermitRequestLubes GetExistingPermitRequestWith1Source()
        {
            PermitRequestLubes existingPermitRequest = PermitRequestLubesFixture.CreateForInsert(new WorkPermitLubesGroup(1, "Group", 1), DataSource.SAP);            
            existingPermitRequest.Id = 42;
            existingPermitRequest.IsModified = false;
            existingPermitRequest.LastSubmittedDateTime = null;
            existingPermitRequest.ClearWorkOrderSources();
            existingPermitRequest.AddWorkOrderSource("1111", "0001", null);

            return existingPermitRequest;
        }
    }
}

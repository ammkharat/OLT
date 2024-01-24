using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkOrderImportDataDaoTest : AbstractDaoTest
    {
        private IWorkOrderImportDataDao dao;                
        private FunctionalLocation flocForTesting;        
        
        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkOrderImportDataDao>();                        
            flocForTesting = FunctionalLocationFixture.GetReal("MI1-A001-IFST");           
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]   
        public void ShouldInsertThenQueryByBatchIdAndDeleteByBatchId()
        {
            long batchId = dao.GetBatchId();

            DateTime now = Clock.Now;
            User createdByUser = UserFixture.CreateSupervisor();

            WorkOrderImportData importDataThatWillBeInserted = WorkOrderImportDataFixture.CreateForInsert(batchId, now, flocForTesting, createdByUser);
            importDataThatWillBeInserted.WorkPermitAttrib = @"LA\LB\LC\LD\LE\LF\LG\LH\LI\LJ\LK\LL\LM\LN\LO\LP\LQ\LR\LS\LT\LU";   // make sure we can fit a lot of attributes

            dao.Insert(importDataThatWillBeInserted);
            List<WorkOrderImportData> resultList = dao.QueryByBatchId(batchId);
            WorkOrderImportData requeried = resultList[0];

            AssertPermitFieldValues(importDataThatWillBeInserted, requeried);

            dao.Delete(batchId);
            List<WorkOrderImportData> resultList2 = dao.QueryByBatchId(batchId);
            Assert.IsEmpty(resultList2);            
        }

        [Ignore] [Test]
        public void ShouldGetBatchId()
        {
            long batchId = dao.GetBatchId();
            long batchId2 = dao.GetBatchId();
            long batchId3 = dao.GetBatchId();

            Assert.IsTrue(batchId > 0);
            Assert.IsTrue(batchId2 > 0);
            Assert.IsTrue(batchId3 > 0);
            
            Assert.IsTrue(batchId != batchId2);
            Assert.IsTrue(batchId2 != batchId3);
            Assert.IsTrue(batchId3 != batchId);
        }     

        public void AssertPermitFieldValues(WorkOrderImportData importData, WorkOrderImportData requeriedImportData)
        {            
            Assert.AreEqual(importData.BatchId, requeriedImportData.BatchId);            
            Assert.That(importData.BatchItemCreatedDateTime, Is.EqualTo(requeriedImportData.BatchItemCreatedDateTime).Within(TimeSpan.FromMilliseconds(500)));
            
            Assert.AreEqual(importData.ImportDate, requeriedImportData.ImportDate);

            Assert.AreEqual(importData.ProcessStatus, requeriedImportData.ProcessStatus);
            Assert.AreEqual(importData.WONumber, requeriedImportData.WONumber); 
            Assert.AreEqual(importData.ShortText, requeriedImportData.ShortText); 
            Assert.AreEqual(importData.FunctionalLocation, requeriedImportData.FunctionalLocation); 
            Assert.AreEqual(importData.EquipmentNumber, requeriedImportData.EquipmentNumber); 
            Assert.AreEqual(importData.PlantId, requeriedImportData.PlantId); 
            Assert.AreEqual(importData.LanguageCode, requeriedImportData.LanguageCode); 
            Assert.AreEqual(importData.Priority, requeriedImportData.Priority); 
            Assert.AreEqual(importData.PlannerGroup, requeriedImportData.PlannerGroup); 
            Assert.AreEqual(importData.OperationKeyNo, requeriedImportData.OperationKeyNo); 
            Assert.AreEqual(importData.OperationNumber, requeriedImportData.OperationNumber); 
            Assert.AreEqual(importData.Suboperation, requeriedImportData.Suboperation); 
            Assert.AreEqual(importData.EarliestStartDate, requeriedImportData.EarliestStartDate); 
            Assert.AreEqual(importData.EarliestStartTime, requeriedImportData.EarliestStartTime); 
            Assert.AreEqual(importData.EarliestFinishDate, requeriedImportData.EarliestFinishDate); 
            Assert.AreEqual(importData.EarliestFinishTime, requeriedImportData.EarliestFinishTime); 
            Assert.AreEqual(importData.LongText, requeriedImportData.LongText); 
            Assert.AreEqual(importData.WorkPermitType, requeriedImportData.WorkPermitType); 
            Assert.AreEqual(importData.WorkPermitAttrib, requeriedImportData.WorkPermitAttrib); 
            Assert.AreEqual(importData.WorkCenterID, requeriedImportData.WorkCenterID); 
            Assert.AreEqual(importData.WorkCenterName, requeriedImportData.WorkCenterName);
            Assert.AreEqual(importData.WorkCenterText, requeriedImportData.WorkCenterText); 
        }
    }
}

using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkOrderImportDataFixture
    {
        public static WorkOrderImportData Create(string workOrderNumber, string operationNumber, string suboperationNumber)
        {
            return CreateForInsert(42, DateTime.Now, workOrderNumber, operationNumber, suboperationNumber, FunctionalLocationFixture.GetReal_ED1_A001_U008(), UserFixture.CreateUserWithGivenId(1));
        }

        public static WorkOrderImportData CreateForInsert(long batchId, DateTime batchCreatedAt, FunctionalLocation floc, User createdBy)
        {
            return CreateForInsert(batchId, batchCreatedAt, "12345", "0110", "0110", floc, createdBy);
        }

        public static WorkOrderImportData CreateForInsert(long batchId, DateTime batchCreatedAt, string workOrderNumber, string operationNumber, string suboperationNumber, FunctionalLocation floc, User createdBy)
        {
            WorkOrderImportData importData = new WorkOrderImportData(batchId, batchCreatedAt, createdBy);

            importData.ImportDate = new Date(batchCreatedAt);
            importData.BatchId = batchId;
            importData.BatchItemCreatedDateTime = batchCreatedAt;
            importData.SubmittedByUser = createdBy;

            importData.ProcessStatus = "SUCCESS";

            importData.WONumber = workOrderNumber;
            importData.ShortText = "This is the short text";

            importData.FunctionalLocation = floc.FullHierarchy;
            importData.EquipmentNumber = "12345";
            importData.PlantId = "2005";
            importData.LanguageCode = "EN";
            importData.Priority = "4";
            importData.PlannerGroup = "PG";
            importData.OperationKeyNo = "45567";
            importData.OperationNumber = operationNumber;
            importData.Suboperation = suboperationNumber;
            importData.EarliestStartDate = "2013-02-04";
            importData.EarliestStartTime = "14:44:06";
            importData.EarliestFinishDate = "2013-10-31";
            importData.EarliestFinishTime = "14:44:06";
            importData.LongText = "Long Text";
            importData.WorkPermitType = "1";
            importData.WorkPermitAttrib = @"EA\FA\";
            importData.WorkCenterID = "10005181";
            importData.WorkCenterName = "BM4";
            importData.WorkCenterText = "Boilermaker, Utiliti";

            return importData;
        }
    }
}

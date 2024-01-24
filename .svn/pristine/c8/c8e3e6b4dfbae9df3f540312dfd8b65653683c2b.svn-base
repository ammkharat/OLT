using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Integration;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class SAPWorkOrderToPersistableDataConverter
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<SAPWorkOrderToPersistableDataConverter>();

        public List<WorkOrderImportData> Convert(IEnumerable<WorkOrderRecordList> workOrderRecordLists, User userThatInitiatedImport, long batchId, DateTime dateTimeAtSite, Date importDate)
        {                        
            List<WorkOrderImportData> permitRequests = new List<WorkOrderImportData>();
           
            foreach (WorkOrderRecordList workOrderRecordList in workOrderRecordLists)
            {
                string processStatus = workOrderRecordList.processStatus; 
                WorkOrderDetails detail = workOrderRecordList.WorkOrderDetails[0];
                              
                Operations[] operationsList = detail.Operations;

                foreach (Operations operations in operationsList)
                {                    
                    try
                    {
                        WorkOrderImportData permitRequest = BuildWorkOrderImportData(processStatus, detail, operations, userThatInitiatedImport, batchId, dateTimeAtSite, importDate);

                        if (permitRequest != null)
                        {
                            permitRequests.Add(permitRequest);
                        }                        
                    }
                    catch (Exception e)
                    {
                        logger.Error("There was an unexpected error processing an operation.", e);                        
                    }
                }                
            }
            
            return permitRequests;
        }

        private WorkOrderImportData BuildWorkOrderImportData(string processsStatus, WorkOrderDetails detail, Operations operations, User userThatInitiatedImport, long batchId, DateTime dateTimeAtSite, Date importDate)
        {
            WorkOrderImportData data = new WorkOrderImportData(batchId, dateTimeAtSite, userThatInitiatedImport)
                {
                    ImportDate = importDate,
                    ProcessStatus = processsStatus,
                    WONumber = detail.WONumber,
                    ShortText = detail.ShortText,
                    FunctionalLocation = detail.FunctionalLocation,
                    EquipmentNumber = detail.EquipmentNumber,
                    PlantId = detail.PlantID,
                    LanguageCode = detail.LanguageCode,
                    Priority = detail.Priority,
                    PlannerGroup = detail.PlannerGroup,
                    OperationKeyNo = operations.OperationKeyNo,
                    OperationNumber = operations.OperationNumber,
                    Suboperation = operations.Suboperation,
                    EarliestStartDate = operations.EarliestStartDate,
                    EarliestStartTime = operations.EarliestStartTime,
                    EarliestFinishDate = operations.EarliestFinishDate,
                    EarliestFinishTime = operations.EarliestFinishTime,
                    LongText = operations.LongText,
                    WorkPermitType = operations.WorkPermitType,
                    WorkPermitAttrib = operations.WorkPermitAttrib,
                    WorkCenterID = operations.WorkCenterID,
                    WorkCenterName = operations.WorkCenterName,
                    WorkCenterText = operations.WorkCenterText
                };

            return data;
        }
    }
}
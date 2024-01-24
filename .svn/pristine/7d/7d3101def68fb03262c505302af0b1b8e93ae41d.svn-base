using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Integration.Handlers.Adapters;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using Com.Suncor.Olt.Integration.Handlers.Validators;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class WorkOrderMessageHandler
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (WorkOrderMessageHandler));

        /// <summary>
        ///     Processes the XML data (supplied by SAP-IDD0308)
        ///     The work order messages from SAP may contain either items that require
        ///     the creation of action items and optionally work permit records
        /// </summary>
        /// <param name="stream">Memory stream containing the decoded XML data</param>
        public bool ProcessWorkOrder(Stream stream)
        {
            var validator = new WorkOrderValidator();
            var workOrder = validator.Parse(stream);

            if (!HasData(workOrder))
            {
                return false;
            }

            var workOrderDetails = workOrder.WorkOrderRecord.WorkOrderDetails;

            LogMessageEntry(workOrderDetails);

            var valid = validator.DoesPassRequirementsCheck(workOrderDetails);
            if (!valid)
                return false;

            var adapter = new WorkOrderAdapter(workOrderDetails);
            adapter.IntegrateWorkOrdersToOperatorLogTool();
            return true;
        }

        private static void LogMessageEntry(IEnumerable<WorkOrderDetails> workOrderDetails)
        {
            foreach (var detail in workOrderDetails)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("WorkOrder {0} received for {1}. ShortText is {2}, LanguageCode is: {3}",
                        detail.WorkOrderNumber,
                        detail.FunctionalLocation,
                        detail.ShortText,
                        detail.LanguageCode);
                }
                else
                {
                    logger.InfoFormat("WorkOrder {0} for {1} received.", detail.WorkOrderNumber,
                        detail.FunctionalLocation);
                }
            }
        }

        private bool HasData(WorkOrder workOrder)
        {
            if (workOrder == null)
            {
                logger.Error("Did not get a work order after parsing the message.");
                return false;
            }
            if (workOrder.WorkOrderRecord == null)
            {
                logger.Error("No Work Order Record found in message.");
                return false;
            }
            if (workOrder.WorkOrderRecord.WorkOrderDetails == null)
            {
                logger.Error("No Work Order Details found in message.");
                return false;
            }
            if (workOrder.WorkOrderRecord.WorkOrderDetails.Length == 0)
            {
                logger.Info("No details records found in the message");
                return false;
            }
            return true;
        }
    }
}
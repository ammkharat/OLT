using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Validators
{
    /// <summary>
    ///     The class processes a memory stream containing an XML based WorkOrder
    ///     message and deserialises it into a object before validating its
    ///     content.
    /// </summary>
    public class WorkOrderValidator : Validator
    {
        private readonly ILog logger;

        public WorkOrderValidator() : this(LogManager.GetLogger(typeof (WorkOrderValidator)))
        {
        }

        public WorkOrderValidator(ILog logger)
        {
            this.logger = logger;
        }

        public WorkOrder Parse(Stream stream)
        {
            // The XML document to deserialize into the XmlSerializer object.
            using (var reader = XmlReader.Create(stream))
            {
                // Use the XmlSerializer object to convert the XML
                var serializer = new XmlSerializer(typeof (WorkOrder));
                return (WorkOrder) serializer.Deserialize(reader);
            }
        }

        public bool DoesPassRequirementsCheck(IEnumerable<WorkOrderDetails> workOrderDetails)
        {
            var result = true;
            var logMessage = new StringBuilder();

            foreach (var details in workOrderDetails)
            {
                logMessage.AppendFormat("Requirements Check for Work Order Number: {0}{1}", details.WorkOrderNumber,
                    Environment.NewLine);
                var valid = true;

                if (FailsIsRequiredAndSizeCheck(details.WorkOrderNumber, Constants.WORK_ORDER_NUMBER_MAX_LENGTH))
                {
                    logMessage.AppendFormat("WorkOrderNumber is invalid. Was: {0}{1}", details.WorkOrderNumber,
                        Environment.NewLine);
                    valid = false;
                }

                if (FailsIsRequiredAndSizeCheck(details.ShortText, Constants.SHORT_TEXT_MAX_LENGTH))
                {
                    logMessage.AppendFormat("ShortText is invalid. Was: {0}{1}", details.ShortText, Environment.NewLine);
                    valid = false;
                }

/*
                if (FailsIsRequiredAndSizeCheck(details.FunctionalLocation, Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH))
                {
                    logMessage.AppendFormat("FunctionalLocation is invalid. Was: {0}{1}", details.FunctionalLocation, Environment.NewLine);
                    valid = false;
                }
*/

/*
                if (FailsNotRequiredAndSizeCheck(details.EquipmentNumber, Constants.EQUIPMENT_NUMBER_MAX_LENGTH))
                {
                    logMessage.AppendFormat("EquipmentNumber is invalid. Was: {0}{1}", details.EquipmentNumber, Environment.NewLine);
                    valid = false;
                }
*/

/*
                if (FailsIsRequiredAndSizeCheck(details.PlantID, Constants.PLANT_ID_MAX_LENGTH))
                {
                    logMessage.AppendFormat("PlantID is invalid. Was: {0}{1}", details.PlantID, Environment.NewLine);
                    valid = false;
                }
*/

                // A work order must contain at least one operation, so iterate through
                // the object array validating the data
                var operations = details.Operations;
                if (operations != null)
                {
                    foreach (var operation in operations)
                    {
                        if (FailsIsRequiredAndSizeCheck(operation.OperationNumber,
                            Constants.WORK_ORDER_OPERATION_NUMBER_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("OperationNumber is invalid. Was: {0}{1}", operation.OperationNumber,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (FailsNotRequiredAndSizeCheck(operation.Suboperation, Constants.SUBOPERATION_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("Suboperation is invalid. Was: {0}{1}", operation.Suboperation,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.EarliestStartDate, Constants.DATE_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("EarliestStartDate is invalid. Was: {0}{1}",
                                operation.EarliestStartDate, Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.EarliestStartTime, Constants.TIME_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("EarliestStartTime is invalid. Was: {0}{1}",
                                operation.EarliestStartTime, Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.EarliestFinishDate, Constants.DATE_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("EarliestFinishDate is invalid. Was: {0}{1}",
                                operation.EarliestFinishDate, Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.EarliestFinishTime, Constants.TIME_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("EarliestFinishTime is invalid. Was: {0}{1}",
                                operation.EarliestFinishTime, Environment.NewLine);
                            valid = false;
                        }

                        if (FailsNotRequiredAndSizeCheck(operation.LongText, Constants.LONG_TEXT_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("LongText is invalid. Was: {0}{1}", operation.LongText,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (FailsNotRequiredAndSizeCheck(operation.WorkPermitType, Constants.WORK_ORDER_TYPE_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("WorkPermitType is invalid. Was: {0}{1}", operation.WorkPermitType,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.WorkCenterID,
                            Constants.WORK_ORDER_WORK_CENTRE_ID_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("WorkCenterCode is invalid. Was: {0}{1}", operation.WorkCenterID,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.WorkCenterName,
                            Constants.WORK_ORDER_WORK_CENTRE_NAME_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("WorkCenterName is invalid. Was: {0}{1}", operation.WorkCenterName,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (FailsIsRequiredAndSizeCheck(operation.WorkCenterText,
                            Constants.WORK_ORDER_WORK_CENTRE_TEXT_MAX_LENGTH))
                        {
                            logMessage.AppendFormat("WorkCenterText is invalid. Was: {0}{1}", operation.WorkCenterText,
                                Environment.NewLine);
                            valid = false;
                        }

                        if (valid)
                        {
                            logMessage.Append(" successfully passed requirements check in Work Order Validator.");
                            logger.Debug(logMessage.ToString());
                        }
                        else
                        {
                            logger.Error(logMessage.ToString());
                            result = false;
                        }
                    }
                }
                else
                {
                    logMessage.AppendFormat("Operations check for the Work Order returned null. {0}",
                        Environment.NewLine);
                    logger.Error(logMessage.ToString());
                    result = false;
                }
            }

            return result;
        }
    }
}
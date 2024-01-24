using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Exceptions;
using Com.Suncor.Olt.Remote.Integration;
using log4net;


// TODO: This shouldn't be in this namespace. This is reserved for stuff that is a wrapper around wcf noise, not clients that happen to be wcf clients/proxies.
namespace Com.Suncor.Olt.Remote.Wcf
{    
    public class WorkOrderImporter
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<WorkOrderImporter>();

        public const string SUCCESS_STATUS = "SUCCESS";

        private readonly WorkOrderImportSettings workOrderImportSettings;        

        public WorkOrderImporter(WorkOrderImportSettings workOrderImportSettings)
        {
            this.workOrderImportSettings = workOrderImportSettings;
        }

        public List<WorkOrderRecordList> ImportWorkOrders(Date @from, long plantId, string workOrderNumberFilterCriteria)
        {            
            BasicHttpBinding binding = new BasicHttpBinding
            {
                CloseTimeout = workOrderImportSettings.CloseTimeout,
                OpenTimeout = workOrderImportSettings.OpenTimeout,
                ReceiveTimeout = workOrderImportSettings.ReceiveTimeout,
                SendTimeout = workOrderImportSettings.SendTimeout,
                MaxBufferSize = workOrderImportSettings.MaxBufferSize,
                MaxReceivedMessageSize = workOrderImportSettings.MaxReceivedMessageSize,
                MaxBufferPoolSize = workOrderImportSettings.MaxBufferPoolSize,
                ReaderQuotas =
                {
                    MaxDepth = workOrderImportSettings.ReaderQuotasMaxDepth,
                    MaxStringContentLength = workOrderImportSettings.MaxStringContentLength,
                    MaxArrayLength = workOrderImportSettings.MaxArrayLength
                }
            };

            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            string uri = workOrderImportSettings.URI;
            EndpointAddress endpointAddress = new EndpointAddress(uri);

            using (MrSapUtils_PortTypeClient client = new MrSapUtils_PortTypeClient(binding, endpointAddress))
            {
                client.ClientCredentials.UserName.UserName = workOrderImportSettings.UserName;
                client.ClientCredentials.UserName.Password = workOrderImportSettings.Password;                  

                MrWorkOrderFindReq request = new MrWorkOrderFindReq();
                request.header = new reqSoapHeader {InitiatedBy = "OLT", InitiatedSystem = "OLT"};

                string transactionKey = Guid.NewGuid().ToString();
                request.header.SystemTransactionKey = transactionKey;

                request.mrWorkOrderFindReqBody = new mrWorkOrderFindReqBody {plantId = Convert.ToString(plantId)};

                string fromString = from.ToDateTimeAtStartOfDay().ToString("yyyyMMdd");
                request.mrWorkOrderFindReqBody.workOrderDate = fromString;

                MrWorkOrderFindRsp results;

                try
                {
                    results = client.mrWorkOrderFind(request);                    
                }
                catch (Exception e)
                {
                    string message = string.Format(
                            "An exception was thrown while importing work order data from SAP via WebMethods. Help desk error code: {0}, Transaction Key: {1}, QueryDate: {2}, Plant Id: {3}",
                                ErrorCodes.WebMethodsPermitRequestImportException, transactionKey, fromString, plantId);
                    logger.Error(message, e);
                    throw new WorkOrderSAPImportException(ErrorCodes.WebMethodsPermitRequestImportException, e);                        
                }

                if (results != null && results.header.CallStatus == SUCCESS_STATUS)
                {
                    if (logger.IsDebugEnabled && results.mrWorkOrderFindRspBody.WorkOrderOLTdata == null)
                    {
                        logger.Debug("A Work Permit import completed without error, but no data was returned");
                    }
                    
                    if (results.mrWorkOrderFindRspBody != null &&
                        results.mrWorkOrderFindRspBody.WorkOrderOLTdata != null &&
                        results.mrWorkOrderFindRspBody.WorkOrderOLTdata.WorkOrderRecordList != null)
                    {
                        //SerializeForDebugging(results);

                        // This is sort of a weird case that happened in release 4.4 with the new Priority field. We get a record back with all the fields empty.
                        // This code will return an empty list if the numberOfRecords field is "0" but if it's anything else it will just continue on like it always has. (Dustin, Oct. 2012)
                        string numberOfRecords = results.mrWorkOrderFindRspBody.numberOfRecords;
                        if (numberOfRecords != null && "0".Equals(numberOfRecords))
                        {
                            return new List<WorkOrderRecordList>();
                        }

                        WorkOrderRecordList[] workOrderRecordList =
                            results.mrWorkOrderFindRspBody.WorkOrderOLTdata.WorkOrderRecordList;

                        if(logger.IsDebugEnabled)
                        {
                            logger.Debug(
                                string.Format("{0} WorkOrder messages were received from a Work Permit import", 
                                    workOrderRecordList.Length));
                        }

                        WorkOrderImportFilter filter = new WorkOrderImportFilter();
                        List<WorkOrderRecordList> workOrderRecordListList =
                            filter.FilterResults(new List<WorkOrderRecordList>(workOrderRecordList), workOrderNumberFilterCriteria);
                                            
                        return workOrderRecordListList;
                    }                   
                }
                else
                {
                    string msg = (results != null && results.mrWorkOrderFindRspBody != null)
                        ? results.mrWorkOrderFindRspBody.sapCallMsg : null;
                    
                    string callStatus = (results != null && results.header != null) ? results.header.CallStatus : null;

                    string message =
                        string.Format(
                            "WebMethods has reported a CallStatus other than {6}. Help desk error code: {0}, CallStatus: {1}, Transaction Key: {2}, Query Date: {3}, Plant Id: {4}, webMethods MSG: {5}",
                                ErrorCodes.WebMethodsPermitRequestImportUnsuccessful, callStatus, transactionKey, fromString, plantId, msg, SUCCESS_STATUS);
                    logger.Error(message);                    
                    throw new WorkOrderSAPImportException(ErrorCodes.WebMethodsPermitRequestImportUnsuccessful);
                }

                client.Close();

                return new List<WorkOrderRecordList>();
            }
        }

        private static void SerializeForDebugging(MrWorkOrderFindRsp results)
        {                        
            XmlSerializer xs = new XmlSerializer(results.GetType());
            StringBuilder sb = new StringBuilder();
            string result = null;
            using (TextWriter writer = new StringWriter(sb))
            {
                xs.Serialize(writer, results);
                result = writer.ToString();
            }
        }
    }
}

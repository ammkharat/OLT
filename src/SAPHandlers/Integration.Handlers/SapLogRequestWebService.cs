using System;
using System.Net;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.SAP.WebService;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class SapLogRequestWebService
    {
        private static readonly ILog logger = LogManager.GetLogger("SAPHandlerWeb");

        public static void SendMessage(string message, Exception exception, string program, string subObjectSLG1,
            string sourceReference)
        {
            try
            {
                var logInput = CreateSapLogRequestInput(message, exception, program, subObjectSLG1,
                    sourceReference, "Red");
                var service = new SuncorCommonWebService_WebServiceService();

                var cache = new CredentialCache();
                var networkCredentials = new NetworkCredential(Constants.OLTSAPWebServiceUser,
                    Constants.OLTSAPWebServicePassword);

                cache.Add(new Uri(new Uri(Constants.OLTSAPWebServiceHost), Constants.OLTSAPWebServiceLogRequestURL),
                    "Basic",
                    networkCredentials);

                service.Credentials = networkCredentials;
                var response = service.SubmitSapLogRequest(logInput);
                logger.Info(String.Format("Error message sent to SAP via web service. Success: {0} Status: {1}",
                    response.Success, response.Status));
            }
            catch (Exception e)
            {
                logger.Error("Failed to send error message to SAP web service.", e);
            }
        }

        private static SapLogRequestInput CreateSapLogRequestInput(string message, Exception exception,
            string integrationName, string subObjectSLG1, string sourceReference, string color)
        {
            var sapLogInput = new SapLogRequestInput
            {
                objectSLG1 = "ZOLT",
                messageText = String.Format("{0} - {1}", message, exception.Message),
                integrationName = integrationName,
                subObjectSLG1 = subObjectSLG1,
                sourceReference = sourceReference,
                messageColour = color
            };
            return sapLogInput;
        }
    }
}
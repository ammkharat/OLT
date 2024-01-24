<%@ WebHandler Language="C#" Class="WorkOrder" %>

using System;
using System.Web;
using System.IO;
using log4net;
using Com.Suncor.Olt.Integration.Handlers;

/// <summary>
/// The WorkOrder Http Handler class implement the receiving functionality
/// for the SAP HTTP posting of data (IDD0308).
/// 
/// </summary>
public class WorkOrder : IHttpHandler {

    /// <summary>
    /// Logger class providing event log support for error reporting
    /// </summary>
    private static readonly ILog logger = LogManager.GetLogger(typeof(WorkOrder));

    /// <summary>
    /// Implemented interface class and is the entry point for the HTTPHandler
    /// </summary>
    /// <param name="context">ASP.NET context object</param>
    public void ProcessRequest(HttpContext context)
    {

        // Set default XML message to indicate error
        // If the message is processed sucessfully then this will be changed to OK
        string rtnResponse;

        try
        {
            // Validate the inbound message if it contains invalid data then
            // an exception is thrown
            context.Request.ValidateInput();

            // Store for decoded and decompressed data
            Stream inputStream = context.Request.InputStream;

            // Now we have the MemoryStream containing the message, pass this to the
            // logic layer to process the message.
            WorkOrderMessageHandler messageHandler = new WorkOrderMessageHandler();
            bool processSucceeded = messageHandler.ProcessWorkOrder(inputStream);

            rtnResponse = processSucceeded ? "<OK/>" : "<Error>See OLT logs for specific errors.</Error>";
        }
        catch (HttpRequestValidationException ex)
        {
            // Log error in event log
            logger.Error("The SAP Work Order HTTP POST message contained invalid data", ex);
            rtnResponse = "<Error>The Work Order request message contained invalid data</Error>";
        }
        catch (ApplicationException appEx)
        {
            logger.ErrorFormat("The SAP Work Order message produced an error while in the WorkOrderAdapter. {0}", appEx);
            rtnResponse = "<Error/>";
        }
        catch (Exception ex)
        {
            logger.Error("The SAP Work Order message was not processed.", ex);
            rtnResponse = "<Error/>";
        }

        // Send valid response to posting application
        // This will be an xml message with either OK or Error element
        context.Response.ContentType = "text/xml";
        context.Response.Write(rtnResponse);
    }

    /// <summary>
    /// Interface method, not implemented
    /// </summary>
    public bool IsReusable {
        get {
            return false;
        }
    }

}
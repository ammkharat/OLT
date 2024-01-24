<%@ WebHandler Language="C#" Class="Notification" %>

using System;
using System.Text;
using System.Web;
using System.IO;
using log4net;
using Com.Suncor.Olt.Integration.Handlers;

/// <summary>
/// The Notification Http Handler class implement the receiving functionality
/// for the SAP HTTP posting of data (IDD0309).
/// 
/// The handler receives base64 encoded/GZip data, which it decodes into
/// XML before validating and processing.
/// </summary>
public class Notification : IHttpHandler {

    /// <summary>
    /// Logger class providing event log support for error reporting
    /// </summary>
    private static readonly ILog logger = LogManager.GetLogger(typeof(Notification));

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
            context.Request.ContentEncoding = Encoding.Default;
            Stream inputStream = context.Request.InputStream;

            // Now we have the MemoryStream containing the message, pass this to the
            // logic layer to process the message.
            NotificationMessageHandler handler = new NotificationMessageHandler();
            bool processSucceeded = handler.ProcessNotification(inputStream);
            rtnResponse = processSucceeded ? "<OK/>" : "<Error>See OLT logs for specific errors.</Error>";
        }
        catch (HttpRequestValidationException ex)
        {
            // Log error in event log
            logger.Error("The SAP Notification HTTP POST message contained invalid data", ex);
            rtnResponse = "<Error>The Notification request message contained invalid data</Error>";
        }
        catch (ApplicationException appEx)
        {
            logger.ErrorFormat("The SAP Notification message produced an error while in the NotificationAdapter. {0}", appEx);
            if (appEx.InnerException != null)
            {
                logger.ErrorFormat("Inner Exception: {0}", appEx.InnerException);
            }

            rtnResponse = "<Error/>";
        }
        catch (Exception ex)
        {
            logger.Error("The SAP Notification message was not processed.", ex);
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
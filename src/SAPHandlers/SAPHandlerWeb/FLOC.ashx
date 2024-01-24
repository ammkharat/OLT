<%@ WebHandler Language="C#" Class="FLOC" %>

using System;
using System.Text;
using System.Web;
using System.IO;
using log4net;
using Com.Suncor.Olt.Integration.Handlers;

/// <summary>
/// The FLOC Http Handler class implement the receiving functionality
/// for the SAP HTTP posting of data (IDD0307).
/// 
/// </summary>
public class FLOC : IHttpHandler {

    /// <summary>
    /// Logger class providing event log support for error reporting
    /// </summary>
    private static readonly ILog logger = LogManager.GetLogger(typeof(FLOC));

    /// <summary>
    /// Implemented interface class and is the entry point for the HTTPHandler
    /// </summary>
    /// <param name="context">ASP.NET context object</param>
    public void ProcessRequest(HttpContext context)
    {

        // Set default XML message to indicate error
        // If the message is processed sucessfully then this will be changed to OK
        string rtnResponse;

        // Store for decoded and decompressed data

        try
        {
            // Validate the inbound message if it contains invalid data then
            // an exception is thrown
            context.Request.ValidateInput();
            context.Request.ContentEncoding = Encoding.Default;
            Stream inputStream = context.Request.InputStream;

            // Now we have the XMLDocument containing the message pass this to the
            // logic layer to process the message.
            FunctionalLocationMessageHandler messageHandler = new FunctionalLocationMessageHandler();
            messageHandler.ProcessFunctionalLocation(inputStream);
                        
            // Everything completed OK, so set the acknolegdement response
            rtnResponse = "<OK/>";
        }
        catch (HttpRequestValidationException ex)
        {
            // Log error in event log
            logger.Error("The SAP FLOC HTTP POST message contained invalid data", ex);
            rtnResponse = "<Error>The FLOC request message contained invalid data</Error>";
        }
        catch (ApplicationException appEx)
        {
            logger.Error("The SAP FLOC message produced an error while in the FunctionalLocationAdapter. {0}", appEx);
            rtnResponse = "<Error/>";
        }
        catch (Exception ex)
        {
            logger.Error("The SAP FLOC message was not processed.", ex);
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
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}
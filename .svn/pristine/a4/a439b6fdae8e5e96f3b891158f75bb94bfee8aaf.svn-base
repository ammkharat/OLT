<%@ WebHandler Language="C#" Class="Ping" %>

using System.Web;

/// <summary>
/// Ping HTTP Handler that provides a heartbeat support for WebMethods
/// </summary>
public class Ping : IHttpHandler {

    /// <summary>
    /// Implemented interface class and is the entry point for the HTTPHandler
    /// </summary>
    /// <param name="context">ASP.NET context object</param>
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/xml";
        context.Response.Write("<OK></OK>");
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
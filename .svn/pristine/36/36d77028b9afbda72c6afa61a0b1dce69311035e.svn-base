<%@ WebHandler Language="C#" Class="ClientLog" Debug="true" %>

using System;
using System.IO;
using System.Web;
using log4net;

public class ClientLog : IHttpHandler 
{
    private static readonly ILog logger = LogManager.GetLogger(typeof(ClientLog));
    
    public void ProcessRequest (HttpContext context) 
    {
        try 
        {
            context.Request.ValidateInput();
            Stream inputStream = context.Request.InputStream;
            StreamReader streamReader = new StreamReader(inputStream);
            string input = streamReader.ReadToEnd();
            streamReader.Close();

            logger.Error("The following error log was sent from a client." + Environment.NewLine + Pad(input));

            context.Response.ContentType = "text/xml";
            context.Response.Write("<OK></OK>");        	
        }
        catch (Exception e)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Error processing client log: " + e);
        }
    }

    private static string Pad(string s)
    {
        const string pad = "     ";
        return pad + s.Replace(Environment.NewLine, Environment.NewLine + pad);
    }

    public bool IsReusable 
    {
        get { return false; }
    }

}
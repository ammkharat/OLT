<%@ Import namespace="System.Diagnostics"%>
<%@ Import namespace="System.IO"%>
<%@ Import Namespace="Com.Suncor.Olt.Common.Wcf" %>
<%@ Import Namespace="Com.Suncor.Olt.PlantHistorian" %>
<%@ Import Namespace="Com.Suncor.Olt.Remote.Bootstrap" %>

<%@ Application Language="C#" %>
<%@ Import Namespace="Com.Suncor.Olt.Remote.Wcf" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        string dll = Path.Combine(Server.MapPath(""), ConfigurationManager.AppSettings["RemoteAppFile"]);
        if (File.Exists(dll)) 
        {
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(dll);
            Application["RemoteAppVersion"] = info.FileVersion;
        }

        string buildConfiguration = ConfigurationManager.AppSettings["BuildConfiguration"];
        Application["BuildConfiguration"] = buildConfiguration;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        Bootstrapper.Reset();
        GenericServiceRegistry.Instance.CloseAll();
        ClientEventPushServiceRegistry.Instance.CloseAll();
        PlantHistorianGateway.Cleanup();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

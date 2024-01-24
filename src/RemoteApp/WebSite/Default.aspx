<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Welcome to the operator log tool</title>
</head>
<body>
Welcome to the Operator Log Tool Remote Service Website.<br /><br />
Version: <%= Application["RemoteAppVersion"]%><br />
BuildConfiguration: <%= Application["BuildConfiguration"]%><br />
.NET Version: <%= Environment.Version %><br />
</body>
</html>

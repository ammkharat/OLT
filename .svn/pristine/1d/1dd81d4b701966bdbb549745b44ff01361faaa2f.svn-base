using System;
using System.Deployment.Application;
using System.Reflection;
using System.Text;
using Com.Suncor.Olt.Client.Services;

namespace Com.Suncor.Olt.Client
{
    public class UserLoginLogEntry
    {
        private const string NullString = "<null>";

        public static string CreateLogMessage()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                // The following is not translated because the contents are meant for an English speaking support person.
                sb.AppendLine("Client URI: " + ClientServiceRegistry.Instance.ClientServiceHostAddress);
                sb.AppendLine("User: " + GetUser());
                sb.AppendLine("Shift: " + GetShift());
                sb.AppendLine("Site: " + GetSite());
                sb.AppendLine("Role: " + GetRole());
                sb.AppendLine("Assignment: " + GetAssignment());
                sb.AppendLine("Version: " + GetVersion());
                sb.AppendLine("Deployment: " + GetDeployment());
                sb.AppendLine("OS Version: " + GetOperatingSystemVersion());
            }
            catch
            {
            }

            return sb.ToString();
        }

        private static string GetOperatingSystemVersion()
        {
            return Environment.OSVersion.ToString();
        }

        private static string GetUser()
        {
            UserContext userContext = ClientSession.GetUserContext();
            if (userContext != null &&
                userContext.User != null &&
                userContext.User.Id.HasValue)
            {
                return String.Format("[Id:{0}] [Name:{1}]",
                                     userContext.User.Id,
                                     userContext.User.FullNameWithUserName);
            }
            return NullString;
        }

        private static string GetShift()
        {
            UserContext userContext = ClientSession.GetUserContext();
            if (userContext != null &&
                userContext.UserShift != null &&
                userContext.UserShift.ShiftPattern != null)
            {
                return String.Format("[Id:{0}] [Name:{1}]",
                                     userContext.UserShift.ShiftPattern.Id,
                                     userContext.UserShift.ShiftPattern.DisplayName);
            }
            return NullString;
        }

        private static string GetSite()
        {
            UserContext userContext = ClientSession.GetUserContext();
            if (userContext != null &&
                userContext.Site != null)
            {
                return String.Format("[Id:{0}] [Name:{1}]",
                                     userContext.Site.Id,
                                     userContext.Site.Name);
            }
            return NullString;
        }

        private static string GetRole()
        {
            UserContext userContext = ClientSession.GetUserContext();
            if (userContext != null &&
                userContext.Role != null)
            {
                return String.Format("[Id:{0}] [Name:{1}]",
                                     userContext.Role.Id,
                                     userContext.Role.Name);
            }
            return NullString;
        }

        private static string GetAssignment()
        {
            UserContext userContext = ClientSession.GetUserContext();
            if (userContext != null &&
                userContext.Assignment != null)
            {
                return String.Format("[Id:{0}] [Name:{1}]",
                                     userContext.Assignment.Id,
                                     userContext.Assignment.Name);
            }
            return NullString;
        }

        private static string GetVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                return version.ToString();
            }
            return string.Empty;
        }

        private static string GetDeployment()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string deployment = string.Empty;
                if (ApplicationDeployment.CurrentDeployment != null)
                {
                    if (ApplicationDeployment.CurrentDeployment.CurrentVersion != null)
                    {
                        deployment += ApplicationDeployment.CurrentDeployment.CurrentVersion + " ";
                    }
                    if (ApplicationDeployment.CurrentDeployment.UpdateLocation != null)
                    {
                        deployment += "(" + ApplicationDeployment.CurrentDeployment.UpdateLocation + ") ";
                    }
                }
                return deployment;
            }
            return "-";
        }
    }
}

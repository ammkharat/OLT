using System.Net;
using System.Net.Sockets;
using Com.Suncor.Olt.Common.Extension;
using log4net;

namespace Com.Suncor.Olt.Common.Utility
{
    public class NetworkUtilities
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (NetworkUtilities));

        public static string GetLocalIpAddress()
        {
            var hostName = Dns.GetHostName();

            var addresses = Dns.GetHostEntry(hostName).AddressList;
            if (addresses.Length == 0)
            {
                logger.Warn("Cannot find IP addresses. Using host name = " + hostName);
                return hostName;
            }

            logger.Info("Number of IP Addresses found: " + addresses.Length);
            addresses.ForEach(a => logger.Info("address: " + a));

            var ip4Address = addresses.Find(a => a.AddressFamily == AddressFamily.InterNetwork);

            if (ip4Address == null)
            {
                logger.Info("Could not find an IP4 address. Using hostname = " + hostName);
                return hostName;
            }
            return ip4Address.ToString();
        }
    }
}
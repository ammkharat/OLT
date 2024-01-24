using System;
using System.Configuration;

namespace Com.Suncor.Olt.Common.Utility
{
    public class EmailSettings
    {
        public static string SMTPServerURL
        {
            get
            {
                var value = ConfigurationManager.AppSettings.Get("SMTPServer");
                return value ?? "smtp.network.lan";
            }
        }

        public static int SMTPServerPort
        {
            get
            {
                var value = ConfigurationManager.AppSettings.Get("SMTPServerPort");
                return value == null ? 25 : Convert.ToInt32(value);
            }
        }

        public static string FromEmailAddress
        {
            get
            {
                var value = ConfigurationManager.AppSettings.Get("DefaultFromEmailAddress");
               // return value ?? "do-not-reply@suncor.com";
                return value ?? "OLTSUPPORT@suncor.com"; // RITM0412672 EN50: OLT:: to start using outbound email using generic id
            }
        }
    }
}
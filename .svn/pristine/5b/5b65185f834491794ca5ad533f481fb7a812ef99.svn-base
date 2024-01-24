using System;
using System.Configuration;

namespace Com.Suncor.Olt.Integration.HTTPHandlers.Utilities
{
    public class Constants
    {
        private static string BASE_URL
        {
            get { return ConfigurationManager.AppSettings.Get("SAPHandlerSite") + "/"; }
        }

        public static string NOTIFICATION_URL
        {
            get { return BASE_URL + "Notification.ashx"; }
        }

        public static string WORK_ORDER_URL
        {
            get { return BASE_URL + "WorkOrder.ashx"; }
        }

        public static string FLOC_URL
        {
            get { return BASE_URL + "FLOC.ashx"; }
        }

        public static string HandlerFunctionalTestDataDirectory
        {
            get
            {
                var nameValueCollection = ConfigurationManager.AppSettings;

                if (nameValueCollection == null)
                {
                    throw new NullReferenceException("NameValueCollection is null.");
                }

                var strings = nameValueCollection.GetValues("HandlerFunctionalTestDataDirectory");

                if (strings == null)
                {
                    throw new NullReferenceException("The 'values' array is null.");
                }

                if (strings.Length == 0)
                {
                    throw new InvalidOperationException("The length of the values array is 0.");
                }

                var value = strings[0];

                if (value == null)
                {
                    throw new NullReferenceException("The actual value is null");
                }


                return value;
            }
        }
    }
}
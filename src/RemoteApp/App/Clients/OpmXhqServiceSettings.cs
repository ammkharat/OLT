using System;
using System.Configuration;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Clients
{
    public class OpmXhqServiceSettings
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<OpmXhqServiceSettings>();

        public virtual string URI
        {
            get { return GetString("OpmXhqServiceURI", null); }
        }

        public virtual string Domain
        {
            get { return GetString("OpmXhqServiceDomain", null); }
        }

        public virtual string UserName
        {
            get { return GetString("OpmXhqServiceUserName", null); }
        }

        public virtual string Password
        {
            get { return GetString("OpmXhqServicePassword", null); }
        }

        public virtual TimeSpan CloseTimeout
        {
            get { return new TimeSpan(0, 0, GetInt("OpmXhqServiceCloseTimeout", 1), 0); }
        }

        public virtual TimeSpan OpenTimeout
        {
            get { return new TimeSpan(0, 0, GetInt("OpmXhqServiceOpenTimeout", 1), 0); }
        }

        public virtual TimeSpan ReceiveTimeout
        {
            get { return new TimeSpan(0, 0, GetInt("ReceiveTimeout", 10), 0); }
        }

        public virtual TimeSpan SendTimeout
        {
            get { return new TimeSpan(0, 0, GetInt("SendTimeout", 3), 0); }
        }

        public virtual int MaxBufferSize
        {
            get { return GetInt("MaxBufferSize", int.MaxValue); }
        }

        public virtual int MaxReceivedMessageSize
        {
            get { return GetInt("MaxReceivedMessageSize", int.MaxValue); }
        }

        public virtual int MaxBufferPoolSize
        {
            get { return GetInt("MaxBufferPoolSize", 524288); }
        }

        public virtual int ReaderQuotasMaxDepth
        {
            get { return GetInt("ReaderQuotasMaxDepth", int.MaxValue); }
        }

        public virtual int MaxStringContentLength
        {
            get { return GetInt("ReaderQuotasMaxStringContentLength", int.MaxValue); }
        }

        public virtual int MaxArrayLength
        {
            get { return GetInt("ReaderQuotasMaxArrayLength", int.MaxValue); }
        }

        protected static int GetInt(string key, int defaultValue)
        {
            string stringValue = ConfigurationManager.AppSettings[key];

            if (stringValue == null)
            {
                logger.Error("There was no value found for the configuration key: " + key + ". Returning default of: " + defaultValue);
                return defaultValue;
            }

            int intValue;

            return Int32.TryParse(stringValue, out intValue) ? intValue : defaultValue;
        }

        protected static string GetString(string key, string defaultValue)
        {
            string stringValue = ConfigurationManager.AppSettings[key];

            if (stringValue == null)
            {
                logger.Error("There was no value found for the configuration key: " + key + ". Returning default of: " + defaultValue);
                return defaultValue;
            }

            return stringValue;
        }
    }
}

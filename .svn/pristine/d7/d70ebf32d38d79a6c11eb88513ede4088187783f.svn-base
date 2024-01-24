using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Xml;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class WcfConfiguration
    {
        private static WcfConfiguration instance;
        private static readonly ILog logger = GenericLogManager.GetLogger<WcfConfiguration>();

        private readonly string[] clientPorts;

        private readonly BindingType clientServerBindingType;
        private readonly NameValueCollection settings;

        private WcfConfiguration()
        {
            settings = GetSettings();

            {
                var value = GetValue("ClientPorts");
                clientPorts = !string.IsNullOrEmpty(value) ? value.Split(',') : new string[0];
            }

            ClientHostNameOrIpAddress = GetValue("ClientHostNameOrIPAddress");

            ReceiveTimeout = GetInt("ReceiveTimeout", 10);
            SendTimeout = GetInt("SendTimeout", 15);

            CloseTimeout = GetInt("CloseTimeout", 2);
            OpenTimeout = GetInt("OpenTimeout", 2);

            MaxBufferSize = GetInt("MaxBufferSize", Int32.MaxValue);
            MaxBufferPoolSize = GetInt("MaxBufferPoolSize", 524288);
            MaxReceivedMessageSize = GetInt("MaxReceivedMessageSize", Int32.MaxValue);

            ReaderQuotasMaxStringContentLength = GetInt("ReaderQuotasMaxStringContentLength", Int32.MaxValue);
            ReaderQuotasMaxDepth = GetInt("ReaderQuotasMaxDepth", Int32.MaxValue);
            ReaderQuotasMaxArrayLength = GetInt("ReaderQuotasMaxArrayLength", Int32.MaxValue);

            MaxConcurrentCalls = GetInt("MaxConcurrentCalls", 200);
            MaxConcurrentInstances = GetInt("MaxConcurrentInstances", 200);
            MaxConcurrentSessions = GetInt("MaxConcurrentSessions", 200);

            MaxConnections = GetInt("MaxConnections", 5000);

            MaxItemsInObjectGraph = GetInt("MaxItemsInObjectGraph", Int32.MaxValue);

            clientServerBindingType = GetInt("clientServerBindingType", 3).ToEnum<BindingType>();

            LogConfiguration();
        }

        public string ClientHostNameOrIpAddress { get; private set; }

        public int OpenTimeout { get; private set; }
        public int ReceiveTimeout { get; private set; }
        public int SendTimeout { get; private set; }
        public int CloseTimeout { get; private set; }

        public int MaxBufferSize { get; private set; }
        public int MaxBufferPoolSize { get; private set; }
        public int MaxReceivedMessageSize { get; private set; }

        public int ReaderQuotasMaxStringContentLength { get; private set; }
        public int ReaderQuotasMaxDepth { get; private set; }
        public int ReaderQuotasMaxArrayLength { get; private set; }

        public int MaxConcurrentCalls { get; private set; }
        public int MaxConcurrentInstances { get; private set; }
        public int MaxConcurrentSessions { get; private set; }
        public int MaxConnections { get; private set; }

        public int MaxItemsInObjectGraph { get; private set; }

        public static WcfConfiguration Instance
        {
            get { return instance ?? (instance = new WcfConfiguration()); }
        }

        public string[] ClientPorts
        {
            get { return clientPorts; }
        }


        public string BaseAddress
        {
            get { return Constants.RemoteServicesURL; }
        }

        public BindingType ClientServerBindingType
        {
            get { return clientServerBindingType; }
        }

        private void LogConfiguration()
        {
            logger.Info("WCF configuration is as follows:");

            logger.Info(String.Format("clientPorts: {0}", string.Join(",", clientPorts ?? new string[0])));
            logger.Info(String.Format("clientHostNameOrIPAddress: {0}", ClientHostNameOrIpAddress));


            logger.Info(String.Format("receiveTimeout: {0}", ReceiveTimeout));
            logger.Info(String.Format("sendTimeout: {0}", SendTimeout));
            logger.Info(String.Format("openTimeout: {0}", OpenTimeout));
            logger.Info(String.Format("closeTimeout: {0}", CloseTimeout));

            logger.Info(String.Format("maxBufferSize: {0}", MaxBufferSize));
            logger.Info(String.Format("maxBufferPoolSize: {0}", MaxBufferPoolSize));
            logger.Info(String.Format("maxReceivedMessageSize: {0}", MaxReceivedMessageSize));


            logger.Info(String.Format("readerQuotasMaxStringContentLength: {0}", ReaderQuotasMaxStringContentLength));
            logger.Info(String.Format("readerQuotasMaxDepth: {0}", ReaderQuotasMaxDepth));
            logger.Info(String.Format("readerQuotasMaxArrayLength: {0}", ReaderQuotasMaxArrayLength));

            logger.Info(String.Format("maxConcurrentCalls: {0}", MaxConcurrentCalls));
            logger.Info(String.Format("maxConcurrentInstances: {0}", MaxConcurrentInstances));
            logger.Info(String.Format("maxConcurrentSessions: {0}", MaxConcurrentSessions));


            logger.Info(String.Format("maxConnections: {0}", MaxConnections));
            logger.Info(String.Format("maxItemsInObjectGraph: {0}", MaxItemsInObjectGraph));
            logger.Info(String.Format("clientServerBindingType: {0}", clientServerBindingType));
        }

        private static NameValueCollection GetSettings()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "wcf.config");
            if (File.Exists(path))
            {
                var settings = new NameValueCollection();

                var reader = new XmlTextReader(path);
                while (reader.Read())
                {
                    if (reader.Name == "add")
                    {
                        var key = reader.GetAttribute("key");
                        var value = reader.GetAttribute("value");
                        settings.Add(key, value);
                    }
                }

                return settings;
            }
            return ConfigurationManager.AppSettings;
        }

        private int GetInt(string key, int defaultValue)
        {
            if (HasKey(key))
            {
                var value = settings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    return int.Parse(value);
                }
                return defaultValue;
            }
            return defaultValue;
        }

        private string GetValue(string key)
        {
            if (HasKey(key))
            {
                var value = settings[key];
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Trim();
                }
                return value;
            }
            return string.Empty;
        }

        private bool HasKey(string targetKey)
        {
            for (var i = 0; i < settings.Keys.Count; i++)
            {
                var key = settings.GetKey(i);
                if (key == targetKey)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
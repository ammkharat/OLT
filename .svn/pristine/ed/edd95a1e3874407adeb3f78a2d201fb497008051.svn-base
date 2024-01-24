using System;
using Com.Suncor.Olt.Remote.Clients;

namespace TestTool
{
    public class UserProvidedOpmXhqServiceSettings : OpmXhqServiceSettings
    {
        private readonly string server;
        private readonly string domain;
        private readonly string username;
        private readonly string password;

        public UserProvidedOpmXhqServiceSettings(string server, string domain, string username, string password)
        {
            this.server = server;
            this.domain = domain;
            this.username = username;
            this.password = password;
        }

        public override string URI
        {
            get { return server; }
        }

        public override string Domain
        {
            get { return domain; }
        }

        public override string UserName
        {
            get { return username; }
        }

        public override string Password
        {
            get { return password; }
        }

        public override TimeSpan CloseTimeout
        {
            get { return new TimeSpan(0, 0, 1, 0); }
        }

        public override TimeSpan OpenTimeout
        {
            get { return new TimeSpan(0, 0, 1, 0); }
        }

        public override TimeSpan ReceiveTimeout
        {
            get { return new TimeSpan(0, 0, 10, 0); }
        }

        public override TimeSpan SendTimeout
        {
            get { return new TimeSpan(0, 0, 3, 0); }
        }

        public override int MaxBufferSize
        {
            get { return 2147483647; }
        }

        public override int MaxReceivedMessageSize
        {
            get { return 2147483647; }
        }

        public override int MaxBufferPoolSize
        {
            get { return 524288; }
        }

        public override int ReaderQuotasMaxDepth
        {
            get { return 2147483647; }
        }

        public override int MaxStringContentLength
        {
            get { return 2147483647; }
        }

        public override int MaxArrayLength
        {
            get { return 2147483647; }
        }
    }
}
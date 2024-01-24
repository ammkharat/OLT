using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class InitiatingEventSink
    {
        private readonly string clientUri;

        public InitiatingEventSink(string clientUri)
        {
            this.clientUri = clientUri;
        }

        public string ClientUri
        {
            get { return clientUri; }
        }

        public override string ToString()
        {
            return "InitiatingEventSink ( ClientUri:" + clientUri + " )";
        }
    }
}
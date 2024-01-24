using System.Configuration;

namespace Com.Suncor.Olt.Common.Domain.PlantHistorian
{
    public class OSIConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("server", IsRequired = true)]
        public string Server
        {
            get { return (string) this["server"]; }
            set { this["server"] = value; }
        }

        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return (string) this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string) this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("mockTagWrites", DefaultValue = "false", IsRequired = false)]
        public bool MockTagWrites
        {
            get { return (bool) this["mockTagWrites"]; }
            set { this["mockTagWrites"] = value; }
        }
    }
}
using System;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Uniformance.PHD;

namespace Com.Suncor.Olt.PlantHistorian
{
    public class OSIPiConnectionInfo
    {
        public OSIPiConnectionInfo(ScadaConnectionInfo connectionInfo)
        {
            SiteId = connectionInfo.SiteId;
            Username = connectionInfo.PiUsername;
            Password = connectionInfo.PiPassword;
            Server = connectionInfo.PiServer;
            MockTagWrites = connectionInfo.MockTagWrites;
            ScadaConnectionInfoId = connectionInfo.Id;
            LastModifiedDateTime = connectionInfo.LastModifiedDateTime;
            SampleType = connectionInfo.SampleType;
        }

        public DateTime LastModifiedDateTime { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Server { get; set; }
        public bool MockTagWrites { get; private set; }
        public long SiteId { get; private set; }
        public long ScadaConnectionInfoId { get; private set; }


        //ayman PI Changes
        public string SampleType { get; set; }

    }
}
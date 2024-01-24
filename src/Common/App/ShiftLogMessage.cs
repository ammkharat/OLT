using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common
{
    [Serializable]
   public class ShiftLogMessage:Domain.DomainObject
    {
        public string UserName { get; set; }

        public string Floc { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public long? ShiftLogMessageStagingId { get {return Id; } }

        public DateTime MessageTimeStamp { get; set; }
        public bool Selected { get; set; }

    }
   //Added by ppanigrahi
    public class CsdLogMessage : Domain.DomainObject
    {
        public long FormNo { get; set; }

        public string Staus { get; set; }

        public string Floc { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public long? CSDLogMessageId { get { return Id; } }

        public DateTime MessageTimeStamp { get; set; }
       // public bool Selected { get; set; }

    }
}

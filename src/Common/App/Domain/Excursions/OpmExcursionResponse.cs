﻿using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionResponse : DomainObject
    {
        public OpmExcursionResponse(long id, long oltExcursionId, long opmExcursionId, long toeVersion,
            string historianTag, User lastModifiedBy, string response, DateTime lastModifiedDateTime, string asset, string code) //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            : base(id)
        {
            OltExcursionId = oltExcursionId;
            OpmExcursionId = opmExcursionId;
            ToeVersion = toeVersion;
            HistorianTag = historianTag;
            LastModifiedBy = lastModifiedBy;
            Response = response;
//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM            Asset = asset;
            Code = code;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        public OpmExcursionResponse(OpmExcursion opmExcursion)
        {
            OltExcursionId = opmExcursion.IdValue;
            OpmExcursionId = opmExcursion.OpmExcursionId;
            ToeVersion = opmExcursion.ToeVersion;
            HistorianTag = opmExcursion.HistorianTag;
        }

        public User LastModifiedBy { get; set; }

        public long OltExcursionId { get; set; }
        public long OpmExcursionId { get; set; }
        public long ToeVersion { get; set; }
        public string HistorianTag { get; set; }
        public string Response { get; set; }

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM

        public string Asset { get; set; }
        public string Code { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public bool HasResponse
        {
            get { return !Response.IsNullOrEmptyOrWhitespace(); }
        }

        public bool IsDirty { get; set; }


        public ExcursionResponseHistory TakeSnapshot()
        {
            return new ExcursionResponseHistory(OltExcursionId, LastModifiedBy, LastModifiedDateTime, Response, Asset, Code);  //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        }
    }
}
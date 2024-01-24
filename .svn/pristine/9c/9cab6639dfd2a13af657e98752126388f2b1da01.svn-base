using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class ExcursionResponseHistory : DomainObjectHistorySnapshot
    {
        public ExcursionResponseHistory(long id,  User lastModifiedBy, DateTime lastModifiedDate, string response, string asset, string code) //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            Response = response;
            Asset = asset; //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            Code = code;
        }

        public string Response { get; private set; }
        public string Asset { get; private set; } //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        public string Code { get; private set; }

    }
}
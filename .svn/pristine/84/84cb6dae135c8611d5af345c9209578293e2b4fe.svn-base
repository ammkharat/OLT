using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Excursions
{
    [Serializable]
    public class ExcursionResponseEditingGridRowDTO : DomainObject
    {
        private string _excursionResponseComment;
        private string _asset; //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        private string _code;
        

        public ExcursionResponseEditingGridRowDTO(long id, long opmExcursionId, string historianTag,
            string toeName,
            ToeType toeType, ExcursionStatus status, DateTime startDateTime,
            decimal peak, decimal average, decimal duration, long? ilpNumber,
            decimal toeLimitValue, string excursionResponseComment, DateTime? responseLastUpdated,
            long? oltExcursionResponseId, string opmTrendUrl, string asset, string code) //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            : base(id)
        {
            OpmExcursionId = opmExcursionId;
            ToeName = toeName;
            ToeType = toeType;
            Status = status;
            StartDateTime = startDateTime;
            Peak = peak;
            Average = average;
            Duration = duration;
            IlpNumber = ilpNumber;
            ToeLimitValue = toeLimitValue;
            _excursionResponseComment = excursionResponseComment;

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            _asset = asset;
            _code = code;

            ResponseLastUpdated = responseLastUpdated;
            OltExcursionResponseId = oltExcursionResponseId;
            HistorianTag = historianTag;
            OpmTrendUrl = opmTrendUrl;
        }

        public long OpmExcursionId { get; private set; }
        public string HistorianTag { get; private set; }
        public string ToeName { get; private set; }
        public ToeType ToeType { get; private set; }
        public ExcursionStatus Status { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public decimal Peak { get; private set; }
        public decimal Average { get; private set; }
        public decimal Duration { get; private set; }
        public string OpmTrendUrl { get; private set; }
        public long? IlpNumber { get; private set; }
        public decimal ToeLimitValue { get; private set; }

        public string Answered
        {
            get { return _excursionResponseComment.IsNullOrEmptyOrWhitespace() ? "No" : "Yes"; }
        }

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        public string Assest
        {
            get { return _asset; }
            set
            {
                _asset = value;
                
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;

            }
        }

        public string ExcursionResponseComment
        {
            get { return _excursionResponseComment; }
            set
            {
                _excursionResponseComment = value;
                IsDirty = true;
            }
        }

        public bool IsDirty { get; set; }

        public DateTime? ResponseLastUpdated { get; set; }
        public long? OltExcursionResponseId { get; private set; }
    }
}
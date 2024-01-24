using System;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO.Excursions
{
    [Serializable]
    public class OpmExcursionResponseDTO : DomainObject
    {
        public OpmExcursionResponseDTO(long id, long opmExcursionId, string functionalLocation, string toeName,
            ToeType toeType, ExcursionStatus status, DateTime startDateTime, DateTime? endDateTime,
            string unitOfMeasure, decimal peak, decimal average, decimal duration, long? ilpNumber,
            string engineerComments, string oltOperatorResponse, string reasonCode,
            DateTime? responseLastUpdatedDateTime,
            string responseLastUpdatedBy, decimal toeLimitValue, string asset, string code)  //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            : base(id)
        {
            OpmExcursionId = opmExcursionId;
            FunctionalLocation = functionalLocation;
            ToeName = toeName;
            ToeType = toeType;
            Status = status;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            UnitOfMeasure = unitOfMeasure;
            Peak = peak;
            Average = average;
            Duration = duration;
            IlpNumber = ilpNumber;
            EngineerComments = engineerComments;
            OltOperatorResponse = oltOperatorResponse;

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
            Asset = asset;
            Code = code;

            ReasonCode = reasonCode;
            ResponseLastUpdatedDateTime = responseLastUpdatedDateTime;
            ResponseLastUpdatedBy = responseLastUpdatedBy;
            ToeLimitValue = toeLimitValue;
        }

        [IncludeInSearch]
        public string FunctionalLocation { get; set; }

        [IncludeInSearch]
        public string ToeName { get; set; }

        [IncludeInSearch]
        public ToeType ToeType { get; set; }

        [IncludeInSearch]
        public ExcursionStatus Status { get; set; }

        [IncludeInSearch]
        public DateTime StartDateTime { get; set; }

        [IncludeInSearch]
        public DateTime? EndDateTime { get; set; }

        [IncludeInSearch]
        public string UnitOfMeasure { get; set; }

        [IncludeInSearch]
        public long OpmExcursionId { get; set; }

        [IncludeInSearch]
        public decimal Peak { get; set; }

        [IncludeInSearch]
        public decimal Average { get; set; }

        [IncludeInSearch]
        public decimal Duration { get; set; }

        [IncludeInSearch]
        public long? IlpNumber { get; set; }

        [IncludeInSearch]
        public string EngineerComments { get; set; }

        [IncludeInSearch]
        public string OltOperatorResponse { get; set; }

//Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        [IncludeInSearch]
        public string Asset { get; set; }

        [IncludeInSearch]
        public string Code { get; set; }

        [IncludeInSearch]
        public string ReasonCode { get; set; }

        [IncludeInSearch]
        public DateTime? ResponseLastUpdatedDateTime { get; set; }

        [IncludeInSearch]
        public string ResponseLastUpdatedBy { get; set; }

        [IncludeInSearch]
        public decimal ToeLimitValue { get; set; }

        [IncludeInSearch]
        public long IdDisplay
        {
            get { return IdValue; }
        }

        [IncludeInSearch]
        public string HasResponse
        {
            get { return OltOperatorResponse.IsNullOrEmpty() ? "No" : "Yes"; }
        }
    }
}
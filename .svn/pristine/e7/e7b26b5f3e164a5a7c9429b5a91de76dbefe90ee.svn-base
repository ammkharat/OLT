using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionResponseDTO : DomainObject
    {
        public OpmExcursionResponseDTO(long id, string functionalLocation, string toeName,
            ToeType toeType, ExcursionStatus status, DateTime startDateTime, DateTime? endDateTime,
            string unitOfMeasure, decimal peak, decimal average, decimal duration, long? ilpNumber,
            string engineerComments, string oltOperatorResponse, string reasonCode, DateTime responseLastUpdatedDateTime,
            string responseLastUpdatedBy, decimal toeLimitValue) : base(id)
        {
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
            ReasonCode = reasonCode;
            ResponseLastUpdatedDateTime = responseLastUpdatedDateTime;
            ResponseLastUpdatedBy = responseLastUpdatedBy;
            ToeLimitValue = toeLimitValue;
        }

        public string FunctionalLocation { get; set; }
        public string ToeName { get; set; }
        public ToeType ToeType { get; set; }
        public ExcursionStatus Status { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Peak { get; set; }
        public decimal Average { get; set; }
        public decimal Duration { get; set; }
        public long? IlpNumber { get; set; }
        public string EngineerComments { get; set; }
        public string OltOperatorResponse { get; set; }
        public string ReasonCode { get; set; }
        public DateTime ResponseLastUpdatedDateTime { get; set; }
        public string ResponseLastUpdatedBy { get; set; }
        public decimal ToeLimitValue { get; set; }

        public string HasResponse
        {
            get { return OltOperatorResponse.IsNullOrEmptyOrWhitespace() ? "No" : "Yes"; }
        }
        
        public string FormNumber
        {
            get { return IdValue.ToString(); }
        }
    }
}
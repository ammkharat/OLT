using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Common.DTO.Excursions
{
    [Serializable]
    public class OpmExcursionDTO : DomainObject
    {
        public OpmExcursionDTO(long id, long opmExcursionId, long toeVersion, string historianTag,
            string functionalLocation, long functionalLocationId, string toeName,
            ToeType toeType, ExcursionStatus status, DateTime startDateTime, DateTime? endDateTime,
            DateTime lastUpdatedDateTime,
            string unitOfMeasure, decimal peak, decimal average, decimal duration, long? ilpNumber,
            string engineerComments, string reasonCode, decimal toeLimitValue, string opmTrendUrl)
            : base(id)
        {
            FunctionalLocation = functionalLocation;
            FunctionalLocationId = functionalLocationId;
            OpmExcursionId = opmExcursionId;
            ToeName = toeName;
            ToeType = toeType;
            Status = status;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            UnitOfMeasure = unitOfMeasure;
            Peak = peak;
            Average = average;
            Duration = duration;
            IlpNumber = ilpNumber;
            EngineerComments = engineerComments;
            ReasonCode = reasonCode;
            ToeLimitValue = toeLimitValue;
            ToeVersion = toeVersion;
            HistorianTag = historianTag;
            OpmTrendUrl = opmTrendUrl;
        }

        public long OpmExcursionId { get; set; }
        public long ToeVersion { get; set; }
        public string HistorianTag { get; set; }
        public string FunctionalLocation { get; set; }
        public long FunctionalLocationId { get; set; }
        public string ToeName { get; set; }
        public ToeType ToeType { get; set; }
        public ExcursionStatus Status { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Peak { get; set; }
        public decimal Average { get; set; }
        public decimal Duration { get; set; }
        public string OpmTrendUrl { get; set; }
        public long? IlpNumber { get; set; }
        public string EngineerComments { get; set; }
        public string ReasonCode { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public decimal ToeLimitValue { get; set; }
    }
}
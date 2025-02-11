﻿using System;
using System.Diagnostics;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursion : DomainObject
    {
        public OpmExcursion(long id, long opmExcursionId, long toeVersion, string historianTag,
            string functionalLocation, long functionalLocationId,
            string toeName, ToeType toeType, ExcursionStatus status, DateTime startDateTime, DateTime? endDateTime,
            string unitOfMeasure, decimal peak, decimal average, decimal duration, string opmTrendUrl, long? ilpNumber,
            string engineerComments, string reasonCode, DateTime lastUpdatedDateTime, decimal toeLimitValue) : base(id)
        {
            OpmExcursionId = opmExcursionId;
            ToeVersion = toeVersion;
            HistorianTag = historianTag;
            FunctionalLocation = functionalLocation;
            FunctionalLocationId = functionalLocationId;
            ToeName = toeName;
            ToeType = toeType;
            Status = status;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            UnitOfMeasure = unitOfMeasure;
            Peak = peak;
            Average = average;
            Duration = duration;
            OpmTrendUrl = opmTrendUrl;
            IlpNumber = ilpNumber;
            EngineerComments = engineerComments;
            ReasonCode = reasonCode;
            LastUpdatedDateTime = lastUpdatedDateTime;
            ToeLimitValue = toeLimitValue;
        }

        public OpmExcursionResponse OpmExcursionResponse { get; set; }
        public OpmToeDefinition OpmToeDefinition { get; set; }
        public OpmTagValueDTO CurrentTagValue { get; set; }

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

        public OpmExcursionResponseDTO CreateExcursionResponseDTO()
        {
            Debug.Assert(OpmExcursionResponse != null,
                "OPMExcursionResponse must be set via the service call. If no response set, you should new it up and attach an empty one.");

            var fullNameWithUserName = OpmExcursionResponse.LastModifiedBy != null
                ? OpmExcursionResponse.LastModifiedBy.FullNameWithUserName
                : null;
            return new OpmExcursionResponseDTO(Id.Value, OpmExcursionId, FunctionalLocation, ToeName, ToeType, Status,
                StartDateTime,
                EndDateTime, UnitOfMeasure, Peak, Average, Duration, IlpNumber, EngineerComments,
                OpmExcursionResponse.Response, ReasonCode,
                OpmExcursionResponse.LastModifiedBy != null
                    ? OpmExcursionResponse.LastModifiedDateTime
                    : (DateTime?) null,
                fullNameWithUserName, ToeLimitValue, OpmExcursionResponse.Asset, OpmExcursionResponse.Code); //Added by Vibhor : RITM0581488 -  Transferring OLT data to OPM
        }
    }
}
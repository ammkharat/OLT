using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class DeviationAlertDTO : DomainObject, IHasStatus<DeviationAlertStatus>
    {
        private readonly DateTime createdDateTime;
        private readonly DateTime endDateTime;
        private readonly string functionalLocationName;
        private readonly bool hasUserEnteredResponse;
        private readonly DateTime lastModifiedDateTime;
        private readonly long lastModifiedUserId;
        private readonly string measurementTagName;
        private readonly int? measurementValue;
        private readonly string measurementValueTagUnit;
        private readonly string productionTargetTagName;
        private readonly int? productionTargetValue;
        private readonly string productionTargetValueTagUnit;
        private readonly string restrictionDefinitionDescription;
        private readonly long restrictionDefinitionId;
        private readonly string restrictionDefinitionName;
        private readonly DateTime startDateTime;
        private readonly DeviationAlertStatus status;

        public DeviationAlertDTO(DeviationAlert deviationAlert) : this(
            deviationAlert.Id,
            deviationAlert.RestrictionDefinitionName,
            deviationAlert.RestrictionDefinitionDescription,
            deviationAlert.ProductionTargetValue,
            deviationAlert.MeasurementValue,
            deviationAlert.StartDateTime,
            deviationAlert.EndDateTime,
            deviationAlert.FunctionalLocation.FullHierarchy,
            deviationAlert.ProductionTargetTag != null ? deviationAlert.ProductionTargetTag.Name : null,
            deviationAlert.MeasurementTag.Name,
            deviationAlert.MeasurementTag.Units,
            deviationAlert.ProductionTargetTag != null ? deviationAlert.ProductionTargetTag.Units : null,
            deviationAlert.RestrictionDefinition.Id.Value,
            deviationAlert.Status,
            deviationAlert.DeviationAlertResponse != null,
            deviationAlert.LastModifiedBy.Id.Value,
            deviationAlert.LastModifiedDateTime,
            deviationAlert.CreatedDateTime)
        {
        }

        public DeviationAlertDTO(
            long? id,
            string restrictionDefinitionName,
            string restrictionDefinitionDescription,
            int? productionTargetValue,
            int? measurementValue,
            DateTime startDateTime,
            DateTime endDateTime,
            string functionalLocationName,
            string productionTargetTagName,
            string measurementTagName,
            string measurementValueTagUnit,
            string productionTargetValueTagUnit,
            long restrictionDefinitionId,
            DeviationAlertStatus status,
            bool hasUserEnteredResponse,
            long lastModifiedUserId,
            DateTime lastModifiedDateTime,
            DateTime createdDateTime)
        {
            this.id = id;
            this.restrictionDefinitionName = restrictionDefinitionName;
            this.restrictionDefinitionDescription = restrictionDefinitionDescription;
            this.productionTargetValue = productionTargetValue;
            this.measurementValue = measurementValue;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.functionalLocationName = functionalLocationName;
            this.productionTargetTagName = productionTargetTagName;
            this.measurementTagName = measurementTagName;
            this.measurementValueTagUnit = measurementValueTagUnit;
            this.productionTargetValueTagUnit = productionTargetValueTagUnit;
            this.restrictionDefinitionId = restrictionDefinitionId;
            this.status = status;
            this.hasUserEnteredResponse = hasUserEnteredResponse;
            this.lastModifiedUserId = lastModifiedUserId;
            this.lastModifiedDateTime = lastModifiedDateTime;
            this.createdDateTime = createdDateTime;
        }

        [IncludeInSearch]
        public string RestrictionDefinitionName
        {
            get { return restrictionDefinitionName; }
        }

        public string RestrictionDefinitionDescription
        {
            get { return restrictionDefinitionDescription; }
        }

        [IncludeInSearch]
        public int? ProductionTargetValue
        {
            get { return productionTargetValue; }
        }

        [IncludeInSearch]
        public int? MeasurementValue
        {
            get { return measurementValue; }
        }

        [IncludeInSearch]
        public int DeviationValue
        {
            get { return DeviationAlert.GetDeviationValue(MeasurementValue, ProductionTargetValue); }
        }

        [IncludeInSearch]
        public DateTime StartDateTime
        {
            get { return startDateTime; }
        }

        [IncludeInSearch]
        public DateTime EndDateTime
        {
            get { return endDateTime; }
        }

        [IncludeInSearch]
        public string FunctionalLocationName
        {
            get { return functionalLocationName; }
        }

        public string ProductionTargetTagName
        {
            get { return productionTargetTagName; }
        }

        public string MeasurementTagName
        {
            get { return measurementTagName; }
        }

        public string MeasurementValueTagUnit
        {
            get { return measurementValueTagUnit; }
        }

        public string ProductionTargetValueTagUnit
        {
            get { return productionTargetValueTagUnit; }
        }

        public long RestrictionDefinitionId
        {
            get { return restrictionDefinitionId; }
        }

        public long LastModifiedUserId
        {
            get { return lastModifiedUserId; }
        }

        public DateTime LastModifiedDateTime
        {
            get { return lastModifiedDateTime; }
        }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public bool HasUserEnteredResponse
        {
            get { return hasUserEnteredResponse; }
        }

        [IncludeInSearch]
        public DeviationAlertStatus Status
        {
            get { return status; }
        }

        public DeviationAlertStatus GetStatus(UserShift userShift)
        {
            if (status == DeviationAlertStatus.RequiresResponse && endDateTime <= userShift.StartDateTime)
            {
                return DeviationAlertStatus.RequiresResponseIsLate;
            }
            return Status;
        }

        public bool IsInShift(UserShift shift)
        {
            return endDateTime >= shift.StartDateTime && endDateTime <= shift.EndDateTime;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class DeviationAlert : ModifiableDomainObject, IFunctionalLocationRelevant, IHistoricalDomainObject,
        IHasDefinition
    {
        public DeviationAlert(
            RestrictionDefinition restrictionDefinition,
            string restrictionDefinitionName,
            string restrictionDefinitionDescription,
            DeviationAlertResponse deviationAlertResponse,
            TagInfo productionTargetTag,
            TagInfo measurementTag,
            int? productionTargetValue,
            int? measurementValue,
            DateTime startDateTime,
            DateTime endDateTime,
            FunctionalLocation functionalLocation,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime createdDateTime) : base(lastModifiedBy, lastModifiedDateTime)
        {
            DeviationAlertResponse = deviationAlertResponse;

            ProductionTargetTag = productionTargetTag;
            MeasurementTag = measurementTag;

            ProductionTargetValue = productionTargetValue;
            MeasurementValue = measurementValue;

            StartDateTime = startDateTime;
            EndDateTime = endDateTime;

            FunctionalLocation = functionalLocation;
            IsOnlyVisibleOnReports = restrictionDefinition.IsOnlyVisibleOnReports;

            RestrictionDefinition = restrictionDefinition;
            RestrictionDefinitionName = restrictionDefinitionName;
            RestrictionDefinitionDescription = restrictionDefinitionDescription;

            CreatedDateTime = createdDateTime;
        }

        [CachedRelationship]
        public DeviationAlertResponse DeviationAlertResponse { get; set; }

        [CachedRelationship]
        public RestrictionDefinition RestrictionDefinition { get; private set; }

        public string RestrictionDefinitionName { get; private set; }

        public string RestrictionDefinitionDescription { get; private set; }

        public TagInfo ProductionTargetTag { get; private set; }

        public TagInfo MeasurementTag { get; private set; }

        public int? ProductionTargetValue { get; private set; }

        public int? MeasurementValue { get; private set; }

        public DateTime StartDateTime { get; private set; }

        public DateTime EndDateTime { get; private set; }

        public FunctionalLocation FunctionalLocation { get; private set; }

        public bool IsOnlyVisibleOnReports { get; private set; }

        ////Added by Mukesh for RITM0219490
        public int? ToleranceValue { get;  set; }

        public string ProductionTargetTagName
        {
            get { return ProductionTargetTag != null ? ProductionTargetTag.Name : null; }
        }

        public string MeasurementTagName
        {
            get { return MeasurementTag.Name; }
        }

        public string MeasurementTagUnit
        {
            get { return MeasurementTag.Units; }
        }

        public string ProductionTargetTagUnit
        {
            get { return ProductionTargetTag != null ? ProductionTargetTag.Units : null; }
        }

        public DateTime CreatedDateTime { get; private set; }

        public string Comments { get; set; }

        public int DeviationValue
        {
            get { return GetDeviationValue(MeasurementValue, ProductionTargetValue); }
        }
        //INC0334048 -changed by Mukesh
        public DeviationAlertStatus Status
        {
            get { return GetStatus(DeviationAlertResponse != null, DeviationValue,(ProductionTargetValue * RestrictionDefinition.ToleranceValue)/100); }
        }

        public bool IsPositiveDeviation
        {
            get { return GetIsPositiveDeviation(DeviationValue); }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies,
            List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,
            SiteConfiguration siteConfiguration)
        {
            var flocHierarchiesToTest = restrictionFullHierarchies != null && restrictionFullHierarchies.Count > 0
                ? restrictionFullHierarchies
                : clientFullHierarchies;

            return !IsOnlyVisibleOnReports &&
                   (new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, flocHierarchiesToTest) ||
                    new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, flocHierarchiesToTest));
        }

        public long DefinitionId
        {
            get { return RestrictionDefinition.IdValue; }
        }

        public static int GetDeviationValue(int? measurementValue, int? targetValue)
        {
            var target = targetValue != null ? targetValue.Value : 0;
            var measurement = measurementValue != null ? measurementValue.Value : 0;

            return measurement - target;
        }

        public static DeviationAlertStatus GetStatus(bool hasResponse, int deviationValue, int? ToleranceValue)
        {
            //deviationValue = deviationValue + 85;
            //Added by Mukesh for RITM0219490
            if (ToleranceValue>0 && deviationValue<0)
            {
                deviationValue = deviationValue +  Convert.ToInt32(ToleranceValue);
            }

            if (GetIsPositiveDeviation(deviationValue))
            {
                return DeviationAlertStatus.AutomaticallyRespondedForPositiveDeviation;
            }
            if (hasResponse)
            {
                return DeviationAlertStatus.Responded;
            }
            return DeviationAlertStatus.RequiresResponse;
        }

        private static bool GetIsPositiveDeviation(int deviationValue)
        {
            return deviationValue >= 0;
        }
    }
}
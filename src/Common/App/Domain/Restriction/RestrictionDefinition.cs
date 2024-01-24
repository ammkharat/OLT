using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionDefinition : ModifiableDomainObject, IFunctionalLocationRelevant, IHistoricalDomainObject
    {
        private DateTime? lastInvokedDateTime;

        public RestrictionDefinition()
        {
            Status = RestrictionDefinitionStatus.Valid;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string HourFrequency { get; set; } //DMND0010124 mangesh

        public FunctionalLocation FunctionalLocation { get; set; }

        public TagInfo MeasurementTagInfo { get; set; }

        public int? ProductionTargetValue { get; set; }

        public TagInfo ProductionTargetTagInfo { get; set; }

        public bool IsActive { get; set; }

        public bool IsOnlyVisibleOnReports { get; set; }

        public RestrictionDefinitionStatus Status { get; set; }

        //Added by Mukesh for RITM0219490
        public int? ToleranceValue { get; set; }
        //End
        public DateTime? LastInvokedDateTime
        {
            get { return lastInvokedDateTime; }
            set
            {
                if (!value.HasValue)
                {
                    lastInvokedDateTime = null;
                }
                else
                {
                    lastInvokedDateTime = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day,
                        value.Value.Hour, 0, 0);
                }
            }
        }

        public DateTime CreatedDate { get; set; }

        public bool Deleted { get; set; }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies,
            List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchy,
            SiteConfiguration siteConfiguration)
        {
            var flocHierarchiesToTest = restrictionFullHierarchy != null && restrictionFullHierarchy.Count > 0
                    ? restrictionFullHierarchy
                    : clientFullHierarchies;

            return !IsOnlyVisibleOnReports &&
                   (new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, flocHierarchiesToTest) ||
                    new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, flocHierarchiesToTest));
        }

        public RestrictionDefinitionHistory TakeSnapshot()
        {
           RestrictionDefinitionHistory Restriction=  new RestrictionDefinitionHistory(
                IdValue,
                Name,
                Description,
                FunctionalLocation,
                MeasurementTagInfo,
                ProductionTargetValue,
                ProductionTargetTagInfo,
                IsActive,
                IsOnlyVisibleOnReports,
                Status,
                LastModifiedBy,
                LastModifiedDateTime);
             //Added by Mukesh for RITM0219490
           Restriction.ToleranceValue = ToleranceValue;

           Restriction.HourFrequency = HourFrequency; // DMND0010124 mangesh

           return Restriction;
        }

        public void HasInvalidTag(User modifiedByUser, DateTime detectedInvalidTagDateTime)
        {
            Status = RestrictionDefinitionStatus.InvalidTag;
            IsActive = false;
            LastModifiedBy = modifiedByUser;
            LastModifiedDateTime = detectedInvalidTagDateTime;
        }

        public void HasValidTag(User modifiedByUser, DateTime detectedValidDateTime)
        {
            Status = RestrictionDefinitionStatus.Valid;
            LastModifiedBy = modifiedByUser;
            LastModifiedDateTime = detectedValidDateTime;
        }

        public List<Range<DateTime>> GetAlertHours(DateTime currentInvocationDateTime)
        {
            return GetAlertHoursAtHourPrecision(currentInvocationDateTime.TruncateToHour());
        }
        
        private List<Range<DateTime>> GetAlertHoursAtHourPrecision(DateTime currentInvocationDateTime)
        {
            var ranges = new List<Range<DateTime>>();

            const int deltaMinutes = -1*60;

            var invocationDateTime = currentInvocationDateTime;

            var previousAlertDateTime = !lastInvokedDateTime.HasValue
                ? CreatedDate.TruncateToHour()
                : lastInvokedDateTime.Value;

            while (invocationDateTime > previousAlertDateTime)
            {
                ranges.Add(new Range<DateTime>(invocationDateTime.AddMinutes(deltaMinutes), invocationDateTime));
                invocationDateTime = invocationDateTime.AddMinutes(deltaMinutes);
            }

            ranges.Reverse();
            return ranges;
        }

        public List<Range<DateTime>> GetAlertHours(DateTime currentInvocationDateTime, int hr)
        {
            var ranges = new List<Range<DateTime>>();

            const int deltaMinutes = -1 * 60 ;

            var invocationDateTime = currentInvocationDateTime;

            var previousAlertDateTime = !lastInvokedDateTime.HasValue
                ? CreatedDate.TruncateToHour()
                : lastInvokedDateTime.Value;

            while (invocationDateTime > previousAlertDateTime)
            {
                ranges.Add(new Range<DateTime>(invocationDateTime.AddMinutes(deltaMinutes * hr), invocationDateTime));
                invocationDateTime = invocationDateTime.AddMinutes(deltaMinutes * hr);
            }

            ranges.Reverse();
            return ranges;
        }

        public DeviationAlert CreateDeviationAlert(
            DateTime fromDateTime,
            DateTime toDateTime,
            int? measurementValue,
            int? productionValue,
            DateTime createDateTime,
            User lastModifiedByUser)
        {
            return new DeviationAlert(
                this,
                Name,
                Description,
                null,
                ProductionTargetTagInfo,
                MeasurementTagInfo,
                productionValue,
                measurementValue,
                fromDateTime,
                toDateTime,
                FunctionalLocation,
                lastModifiedByUser,
                createDateTime,
                createDateTime);
        }
    }
}
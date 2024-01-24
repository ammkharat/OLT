using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ExcursionEventPriorityPageDTO : DomainObject
    {
        private readonly List<OpmExcursion> excursions = new List<OpmExcursion>();
        private readonly List<string> functionalLocations = new List<string>();

        public ExcursionEventPriorityPageDTO(
            long id, List<string> functionalLocations, IEnumerable<OpmExcursion> excursions, string historianTag, long toeVersion,
            ExcursionStatus status, ToeType toeType,
            string toeName,
            DateTime startDateTime, DateTime? endDateTime, DateTime lastUpdatedDateTime, bool hasResponse) : base(id)
        {
            Id = id;
            functionalLocations.ForEach(AddFunctionalLocation);
            this.excursions.AddRange(excursions);
            HistorianTag = historianTag;
            ToeVersion = toeVersion;
            Status = status;
            ToeType = toeType;
            ToeName = toeName;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            HasResponse = hasResponse;
        }

        public ExcursionEventPriorityPageDTO(OpmExcursion excursion) : base(excursion.IdValue)
        {
            excursions.Add(excursion);
            functionalLocations.Add(excursion.FunctionalLocation);
            HistorianTag = excursion.HistorianTag;
            ToeVersion = excursion.ToeVersion;
            Status = excursion.Status;
            ToeType = excursion.ToeType;
            ToeName = excursion.ToeName;
            StartDateTime = excursion.StartDateTime;
            EndDateTime = excursion.EndDateTime;
            LastUpdatedDateTime = excursion.LastUpdatedDateTime;
        }

        public string HistorianTag { get; set; }
        public long ToeVersion { get; set; }
        public ToeType ToeType { get; set; }
        public ExcursionStatus Status { get; private set; }
        public string ToeName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool HasResponse { get; set; }

        public string FunctionalLocationNames
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        public List<OpmExcursion> Excursions
        {
            get { return excursions; }
        } 

        public int ExcursionCount
        {
            get { return excursions.Count; }
        }

        public List<long> ExcursionIds
        {
            get { return excursions.Select(excursion => excursion.IdValue).ToList(); }
        } 

        public bool ContainsExcursionById(long excursionId)
        {
            return excursions.Exists(excursion => excursion.Id.HasValue && excursion.IdValue == excursionId);
        }

        private void RemoveExcursionById(long excursionId)
        {
            if (ContainsExcursionById(excursionId))
            {
                var excursionToRemove = excursions.Find(excursion => excursion.Id.HasValue && excursion.IdValue == excursionId);

                if (excursionToRemove != null)
                {
                    excursions.Remove(excursionToRemove);
                }
            }
        }

        private void RemoveAllClosedExcursions()
        {
            excursions.RemoveAll(excursion => excursion.Status == ExcursionStatus.Closed);
        }

        /// <summary>
        ///     Returns true if status is open with response and duration is less than max allowable duration; false otherwise.
        /// </summary>
        public bool IsRespondedStillExceedingOperatingLimits(TimeSpan maxAllowableDuration)
        {
            return HasResponse && Status == ExcursionStatus.Open &&
                   (maxAllowableDuration == TimeSpan.FromMinutes(0) ||
                    (StartDateTime.IsWithinTimeSpan(maxAllowableDuration)));
        }

        /// <summary>
        ///     Returns true if status is open with no response and duration is less than max allowable duration;
        ///     OR, status is closed and the close date is within the allowable timeframe start to now.
        ///     Otherwise returns false.
        /// </summary>
        public bool IsUnrespondedOpenOrRecentlyClosedSol(DateTime allowableTimeframeStartDateTime,
            TimeSpan maxAllowableDuration)
        {
            return (HasResponse == false && (ToeType == ToeType.HighSol || ToeType == ToeType.LowSol)) &&
                   ((Status == ExcursionStatus.Open && (maxAllowableDuration == TimeSpan.FromMinutes(0) ||
                                                        (StartDateTime.IsWithinTimeSpan(maxAllowableDuration)))) ||
                    (Status == ExcursionStatus.Closed && EndDateTime.HasValue &&
                     EndDateTime.IsWithinTimeSpan(TimeSpan.FromTicks(allowableTimeframeStartDateTime.Ticks))));
        }

        /// <summary>
        ///     Returns true if status is open with no response and duration is less than max allowable duration;
        ///     OR, status is closed and the close date is within the allowable timeframe start to now.
        ///     Otherwise returns false.
        /// </summary>
        public bool IsUnrespondedOpenOrRecentlyClosedSl(DateTime allowableTimeframeStartDateTime,
            TimeSpan maxAllowableDuration)
        {
            return (HasResponse == false && (ToeType == ToeType.HighSl || ToeType == ToeType.LowSl)) &&
                   ((Status == ExcursionStatus.Open && (maxAllowableDuration == TimeSpan.FromMinutes(0) ||
                                                        (StartDateTime.IsWithinTimeSpan(maxAllowableDuration)))) ||
                    (Status == ExcursionStatus.Closed && EndDateTime.HasValue &&
                     EndDateTime.IsWithinTimeSpan(TimeSpan.FromTicks(allowableTimeframeStartDateTime.Ticks))));
        }

        /// <summary>
        ///     Returns true if status is open with no response and duration is less than max allowable duration;
        ///     OR, status is closed and the close date is within the allowable timeframe start to now.
        ///     Otherwise returns false.
        /// </summary>
        public bool IsUnrespondedOpenOrRecentlyClosedTarget(DateTime allowableTimeframeStartDateTime,
            TimeSpan maxAllowableDuration)
        {
            return (HasResponse == false && (ToeType == ToeType.HighTarget || ToeType == ToeType.LowTarget)) &&
                   ((Status == ExcursionStatus.Open && (maxAllowableDuration == TimeSpan.FromMinutes(0) ||
                                                        (StartDateTime.IsWithinTimeSpan(maxAllowableDuration)))) ||
                    (Status == ExcursionStatus.Closed && EndDateTime.HasValue &&
                     EndDateTime.IsWithinTimeSpan(TimeSpan.FromTicks(allowableTimeframeStartDateTime.Ticks))));
        }

        private void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }

        private bool AllExcursionsHaveBeenResponded
        {
            get
            {
                return
                    excursions.TrueForAll(
                        excursion =>
                            excursion.OpmExcursionResponse != null && excursion.OpmExcursionResponse.HasResponse);
            }
        }

        public void UpdateFromExcursion(OpmExcursion excursion)
        {
            // If the group has been responded, remove all CLOSED excursions.
            var isMostRecentExcursion = excursion.StartDateTime.Ticks >= StartDateTime.Ticks;
            var entireGroupOrIndividualExcursionResponded = HasResponse ||
                                                            (excursion.OpmExcursionResponse != null &&
                                                            excursion.OpmExcursionResponse.HasResponse);
            var shouldRemoveExcursion = entireGroupOrIndividualExcursionResponded &&
                                        excursion.Status == ExcursionStatus.Closed;

            if (ContainsExcursionById(excursion.IdValue))
            {
                // update the excursion in case it's changed
                RemoveExcursionById(excursion.IdValue);
                if (!shouldRemoveExcursion)
                {
                    excursions.Add(excursion);
                }
            }
            else
            {
                if (!shouldRemoveExcursion)
                {
                    excursions.Add(excursion);
                }
            }

            // Update the group if this is the most recent excursion
            if (isMostRecentExcursion)
            {
                StartDateTime = excursion.StartDateTime;
                EndDateTime = excursion.EndDateTime;
                Status = excursion.Status;
            }

            // HasResponse should be true only if ALL excursions in the group have been responded to
            var allExcursionsResponded = AllExcursionsHaveBeenResponded;
            HasResponse = allExcursionsResponded;

            // If the status is OPEN and all excursions have been responded to, remove all the CLOSED excursions from the group
            if (Status == ExcursionStatus.Open && HasResponse)
            {
                RemoveAllClosedExcursions();
            }
        }
    }
}
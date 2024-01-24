using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    public class LabAlert : DomainObject, IFunctionalLocationRelevant, IHasDefinition
    {
        private List<LabAlertResponse> responses = new List<LabAlertResponse>();

        public LabAlert()
        {
            Status = LabAlertStatus.NotResponded;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public FunctionalLocation FunctionalLocation { get; set; }

        public TagInfo TagInfo { get; set; }

        public int MinimumNumberOfSamples { get; set; }

        public int ActualNumberOfSamples { get; set; }

        public DateTime LabAlertTagQueryRangeFromDateTime { get; set; }

        public DateTime LabAlertTagQueryRangeToDateTime { get; set; }

        public string ScheduleDescription { get; set; }

        public long LabAlertDefinitionId { get; set; }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public LabAlertStatus Status { get; set; }

        public List<LabAlertResponse> Responses
        {
            get { return responses; }
            set { responses = value ?? new List<LabAlertResponse>(); }
        }

        public string WhenToCheckDescription
        {
            get
            {
                return string.Format(StringResources.LabAlertWhenToCheckDescription, MinimumNumberOfSamples,
                    LabAlertTagQueryRangeFromDateTime.ToLongDateAndTimeString(),
                    LabAlertTagQueryRangeToDateTime.ToLongDateAndTimeString());
            }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public long DefinitionId
        {
            get { return LabAlertDefinitionId; }
        }

        public static LabAlert CreateLabAlertForTagFailure(
            LabAlertDefinition definition, DateTime intendedScheduleExecutionTime,
            User lastModifiedUser, DateTime lastModifiedDate)
        {
            var rangeCalculator = new LabAlertCheckRangeCalculator(definition, intendedScheduleExecutionTime);

            var fromRange = rangeCalculator.FromDateTime;
            var toRange = rangeCalculator.ToDateTime;

            var alert = new LabAlert
            {
                Name = definition.Name,
                Description =
                    StringResources.LabAlertTagFailureDescriptionText + Environment.NewLine + Environment.NewLine +
                    definition.Description,
                FunctionalLocation = definition.FunctionalLocation,
                TagInfo = definition.TagInfo,
                MinimumNumberOfSamples = definition.MinimumNumberOfSamples,
                LabAlertTagQueryRangeFromDateTime = fromRange,
                LabAlertTagQueryRangeToDateTime = toRange,
                ScheduleDescription = definition.ScheduleDescription,
                LabAlertDefinitionId = definition.IdValue,
                LastModifiedBy = lastModifiedUser,
                LastModifiedDate = lastModifiedDate,
                CreatedDateTime = lastModifiedDate,
                Status = LabAlertStatus.DataUnavailable
            };

            return alert;
        }

        public static List<FunctionalLocation> BuildFunctionalLocationListForResponseLog(
            List<FunctionalLocation> userSelectedFlocRoots, bool allowStandardLogAtSecondLevelFunctionalLocation,
            IFunctionalLocationInfoService flocInfoService)
        {
            var flocs = new List<FunctionalLocation>();
            GetAllowedFlocs(flocs, userSelectedFlocRoots, allowStandardLogAtSecondLevelFunctionalLocation,
                flocInfoService);
            return flocs;
        }

        private static void GetAllowedFlocs(List<FunctionalLocation> allowedFlocs,
            IList<FunctionalLocation> sourceFlocList, bool allowStandardLogAtSecondLevelFunctionalLocation,
            IFunctionalLocationInfoService infoService)
        {
            foreach (var floc in sourceFlocList)
            {
                if (FlocIsAllowed(floc, allowStandardLogAtSecondLevelFunctionalLocation))
                {
                    allowedFlocs.Add(floc);
                }
                else if (floc.Type < FunctionalLocationType.Level3)
                {
                    var childFlocs = infoService.QueryByParentFunctionalLocation(floc);
                    GetAllowedFlocs(allowedFlocs, childFlocs.ConvertAll(obj => obj.Floc),
                        allowStandardLogAtSecondLevelFunctionalLocation, infoService);
                }
            }
        }

        private static bool FlocIsAllowed(FunctionalLocation floc, bool allowStandardLogAtSecondLevelFunctionalLocation)
        {
            if (floc.IsDivision || (!allowStandardLogAtSecondLevelFunctionalLocation && floc.IsSection))
            {
                return false;
            }

            return true;
        }
    }
}
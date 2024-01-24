using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class CommentsReportAdapter : AbstractLocalizedReportAdapter
    {
        public CommentsReportAdapter(string parentId, string createdByUser, DateTime logDateTime, string locationText,
            string comment, string logTypeLabel, bool suppressLogType, bool suppressCreatedByUser)
        {
            ParentId = parentId;

            CreatedByUser = createdByUser;
            LogDateTime = logDateTime;
            LocationText = locationText;
            Comments = comment;

            LogTypeLabel = logTypeLabel;
            SuppressLogTypeLabel = suppressLogType;
            SuppressCreatedByUser = suppressCreatedByUser;
        }

        public string ParentId { get; private set; }
        public string LogTypeLabel { get; private set; }
        public string CreatedByUser { get; private set; }

        public string LogTime
        {
            get { return LogDateTime.ToTimeString(); }
        }

        public DateTime LogDateTime { get; private set; }
        public string LocationText { get; private set; }
        public string Comments { get; private set; }

        public bool SuppressLogTypeLabel { get; private set; }
        public bool SuppressCreatedByUser { get; private set; }

        internal static IEnumerable<CommentsReportAdapter> GetAdapters(
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire, IEnumerable<HasCommentsDTO> logs, string logTypeLabel,
            bool suppressLogTypeLabel, bool suppressCreatedByUser)
        {
            var adapters = new List<CommentsReportAdapter>();
            foreach (var log in logs)
            {
                var logText = log.RtfComments;

                var workAssignment = shiftHandoverQuestionnaire.Assignment;
                // TODO: Remove the check for Site Edmonton in the future.
                var hasSameFunctionalLocations = workAssignment.SiteId == Site.EDMONTON_ID &&
                                                 workAssignment.HasSameFunctionalLocations(log.FunctionalLocationNames);

                var locationText = hasSameFunctionalLocations
                    ? string.Empty
                    : log.FunctionalLocationsAsCommaSeparatedFullHierarchyList;

                //adapters.Add(new CommentsReportAdapter(
                //    shiftHandoverQuestionnaire.IdValue.ToString(CultureInfo.InvariantCulture),
                //    log.CreationUserFullName,
                //    log.LogDateTime,
                //    locationText,
                //    logText,
                //    logTypeLabel,  
                //    suppressLogTypeLabel,
                //    suppressCreatedByUser));


                //Mukesh for Log Image
                CommentsReportAdapter commentsReportAdapter = new CommentsReportAdapter(
                        shiftHandoverQuestionnaire.IdValue.ToString(CultureInfo.InvariantCulture),
                        log.CreationUserFullName,
                        log.LogDateTime,
                        locationText,
                        logText,
                        logTypeLabel,
                        suppressLogTypeLabel,
                        suppressCreatedByUser);

                commentsReportAdapter.Imagelist = log.SummaryLogImagelist ?? new List<LogImage>();
                adapters.Add(commentsReportAdapter);

            }
            return adapters;
        }


        //Mukesh for Log Image
        public List<LogImage> Imagelist { get; set; }
    }
}
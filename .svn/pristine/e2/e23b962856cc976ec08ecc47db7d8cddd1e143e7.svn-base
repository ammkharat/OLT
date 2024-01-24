using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class GenericMultiLogReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly List<CustomFieldsReportAdapter> customFieldsReportAdapters =
            new List<CustomFieldsReportAdapter>();

        private readonly List<DocumentLinkReportAdapter> documentLinkReportAdapters =
            new List<DocumentLinkReportAdapter>();

        private readonly string flocGroupByValue;

        private readonly List<FunctionalLocationReportAdapter> flocReportAdapters =
            new List<FunctionalLocationReportAdapter>();

        private readonly AssignmentSectionUnitReportGroupBy groupBy;
        private readonly List<GenericMultiLogReportAdapter> logReportAdapters = new List<GenericMultiLogReportAdapter>();

        public GenericMultiLogReportAdapter(DetailedLogReportDTO log, AssignmentSectionUnitReportGroupBy groupBy,
            string flocGroupByValue)
        {
            flocReportAdapters.AddRange(GetFunctionalLocations(log));
            documentLinkReportAdapters.AddRange(GetDocumentLinks(log));
            customFieldsReportAdapters.AddRange(GetCustomFieldEntries(log));

            this.groupBy = groupBy;
            this.flocGroupByValue = flocGroupByValue;

            Id = log.IdValue.ToString(CultureInfo.InvariantCulture);

            Label_Title = StringResources.ReportLabel_Title_DetailedLogReport;
            ShiftGroupByValue = log.ShiftStartDateTime.Ticks.ToString(CultureInfo.InvariantCulture);
            LastModifiedByName = log.LastModifiedByUser;
            LogDateTimeAsString = log.LogDateTime.ToLongDateAndTimeString();
            LogDateTime = log.LogDateTime;
            Shift = log.ShiftDisplayName;
            WorkAssignment = log.WorkAssignment ?? Common.Domain.WorkAssignment.NoneWorkAssignment.Name;
            RecommendForSummary = log.RecommendForSummary;
            CommentsAsPlainText = log.PlainTextComments;
            CommentsAsRtfText = log.RtfComments;
            EnvironmentalHealthSafetyFollowUp = log.EnvironmentalHealthSafetyFollowUp;
            ProcessControlFollowUp = log.ProcessControlFollowUp;
            OperationsFollowUp = log.OperationsFollowUp;
            InspectionFollowUp = log.InspectionFollowUp;
            SupervisionFollowUp = log.SupervisionFollowUp;
            OtherFollowUp = log.OtherFollowUp;

            ShowDocumentLinks = log.DocumentLinks.Count > 0;
            ShowCustomFields = log.CustomFieldEntries != null &&
                               log.CustomFieldEntries.Count > 0 &&
                               log.CustomFieldEntries.Exists(obj => !string.IsNullOrEmpty(obj.FieldEntryForDisplay));
        }

        public string Id { get; private set; }

        public string LastModifiedByName { get; private set; }
        public string LogDateTimeAsString { get; private set; }
        public DateTime LogDateTime { get; private set; }
        public string Shift { get; private set; }
        public string WorkAssignment { get; private set; }
        public bool RecommendForSummary { get; private set; }
        public string CommentsAsPlainText { get; private set; }
        public string CommentsAsRtfText { get; private set; }
        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }
        public bool ProcessControlFollowUp { get; private set; }
        public bool OperationsFollowUp { get; private set; }
        public bool InspectionFollowUp { get; private set; }
        public bool SupervisionFollowUp { get; private set; }
        public bool OtherFollowUp { get; private set; }

        public bool ShowFollowup
        {
            get
            {
                return EnvironmentalHealthSafetyFollowUp ||
                       ProcessControlFollowUp ||
                       OperationsFollowUp ||
                       InspectionFollowUp ||
                       SupervisionFollowUp ||
                       OtherFollowUp;
            }
        }

        public List<GenericMultiLogReportAdapter> LogReportAdapters
        {
            get { return logReportAdapters; }
        }

        public List<FunctionalLocationReportAdapter> FlocReportAdapters
        {
            get { return flocReportAdapters; }
        }

        public List<DocumentLinkReportAdapter> DocumentLinkReportAdapters
        {
            get { return documentLinkReportAdapters; }
        }

        public List<CustomFieldsReportAdapter> CustomFieldReportAdapters
        {
            get { return customFieldsReportAdapters; }
        }

        public bool ShowDocumentLinks { get; private set; }
        public bool ShowCustomFields { get; private set; }

        private static List<FunctionalLocationReportAdapter> GetFunctionalLocations(DetailedLogReportDTO log)
        {
            return log.FunctionalLocationNames.ConvertAll(floc => new FunctionalLocationReportAdapter(log.IdValue, floc));
        }

        private static IEnumerable<DocumentLinkReportAdapter> GetDocumentLinks(DetailedLogReportDTO log)
        {
            return log.DocumentLinks.ConvertAll(obj => new DocumentLinkReportAdapter(
                log.IdValue.ToString(CultureInfo.InvariantCulture), obj.Url, obj.Title));
        }

        private static IEnumerable<CustomFieldsReportAdapter> GetCustomFieldEntries(DetailedLogReportDTO dto)
        {
            return CustomFieldsReportAdapter.GetCustomFields(dto.IdValue, dto);
        }

        #region Grouping Properties

        public string ShiftGroupByValue { get; private set; }

        public bool ShouldGroup
        {
            get { return groupBy.IdValue != AssignmentSectionUnitReportGroupBy.None.IdValue; }
        }

        public string GroupByHeading
        {
            get { return groupBy.GetShortName(); }
        }

        public string GroupByValue
        {
            get
            {
                if (groupBy.IdValue == AssignmentSectionUnitReportGroupBy.Assignment.IdValue)
                {
                    return WorkAssignment;
                }
                if (groupBy.IdValue == AssignmentSectionUnitReportGroupBy.Section.IdValue ||
                    groupBy.IdValue == AssignmentSectionUnitReportGroupBy.Unit.IdValue)
                {
                    return flocGroupByValue;
                }
                if (groupBy.IdValue == AssignmentSectionUnitReportGroupBy.None.IdValue)
                {
                    return string.Empty;
                }
                return string.Empty;
            }
        }

        public string SecondaryGroupByValue
        {
            get
            {
                if (groupBy.IdValue == AssignmentSectionUnitReportGroupBy.None.IdValue)
                {
                    return string.Empty;
                }
                return LastModifiedByName;
            }
        }

        public bool ShowWorkAssignmentInDetailSection
        {
            get { return groupBy.IdValue != AssignmentSectionUnitReportGroupBy.Assignment.IdValue; }
        }

        #endregion
    }
}
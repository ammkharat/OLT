using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using System.Linq;
using Com.Suncor.Olt.Reports.SubReports.DailyShiftLog;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class DailyShiftLogReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly List<DailyShiftLogCommentsReportAdapter> commentsAdapters;
        private readonly List<TagInfoReportAdapter> tagAdapters;
        
        public DailyShiftLogReportAdapter(String labelTitle, DailyShiftLogReportDTO reportDTO)
        {
            Label_Title = labelTitle;
            commentsAdapters = reportDTO.Logs.ConvertAll(l => new DailyShiftLogCommentsReportAdapter(l));
            tagAdapters = reportDTO.TagInfoReportDetailList.ConvertAll(t => new TagInfoReportAdapter(t));
        }

        public bool HasTags
        {
            get { return tagAdapters.Count > 0; }
        }

        public bool HasComments
        {
            get { return commentsAdapters.Count > 0; }
        }

        public List<DailyShiftLogCommentsReportAdapter> CommentsAdapters
        {
            get { return commentsAdapters; }
        }

        public List<TagInfoReportAdapter> TagAdapters
        {
            get { return tagAdapters; }
        }
    }

    public class TagInfoReportAdapter : AbstractLocalizedReportAdapter
    {
        public TagInfoReportAdapter(TagInfoReportDetail details)
        {
            Name = details.Name;
            Description = details.Description;
            Value = details.Value.HasValue ? details.Value.ToString() : StringResources.InvalidPhdRead;
            Unit = details.UnitName;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        public string Unit { get; private set; }
    }

    public class DailyShiftLogCommentsReportAdapter : AbstractLocalizedReportAdapter
    {
        public DailyShiftLogCommentsReportAdapter(LogReportDTO dto)
        {
            ShiftName = dto.ShiftName;
            ShiftStartDate = dto.ShiftStartDateTime;
            FunctionalLocationFullHierarchy = dto.FunctionalLocationFullHierarchy;
            FunctionalLocationUnitLevel = dto.FunctionalLocationUnitLevel;
            FunctionalLocationDescription = dto.FunctionalLocationDescription;
            FunctionalLocationUnitLevelDescription = dto.FunctionalLocationUnitLevelDescription;
            LoggedByUser = dto.LastModifiedByUser;
            LoggedDate = dto.LogDateTime;
            RtfComments = dto.RtfComments.TrimEnd();

//            Label_Title = StringResources.ReportLabel_Title_DailyShiftLog;

            //mangesh # RITM0208281
            IsOnlyReturnLogsFlaggedAsOperatingEngineerLog = dto.IsOnlyReturnLogsFlaggedAsOperatingEngineerLog;
            CustomFieldsReportAdapters = CustomFieldsReportAdapter.GetCustomFields(dto.IdValue, dto).ToList();
            FunctionalLocations = dto.FunctionalLocationNames.Aggregate(new System.Text.StringBuilder(),
                  (sb, a) => sb.AppendLine(String.Join(",", a)),
                  sb => sb.ToString());
            ShowCustomFields = dto.CustomFieldEntries != null &&
                               dto.CustomFieldEntries.Count > 0 &&
                               dto.CustomFieldEntries.Exists(obj => !string.IsNullOrEmpty(obj.FieldEntryForDisplay));
            CustomFieldLabelText = IsOnlyReturnLogsFlaggedAsOperatingEngineerLog && ShowCustomFields ? StringResources.ReportLabel_CustomFields.ToUpper() : string.Empty;
        }

        //mangesh # RITM0208281
        public List<CustomFieldsReportAdapter> CustomFieldsReportAdapters { get; set; }
        public string FunctionalLocations { get; private set; }
        public bool IsOnlyReturnLogsFlaggedAsOperatingEngineerLog { get; private set; }
        public bool ShowCustomFields { get; private set; }
        public string CustomFieldLabelText { get; private set; }

        public string ShiftName { get; private set; }
        public DateTime ShiftStartDate { get; private set; }

        public string FunctionalLocationFullHierarchy { get; private set; }
        public string FunctionalLocationUnitLevel { get; private set; }
        public string FunctionalLocationDescription { get; private set; }
        public string FunctionalLocationUnitLevelDescription { get; private set; }

        public string LoggedByUser { get; private set; }
        public DateTime LoggedDate { get; private set; }

        public string RtfComments { get; private set; }
    }
}
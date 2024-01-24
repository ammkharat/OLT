using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class CustomFieldTrendReportDTO : DomainObject
    {
        public enum LogType
        {
            Standard = 1,
            SummaryLog = 2,
            DailyDirective = 3
        }

        private readonly LogType logType;
        private readonly string shiftName;
        private readonly Date shiftStartDate;

        public CustomFieldTrendReportDTO(long id, LogType logType, string lastModifiedByFullNameWithUserName,
            DateTime logDateTime, string shiftName, Date shiftStartDate, string functionalLocations,
            List<CustomFieldEntry> customFieldEntries, string workAssignmentName, List<CustomField> customFields)
        {
            this.id = id;
            LastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
            LogDateTime = logDateTime;
            this.shiftName = shiftName;
            FunctionalLocationNames = functionalLocations;
            WorkAssignmentName = workAssignmentName;
            this.logType = logType;
            this.shiftStartDate = shiftStartDate;
            CustomFields = customFields;
            CustomFieldEntries = customFieldEntries;
        }

        public string LastModifiedByFullNameWithUserName { get; private set; }
        public DateTime LogDateTime { get; private set; }
        public string FunctionalLocationNames { get; private set; }
        public List<CustomFieldEntry> CustomFieldEntries { get; private set; }
        public List<CustomField> CustomFields { get; private set; }
        public string WorkAssignmentName { get; private set; }

        public string LogTypeName
        {
            get
            {
                if (logType.Equals(LogType.Standard))
                {
                    return StringResources.ReportLogTypeDisplay_Log;
                }

                if (logType.Equals(LogType.DailyDirective))
                {
                    return StringResources.ReportLogTypeDisplay_DailyDirective;
                }

                if (logType.Equals(LogType.SummaryLog))
                {
                    return StringResources.ReportLogTypeDisplay_ShiftSummary;
                }

                return string.Empty;
            }
        }

        public string ShiftName
        {
            get { return String.Format("{0} - {1}", shiftStartDate, shiftName); }
        }

        public void AddCustomFieldEntry(CustomFieldEntry customFieldEntry)
        {
            if (customFieldEntry != null && !HasCustomFieldEntryAlready(customFieldEntry))
            {
                CustomFieldEntries.Add(customFieldEntry);
            }
        }

        public void AddCustomField(CustomField customField)
        {
            if (customField != null && !HasCustomFieldAlready(customField))
            {
                CustomFields.Add(customField);
            }
        }

        private bool HasCustomFieldAlready(CustomField customField)
        {
            return CustomFields.Exists(cf => cf.Id == customField.Id);
        }

        private bool HasCustomFieldEntryAlready(CustomFieldEntry customFieldEntry)
        {
            return CustomFieldEntries.Exists(e => e.Id == customFieldEntry.Id);
        }

        public static List<CustomFieldTrendReportDTO> RemoveEmpties(List<CustomFieldTrendReportDTO> dtos)
        {
            var resultDtos = new List<CustomFieldTrendReportDTO>(dtos);
            resultDtos.RemoveAll(
                dto =>
                    dto.CustomFieldEntries == null || dto.CustomFieldEntries.IsEmpty() ||
                    !CustomFieldEntry.HasAtLeastOneNonEmptyEntry(dto.CustomFieldEntries));
            return resultDtos;
        }

        // this method makes sure all dtos have the same custom field entries and in the same order, filling ones that didn't exist with 'N/A'
        public static List<CustomFieldTrendReportDTO> StandardizeCustomFields(List<CustomFieldTrendReportDTO> dtos)
        {
            var originCustomFieldIds = new List<long>();

            foreach (var dto in dtos)
            {
                dto.CustomFieldEntries = CustomFieldEntry.PadEntriesWithBlanks(dto.CustomFields, dto.CustomFieldEntries);

                CustomField.SortAndResetDisplayOrder(dto.CustomFields);
                dto.CustomFieldEntries.Sort(
                    (x, y) =>
                        dto.CustomFields.Find(cf => cf.Id == x.CustomFieldId)
                            .DisplayOrder.CompareTo(dto.CustomFields.Find(cf => cf.Id == y.CustomFieldId).DisplayOrder));

                foreach (var entry in dto.CustomFieldEntries)
                {
                    var customField = dto.CustomFields.Find(cf => cf.Id == entry.CustomFieldId);

                    if (!originCustomFieldIds.Contains(customField.OriginCustomFieldId.Value))
                    {
                        originCustomFieldIds.Add(customField.OriginCustomFieldId.Value);
                    }
                }
            }

            // sort in reverse order by log datetime so that we can find the latest custom field name for each custom field
            var dtosInReverseLogDateTimeOrder = new List<CustomFieldTrendReportDTO>(dtos);
            dtosInReverseLogDateTimeOrder.Sort((x, y) => y.LogDateTime.CompareTo(x.LogDateTime));

            foreach (var dto in dtos)
            {
                var newCustomFieldEntries = new List<CustomFieldEntry>();

                var displayOrder = 0;
                foreach (var originCustomFieldId in originCustomFieldIds)
                {
                    var customFieldForThisDto =
                        dto.CustomFields.Find(cf => cf.OriginCustomFieldId == originCustomFieldId);

                    var latestDtoForCustomField =
                        dtosInReverseLogDateTimeOrder.Find(
                            x => x.CustomFields.Exists(cf => cf.OriginCustomFieldId == originCustomFieldId));
                    var latestCustomField =
                        latestDtoForCustomField.CustomFields.Find(cf => cf.OriginCustomFieldId == originCustomFieldId);
                    var latestCustomFieldName = latestCustomField.Name;

                    CustomFieldEntry existingEntry = null;
                    if (customFieldForThisDto != null)
                    {
                        existingEntry = dto.CustomFieldEntries.Find(e => e.CustomFieldId == customFieldForThisDto.Id);
                    }

                    if (existingEntry != null)
                    {
                        var type = existingEntry.Type;
                        var phdLinkType = existingEntry.PhdLinkType;
                        CustomFieldEntry customFieldEntry = null;
                        if (type.Equals(CustomFieldType.NumericValue))
                        {
                            customFieldEntry = new CustomFieldEntry(null, customFieldForThisDto.Id,
                                latestCustomFieldName, null, existingEntry.NumericFieldEntry,existingEntry.NewNumericFieldEntry, displayOrder, type,
                                phdLinkType,null);
                        }
                        else
                        {
                            customFieldEntry = new CustomFieldEntry(null, customFieldForThisDto.Id,
                                latestCustomFieldName, existingEntry.FieldEntry, null,null, displayOrder, type, phdLinkType,null);
                        }

                        newCustomFieldEntries.Add(customFieldEntry);
                    }
                    else
                    {
                        newCustomFieldEntries.Add(new CustomFieldEntry(null, null, latestCustomFieldName, "N/A", null,null,
                            displayOrder, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
                    }

                    displayOrder += 1;
                }

                dto.CustomFieldEntries.Clear();
                dto.CustomFieldEntries.AddRange(newCustomFieldEntries);
            }

            return dtos;
        }
    }
}
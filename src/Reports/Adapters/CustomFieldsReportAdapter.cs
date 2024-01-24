using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class CustomFieldsReportAdapter
    {
        private readonly List<CustomFieldEntry> threeEntries;

        public CustomFieldsReportAdapter(
            string parentId,
            string logId,
            string createdByUser,
            DateTime logDateTime,
            string flocs,
            List<CustomFieldEntry> threeEntries,
            string logTypeLabel,
            bool suppressLogTypeLabel,
            bool suppressCreatedByUser)
        {
            ParentId = parentId;
            LogId = logId;
            CreatedByUser = createdByUser;
            LogDateTime = logDateTime;
            FunctionalLocations = flocs;
            this.threeEntries = threeEntries;

            LogTypeLabel = logTypeLabel;
            SuppressLogTypeLabel = suppressLogTypeLabel;
            SuppressCreatedByUser = suppressCreatedByUser;
        }


        public string ParentId { get; private set; }
        public string LogId { get; private set; }
        public string CreatedByUser { get; private set; }
        public DateTime LogDateTime { get; private set; }

        public string LogTime
        {
            get { return LogDateTime.ToTimeString(); }
        }

        public string FunctionalLocations { get; private set; }

        public string LogTypeLabel { get; private set; }
        public bool SuppressLogTypeLabel { get; private set; }
        public bool SuppressCreatedByUser { get; private set; }

        //Added by mangesh new start
        //public string GreaterThanValue { get; private set; }
        //public string LessThanValue { get; private set; }
        //public string RangeGreaterThanValue { get; private set; }
        //public string RangeLessThanValue { get; private set; }
        //Added by mangesh new end

        public string FieldOneEntryColor
        {
            get { return GetColor(0); }
        }

        public string FieldTwoEntryColor
        {
            get { return GetColor(1); }
        }

        public string FieldThreeEntryColor
        {
            get { return GetColor(2); }
        }
        private string GetColor(int index)
        {
            if (index >= threeEntries.Count)
            {
                return string.Empty;
            }
            return Convert.ToString(threeEntries[index].Color);
        }

        public string FieldOneName
        {
            get { return CustomFieldName(0); }
        }

        public string FieldOneEntry
        {
            get { return FieldEntry(0); }
        }

        public string FieldTwoName
        {
            get { return CustomFieldName(1); }
        }

        public string FieldTwoEntry
        {
            get { return FieldEntry(1); }
        }

        public string FieldThreeName
        {
            get { return CustomFieldName(2); }
        }

        public string FieldThreeEntry
        {
            get { return FieldEntry(2); }
        }

       
        private string CustomFieldName(int index)
        {
            if (index >= threeEntries.Count)
            {
                return string.Empty;
            }
            if (threeEntries[index].IsJustForDisplay) return threeEntries[index].CustomFieldName;
            return threeEntries[index].CustomFieldName + ":";
        }

        private string FieldEntry(int index)
        {
            if (index >= threeEntries.Count)
            {
                return string.Empty;
            }
            return threeEntries[index].FieldEntryForDisplay;
        }
        
        public static IEnumerable<CustomFieldsReportAdapter> GetCustomFields(long parentId, List<HasCommentsDTO> logs,
            string logTypeLabel, bool suppressLogTypeLabel, bool suppressCreadByUser)
        {
            var customFieldsReportAdapters = new List<CustomFieldsReportAdapter>();


            logs.Sort((x, y) => DateTime.Compare(x.LogDateTime, y.LogDateTime));

            for (var i = 0; i < logs.Count; i++)
            {
                var log = logs[i];

                if (log.ContainsCustomFieldEntries())
                {
                    var sortableLogId = i.ToString("00000000") + "-" + (log.Id.HasValue ? log.IdValue.ToString() : "");

                    customFieldsReportAdapters.AddRange(GetCustomFields(
                        parentId,
                        sortableLogId,
                        log.CreationUserFullName,
                        log.LogDateTime,
                        log.FunctionalLocationsAsCommaSeparatedFullHierarchyList,
                        CustomFieldEntry.PadEntriesWithBlanks(log.CustomFields, log.CustomFieldEntries),
                        logTypeLabel, suppressLogTypeLabel, suppressCreadByUser));
                }
            }

            return customFieldsReportAdapters;
        }

        //mangesh # RITM0208281
        public static IList<CustomFieldsReportAdapter> GetCustomFields(long parentId, LogReportDTO log)
        {
            if (CustomFieldEntry.HasAtLeastOneNonEmptyEntry(log.CustomFieldEntries))
            {
                return GetCustomFields(parentId, log.CustomFieldEntries);
            }
            return new List<CustomFieldsReportAdapter>();
        }
       
        public static IList<CustomFieldsReportAdapter> GetCustomFields(long parentId, DetailedLogReportDTO log)
        {
            if (CustomFieldEntry.HasAtLeastOneNonEmptyEntry(log.CustomFieldEntries))
            {
                return GetCustomFields(parentId, log.CustomFieldEntries);
            }
            return new List<CustomFieldsReportAdapter>();
        }

        public static IList<CustomFieldsReportAdapter> GetCustomFields(long parentId,
            List<CustomFieldEntry> customFieldEntries)
        {
            return GetCustomFields(parentId, string.Empty, string.Empty, new DateTime(), string.Empty,
                customFieldEntries, "", true, true);
        }

        private static IList<CustomFieldsReportAdapter> GetCustomFields(
            long parentId, string logId, string createdByUser, DateTime logDateTime, string flocs,
            List<CustomFieldEntry> customFieldEntries,
            string logTypeLabel, bool suppressLogTypeLabel, bool suppressCreatedByUser)
        {
            var customFieldsReportAdapters = new List<CustomFieldsReportAdapter>();
            //Added new by mangesh for E&U Custom field changes
            foreach (var customFieldEntry in customFieldEntries)
            {
                if (customFieldEntry.GreaterThanValue != null && customFieldEntry.GreaterThanValue >= customFieldEntry.NumericFieldEntry)
                {
                    customFieldEntry.Color = "R";
                }
                if (customFieldEntry.LessThanValue != null && customFieldEntry.LessThanValue <= customFieldEntry.NumericFieldEntry)
                {
                    customFieldEntry.Color = "R";
                }
                if (customFieldEntry.MaxValueofRange != null && customFieldEntry.MinValueofRange != null
                    && customFieldEntry.MinValueofRange > customFieldEntry.NumericFieldEntry || customFieldEntry.MaxValueofRange < customFieldEntry.NumericFieldEntry)
                {
                    customFieldEntry.Color = "R";
                }
            }
            //End 
            customFieldEntries.Sort();
            customFieldEntries.ForEachSlice(3, entries =>
            {
                var customFieldsReportAdapter = new CustomFieldsReportAdapter(
                    parentId.ToString(CultureInfo.InvariantCulture), logId, createdByUser, logDateTime, flocs, entries,
                    logTypeLabel, suppressLogTypeLabel, suppressCreatedByUser);
                customFieldsReportAdapters.Add(customFieldsReportAdapter);
            });

            

            return customFieldsReportAdapters;
        }
    }
}
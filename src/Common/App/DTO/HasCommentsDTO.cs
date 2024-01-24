using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class HasCommentsDTO : DomainObject, IHasCustomFieldEntries
    {
        public HasCommentsDTO(
            long id,
            DateTime logDateTime,
            string creationUserFullName,
            long creationUserId,
            string functionalLocationNames,
            List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields,
            string rtfComments,
            string plainTextComments)
        {
            this.id = id;
            LogDateTime = logDateTime;
            CreationUserFullName = creationUserFullName;
            CreationUserId = creationUserId;
            RtfComments = rtfComments;
            PlainTextComments = plainTextComments;

            FunctionalLocationNames = functionalLocationNames;
            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>(0);
            CustomFields = customFields ?? new List<CustomField>();
        }

        public HasCommentsDTO(Log log)
        {
            id = log.IdValue;
            LogDateTime = log.CreatedDateTime;
            CreationUserFullName = log.CreationUserFullName;
            CreationUserId = log.CreationUser.IdValue;
            RtfComments = log.RtfComments;
            PlainTextComments = log.PlainTextComments;

            var functionalLocations = log.FunctionalLocations ?? new List<FunctionalLocation>(0);
            FunctionalLocationNames = functionalLocations.FullHierarchyListToString(true, false);

            CustomFieldEntries = log.CustomFieldEntries ?? new List<CustomFieldEntry>(0);
            CustomFields = log.CustomFields ?? new List<CustomField>();
        }

        public HasCommentsDTO(SummaryLog summaryLog)
        {
            id = summaryLog.IdValue;
            LogDateTime = summaryLog.LogDateTime; //summaryLog.CreatedDateTime; //SO: 8003623281 Display LogDateTime Instead of CreatedDateTime
            CreationUserFullName = summaryLog.CreationUserFullName;
            CreationUserId = summaryLog.CreationUser.IdValue;
            RtfComments = summaryLog.RtfComments;
            PlainTextComments = summaryLog.PlainTextComments;

            var functionalLocations = summaryLog.FunctionalLocations ?? new List<FunctionalLocation>(0);
            FunctionalLocationNames = functionalLocations.FullHierarchyListToString(true, false);

            CustomFieldEntries = summaryLog.CustomFieldEntries ?? new List<CustomFieldEntry>(0);
            CustomFields = summaryLog.CustomFields ?? new List<CustomField>();

            //Mukesh for Log Image
           SummaryLogImagelist = summaryLog.Imagelist ?? new List<LogImage>();

        }

        public string CreationUserFullName { get; private set; }
        public long CreationUserId { get; private set; }
        public string RtfComments { get; private set; }
        public string PlainTextComments { get; private set; }

        public string FunctionalLocationNames { get; private set; }

        public string FunctionalLocationsAsCommaSeparatedFullHierarchyList
        {
            get { return FunctionalLocationNames; }
        }

        public DateTime LogDateTime { get; private set; }

        public List<CustomFieldEntry> CustomFieldEntries { get; private set; }
        public List<CustomField> CustomFields { get; private set; }

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
                CustomFields.Sort();
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

        //Mukesh for Log Image
        public List<LogImage> SummaryLogImagelist { get; set; }
    }
}
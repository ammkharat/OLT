using System;
using Com.Suncor.Olt.Common.Domain;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class LogReportDTO : DomainObject
    {
        public LogReportDTO(long id, long shiftId, string shiftName, DateTime shiftStartDateTime,
            string functionalLocationFullHierarchy, string functionalLocationDescription,
            string functionalLocationUnitLevel, string functionalLocationUnitLevelDescription,
            string lastModifiedByUser, DateTime logDateTime,
            string plainTextComments,
            string rtfComments)
        {
            this.id = id;

            ShiftId = shiftId;
            ShiftName = shiftName;
            ShiftStartDateTime = shiftStartDateTime;
            LastModifiedByUser = lastModifiedByUser;
            LogDateTime = logDateTime;
            PlainTextComments = plainTextComments;
            RtfComments = rtfComments;

            FunctionalLocationFullHierarchy = functionalLocationFullHierarchy;
            FunctionalLocationDescription = functionalLocationDescription;
            FunctionalLocationUnitLevel = functionalLocationUnitLevel;
            FunctionalLocationUnitLevelDescription = functionalLocationUnitLevelDescription;
        }

        //mangesh # RITM0208281  -- start
        public LogReportDTO(long id, long shiftId, string shiftName, DateTime shiftStartDateTime,
            string functionalLocationFullHierarchy, string functionalLocationDescription,
            string functionalLocationUnitLevel, string functionalLocationUnitLevelDescription,
            string lastModifiedByUser, DateTime logDateTime,
            string plainTextComments,
            string rtfComments,
            List<CustomFieldEntry> customFieldEntries,
            List<string> functionalLocationNames)
        {
            this.id = id;
            ShiftId = shiftId;
            ShiftName = shiftName;
            ShiftStartDateTime = shiftStartDateTime;
            LastModifiedByUser = lastModifiedByUser;
            LogDateTime = logDateTime;
            PlainTextComments = plainTextComments;
            RtfComments = rtfComments;

            FunctionalLocationFullHierarchy = functionalLocationFullHierarchy;
            FunctionalLocationDescription = functionalLocationDescription;
            FunctionalLocationUnitLevel = functionalLocationUnitLevel;
            FunctionalLocationUnitLevelDescription = functionalLocationUnitLevelDescription;

            CustomFieldEntries = customFieldEntries ?? new List<CustomFieldEntry>();
            FunctionalLocationNames = functionalLocationNames ?? new List<string>();
            FunctionalLocationNames.Sort();
        }
        public void AddCustomFieldEntry(CustomFieldEntry customFieldEntry)
        {
            if (customFieldEntry != null && !HasCustomFieldEntryAlready(customFieldEntry))
            {
                CustomFieldEntries.Add(customFieldEntry);
            }
        }
        
        public void AddFunctionalLocation(string functionalLocationName)
        {
            FunctionalLocationNames.AddAndSort(functionalLocationName);
        }

        private bool HasCustomFieldEntryAlready(CustomFieldEntry customFieldEntry)
        {
            return CustomFieldEntries.Exists(e => e.Id == customFieldEntry.Id);
        }

        public List<CustomFieldEntry> CustomFieldEntries { get; set; }
        public List<string> FunctionalLocationNames { get; set; }
        public bool IsOnlyReturnLogsFlaggedAsOperatingEngineerLog { get; set; }
        //--End---RITM0208281---//

        public long ShiftId { get; private set; }
        public string ShiftName { get; private set; }
        public DateTime ShiftStartDateTime { get; private set; }
        public string LastModifiedByUser { get; private set; }
        public DateTime LogDateTime { get; private set; }
        public string PlainTextComments { get; private set; }
        public string RtfComments { get; private set; }

        public string FunctionalLocationFullHierarchy { get; private set; }
        public string FunctionalLocationDescription { get; private set; }
        public string FunctionalLocationUnitLevel { get; private set; }
        public string FunctionalLocationUnitLevelDescription { get; private set; }
    }
}
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogCopyStrategy : ILogCopyStrategy
    {
        private readonly Log logToCopy;

        public LogCopyStrategy(Log logToCopy)
        {
            this.logToCopy = logToCopy;
        }

        public void Copy(ILogCopyFormView view, List<CustomField> customFields, WorkAssignment workAssignmentOfNewLog)
        {
            view.FunctionalLocations = GetFunctionalLocationsThatAreInCurrentActiveSet();            
            view.Comments = logToCopy.RtfComments;

            if (logToCopy.WorkAssignment != null && logToCopy.WorkAssignment.Equals(workAssignmentOfNewLog))
            {
                List<CustomFieldEntry> customFieldEntries = logToCopy.CustomFieldEntries;
                
                List<CustomFieldEntry> newListOfCustomFieldEntries = new List<CustomFieldEntry>();
                foreach (CustomField customField in customFields)
                {
                    CustomFieldEntry newCustomFieldEntry = new CustomFieldEntry(customField);

                    CustomField existingCustomField = logToCopy.CustomFields.Find(cf => cf.OriginCustomFieldId.Equals(customField.OriginCustomFieldId));
                    if (existingCustomField != null)
                    {
                        CustomFieldEntry existingCustomFieldEntry = customFieldEntries.Find(entry => entry.CustomFieldId.Equals(existingCustomField.Id));
                        if (existingCustomFieldEntry != null)
                        {
                            newCustomFieldEntry.SetValue(existingCustomFieldEntry.FieldEntryForDisplay);
                        }
                    }

                    newListOfCustomFieldEntries.Add(newCustomFieldEntry);
                }

                view.SetCustomFieldEntries(newListOfCustomFieldEntries, customFields);
            }
            else
            {
                view.SetCustomFieldEntries(customFields.ConvertAll(field => new CustomFieldEntry(field)), customFields);
            }

            if (logToCopy.FunctionalLocations.Count > 1)
            {
                view.CreateALogForEachFunctionalLocation = false;
            }
        }

        private List<FunctionalLocation> GetFunctionalLocationsThatAreInCurrentActiveSet()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            foreach (FunctionalLocation originalFloc in logToCopy.FunctionalLocations)
            {
                if (ClientSession.GetUserContext().RootsForSelectedFunctionalLocations.Exists(
                        activeFloc => activeFloc.Id == originalFloc.Id || activeFloc.IsParentOf(originalFloc)))
                {
                    flocs.Add(originalFloc);
                }
            }
            return flocs;
        }

        // This entire class is irritating to me. I had to add this because I can't find a better way to know if I'm doing a copy or not,
        // and I need to know. (Dustin)
        public bool IsCopying
        {
            get { return true; }
        }

        public Log LogToCopy
        {
            get { return logToCopy; }
        }
    }
}

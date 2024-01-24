using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ImportCustomFieldsPresenter
    {
        private readonly IImportCustomFieldsView view;
        private readonly List<CustomField> customFields;

        public ImportCustomFieldsPresenter(IImportCustomFieldsView view, List<CustomField> customFields)
        {
            this.view = view;
            this.customFields = customFields;
        }

        public void Import(ClientBackgroundWorker backgroundWorker, IPlantHistorianService plantHistorianService)
        {
            bool aFieldWillBeOverWritten = NonEmptyCustomFieldWithAssociatedPhTagExists();
            if (aFieldWillBeOverWritten)
            {
                DialogResult dialogResult = OltMessageBox.ShowCustomYesNo((Form)view, StringResources.CustomFieldsWillBeOverwrittenWarning, StringResources.CustomFieldsWillBeOverwrittenWarningTitle, MessageBoxIcon.Warning, StringResources.Yes, StringResources.No);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            List<CustomField> importableCustomFields = customFields.FindAll(field => field.PhdLinkType == CustomFieldPhdLinkType.Read && field.TagInfo != null);
            List<TagInfo> tagInfos = importableCustomFields.ConvertAll(field => field.TagInfo);

            CustomFieldTagValueReader tagValueReader = new CustomFieldTagValueReader(backgroundWorker, plantHistorianService, view.DisableControls, view.EnableControls, DoneImportingCustomFieldsData);
            tagValueReader.Run(tagInfos);
        }

        //Chnaged by Mukesh :-RITM0238302 from Dictionary<long, decimal?> to Dictionary<long, object?> 
        private void DoneImportingCustomFieldsData(Dictionary<long, object> results)
        {
            List<CustomField> importableCustomFields = customFields.FindAll(field => field.TagInfo != null);
            List<CustomFieldEntry> fieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            
            foreach (KeyValuePair<long, object> keyValuePair in results)
            {
                long tagInfoId = keyValuePair.Key;
                //decimal? value = keyValuePair.Value;
                object value = keyValuePair.Value;


                //ayman pi average




                List<CustomField> customFieldsForTag = importableCustomFields.FindAll(field => field.PhdLinkType == CustomFieldPhdLinkType.Read && field.TagInfo.IdValue == tagInfoId);
                foreach (CustomField customField in customFieldsForTag)
                {
                    CustomFieldEntry customFieldEntry = fieldEntries.Find(entry => entry.CustomFieldName == customField.Name);

                    if (customField.TagInfo.Deleted)
                    {
                        view.SetCustomFieldEntryText(customFieldEntry, StringResources.CustomFieldTagHasBeenDeleted);
                    }
                    //else if (value.HasValue)
                    else if (value!=null)
                    {
                        view.SetCustomFieldEntryText(customFieldEntry, value.ToString());
                    }
                    else
                    {
                        view.SetCustomFieldEntryText(customFieldEntry, StringResources.Unavailable);
                    }
                }
            }
        }

        private List<CustomFieldEntry> NonEmptyCustomFieldsToWriteToPhd()
        {
            List<CustomFieldEntry> customFieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            customFieldEntries.ForEach(entry => entry.SetValue(view.GetCustomFieldEntryText(entry)));

            return customFieldEntries.FindAll(entry => entry.PhdLinkType == CustomFieldPhdLinkType.Write && !entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace());
        }

        private bool NonEmptyCustomFieldWithAssociatedPhTagExists()
        {
            List<CustomFieldEntry> customFieldEntries = customFields.ConvertAll(field => new CustomFieldEntry(field));
            customFieldEntries.ForEach(entry => entry.SetValue(view.GetCustomFieldEntryText(entry)));

            return customFieldEntries.Exists(entry => entry.PhdLinkType == CustomFieldPhdLinkType.Read && !entry.FieldEntryForDisplay.IsNullOrEmptyOrWhitespace());
        }
    }
}

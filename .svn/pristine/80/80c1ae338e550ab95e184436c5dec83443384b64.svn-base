using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IRespondFormView: IBaseForm
    {
        List<ActionItemResponseTracker> TrackerList { set; }        //ayman action item reading
        void SelectFirstCustomField();                 //ayman action item reading
        List<ActionItemResponseForm.entriesText> GetEntriesTextForTracker();    //ayman action item reading
        DateTime CreateDateTime { set; get; }
        string Shift { set; }
        User Author { set; }
        SimpleDomainObject SelectedStatus { get;}

        //ayman custom fields DMND0010030
        string GetCustomFieldEntryText(CustomFieldEntry entry);   
        string GetCustomFieldEntryText(long customFieldId);    //ayman action item reading
        List<ActionItemResponseTracker> GetCustomFieldEntryTextForTracker(IEnumerable<CustomField> customfields); //ayman action item reading
     
        void DisableControls();
        void EnableControls();
        void SetCustomFieldEntryText(CustomFieldEntry entry, string text);
        void SetCustomFieldEntryTextForReading(List<ActionItemResponseTracker> entrieslist);
   //     void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries,bool reading);           //ayman action item reading
        void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField);
        void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields,ActionItem respondTo);                   //ayman action item reading
        void EnableCustomFieldsLabel(bool enable); //ayman custom fields DMND0010030
        void EnableCustomFieldControl(bool enable); //ayman action item reading
        void EnableCustomFieldAreaGroupBox(bool enable); //ayman action item reading
        void EnableTableLayoutPanel(bool enable);        //ayman action item reading


        string Comment { get;}
        void DisableLogCreatedWithComments();
        void EnableLogCreatedWithComments();
        bool CreateLogChecked { set; get; }
        new DialogResult DialogResult { set; }

        bool EnableActionItemImagePanel { set; get; }  // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
        

    }
}

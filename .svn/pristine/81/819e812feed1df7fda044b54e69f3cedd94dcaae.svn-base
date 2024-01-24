using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IActionItemResponseFormView : IRespondFormView
    {
        //List<CustomFieldEntry> CustomFieldList { set; }        //ayman action item reading
        //void SelectFirstCustomField();                 //ayman action item reading
    

        string ActionItemName { set; }
        string Category { set; }
        List<FunctionalLocation> FunctionalLocations { set; }
        string DetailComments { set; }

        bool IsLogAnOperatingEngineeringLog { set; get; }

        //   List<CustomFieldEntry> customFieldEntries { set; get; }       //ayman custom fields DMND0010030
        void CallImportCustomFields();                                     //ayman action item reading

        bool CommentOnly { set;get;}
        void EnableOperatingEngineerLogCheckbox(bool enabled);
        void HideOperatingEngineerLogCheckbox();
        string OperatingEngineerLogDisplayText { set; }

        /// <summary>
        /// Set whether the 'Create Log' option should be enabled.
        /// </summary>
        bool CreateLogEnabled { set; }
        bool CreateLogVisible { set; }

        void ShowCommentOnlyError();
        void ShowCommentRequiredError();
        void ClearErrors();

        void DisableReasonCodeDropDown();
        void EnableReasonCodeDropDown();

        bool ShowSaveButton { set;}

        ActionItemStatus SelectedActionItemStatus { set; get; }

        void HideCommentOnlyCheckbox();

        // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
        List<LogImage> ActionItemResponseImageLogdetails { set; get; }
        void SetErrorForAddButton();
        bool EnableAddButton { get; }
        string FilePathText { get; }
    }
}

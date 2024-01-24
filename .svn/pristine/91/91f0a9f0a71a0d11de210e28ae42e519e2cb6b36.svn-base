
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditCustomFieldFormView
    {
        string FieldName { get; set; }
        decimal? MinRangeValue { get; set; } // Custom Field Changes By : Swapnil Patki
        decimal? MaxRangeValue { get; set; } // Custom Field Changes By : Swapnil Patki
        decimal? GreaterThanValue { get; set; } // Custom Field Changes By : Swapnil Patki
        decimal? LessThanValue { get; set; } // Custom Field Changes By : Swapnil Patki
        bool? IsActive { get; set; } // Custom Field Changes By : Swapnil Patki
        //char Color { get; set; } // Custom Field Changes By : Swapnil Patki
        TagInfo TagInfo { get; set; }
        string TagValue { set; }
        bool RefreshButtonEnabled { set; }
        List<CustomFieldType> Types { set; }
        CustomFieldType Type { get; set; }
        CustomFieldPhdLinkType PhdLinkType { get; set; }
        bool DropDownListEditingEnabled { set; }
        CustomFieldDropDownValue SelectedDropDownValue { get; set; }
        List<CustomFieldDropDownValue> DropDownValues { set; }
        bool EditAndDeleteDropDownButtonsEnabled { set; }
        bool NameEditingEnabled { set; }
        bool PhdLinkTypeEditingEnabled { set; }
        //bool DisableRangeGroupBox { set; } // Custom Field Changes By : Swapnil Patki

        void ClearAllErrors();
        void SetErrorForNoNameProvided();

        void SaveSucceededMessage();
        void Close();
        DialogResultAndOutput<TagInfo> ShowTagSelector();
        void DisablePlantHistorianSection();
        void DisableControlsForBackgroundWorker();
        void EnableControlsForBackgroundWorker();
        void TurnOffDeletedTagIndicators();
        void IndicateThatTagInfoIsDeleted();
        CustomFieldDropDownValue LaunchAddEditValueForm(CustomFieldDropDownValue editObject);
        void SelectFirstDropDownValue();
        void SetErrorForDropDownValuesRequired();
        bool ShowWarningForNonNumericTypeAndReturnUserResult();
        void SetErrorForWriteMustUseNumericType();
        void SetErrorForNoPhdTagSelected();
        void SetErrorForNotAWriteTag();
        void SetErrorForCustomFieldRange();
        // Added by Mukesh:-RITM0238302
        void SetErrorForStringTagMustUseTextType();
        bool DisableRangeGroupBox{set;}
    }
}

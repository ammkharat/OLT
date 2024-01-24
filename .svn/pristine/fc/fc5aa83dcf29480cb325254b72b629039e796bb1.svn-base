using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITargetDefinitionReadWriteTagConfigurationView
    {
        bool TargetDefinitionNameEnabled { set; }
        string TargetDefinitionName { set; }
        TargetDefinitionReadWriteTagConfiguration ReadWriteTagsConfiguration { get;  }
                
        bool MaxThresholdTagEnabled { set; }
        bool MinThresholdTagEnabled { set; }
        bool TargetThresholdEnabled { set; }
        bool GapUnitValueEnabled { set; }

        IList<TagDirection> MaxThresholdDirectionList { set; }
        TagDirection MaxThresholdDirection { get; set; }
        IList<TagDirection> MinThresholdDirectionList { set; }
        TagDirection MinThresholdDirection { get; set; }
        IList<TagDirection> TargetThresholdDirectionList { set; }
        TagDirection TargetThresholdDirection { get; set; }
        IList<TagDirection> GapUnitValueDirectionList { set; }
        TagDirection GapUnitDirection { get; set; }

        TagInfo MaxThresholdTag { get; set; }
        TagInfo MinThresholdTag { get; set; }
        TagInfo TargetThresholdTag { get; set; }
        TagInfo GapUnitValueTag { get; set; }
        void ClearErrors();
        void ShowInvalidMaxThresholdDirectionError();
        void ShowInvalidMaxThresholdTagError();
        void ShowInvalidMinThresholdDirectionError();
        void ShowInvalidMinThresholdTagError();
        void ShowInvalidTargetThresholdDirectionError();
        void ShowInvalidTargetThresholdTagError();
        void ShowInvalidGapUnitValueDirectionError();
        void ShowInvalidGapUnitValueTagError();
        void ShowMaxAndMinSameTagError();
        void ShowMaxAndTargetSameTagError();
        void ShowMaxAndGapUnitValueSameTagError();
        void ShowMinAndTargetSameTagError();
        void ShowMinAndGapUnitValueSameTagError();
        void ShowTargetAndGapUnitValueSameTagError();
        void ShowMaxTagAssociatedToOtherTargetDefinitionError(string errorMessage);
        void ShowMinTagAssociatedToOtherTargetDefinitionError(string errorMessage);
        void ShowTargetTagAssociatedToOtherTargetDefinitionError(string errorMessage);
        void ShowGapUnitValueTagAssociatedToOtherTargetDefinitionError(string errorMessage);
        void ShowMaxTagInvalidReadError();
        void ShowMinTagInvalidReadError();
        void ShowTargetTagInvalidReadError();
        void ShowGapUnitValueTagInvalidReadError();
        void ShowMaxTagInvalidWriteError();
        void ShowMinTagInvalidWriteError();
        void ShowTargetTagInvalidWriteError();
        void ShowGapUnitValueTagInvalidWriteError();
        
        void SetDialogResultOK(); 
        DialogResult ShowDialog();
        ITagSearchFormView DisplayTagSearchForm();
        void CloseView();
       
    }
}
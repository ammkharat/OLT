using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISingleSelectFunctionalLocationSelectionForm : ISelectFunctionalLocationSelectionForm
    {
        FunctionalLocation SelectedFunctionalLocation { get; }        
    }

    public interface IConfigureFunctionalLocationsView
    {
        FunctionalLocation SelectedFunctionalLocation { get; }
        bool IsSelectedEditable { get; }
        FunctionalLocation ParentOfSelectedFunctionalLocation { get; }
        List<FunctionalLocation> ChildrenOfSelectedFunctionalLocation { get; }
        List<FunctionalLocation> SiblingsOfSelectedFunctionalLocation { get; }
        bool EditButtonEnabled { set; }
        bool DeleteButtonEnabled { set; }
        bool AddButtonEnabled { set; }

        void UpdateSelectedFunctionalLocation(FunctionalLocation functionalLocation);
        void RemoveSelectedFunctionalLocation();
        void AddNewFunctionalLocation(FunctionalLocation insertedFunctionalLocation);
    }

    public interface IAddEditFunctionalLocationView
    {
        string Description { get; set; }
        string SuperiorFloc { set; }
        string NextLevel { get; set; }
        bool ShouldAddOrUpdate { set; }
        string NewFullHierarchy { get; }
        string FullHierarchy { set; }
        void Close();
        void ClearErrors();
        void SetErrorForEmptyName();
        void SetErrorForInvalidCharactersInFlocName();
        void SetErrorForDuplicateFlocName();
        void SetErrorForEmptyDescription();
    }
}
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IBusinessCategoryFLOCAssociationView : IBaseForm
    {
        List<FunctionalLocation> DivisionLevelFunctionalLocations { set; }
        List<BusinessCategoryFLOCAssociation> Associations { set; }

        FunctionalLocation SelectedFunctionalLocation { set; get; }
        BusinessCategoryFLOCAssociation SelectedAssociation { get; set; }

        void ShowEditBusinessCategoryFLOCAssociationsPopupForm(
            FunctionalLocation selectedFunctionalLocation, List<BusinessCategory> masterList);

        void SelectFirstBusinessCategoryRow();
        void SelectFirstFunctionalLocation();
    }
}

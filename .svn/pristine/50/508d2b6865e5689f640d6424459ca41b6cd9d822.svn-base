using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public delegate List<BusinessCategoryFLOCAssociation> BusinessCategoriesForFLOCHandler(FunctionalLocation floc);

    public interface IAssociateBusinessCategoriesPopupView : IBaseForm
    { 
        List<BusinessCategoryFLOCAssociation> AssociationList { set; }
        List<BusinessCategory> BusinessCategoryList { set; }
        List<BusinessCategory> SelectedBusinessCategories { get; }
        List<BusinessCategoryFLOCAssociation> SelectedAssociations { get; set; }
        BusinessCategoryFLOCAssociation SelectedAssociation { set; }
        void ShowNoAssociationsSelectedMessageBox();        
    }
}

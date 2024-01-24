using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AssociateBusinessCategoriesPopupPresenter
    {
        private readonly IAssociateBusinessCategoriesPopupView view;                
        private readonly IBusinessCategoryFLOCAssociationService associationService;

        private readonly List<BusinessCategoryFLOCAssociation> originalAssociationList = new List<BusinessCategoryFLOCAssociation>();
        private readonly List<BusinessCategoryFLOCAssociation> masterAssociationList = new List<BusinessCategoryFLOCAssociation>();

        private readonly List<BusinessCategory> businessCategories;
        private readonly FunctionalLocation functionalLocation;
        
        public AssociateBusinessCategoriesPopupPresenter(
            IAssociateBusinessCategoriesPopupView view, 
            FunctionalLocation functionalLocation, 
            List<BusinessCategory> businessCategories)
        {
            this.view = view;
            this.functionalLocation = functionalLocation;
            this.businessCategories = businessCategories;
            
            associationService = ClientServiceRegistry.Instance.GetService<IBusinessCategoryFLOCAssociationService>();
        }

        public void HandleLoad(object sender, EventArgs e)
        {            
            view.BusinessCategoryList = businessCategories;

            List<BusinessCategoryFLOCAssociation> associations =
                    associationService.QueryByFLOCId(functionalLocation.Id.Value);

            originalAssociationList.AddRange(associations);
            masterAssociationList.AddRange(associations);

            view.AssociationList = masterAssociationList;
        }              

        public void AddAssociationButton_Clicked(object sender, EventArgs e)
        {
            List<BusinessCategory> selectedBusinessCategories = view.SelectedBusinessCategories;

            if (selectedBusinessCategories == null || selectedBusinessCategories.Count == 0)
            {
                return;
            }

            foreach (BusinessCategory selectedBusinessCategory in selectedBusinessCategories)
            {
                if (!masterAssociationList.Exists(association => association.BusinessCategory.Id == selectedBusinessCategory.Id))
                {
                    BusinessCategoryFLOCAssociation newAssociation =
                        new BusinessCategoryFLOCAssociation(
                            functionalLocation, selectedBusinessCategory, ClientSession.GetUserContext().User, Clock.Now);
                                        
                    masterAssociationList.Add(newAssociation);                    
                }       
            }

            view.AssociationList = masterAssociationList;
        }

        public void RemoveAssociationButton_Clicked(object sender, EventArgs e)
        {
            List<BusinessCategoryFLOCAssociation> selectedAssociations = view.SelectedAssociations;

            if (selectedAssociations == null || selectedAssociations.Count == 0)
            {
                return;
            }

            masterAssociationList.RemoveAll(
                obj => selectedAssociations.Exists(
                    selectedObj => obj.BusinessCategory.Id == selectedObj.BusinessCategory.Id));
            
            view.AssociationList = masterAssociationList;

            if (masterAssociationList.Count > 0)
            {
                view.SelectedAssociation = masterAssociationList[0];
            }
        }

        public void Save()
        {           
            associationService.RecreateFLOCAssociations(
                    masterAssociationList, functionalLocation, ClientSession.GetUserContext().User, Clock.Now);
        }

        public void SaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            Save();
            view.Close();
        }

        public void CancelButton_Clicked(object sender, EventArgs e)
        {
            view.Close();
        }       
    }
}


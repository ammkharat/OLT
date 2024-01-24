using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class BusinessCategoryFLOCAssociationPresenter
    {
        private readonly IBusinessCategoryFLOCAssociationView view;

        private readonly IFunctionalLocationInfoService functionalLocationInfoService;
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly IBusinessCategoryFLOCAssociationService associationService;

        private readonly Dictionary<long, List<BusinessCategoryFLOCAssociation>> masterDictionary = 
                new Dictionary<long, List<BusinessCategoryFLOCAssociation>>();

        private List<BusinessCategory> masterBusinessCategoryList;

        public BusinessCategoryFLOCAssociationPresenter(IBusinessCategoryFLOCAssociationView view)
        {
            this.view = view;

            functionalLocationInfoService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>();
            businessCategoryService = ClientServiceRegistry.Instance.GetService<IBusinessCategoryService>();
            associationService = ClientServiceRegistry.Instance.GetService<IBusinessCategoryFLOCAssociationService>();           
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Associate Business Categories to FLOCs, Site Id: {0}", site.Id);
        }

        public void Load(object sender, EventArgs e)
        {
            List<FunctionalLocationInfo> divisions = functionalLocationInfoService.QueryDivisionsBySiteId(ClientSession.GetUserContext().SiteId);
            List<FunctionalLocation> divisionLevelFLOCs = divisions.ConvertAll(obj => obj.Floc);
            masterBusinessCategoryList = businessCategoryService.QueryAllBySite(ClientSession.GetUserContext().SiteId);
            view.DivisionLevelFunctionalLocations = divisionLevelFLOCs;
            view.SelectFirstFunctionalLocation();
        }

        public void FunctionalLocationGrid_SelectedItemChanged(object sender, DomainEventArgs<FunctionalLocation> e)
        {
            FunctionalLocation selectedFunctionalLocation = view.SelectedFunctionalLocation;            

            long flocId = selectedFunctionalLocation.Id.Value;
          
            if(!masterDictionary.ContainsKey(flocId))
            {
                List<BusinessCategoryFLOCAssociation> categoriesForFloc = associationService.QueryByFLOCId(selectedFunctionalLocation.Id.Value);
                masterDictionary.Add(flocId, categoriesForFloc);
            }

            view.Associations = masterDictionary[flocId];
            view.SelectFirstBusinessCategoryRow();
        }

        private List<BusinessCategoryFLOCAssociation> AssociationsForSelectedFLOC
        {
            get
            {
                FunctionalLocation selectedFunctionalLocation = view.SelectedFunctionalLocation;
                long flocId = selectedFunctionalLocation.Id.Value;

                if (masterDictionary.ContainsKey(flocId))
                {
                    return masterDictionary[flocId];
                }

                return new List<BusinessCategoryFLOCAssociation>();
            }
        }
        
        public void EditAssociationsButton_Clicked(object sender, EventArgs e)
        {
            view.ShowEditBusinessCategoryFLOCAssociationsPopupForm(
                view.SelectedFunctionalLocation, masterBusinessCategoryList);
        }

        public void CancelButton_Clicked(object sender, EventArgs e)
        {
            view.Close();
        }

        public List<BusinessCategoryFLOCAssociation> PopupForm_Closed(FunctionalLocation floc)
        {
            List<BusinessCategoryFLOCAssociation> associations = associationService.QueryByFLOCId(floc.Id.Value);

            masterDictionary[floc.Id.Value].Clear();
            masterDictionary[floc.Id.Value].AddRange(associations);

            return associations;
        }
    }
}
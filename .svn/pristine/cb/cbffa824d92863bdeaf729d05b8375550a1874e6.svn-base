using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RestrictionLocationItemReasonCodePresenter
    {
        private readonly IRestrictionLocationItemReasonCodeForm view;
        private readonly List<RestrictionLocationItemReasonCodeAssociation> associationList;

        private readonly List<RestrictionReasonCode> masterRestrictionReasonCodesList;

        public RestrictionLocationItemReasonCodePresenter(
            IRestrictionLocationItemReasonCodeForm view,
            RestrictionLocationItem restrictionLocationItem,
            List<RestrictionReasonCode> allRestrictionReasonCodes)
        {
            this.view = view;
            
            masterRestrictionReasonCodesList = allRestrictionReasonCodes;
            associationList = new List<RestrictionLocationItemReasonCodeAssociation>(restrictionLocationItem.ReasonCodes);
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void RefreshLists()
        {
            view.ReasonCodeList = CreateListOfReasonCodesNotIncludingAssociatedOnes();
            view.AssociationList = associationList;
        }

        private List<RestrictionReasonCode> CreateListOfReasonCodesNotIncludingAssociatedOnes()
        {
            List<RestrictionReasonCode> availableReasonCodes = new List<RestrictionReasonCode>(masterRestrictionReasonCodesList);

            // Remove from the 'all' list, the ones that are already associated to the RestrictionLocationItem
            foreach (RestrictionLocationItemReasonCodeAssociation assoc in associationList)
            {
                int indexOf = availableReasonCodes.FindIndex(rc => rc.IdValue == assoc.RestrictionReasonCodeId);
                if (indexOf != -1)
                {
                    availableReasonCodes.RemoveAt(indexOf);
                }
            }

            return availableReasonCodes;
            
        }

        public void AddAssociationButton_Clicked(object sender, EventArgs e)
        {
            List<RestrictionReasonCode> selectedReasonCodes = view.SelectedRestrictionReasonCodes;

            if (selectedReasonCodes == null || selectedReasonCodes.Count == 0)
            {
                return;
            }

            foreach (RestrictionReasonCode selectedReasonCode in selectedReasonCodes)
            {
                if (!associationList.Exists(association => association.RestrictionReasonCodeId == selectedReasonCode.Id))
                {
                    RestrictionLocationItemReasonCodeAssociation newAssociation =
                        new RestrictionLocationItemReasonCodeAssociation(selectedReasonCode, null);

                    associationList.Add(newAssociation);
                }
            }

            RefreshLists();
        }

        public void RemoveAssociationButton_Clicked(object sender, EventArgs e)
        {
            List<RestrictionLocationItemReasonCodeAssociation> selectedAssociations = view.SelectedAssociations;

            if (selectedAssociations == null || selectedAssociations.Count == 0)
            {
                return;
            }

            associationList.RemoveAll(
                obj => selectedAssociations.Exists(
                    selectedObj => obj.RestrictionReasonCodeId == selectedObj.RestrictionReasonCodeId));

            RefreshLists();

            if (associationList.Count > 0)
            {
                view.SelectedAssociation = associationList[0];
            }
        }

        public void EditLimitButton_Clicked(object sender, EventArgs e)
        {
            List<RestrictionLocationItemReasonCodeAssociation> selectedAssociations = view.SelectedAssociations;

            if (selectedAssociations.Count == 0)
            {
                view.ShowNoAssociationsSelectedMessageBox();
                return;
            }

            view.DisplayEditLimitsForm(selectedAssociations);
            view.AssociationList = associationList;
        }
    }
}
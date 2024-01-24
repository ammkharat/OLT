using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditRestrictionReasonCodesPresenter
    {
        private readonly IEditRestrictionReasonCodesView view;
        private readonly IRestrictionReasonCodeService restrictionReasonCodeService;



        private List<RestrictionReasonCode> masterList;        
        private readonly List<RestrictionReasonCode> updateList = new List<RestrictionReasonCode>();
        private readonly List<RestrictionReasonCode> deleteList = new List<RestrictionReasonCode>();

        // - adds - add the master list
        // - edits - if old, add them to update list, modify master list. 
        // - edits - if unsaved, modify master list
        // - deletes - if new objects, do nothing but remove them from master list.
        // - deletes - if old objects, add the delete list, remove them from master list

        public EditRestrictionReasonCodesPresenter(IEditRestrictionReasonCodesView view)
        {
            this.view = view;
            restrictionReasonCodeService = ClientServiceRegistry.Instance.GetService<IRestrictionReasonCodeService>();
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            var siteid = ClientSession.GetUserContext().SiteId;          //ayman restriction reason codes
            List<RestrictionReasonCode> restrictionReasonCodes = restrictionReasonCodeService.QueryAll(siteid);
            masterList = new List<RestrictionReasonCode>(restrictionReasonCodes);

            view.Items = restrictionReasonCodes;
        }

        public static string CreateLockIdentifier()
        {
            return "Associate Restriction Reason Codes";
        }

        public void HandleAddButtonClicked(object sender, EventArgs e)
        {
            AddEditRestrictionReasonCodeForm form = new AddEditRestrictionReasonCodeForm(null, masterList);
            
            RestrictionReasonCode returnedReasonCode = form.ShowDialogAndReturnRestrictionReasonCode((Form) view);

            if (returnedReasonCode != null)
            {
                masterList.Add(returnedReasonCode);               
                view.Items = masterList;
                view.SelectReasonCode(returnedReasonCode);
            }
        }

        public void HandleEditButtonClicked(object sender, EventArgs e)
        {
            RestrictionReasonCode reasonCode = view.SelectedReasonCode;

            if (reasonCode == null)
            {
                OltMessageBox.ShowError(StringResources.EditRestrictionReasonCodes_NoReasonCodeSelectedMessageBoxText);
                return;
            }

            AddEditRestrictionReasonCodeForm form = new AddEditRestrictionReasonCodeForm(reasonCode, masterList);
            
            RestrictionReasonCode returnedReasonCode = form.ShowDialogAndReturnRestrictionReasonCode((Form)view);

            if (returnedReasonCode != null)
            {
                if(!updateList.Exists(code => code == returnedReasonCode) && returnedReasonCode.IsInDatabase())
                {
                    updateList.Add(returnedReasonCode);
                }

                view.RebindGrid();
                view.Items = masterList;
                view.SelectReasonCode(returnedReasonCode);
            }
        }

        public void HandleDeleteButtonClicked(object sender, EventArgs e)
        {
            RestrictionReasonCode restrictionReasonCode = view.SelectedReasonCode;

            if (restrictionReasonCode == null)
            {
                OltMessageBox.ShowError(StringResources.ReasonCode_Please_Select_To_Delete, StringResources.ReasonCode_Please_Select_To_Delete_Title);
                return;
            }

            DialogResult dialogResult = 
                OltMessageBox.ShowCustomYesNo(
                StringResources.EditRestrictionReasonCodes_AreYouSureDeleteMessageBoxText,
                StringResources.EditRestrictionReasonCodes_AreYouSureDeleteMessageBoxCaption);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (restrictionReasonCode.IsInDatabase())
            {
                deleteList.Add(restrictionReasonCode);
            }

            masterList.Remove(restrictionReasonCode);

            view.Items = masterList;
        }

        public void HandleSaveButtonClicked(object sender, EventArgs e)
        {
            List<RestrictionReasonCode> addList = masterList.FindAll(code => !code.IsInDatabase());           

            User lastModifiedUser = ClientSession.GetUserContext().User;
            DateTime lastModifiedDateTime = Clock.Now;

            long SiteId = ClientSession.GetUserContext().SiteId;   // ayman restriction reason codes

            restrictionReasonCodeService.DeleteReasonCodeList(deleteList, lastModifiedUser, lastModifiedDateTime, SiteId);   //ayman restriction reason codes
            restrictionReasonCodeService.UpdateReasonCodeList(updateList, lastModifiedUser, lastModifiedDateTime, SiteId); //ayman restriction reason codes
            restrictionReasonCodeService.AddReasonCodeList(addList, lastModifiedUser, lastModifiedDateTime, SiteId); //ayman restriction reason codes
                      
            view.Close();
        }

        public void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class BusinessCategoryPresenter
    {
        private readonly IBusinessCategoryView view;
        private readonly IBusinessCategoryService businessCategoryService;

        private List<BusinessCategory> masterList;
        private readonly List<BusinessCategory> updateList = new List<BusinessCategory>();
        private readonly List<BusinessCategory> deleteList = new List<BusinessCategory>();

        public BusinessCategoryPresenter(IBusinessCategoryView view)
        {
            this.view = view;
            businessCategoryService = ClientServiceRegistry.Instance.GetService<IBusinessCategoryService>();
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            List<BusinessCategory> businessCategories = businessCategoryService.QueryAllBySite(ClientSession.GetUserContext().SiteId);
            masterList = new List<BusinessCategory>(businessCategories);

            view.Items = businessCategories;
        }

        public void HandleAddButtonClicked(object sender, EventArgs e)
        {
            AddEditBusinessCategoryForm form = new AddEditBusinessCategoryForm(null, masterList);

            BusinessCategory returnedBusinessCategory = form.ShowDialogAndReturnBusinessCategory((Form)view);

            if (returnedBusinessCategory != null)
            {
                masterList.Add(returnedBusinessCategory);
                view.Items = masterList;
                view.SelectBusinessCategory(returnedBusinessCategory);
            }
        }

        public void HandleEditButtonClicked(object sender, EventArgs e)
        {
            BusinessCategory selectedBusinessCategory = view.SelectedBusinessCategory;

            if (selectedBusinessCategory == null)
            {
                OltMessageBox.Show(StringResources.NoBusinessCategorySelectedMessageBoxText);
                return;
            }

            AddEditBusinessCategoryForm form = new AddEditBusinessCategoryForm(selectedBusinessCategory, masterList);
            BusinessCategory businessCategory = form.ShowDialogAndReturnBusinessCategory((Form)view);

            if (businessCategory != null)
            {
                if (!updateList.Exists(obj => obj == businessCategory) && businessCategory.IsInDatabase())
                {
                    updateList.Add(businessCategory);
                }

                view.RebindGrid();
                view.Items = masterList;
                view.SelectBusinessCategory(businessCategory);
            }
        }

        public void HandleDeleteButtonClicked(object sender, EventArgs e)
        {
            BusinessCategory businessCategory = view.SelectedBusinessCategory;

            if (businessCategory == null)
            {
                OltMessageBox.ShowError(StringResources.NoBusinessCategorySelectedForDeletionMessageBoxText, 
                    StringResources.NoBusinessCategorySelectedForDeletionMessageBoxCaption);
                return;
            }

            DialogResult dialogResult =
                OltMessageBox.ShowCustomYesNo(StringResources.AreYouSureYouWantToDeleteBusinessCategoryMessageBoxText, StringResources.AreYouSureYouWantToDeleteBusinessCategoryMessageBoxCaption);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (businessCategory.IsInDatabase())
            {
                deleteList.Add(businessCategory);
            }

            masterList.Remove(businessCategory);

            view.Items = masterList;
        }

        public void HandleSaveButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            List<BusinessCategory> addList = masterList.FindAll(obj => !obj.IsInDatabase());

            User lastModifiedUser = ClientSession.GetUserContext().User;
            DateTime lastModifiedDateTime = Clock.Now;

            businessCategoryService.Save(addList, updateList, deleteList, lastModifiedUser, lastModifiedDateTime);

            view.Close();

        }

        private bool DataIsValid()
        {
            view.ClearErrors();

            int sapWorkOrderCategoryCount = 0;
            int sapNotificationCategoryCount = 0;

            foreach (BusinessCategory businessCategory in masterList)
            {
                sapWorkOrderCategoryCount = businessCategory.IsDefaultSAPWorkOrderCategory ? sapWorkOrderCategoryCount + 1 : sapWorkOrderCategoryCount;
                sapNotificationCategoryCount = businessCategory.IsDefaultSAPNotificationCategory ? sapNotificationCategoryCount + 1 : sapNotificationCategoryCount;
            }

            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            isValid &= AppendMissingDefaultErrorMessageIfNeededAndReturnTrueIfValid(
                errorMessage, sapWorkOrderCategoryCount, StringResources.BusinessCategoryErrorMessageSuffix_SAPWorkOrders);
            isValid &= AppendMissingDefaultErrorMessageIfNeededAndReturnTrueIfValid(
                errorMessage, sapNotificationCategoryCount, StringResources.BusinessCategoryErrorMessageSuffix_SAPNotifications);

            if (!isValid)
            {
                string errorString = errorMessage.ToString().Trim();
                view.SetGridDataError(errorString);
            }

            return isValid;
        }

        private static bool AppendMissingDefaultErrorMessageIfNeededAndReturnTrueIfValid(StringBuilder errorMessage, int count, string businessProcess)
        {
            if (count != 1)
            {
                string message = string.Format(StringResources.BusinessCategory_MustBeExactlyOneForBusinessProcess, businessProcess);
                errorMessage.AppendLine(message);
                return false;
            }

            return true;
        }

        public void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            view.Close();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Add/Edit Business Categories: Site {0}", site.IdValue);
        }
    }
}
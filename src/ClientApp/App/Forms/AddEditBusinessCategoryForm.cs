using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditBusinessCategoryForm : BaseForm
    {
        private readonly bool isAddMode;
        private bool cancelClicked;
        private BusinessCategory businessCategory;        
        private readonly List<BusinessCategory> masterList;
        
        public AddEditBusinessCategoryForm(
            BusinessCategory businessCategory,             
            List<BusinessCategory> masterList)
        {
            InitializeComponent();

            this.businessCategory = businessCategory;            
            this.masterList = masterList;

            isAddMode = businessCategory == null;
            SetUpControlsForAddOrEditMode();

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            string name = NameFromTextBox;
            string shortName = ShortNameFromTextBox;

            bool isDefaultSAPWorkOrderCategory = defaultSAPWorkOrderCheckBox.Checked;
            bool isDefaultSAPNotificationCategory = defaultSAPNotificationCheckBox.Checked;

            if (isAddMode)
            {
                businessCategory = new BusinessCategory(
                        name, shortName, 
                        isDefaultSAPWorkOrderCategory, isDefaultSAPNotificationCategory, 
                        ClientSession.GetUserContext().User, Clock.Now, Clock.Now,
                        ClientSession.GetUserContext().SiteId);
            }
            else
            {
                businessCategory.Name = name;
                businessCategory.ShortName = shortName;

                businessCategory.IsDefaultSAPWorkOrderCategory = isDefaultSAPWorkOrderCategory;
                businessCategory.IsDefaultSAPNotificationCategory = isDefaultSAPNotificationCategory;
            }

            Close();
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            Close();
        }

        private string NameFromTextBox
        {
            get { return nameTextBox.Text.TrimOrNull(); }        
        }

        private string ShortNameFromTextBox
        {
            get { return shortNameTextBox.Text.TrimOrNull(); }
        }

        private bool DataIsValid()
        {
            errorProvider.Clear();

            bool hasError = false;

            if (NameFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(nameTextBox, StringResources.InvalidBusinessCategoryNameError);
                hasError = true;
            }

            if (ShortNameFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(shortNameTextBox, StringResources.InvalidBusinessCategoryShortNameError);
                hasError = true;
            }

            if (hasError)
            {
                return false;
            }

            if (masterList.Exists(obj => obj != businessCategory && NameFromTextBox.Equals(obj.Name)))
            {
                errorProvider.SetError(nameTextBox, StringResources.BusinessCategoryWithNameAlreadyExistsError);
                hasError = true;
            }

            if (masterList.Exists(obj => obj != businessCategory && ShortNameFromTextBox.Equals(obj.ShortName)))
            {
                errorProvider.SetError(shortNameTextBox, StringResources.BusinessCategoryWithShortNameAlreadyExistsError);
                hasError = true;
            }

            return !hasError;
        }

        private void SetUpControlsForAddOrEditMode()
        {
            submitButton.Text = isAddMode ? StringResources.AddButtonLabelNoAmpersand : StringResources.OKButtonLabel;
            Text = isAddMode ? StringResources.AddBusinessCategory : StringResources.EditBusinessCategory;

            if (!isAddMode)
            {
                nameTextBox.Text = businessCategory.Name;
                shortNameTextBox.Text = businessCategory.ShortName;

                defaultSAPWorkOrderCheckBox.Checked = businessCategory.IsDefaultSAPWorkOrderCategory;
                defaultSAPNotificationCheckBox.Checked = businessCategory.IsDefaultSAPNotificationCategory;
            }
        }
       
        public BusinessCategory ShowDialogAndReturnBusinessCategory(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : businessCategory;
        }
    }
}
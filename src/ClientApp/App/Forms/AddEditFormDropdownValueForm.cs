using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditFormDropdownValueForm : BaseForm
    {
        private readonly FormDropdown dropdown;
        private readonly bool isAddMode;
        private readonly List<DropdownValue> masterList;
        private readonly string nameAlreadyExistsErrorMessage;
        private bool cancelClicked;
        private DropdownValue value;

        public AddEditFormDropdownValueForm(FormDropdown dropdown, DropdownValue value, List<DropdownValue> masterList,
            string nameAlreadyExistsErrorMessage)
        {
            InitializeComponent();

            this.dropdown = dropdown;
            this.value = value;
            this.masterList = masterList;
            this.nameAlreadyExistsErrorMessage = nameAlreadyExistsErrorMessage;

            isAddMode = value == null;
            SetUpControlsForAddOrEditMode();

            okButton.Click += HandleOkButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
        }

        private string ValueFromTextBox
        {
            get { return valueTextBox.Text.TrimOrNull(); }
        }

        private void HandleOkButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            var valueText = ValueFromTextBox;

            if (isAddMode)
            {
                value = new DropdownValue(dropdown.SiteId, dropdown.Key, valueText, 0);
            }
            else
            {
                value.Value = valueText;
            }

            Close();
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            Close();
        }

        private bool DataIsValid()
        {
            errorProvider.Clear();

            var hasError = false;

            if (ValueFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(valueTextBox, StringResources.EnterAValidValue);
                hasError = true;
            }

            if (hasError)
            {
                return false;
            }

            if (masterList.Exists(obj => obj != value && ValueFromTextBox.ToLower().Equals(obj.Name.ToLower())))
            {
                errorProvider.SetError(valueTextBox, nameAlreadyExistsErrorMessage);
                hasError = true;
            }

            return !hasError;
        }

        private void SetUpControlsForAddOrEditMode()
        {
            okButton.Text = isAddMode ? StringResources.AddButtonLabelNoAmpersand : StringResources.OKButtonLabel;
            Text = isAddMode
                ? StringResources.AddDropDownValue
                : StringResources.EditDropDownValue;

            if (!isAddMode)
            {
                valueTextBox.Text = value.Value;
            }
        }

        public DropdownValue ShowDialogAndReturnValue(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : value;
        }
    }
}
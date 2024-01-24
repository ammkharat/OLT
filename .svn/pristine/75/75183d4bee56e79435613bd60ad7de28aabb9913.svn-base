
using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditWorkPermitDropdownValueForm : BaseForm
    {
        private readonly bool isAddMode;
        private bool cancelClicked;
        private readonly WorkPermitDropdown dropdown;
        private DropdownValue value;

        public AddEditWorkPermitDropdownValueForm(WorkPermitDropdown dropdown, DropdownValue value)
        {
            InitializeComponent();

            this.dropdown = dropdown;
            this.value = value;
             
            isAddMode = value == null;
            SetUpControlsForAddOrEditMode();

            okButton.Click += HandleOkButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
        }

        private void HandleOkButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            string valueText = ValueFromTextBox;
           
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

        private string ValueFromTextBox
        {
            get { return valueTextBox.Text.TrimOrNull(); }
        }

        private bool DataIsValid()
        {
            errorProvider.Clear();

            bool hasError = false;

            if (ValueFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(valueTextBox, StringResources.EnterAValidValue);
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

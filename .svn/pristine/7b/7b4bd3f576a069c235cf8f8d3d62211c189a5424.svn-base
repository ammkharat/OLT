using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditCustomFieldDropDownValueForm : BaseForm
    {
        private readonly bool isAddMode;
        private CustomFieldDropDownValue value;
        private bool cancelClicked;

        public AddEditCustomFieldDropDownValueForm(CustomFieldDropDownValue value)
        {            
            InitializeComponent();

            this.value = value;

            isAddMode = value == null;
            SetUpControlsForAddOrEditMode();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            valueTextBox.Focus();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            string valueText = ValueFromTextBox;

            if (isAddMode)
            {
                value = new CustomFieldDropDownValue(null, valueText, 0);
            }
            else
            {
                value.Value = valueText;
            }

            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            cancelClicked = true;
            Close();
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

        public CustomFieldDropDownValue ShowDialogAndReturnValue(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : value;
        }
    }
}

using System.Windows.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditCokerCardConfigurationChildItemForm : BaseForm
    {
        private bool cancelClicked;

        public AddEditCokerCardConfigurationChildItemForm(string title, string itemName)
        {
            InitializeComponent();

            Text = title;
            nameTextBox.Text = itemName;
        }

        public string ShowDialogAndReturnName(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : nameTextBox.Text;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            errorProvider.Clear();

            if (nameTextBox.Text.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(nameTextBox, StringResources.FieldEmptyError);
                return;
            }

            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            cancelClicked = true;
        }
    }
}

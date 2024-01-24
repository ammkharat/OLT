using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public enum GridLayoutAction { Save, RestoreDefault, RevertToPreviouslySaved, Cancel }

    public partial class GridLayoutActionSelectionForm : BaseForm
    {
        private bool saveButtonWasClicked = false;

        public GridLayoutActionSelectionForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            saveButtonWasClicked = true;
            Close();
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {            
            Close();
        }

        public GridLayoutAction GetGridLayoutAction()
        {
            if (!saveButtonWasClicked)
            {
                return GridLayoutAction.Cancel;
            }

            if (saveLayoutRadioButton.Checked)
            {
                return GridLayoutAction.Save;
            }
            
            if (resetLayoutRadioButton.Checked)
            {
                return GridLayoutAction.RestoreDefault;
            }

            if (revertLayoutRadioButton.Checked)
            {
                return GridLayoutAction.RevertToPreviouslySaved;
            }
            
            throw new InvalidOperationException("Somehow a radio button was not selected. This is highly irregular and should not occur because Windows Forms won't allow it.");
        }
    }
}

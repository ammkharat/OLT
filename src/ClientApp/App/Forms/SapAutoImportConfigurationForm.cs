using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SapAutoImportConfigurationForm : BaseForm, ISapAutoImportConfigurationView
    {
        public event Action Save;

        public SapAutoImportConfigurationForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            enabledCheckBox.CheckedChanged += HandleEnabledCheckBoxChanged;
        }

        private void HandleEnabledCheckBoxChanged(object sender, EventArgs e)
        {
            timePicker.Enabled = enabledCheckBox.Checked;           
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (Save != null)
            {
                Save();
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        public bool IsEnabled
        {
            get { return enabledCheckBox.Checked; }
            set { enabledCheckBox.Checked = value; }
        }

        public Time ImportTime
        {
            get { return timePicker.Value; }
            set { timePicker.Value = value; }
        }

        public bool TimePickerEnabled
        {
            set { timePicker.Enabled = value; }
        }
    }
}

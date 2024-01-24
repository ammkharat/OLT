using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitPrintPreferencesForm : BaseForm, IWorkPermitPrintPreferencesFormView
    {        
        public event Action SaveButtonClicked;
        public event Action CancelButtonClicked;

        public WorkPermitPrintPreferencesForm()
        {
            InitializeComponent();

            saveButton.Click += (sender, args) => SaveButtonClicked();
            cancelButton.Click += (sender, args) => CancelButtonClicked();          
        }

        public void UpdatePreferences()
        {
            workPermitPrintPreferenceTabPage.UpdatePreference();
        }
    }
}

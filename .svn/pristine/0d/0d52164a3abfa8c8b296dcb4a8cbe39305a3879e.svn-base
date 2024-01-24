using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitDefaultTimesPreferenceTabPage : UserControl, IWorkPermitDefaultTimesPreferenceTabPage
    {
        private readonly WorkPermitDefaultTimesPreferenceTabPagePresenter presenter;
        
        public WorkPermitDefaultTimesPreferenceTabPage()
        {
            presenter = new WorkPermitDefaultTimesPreferenceTabPagePresenter(this);
            
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Load += presenter.Load;
        }

        public void UpdatePreference()
        {
            presenter.Update();
        }

        public bool IsTabValid
        {
            get { return presenter.Validate(); }
        }
        
        public TimeSpan PreShiftPadding
        {
            get { return preShiftPaddingPicker.Value.TimeOfDay; }
            set { preShiftPaddingPicker.Value = new Time(value); }
        }

        public TimeSpan PostShiftPadding
        {
            get { return postShiftPaddingPicker.Value.TimeOfDay; }
            set { postShiftPaddingPicker.Value = new Time(value); }
        }

        public void ClearValidationProviders()
        {
            errorProvider.Clear();
        }

        public void ShowPreShiftPaddingError(string errorMessage)
        {
            errorProvider.SetError(preShiftPaddingPicker, errorMessage);
        }

        public void ShowPostShiftPaddingError(string errorMessage)
        {
            errorProvider.SetError(postShiftPaddingPicker, errorMessage);
        }
    }
}
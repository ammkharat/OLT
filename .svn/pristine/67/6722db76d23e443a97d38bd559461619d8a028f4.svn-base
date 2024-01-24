using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureDORCutoffTimeForm : BaseForm, IConfigureDORCutoffTimeFormView
    {
        private ConfigureDORCutoffTimeFormPresenter presenter;

        public ConfigureDORCutoffTimeForm()
        {
            InitializeComponent();
            InitializePresenter();          
        }

        private void InitializePresenter()
        {
            presenter = new ConfigureDORCutoffTimeFormPresenter(this);
            Load += presenter.LoadForm;
            Closing += presenter.FormClosing;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
        }

        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public Time CutoffTime
        {
            get { return timePicker.Value; }
            set { timePicker.Value = value; }
        }

        public void CloseForm()
        {
            Close();
        }

        public void SetTimeLmitError(string errorMessage)
        {
            errorProvider.SetError(timePicker, errorMessage);
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }
    }
}
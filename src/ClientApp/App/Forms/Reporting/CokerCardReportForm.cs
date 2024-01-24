using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Presenters.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public partial class CokerCardReportForm : BaseForm, ICokerCardReportFormView
    {
        private CokerCardReportFormPresenter presenter;

        public CokerCardReportForm()
        {
            InitializeComponent();            
            InitializePresenter();

            cokerCardConfigurationComboBox.DisplayMember = CokerCardConfiguration.DISPLAY_MEMBER;
        }

        private void InitializePresenter()
        {
            presenter = new CokerCardReportFormPresenter(this);
            Load += presenter.Form_Load;
            runReportButton.Click += presenter.RunReportButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;
        }      

        public void CloseForm()
        {
            Close();
        }

        public Date StartDate
        {
            get { return startRangeDatePicker.Value; }
            set { startRangeDatePicker.Value = value; }
        }

        public Date EndDate
        {
            get { return endRangeDatePicker.Value; }
            set { endRangeDatePicker.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string SelectedCokerCardConfiguration
        {
            get { return (string) cokerCardConfigurationComboBox.SelectedItem; }
        }

        public List<string> CokerCardConfigurations
        {
            set { cokerCardConfigurationComboBox.DataSource = value; }
        }

        public void ClearErrors()
        {
            startDateErrorProvider.Clear();
        }

        public void SetErrorForStartDate(string errorMessage)
        {
            startDateErrorProvider.SetError(startRangeDatePicker, errorMessage);
        }

        public void SetErrorForEndDate(string errorMessage)
        {
            endDateErrorProvider.SetError(endRangeDatePicker, errorMessage);
        }       
    }
}
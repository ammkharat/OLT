using System;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Excel;
using Com.Suncor.Olt.Client.Forms.Reporting;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class CokerCardReportFormPresenter
    {
        private readonly ICokerCardReportFormView view;
        private readonly ICokerCardService cokerCardService;
        private readonly IStreamingCokerCardService streamingCokerCardService;
        

        public CokerCardReportFormPresenter(ICokerCardReportFormView view)
        {
            this.view = view;
            cokerCardService = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
            streamingCokerCardService = ClientServiceRegistry.Instance.GetService<IStreamingCokerCardService>();
        }

        public void Form_Load(object sender, EventArgs e)
        {
            DateTime now = Clock.Now.TruncateToDay();

            view.StartDate = now.ToDate();
            view.EndDate = now.ToDate();

            view.CokerCardConfigurations = cokerCardService.QueryCokerCardConfigurationNameBySite(ClientSession.GetUserContext().Site);
        }

        public void RunReportButton_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string selectedCokerCardConfiguration = view.SelectedCokerCardConfiguration;              

                if (selectedCokerCardConfiguration == null)
                {
                    OltMessageBox.Show(StringResources.NoConfiguredCokerCardsError);
                    return;
                }

                Stream stream = streamingCokerCardService.QueryCycleStepDTOsByConfigurationIdsAndDateRange(
                    selectedCokerCardConfiguration, view.StartDate, view.EndDate);
              
                using (stream)
                {
                    ExcelExporter excelExporter = new ExcelExporter();
                    excelExporter.Export(stream);
                }

                view.CloseForm();
            }
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        private bool Validate()
        {
            view.ClearErrors();

            bool isValid = true;

            if (view.StartDate > view.EndDate)
            {                
                view.SetErrorForStartDate(StringResources.FromDateBeforeToDate);                
                view.SetErrorForEndDate(StringResources.FromDateBeforeToDate);
                isValid = false;
            }
           
            return isValid;
        }

    }
}
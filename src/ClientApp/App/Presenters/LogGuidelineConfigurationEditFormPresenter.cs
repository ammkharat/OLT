using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogGuidelineConfigurationEditFormPresenter : BaseFormPresenter<ILogGuidelineConfigurationEditView>
    {
        private readonly ILogService logService;
        private readonly FunctionalLocation functionalLocation;

        public LogGuidelineConfigurationEditFormPresenter(FunctionalLocation functionalLocation)
            : base(new LogGuidelineConfigurationEditForm())
        {            
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();

            this.functionalLocation = functionalLocation;

            SubscribeToEvents();
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            LogGuideline guideline = logService.QueryLogGuidelineByDivision(functionalLocation);

            if (guideline != null)
            {
                view.GuidelineText = guideline.Text;
            }            
        }

        private void SubscribeToEvents()
        {
            view.Load += HandleLoad;
            view.CancelButtonClicked += CancelButton_Click;
            view.SaveAndCloseButtonClicked += HandleSaveAndCloseButtonClicked;
        }

        private void HandleSaveAndCloseButtonClicked(object sender, EventArgs e)
        {           
            logService.SaveLogGuideline(view.GuidelineText, functionalLocation);
            view.Close();                       
        }
    }
}

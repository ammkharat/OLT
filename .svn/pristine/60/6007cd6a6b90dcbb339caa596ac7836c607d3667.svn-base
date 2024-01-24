using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SelectHazardPresenter : BaseFormPresenter<ISelectHazardView>
    {
        private readonly IFlocSet flocSet;
        private readonly IWorkPermitEdmontonService service;
        private readonly ISiteConfigurationService siteConfigurationService;

        public SelectHazardPresenter(IFlocSet flocSet) : base(new SelectHazardForm())
        {
            this.flocSet = flocSet;
            service = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            view.FormLoad += HandleLoad;
            view.AddHazardButtonClick += HandleAddHazardButtonClick;
            view.SelectedItemChange += HandleSelectedItemChange;
        }

        private void HandleSelectedItemChange()
        {
            view.AddHazardButtonEnabled = view.SelectedItem != null;
        }

        private void HandleLoad()
        {
            view.AddHazardButtonEnabled = false;

            List<WorkPermitLoggableStatus> loggableStatuses = siteConfigurationService.QueryWorkPermitStatusesForClosingBySite(ClientSession.GetUserContext().SiteId);
            List<PermitRequestBasedWorkPermitStatus> completionStatuses = loggableStatuses.ConvertAll(loggableStatus => loggableStatus.Status);
            completionStatuses.Add(PermitRequestBasedWorkPermitStatus.Issued);

            view.HazardDtos = service.QueryByFlocsAndStatuses(flocSet, completionStatuses);
            view.SelectFirstRow();
        }

        private void HandleAddHazardButtonClick(WorkPermitEdmontonHazardDTO selectedDto)
        {
            view.DialogResult = DialogResult.OK;
        }

        public DialogResultAndOutput<string> RunWithDialogResultAndOutput(IWorkPermitEdmontonView parent)
        {
            DialogResult dialogResult = view.ShowDialog(parent);
            DialogResultAndOutput<string> dialogResultAndOutput = null;

            if (dialogResult == DialogResult.Cancel)
            {
                dialogResultAndOutput = new DialogResultAndOutput<string>(dialogResult, null);
            }
            else
            {
                dialogResultAndOutput = new DialogResultAndOutput<string>(dialogResult, view.SelectedItem.Hazards);
            }

            view.Dispose();
            return dialogResultAndOutput;
        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageWorkPermitLubesDetailsPresenter : WorkPermitLubesPagePresenter
    {
        private readonly IGridAndDetailsView view;

        private readonly IWorkPermitLubesService workPermitService;
        private WorkPermitLubes workPermit;

        public PriorityPageWorkPermitLubesDetailsPresenter(long id) 
        {
            view = new GridAndDetailsForm();
            view.Title = StringResources.DomainObjectName_WorkPermit;
            view.Details = page.Details;

            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>();
            workPermit = workPermitService.QueryById(id);

            page.Details.MakeAllButtonsInvisible();
            page.Details.EditButtonVisible = true;
            page.Details.CloseButtonVisible = true;
        }

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitLubesUpdated += Repeater_ServerWorkPermitLubesUpdated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitLubesUpdated -= Repeater_ServerWorkPermitLubesUpdated;
        }

        private void Repeater_ServerWorkPermitLubesUpdated(object sender, DomainEventArgs<WorkPermitLubes> e)
        {
            if (e.SelectedItem != null && e.SelectedItem.IdValue == workPermit.IdValue)
            {
                workPermit = e.SelectedItem;
                repeater_Updated(sender, e);                
            }
        }

        protected override WorkPermitLubes QueryByDto(WorkPermitLubesDTO dto)
        {
            return workPermit;
        }

        protected override IList<WorkPermitLubesDTO> GetDtos(Range<Date> dateRange)
        {
            return new List<WorkPermitLubesDTO> { new WorkPermitLubesDTO(workPermit) };            
        }

        protected override void Close(List<WorkPermitLubes> permits)
        {
            base.Close(permits);
            view.Close();
        }
    }
}

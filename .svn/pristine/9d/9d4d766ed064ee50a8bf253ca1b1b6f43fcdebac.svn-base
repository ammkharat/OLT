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
    public class PriorityPageWorkPermitMontrealDetailsPresenter : WorkPermitMontrealPagePresenter
    {
        private readonly IGridAndDetailsView view;

        private readonly IWorkPermitMontrealService workPermitService;
        private WorkPermitMontreal workPermit;

        public PriorityPageWorkPermitMontrealDetailsPresenter(long id) 
        {
            view = new GridAndDetailsForm();
            view.Title = StringResources.DomainObjectName_WorkPermit;
            view.Details = page.Details;

            page.Details.MakeAllButtonsInvisible();
            page.Details.CloseVisible = true;

            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();
            workPermit = workPermitService.QueryById(id);
        }

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.ShowDialog(parent);
            //view.Remove(page.Details);
            view.Dispose();
            page.Dispose();
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitMontrealUpdated += Repeater_ServerWorkPermitMontrealUpdated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitMontrealUpdated -= Repeater_ServerWorkPermitMontrealUpdated;
        }

        private void Repeater_ServerWorkPermitMontrealUpdated(object sender, DomainEventArgs<WorkPermitMontreal> e)
        {
            if (e.SelectedItem != null && e.SelectedItem.IdValue == workPermit.IdValue)
            {
                workPermit = e.SelectedItem;
                repeater_Updated(sender, e);                
            }
        }

        protected override WorkPermitMontreal QueryByDto(WorkPermitMontrealDTO dto)
        {
            return workPermit;
        }

        protected override IList<WorkPermitMontrealDTO> GetDtos(Range<Date> dateRange)
        {
            return new List<WorkPermitMontrealDTO>{new WorkPermitMontrealDTO(workPermit)};
            
        }

        protected override void CloseWorkPermit(object sender, System.EventArgs e)
        {
            base.CloseWorkPermit(sender, e);
            view.Close();
        }

          //Mukesh for Permit search Demand
        public PriorityPageWorkPermitMontrealDetailsPresenter(long id, bool isSearch)
        {
            view = new GridAndDetailsForm();
            view.Title = StringResources.DomainObjectName_WorkPermit;
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();
            workPermit = workPermitService.QueryById(id);

            SearchPermitdata data = new SearchPermitdata(workPermit.WorkPermitStatus.Name, workPermit.CreatedBy.Username, workPermit.WorkPermitType.Name, workPermit.PermitNumber.ToString(), "Work Permit");
            Com.Suncor.Olt.Client.Controls.Details.SearchWorkpermit Attach = new Com.Suncor.Olt.Client.Controls.Details.SearchWorkpermit(data);
            view = new GridAndDetailsForm();

           // view.Details = page.Details;

            page.Details.MakeSeachWindowRequiredButtonsvisibleonly();
            page.Details.CloseVisible = true;

          

            Attach.Dock = DockStyle.Fill;
            TableLayoutPanel tbl = new TableLayoutPanel();
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add(Attach);
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add((Control)page.Details);
            view.GridAndDetails = (Control)tbl;
            (view as Control).Text = StringResources.SearchPermitFormCaption;
        }
    }
}

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
    public class PriorityPageWorkPermitEdmontonDetailsPresenter : WorkPermitEdmontonPagePresenter
    {
        private readonly IGridAndDetailsView view;

        private readonly IWorkPermitEdmontonService workPermitService;
        private WorkPermitEdmonton workPermit;

        public PriorityPageWorkPermitEdmontonDetailsPresenter(long id) 
        {
            view = new GridAndDetailsForm();
            view.Title = StringResources.DomainObjectName_WorkPermit;
            view.Details = page.Details;


            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            workPermit = workPermitService.QueryById(id);

            page.Details.MakeAllButtonsInvisible();
            page.Details.EditButtonVisible = true;
            page.Details.CloseButtonVisible = true;
        }


        //Mukesh for Permit search Demand
        public PriorityPageWorkPermitEdmontonDetailsPresenter(long id,bool isSearch)
        {
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            workPermit = workPermitService.QueryById(id);
            SearchPermitdata data = new SearchPermitdata(workPermit.WorkPermitStatus.Name, workPermit.CreatedBy.Username, workPermit.WorkPermitType.Name, workPermit.PermitNumber.ToString(), "Work Permit");
            Com.Suncor.Olt.Client.Controls.Details.SearchWorkpermit Attach = new Com.Suncor.Olt.Client.Controls.Details.SearchWorkpermit(data);
            view = new GridAndDetailsForm();
            page.Details.MakeSeachWindowRequiredButtonsvisibleonly();
            Attach.Dock = DockStyle.Fill;
            TableLayoutPanel tbl = new TableLayoutPanel();
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add(Attach);
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl.Controls.Add((Control)page.Details);
            view.GridAndDetails = (Control)tbl;
            view.Title = StringResources.DomainObjectName_WorkPermit;
            (view as Control).Text = StringResources.SearchPermitFormCaption;
            //view.Details = page.Details;

             
             
            

        }
        //End Mukesh for Permit search Demand

        public void Run(IWin32Window parent)
        {
            DoInitialDataLoad();
            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitEdmontonUpdated += Repeater_ServerWorkPermitEdmontonUpdated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitEdmontonUpdated -= Repeater_ServerWorkPermitEdmontonUpdated;
        }

        private void Repeater_ServerWorkPermitEdmontonUpdated(object sender, DomainEventArgs<WorkPermitEdmonton> e)
        {
            if (e.SelectedItem != null && e.SelectedItem.IdValue == workPermit.IdValue)
            {
                workPermit = e.SelectedItem;
                repeater_Updated(sender, e);                
            }
        }

        protected override bool ShouldBeDisplayed(WorkPermitEdmonton item)
        {
            return true;
        }

        protected override WorkPermitEdmonton QueryByDto(WorkPermitEdmontonDTO dto)
        {
            return workPermit;
        }

        protected override IList<WorkPermitEdmontonDTO> GetDtos(Range<Date> dateRange)
        {
            return new List<WorkPermitEdmontonDTO> { new WorkPermitEdmontonDTO(workPermit) };            
        }
    }
}

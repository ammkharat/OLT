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
using Com.Suncor.Olt.Client.Controls.Details;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
   

    public class SearchSarniaWorkpemitPresenter : WorkPermitPagePresenter
    {
        private readonly IGridAndDetailsView view;

        private readonly IWorkPermitService workPermitService;
        private WorkPermit workPermit;

       


        //Mukesh for Permit search Demand
        public SearchSarniaWorkpemitPresenter(long id, bool isSearch)
        {
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitService>();
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
            DoInitialDataLoad();
            //page.SelectSingleItemById(workPermit.Id);
          //  SetDetailData(page.Details, workPermit);
           
                             
             
            

        }
        public Control GetCOntrolForSign()
        {
            page.Details.MakeSeachWindowRequiredButtonsvisibleonly();
            return (Control)page.Details;
        }

        protected override WorkPermitDTO CreateDTOFromDomainObject(WorkPermit domainObject)
        {
            return new WorkPermitDTO(domainObject);
        }

       

        protected override IList<WorkPermitDTO> GetDtos(Range<Date> dateRange)
        {
            return new List<WorkPermitDTO> { new WorkPermitDTO(workPermit) };   
        }
        //End Mukesh for Permit search Demand
     

        public void Run(IWin32Window parent)
        {
           // DoInitialDataLoad();
            view.ShowDialog(parent);
            view.Dispose();
            page.Dispose();
        }

       
       

       
    }
}

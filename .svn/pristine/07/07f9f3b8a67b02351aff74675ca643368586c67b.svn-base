using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;
using System.IO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;


namespace Com.Suncor.Olt.Client.Presenters
{
    class WorkPermitSarniaSignFormPresenter
    {
        IWorkPermitService workpermitService;
        private IConfinedSpaceMudsService confinedSpaceService;
        public string LenleConnectionstring="";
        public string LenleQuery="";
        IWorkPermitMudsService workPermitMudsService;
        public WorkPermitSarniaSignFormPresenter()
        {
            workpermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitService>();
            workPermitMudsService = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>();
            confinedSpaceService = ClientServiceRegistry.Instance.GetService<IConfinedSpaceMudsService>();
        }
        public void SaveSign(WorkPermitSign workPermitSign)
        {
            workPermitSign.SiteId = Convert.ToString(ClientSession.GetUserContext().SiteId);
            workPermitSign.CreatedBy = Convert.ToInt32(ClientSession.GetUserContext().User.Id);
            workPermitSign.UpdatedBy = Convert.ToInt32(ClientSession.GetUserContext().User.Id);
            workPermitSign.CreatedDate = Convert.ToString(Clock.Now);
            workPermitSign.UpdatedDate = Convert.ToString(Clock.Now);
            workpermitService.InserUpdateWorkPermitSign(workPermitSign);

        }
        public WorkPermitSign GetSign(string workpermitId)
        {

           return workpermitService.GetWorkPermitSign(workpermitId,Convert.ToInt32(ClientSession.GetUserContext().SiteId));

        }
        public BADGE GetBadgeInfo(string badgeNumber)
        {
            if (LenleConnectionstring == "" || LenleQuery=="")
            {
              LenleConnection objLnl=  workpermitService.GetWorkPermitSignLenelConnection();
              LenleConnectionstring = objLnl.Connectonstring;
              LenleQuery = objLnl.LenleQuery;
            }
            return workpermitService.GetBadgeInfo(badgeNumber, LenleConnectionstring, LenleQuery);

        }
        public List<GasTestElementResultDTO> LoadWorkItemGasTests(long workpermitId, out bool? IsCoauthorizationRequired, out Time ConfinedSpaceTestTime, out Time ImmediateAreaTestTime)
        {
            WorkPermit permit = workpermitService.QueryById(workpermitId);
            IsCoauthorizationRequired = permit.IsCoauthorizationRequired;
            ConfinedSpaceTestTime=permit.GasTests.ConfinedSpaceTestTime;
            ImmediateAreaTestTime=permit.GasTests.ImmediateAreaTestTime;
           return new GasTestElementResultDTOConverter().ConvertAll(permit);

        }

        //Functions for MUds sign

        public void SaveMudsSign(WorkPermitMudSign workPermitSign)
        {
            workPermitSign.SiteId = Convert.ToString(ClientSession.GetUserContext().SiteId);
            workPermitSign.CreatedBy = Convert.ToInt32(ClientSession.GetUserContext().User.Id);
            workPermitSign.UpdatedBy = Convert.ToInt32(ClientSession.GetUserContext().User.Id);
            workPermitSign.CreatedDate = Convert.ToString(Clock.Now);
            workPermitSign.UpdatedDate = Convert.ToString(Clock.Now);
            workPermitMudsService.InserUpdateWorkPermitSign(workPermitSign);

        }
        public WorkPermitMudSign GetMudSign(string workpermitId)
        {

            return workPermitMudsService.GetWorkPermitSign(workpermitId, Convert.ToInt32(ClientSession.GetUserContext().SiteId));

        }
        //Functions for ConfinedSpaceMuds Sign
        public void SaveConfinedMudsSign(ConfinedSpaceMudSign confinedSpaceSign)
        {
            confinedSpaceSign.SiteId = Convert.ToString(ClientSession.GetUserContext().SiteId);
            confinedSpaceSign.CreatedBy = Convert.ToInt32(ClientSession.GetUserContext().User.Id);
            confinedSpaceSign.UpdatedBy = Convert.ToInt32(ClientSession.GetUserContext().User.Id);
            confinedSpaceSign.CreatedDate = Convert.ToString(Clock.Now);
            confinedSpaceSign.UpdatedDate = Convert.ToString(Clock.Now);
          //  workPermitMudsService.InserUpdateWorkPermitSign(workPermitSign);
            confinedSpaceService.InserUpdateConfinedSpaceSign(confinedSpaceSign);

        }
        public ConfinedSpaceMudSign GetConfinedMudSign(string confinedSpaceId)
        {

            
            return confinedSpaceService.GetConfinedSpaceSign(confinedSpaceId,
                Convert.ToInt32(ClientSession.GetUserContext().SiteId));
        }

    }
}

using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class WorkPermitSectionPresenter : AbstractSectionPresenter
    {
        public WorkPermitSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            long siteId = ClientSession.GetUserContext().SiteId;
            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            #region Work Permit 

            if (authorized.ToViewWorkPermits(userRoleElements))
            {
                if (siteId == Site.MONTREAL_ID)
                {
                    presenters.Add(new WorkPermitMontrealPagePresenter());
                }
                else if (siteId == Site.MontrealSulphur_ID) //RITM0301321 mangesh
                {
                    presenters.Add(new WorkPermitMudsPagePresenter());
                }
                else if (siteId == Site.EDMONTON_ID)
                {
                    presenters.Add(new WorkPermitEdmontonPagePresenter(PageKey.WORK_PERMIT_RUNNING_UNIT_PAGE));
                    presenters.Add(new WorkPermitEdmontonTurnaroundPagePresenter());
                }
                else if (siteId == Site.LUBES_ID)
                {
                    presenters.Add(new WorkPermitLubesPagePresenter());
                }
                else if (siteId == Site.FORT_HILLS_ID)
                {
                    presenters.Add(new WorkPermitFortHillsPagePresenter(PageKey.WORK_PERMIT_PAGE));
                    
                }
                else
                {
                    presenters.Add(new WorkPermitPagePresenter());

                    if (ClientSession.GetUserContext().Assignment != null)
                    {
                        presenters.Add(new WorkPermitByAssignmentPagePresenter());
                    }
                    presenters.Add(new WorkPermitForTodayPagePresenter());
                }
            }

#endregion

            #region Confined Space

            if (authorized.ToViewConfinedSpaceDocuments(userRoleElements))
            {
                if (siteId == Site.MONTREAL_ID) 
                {
                    presenters.Add(new ConfinedSpacePagePresenter());
                }
                //RITM0301321 mangesh
                else if (siteId == Site.MontrealSulphur_ID)
                {
                    presenters.Add(new ConfinedSpaceMudsPagePresenter());
                }
            }

            #endregion

            #region Permit Request

            if (authorized.ToViewPermitRequests(userRoleElements))
            {
                if (siteId == Site.MONTREAL_ID)
                {
                    presenters.Add(new PermitRequestMontrealPagePresenter());
                }
                //RITM0301321 mangesh
                else if (siteId == Site.MontrealSulphur_ID)
                {
                    presenters.Add(new PermitRequestMudsPagePresenter());
                }
                else if (siteId == Site.EDMONTON_ID)
                {
                    presenters.Add(new PermitRequestEdmontonPagePresenter(PageKey.PERMIT_REQUEST_RUNNING_UNIT_PAGE));
                    presenters.Add(new PermitRequestEdmontonTurnaroundPagePresenter());
                }
                else if (siteId == Site.LUBES_ID)
                {
                    presenters.Add(new PermitRequestLubesPagePresenter());
                }
                if (siteId == Site.FORT_HILLS_ID)
                {
                   // presenters.Add(new PermitRequestFortHillsPagePresenter(PageKey.PERMIT_REQUEST_RUNNING_UNIT_PAGE));
                    presenters.Add(new PermitRequestFortHillsPagePresenter(PageKey.PERMIT_REQUEST_PAGE));
                   // presenters.Add(new PermitRequestEdmontonTurnaroundPagePresenter());
                }
            }

#endregion

            #region Showing Tabs for Work Permit / Permit Request Templates

            //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

            if (authorized.ToViewWorkPermits(userRoleElements))
            {
                if (siteId == Site.SARNIA_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitSarniaTemplatePagePresenter());
                }
                if (siteId == Site.DENVER_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitSarniaTemplatePagePresenter());
                } 
                if (siteId == Site.USPipeline_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitSarniaTemplatePagePresenter());
                }
                //mangesh uspipeline to selc
                if (siteId == Site.SELC_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitSarniaTemplatePagePresenter());
                }
                if (siteId == Site.MONTREAL_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitMontrealTemplatePagePresenter()); 
                }
                if (siteId == Site.MontrealSulphur_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitMudsTemplatePagePresenter()); 
                }
                if (siteId == Site.EDMONTON_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new WorkPermitEdmontonTemplatePresenter(PageKey.WORK_PERMIT_Edmonton_Template_PAGE));
                }
            }

            if (authorized.ToViewPermitRequests(userRoleElements))
            {
                if (siteId == Site.MONTREAL_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new PermitRequestMontrealTemplatePagePresenter()); 
                }
                if (siteId == Site.MontrealSulphur_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new PermitRequestMudsTemplatePagePresenter()); 
                }
                if (siteId == Site.EDMONTON_ID && ClientSession.GetUserContext().SiteConfiguration.EnableTemplateFeatureForWorkPermit)
                {
                    presenters.Add(new PermitRequestEdmontonTemplatePagePresenter(PageKey.EdmontonMarkedTemplate)); 
                }
            }

#endregion

            return presenters;
        }
    }
}

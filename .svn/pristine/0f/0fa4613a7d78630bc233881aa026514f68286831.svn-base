using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Annotations;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class FormSectionPresenter : AbstractSectionPresenter
    {
        public FormSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            IAuthorized authorized = new Authorized();
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            var presenters = new List<IDomainPagePresenter>();

            if (authorized.ToViewForm(userRoleElements))
            {
                if (ClientSession.GetUserContext().IsOilsandsSite)
                {
                    presenters.Add(MultiGridFormPagePresenter.CreateForOilsands());
                }
                    //ayman forthills
                else if (ClientSession.GetUserContext().IsForthillsSite)
                {
                    presenters.Add(MultiGridFormPagePresenter.CreateForForthills());
                }
                    //ayman E&U
                else if (ClientSession.GetUserContext().IsSiteWideServicesSite)
                {
                    presenters.Add(MultiGridFormPagePresenter.CreateForSiteWide());
                }
                else if (ClientSession.GetUserContext().IsEdmontonSite)
                {
                    presenters.Add(MultiGridEdmontonFormPagePresenter.Create());
                }
                //Ayman sarnia
                else if (ClientSession.GetUserContext().IsSarniaSite)
                {
                    if(ClientSession.GetUserContext().SiteConfiguration.EnableCSDMarkAsRead && userRoleElements.AuthorizedTo(RoleElement.MARKASREAD_CSDFORMS))
                    {
                     presenters.Add(MultiGridCSDFormPagePresenter.Create()); //DMND0010815 : Added By Vibhor - Sarnia Issues for CSD, EIP forms   
                    }
                    
                    presenters.Add(MultiGridSarniaFormPagePresenter.Create());
                }
                else if (ClientSession.GetUserContext().IsLubesSite)
                {
                    presenters.Add(MultiGridLubesFormPagePresenter.Create());
                }
                else if (ClientSession.GetUserContext().IsMontrealSite)
                {
                    presenters.Add(MultiGridMontrealFormPagePresenter.Create());
                }
                else if (ClientSession.GetUserContext().IsWoodBuffaloRegionSite)
                {
                    presenters.Add(MultiGridWoodBuffaloRegionFormPagePresenter.Create());
                }
                //RITM0268131 - mangesh
                else if (ClientSession.GetUserContext().IsMontrealSulphurSite)
                {
                    presenters.Add(MultiGridMontrealSulphurFormPagePresenter.Create());
                }
            }

           if(ClientSession.GetUserContext().SiteConfiguration.EnableCSDMarkAsRead && userRoleElements.AuthorizedTo(RoleElement.MARKASREAD_CSDFORMS)
               && !ClientSession.GetUserContext().IsSarniaSite)  //DMND0010815 : Added By Vibhor - Sarnia Issues for CSD, EIP forms
            /* RITM0265746 - Sarnia CSD marked as read **** Add tab to all and make it visibale or hidden from role matrix*/
              presenters.Add(MultiGridCSDFormPagePresenter.Create());
            /**/

            return presenters;
        }
        
    }
}

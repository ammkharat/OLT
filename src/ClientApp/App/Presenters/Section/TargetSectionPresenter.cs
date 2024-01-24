using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class TargetSectionPresenter : AbstractSectionPresenter
    {
        public TargetSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();            

            if (authorized.ToViewTargetDefinitions(userRoleElements))
            {
                presenters.Add(new TargetDefinitionPagePresenter());    
            }

            if (authorized.ToViewTargetAlerts(userRoleElements))
            {
                presenters.Add(new TargetAlertPagePresenter());
            }

            return presenters;
        }
    }
}

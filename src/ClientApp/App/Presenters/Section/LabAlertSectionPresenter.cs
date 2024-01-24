using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class LabAlertSectionPresenter : AbstractSectionPresenter
    {
        public LabAlertSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            if (authorized.ToViewLabAlertDefinitionsAndLabAlerts(userRoleElements))
            {
                presenters.Add(new LabAlertDefinitionPagePresenter());
                presenters.Add(new LabAlertPagePresenter());                
            }

            return presenters;
        }
    }
}

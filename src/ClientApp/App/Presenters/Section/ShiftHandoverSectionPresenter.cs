using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class ShiftHandoverSectionPresenter : AbstractSectionPresenter
    {
        public ShiftHandoverSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            if (authorized.ToViewShiftHandover(userRoleElements))
            {
                presenters.Add(new ShiftHandoverQuestionnairePagePresenter());
                if (ClientSession.GetUserContext().Assignment != null)
                {
                    presenters.Add(new ShiftHandoverQuestionnaireByAssignmentPagePresenter());
                }
            }

            return presenters;
        }
    }
}

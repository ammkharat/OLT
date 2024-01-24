using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class ActionItemSectionPresenter : AbstractSectionPresenter
    {
        public ActionItemSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            IAuthorized authorized = new Authorized();

            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            if (ShouldActionItemDefinitionTabBeVisible(authorized))
            {
                presenters.Add(new ActionItemDefinitionPagePresenter());
            }

            if (ShouldActionItemTabBeVisible(authorized))
            {
                presenters.Add(new ActionItemPagePresenter());
            }
            
            if (ShouldActionItemByAssignmentTabBeVisible(authorized))
            {
                presenters.Add(new ActionItemByAssignmentPagePresenter());
            }

            if (ShouldFutureActionItemTabBeVisible(authorized))
            {
                presenters.Add(new FutureActionItemPagePresenter());
            }

            return presenters;
        }

        private static bool ShouldFutureActionItemTabBeVisible(IAuthorized authorized)
        {
            return (authorized.ToViewFutureActionItemDefinitions(ClientSession.GetUserContext().UserRoleElements));
            
        }

        private static bool ShouldActionItemDefinitionTabBeVisible(IAuthorized authorized)
        {
            return (authorized.ToViewActionItemDefinitions(ClientSession.GetUserContext().UserRoleElements));
        }

        private static bool ShouldActionItemTabBeVisible(IAuthorized authorized)
        {
            return (authorized.ToViewActionItems(ClientSession.GetUserContext().UserRoleElements));
        }

        private static bool ShouldActionItemByAssignmentTabBeVisible(IAuthorized authorized)
        {
            return ShouldActionItemTabBeVisible(authorized) && ClientSession.GetUserContext().Assignment != null;
        }
    }
}

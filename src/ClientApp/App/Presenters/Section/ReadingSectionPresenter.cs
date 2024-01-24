using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class ReadingSectionPresenter : AbstractSectionPresenter
    {
        public ReadingSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            IAuthorized authorized = new Authorized();

            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            if (ShouldReadingDefinitionTabBeVisible(authorized))
            {
                presenters.Add(new ReadingDefinitionPagePresenter());
            }

            if (ShouldReadingTabBeVisible(authorized))
            {
                presenters.Add(new ReadingPagePresenter());
            }
            
            if (ShouldActionItemByAssignmentTabBeVisible(authorized))
            {
                presenters.Add(new ReadingByAssignmentPagePresenter());
            }

            return presenters;
        }

        private static bool ShouldFutureActionItemTabBeVisible(IAuthorized authorized)
        {
            return (authorized.ToViewFutureActionItemDefinitions(ClientSession.GetUserContext().UserRoleElements));
            
        }

        private static bool ShouldReadingDefinitionTabBeVisible(IAuthorized authorized)
        {
            return (authorized.ToViewActionItemDefinitions(ClientSession.GetUserContext().UserRoleElements));
        }

        private static bool ShouldReadingTabBeVisible(IAuthorized authorized)
        {
            return (authorized.ToViewReading(ClientSession.GetUserContext().UserRoleElements));
        }

        private static bool ShouldActionItemByAssignmentTabBeVisible(IAuthorized authorized)
        {
            return ShouldReadingTabBeVisible(authorized) && ClientSession.GetUserContext().Assignment != null;
        }
    }
}

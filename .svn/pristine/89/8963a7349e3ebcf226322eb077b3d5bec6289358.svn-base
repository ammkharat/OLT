using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class RestrictionSectionPresenter : AbstractSectionPresenter
    {
        public RestrictionSectionPresenter() : base(new BaseSection(), GetPresenters())
        {
        }

        private static IEnumerable<IDomainPagePresenter> GetPresenters()
        {
            List<IDomainPagePresenter> presenters = new List<IDomainPagePresenter>();

            presenters.Add(new RestrictionDefinitionPagePresenter());
            presenters.Add(new DeviationAlertPagePresenter());

            return presenters;
        }
    }
}

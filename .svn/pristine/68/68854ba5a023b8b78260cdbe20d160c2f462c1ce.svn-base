using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Controls.Section;
using Com.Suncor.Olt.Client.Presenters.Page;

namespace Com.Suncor.Olt.Client.Presenters.Section
{
    public class PrioritiesSectionPresenter : ISectionPresenter
    {
        private readonly ISection section;

        public PrioritiesSectionPresenter()
        {
            Control page;
            if (ClientSession.GetUserContext().SiteConfiguration.UseNewPriorityPage)
            {
                PriorityPagePresenter presenter = new PriorityPagePresenter();
                page = (Control)presenter.Page;
            }
            else
            {
                page = new OldPriorityPage();
            }

            section = new PrioritiesSection(page);
        }

        public ISection Section
        {
            get { return section; }
        }

        public void Dispose()
        {
            section.DisposePages();
            section.Dispose();
        }
    }
}

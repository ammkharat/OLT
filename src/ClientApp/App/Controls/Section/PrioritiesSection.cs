using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Section
{
    public partial class PrioritiesSection : UserControl, ISection
    {
        public event Action<IItemSelectablePage> SelectedTabChanged;
        public event Action Selected;

        private Control page;

        public PrioritiesSection(Control page)
        {
            InitializeComponent();

            this.page = page;
            page.Visible = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(page);

            page.Dock = DockStyle.Fill;
            page.Size = contentPanel.Size;
            page.Visible = true;
        }

        public void OnSelect()
        {
            if (Selected != null)
            {
                Selected();
            }
        }

        public bool IsPageVisible(PageKey pageKey)
        {
            if (pageKey == PageKey.PRIORITIES_PAGE && page != null && page.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IItemSelectablePage SelectedPage
        {
            get { return null; }
        }

        public IDomainPagePresenter SelectedPagePresenter
        {
            get { return null; }
        }

        public void DisposePages()
        {
            contentPanel.Controls.Clear();
            if (page  != null)
            {
                page.Dispose();
                page = null;
            }
        }

        public void AddPage(IItemSelectablePage page, IDomainPagePresenter pagePresenter, int defaultSelectOrder)
        {            
        }

        public void SelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage)
        {
        }

        public void SelectSingleItem(DomainObject selected, bool suppressItemNotFoundMesage)
        {
        }

        public bool GetSelectSingleItem(PageKey pageKey, long domainObjectId, bool suppressItemNotFoundMesage)
        {
            return false;
        }
    }
}
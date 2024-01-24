using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public interface IDomainListViewRenderer<TDomainObject> where TDomainObject : DomainObject
    {
        DomainListViewColumnCollection Columns { get; }

        string FilterString { get; set; }

        string SearchString { get; set; }

        ListViewItem RenderItem(TDomainObject domainObject);
    }
}

using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class formSelectorListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<FormGN75BTemplatePattern>
    {
        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colForm = new DomainListViewColumn.ResizeToHeaderSizeColumn();
                colForm.Name = "StartTime";

                colForm.Text = "FormGN75BTemplate";

                return new DomainListViewColumnCollection(
                    colForm);
            }
        }

        public ListViewItem RenderItem(FormGN75BTemplatePattern formPattern)
        {
            ListViewItem result = null;

            if (formPattern != null)
            {
                var lvi = new DomainListViewItem<FormGN75BTemplatePattern>(formPattern)
                {
                    Text = new formPatternFormatter(formPattern).Format()
                };

                result = lvi;
            }

            return result;

        }
    }
}

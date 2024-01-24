using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
   public interface IFormGN75BTemplateSelectionForm
    {
        FormGN75BTemplatePattern SelectedFormGN75BTemplatePattern { set; get; }
        DomainListView<FormGN75BTemplatePattern> SelectedFormGN75BTemplatelISTView { get; }
        int ListViewItemCount { get; }
        List<FormGN75BTemplatePattern> FormGN75BTemplatesToAddToListView { set; get; }
        void CloseForm();
        void SelectItem(DomainObject selected);
        bool formWasSelected();
    }
}

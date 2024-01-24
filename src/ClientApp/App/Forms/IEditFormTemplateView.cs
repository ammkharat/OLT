using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditFormTemplateView : IBaseForm
    {
        event Action SaveButtonClick;
        event Action CancelButtonClick;

        string Template { get; set; }
        string Title { set; }
    }
}

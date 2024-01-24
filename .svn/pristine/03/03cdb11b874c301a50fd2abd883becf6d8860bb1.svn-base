
using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditConfiguredDocumentLinkView : IBaseForm
    {
        string Title { set; }
        string LinkTitle { get; set; }
        string Link { get; set; }
        event EventHandler OkButtonClicked;
        void SetErrorNoLink();
        void SetErrorNoTitle();
        void ClearErrors();
    }
}

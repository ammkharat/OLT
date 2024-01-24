
using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditConfiguredDocumentLinksView : IBaseForm
    {
        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        string LocationName { set; }
        ConfiguredDocumentLink SelectedLink { get; set; }
        void SelectFirstRow();
        bool UserIsSure();

        event EventHandler AddButtonClick;
        event EventHandler EditButtonClick;
        event EventHandler MoveUpButtonClick;
        event EventHandler MoveDownButtonClick;
        event EventHandler DeleteButtonClick;        
        event EventHandler SaveAndCloseButtonClick;
    }
}

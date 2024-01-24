
using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfiguredDocumentLinkConfigurationView : IBaseForm
    {
        event Action<ConfiguredDocumentLinkLocation> EditButtonClicked;

        List<ConfiguredDocumentLinkLocation> Locations { set; }
        void SelectFirstRow();
    }
}

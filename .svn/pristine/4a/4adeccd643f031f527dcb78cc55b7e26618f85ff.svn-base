using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditHistoryFormView : IBaseForm
    {
        event Action CloseButtonClicked;
        event Action<DomainObject> SelectedItemChanged;

        List<DomainObjectChangeSet> DomainObjectChangeSets { set; }
        List<PropertyChange> PropertyChanges { set; }
        string TypeGroupBoxText { set; }
        string Name { set; }
    }
}
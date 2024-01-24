using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureAreaLabelsView : IBaseForm
    {
        event Action AddAreaLabel;
        event Action EditAreaLabel;
        event Action DeleteAreaLabel;
        event Action SaveAndClose;
        event Action MoveUp;
        event Action MoveDown;

        List<AreaLabel> AreaLabels { set; }
        AreaLabel SelectedAreaLabel { get; set; }
        bool UserIsSureTheyWantToDelete();
        void SelectFirstValue();
    }
}

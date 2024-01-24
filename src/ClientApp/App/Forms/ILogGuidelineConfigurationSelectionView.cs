using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogGuidelineConfigurationSelectionView : IBaseForm
    {
        event EventHandler EditButtonClicked;
        event EventHandler CloseButtonClicked;

        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FunctionalLocation> FunctionalLocationList { set; }
        void SelectFirstFunctionalLocation();       
    }
}

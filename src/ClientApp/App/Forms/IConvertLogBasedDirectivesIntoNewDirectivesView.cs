using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConvertLogBasedDirectivesIntoNewDirectivesView : IBaseForm
    {
        bool ContinueButtonEnabled { set; }
        bool AcceptChecked { get; }
        string SiteName { set; }
        IMultiSelectFunctionalLocationSelectionForm FlocSelector { set; }
        List<FunctionalLocation> FunctionalLocations { get; set; }
        FunctionalLocation SelectedFunctionalLocation { get; }
        event Action FormLoad;
        event Action AcceptCheckboxChanged;
        event Action ContinueClicked;
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        void SetErrorForNoFunctionalLocationSelected();
        void ClearErrorProviders();

        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> flocSelections);
    }
}
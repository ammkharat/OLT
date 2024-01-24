using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFunctionalLocationSearchView
    {
        string SearchText { get; }
        bool FindNextButtonEnabled { set; }
        IList<FunctionalLocation> RootFunctionalLocations { get; }
        FunctionalLocation HighlightedFunctionalLocation { get; }

        Form GetActiveForm();
        bool SelectResult(FunctionalLocation floc);
    }
}

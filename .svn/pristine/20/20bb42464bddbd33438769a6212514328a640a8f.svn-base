using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IMultiSelectFunctionalLocationSelectionForm : ISelectFunctionalLocationSelectionForm
    {
        IList<FunctionalLocation> UserSelectedFunctionalLocations { get; set; }
        DialogResult ShowDialog(IWin32Window owner, List<FunctionalLocation> initialSelection);

        bool CanCheckFunctionalLocation(FunctionalLocation floc);
        IFunctionalLocationValidator FlocValidator { set; }
    }
}

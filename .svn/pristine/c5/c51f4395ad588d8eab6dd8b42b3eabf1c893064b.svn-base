using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SingleSelectFunctionalLocationSelectionFormPresenter //: ISingleSelectFunctionalLocationFormSelectionPresenter
    {
        private readonly ISingleSelectFunctionalLocationSelectionForm view;

        public SingleSelectFunctionalLocationSelectionFormPresenter(ISingleSelectFunctionalLocationSelectionForm view)
        {
            this.view = view;
        }

        public void HandleAccept(object sender, EventArgs e)
        {
            
            if (view.SelectedFunctionalLocation == null)
            {
                view.LaunchFunctionalLocationSelectionRequiredMessage();
            }
            else if (!view.AreSelectedFunctionalLocationsValid)
            {
                view.SetFunctionalLocationErrorMessage();
            }
            else
            {
                view.CloseForm(DialogResult.OK);
            }
        }

        public void HandleCancel(object sender, EventArgs e)
        {
            view.CloseForm(DialogResult.Cancel);
        }
    }
}
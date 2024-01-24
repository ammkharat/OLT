using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SingleSelectFunctionalLocationSelectionForm : BaseForm, ISingleSelectFunctionalLocationSelectionForm
    {
        private readonly SingleSelectFunctionalLocationSelectionFormPresenter formPresenter;

        public SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode mode,
                                                           IFunctionalLocationTreeNodeFilter filter) : this(mode)
        {
            flocControl.NodeFilter = filter;
        }

        public SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode mode)
        {
            InitializeComponent();
            flocControl.Mode = mode;
            flocControl.FunctionalLocationLookup = new FunctionalLocationLookup();
            formPresenter = new SingleSelectFunctionalLocationSelectionFormPresenter(this);
            cancelButton.Click += formPresenter.HandleCancel;
            acceptButton.Click += formPresenter.HandleAccept;
        }


        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return flocControl.SelectedFunctionalLocation; }
        }

        public bool AreSelectedFunctionalLocationsValid
        {
            get { return flocControl.IsSelectedValid; }
        }

        public void SetFunctionalLocationErrorMessage()
        {
            SetFunctionalLocationErrorMessage(StringResources.FlocsNotVisibleToUserError);
        }

        public void SetFunctionalLocationErrorMessage(string message)
        {
            functionalLocationErrorProvider.SetError(cancelButton, message);
        }

        private void ClearErrorMessages()
        {
            functionalLocationErrorProvider.Clear();
        }

        public void LaunchFunctionalLocationSelectionRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.FlocNotSelectedError, StringResources.FunctionalLocationsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseForm(DialogResult result)
        {
            ClearErrorMessages();
            DialogResult = result;
            Close();
        }
    }
}
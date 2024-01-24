using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class MultiSelectFunctionalLocationSelectionForm : BaseForm, IMultiSelectFunctionalLocationSelectionForm
    {
        private readonly MultiSelectFunctionalLocationSelectionFormPresenter presenter;

        /// <summary>
        /// No arg constructor that should allow the designer to work
        /// </summary>
        public MultiSelectFunctionalLocationSelectionForm()
        {
            InitializeComponent();
        }

        public MultiSelectFunctionalLocationSelectionForm(FunctionalLocationMode mode, IFunctionalLocationTreeNodeFilter filter, bool allowSelectFlocsForCurrentAssignment,
                                                          List<FunctionalLocation> rootFlocsForActiveSelection) : this()
        {
            flocSelectionControl.Mode = mode;
            flocSelectionControl.NodeFilter = filter;

            selectActiveFlocsButton.Visible = allowSelectFlocsForCurrentAssignment;

            presenter = new MultiSelectFunctionalLocationSelectionFormPresenter(this, rootFlocsForActiveSelection);


            Load += presenter.Form_Load;

            acceptButton.Click += presenter.AcceptButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;
            clearButton.Click += presenter.ClearSelectionButton_Click;
            selectActiveFlocsButton.Click += presenter.SelectActiveFlocsButton_Click;
        }

        public MultiSelectFunctionalLocationSelectionForm(
            FunctionalLocationMode mode, IFunctionalLocationTreeNodeFilter filter, bool allowSelectFlocsForCurrentAssignment)
            : this(mode, filter, allowSelectFlocsForCurrentAssignment, ClientSession.GetUserContext().RootsForSelectedFunctionalLocations)
        {
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> UserSelectedFunctionalLocations
        {
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
            set { flocSelectionControl.UserCheckedFunctionalLocations = value; }
        }

        public bool AreSelectedFunctionalLocationsValid
        {
            get { return flocSelectionControl.IsSelectedValid; }
        }

        public void ClearErrorMessages()
        {
            functionalLocationErrorProvider.Clear();
        }

        public void SetFunctionalLocationErrorMessage()
        {
            SetFunctionalLocationErrorMessage(StringResources.FlocsNotVisibleToUserError);
        }

        public void SetFunctionalLocationErrorMessage(string message)
        {
            functionalLocationErrorProvider.SetError(cancelButton, message);
        }

        public void LaunchFunctionalLocationSelectionRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.FlocEmptyError, StringResources.FunctionalLocationsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public void CloseForm(DialogResult result)
        {
            ClearErrorMessages();
            DialogResult = result;
            Close();
        }

        public DialogResult ShowDialog(IWin32Window owner, List<FunctionalLocation> initialSelection)
        {
            return presenter.ShowDialog(owner, initialSelection);
        }

        public bool CanCheckFunctionalLocation(FunctionalLocation floc)
        {
            return flocSelectionControl.CanCheckFunctionalLocation(floc);
        }

        public IFunctionalLocationValidator FlocValidator
        {
            set { presenter.FlocValidator = value; }
        }
    }
}

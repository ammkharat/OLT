using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ChangeActiveRestrictionFunctionalLocationForm : BaseForm, IChangeActiveRestrictionFunctionalLocationView
    {
        private readonly IChangeActiveFunctionalLocationPresenter presenter;

        public ChangeActiveRestrictionFunctionalLocationForm()
        {
            InitializeComponent();
            flocSelectionControl.Mode = ClientSession.GetInstance().SiteConfiguredFunctionalLocationMode;
            flocSelectionControl.CheckParentIfAllSiblingsAreChecked = true;

            presenter = new ChangeActiveRestrictionFunctionalLocationPresenter(this);
            Text = StringResources.ChangeActiveRestrictionFLOCFormTitle;
                        
            Load += presenter.Form_Load;

            acceptButton.Click += presenter.AcceptButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;
            loadDefaultAssignmentFlocsButton.Click += presenter.HandleLoadDefaultAssignmentFlocsButtonClick;
            clearButton.Click += presenter.ClearSelectionButton_Click;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> UserSelectedFunctionalLocations
        {
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
            set { flocSelectionControl.UserCheckedFunctionalLocations = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<FunctionalLocation> AllSelectedFunctionalLocations
        {
            get { return flocSelectionControl.AllCheckedFunctionalLocations; }
        }

        public string Assignment
        {
            set { assignmentLabel.Text = value; }
        }

        public bool LoadDefaultAssignmentFlocsButtonEnabled
        {
            set { loadDefaultAssignmentFlocsButton.Enabled = value; }
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
            functionalLocationErrorProvider.SetError(cancelButton, StringResources.FlocsNotVisibleToUserError);
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
            set { }
        }
    }
}

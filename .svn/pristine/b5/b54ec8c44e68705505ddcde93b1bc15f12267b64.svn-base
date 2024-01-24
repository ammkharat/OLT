using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureFunctionalLocationsForm : BaseForm, IConfigureFunctionalLocationsView
    {
        private readonly ConfigureFunctionalLocationsFormPresenter formPresenter;

        public ConfigureFunctionalLocationsForm(FunctionalLocationMode mode)
        {
            InitializeComponent();
            flocControl.Mode = mode;
            flocControl.NodeFilter = new AdminOltSourcedFunctionalLocationsFilter();
            flocControl.FunctionalLocationLookup = new AdminFunctionalLocationLookup();

            formPresenter = new ConfigureFunctionalLocationsFormPresenter(this);

            flocControl.AfterSelect += (sender, args) => formPresenter.HandleSelectedFunctionalLocationTreeNodeChanged();
            cancelButton.Click += (sender, args) => CloseForm();
            addButton.Click += (sender, args) => formPresenter.AddFunctionalLocation();
            editButton.Click += (sender, args) => formPresenter.EditFunctionalLocation();
            deleteButton.Click += (sender, args) => formPresenter.DeleteFunctionalLocation();
        }

        public FunctionalLocation ParentOfSelectedFunctionalLocation
        {
            get { return flocControl.ParentOfSelectedFunctionalLocation; }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return flocControl.SelectedFunctionalLocation; }
        }

        public List<FunctionalLocation> ChildrenOfSelectedFunctionalLocation
        {
            get { return flocControl.ChildrenOfSelectedFunctionalLocation; }
        }

        public List<FunctionalLocation> SiblingsOfSelectedFunctionalLocation
        {
            get { return flocControl.SiblingsOfSelectedFunctionalLocation; }
        }

        public bool EditButtonEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool DeleteButtonEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool AddButtonEnabled
        {
            set { addButton.Enabled = value; }
        }

        public void UpdateSelectedFunctionalLocation(FunctionalLocation functionalLocation)
        {
            flocControl.UpdateSelectedItem(functionalLocation);
        }

        public void RemoveSelectedFunctionalLocation()
        {
            flocControl.RemoveSelectedFunctionalLocation();
        }

        public void AddNewFunctionalLocation(FunctionalLocation insertedFunctionalLocation)
        {
            flocControl.AddNewFunctionalLocation(insertedFunctionalLocation);
        }

        public bool IsSelectedEditable
        {
            get
            {
                return flocControl.SelectedFunctionalLocation != null && flocControl.SelectedFunctionalLocation.Source == FunctionalLocationSource.OLT;
            }
        }

        private void CloseForm()
        {
            Close();
        }

        public static string CreateObjectLockKey()
        {
            return string.Format("Configure FLOCS for site: {0}", ClientSession.GetUserContext().Site.Id);
        }
    }
}
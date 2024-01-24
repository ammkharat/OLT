using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureFunctionalLocationsFormPresenter
    {
        private readonly IConfigureFunctionalLocationsView view;
        private readonly IFunctionalLocationService functionalLocationService;

        public ConfigureFunctionalLocationsFormPresenter(IConfigureFunctionalLocationsView view)
        {
            this.view = view;
            functionalLocationService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        public void AddFunctionalLocation()
        {
            var form = new AddEditFunctionalLocationForm(view.SelectedFunctionalLocation, view.ChildrenOfSelectedFunctionalLocation);
            form.ShowDialog(Form.ActiveForm);

            if (form.ShouldAddOrUpdate)
            {
                Site site = ClientSession.GetUserContext().Site;
                FunctionalLocation newFunctionalLocation = new FunctionalLocation(null, site, form.NewFullHierarchy, form.Description, false, false,
                    view.SelectedFunctionalLocation.PlantId, view.SelectedFunctionalLocation.Culture, FunctionalLocationSource.OLT);

                FunctionalLocation functionalLocation = functionalLocationService.QueryByFullHierarchyIncludeDeleted(newFunctionalLocation.FullHierarchy, site.IdValue);
                if (functionalLocation != null)
                {
                    functionalLocationService.UndoRemove(functionalLocation);
                    view.AddNewFunctionalLocation(functionalLocation);
                }
                else
                {
                    FunctionalLocation insertedFunctionalLocation = functionalLocationService.Insert(newFunctionalLocation);
                    view.AddNewFunctionalLocation(insertedFunctionalLocation);
                }
                
            }
        }

        public void EditFunctionalLocation()
        {
            if (view.IsSelectedEditable)
            {
                var form = new AddEditFunctionalLocationForm(view.ParentOfSelectedFunctionalLocation, view.SiblingsOfSelectedFunctionalLocation, view.SelectedFunctionalLocation);
                form.ShowDialog(Form.ActiveForm);

                if (form.ShouldAddOrUpdate)
                {
                    FunctionalLocation selectedFunctionalLocation = view.SelectedFunctionalLocation;
                    selectedFunctionalLocation.Description = form.Description;
                    functionalLocationService.Update(selectedFunctionalLocation);
                    view.UpdateSelectedFunctionalLocation(selectedFunctionalLocation);
                }
            }
        }

        public void DeleteFunctionalLocation()
        {
            if (view.IsSelectedEditable)
            {
                DialogResult dialogResult = OltMessageBox.ShowCustomYesNo(StringResources.FunctionalLocationDeleteConfirmation);
                if (DialogResult.Yes == dialogResult)
                {
                    functionalLocationService.RemoveByFullHierarchy(view.SelectedFunctionalLocation);
                    view.RemoveSelectedFunctionalLocation();
                }
            }
        }

        public void HandleSelectedFunctionalLocationTreeNodeChanged()
        {
            if (view.SelectedFunctionalLocation == null)
            {
                view.EditButtonEnabled = false;
                view.DeleteButtonEnabled = false;
            }
            else
            {
                bool isOltSourcedFloc = view.IsSelectedEditable;
                view.EditButtonEnabled = isOltSourcedFloc;
                view.DeleteButtonEnabled = isOltSourcedFloc;
            }
            view.AddButtonEnabled = view.SelectedFunctionalLocation != null && view.SelectedFunctionalLocation.Level < 7;
        }
    }
}
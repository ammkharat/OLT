using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditFunctionalLocationFormPresenter
    {
        private readonly IAddEditFunctionalLocationView view;
        private readonly FunctionalLocation editObject;
        private readonly FunctionalLocation parentFunctionalLocation;
        private readonly List<FunctionalLocation> potentialSiblingFunctionalLocations;

        private readonly IFunctionalLocationService service;

        private readonly long siteId;

        public AddEditFunctionalLocationFormPresenter(IAddEditFunctionalLocationView view, FunctionalLocation parentFunctionalLocation, List<FunctionalLocation> potentialSiblingFunctionalLocations, FunctionalLocation editObject)
        {
            this.view = view;
            this.editObject = editObject;
            this.parentFunctionalLocation = parentFunctionalLocation;
            this.potentialSiblingFunctionalLocations = potentialSiblingFunctionalLocations;

            service = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>();

            siteId = ClientSession.GetUserContext().SiteId;
        }

        private const string Format = "{0}-{1}";

        public void NameTextBoxTextChanged()
        {
            string fullHierarchyPart = view.NextLevel;
            view.FullHierarchy = fullHierarchyPart.IsNullOrEmptyOrWhitespace()
                ? string.Empty
                : string.Format(Format, parentFunctionalLocation.FullHierarchy, fullHierarchyPart);

        }

        public void HandleLoadForm()
        {
            view.SuperiorFloc = parentFunctionalLocation.FullHierarchy;
            if (editObject != null)
            {
                view.Description = editObject.Description;
                string flocPartWithoutSuperior = editObject.FullHierarchy.RemoveStringFromStartOf(parentFunctionalLocation.FullHierarchy);
                view.NextLevel = flocPartWithoutSuperior.TrimStart(new[] { '-' });
            }
        }

        public void HandleCancelButtonClicked()
        {
            view.ShouldAddOrUpdate = false;
            view.Close();
        }

        public void HandleSubmitButtonClicked()
        {
            if (!DataIsValid())
            {
                return;
            }

            view.ShouldAddOrUpdate = true;
            view.Close();
        }

        private bool DataIsValid()
        {
            view.ClearErrors();

            bool hasError = false;

            string fullHierarchy = view.NewFullHierarchy;

            if (fullHierarchy.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForEmptyName();
                hasError = true;
            }
            else if (view.NextLevel.IndexOfAny(new[] { '-', ' ' }) != -1)
            {
                view.SetErrorForInvalidCharactersInFlocName();
                hasError = true;
            }
            else
            {

                if ((editObject == null && potentialSiblingFunctionalLocations.Exists(sibling => sibling.FullHierarchy.EqualsIgnoreCase(fullHierarchy))))
                {
                    view.SetErrorForDuplicateFlocName();
                    hasError = true;
                }
                else if (editObject != null && potentialSiblingFunctionalLocations.Exists(sibling => !editObject.IsSame(sibling) && sibling.FullHierarchy.EqualsIgnoreCase(fullHierarchy)))
                {
                    view.SetErrorForDuplicateFlocName();
                    hasError = true;
                }
            }
            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForEmptyDescription();
                hasError = true;
            }

            if (hasError)
                return !hasError;

            FunctionalLocation functionalLocation = service.QueryByFullHierarchyIncludeDeleted(fullHierarchy, siteId);
            if (functionalLocation != null && functionalLocation.Deleted)
            {
                if (editObject == null)
                {
                    DialogResult result = OltMessageBox.ShowCustomYesNo(StringResources.FunctionalLocationUndelete);
                    if (result != DialogResult.Yes)
                    {
                        view.SetErrorForDuplicateFlocName();
                        hasError = true;
                    }
                }
                else
                {
                    view.SetErrorForDuplicateFlocName();
                }
            }
            return !hasError;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FunctionalLocationSearchPresenter
    {
        private readonly IFunctionalLocationSearchView view;
        private IFunctionalLocationService flocService;
        private IFunctionalLocationDTOService flocDtoService;

        private FunctionalLocationMode mode;
        private IList<FunctionalLocation> rootFunctionalLocationCache;
        private FunctionalLocationSearchResult results;

        public FunctionalLocationSearchPresenter(IFunctionalLocationSearchView view)
        {
            this.view = view;
            view.FindNextButtonEnabled = false;
        }

        public FunctionalLocationMode Mode
        {
            set { mode = value; }
        }

        public void HandleSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            view.FindNextButtonEnabled = !String.IsNullOrEmpty(view.SearchText);
            results = null;
        }

        public void HandleFindNextButton_Click(object sender, EventArgs e)
        {
            if (results == null)
            {
                string searchText = view.SearchText;
                if (!String.IsNullOrEmpty(searchText))
                {
                    List<FunctionalLocationDTO> dtos = FlocDtoService.QueryBySearchTextInDescriptionOrFullHierarchy(
                        searchText,
                        ClientSession.GetUserContext().Site,
                        mode.AllowedTypes);
                    results = new FunctionalLocationSearchResult(dtos);
                }
            }
            DisplayResults();
        }

        private void DisplayResults()
        {
            if (results == null)
            {
                DisplayNotFoundMessageBox();
            }
            else
            {
                MoveCurrentToJustBeforeHighlighted();
                if (!ShowOneResult())
                {
                    results.Reset(); // loop back to the beginning and try one more time
                    if (!ShowOneResult())
                    {
                        DisplayNotFoundMessageBox();
                    }
                }
            }
        }

        private void MoveCurrentToJustBeforeHighlighted()
        {
            if (view.HighlightedFunctionalLocation != null)
            {
                results.MoveToOrJustBefore(view.HighlightedFunctionalLocation);
            }
        }

        private bool ShowOneResult()
        {
            while (results.MoveNext())
            {
                FunctionalLocationDTO current = results.Current;
                if (CanShow(current))
                {
                    FunctionalLocation floc = FlocService.QueryById(current.IdValue);
                    bool selected = view.SelectResult(floc);
                    if (selected)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanShow(FunctionalLocationDTO floc)
        {
            return 
                mode.IsAllowed(floc.Type) &&
                (RootFunctionalLocations.Exists(root =>
                    root.Id == floc.Id || root.IsParentOf(floc, ClientSession.GetUserContext().Site)));
        }

        private IList<FunctionalLocation> RootFunctionalLocations
        {
            get { return rootFunctionalLocationCache ?? (rootFunctionalLocationCache = view.RootFunctionalLocations); }
        }

        private void DisplayNotFoundMessageBox()
        {
            OltMessageBox.Show(
                view.GetActiveForm(),
                StringResources.FunctionalLocationNotFound,
                StringResources.SearchFunctionalLocationTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // lazy load service instead of getting it in constructor so that designer will work
        private IFunctionalLocationService FlocService
        {
            get { return flocService ?? (flocService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>()); }
        }

        // lazy load service instead of getting it in constructor so that designer will work
        private IFunctionalLocationDTOService FlocDtoService
        {
            get { return flocDtoService ?? (flocDtoService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationDTOService>()); }
        }
    }
}
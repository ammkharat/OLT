using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class MultiSelectFunctionalLocationSelectionFormPresenter
    {
        private readonly IMultiSelectFunctionalLocationSelectionForm view;
        private readonly IFunctionalLocationInfoService functionalLocationInfoService;

        private List<FunctionalLocation> mostRecentlySelectedFlocList;
        private List<FunctionalLocation> flocsToSelectOnLoad;

        private readonly List<FunctionalLocation> rootsForSelectedFunctionalLocations;

        public MultiSelectFunctionalLocationSelectionFormPresenter(IMultiSelectFunctionalLocationSelectionForm view, List<FunctionalLocation> rootFlocsForActiveSelection)
            : this(view, ClientServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>(), rootFlocsForActiveSelection)
        {
        }

        public MultiSelectFunctionalLocationSelectionFormPresenter(
            IMultiSelectFunctionalLocationSelectionForm view,
            IFunctionalLocationInfoService functionalLocationInfoService)
            : this(view, functionalLocationInfoService, ClientSession.GetUserContext().RootsForSelectedFunctionalLocations)
        {
        }

        private MultiSelectFunctionalLocationSelectionFormPresenter(
            IMultiSelectFunctionalLocationSelectionForm view,
            IFunctionalLocationInfoService functionalLocationInfoService, 
            List<FunctionalLocation> rootsForSelectedFunctionalLocations)
        {
            this.view = view;
            this.functionalLocationInfoService = functionalLocationInfoService;
            this.rootsForSelectedFunctionalLocations = rootsForSelectedFunctionalLocations;
        }

        public DialogResult ShowDialog(IWin32Window owner, List<FunctionalLocation> initialSelectedFlocs)
        {
            flocsToSelectOnLoad = initialSelectedFlocs;
            return view.ShowDialog(owner);
        }

        public virtual void Form_Load(object sender, EventArgs e)
        {
            if (flocsToSelectOnLoad != null)
            {
                view.UserSelectedFunctionalLocations = flocsToSelectOnLoad;
                flocsToSelectOnLoad = null;
            }

            // Save the selected FLOC list such that we can restore the selected FLOC list to its original selections in the
            // event that the user cancels this operation.
            mostRecentlySelectedFlocList = new List<FunctionalLocation>(view.UserSelectedFunctionalLocations);
        }

        public void AcceptButton_Click(object sender, EventArgs e)
        {
            IList<FunctionalLocation> userSelectedFlocList = view.UserSelectedFunctionalLocations;
            if (userSelectedFlocList.Count == 0)
            {
                view.LaunchFunctionalLocationSelectionRequiredMessage();
            }
            else if (!view.AreSelectedFunctionalLocationsValid)
            {
                view.SetFunctionalLocationErrorMessage();
            }
            else if (FlocValidator != null && !FlocValidator.AreValid(new List<FunctionalLocation>(userSelectedFlocList)))
            {
                view.SetFunctionalLocationErrorMessage(FlocValidator.ErrorMessage());
            }
            else
            {
                view.CloseForm(DialogResult.OK);
            }
        }

        public void CancelButton_Click(object sender, EventArgs e) 
        {
            view.UserSelectedFunctionalLocations = mostRecentlySelectedFlocList;
            view.CloseForm(DialogResult.Cancel);
        }

        public void ClearSelectionButton_Click(object sender, EventArgs args)
        {
            view.UserSelectedFunctionalLocations = new List<FunctionalLocation>();
        }

        public void SelectActiveFlocsButton_Click(object sender, EventArgs e)
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            GetCheckableFlocs(flocs, rootsForSelectedFunctionalLocations);
            view.UserSelectedFunctionalLocations = flocs;
        }

        private void GetCheckableFlocs(List<FunctionalLocation> checkableFlocs, IList<FunctionalLocation> flocsToTryToSelect)
        {
            foreach (FunctionalLocation floc in flocsToTryToSelect)
            {
                if (view.CanCheckFunctionalLocation(floc))
                {
                    checkableFlocs.Add(floc);
                }
                else if (floc.Type < FunctionalLocationType.Level3)
                {
                    List<FunctionalLocationInfo> childFlocs = functionalLocationInfoService.QueryByParentFunctionalLocation(floc);
                    GetCheckableFlocs(checkableFlocs, childFlocs.ConvertAll(obj => obj.Floc));
                }
            }
        }

        public IFunctionalLocationValidator FlocValidator { set; private get; }

    }
}

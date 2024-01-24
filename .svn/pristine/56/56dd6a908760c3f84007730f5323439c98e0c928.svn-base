using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConvertLogBasedDirectivesIntoNewDirectivesFormPresenter :
        BaseFormPresenter<IConvertLogBasedDirectivesIntoNewDirectivesView>
    {
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly long siteId;
        private ConvertLogBasedDirectivesProgressForm progressForm;
        private List<FunctionalLocation> selectedFunctionalLocations;

        public ConvertLogBasedDirectivesIntoNewDirectivesFormPresenter()
            : base(new ConvertLogBasedDirectivesIntoNewDirectivesForm())
        {
            var clientServiceRegistry = ClientServiceRegistry.Instance;

            functionalLocationService = clientServiceRegistry.GetService<IFunctionalLocationService>();

            siteId = ClientSession.GetUserContext().SiteId;

            var userContext = ClientSession.GetUserContext();

            var topLevelFlocsForSite = GetTopLevelFlocsForSite();

            var flocSelector =
                new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAdmin(userContext.SiteConfiguration),
                    new FunctionalLocationIsTopLevelFilter(),
                    true, topLevelFlocsForSite);

            view.FlocSelector = flocSelector;

            view.FormLoad += HandleFormLoad;
            view.AcceptCheckboxChanged += HandleAcceptCheckboxChanged;
            view.ContinueClicked += HandleContinueClicked;

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationClicked;
        }

        private List<FunctionalLocation> GetTopLevelFlocsForSite()
        {
            var flocInfo = new FunctionalLocationLookup().GetChildrenFor(siteId);

            return flocInfo.Select(info => info.Floc).ToList();
        }

        private void HandleAddFunctionalLocationClicked()
        {
            var result = view.ShowFunctionalLocationSelector(view.FunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null
                    ? new List<FunctionalLocation>()
                    : new List<FunctionalLocation>(newFlocList);
            }
        }

        private void HandleRemoveFunctionalLocationClicked()
        {
            var floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                var associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
            }
        }

        private void HandleFormLoad()
        {
            view.SiteName = ClientSession.GetUserContext().Site.Name;
            view.ContinueButtonEnabled = false;
        }

        private void HandleAcceptCheckboxChanged()
        {
            view.ContinueButtonEnabled = view.AcceptChecked;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Convert Log Based Directives into New Directives - {0}", site.IdValue);
        }

        private bool ViewHasErrorsAndErrorMessagesSet()
        {
            var hasErrors = false;

            view.ClearErrorProviders();

            if (view.FunctionalLocations.IsNullOrEmpty())
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasErrors = true;
            }

            return hasErrors;
        }

        private void HandleContinueClicked()
        {
            if (ViewHasErrorsAndErrorMessagesSet()) return;

            selectedFunctionalLocations = view.FunctionalLocations;

            progressForm = new ConvertLogBasedDirectivesProgressForm();
            progressForm.OkButtonClick += form =>
            {
                form.Close();
                view.Close();
            };
            progressForm.Shown += HandleProgressFormShown;

            progressForm.StartPosition = FormStartPosition.Manual;
            progressForm.Location = view.GetCenterParentLocation(progressForm);

            progressForm.ShowDialog(view);
            progressForm.Dispose();
        }

        private void HandleProgressFormShown(object sender, EventArgs eventArgs)
        {
            new BackgroundHelper<long, string>(new ClientBackgroundWorker(),
                new ConversionPerformer(progressForm, selectedFunctionalLocations)).Run(
                    siteId);
        }

        private class ConversionPerformer : IBackgroundingFriendly<long, string>
        {
            private readonly IDirectiveConversionService directiveConversionService;
            private readonly List<FunctionalLocation> functionalLocations;
            private readonly ConvertLogBasedDirectivesProgressForm progressForm;

            public ConversionPerformer(ConvertLogBasedDirectivesProgressForm progressForm,
                List<FunctionalLocation> functionalLocations)
            {
                this.progressForm = progressForm;
                this.functionalLocations = functionalLocations;
                directiveConversionService = ClientServiceRegistry.Instance.GetService<IDirectiveConversionService>();
            }

            public string DoWork(long siteId)
            {
                var selectedLevel1Flocs = functionalLocations;

                foreach (var functionalLocation in selectedLevel1Flocs)
                {
                    var numberOfBatches = directiveConversionService.QueryNumberOfBatches(siteId, functionalLocation);

                    if (numberOfBatches > 0)
                    {
                        ShowUpdate(
                            string.Format(
                                "Converting log-based directives into new directives for functional location {0}...",
                                functionalLocation.FullHierarchy));
                    }

                    for (var i = 0; i < numberOfBatches; i++)
                    {
                        ShowUpdate(String.Format("Converting batch {0} of {1} for functional location {2}...", i + 1,
                            numberOfBatches, functionalLocation.FullHierarchy));
                        directiveConversionService.SwitchFromLogBasedDirectives(siteId, i, functionalLocation);
                    }

                    ShowUpdate(
                        string.Format(
                            "Converting standing orders to directives and then cancelling them for functional location {0}...",
                            functionalLocation));
                    directiveConversionService.ConvertStandingOrdersToDirectiveAndThenCancelThem(siteId,
                        functionalLocation);
                }

                return null;
            }

            public void BeforeDoingWork()
            {
                progressForm.ControlBox = false;
            }

            public void AfterDoingWork()
            {
                ShowUpdate("Done!");
                progressForm.OkButtonEnabled = true;
            }

            public void WorkSuccessfullyCompleted(string result)
            {
            }

            public void OnError(Exception e)
            {
                throw new Exception("Error converting log-based directives into new directives", e);
            }

            public void WorkCompletedOrCancelled()
            {
                progressForm.ControlBox = true;
            }

            private void ShowUpdate(string message)
            {
                progressForm.Invoke(new Action<string>(progressForm.AppendText), message);
            }
        }
    }
}
using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SwitchFromLogBasedDirectivesFormPresenter : BaseFormPresenter<ISwitchFromLogBasedDirectivesView>
    {
        private readonly long siteId;
        private SwitchFromLogBasedDirectivesProgressForm progressForm;

        public SwitchFromLogBasedDirectivesFormPresenter() : base(new SwitchFromLogBasedDirectivesForm())
        {
            siteId = ClientSession.GetUserContext().SiteId;

            view.FormLoad += HandleFormLoad;
            view.AcceptCheckboxChanged += HandleAcceptCheckboxChanged;
            view.ContinueClicked += HandleContinueClicked;
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
            return string.Format("Switch From Log Based Directives - {0}", site.IdValue);
        }

        private void HandleContinueClicked()
        {
            progressForm = new SwitchFromLogBasedDirectivesProgressForm();
            progressForm.OkButtonClick += form => { form.Close(); view.Close(); };
            progressForm.Shown += HandleProgressFormShown;

            progressForm.StartPosition = FormStartPosition.Manual;
            progressForm.Location = view.GetCenterParentLocation(progressForm);

            progressForm.ShowDialog(view);
            progressForm.Dispose();
        }

        private void HandleProgressFormShown(object sender, EventArgs eventArgs)
        {
            new BackgroundHelper<long, string>(new ClientBackgroundWorker(), new ConversionPerformer(progressForm)).Run(siteId);
        }

        private class ConversionPerformer : IBackgroundingFriendly<long, string>
        {
            private readonly SwitchFromLogBasedDirectivesProgressForm progressForm;
            private readonly IDirectiveConversionService directiveConversionService;

            public ConversionPerformer(SwitchFromLogBasedDirectivesProgressForm progressForm)
            {
                this.progressForm = progressForm;
                directiveConversionService = ClientServiceRegistry.Instance.GetService<IDirectiveConversionService>();
            }

            public string DoWork(long siteId)
            {
                ShowUpdate("Updating site configuration and roles...");
                directiveConversionService.ChangeSiteConfigurationAndUpdateRolesToSupportNonLogBasedDirectives(siteId);

                int numberOfBatches = directiveConversionService.QueryNumberOfBatches(siteId);

                if (numberOfBatches > 0)
                {
                    ShowUpdate("Converting log-based directives to new directives...");
                }

                for (int i = 0; i < numberOfBatches; i++)
                {
                    ShowUpdate(String.Format("Converting batch {0} of {1}...", i + 1, numberOfBatches));
                    directiveConversionService.SwitchFromLogBasedDirectives(siteId, i);
                }

                ShowUpdate("Converting standing orders to directives and then cancelling them...");
                directiveConversionService.ConvertStandingOrdersToDirectiveAndThenCancelThem(siteId);

                ShowUpdate("Removing default tab settings involving directives...");
                directiveConversionService.RemoveDefaultTabSettings(siteId);

                ShowUpdate("Removing 'applies to daily directives' selection from custom field groups...");
                directiveConversionService.UpdateCustomFieldGroups(siteId);

                return null;
            }

            private void ShowUpdate(string message)
            {
                progressForm.Invoke(new Action<string>(progressForm.AppendText), message);
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
                throw new Exception("Error converting directives", e);
            }

            public void WorkCompletedOrCancelled()
            {
                progressForm.ControlBox = true;
            }
        }

    }
}

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
    public class EnableSecurityForNewDirectivesFormPresenter : BaseFormPresenter<IEnableSecurityForNewDirectivesView>
    {
        private readonly long siteId;
        private ConvertLogBasedDirectivesProgressForm progressForm;

        public EnableSecurityForNewDirectivesFormPresenter()
            : base(new EnableSecurityForNewDirectivesForm())
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
            return string.Format("Enable Security for New Directives - {0}", site.IdValue);
        }

        private void HandleContinueClicked()
        {
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
            new BackgroundHelper<long, string>(new ClientBackgroundWorker(), new ConversionPerformer(progressForm)).Run(
                siteId);
        }

        private class ConversionPerformer : IBackgroundingFriendly<long, string>
        {
            private readonly IDirectiveConversionService directiveConversionService;
            private readonly ConvertLogBasedDirectivesProgressForm progressForm;

            public ConversionPerformer(ConvertLogBasedDirectivesProgressForm progressForm)
            {
                this.progressForm = progressForm;
                directiveConversionService = ClientServiceRegistry.Instance.GetService<IDirectiveConversionService>();
            }

            public string DoWork(long siteId)
            {
                ShowUpdate("Updating site configuration and roles...");
                directiveConversionService.ChangeSiteConfigurationAndUpdateRolesToSupportNonLogBasedDirectives(siteId);

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
                throw new Exception("Error enabling security for new directives", e);
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
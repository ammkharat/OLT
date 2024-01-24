using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CokerCardFormLauncher
    {
        private readonly IMainForm mainView;
        private readonly IObjectLockingService objectLockingService;
        private readonly ICokerCardService cokerCardService;                

        public CokerCardFormLauncher(IMainForm mainView)
        {
            this.mainView = mainView;
            objectLockingService = ClientServiceRegistry.Instance.GetService<IObjectLockingService>();
            cokerCardService = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
        }


        public void AttemptLaunch()
        {
            // get all the configurations available
            UserContext userContext = ClientSession.GetUserContext();
            List<CokerCardConfiguration> configurations = cokerCardService.QueryCokerCardConfigurationsByExactFlocMatch(
                new ExactFlocSet(userContext.DivisionsAndSectionsForSelectedFunctionalLocations));

            if (configurations.Count == 0)
            {
                OltMessageBox.Show(Form.ActiveForm,
                                   StringResources.CokerCardNotConfiguredMessageBoxText,
                                   StringResources.CokerCardNotConfiguredMessageBoxCaption,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information,
                                   ContentAlignment.MiddleLeft);
            }

            else if (configurations.Count > 1)
            {
                // pop up selector
                ICokerCardConfigurationSelectionView newForm = new CokerCardConfigurationSelectionForm();
                DialogResult dialogResult = newForm.ShowDialog(mainView);

                if (DialogResult.OK == dialogResult)
                {
                    CokerCardConfiguration configuration = newForm.SelectedCokerCardConfiguration;
                    CheckForExistingCokerCardBeforeOpeningForm(configuration);
                }
            }
            else
            {
                CheckForExistingCokerCardBeforeOpeningForm(configurations[0]);
            }
        }

        private void CheckForExistingCokerCardBeforeOpeningForm(CokerCardConfiguration cokerCardConfiguration)
        {
            CokerCard existingCokerCard = cokerCardService.QueryCokerCardByConfigurationAndShift(
                cokerCardConfiguration.IdValue, ClientSession.GetUserContext().UserShift);

            if (existingCokerCard == null)
            {
                SetLockWhileInUse(cokerCardConfiguration, null);
            }

            else
            {
                DialogResult result = DisplayCokerCardExistsMessageAndAskUserIfExistingShouldBeEdited(mainView);
                if (result == DialogResult.Yes)
                {
                    mainView.SelectSectionAndItem(SectionKey.LogSection, new CokerCardDTO(existingCokerCard), true);
                    SetLockWhileInUse(cokerCardConfiguration, existingCokerCard);
                }
                else
                {
                    // cancel, do nothing
                    return;
                }
            }
        }

        public static string LockIdentifier(long cokerCardConfigurationId)
        {
            return string.Format("{0}-{1}", typeof(CokerCardConfiguration), cokerCardConfigurationId);
        }

        private void SetLockWhileInUse(CokerCardConfiguration configuration, CokerCard cokerCard)
        {
            User user = ClientSession.GetUserContext().User;

            string cokerCardLockIdentifier = cokerCard == null
                ? LockIdentifier(configuration.IdValue) : LockIdentifier(cokerCard.ConfigurationId);

            ObjectLockResult lockOnCokerCard = objectLockingService.GetLock(cokerCardLockIdentifier, user.IdValue, ClientSession.GetInstance().GuidAsString);

            bool lockAquired = lockOnCokerCard.Succeeded;

            if (lockAquired)
            {
                try
                {
                    CokerCardForm cokerCardForm = new CokerCardForm(configuration.IdValue, cokerCard);
                    cokerCardForm.ShowDialog(mainView);
                    cokerCardForm.Dispose();
                }
                finally
                {
                    objectLockingService.ReleaseLock(cokerCardLockIdentifier, user.IdValue);
                }
            }
            else
            {
                LaunchLockDeniedBecauseCokerCardForConfigurationInEdit(lockOnCokerCard.LockedByUserName);
            }
        }

        private DialogResult DisplayCokerCardExistsMessageAndAskUserIfExistingShouldBeEdited(IMainForm form)
        {
            DialogResult result = OltMessageBox.ShowCustomYesNo(
                (Form)form,
                StringResources.CokerCardAlreadyExists,
                StringResources.CokerCardAlreadyExistsTitle,
                MessageBoxIcon.Asterisk,
                StringResources.EditExistingCokerCard,
                StringResources.CancelExistingCokerCardDialog);
            return result;
        }

        private void LaunchLockDeniedBecauseCokerCardForConfigurationInEdit(string nameOfUserThatIsCurrentlyEditing)
        {
            OltMessageBox.Show(Form.ActiveForm,
                               string.Format(StringResources.EditDeniedMessage, nameOfUserThatIsCurrentlyEditing),
                               StringResources.EditDeniedTitle,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
    }

    }
}
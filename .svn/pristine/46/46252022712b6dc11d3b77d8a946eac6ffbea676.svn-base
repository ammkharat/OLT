using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitPrintPreferencesFormPresenter : BaseFormPresenter<IWorkPermitPrintPreferencesFormView>
    {
        private readonly IUserService userService;

        public WorkPermitPrintPreferencesFormPresenter() : base(new WorkPermitPrintPreferencesForm())
        {
            userService = ClientServiceRegistry.Instance.GetService<IUserService>();

            view.SaveButtonClicked += HandleSaveButtonClicked;
            view.CancelButtonClicked += CancelButton_Click;
        }

        private void HandleSaveButtonClicked()
        {
            // This is weird, but it's how the control currently works. It will update the User object in the ClientSession for us.
            view.UpdatePreferences();

            User user = ClientSession.GetUserContext().User;

            UserPrintPreference saved = userService.UpdatePrintPreferences(user);
            if (user.WorkPermitPrintPreference.Id == null)
            {
                user.WorkPermitPrintPreference.Id = saved.Id;
            }

            view.Close();
        }
    }
}


namespace Com.Suncor.Olt.Client.Forms
{
    public interface IBaseForm : IForm
    {
        void ShowWaitScreenAndDisableForm();
        void CloseWaitScreenAndEnableForm();
        void SetFormVisibleState(bool visible);
        bool ConfirmCancelDialog();
        void SaveFailedMessage();
        void SaveSucceededMessage();
        void ShowMessageBox(string title, string error);

        void UpdateTitleAsCreateOrEdit(bool isEdit, string titleText);
    }
}
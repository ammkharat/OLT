namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureWorkPermitArchivalProcessForm : IBaseForm
    {
        string SiteName { set; }

        int DaysBeforeArchivingClosedWorkPermits { set; get; }
        int DaysBeforeDeletingPendingWorkPermits { set; get; }
        int DaysBeforeClosingIssuedWorkPermits { set; get; }

        void ShowDaysBeforeArchivingClosedWorkPermitsError(string message);
        void ShowDaysBeforeDeletingPendingWorkPermitsError(string message);
        void ShowDaysBeforeClosingIssuedWorkPermitsError(string message);
        void ClearErrorMessages();
    }
}

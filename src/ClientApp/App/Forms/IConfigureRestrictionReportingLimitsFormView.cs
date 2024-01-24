namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureRestrictionReportingLimitsFormView
    {
        string SiteName { set; }
        string DaysToEditDeviationAlerts { set; get; }
        void CloseForm();
        void SetErrorForDaysToEditDeviationAlerts(string errorMessage);
        void ClearErrors();
    }
}
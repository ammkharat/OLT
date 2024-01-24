namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISiteConfigurationFormView
    {
        string SiteName { set; }
        string DaysToDisplayActionItems { set; get; }
        string DaysToDisplayShiftLogs { set; get; }
        string DaysToDisplayShiftHandovers { get; set; }
        string DaysToDisplayDeviationAlerts { get; set; }
        string DaysToDisplayWorkPermitsBackwards { get; set; }
        string DaysToDisplayWorkPermitsForwards { get; set; }
        string DaysToDisplayLabAlerts { get; set; }
        string DaysToDisplayCokerCards { get; set; }
        string DaysToDisplayPermitRequestsBackwards { get; set; }
        string DaysToDisplayPermitRequestsForwards { get; set; }
        string DaysToDisplayElectronicFormsBackwards { get; set; }
        string DaysToDisplayElectronicFormsForwards { get; set; }
        string DaysToDisplaySAPNotificationsBackwards { get; set; }
        string DaysToDisplayDirectivesBackwards { get; set; }
        string DaysToDisplayDirectivesForwards { get; set; }
        string DaysToDisplayDocumentSuggestionFormsBackwards { get; set; }
        string DaysToDisplayDocumentSuggestionFormsForwards { get; set; }

        bool ActionItemConfigurationVisible { set; }
        bool CokerCardConfigurationVisible { set; }
        bool DeviationConfigurationVisible { set; }
        bool LabAlertConfigurationVisible { set; }
        bool PermitConfigurationVisible { set; }
        bool ShiftHandoverConfigurationVisible { set; }
        bool LogConfigurationVisible { set; }
        bool ElectronicFormsVisible { set; }
        bool DirectiveConfigurationVisible { set; }
        bool EventsConfigurationVisible { set; }
        string DaysToDisplayEvents { get; set; }
        bool DocumentSuggestionConfigurationVisible { set; }

        void CloseForm();
        void SetErrorForActionItems(string errorMessage);
        void SetErrorForShiftLogs(string errorMessage);
        void SetErrorForShiftHandovers(string pleaseEnterAValueGreaterThan);
        void SetErrorForDeviationAlerts(string errorMessage);
        void SetErrorForLabAlerts(string errorMessage);
        void SetErrorForCokerCards(string pleaseEnterAValueGreaterThan);
        void ClearErrors();
        void SetErrorForEvents(string displayLimitsValueMustBeGreaterThanZeroError);
    }
}
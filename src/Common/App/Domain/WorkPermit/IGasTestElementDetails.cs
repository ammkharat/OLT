namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public interface IGasTestElementDetails
    {
        long? GasTestElementInfoId { get; set; }
        string ElementName { set; get; }
        string ElementNameOther { set; get; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        
        string Limits { set; get; }
        double? ImmediateAreaTestResult { get; set; }
        bool ImmediateAreaTestRequired { get; set; }
        double? ConfinedSpaceTestResult { get; set; }
        bool ConfinedSpaceTestRequired { get; set; }
        bool ConfinedSpaceTestRequiredEnabledDisabled { get; set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        bool ImmediateAreaTestRequiredEnabledDisabled { get; set; } // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        
        
        bool IsStandard { get; set; }
        bool SystemEntryTestNotApplicable { get; set; }
        double? SystemEntryTestResult { get; set; }
        void ClearWarningMessages();
        void SetImmediateAreaResultWarningMessage(string message);
        void SetConfinedSpaceTestResultWarningMessage(string message);
        void SetConfinedSpaceTestResultAlertMessage(string message);  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        void SetImmediateAreaResultAlertMessage(string message);  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        
        
        void SetSystemEntryTestResultWarningMessage(string message);

        
        
        
    }
}
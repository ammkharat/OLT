using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitFortHillsView : IWorkPermitFortHillsSharedView
    {
        List<WorkPermitFortHillsType> AllPermitTypes { set; }
        List<CraftOrTrade> AllCraftOrTrades { set; }
        event Action FunctionalLocationBrowseClicked;
        event Action FormLoad;
        event Action SaveAndIssueButtonClicked;
        event Action PrintPreferencesButtonClicked;
        event Action ValidateButtonClicked;
        event Action GroupChanged;
        event Action ExpireTimeChangedByUser;
        

        
       // new bool IssuedToContractor { get; set; }

        bool WorkOrderNumberReadOnly { set; }
        bool OperationNumberReadOnly { set; }
        bool SubOperationNumberReadOnly { set; }
        string EmergencyAssemblyArea { get; set; }
        string EmergencyMeetingPoint { get; set; }
        string EmergencyContactNo { get; set; }
        string LockBoxNumber { get; set; }
        string IsolationNo { get; set; }
        FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector();
        DateTime RequestedStartDateTime { get; set; }        
        DateTime ExpiryDateTime { get; set; }
        DateTime? RevalidationDateTime { get; set; }
        DateTime? ExtensionDateTime  { get; set; }
        string PermitNumber { get; set; }
        bool IsolationNoEnabled {  set; }
        bool ExtensionDateTimeEnable { get; set; }
        bool ExtensionDateTimeVisible { get; set; }
        string ExtensionComments { get; set; }
        // bool RevalidationDateTimeEnable { set; }
        bool LockBoxNumberEnabled { set; }
        List<Contractor> AllCompanies { set; }
        List<WorkPermitFortHillsGroup> AllGroups { set; }
        

        //Part F data
        bool PartFWorkSectionNotApplicableToJob { get; set; }
        bool MechanicallyIsolated { get; set; }
        bool BlindedOrBlanked { get; set; }
        bool DoubleBlockedandBled { get; set; }
        bool DrainedAndDepressurised { get; set; }
        bool PurgedorNeutralised { get; set; }
        bool ElectricallyIsolated { get; set; }
        bool TestBumped { get; set; }
        bool NuclearSource { get; set; }
        bool ReceiverStafingRequirements { get; set; }

        //Part G data
        bool PartGWorkSectionNotApplicableToJob { get; set; }
        bool PartGWorkSectionNotApplicableToJobEnabled { get; set; }
        string Frequency { get; set; }
        bool Continuous { get; set; }
        string TesterName { get; set; }
        bool Oxygen { get; set; }
        bool LEL { get; set; }
        bool H2SPPM { get; set; }
        bool CoPPM { get; set; }
        bool SO2PPM { get; set; }
        bool Other1PartG { get; set; }
        string Other1PartGValue { get; set; }
        bool Other2PartG { get; set; }
        string Other2PartGValue { get; set; }

       string PermitIssuer  { get; set; }
       string AreaAuthority  { get; set; }
       string CoAuthorizingIssuer  { get; set; }
       string AddationalAuthority  { get; set; }
       string PermitIssuerContact  { get; set; }
       string AreaAuthorityContact  { get; set; }
       string CoAuthorizingIssuerContact  { get; set; }
       string AddationalAuthorityContact  { get; set; }
       bool IsFieldTourRequired { get; set; }
       bool IsFieldTourRequiredEnabled { get; set; }
       string FieldTourConductedBy { get; set; }
        
        void ShowIsValidMessageBox();
        void ShowHasValidationErrorsMessageBox();
        void ShowHasValidationWarningsMessageBox();
        void ShowHasValidationWarningsAndErrorsMessageBox();
        void SetErrorForExpiryDateTimeInThePast();
        //void SetErrorForNoIssuedToOptionSelected();
        void SetErrorForNoHazardsAndOrRequirements();
        void SetErrorForHazardsTooLong();
        void SetErrorForEmergencyDetails();
       
       
        bool IsEdit { get; set; }
        bool IsExtension { get; set; }
        bool IsClone { get; set; }
        
        void ForceExecutionOfBusinessLogic();
        DialogResult ShowWarnings(WorkPermitFortHillsOtherWarnings otherWarnings, bool validationWarning);
               List<DocumentLink> DocumentLinks { get; set; }
      

        string PermitAcceptor { get; set; }        
        
        List<Priority> Priorities { set; }
        Priority Priority { get; set; }
       
        bool SaveAndIssueButtonEnabled { set; }

        void TurnOnAutosetIndicatorsForDateTimes();
    

        void DisplayInvalidPrintMessage(string message);
        void DisplayErrorMessageDialog(string message, string title);
        void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations);
        void DisableAllcontrolsforExtension();
        void SetErrorForLockBoxNumberandisolationNo();
        void SetErrorForNoEquipmentNo();
        void SetErrorForIsFieldTourRequiredYes();
        void SetErrorForOther1PartGCheckedWithNoValue();
        void SetErrorForOther2PartGCheckedWithNoValue();

        void SetErrorForPartCOptionNotChosen();
        void SetErrorForPartEOptionNotChosen();
        void SetErrorForPartFOptionNotChosen();
        void SetErrorForPartGOptionNotChosen();


        

    }
}
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICloneWorkPermitFormView
    {
        string WorkPermitNumber { set; }
        bool ClonePermitTypeAttributes { get; set; }
        bool CloneAdditionalForms { get; set; }
        bool CloneLocationJobSpecifics { get; set; }
        bool CloneTools { get; set; }
        bool CloneEquipmentPreparationCondition { get; set; }
        bool CloneJobWorksitePreparation { get; set; }
        bool CloneCommunicationMethod { get; set; }
        bool CloneRadiationInformation { get; set; }
        bool CloneAsbestos { get; set; }
        bool CloneFireConfinedSpaceRequirements { get; set; }
        bool CloneRespiratoryProtectionRequirements { get; set; }
        bool CloneSpecialPPERequirements { get; set; }
        bool CloneSpecialPrecautionsOrConsiderations { get; set; }
        bool CloneGasTests {get; set;}
        bool CloneNotificationAuthorization { get; set; }
        bool CloneMiscellaneous { get; set; }
        
        bool ClonePermitTypeAttributesEnabled { set; }
        bool CloneAdditionalFormsEnabled { set; }
        bool CloneLocationJobSpecificsEnabled { set; }
        bool CloneToolsEnabled { set; }
        bool CloneEquipmentPreparationConditionEnabled { set; }
        bool CloneJobWorksitePreparationEnabled { set; }
        bool CloneCommunicationMethodEnabled { set; }
        bool CloneRadiationInformationEnabled { set; }
        bool CloneAsbestosEnabled { set; }
        bool CloneFireConfinedSpaceRequirementsEnabled { set; }
        bool CloneRespiratoryProtectionRequirementsEnabled { set; }
        bool CloneSpecialPPERequirementsEnabled { set; }
        bool CloneSpecialPrecautionsOrConsiderationsEnabled { set; }
        bool CloneGasTestsEnabled { set;}
        bool CloneNotificationAuthorizationEnabled { set; }
        bool CloneMiscellaneousEnabled { set; }
        
        WorkPermit OriginalWorkPermit{get; set;}
        WorkPermit ClonedWorkPermit { get; set;}
        bool ShowCommunicationMethod { get; set; }
        bool ShowTools { get; set;  }
        bool ShowRadiation { get; set;  }
        bool ShowAsbestos { get; set;  }
        DialogResult ShowDialog(IWin32Window owner); 
    }
}

using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICopyWorkPermitFormView
    {
        event EventHandler LoadView;
        event EventHandler Copy;
        event EventHandler Cancel;
        event EventHandler SelectAllSections;
        event EventHandler DeselectAllSections;
        bool ToolsChecked { get; set; }
        bool EquipmentPreparationConditionChecked { get; set; }
        bool JobWorksitePreparationChecked { get; set; }
        bool RadiationInformationChecked { get; set; }
        bool AsbestosChecked { get; set; }
        bool FireConfinedSpaceRequirementsChecked { get; set; }
        bool RespiratoryProtectionRequirementsChecked { get; set; }
        bool SpecialPPERequirementsChecked { get; set; }
        bool SpecialPrecautionsOrConsiderationsChecked { get; set; }
        bool GasTestsChecked { get; set; }
        bool NotificationAuthorizationChecked { get; set; }
        bool MiscellaneousChecked { get; set; }
        bool CommunicationMethodChecked { get; set; }
        bool ToolsEnabled { set; }
        bool EquipmentPreparationConditionEnabled { set; }
        bool JobWorksitePreparationEnabled { set; }
        bool RadiationInformationEnabled { set; }
        bool AsbestosEnabled { set; }
        bool FireConfinedSpaceRequirementsEnabled { set; }
        bool RespiratoryProtectionRequirementsEnabled { set; }
        bool SpecialPPERequirementsEnabled { set; }
        bool SpecialPrecautionsOrConsiderationsEnabled { set; }
        bool GasTestsEnabled { set; }
        bool NotificationAuthorizationEnabled { set; }
        bool MiscellaneousEnabled { set; }
        bool ShowCommunicationMethod { set; }
        bool CommunicationMethodEnabled { set; }
        bool ShowTools { set; }
        bool ShowRadiation { set; }
        bool ShowAsbestos { set; }
        string WorkPermitNumber { set; }
        void CloseView();
        bool ConfirmCancelDialog();
        DialogResult ShowDialog(string text, string caption);
        DialogResult ShowDialog(IWin32Window form);
    }
}
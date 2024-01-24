using System.Collections.Generic;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface IWorkPermitPrintPreferenceTabPage: IPreferenceTabPage
    {
        List<string> AvailablePrinters { set;}
        string PrinterName { get; set;}

        int NumberOfCopies { get; set;}        
        int NumberOfTurnaroundCopies { get; set; }
        
        List<int> NumberOfCopiesValueList { set; }
        List<int> NumberOfTurnaroundCopiesValueList { set; }

        bool ShowPrintDialog { get; set; }
        bool ShowShiftHandoverAlertDialog { get; set; } //RITM0387753-Shift Handover creation alert(Aarti)

        bool NumberOfCopiesVisible { set; }        
        bool NumberOfTACopiesVisible { set; }

        bool IsDesignMode { get; }

        bool ShowAlternativeNumberOfCopiesLabel { set; }

        bool SoundAlertEnable { get; set; }
    }
}
using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class UserPrintPreference : DomainObject
    {
        private const int DEFAULT_NUM_COPIES = 1;
            // Note: this value is overwritten based on what's in SiteConfiguration in the UserContext.

        private const int DEFAULT_NUM_TA_COPIES = 3;

        private readonly long userId;
        private int numberOfCopies;
        private int numberOfTurnaroundCopies;
        private string printerName;
        private bool showPrintDialog;
        private bool showShiftHandoverAlertDialog;
        private bool showSoundAlertforActionItemDirectiveTargets;
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 3 - 03-Oct-2018 start 
        private bool jobsiteEquipmentInspected;
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 3 - 03-Oct-2018 end
        public UserPrintPreference(long userId)
            : this(null, userId, null, DEFAULT_NUM_COPIES, DEFAULT_NUM_TA_COPIES, true,true,true)
        {
        }
        

        public UserPrintPreference(long? id, long userId, string printerName, int numberOfCopies,
            int numberOfTurnaroundCopies, bool showPrintDialog, bool showShiftHandoverAlertDialog, bool showSoundAlertforActionItemDirectiveTargets)
        {
            this.id = id;
            this.userId = userId;
            this.printerName = printerName;
            this.numberOfCopies = numberOfCopies;
            this.numberOfTurnaroundCopies = numberOfTurnaroundCopies;
            this.showPrintDialog = showPrintDialog;
            this.showShiftHandoverAlertDialog = showShiftHandoverAlertDialog;//RITM0387753-Shift Handover creation alert(Aarti)
            this.showSoundAlertforActionItemDirectiveTargets = showSoundAlertforActionItemDirectiveTargets;
        }

        public long UserId
        {
            get { return userId; }
        }

        public int NumberOfCopies
        {
            get { return numberOfCopies; }
            set { numberOfCopies = value; }
        }

        public int NumberOfTurnaroundCopies
        {
            get { return numberOfTurnaroundCopies; }
            set { numberOfTurnaroundCopies = value; }
        }

        public bool ShowPrintDialog
        {
            get { return showPrintDialog; }
            set { showPrintDialog = value; }
        }

        //RITM0387753-Shift Handover creation alert(Aarti)
        public bool ShowShiftHandoverAlertDialog
        {
            get { return showShiftHandoverAlertDialog; }
            set { showShiftHandoverAlertDialog = value; }
        }

        public string PrinterName
        {
            get { return printerName; }
            set { printerName = value; }
        }
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 3 - 03-Oct-2018 start 
        public bool JobsiteEquipmentInspected {
            get { return jobsiteEquipmentInspected; }
            set { jobsiteEquipmentInspected = value; }
        }
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 3 - 03-Oct-2018 end

        public bool SoundAlertEnable  // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
        {
            get { return showSoundAlertforActionItemDirectiveTargets; }
            set { showSoundAlertforActionItemDirectiveTargets = value; }
        }
    }
}
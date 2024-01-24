using System.Collections.Generic;
using System.Drawing.Printing;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitPrintPreferenceTabPagePresenter
    {
        private readonly string defaultPrinter = StringResources.DefaultPrinter;

        private readonly IWorkPermitPrintPreferenceTabPage tabPage;

        private readonly UserContext userContext;

        public WorkPermitPrintPreferenceTabPagePresenter(IWorkPermitPrintPreferenceTabPage tabPage)
        {
            this.tabPage = tabPage;
            userContext = ClientSession.GetUserContext();
        }

        public void HandleFormLoad()
        {
            if (tabPage.IsDesignMode)
            {
                return;
            }

            List<string> installedPrinters = GetInstalledPrinters();

            tabPage.AvailablePrinters = installedPrinters;
            
            UserPrintPreference workPermitPrintPreference = userContext.User.WorkPermitPrintPreference;

            string printerName = workPermitPrintPreference.PrinterName;
            // make sure the printer in the user's preferences still exists as an installed printer before trying to select it.
            if (printerName.HasValue() && installedPrinters.Exists(p => string.Equals(p, printerName)))
            {
                tabPage.PrinterName = printerName;
            }
            else
            {
                tabPage.PrinterName = defaultPrinter;
            }

            tabPage.NumberOfCopiesValueList = GetNumberOfRunningUnitCopies();
            tabPage.NumberOfTurnaroundCopiesValueList = new List<int> { 2, 3 };

            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 4 - 03-Oct-2018 start
            //tabPage.NumberOfCopies = workPermitPrintPreference.NumberOfCopies;
            if (workPermitPrintPreference.JobsiteEquipmentInspected)
            {
                tabPage.NumberOfCopies = GetNumberOfRunningUnitCopies()[1];//29-Oct-2018 //Dharmesh // DMND0009363--#950322732
            }
            else
            {
                tabPage.NumberOfCopies = GetNumberOfRunningUnitCopies()[0];//29-Oct-2018 //Dharmesh // DMND0009363--#950322732
            }
            userContext.User.WorkPermitPrintPreference.NumberOfCopies = tabPage.NumberOfCopies; //29-Oct-2018 //Dharmesh // DMND0009363--#950322732
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 4 - 03-Oct-2018 start

            tabPage.NumberOfTurnaroundCopies = workPermitPrintPreference.NumberOfTurnaroundCopies;

            tabPage.ShowPrintDialog = workPermitPrintPreference.ShowPrintDialog;
            tabPage.ShowShiftHandoverAlertDialog = workPermitPrintPreference.ShowShiftHandoverAlertDialog;//RITM0387753-Shift Handover creation alert(Aarti)
            tabPage.SoundAlertEnable = workPermitPrintPreference.SoundAlertEnable;  // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
            tabPage.NumberOfCopiesVisible = userContext.SiteConfiguration.ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab;
            bool showTALine = userContext.SiteConfiguration.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab;
            tabPage.NumberOfTACopiesVisible = showTALine;

            // If we're showing the Turnaround line, use the alternative label text for the regular stuff, to match the Turnaround label.
            tabPage.ShowAlternativeNumberOfCopiesLabel = showTALine;                     
        }

        private List<int> GetNumberOfRunningUnitCopies()
        {
            // I just made this up to have a way to know how to get Edmonton to have the alternate default list without hardcoding it. The turnaround stuff is for Edmonton so this seems reasonable for now.
            if(userContext.SiteConfiguration.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab)
            {
                return new List<int> {2, 3};
            }

            return CreateNumberOfCopiesList();
        }

        private static List<int> CreateNumberOfCopiesList()
        {
            var list = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                list.Add(i);
            }
            return list;
        }

        protected virtual List<string> GetInstalledPrinters()
        {
            List<string> list = new List<string> {defaultPrinter};
            PrinterSettings.InstalledPrinters.ForEach<string>(list.Add);
            return list;
        }

        public bool Validate()
        {
            // this tab may not really need validation since they always have to have an option defaulted.
            return true;
        }

        public void Update()
        {
            string printerName = null;
            if (!string.Equals(tabPage.PrinterName, defaultPrinter))
            {
                printerName = tabPage.PrinterName;
            }

            User user = ClientSession.GetUserContext().User;
            user.WorkPermitPrintPreference.PrinterName = printerName;
            user.WorkPermitPrintPreference.NumberOfCopies = tabPage.NumberOfCopies;
            user.WorkPermitPrintPreference.NumberOfTurnaroundCopies = tabPage.NumberOfTurnaroundCopies;
            user.WorkPermitPrintPreference.ShowPrintDialog = tabPage.ShowPrintDialog;
            user.WorkPermitPrintPreference.ShowShiftHandoverAlertDialog = tabPage.ShowShiftHandoverAlertDialog; //RITM0387753-Shift Handover creation alert(Aarti)
            user.WorkPermitPrintPreference.SoundAlertEnable = tabPage.SoundAlertEnable; // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
        }
    }
}
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class EmbeddedRtfPrintControl : UserControl
    {
        private readonly PrintCommandHandler printCommandHandler;
        public event EventHandler Print;


        public EmbeddedRtfPrintControl()
        {
            InitializeComponent();
            InitializePrintButtonEvent();

            printCommandHandler = new PrintCommandHandler();
        }

        private void InitializePrintButtonEvent()
        {
            printButton.ItemClick += printButton_ItemClick;
        }

        void printButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (null != Print)
            {
                Print(sender, e);
            }
        }

        public bool UseCustomPrinting
        {
            get { return printCommandHandler.UseCustomPrinting; }
            set { printCommandHandler.UseCustomPrinting = value; }
        }

        public object ReportSource
        {
            set
            {
                XtraReport report = (XtraReport) value;
                if (report != null)
                {
                    printControl.PrintingSystem = report.PrintingSystem;
                    PrintingSystemBase printingSystemBase = printControl.PrintingSystem;
                    printingSystemBase.ShowMarginsWarning = false;
                    printingSystemBase.ShowPrintStatusDialog = false;
                    printingSystemBase.AddCommandHandler(printCommandHandler);
                }
            }
        }

        protected class PrintCommandHandler : ICommandHandler
        {
            private readonly SplashScreenManager printProgressSplashScreen;

            public bool UseCustomPrinting { get; set; }

            public PrintCommandHandler()
            {
                printProgressSplashScreen = new SplashScreenManager(Form.ActiveForm, typeof(WaitForm), true, true);
            }

            public void HandleCommand(PrintingSystemCommand command, object[] args, IPrintControl printControl, ref bool handled)
            {
                // if UseCustomPrinting is set to true (usually via the designer properties), mark this command as handled so that DevEx's printing functionality doesn't kick in
                if (UseCustomPrinting)
                {
                    handled = true;
                }
                else
                {
                    printControl.PrintingSystem.PrintProgress += OnPrintProgress;
                    printControl.PrintingSystem.EndPrint += OnEndPrint;
                }
            }

            void OnPrintProgress(object sender, PrintProgressEventArgs args)
            {
                if (!printProgressSplashScreen.IsSplashFormVisible)
                {
                    printProgressSplashScreen.ShowWaitForm();
                }

                printProgressSplashScreen.SetWaitFormCaption(StringResources.ReportPrinting_Caption);
                printProgressSplashScreen.SetWaitFormDescription(GetPrintWaitFormDescription(sender, args));
            }

            private string GetPrintWaitFormDescription(object sender, PrintProgressEventArgs args)
            {
                string text;
                if (args.PageSettings.PrinterSettings.PrintRange == PrintRange.AllPages && sender is PrintingSystemBase)
                {
                    PrintingSystemBase printingSystem = sender as PrintingSystemBase;
                    text = string.Format(StringResources.ReportPrinting_Description_Format_With_Total, args.PageIndex + 1, printingSystem.Pages.Count);
                }
                else
                {
                    text = string.Format(StringResources.ReportPrinting_Description_Format, args.PageIndex + 1);
                }
                return text;
            }

            public bool CanHandleCommand(PrintingSystemCommand command, IPrintControl printControl)
            {
                return command == PrintingSystemCommand.Print;
            }

            private void OnEndPrint(object sender, EventArgs e)
            {
                if (printProgressSplashScreen.IsSplashFormVisible)
                {
                    printProgressSplashScreen.CloseWaitForm();
                    printProgressSplashScreen.WaitForSplashFormClose();
                }
            }
        }
    }
}
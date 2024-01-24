using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ReportPrintPreference
    {
        /// <summary>
        /// This is important to set to true in the following example:  A work permit needs to print simplex regardless of what the user's print preferences are.
        /// The paper also has the AST printed on the back, and we don't want to print permit data on the back.
        /// Also, this is required in some cases because you cannot force the duplex setting for networked printers.  Even if you pass Duplex.Simplex to the Print Dialog, the print dialog won't show it.
        /// See:  http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/e70bb393-e4ae-46eb-aba5-c0412b609c02  and
        /// http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/e70bb393-e4ae-46eb-aba5-c0412b609c02
        /// </summary>
        private readonly bool forcePrintBothSidesSetting;
        private readonly PaperKind paperKind;
        private readonly string paperName;
        private readonly string preferredPrinter;
        private readonly bool showPrintDialog;
        private readonly bool printOnBothSides;
        private readonly short numberOfCopies;


        public ReportPrintPreference(XtraReport report, int numberOfCopies, bool printOnBothSides, bool forcePrintBothSidesSetting, string printerName, bool showPrintDialog)
        {
            this.forcePrintBothSidesSetting = forcePrintBothSidesSetting;
            preferredPrinter = SetPrinter(printerName);
            this.showPrintDialog = showPrintDialog;
            paperKind = report.PaperKind;
            paperName = report.PaperName;
            this.numberOfCopies = (short) numberOfCopies;
            this.printOnBothSides = printOnBothSides;
        }

        private string SetPrinter(string printerName)
        {
            if (printerName.HasValue() && InstalledPrinters.Exists(printerName.Equals))
            {
                return printerName;
            }
            return new PrinterSettings().PrinterName;
        }

        private static List<string> InstalledPrinters
        {
            get
            {
                List<string> list = new List<string>();
                PrinterSettings.InstalledPrinters.ForEach<string>(list.Add);
                return list;
            }
        }

        public PrintOptions GetPrintOptionsViaPrintDialog()
        {
            PrintOptions selectedPrintOptions = null;
            if (showPrintDialog)
            {
                PrintDialog printDialog = new PrintDialog
                {
                    UseEXDialog = true,
                    AllowSomePages = false,
                    AllowPrintToFile = false,
                    AllowSelection = false,
                    AllowCurrentPage = false,
                    PrinterSettings =
                    {
                        PrintToFile = false
                    }
                };

                printDialog.Document = new PrintDocument();

                if (preferredPrinter.HasValue())
                {
                    printDialog.PrinterSettings.PrinterName = preferredPrinter;
                    printDialog.Document.PrinterSettings.PrinterName = preferredPrinter;
                }

                if (PrintToLegalSizePaper)
                {
                    PaperSize legalPaperSize = GetLegalPaperSize(preferredPrinter);
                    printDialog.Document.DefaultPageSettings.PaperSize = legalPaperSize;
                    printDialog.PrinterSettings.DefaultPageSettings.PaperSize = legalPaperSize;
                }

                printDialog.PrinterSettings.Copies = numberOfCopies;

                // This doesn't get preserved in the case of a network printer.  See links above..
                printDialog.PrinterSettings.Duplex = printOnBothSides ? Duplex.Vertical : Duplex.Simplex;
                printDialog.Document.PrinterSettings.Duplex = printOnBothSides ? Duplex.Vertical : Duplex.Simplex;

                DialogResult dialogResult = printDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    // copy results from Dialog to PrintOptions and return it.
                    string printerName = printDialog.PrinterSettings.PrinterName;
                    short numberOfCopiesinPrintDialog = printDialog.PrinterSettings.Copies;
                    bool collate = printDialog.PrinterSettings.Collate;
                    PrintRange printRange = printDialog.PrinterSettings.PrintRange;

                    Duplex duplex;
                    if (forcePrintBothSidesSetting)
                    {
                        duplex = printOnBothSides ? Duplex.Vertical : Duplex.Simplex;
                    }
                    else
                    {
                        duplex = printDialog.PrinterSettings.Duplex;
                    }

                    PaperSize paperSize = printDialog.Document.DefaultPageSettings.PaperSize;

                    selectedPrintOptions = new PrintOptions(printerName, numberOfCopiesinPrintDialog, collate, printRange, duplex, paperSize);

                }
            }
            else
            {
                // by-pass printing dialog and use defaults for the user preferences, and report print preferences to print the document.
                selectedPrintOptions = GetDefaultPrintOptions();
            }
            return selectedPrintOptions;
        }


        private PrintOptions GetDefaultPrintOptions()
        {
            Duplex duplex = printOnBothSides ? Duplex.Vertical : Duplex.Simplex;
            PaperSize paperSize = PrintToLegalSizePaper ? GetLegalPaperSize(preferredPrinter) : GetLetterPaperSize(preferredPrinter);
            return new PrintOptions(preferredPrinter, numberOfCopies, false, PrintRange.AllPages, duplex, paperSize);
        }

        private const string LegalPaperName = "Legal";
        private const string LetterPaperName = "Letter";

        private bool PrintToLegalSizePaper
        {
            get { return paperKind == PaperKind.Legal || string.Equals(paperName, LegalPaperName); }
        }

        private PaperSize GetLegalPaperSize(string printerName)
        {
            PrinterSettings printerSettings = new PrinterSettings { PrinterName = printerName };

            PrinterSettings.PaperSizeCollection paperSizeCollection = printerSettings.PaperSizes;

            foreach (PaperSize paperSize in paperSizeCollection)
            {
                // The second check is because French machines use a Custom PaperKind for Legal, but the PaperName is still Legal
                if (PaperKind.Legal.Equals(paperSize.Kind) || LegalPaperName.Equals(paperSize.PaperName))
                {
                    // create a new PaperSize wih the legal paperkind in it.
                    PaperSize legalPaperSize = new PaperSize(paperSize.PaperName, paperSize.Width, paperSize.Height) { RawKind = (int)PaperKind.Legal };
                    return legalPaperSize;
                }
            }
            return default(PaperSize);
        }

        private PaperSize GetLetterPaperSize(string printerName)
        {
            PrinterSettings printerSettings = new PrinterSettings { PrinterName = printerName };

            PrinterSettings.PaperSizeCollection paperSizeCollection = printerSettings.PaperSizes;

            foreach (PaperSize paperSize in paperSizeCollection)
            {
                // The second check is because French machines use a Custom PaperKind for Letter, but the PaperName is still Letter
                if (PaperKind.Letter.Equals(paperSize.Kind) || LetterPaperName.Equals(paperSize.PaperName))
                {
                    // create a new PaperSize wih the letter paperkind in it.
                    PaperSize letterPaperSize = new PaperSize(paperSize.PaperName, paperSize.Width, paperSize.Height) { RawKind = (int)PaperKind.Letter };
                    return letterPaperSize;
                }
            }
            return default(PaperSize);
        }
    }
}
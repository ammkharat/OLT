using System.Drawing;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class PrintOptions
    {
        public Duplex Duplex { get; private set; }
        public string PrinterName { get; private set; }
        public int NumberOfCopies { get; private set; }
        public bool Collate { get; private set; }
        public PrintRange PrintRange { get; private set; }
        
        private PaperSize PaperSize { get; set; }

        public PrintOptions(string printerName, int numberOfCopies, bool collate, PrintRange pageRange, Duplex duplex, PaperSize paperSize)
        {
            PrinterName = printerName;
            NumberOfCopies = numberOfCopies;
            Collate = collate;
            PrintRange = pageRange;
            Duplex = duplex;
            PaperSize = paperSize;
        }

        public void ApplyToReport(XtraReport report)
        {
            report.PageSize = new Size(PaperSize.Width, PaperSize.Height);
            report.PaperKind = PaperSize.Kind;
            report.PaperName = PaperSize.PaperName;
            //Added for Montrealwork permit print only
            if (report.GetType() != typeof(Com.Suncor.Olt.Reports.WorkPermitMontrealReport))
            report.PrintingSystem.PageSettings.Assign(report.Margins, PaperSize.Kind, new Size(PaperSize.Width, PaperSize.Height), report.PrintingSystem.PageSettings.Landscape);
        }
    }
}